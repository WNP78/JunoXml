#!/usr/bin/dotnet run
#:package Mono.Cecil@0.11.6
#nullable disable

using static System.Console;
using Mono.Cecil;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;

string GetScriptPath([CallerFilePath] string filePath = "") => filePath;

var rootDir = Path.GetDirectoryName(GetScriptPath());
var cachePath = Path.Combine(rootDir, "asm_path.txt");
var filePath = File.ReadAllText(cachePath).Trim();
var module = ModuleDefinition.ReadModule(filePath);
((DefaultAssemblyResolver)module.AssemblyResolver).AddSearchDirectory(new FileInfo(filePath).DirectoryName);
var modApi = module.AssemblyResolver.Resolve(module.AssemblyReferences.First(e => e.Name == "ModApi")).MainModule;

var lg = module.GetType("Assets.Scripts.Craft.Parts.Modifiers.LandingGear.LandingGearData");

Console.WriteLine(lg);
var prop = lg.Properties.Single(x => x.Name == "Extended").PropertyType;
WriteLine(prop.FullName);

public static class CecilTypeExtensions
{
    public static string FormatTypeString(this TypeReference type, bool includeNamespace)
    {
        if (type == null) return string.Empty;

        if (type is ArrayType array)
        {
            string rank = new(',', array.Rank - 1);
            return $"{array.ElementType.FormatTypeString(includeNamespace)}[{rank}]";
        }

        if (type is ByReferenceType byRef)
        {
            return $"ref {byRef.ElementType.FormatTypeString(includeNamespace)}";
        }

        if (type is PointerType pointer)
        {
            return $"{pointer.ElementType.FormatTypeString(includeNamespace)}*";
        }

        if (type is GenericInstanceType generic)
        {
            if (generic.ElementType.FullName == "System.Nullable`1")
            {
                return $"{generic.GenericArguments[0].FormatTypeString(includeNamespace)}?";
            }

            var baseName = GetCleanClassName(generic.ElementType, includeNamespace);
            var arguments = string.Join(", ", generic.GenericArguments.Select(x => x.FormatTypeString(includeNamespace)));
            return $"{baseName}<{arguments}>";
        }

        return GetCleanClassName(type, includeNamespace);
    }

    private static string GetCleanClassName(TypeReference type, bool includeNamespace)
    {
        switch (type.FullName)
        {
            case "System.Void": return "void";
            case "System.Object": return "object";
            case "System.String": return "string";
            case "System.Boolean": return "bool";
            case "System.Byte": return "byte";
            case "System.SByte": return "sbyte";
            case "System.Char": return "char";
            case "System.Decimal": return "decimal";
            case "System.Double": return "double";
            case "System.Single": return "float";
            case "System.Int32": return "int";
            case "System.UInt32": return "uint";
            case "System.Int64": return "long";
            case "System.UInt64": return "ulong";
            case "System.Int16": return "short";
            case "System.UInt16": return "ushort";
            case "System.IntPtr": return "nint";
            case "System.UIntPtr": return "nuint";
            default: break;
        }

        if (type.IsGenericParameter)
        {
            return type.Name;
        }

        string name = type.Name;
        int tickIndex = name.IndexOf('`');
        if (tickIndex > 0)
        {
            name = name[..tickIndex];
        }

        if (type.DeclaringType != null)
        {
            return $"{GetCleanClassName(type.DeclaringType, includeNamespace)}.{name}";
        }

        if (includeNamespace && !string.IsNullOrEmpty(type.Namespace))
        {
            return $"{type.Namespace}.{name}";
        }

        return name;
    }
}