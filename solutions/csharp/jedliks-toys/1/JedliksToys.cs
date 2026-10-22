class RemoteControlCar
{
    private int _metersDriven = 0;
    private int _batteryPercent = 100;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_metersDriven} meters";

    public string BatteryDisplay() {
        if (_batteryPercent > 0)
            return $"Battery at {_batteryPercent}%";
        else
            return "Battery empty";
    } 
    
    public void Drive()
    {
        if (_batteryPercent > 0) { 
            _metersDriven = _metersDriven + 20;
            _batteryPercent = _batteryPercent - 1;
        }
    }
}
