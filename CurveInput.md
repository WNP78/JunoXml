[Home](https://wnp78.github.io/Sr2Xml/)

# CurveInput


|Name|Type|Description|
|--|--|--|
|`amplitude`|`float`|The amplitude of the curve.|
|`frequency`|`float`|The frequency of the curve.|
|`ignorePartActivationState`|`bool`|If true, the part does not need to be active in order for the curve to be updated.|
|`keyframes`|`string`|Keyframes should be separated by the '|' character, with each keyframe having values separated by the ',' character. A keyframe should define a time value and an output value. Optionally, the keyframe may specify a third value the definesthe incoming and outgoing tangents, or a third and fourth value that define the incoming and outgoing tangents respectively. Example: 0.0,0.0|0.5,1.0|1.0,0.0|
|`offset`|`float`|The initial time offset value used when when the curve is created.|
|`style`|`CurveStyle`|The style of the curve.|
|`updateInWarp`|`bool`|If enabled, the curve will continue to update in warp mode. If disabled, the current time of the curve will remain unchanged while warp mode is active.|
|`useUnscaledTime`|`bool`|If enabled, unscaled time will be used when updating the curve every frame. This is the time delta between this frame and the last frame, ignoring the effects of fast forward, slow motion, and warp mode.|
|`wrapMode`|`CurveWrapMode`|Determines how the curve is evaluated when the time value extends beyond the extents of the curve.|


