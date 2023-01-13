[Home](https://wnp78.github.io/JunoXml/)

# RocketEngine


|Name|Type|Description|
|--|--|--|
|`chamberPressure`|`float`|Higher chamber pressures can increase thrust and efficiency, but add additional cost.|
|`engineSubTypeId`|`string`|The method used for injecting the propellant, which can greatly impact the performance of the engine.|
|`engineTypeId`|`string`|The type of rocket engine.|
|`engineSoundOverride`|`string`||
|`thrustOverride`|`float`||
|`massFlowRateOverride`|`float`||
|`wattsPerFuelFlowOverride`|`float`||
|`minThrottleOverride`|`float`||
|`throttleResponse`|`float`||
|`heatTransferOverride`|`float`||
|`directDamage`|`float`||
|`overexpansionDamage`|`float`||
|`hasSmoke`|`bool`||
|`exhaustColor`|`string`||
|`exhaustOffset`|`float`||
|`exhaustWhiteIntensity`|`float`||
|`exhaustScale`|`float`||
|`smokeSpeedOverride`|`float`||
|`smokeColor`|`string`||
|`fuelType`|`string`|The type of fuel to use. Connected fuel tanks will be automatically updated to this fuel type if they have the Auto Select Fuel Type setting enabled.|
|`gimbalRange`|`float`|The maximum allowable range that the engine can rotate to assist in controlling the craft's attitude.|
|`mass`|`float`||
|`nozzleSize`|`float`|Increasing the nozzle length can increase the Nozzle Ratio, which will improve vacuum efficiency but it can decrease sea level efficiency and it adds additional mass and cost.|
|`nozzleThroatSize`|`float`|Increasing the throat size can increase thrust, but will decrease the Nozzle Ratio, which decreases efficiency in a vacuum.|
|`nozzleTypeId`|`string`|The nozzle style.|
|`fuelGrain`|`string`|The fuel grain of the solid propellant, defining its thrust curve.|
|`price`|`Int64`||
|`size`|`float`|Changes the overall size of the engine. Increasing size can increase thrust, but it also increases mass and price.|
|`supportsWarpBurn`|`bool`||


