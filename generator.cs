#!/usr/bin/dotnet run
#:package Mono.Cecil@0.11.6
#nullable disable

using Mono.Cecil;
using System.Text;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Mono.Cecil.Cil;

namespace ModifierPropertiesExtractor;

static class Program
{
    static Dictionary<string, string> TypeMap = new Dictionary<string, string>
    {
        { "System.Single", "float" },
        { "System.Int32", "int" },
        { "System.Double", "double" },
        { "System.String", "string" },
        { "System.Boolean", "bool" },
        { "UnityEngine.Vector3d", "vector" },
    };

    static ModuleDefinition module;
    static ModuleDefinition modApi;
    static string rootDir;
    static XDocument _Manifest;
    static XElement ManifestRoot;
    static void Main(string[] args)
    {
        rootDir = Path.GetDirectoryName(GetScriptPath());

        _Manifest = XDocument.Load(rootDir + "\\manifest.xml");
        ManifestRoot = _Manifest.Root;

        string filePath = null;
        string cachePath = Path.Combine(rootDir, "asm_path.txt");
        if (File.Exists(cachePath))
        {
            filePath = File.ReadAllText(cachePath).Trim();
            if (!Path.Exists(filePath)) filePath = null;
        }

        if (filePath != null)
        {
            Console.WriteLine($"Saved path is {filePath} - leave field empty to use");
        }
        Console.Write("Path to SimpleRockets2.dll> ");
        string inputPath = Console.ReadLine();
        if (!string.IsNullOrEmpty(inputPath)) filePath = inputPath;
        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("No assembly path entered!");
            return;
        }
        else if (!File.Exists(filePath))
        {
            Console.WriteLine("File path does not exist!");
            return;
        }

        File.WriteAllText(cachePath, filePath);

        module = ModuleDefinition.ReadModule(filePath);
        ((DefaultAssemblyResolver)module.AssemblyResolver).AddSearchDirectory(new FileInfo(filePath).DirectoryName);
        modApi = module.AssemblyResolver.Resolve(module.AssemblyReferences.First(e => e.Name == "ModApi")).MainModule;

        Console.WriteLine("Got module: " + module.Name);
        Console.WriteLine("Got module: " + modApi.Name);
        Console.Write("Action (default GenPages)> ");
        string command = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(command)) command = "GenPages";
        switch (command)
        {
            case "GetModifierScriptProperties":
                var w = new StreamWriter(Console.OpenStandardOutput());
                GetModifierScriptProperties(w);
                w.Close();
                break;
            case "GetPartModifierOptions":
                GetPartModifierOptions();
                break;
            case "GenPages":
                GeneratePages();
                break;
            case "GetControls":
                using (var s = new StreamWriter(Console.OpenStandardOutput()))
                {
                    GetControls(s);
                }
                break;
            default:
                Console.WriteLine("Unknown Command");
                break;
        }
        Console.Write("Press any key to exit.");
        Console.ReadKey();

    }

    private static string GetScriptPath([CallerFilePath] string filePath = "") => filePath;

    private static void GetControls(StreamWriter stream)
    {
        var controls = modApi.GetType("ModApi.Craft.CraftControls");

        if (controls == null)
        {
            stream.WriteLine("Error: could not find ModApi.Craft.CraftControls");
        }
        else
        {
            stream.WriteLine("|Controls|");
            stream.WriteLine("|---|");
            foreach (PropertyDefinition property in controls.Properties)
            {
                var name = property.PropertyType.Name;
                if (name == "Single" || name == "Double" || name == "Boolean")
                {
                    stream.Write("|`");
                    stream.Write(property.Name);
                    stream.WriteLine("`|");
                }
            }

            stream.WriteLine();
            stream.WriteLine();
        }

        ExtractDataClass("Assets.Scripts.Craft.FlightData.CraftFlightData", "FlightData", "Flight Data");
        stream.WriteLine();
        ExtractDataClass("Assets.Scripts.Craft.FlightData.CraftOrbitData", "OrbitData", "Orbit Data");

        void ExtractDataClass(string klass, string prefix, string title)
        {
            var type = module.GetType(klass);

            if (type == null)
            {
                stream.WriteLine("Error: could not find " + prefix);
            }
            else
            {
                stream.WriteLine($"|{title}|Type|");
                stream.WriteLine("|---|---|");
                foreach (PropertyDefinition property in type.Properties)
                {
                    if (TypeMap.TryGetValue(property.PropertyType.FullName, out string typeName))
                    {
                        stream.Write($"|`{prefix}.");
                        stream.Write(property.Name);
                        stream.Write("`|`");
                        stream.Write(typeName);
                        stream.WriteLine("`|");
                    }
                }
            }
        }
    }

    static void GetModifierScriptProperties(StreamWriter stream)
    {
        stream.WriteLine("|Name|Type|\n|--|--|");
        foreach (TypeDefinition type in module.Types)
        {
            bool isMod = false;
            bool isModData = false;
            TypeReference t = type.BaseType;
            while (t != null)
            {
                if (t.FullName.StartsWith("ModApi.Craft.Parts.PartModifierScript"))
                {
                    isMod = true;
                    break;
                }
                if (t.Scope.Name != module.Name) { break; }
                t = t.Resolve().BaseType;
            }
            if (!isMod)
            {
                while (t != null)
                {
                    if (t.FullName.StartsWith("ModApi.Craft.Parts.PartModifierData"))
                    {
                        isModData = true;
                        break;
                    }
                    if (t.Scope.Name != module.Name) { break; }
                    t = t.Resolve().BaseType;
                }
            }

            if (isMod || isModData)
            {
                string name = type.Name;
                if (name.EndsWith("Script"))
                {
                    name = name.Remove(name.Length - 6);
                }
                else if (isModData && name.EndsWith("Data"))
                {
                    name = name.Remove(name.Length - 4);
                }
                name = name + ".";
                if (isModData) { name += "Data."; }
                foreach (var property in type.Properties)
                {
                    string typeName = null;
                    var propType = property.PropertyType;
                    if (propType.FullName == "System.Single")
                    {
                        typeName = "float";
                    }
                    else if (propType.FullName == "System.Double")
                    {
                        typeName = "double";
                    }
                    else if (propType.FullName == "System.Boolean")
                    {
                        typeName = "bool";
                    }
                    else
                    {
                        continue;
                    }
                    string pname = property.Name;
                    if (pname.Contains("."))
                    {
                        pname = pname.Substring(pname.LastIndexOf('.') + 1);
                    }
                    if (pname.StartsWith("_")) { continue; } // relies on style rules being obeyed...
                    stream.WriteLine("|`" + (name + pname).Replace("|", "\\|") + "`|" + typeName.Replace("|", "\\|") + "|");
                }
            }
        }
    }

    static void GeneratePages()
    {
        List<Page> contents = new List<Page>();
        foreach (TypeDefinition modifierType in module.Types.Concat(modApi.Types).Where(IsPartModifierData))
        {
            List<PropertyEntry> properties = new List<PropertyEntry>();
            foreach (var field in modifierType.Fields)
            {
                foreach (var attr in field.CustomAttributes)
                {
                    if (IsPartModifierProperty(field, out string description, out bool designerOnly))
                    {
                        if (designerOnly)
                        {
                            description = "Designer only. " + (description ?? "");
                        }
                        if (!TypeMap.TryGetValue(field.FieldType.FullName, out string type)) { type = field.FieldType.Name; }
                        properties.Add(new PropertyEntry
                        {
                            Name = field.Name.TrimStart('_'),
                            Type = type,
                            Desc = description ?? ""
                        });
                        break;
                    }
                }
            }
            string name = modifierType.Name;
            if (name.EndsWith("Data"))
            {
                name = name.Remove(name.Length - 4);
            }
            GeneratePage(rootDir + "\\" + name + ".md", name, ManifestRoot, properties, contents);
        }

        var Game = module.GetType("Assets.Scripts.Game");
        string version = null;
        var cctor = Game?.Methods.First(m => m.Name == ".cctor");
        if (cctor != null)
        {
            List<int> versionQueue = new List<int>();
            foreach (var i in cctor.Body.Instructions)
            {
                if (i.OpCode == OpCodes.Newobj && (i.Operand as MethodReference).DeclaringType.Name == "Version")
                {
                    if (versionQueue.Count > 3)
                    {
                        version = (string.Join(".", versionQueue.GetRange(versionQueue.Count - 4, 4)));
                    }
                    break;
                }
                if (!i.OpCode.Code.ToString().StartsWith("Ldc_I4")) { continue; }
                if (i.OpCode == OpCodes.Ldc_I4)
                {
                    versionQueue.Add((int)i.Operand);
                }
                else if (i.OpCode == OpCodes.Ldc_I4_S)
                {
                    versionQueue.Add(((IConvertible)i.Operand).ToInt32(System.Globalization.CultureInfo.InvariantCulture));
                }
                else
                {
                    versionQueue.Add(int.Parse(i.OpCode.Code.ToString().Split('_').Last()));
                }
            }

        }


        UpdatePartModifierPropertiesPage();
        UpdateMainPage(contents, version);
        _Manifest.Save(rootDir + "\\/manifest.xml");
    }

    static void GetPartModifierOptions()
    {
        foreach (TypeDefinition type in module.Types.Concat(modApi.Types))
        {
            if (IsPartModifierData(type))
            {
                string tname = type.Name;
                if (tname.EndsWith("Data")) { tname = tname.Remove(tname.Length - 4); }
                string filePath = rootDir + "\\" + tname + ".md";
                StringBuilder s = new StringBuilder();
                bool wrote = false;
                foreach (FieldDefinition field in type.Fields)
                {
                    if (IsPartModifierProperty(field, out string description, out bool designerOnly))
                    {
                        if (designerOnly)
                        {
                            description = "Designer only. " + (description ?? "");
                        }
                        string name = field.Name.TrimStart('_');
                        if (!TypeMap.TryGetValue(field.FieldType.FullName, out string typeName))
                        {
                            typeName = field.FieldType.Name;
                        }
                        s.Append("|`");
                        s.Append(name.Replace("|", "\\|"));
                        s.Append("`|`");
                        s.Append(typeName.Replace("|", "\\|"));
                        s.Append("`|");
                        s.Append(description.Replace("|", "\\|"));
                        s.AppendLine("|");
                        wrote = true;
                    }
                }
                string tableHead = "|Name|Type|Description|\n|--|--|--|\n";
                if (!wrote)
                {
                    s.AppendLine("This Part Modifier type has no XML properties.");
                    tableHead = "";
                }
                File.WriteAllText(filePath, "# " + tname + "\n\n" + tableHead + s.ToString());
                Console.WriteLine("   - [" + tname + "](/JunoXml/" + tname + ")");
            }
        }
    }

    static bool IsPartModifierData(TypeDefinition type)
    {
        if (type.IsAbstract) { return false; }
        TypeReference t = type.BaseType;
        while (t != null)
        {
            if (t.FullName.StartsWith("ModApi.Craft.Parts.PartModifierData"))
            {
                return true;
            }
            t = t.Resolve().BaseType;
        }
        return false;
    }
    static bool IsPartModifierProperty(FieldDefinition field, out string tooltip, out bool designerOnly)
    {
        designerOnly = false;
        tooltip = null;
        try
        {
            foreach (var attr in field.CustomAttributes)
            {
                TypeDefinition at = attr.AttributeType.Resolve();
                while (at != null)
                {
                    if (at.FullName == "ModApi.Craft.Parts.Attributes.PartModifierPropertyAttribute")
                    {
                        foreach (var a in attr.Properties)
                        {
                            if (a.Name == "Tooltip") { tooltip = (string)a.Argument.Value; }
                            if (a.Name == "DesignerOnly" && (bool)a.Argument.Value == true)
                            {
                                designerOnly = true;
                            }
                        }
                        return true;
                    }
                    if (at.BaseType == null) { break; }
                    at = at.BaseType.Resolve();
                }
            }
        }
        catch (AssemblyResolutionException) { }
        return false;
    }

    class PropertyEntry
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }

    }

    static void GeneratePage(string path, string name, XElement manifest, List<PropertyEntry> properties, List<Page> contents)
    {
        XElement element = manifest.Element(name);
        if (element == null)
        {
            element = new XElement(name);
            manifest.Add(element);
        }
        var overrides = element.Element("Overrides");
        if (overrides == null)
        {
            var o = new XElement("Overrides");
            element.Add(o);
            overrides = o;
        }
        var customs = element.Element("Customs");

        contents.Add(new Page()
        {
            name = name,
            children = element.GetStringAttribute("childPages")?.Split(',') ?? new string[] { }
        });
        using (var file = File.CreateText(path))
        {
            file.WriteLine("[Home](https://wnp78.github.io/JunoXml/)\n");
            string head = element.GetChildContents("Head");
            if (string.IsNullOrEmpty(head))
            {
                head = "# " + name + "\n";
            }
            file.WriteLine(head);
            if (properties.Count == 0 && customs == null)
            {
                file.WriteLine("This Part Modifier type has no XML properties.");
            }
            else
            {
                file.WriteLine("\n|Name|Type|Description|\n|--|--|--|");
                foreach (var property in properties)
                {
                    var over = overrides.Element(property.Name);
                    if (over == null)
                    {
                        over = new XElement(property.Name);
                        overrides.Add(over);
                    }
                    string type = over.GetStringAttribute("type", property.Type);
                    if (TypeMap.ContainsKey(type)) { type = TypeMap[type]; }
                    string desc = over.Value?.Trim();
                    if (string.IsNullOrEmpty(desc)) { desc = property.Desc; }
                    desc = desc.Replace("\r\n", "\n").Replace('\n', ' ');
                    file.WriteLine("|`" + (over.Name.LocalName ?? property.Name).Replace("|", "\\|") + "`|`" + type.Replace("|", "\\|") + "`|" + desc.Replace("|", "\\|") + "|");
                }
                if (customs != null)
                {
                    foreach (var custom in customs.Elements())
                    {
                        file.WriteLine("|`" + custom.Name.LocalName + "`|`" + custom.GetStringAttribute("type", "string") + "`|" + custom.Value.Trim().Replace("\r", "").Replace("\n", "") + "|");
                    }
                }
            }

            file.Write('\n');
            string foot = element.GetChildContents("Footer", "");
            const string flagword = "{{INPUTS}}";
            int index = foot.IndexOf(flagword);
            if (index != -1)
            {
                file.Write(foot.Substring(0, index));
                GetControls(file);
                file.Write(foot.Substring(index + flagword.Length));
            }
            else
            {
                file.WriteLine(foot);
            }
        }
    }

    static void UpdateMainPage(List<Page> modifiers, string version)
    {
        string path = Path.Combine(rootDir, "README.md");
        XElement over = ManifestRoot.Element("README");
        if (over == null)
        {
            over = new XElement("README");
            ManifestRoot.Add(over);
        }
        using (var file = File.CreateText(path))
        {
            string head = over.GetChildContents("Head", "# SR2 XML Guide");
            file.WriteLine(head + "\n");
            file.WriteLine("Game Version: `" + (version ?? "unknown") + "`\n");
            file.WriteLine("Contents:");
            foreach (var page in modifiers.OrderBy(p => p.name))
            {
                file.WriteLine(" - [" + page.name + "](/JunoXml/" + page.name + ")");
                foreach (var p in page.children)
                {
                    file.WriteLine("   - [" + p + "](/JunoXml/" + p + ")");
                }
            }
        }
    }

    static void UpdatePartModifierPropertiesPage()
    {
        string path = Path.Combine(rootDir, "PartModifierScriptProperties.md");
        XElement over = ManifestRoot.Element("PartModifierScriptProperties");
        if (over == null)
        {
            over = new XElement("PartModifierScriptProperties");
            ManifestRoot.Add(over);
        }
        using (var file = File.CreateText(path))
        {
            file.WriteLine("[Home](https://wnp78.github.io/JunoXml/)\n");
            file.WriteLine(over.GetChildContents("Head"));
            file.WriteLine("");
            GetModifierScriptProperties(file);
            file.Write(over.GetChildContents("Footer"));
        }
    }
}

public static class Extensions
{
    public static string GetChildContents(this XElement element, XName childName, string def = "")
    {
        var el = element.Element(childName);
        return el != null ? el.Value.Trim() : def;
    }
    public static string GetStringAttribute(this XElement element, XName name, string def = null)
    {
        var a = element.Attribute(name);
        return a != null ? a.Value : def;
    }
}
struct Page
{
    public string name;
    public string[] children;
}