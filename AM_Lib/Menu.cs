using System;
using System.Windows.Forms;

namespace AM_Lib
{
	/// <summary>
	///  ласс дл€ клонировнаи€ меню и контексного меню
	/// </summary>
	public class Menu
	{
		public Menu()
		{
		}

		public static void Clone(System.Windows.Forms.Menu.MenuItemCollection pattern, MenuItem clone)
		{
			while (clone.MenuItems.Count>0)
				clone.MenuItems.RemoveAt(0);
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
		}

		
		
		public static MenuItem Clone(System.Windows.Forms.Menu.MenuItemCollection pattern )
		{
			MenuItem clone = new MenuItem();
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
			return clone;
		}

		
		
		public static void Clone(System.Windows.Forms.Menu.MenuItemCollection pattern, ContextMenu clone)
		{
			while (clone.MenuItems.Count>0)
				clone.MenuItems.RemoveAt(0);
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
		}


		public static ContextMenu CloneToContext(System.Windows.Forms.Menu.MenuItemCollection pattern)
		{
			ContextMenu clone = new ContextMenu ();
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
			return clone;
		}

	}
}
