using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) =>
	dtUtc.ToLocalTime();

    public static TimeZoneInfo GetTimeZone(Location location)
    {
       	if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
	{
	    string timeZoneId = location switch
	    {
		Location.NewYork => "America/New_York",
		Location.London => "Europe/London",
		Location.Paris => "Europe/Paris",
		_ => throw new ArgumentOutOfRangeException()
	    };
	    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
	}
	else
	{
	    string timeZoneId = location switch
	    {
		Location.NewYork => "Eastern Standard Time",
		Location.London => "GMT Standard Time",
		Location.Paris => "W. Europe Standard Time",
		_ => throw new ArgumentOutOfRangeException()
	    };
	    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);	    
	}	
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
	DateTime appointment = DateTime.Parse(appointmentDateDescription);
	return TimeZoneInfo.ConvertTimeToUtc(appointment, GetTimeZone(location));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
	alertLevel switch
	{
	    AlertLevel.Early => appointment.AddDays(-1),
	    AlertLevel.Standard => appointment.AddHours(-1.75),
	    AlertLevel.Late => appointment.AddMinutes(-30),
	    _ => appointment
	};

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
	TimeZoneInfo salonTimeZone = GetTimeZone(location);
	DateTime startDate = dt.AddDays(-7);
	bool isDSTAtStartDate = salonTimeZone.IsDaylightSavingTime(startDate);
	bool isDSTAtEndDate = salonTimeZone.IsDaylightSavingTime(dt);
	return isDSTAtStartDate != isDSTAtEndDate;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
	string pattern = "";
	CultureInfo provider = CultureInfo.InvariantCulture;
	switch (location)
	{
	    case Location.NewYork:
		pattern = "M/d/yyyy H:mm:ss";
		break;
	    case Location.London:
	    case Location.Paris:
		pattern = "d/M/yyyy H:mm:ss";
		break;
	}

	try
	{
	    return DateTime.ParseExact(dtStr, pattern, provider);
	}
	catch (FormatException)
	{
	    return DateTime.MinValue;
	}
    }
}
