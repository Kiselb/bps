using System;

namespace AM_Lib
{
	/// <summary>
	/// Summary description for TrimSpec.
	/// </summary>
	public class TrimSpec
	{
		public TrimSpec()
		{
		}

		public static string Trim(string s)
		{
			char[] NotValid =  new char[]{'"',' ','<','>','\'','.',',','[',']','{','}','(',')',':',';','?','/','!','@','#','$','%','^','&','*'};
			return s.Trim(NotValid).TrimStart(NotValid);
		}


	}
}
