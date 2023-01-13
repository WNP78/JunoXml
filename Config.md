[Home](https://wnp78.github.io/JunoXml/)

# Config


|Name|Type|Description|
|--|--|--|
|`addFlightProgramButton`|`bool`|Adds a flight program to this part.|
|`autoActivateIfNoStageOrActivationGroup`|`bool`|Automatically activates the part if it isn't assigned to any Activation Group or Stage.|
|`buoyancyBaseScale`|`float`||
|`buoyancyUserScale`|`float`|Changes how buoyant the part is in water.|
|`castShadows`|`bool`|Define if the part group should cast shadows on other parts and the terrain while in flight.|
|`centerOfMass`|`Vector3`||
|`changeCommandPod`|`bool`|Change the command pod that controls this part.|
|`collisionDisconnectImpulse`|`float`||
|`collisionDisconnectVelocity`|`float`||
|`collisionExplodeImpulse`|`float`||
|`collisionExplodeVelocity`|`float`||
|`collisionPreventExternalDisconnections`|`bool`||
|`collisionVelocityMode`|`PartCollisionVelocityMode`||
|`descriptionLabel`|`string`||
|`dragScale`|`float`|Changes this part's contribution to the craft's overall drag force.|
|`dragScaleActive`|`float`||
|`explosiveness`|`float`|Changes how much explosiveness this part has.|
|`fuelLine`|`bool`|Allow connected engines to search this part and its connected parts for fuel tanks.|
|`heatShield`|`float`||
|`heatShieldBaseScale`|`float`||
|`heatShieldMass`|`float`||
|`heatShieldScale`|`float`|A heat shield layer that prevents heat damage until it gets depleted.|
|`heatShieldValidation`|`bool`||
|`ignoreValidation`|`bool`||
|`includeInDrag`|`bool`|Determines whether or not to include this part in the drag model.|
|`inertiaTensorBaseScale`|`float`||
|`inertiaTensorMin`|`float`||
|`inertiaTensorUserScale`|`float`|Increase to strengthen movable joints which are wobbly. Increase slowly, and only as much as necessary until the joint is stable as it can dramatically slow down rotation, or cause other issues if raised too much. Note: It is irrelevant which part within a group is adjusted; values are summed between parts in a group and applied to the group as a whole.|
|`initialCraftNodeId`|`int`||
|`massScale`|`float`|Handy way to trick the laws of physics and increase or decrease the mass of this part.|
|`maxDamage`|`float`||
|`maxDrag`|`float`||
|`maxDragActive`|`float`||
|`maxTemperature`|`float`|The maximum temperature, in Kelvin, that this part can withstand before taking heat damage or depleting its heat shield.|
|`occlusion`|`OcclusionCalculationType`|Changes how the occlusion state of the part is calculated. Some parts will not function if they are occluded, such as wings and inlets. Auto will calculate if the part is occluded by other surrounding parts. Always will always consider the part as occluded. Never will never consider the part as occluded.|
|`partCollisionHandling`|`PartCollisionHandlingMethod`|Determines how collisions are handled when two parts bump into each other.|
|`partCollisionResponse`|`PartCollisionResponseType`|Determines how this part reacts when it takes a solid hit.|
|`partIdLabel`|`string`||
|`partScale`|`Vector3`||
|`partScaleMagnitude`|`float`|Changes the size of the part. This can cause odd behavior, so for parts that have a dedicated size setting or tool we recommend you use that instead of this.|
|`partSelectionEnabled`|`bool`||
|`preventDebris`|`bool`|Prevent this part (and connected parts) from being automatically removed when separated from the player's craft.|
|`priceScale`|`float`|Handy way to adjust the cost of this part to fit your budget.|
|`raiseWaterEventsEvenIfNotBuoyant`|`bool`||
|`renderQueue`|`PartMeshRenderQueue`|The render queue for the part. Rendering before the depth mask will allow some parts to be visible inside of cockpits where they might not otherwise be visible. Transparent objects may not display correctly.|
|`showHiddenPartProperties`|`bool`||
|`stageActivationType`|`StageActivationType`|Changes the current stage activation type of the part.|
|`supportsActivation`|`bool`||
|`supportsTransparency`|`bool`|When enabled this part will respond to transparent materials. Note that this can cause some parts to render in strange and mysterious ways, so use with caution.|
|`thermalMassRatio`|`float`||
|`tinkerPanelEnabled`|`bool`||
|`tutorialId`|`string`||
|`viewCommandPod`|`bool`|View the command pod that controls this part.|
|`xmlEditButton`|`bool`|Opens a window that shows all the parameters in the different modifiers found in the part, with all its available parameters.|


