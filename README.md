# SR2 XML Guide
This guide is under construction. Patience.

The big difference between SP and SR2 modding is that you can add new modifiers to things as you like. For instance, a landing leg might not have an `InputBasedActivator` on it by default, but you can just add one.

If you find, or think you have found, any inaccuracies or omissions, do not be afraid to ask, or submit a PR.

## InputControllers
An `InputController` takes an input value, chosen by it's `input` property, then applies a set of transformations to it, mapping it to the final range of `min` to `max`, optionally inverting it. Other modifiers then use the `InputController`'s output value as their input.

### Options
|Option|Type|Description|
|---|---|---|
|`activationGroup`|`int`|The activation group assigned to the inputcontroller. When this is disabled, the inputcontroller will not update it's input.|
|`currentValue`|`float`|This is used in-game, when saving the game's state.|
|`designerInputOptions`|`string`|This is the comma separated list of available inputs in the part properties panel. This is overriden by the "Show Hidden Properties" checkbox in the Tinker panel.|
|`ignorePartActivationState`|`bool`|If set to true, then the input controller will function even when the part is not activated. This is required for auto-activating parts.|
|`input`|`string`|The input axis to use. More details below.|
|`inputAxisRange`|`InputControllerInputRange`|One, two or three numbers, comma separated. More detail below.|
|`inputAxisRangeDesigner`|`string`|The designer field for the above property.|
|`invert`|`bool`|Invert the value?|
|`invertOnMirror`|`bool`|Invert when the part is mirrored?|
|`invertType`|`InvertType`|If `Output`, then the value will be inverted after mapping. If `Axis`, it will be before mapping.|
|`max`|`float`|The maximum output value|
|`min`|`float`|The minimum output value|
|`overrideInput`|`string`|If assigned, this will override the `input` field.|
|`showActivationGroup`|`bool`|Controls if the activation group spinner is shown in the designer.|
|`showInputAxis`|`bool`|Controls if the input axis spinner is shown in the desinger.|
|`showInvert`|`bool`|Controls if the invert checkbox is shown in the deisgner.|
|`type`|`InputControllerType`|This is the method used to map the input to the output range. More below.|
|`zeroOnDeactivate`|`bool`|If false, the value will remain frozen when deactivated. If true it will go to zero.|

### Option Values

|InputControllerType|Description (from in-game tooltip)|
|---|---|
|Standard|A positive axis will be multiplied by the max value. A negative axis will be multiplied by the min value. |
|Lerp Full Axis|The output value will be linearly interpolated between the min and max values assuming an input axis of -1 to 1. |
|Lerp Positive Axis|The output value will be linearly interpolated between the min and max values assuming an input axis of 0 to 1. |
|Lerp Negative Axis|The output value will be linearly interpolated between the min and max values assuming an input axis of -1 to 0.|


### Input Axes
There are many things you can put in the `input` field. It's rather quite exciting. For a start, you can access any "control" in this list.

|Controls|
|---|
|`Brake`|
|`OffsetBrake`|
|`OffsetPitch`|
|`OffsetRoll`|
|`OffsetSlider1`|
|`OffsetSlider2`|
|`OffsetYaw`|
|`Pitch`|
|`Roll`|
|`RollInputReceived`|
|`Slider1`|
|`Slider2`|
|`Throttle`|
|`TranslateForward`|
|`TranslateRight`|
|`TranslateUp`|
|`Yaw`|

If you want to, you can just put a constant value in there. Like `0.5`, `-1`, or even `.3`. This will just remain constant.

But it goes on. You can also access Flight Data.

|Flight Data|
|---|
|`FlightData.AltitudeAboveGroundLevel`|
|`FlightData.AltitudeAboveSeaLevel`|
|`FlightData.CurrentEngineThrust`|
|`FlightData.CurrentMass`|
|`FlightData.MaxActiveEngineThrust`|
|`FlightData.ParentPlanetOcclusion`|
|`FlightData.RemainingBattery`|
|`FlightData.RemainingFuelInStage`|
|`FlightData.RemainingMonopropellant`|
|`FlightData.SolarRadiationIntensity`|
|`FlightData.SurfaceVelocityMagnitude`|
|`FlightData.VelocityMagnitude`|

How awesome! Then it gets even more complex. You can assign, to any part modifier (the sub elements under `<Part>`), an `id` value, that uniquely identifies that modifier within the craft. You can then reference that from the InputController and get a value from that modifier. There are two ways to do this. Firstly, the modifier itself can act as an input. To do this, you just add the modifier ID straight out. This only works if that particular modifier is able to act as an InputControllerInput, and nothing does that at the moment. But don't fret! Something probably will in the future. Also, there's another way. By inputting the modifier ID, then a `.`, then a property name, you can get any property from the modifier! The properties you can choose are all listed in [this page](https://github.com/WNP78/Sr2Xml/blob/master/PartModifierScriptProperties.md).
