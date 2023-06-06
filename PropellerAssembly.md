[Home](https://wnp78.github.io/JunoXml/)

# PropellerAssembly


|Name|Type|Description|
|--|--|--|
|`basePrice`|`int`||
|`bladeBlurCount`|`int`||
|`bladeBlurSpread`|`float`||
|`bladeCount`|`int`|The number of propeller blades. More blades means more thrust given the same RPM, but also more drag and mass for the motor to spin.|
|`chordRadiusRatio`|`float`||
|`chordScale`|`float`|The width (chord-length) of the propeller blades|
|`defaultDiameter`|`float`||
|`density`|`float`||
|`dragScalar`|`float`||
|`hubScale`|`float`|The scale of the propeller hub/cone|
|`isWaterProp`|`bool`||
|`maxPitch`|`float`|The propeller blade's pitch setting, which is either used to determine the fixed pitch of the blades, or maximum pitch, depending on blade control type.|
|`pitchControlType`|`PitchControl`|The pitch of the blades can either be fixed, or controlled via an input controller during flight.|
|`reverseBladeDirection`|`bool`|Reverses the direction the propellers are facing as well as inverting an attached motor's input controller, if "Sync with motor" is enabled.|
|`size`|`float`|Changes the overall size/scale of the propeller assembly|
|`spinTolerance`|`float`||
|`styleId`|`string`||
|`styleIdHub`|`string`||
|`syncWithMotor`|`bool`|Synchronizes changes between blade direction and motor rotation.|
|`thrustScalar`|`float`||


