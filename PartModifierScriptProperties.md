# PartModifier Properties
These can all be used when referencing a part modifier by `id` in an InputController.

## DockingPort
|Name|Type|
|---|---|
|DockingTime|float|
|InspectorDockingStatusPercentage|float|
|IsDocked|bool|
|IsDocking|bool|
|IsReadyForDocking|bool|
|IsUndocking|bool|


## ElectricMotor
|Name|Type|
|---|---|
|MaxPowerConsumption|float|


## FuelSource
|Name|Type|
|---|---|
|IsEmpty|bool|
|TotalCapacity|float|
|TotalFuel|float|


## FuelTank
|Name|Type|
|---|---|
|IsEmpty|bool|


## RelayFuelSource
|Name|Type|
|---|---|
|IsEmpty|bool|
|TotalCapacity|float|
|TotalFuel|float|


## ResizableWheel
|Name|Type|
|---|---|
|CurrentRpm|float|
|Enabled|bool|
|Grounded|bool|
|MaxRpm|float|
|SpringReductionCoefficient|float|
|WheelDisconnected|bool|
|MaxPowerConsumption|float|
|TurningRate|float|


## TestPilot
|Name|Type|
|---|---|
|Acceleration|float|
|InstantaneousEarthGs|float|
|SmoothEarthGs|float|
|SmoothEarthGsMax|float|


## ControlSurface
|Name|Type|
|---|---|
|DeflectionAngle|float|


## Wing
|Name|Type|
|---|---|
|DrawCenterOfLiftBalls|bool|
|DrawCenterOfLiftBallsProportionalToMagnitude|bool|
|AngleOfAttack|float|
|DihedralAngle|float|
|IsWingTipAttached|bool|
|MaxFuelCapacity|float|
|WingSweep|float|


## Engine
|Name|Type|
|---|---|
|CurrentEfficiency|float|
|CurrentThrust|float|
|MassFlowRate|float|
|MaximumThrust|float|
|RemainingFuel|float|


## JetEngine
|Name|Type|
|---|---|
|CurrentThrust|float|
|MassFlowRate|float|
|MaximumThrust|float|
|RemainingFuel|float|


## InputController
|Name|Type|
|---|---|
|Active|bool|
|Value|float|


## Fuselage
|Name|Type|
|---|---|
|Backwards|bool|
|ClampedSlant|float|
|MaxFuelCapacity|float|
|UpdateAttachPointRotatePosition|bool|
