class RemoteControlCar
{
    public int speed;
    public int batteryPercentage = 100;
    public int batteryDrain;
    public int distanceDriven;

    public RemoteControlCar(int speed, int batteryDrain) {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() =>
        this.batteryPercentage < this.batteryDrain;

    public int DistanceDriven() =>
        this.distanceDriven;

    public void Drive()
    {
        if (this.batteryPercentage - this.batteryDrain >= 0) {
            this.distanceDriven += this.speed;
            this.batteryPercentage -= this.batteryDrain;    
        }
    }

    public static RemoteControlCar Nitro() =>
        new RemoteControlCar(50, 4);
}

class RaceTrack
{
    public int distance;

    public RaceTrack(int distance) {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car) =>
        (100 / car.batteryDrain) * car.speed >= distance;
}
