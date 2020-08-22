using System;

namespace AM_Lib
{
	/// <summary>
	///  ласс дл€ построени€ строки фильтра FilterBuilder.
	/// </summary>
	public class FilterBuilder
	{
		protected string sFilter;
		
		public string Text { get {return sFilter;} }

		public FilterBuilder()
		{
			sFilter="";
		}

		public FilterBuilder(string s)
		{
			sFilter=s;
		}

		private void AppendAnd()
		{
			if (sFilter.Length>0)
				sFilter += " AND ";
		}

		public string Append(string s)
		{
			AppendAnd();
			sFilter += s;
			return sFilter;
		}

		public string Append(string s, object o)
		{
			AppendAnd();
			sFilter += s + o.ToString();
			return sFilter;
		}

		public string Append(string s, string sValue)
		{
			AppendAnd();
			sFilter += s + "\'" +sValue + "\'";
			return sFilter;
		}


		public string Append(string s, bool b)
		{
			AppendAnd();
			sFilter += s + (b?"true":"false");
			return sFilter;
		}

		/// <summary>
		/// »спользу€ ToShortDateString
		/// </summary>
		/// <param name="s"></param>
		/// <param name="dtValue"></param>
		/// <returns></returns>
		public string Append(string s, DateTime dt)
		{
			AppendAnd();
//			sFilter += s + "\'" +dtValue.ToShortDateString() + "\'";
			sFilter += s + "#" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString() + "#";
			return sFilter;
		}


	}
}
