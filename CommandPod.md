# CommandPod


|Name|Type|Description|
|--|--|--|
|`activationGroupNames`|`List`1`||
|`activationGroupStates`|`List`1`||
|`craftConfigType`|`CrafConfigurationType`|Changes the configuration of a craft. The configuration is used to drive various functions such as pilot orientation, rotation when certain parts are pulled out, and some default settings for parts.|
|`currentStage`|`int`||
|`editActivationGroups`|`bool`|Edit the names of your activation groups to help keep them organized.|
|`pilotSeatRotation`|`Vector3`||
|`primaryButton`|`bool`|Designer only. Assigns this as the primary command pod for the craft. The primary command pod will control all parts in the craft, except for those added from a previously made subassembly that included its own command pod. Note: The primary command pod cannot be deleted.|
|`reorientCraftOnConfigChange`|`bool`|If enabled, the craft will rotate when the configuration type changes.  You would want to disable this if a craft is already oriented correctly but needs to have its configuration type changed.|


