public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            long denomination = checked(@base * multiplier);
            return denomination.ToString();
        }
        catch (OverflowException err)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float gdp = @base * multiplier;
        if (float.IsInfinity(gdp))
            return "*** Too Big ***";
        return gdp.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            decimal salary = checked(salaryBase * multiplier);
            return salary.ToString();
        }
        catch (OverflowException err)
        {
            return "*** Much Too Big ***";
        }
    }
}
