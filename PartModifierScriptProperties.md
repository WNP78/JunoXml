# PartModifier Properties
These can all be used when referencing a part modifier by `id` in an InputController.
They are displayed in the format of: `PartModifierType.Property`. In actual use, you could call the modifier anything you like. For instance, you could, on your fuel tank, set up:
```xml
<FuelTank id="MainFuelTank" />
```
then, in an `InputController`, use:
```xml
<InputController input="MainFuelTank.IsEmpty" />
```

|Name|Type|
|--|--|
|`DockingPort.DockingTime`|float|
|`DockingPort.InspectorDockingStatusPercentage`|float|
|`DockingPort.IsDocked`|bool|
|`DockingPort.IsDocking`|bool|
|`DockingPort.IsReadyForDocking`|bool|
|`DockingPort.IsUndocking`|bool|
|`ElectricMotor.MaxPowerConsumption`|float|
|`FuelSource.IsEmpty`|bool|
|`FuelSource.TotalCapacity`|float|
|`FuelSource.TotalFuel`|float|
|`FuelTank.IsEmpty`|bool|
|`RelayFuelSource.IsEmpty`|bool|
|`RelayFuelSource.TotalCapacity`|float|
|`RelayFuelSource.TotalFuel`|float|
|`ResizableWheel.CurrentRpm`|float|
|`ResizableWheel.Enabled`|bool|
|`ResizableWheel.Grounded`|bool|
|`ResizableWheel.MaxRpm`|float|
|`ResizableWheel.SpringReductionCoefficient`|float|
|`ResizableWheel.WheelDisconnected`|bool|
|`ResizableWheel.MaxPowerConsumption`|float|
|`ResizableWheel.TurningRate`|float|
|`TestPilot.Acceleration`|float|
|`TestPilot.InstantaneousEarthGs`|float|
|`TestPilot.SmoothEarthGs`|float|
|`TestPilot.SmoothEarthGsMax`|float|
|`ControlSurface.DeflectionAngle`|float|
|`Wing.DrawCenterOfLiftBalls`|bool|
|`Wing.DrawCenterOfLiftBallsProportionalToMagnitude`|bool|
|`Wing.AngleOfAttack`|float|
|`Wing.DihedralAngle`|float|
|`Wing.IsWingTipAttached`|bool|
|`Wing.MaxFuelCapacity`|float|
|`Wing.WingSweep`|float|
|`Engine.CurrentEfficiency`|float|
|`Engine.CurrentThrust`|float|
|`Engine.MassFlowRate`|float|
|`Engine.MaximumThrust`|float|
|`Engine.RemainingFuel`|float|
|`JetEngine.CurrentThrust`|float|
|`JetEngine.MassFlowRate`|float|
|`JetEngine.MaximumThrust`|float|
|`JetEngine.RemainingFuel`|float|
|`InputController.Active`|bool|
|`InputController.Value`|float|
|`Fuselage.Backwards`|bool|
|`Fuselage.ClampedSlant`|float|
|`Fuselage.MaxFuelCapacity`|float|
|`Fuselage.UpdateAttachPointRotatePosition`|bool|