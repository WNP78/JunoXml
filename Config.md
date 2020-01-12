[Home](https://wnp78.github.io/Sr2Xml/)

# Config


|Name|Type|Description|
|--|--|--|
|`addFlightProgramButton`|`bool`|Adds a flight program to this part.|
|`autoActivateIfNoStageOrActivationGroup`|`bool`||
|`buoyancyBaseScale`|`float`||
|`buoyancyUserScale`|`float`|Changes how buoyant the part is in water.|
|`centerOfMass`|`Vector3`||
|`collisionDisconnectImpulse`|`float`||
|`collisionDisconnectVelocity`|`float`||
|`collisionExplodeImpulse`|`float`||
|`collisionExplodeVelocity`|`float`||
|`collisionVelocityMode`|`PartCollisionVelocityMode`||
|`descriptionLabel`|`string`||
|`dragScale`|`float`|Changes this part's contribution to the craft's overall drag force.|
|`fuelLine`|`bool`|Allow connected engines to search this part and its connected parts for fuel tanks.|
|`heatShield`|`float`|Heat shield that prevents heat damage until it depletes.|
|`includeInDrag`|`bool`|Determines whether or not to include this part in the drag model.|
|`inertiaTensorBaseScale`|`float`||
|`inertiaTensorMin`|`float`||
|`inertiaTensorUserScale`|`float`|Increase to strengthen movable joints which are wobbly. Increase slowly, and only as much as necessary until the joint is stable as it can dramatically slow down rotation, or cause other issues if raised too much. Note: It is irrelevant which part within a group is adjusted; values are summed between parts in a group and applied to the group as a whole.|
|`massScale`|`float`|Handy way to trick the laws of physics and increase or decrease the mass of this part.|
|`maxDamage`|`float`||
|`maxTemperature`|`float`|The maximum temperature, in Celsius, that this part can withstand before taking heat damage or depleting its heat shield.|
|`partCollisionHandling`|`PartCollisionHandlingMethod`|Determines how collisions are handled when two parts bump into each other.|
|`partCollisionResponse`|`PartCollisionResponseType`|Determines how this part reacts when it takes a solid hit.|
|`partIdLabel`|`string`||
|`partScale`|`Vector3`||
|`partScaleMagnitude`|`float`|Changes the size of the part. This can cause odd behavior, so for parts that have a dedicated size setting or tool we recommend you use that instead of this.|
|`raiseWaterEventsEvenIfNotBuoyant`|`bool`||
|`showHiddenPartProperties`|`bool`||
|`stageActivationType`|`StageActivationType`|Changes the current stage activation type of the part.|
|`supportsActivation`|`bool`||
|`thermalMassRatio`|`float`||
|`tinkerPanelEnabled`|`bool`||


