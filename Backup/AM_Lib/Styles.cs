using System;
using System.Drawing;
using System.Windows.Forms;

namespace AM_Lib
{
	/// <summary>
	/// Summary description for Styles.
	/// </summary>
	public class Styles
	{
		public static Color		GridBkColor =Color.LightGray;
		public static Color		GridAltBkColor= Color.Gainsboro;
		public static Color		GridLineColor= Color.LightGray;
		public static Color		SelectionBackColor= Color.Cornsilk;
		public static Color		SelectionForeColor= Color.Black;
		public static Color		HeaderBackColor= SystemColors.Control;
		public static Color		HeaderForeColor= Color.Black;
		public static DataGridLineStyle GridLineStyle= DataGridLineStyle.Solid;

		public Styles()
		{
		}

		public static void SetDataGridTableStyle(DataGridTableStyle dataGridTableStyle1)
		{
			dataGridTableStyle1.AlternatingBackColor= GridBkColor;
			dataGridTableStyle1.BackColor			= GridAltBkColor;
			dataGridTableStyle1.GridLineColor		= GridLineColor;
			dataGridTableStyle1.SelectionBackColor	= SelectionBackColor;
			dataGridTableStyle1.SelectionForeColor	= SelectionForeColor;
			dataGridTableStyle1.HeaderBackColor		= HeaderBackColor;
			dataGridTableStyle1.HeaderForeColor		= HeaderForeColor;
			dataGridTableStyle1.GridLineStyle		= GridLineStyle;
		}

	}
}
