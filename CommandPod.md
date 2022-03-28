[Home](https://wnp78.github.io/Sr2Xml/)

# CommandPod


|Name|Type|Description|
|--|--|--|
|`autoPilotMaxPitchPid`|`float`|Adjusts the range of the PID sliders in the UI...does not impact flight performance.|
|`autoPilotMaxRollPid`|`float`|Adjusts the range of the PID sliders in the UI...does not impact flight performance.|
|`autoPilotPitchDerivative`|`float`|Used to reduce overshooting/oscillations, although excessive amounts will introduce oscillation. Highly maneuverable crafts will not tolerate much if any derivative without introducing oscillation.|
|`autoPilotPitchIntegral`|`float`|Attempts to compensate for cases where the proportional is not sufficient to maintain the target. Not typically recommended for roll.|
|`autoPilotPitchPidLabel`|`string`||
|`autoPilotPitchProportional`|`float`|The primary value which dictates how strongly the auto-pilot reacts to errors.  Craft with large control lag will need proportional reduced considerably below the craft's maximum rate to get oscillation to an acceptable level.|
|`autoPilotRollDerivative`|`float`|Used to reduce overshooting/oscillations, although excessive amounts will introduce oscillation. Highly maneuverable crafts will not tolerate much if any derivative without introducing oscillation.|
|`autoPilotRollIntegral`|`float`|Attempts to compensate for cases where the proportional is not sufficient to maintain the target. Not typically recommended for roll.|
|`autoPilotRollPidLabel`|`string`||
|`autoPilotRollProportional`|`float`|The primary value which dictates how strongly the auto-pilot reacts to errors.  Craft with large control lag will need proportional reduced considerably below the craft's maximum rate to get oscillation to an acceptable level.|
|`descriptionLabel`|`string`|Auto-pilot uses a "PID" controller, which has 3 main components Proportional, Integral, and Derivative.  They can be adjusted while in-flight to determine optimal values (View Panel->Auto-Pilot), and can then be adjusted here to save with the craft. The difficult part of pid tuning is controlling oscillation when the craft is nearly on-target.  The values should typically be large enough to produce the desired response rate without introducing oscillation, at a variety of airspeeds.  All may introduce oscillation if they're too high.  General advice to begin tuning - While in flight, start with integral and derivative at zero.  Adjust proportional until desired response rate is achieved, and oscillation is minimized (may not be able to eliminate).  Increase derivative until overshoot/oscillation is minimized.  Add integral until any persistent error scenarios are addressed while keeping oscillation to a minimum. Tip: Display input sliders to monitor oscillation in inputs.|
|`activationGroupNames`|`List`1`||
|`activationGroupStates`|`List`1`||
|`autoRecalculateStages`|`bool`||
|`craftConfigAutoAssign`|`bool`||
|`craftConfigType`|`CrafConfigurationType`|Changes the configuration of a craft. The configuration is used to drive various functions such as pilot orientation, rotation when certain parts are pulled out, and some default settings for parts.|
|`currentStage`|`int`||
|`editActivationGroups`|`bool`|Edit the names of your activation groups to help keep them organized.|
|`pidPitch`|`Vector3`||
|`pidRoll`|`Vector3`||
|`pilotSeatRotation`|`Vector3`||
|`primaryButton`|`bool`|Assigns this as the primary command pod for the craft. The primary command pod will control all parts in the craft, except for those added from a previously made subassembly that included its own command pod. Note: The primary command pod cannot be deleted.|
|`reorientCraftOnConfigChange`|`bool`|If enabled, the craft in the designer will rotate when the configuration type changes (Plane/Rocket).  You would want to disable this if a craft is already oriented correctly but it needs to have its configuration type changed.  This option does not impact operation during flight.|
|`replicateActivationGroups`|`ActivationGroupReplicationMode`|Determines how this command pod will replicate activation groups from the active command pod when this pod isn't active.|
|`replicateControls`|`bool`|Determines whether this command pod will replicate inputs from the active pod when this command pod isn't active.|
|`replicateStageActivations`|`bool`|Determines whether this command pod will replicate stage activations from the active pod when this command pod isn't active.|
|`stageCalculationVersion`|`int`||
|`useDefaultPilotSeatRotation`|`bool`||
|`powerConsumption`|`float`||


