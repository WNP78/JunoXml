[Home](https://wnp78.github.io/Sr2Xml/)

# InputController
An `InputController` takes an input value, chosen by it's `input` property, then applies a set of transformations to it, mapping it to the final range of `min` to `max`, optionally inverting it. Other modifiers then use the `InputController`'s output value as their input.

|Name|Type|Description|
|--|--|--|
|`activationGroup`|`int`|The activation group assigned to the inputcontroller. When this is disabled, the inputcontroller will not update it's input.|
|`currentValue`|`float`|This is used in-game, when saving the game's state.|
|`designerInputOptions`|`string`|This is the comma separated list of available inputs in the part properties panel. This is overriden by the "Show Hidden Properties" checkbox in the Tinker panel.|
|`ignorePartActivationState`|`bool`|If set to true, then the input controller will function even when the part is not activated. This is required for auto-activating parts.|
|`input`|`string`|The input axis to use. More details below.|
|`inputAxisRange`|`string`|One, two or three numbers, comma separated. They define the range of the input values that are expected when mapping to output values. Can either be `max`, `min,max` or `min,zero,max`.|
|`inputAxisRangeDesigner`|`string`|The designer field for the `inputAxisRange` property.|
|`invert`|`bool`|Invert the value?|
|`invertOnMirror`|`bool`|Invert when the part is mirrored?|
|`invertType`|`string`|If `Output`, then the value will be inverted after mapping. If `Axis`, it will be before mapping.|
|`max`|`float`|The maximum output value|
|`min`|`float`|The minimum output value|
|`outputCurveAmplitude`|`float`|The amplitude of the output curve.|
|`outputCurveFrequency`|`float`|The frequency of the output curve.|
|`outputCurveKeyframes`|`string`|Keyframes should be separated by the '\|' character, with each keyframe having values separated by the ',' character. A keyframe should define a time value and an output value. Optionally, the keyframe may specify a third value the definesthe incoming and outgoing tangents, or a third and fourth value that define the incoming and outgoing tangents respectively. Example: 0.0,0.0\|0.5,1.0\|1.0,0.0|
|`outputCurveLabel`|`string`||
|`outputCurveOffset`|`float`|The offset value used when evaluating the output curve.|
|`outputCurveStyle`|`CurveStyle`|The style of the output curve.|
|`outputCurveWrapMode`|`CurveWrapMode`|Determines how the curve is evaluated when the axis value extends beyond the extents of the curve.|
|`overrideInput`|`string`|If assigned, this will override the `input` field.|
|`showActivationGroup`|`bool`|Controls if the activation group spinner is shown in the designer.|
|`showInputAxis`|`bool`|Controls if the input axis spinner is shown in the desinger.|
|`showInvert`|`bool`|Controls if the invert checkbox is shown in the deisgner.|
|`type`|`string`|This is the method used to map the input to the output range. See the `InputControllerType` table.|
|`zeroOnDeactivate`|`bool`|If false, the value will remain frozen when deactivated. If true it will go to zero.|
|`inputId`|`string`|Define what input the InputController is trying to override. See the `inputId` table.|

## Option Values

|InputControllerType|Description (from in-game tooltip)|
|---|---|
|`Standard`|A positive axis will be multiplied by the max value. A negative axis will be multiplied by the min value. |
|`LerpFullAxis`|The output value will be linearly interpolated between the min and max values assuming an input axis of -1 to 1. |
|`LerpPositiveAxis`|The output value will be linearly interpolated between the min and max values assuming an input axis of 0 to 1. |
|`LerpNegativeAxis`|The output value will be linearly interpolated between the min and max values assuming an input axis of -1 to 0.|

## Input Axes
There are many things you can put in the `input` field. It's rather quite exciting. For a start, you can access anything in this list.

|Controls|
|---|
|`Brake`|
|`EvaAnalogJump`|
|`EvaMoveFwdAft`|
|`EvaMoveUpDown`|
|`EvaPitch`|
|`EvaRoll`|
|`EvaShootTether`|
|`EvaStrafe`|
|`EvaTetherLength`|
|`EvaTetherLengthOffset`|
|`EvaTurn`|
|`EvaWalk`|
|`OffsetBrake`|
|`OffsetPitch`|
|`OffsetRoll`|
|`OffsetSlider1`|
|`OffsetSlider2`|
|`OffsetSlider3`|
|`OffsetSlider4`|
|`OffsetTranslateForward`|
|`OffsetTranslateRight`|
|`OffsetTranslateUp`|
|`OffsetYaw`|
|`Pitch`|
|`PitchInputReceived`|
|`Roll`|
|`RollInputReceived`|
|`Slider1`|
|`Slider2`|
|`Slider3`|
|`Slider4`|
|`Throttle`|
|`TranslateForward`|
|`TranslateRight`|
|`TranslateUp`|
|`TranslationModeEnabled`|
|`Yaw`|
|`YawInputReceived`|


|Flight Data|Type|
|---|---|
|`FlightData.Acceleration`|`vector`|
|`FlightData.AccelerationMagnitude`|`double`|
|`FlightData.AltitudeAboveGroundLevel`|`double`|
|`FlightData.AltitudeAboveSeaLevel`|`double`|
|`FlightData.AltitudeAboveTerrain`|`double`|
|`FlightData.AngleOfAttack`|`double`|
|`FlightData.AngularVelocityMagnitude`|`double`|
|`FlightData.BankAngle`|`double`|
|`FlightData.CraftForward`|`vector`|
|`FlightData.CraftRight`|`vector`|
|`FlightData.CraftUp`|`vector`|
|`FlightData.CurrentEngineThrust`|`float`|
|`FlightData.CurrentEngineThrustUnscaled`|`float`|
|`FlightData.CurrentMass`|`float`|
|`FlightData.CurrentMassUnscaled`|`float`|
|`FlightData.East`|`vector`|
|`FlightData.FuelMass`|`float`|
|`FlightData.Gravity`|`vector`|
|`FlightData.GravityMagnitude`|`float`|
|`FlightData.Grounded`|`bool`|
|`FlightData.Heading`|`double`|
|`FlightData.LateralSurfaceVelocity`|`double`|
|`FlightData.MachNumber`|`float`|
|`FlightData.MaxActiveEngineThrust`|`float`|
|`FlightData.MaxActiveEngineThrustUnscaled`|`float`|
|`FlightData.North`|`vector`|
|`FlightData.ParentPlanetOcclusion`|`float`|
|`FlightData.Pitch`|`double`|
|`FlightData.Position`|`vector`|
|`FlightData.PositionNormalized`|`vector`|
|`FlightData.RemainingBattery`|`float`|
|`FlightData.RemainingFuelInStage`|`float`|
|`FlightData.RemainingMonopropellant`|`float`|
|`FlightData.SideSlip`|`double`|
|`FlightData.SolarRadiationDirection`|`vector`|
|`FlightData.SolarRadiationIntensity`|`double`|
|`FlightData.SupportsWarpBurn`|`bool`|
|`FlightData.SurfaceVelocity`|`vector`|
|`FlightData.SurfaceVelocityMagnitude`|`double`|
|`FlightData.Velocity`|`vector`|
|`FlightData.VelocityMagnitude`|`double`|
|`FlightData.VerticalSurfaceVelocity`|`double`|
|`FlightData.WeightedThrottleResponse`|`float`|
|`FlightData.WeightedThrottleResponseTime`|`float`|


You can also access activation group states with `AG1` to `AG10`.
If you want to, you can just put a constant value in there. Like `0.5`, `-1`, or even `.3`. This will just remain constant. Additionally you can reference `pi`, `e`, `true` or `false` to get their respective values.

And you can even use some operators and functions:

|Operators and Functions|
|---|
|`Mathematical`|`+`, `-`, `*` and `/` |
|`Comparison`|`<`, `>`, `<=`, `>=`, `==`, `!=` |
|`Boolean`|`&`, `|`, `!`, Ternary operator: `(condition ? value_if_true : value_if_false)` |
|`abs(x)`|The absolute (positive) value of x. |
|`ceil(x)`|x rounded up to an integer. |
|`clamp(x, min, max)`|x clamped between min and max. |
|`clamp01(x)`|Equivalent to clamp(x, 0, 1). |
|`deltaangle(a, b)`|The shortest angle delta between angles a and b in degrees. |
|`exp(x)`|Returns e raised to the power of x. |
|`floor(x)`|x rounded down to an integer. |
|`inverselerp(a, b, x)`|Calculates the linear parameter t that produces the interpolant value within the range [a, b]. |
|`lerp(a, b, t)`|Linearly interpolates between a and b, by a proportion of t. |
|`lerpangle(a, b, t)`|Similar to lerp, but interpolates correctly when values pass 360 degrees. |
|`lerpunclamped(a, b, t)`|Similar to lerp, but doesn't clamp the value between a and b. |
|`log(x, p)`|The logarithm of x in base p. |
|`log10(x)`|Equivalent to log(x, 10). |
|`pingpong(x, l)`|"Ping-pongs" the value x so it is never larger than l and never less than 0. |
|`max(a, b)`|The largest value between a and b. |
|`min(a, b)`|The smallest value between a and b. |
|`pow(x, p)`|x raised to the power of p. |
|`repeat(x, l)`|Loops the value x so it is never larger than l and never less than 0. |
|`round(x)`|Rounds x to the nearest integer. |
|`sign(x)`|The sign of x (1 if x positive, -1 if x negative) |
|`smoothstep(a, b, t)`|Similar to lerp, but with smoothing at the ends. |
|`sqrt(x)`|The square root of x. |
|`sin(x)`|The sine of x (degrees) |
|`cos(x)`|The cosine of x (degrees) |
|`tan(x)`|The tangent of x (degrees) |
|`asin(x)`|The arc-sine of x (degrees) |
|`acos(x)`|The arc-cosine of x (degrees) |
|`atan(x)`|The arc-tangent of x (degrees) |

|Vector Operators and Functions|
|---|
|`angle(Vector from, Vector to)`|The difference in angle between two vectors (degrees) |
|`clampMagnitude(Vector vector, Number maxLength)`|A vector pointing in the same direction but with the indicated magnitude |
|`cross(Vector lhs, Vector rhs)`|The cross product of two vectors |
|`distance(Vector a, Vector b)`|The distance between the positions pointed at by two vectors |
|`dot(Vector lhs, Vector rhs)`|The dot product of two vectors |
|`exclude(Vector excludeThis, Vector fromThat)`|A vector with the components in the direction of fromThat removed, similar to projectOnPlane |
|`isNaN(Vector v)`|Checks if a vector is NaN |
|`lerp3(Vector from, Vector to, Number t)`|A linear interpolation between two vectors by the amount t |
|`magnitude(Vector vector)`|The length of a vector |
|`max3(Vector a, Vector b)`|A vector formed by the max components between the input vectors |
|`min3(Vector a, Vector b)`|A vector formed by the min components between the input vectors |
|`moveTowards(Vector current, Vector target, Number maxDistanceDelta)`|A vector interpolation limited by a maximum distance delta |
|`normalize(Vector vector)`|A vector with the same direction but with a magnitude of 1 |
|`project(Vector vector, Vector onNormal)`|A vector in the direction of onNormal with the length of the projection of the vector onto it |
|`projectOnPlane(Vector vector, Vector planeNormal)`|The projection of a vector onto a plane defined by its normal, similar to exclude |
|`reflect(Vector inDirection, Vector inNormal)`|A mirrored vector of inDirection relative to inNormal |
|`scale(Vector a, Vector b)`|The component-wise multiplication of a and b |
|`signedAngle(Vector from, Vector to, Vector axis)`|The signed angle in degrees between two vectors rotated around an axis |
|`slerp(Vector from, Vector to, Number t)`|A smooth interpolation between two vectors by the amount t |
|`sqrMagnitude(Vector vector)`|The square root of the length of the vector |
|`x(Vector)`|The X component of the vector |
|`y(Vector)`|The Y component of the vector |
|`z(Vector)`|The Z component of the vector |

How awesome! Then it gets even more complex. You can get parameters from different parts in the crafts using the following format:

	`[PartSelector].ModifierSelector[.Data][.PropertySelector]`

	`[PartSelector]`
	 - May be omitted to select the current part (must start with '.')
	 - May be '*' for legacy style of searching entire craft for a modifier id (specified by modifier selector)
	 - Matches part based on exact part name. If the part belongs to a group, the connected group parts will be searched first.

	`.ModifierSelector`
	 - Required
	 - First tries to match a modifier based on the modifier's 'id' property.
	 - If no match is found, it tries to match based on the modifier's type id (InputController, Piston, Gyroscope, etc)

	`[.Data]`
	 - If specified, it will match the part modifier data object
	 - If omitted, it will match the part modifier's script

	`[.PropertySelector]`
	 - Required (unless the target modifier implements the IInputControllerInput interface)
	 - Matches the name of a public float/double/bool property on the target object.

The properties you can choose are all listed in [this page](PartModifierScriptProperties).