using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar otherCar)
    {
        if (this.NumberOfVictories > otherCar.NumberOfVictories)
            return 1;
        if (this.NumberOfVictories < otherCar.NumberOfVictories)
            return -1;
        else
            return 0;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var ranking = new List<ProductionRemoteControlCar>();
        if (prc1.CompareTo(prc2) >= 0)
            ranking.AddRange([prc2, prc1]);
        else
            ranking.AddRange([prc1, prc2]);
        return ranking;
    }
}
