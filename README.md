# SR2 XML Guide
The big difference between SP and SR2 modding is that you can add new modifiers to things as you like. For instance, a landing leg might not have an `InputBasedActivator` on it by default, but you can just add one.

## InputControllers
An `InputController` takes an input value, chosen by it's `input` property, then applies a set of transformations to it, mapping it to the final range of `min` to `max`, optionally inverting it. Other modifiers then use the `InputController`'s output value as their input.

### Options
|Option|Type|Description|
|---|---|---|
|`min`|float|The minimum output value|
|`max`|float|The maximum output value|
|`invert`|bool|Invert the value?|
|`invertOnMirror`|bool|Invert when the part is mirrored?|
|`invertType`|bool|If `Output`, then the value will be inverted after mapping. If `Axis`, it will be before mapping.|
|`zeroOnDeactivate`|bool|If false, the value will remain frozen when deactivated. If true it will go to zero.|
|`input`|input|The input axis to use. More details below.|
|`ignorePartActivationState`|bool|If set to true, then the input controller will function even when the part is not activated. This is required for auto-activating parts.|
