using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override bool Equals(object obj)
    {
        Coord otherCoord = (Coord)obj;

        return X == otherCoord.X && Y == otherCoord.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}

public struct Plot
{
    
    public Coord CoordA { get; }
    public Coord CoordB { get; }
    public Coord CoordC { get; }
    public Coord CoordD { get; }
        
    public Plot(Coord coordA, Coord coordB, Coord coordC, Coord coordD)
    {
        CoordA = coordA;
        CoordB = coordB;
        CoordC = coordC;
        CoordD = coordD;
    }

    public int GetLongestSide()
    {
        int first = CoordA.X - CoordB.X;
        int second = CoordA.Y - CoordC.Y;
        int third = CoordD.X - CoordC.X;
        int fourth = CoordD.Y - CoordB.Y;
        int[] lengths = {first, second, third, fourth};
        return lengths.Max();
    }

    public override bool Equals(object obj)
    {
        Plot otherPlot = (Plot)obj;
        
        return
            CoordA.Equals(otherPlot.CoordA) &&
            CoordB.Equals(otherPlot.CoordB) &&
            CoordC.Equals(otherPlot.CoordC) &&
            CoordD.Equals(otherPlot.CoordD);
    }

    public override int GetHashCode() => HashCode.Combine(CoordA, CoordB, CoordC, CoordD);
}


public class ClaimsHandler
{
    public HashSet<Plot> claimedStakes = [];
    public Plot lastClaimed;
    public Plot hasLongestSide = new Plot();
    
    public void StakeClaim(Plot plot) 
    {
        claimedStakes.Add(plot);
        lastClaimed = plot;
    }

    public bool IsClaimStaked(Plot plot) =>
        claimedStakes.Contains(plot);

    public bool IsLastClaim(Plot plot) =>
        plot.Equals(lastClaimed);

    public Plot GetClaimWithLongestSide()
    {
        foreach (Plot plot in claimedStakes)
        {
            if (plot.GetLongestSide() > hasLongestSide.GetLongestSide())
                hasLongestSide = plot;
        }
        return hasLongestSide;
    }
}
