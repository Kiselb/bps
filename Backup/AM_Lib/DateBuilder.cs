using System;

namespace AM_Lib
{
	/// <summary>
	///  ласс дл€ манипул€ций с датами
	/// </summary>
	public class DateBuilder
	{
		public DateBuilder()
		{
		}

		public static string MakeDate (DateTime dt, string szTime)
		{
			return "#" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString() + " " + szTime + "#";
		}

		public static DateTime ClearTime(DateTime dt)
		{
			dt = dt.AddHours	( -dt.Hour	);
			dt = dt.AddMinutes	( -dt.Minute);
			dt = dt.AddSeconds	( -dt.Second);
			dt = dt.AddMilliseconds( -dt.Millisecond);
			return dt;
		}
		
		
		public static DateTime DayBefore(DateTime dt, int nDays)
		{
			if (dt.DayOfWeek== DayOfWeek.Monday)
				dt= dt.AddDays(-3);
			else if (dt.DayOfWeek== DayOfWeek.Sunday)
				dt= dt.AddDays(-2);
			else
				dt= dt.AddDays(-1);
			return dt;
		}

	}
}
