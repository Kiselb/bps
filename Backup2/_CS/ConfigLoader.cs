using System;
using System.Xml;

namespace BPS
{
	/// <summary>
	/// Summary description for ConfigLoader.
	/// </summary>
	public class ConfigLoader
	{
		private string strSettingsFileName;
		private XmlDocument SettingsDocument;
		public ConfigLoader(string filename)
		{
			this.strSettingsFileName = filename;
			SettingsDocument = new XmlDocument();
			SettingsDocument.Load(strSettingsFileName);
		}

		public string[] GetSettingsCollection()
		{
			string[] SetNames;
			XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("settings");
			SetNames = new string[nodeList.Count];
			for(int counter = 0; counter < nodeList.Count; counter ++)
			{
				SetNames[counter] = nodeList[counter].Attributes["name"].Value.ToString();
			}
			return SetNames;
		}

		public XmlNode GetSpecifiedNode(string settings_name)
		{
			XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("settings");
			for(int counter = 0; counter < nodeList.Count; counter ++)
			{
				if(nodeList[counter].Attributes["name"].Value.CompareTo(settings_name) == 0)
				{
					return nodeList[counter];
				}
			}
			return null;
		}

		public string GetSpecifiedNodeDescription(string settings_name)
		{
			XmlNode node = this.GetSpecifiedNode(settings_name);
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.CompareTo("description") == 0)
				{
					return node.ChildNodes[counter].InnerText;
				}
			}
			return null;
		}

		private string[] GetAllInnerText(XmlNodeList nodeList)
		{
			string[] list = new string[nodeList.Count];
			int listLen = 0;
			for(int counter = 0; counter < nodeList.Count; counter ++)
			{
				bool bHasSuchElement = false;
				for(int counter2 = 0; counter2 < listLen; counter2 ++)
				{
					if(list[counter2].CompareTo(nodeList[counter].InnerText) == 0)
					{
						bHasSuchElement = true;
						break;
					}
				}
				if(!bHasSuchElement)
				{
					list[listLen] = nodeList[counter].InnerText;
					listLen ++;
				}
			}
			string[] TrimmedList = new string[listLen];
			for(int counter = 0; counter < listLen; counter ++)
			{
				TrimmedList[counter] = list[counter];
			}
			return TrimmedList;		
		}
		
		public string[] GetAllCodepages()
		{
			XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("codepage");
			return GetAllInnerText(nodeList);
		}

		public string[] GetAllDecimalSplitters()
		{
			XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("decimalsplitter");
			return GetAllInnerText(nodeList);
		}

		public string[] GetSpecifiedNodeFields(XmlNode node)
		{
			int counter = 0;
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
				{
					break;
				}
			}
			node = node.ChildNodes[counter];
			string[] fieldnames = new string[node.ChildNodes.Count];
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				fieldnames[counter] = node.ChildNodes[counter].InnerText.ToString();
			}
			return fieldnames;
		}

		public string[] GetSpecifiedNodeFieldAttributes(string AttributeName, XmlNode node)
		{
			int counter = 0;
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
				{
					break;
				}
			}
			node = node.ChildNodes[counter];
			string[] fieldtypes = new string[node.ChildNodes.Count];
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				fieldtypes[counter] = node.ChildNodes[counter].Attributes[AttributeName].Value.ToString();
			}
			return fieldtypes;
		}

		public string[] GetAllFieldSplitters()
		{
			XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("fields");
			string[] list = new string[nodeList.Count];
			int listLen = 0;
			for(int counter = 0; counter < nodeList.Count; counter ++)
			{
				bool bHasSuchElement = false;
				for(int counter2 = 0; counter2 < listLen; counter2 ++)
				{
					if(list[counter2].CompareTo(nodeList[counter].Attributes["splitter"].Value.ToString()) == 0)
					{
						bHasSuchElement = true;
						break;
					}
				}
				if(!bHasSuchElement)
				{
					list[listLen] = nodeList[counter].Attributes["splitter"].Value.ToString();
					listLen ++;
				}
			}
			string[] TrimmedList = new string[listLen];
			for(int counter = 0; counter < listLen; counter ++)
			{
				TrimmedList[counter] = list[counter];
			}
			return TrimmedList;		
		}

		public string[] GetAllDateSplitters()
		{
			XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("datesplitter");
			return GetAllInnerText(nodeList);
		}

		private string GetDatePartAtPosition(XmlNode DayNode, XmlNode MonthNode, XmlNode YearNode, int NeededPosition)
		{
			if(DayNode.Attributes["position"].Value.ToString().CompareTo(NeededPosition.ToString()) == 0)
			{
				return DayNode.Attributes["form"].Value.ToString().CompareTo("long") == 0 ? "dd" : "d";
			}
			if(MonthNode.Attributes["position"].Value.ToString().CompareTo(NeededPosition.ToString()) == 0)
			{
				switch(MonthNode.Attributes["form"].Value.ToString())
				{
					case "digit1":
						return "M";
					case "digit2":
						return "MM";
					case "letters1":
						return "MMM";
					case "letters2":
						return "MMMM";
					default:
						break;
				}
			}
			if(YearNode.Attributes["position"].Value.ToString().CompareTo(NeededPosition.ToString()) == 0)
			{
				return YearNode.Attributes["form"].Value.ToString().CompareTo("long") == 0 ? "yyyy" : "yy";
			}
			return null;
		}

		public string GetDateFormatString(string settings_name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode DateFormatNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("dateformat") == 0)
				{
					DateFormatNode = node.ChildNodes[counter];
					break;
				}
			}
			/* пор€док следовани€ тэгов в настройках формата даты д.б. всегда одинаковым */
			XmlNode DayNode = DateFormatNode.ChildNodes[1];
			XmlNode MonthNode = DateFormatNode.ChildNodes[2];
			XmlNode YearNode = DateFormatNode.ChildNodes[3];
			string separator = DateFormatNode.ChildNodes[0].InnerText;
			string DateFormat = GetDatePartAtPosition(DayNode, MonthNode, YearNode, 1)
				+ separator + GetDatePartAtPosition(DayNode, MonthNode, YearNode, 2)
				+ separator + GetDatePartAtPosition(DayNode, MonthNode, YearNode, 3);
			return DateFormat;
		}
		
		public string GetSpecifiedNodeCodepage(string settings_name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode CodePageNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("codepage") == 0)
				{
					CodePageNode = node.ChildNodes[counter];
					break;
				}
			}
			return CodePageNode.InnerText;
		}

		public string GetSpecifiedNodeDecimalSplitter(string settings_name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode DecimalSplitterNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("decimalsplitter") == 0)
				{
					DecimalSplitterNode = node.ChildNodes[counter];
					break;
				}
			}
			return DecimalSplitterNode.InnerText;
		}
	
		public string GetSpecifiedNodeFieldsSplitter(string settings_name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode SplitterNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("fields") == 0)
				{
					SplitterNode = node.ChildNodes[counter];
					break;
				}
			}
			return SplitterNode.Attributes["delimiter"].Value.ToString();
		}

		public string GetSpecifiedNodeDateSplitter(string settings_name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode DateSplitterNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("dateformat") == 0)
				{
					DateSplitterNode = node.ChildNodes[counter];
					break;
				}
			}
			return DateSplitterNode.ChildNodes[0].InnerText.ToString();
		}

		public void SaveSettings()
		{
//			XmlNode x = GetSpecifiedNode(settings_name);
//			XmlNode parent = x.ParentNode;
//			x.ParentNode.RemoveChild(x);
//			parent.AppendChild(node);
			try
			{
				SettingsDocument.Save(this.strSettingsFileName);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void AddField(string settings_name, string header, string type, string delimiter, int length, int align, string filler, string name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			int counter = 0;
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
				{
					break;
				}
			}
			node = node.ChildNodes[counter];
			XmlNode x = SettingsDocument.CreateElement("field");
			x.Attributes.Append(SettingsDocument.CreateAttribute("header"));
			x.Attributes.Append(SettingsDocument.CreateAttribute("type"));
			x.Attributes.Append(SettingsDocument.CreateAttribute("delimiter"));
			x.Attributes.Append(SettingsDocument.CreateAttribute("length"));
			x.Attributes.Append(SettingsDocument.CreateAttribute("align"));
			x.Attributes.Append(SettingsDocument.CreateAttribute("filler"));
			x.Attributes["header"].Value = header;
			x.Attributes["type"].Value = type;
			x.Attributes["delimiter"].Value = delimiter;
			x.Attributes["length"].Value = length.ToString();
			x.Attributes["align"].Value = align.ToString();
			x.Attributes["filler"].Value = filler.ToString();
			x.InnerText = name;
			node.AppendChild(x);
		}

		public void EditField(string settings_name, int index, string new_header, string new_type, string new_delimiter, int new_length, int new_align, string new_filler, string new_name)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			int counter = 0;
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
				{
					break;
				}
			}
			node = node.ChildNodes[counter];
			XmlNode x = node.ChildNodes[index];
			x.Attributes["header"].Value = new_header;
			x.Attributes["type"].Value = new_type;
			x.Attributes["delimiter"].Value = new_delimiter;
			x.Attributes["length"].Value = new_length.ToString();
			x.Attributes["align"].Value = new_align.ToString();
			x.Attributes["filler"].Value = new_filler.ToString();
			x.InnerText = new_name;
		}

		public int RemoveField(string settings_name, int index)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			int counter = 0;
			for(counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
				{
					break;
				}
			}
			node = node.ChildNodes[counter];
			node.RemoveChild(node.ChildNodes[index]);
			return index;
		}

		public void MoveFieldUp(string settings_name, string header, string type, string delimiter, int length, int align, string filler, string name, int index)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			int id = RemoveField(settings_name, index);
			if(id >= 0)
			{
				int counter = 0;
				for(counter = 0; counter < node.ChildNodes.Count; counter ++)
				{
					if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
					{
						break;
					}
				}
				node = node.ChildNodes[counter];
				XmlNode x = SettingsDocument.CreateElement("field");
				x.Attributes.Append(SettingsDocument.CreateAttribute("header"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("type"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("delimiter"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("length"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("align"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("filler"));
				x.Attributes["header"].Value = header;
				x.Attributes["type"].Value = type;
				x.Attributes["delimiter"].Value = delimiter;
				x.Attributes["length"].Value = length.ToString();
				x.Attributes["align"].Value = align.ToString();
				x.Attributes["filler"].Value = filler.ToString();
				x.InnerText = name;
				node.InsertBefore(x, node.ChildNodes[id - 1]);
			}
		}

		public void MoveFieldDown(string settings_name, string header, string type, string delimiter, int length, int align, string name, string filler, int index)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			int id = RemoveField(settings_name, index);
			if(id >= 0)
			{
				int counter = 0;
				for(counter = 0; counter < node.ChildNodes.Count; counter ++)
				{
					if(node.ChildNodes[counter].Name.CompareTo("fields") == 0)
					{
						break;
					}
				}
				node = node.ChildNodes[counter];
				XmlNode x = SettingsDocument.CreateElement("field");
				x.Attributes.Append(SettingsDocument.CreateAttribute("header"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("type"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("delimiter"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("length"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("align"));
				x.Attributes.Append(SettingsDocument.CreateAttribute("filler"));
				x.Attributes["header"].Value = header;
				x.Attributes["type"].Value = type;
				x.Attributes["delimiter"].Value = delimiter;
				x.Attributes["length"].Value = length.ToString();
				x.Attributes["align"].Value = align.ToString();
				x.Attributes["filler"].Value = filler.ToString();
				x.InnerText = name;
				node.InsertAfter(x, node.ChildNodes[id]);			
			}
		}

		private XmlNode CreateFormatNode(string settings_name)
		{
			XmlNode temp_node;
			XmlNode inner_node;
			XmlNode node = SettingsDocument.CreateNode(XmlNodeType.Element, "settings", null);
			XmlAttribute attr = SettingsDocument.CreateAttribute("name");
			attr.Value = settings_name;
			node.Attributes.Append(attr);
            node.AppendChild(SettingsDocument.CreateElement("description"));
			node.AppendChild(SettingsDocument.CreateElement("codepage"));
			node.AppendChild(temp_node = SettingsDocument.CreateElement("fields"));
			temp_node.Attributes.Append(SettingsDocument.CreateAttribute("delimiter"));
			node.AppendChild(SettingsDocument.CreateElement("decimalsplitter"));
			node.AppendChild(temp_node = SettingsDocument.CreateElement("dateformat"));
			temp_node.AppendChild(SettingsDocument.CreateElement("datesplitter"));
			temp_node.AppendChild(inner_node = SettingsDocument.CreateElement("day"));
			inner_node.Attributes.Append(SettingsDocument.CreateAttribute("position"));
			inner_node.Attributes.Append(SettingsDocument.CreateAttribute("form"));
			temp_node.AppendChild(inner_node = SettingsDocument.CreateElement("month"));
            inner_node.Attributes.Append(SettingsDocument.CreateAttribute("position"));
			inner_node.Attributes.Append(SettingsDocument.CreateAttribute("form"));
			temp_node.AppendChild(inner_node = SettingsDocument.CreateElement("year"));
			inner_node.Attributes.Append(SettingsDocument.CreateAttribute("position"));
			inner_node.Attributes.Append(SettingsDocument.CreateAttribute("form"));
			temp_node.AppendChild(SettingsDocument.CreateElement("example"));
			return node;
		}

		public void AddNewFormat(string settings_name)
		{
			XmlNodeList list = this.SettingsDocument.GetElementsByTagName("settingscollection");
			XmlNode node = CreateFormatNode(settings_name);
			list[0].AppendChild(node);
		}

		public string GetDateStringFromDate(string settings_name, DateTime date)
		{
			string dateString = string.Empty;
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode DateFormatNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("dateformat") == 0)
				{
					DateFormatNode = node.ChildNodes[counter];
					break;
				}
			}
			/* пор€док следовани€ тэгов в настройках формата даты д.б. всегда одинаковым */
			XmlNode DayNode = DateFormatNode.ChildNodes[1];
			XmlNode MonthNode = DateFormatNode.ChildNodes[2];
			XmlNode YearNode = DateFormatNode.ChildNodes[3];
			string separator = DateFormatNode.ChildNodes[0].InnerText;
			for(int counter = 1; counter <= 3; counter ++)
			{
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("dd") == 0)
				{
					dateString += date.Day.ToString("00") + separator;
					continue;
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("d") == 0)
				{
					if(date.Day < 10)
					{
						dateString += date.Day.ToString("0") + separator;
						continue;
					}
					else
					{
						dateString += date.Day.ToString("00") + separator;
						continue;
					}
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("M") == 0)
				{
					if(date.Month < 10)
					{
						dateString += date.Month.ToString("0") + separator;
						continue;
					}
					else
					{
						dateString += date.Month.ToString("00") + separator;
						continue;
					}
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("MM") == 0)
				{
					dateString += date.Month.ToString("00") + separator;
					continue;
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("MMM") == 0)
				{
					string[] Months = {"€нв", "фев", "мар", "апр", "май", "июн", "июл", "авг", "сен", "окт", "но€", "дек"};
					dateString += Months[date.Month - 1] + separator;
					continue;
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("MMMM") == 0)
				{
					string[] Months = {"€нварь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сент€брь", "окт€брь", "но€брь", "декабрь"};
					dateString += Months[date.Month - 1] + separator;
					continue;
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("yy") == 0)
				{
					dateString += ((date.Year) - (date.Year / 100) * 100).ToString("00");
					continue;
				}
				if(GetDatePartAtPosition(DayNode, MonthNode, YearNode, counter).CompareTo("yyyy") == 0)
				{
					dateString += date.Year.ToString("0000");
					continue;
				}
			}
			return dateString;
		}

		public bool DelFormat(string settings_name)
		{
			try
			{
				XmlNode node = GetSpecifiedNode(settings_name);
				XmlNodeList nodeList = SettingsDocument.GetElementsByTagName("settings");
				node.ParentNode.RemoveChild(node);
				this.SaveSettings();
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}

		public void SetDateFormat(string settings_name, string[] DateParts, string datedelimiter)
		{
			XmlNode node = GetSpecifiedNode(settings_name);
			XmlNode DateFormatNode = null;
			for(int counter = 0; counter < node.ChildNodes.Count; counter ++)
			{
				if(node.ChildNodes[counter].Name.ToString().CompareTo("dateformat") == 0)
				{
					DateFormatNode = node.ChildNodes[counter];
					break;
				}
			}
			DateFormatNode.ChildNodes[0].InnerText = datedelimiter;
			for(int counter = 0; counter < DateParts.Length; counter ++)
			{
				switch(DateParts[counter])
				{
					case "d":
						DateFormatNode.ChildNodes[1].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[1].Attributes["form"].Value = "short";
						break;
					case "dd":
						DateFormatNode.ChildNodes[1].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[1].Attributes["form"].Value = "long";
						break;
					case "M":
						DateFormatNode.ChildNodes[2].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[2].Attributes["form"].Value = "digit1";
						break;
					case "MM":
						DateFormatNode.ChildNodes[2].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[2].Attributes["form"].Value = "digit2";
						break;
					case "MMM":
						DateFormatNode.ChildNodes[2].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[2].Attributes["form"].Value = "letters1";
						break;
					case "MMMM":
						DateFormatNode.ChildNodes[2].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[2].Attributes["form"].Value = "letters2";
						break;
					case "yy":
						DateFormatNode.ChildNodes[3].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[3].Attributes["form"].Value = "short";
						break;
					case "yyyy":
						DateFormatNode.ChildNodes[3].Attributes["position"].Value = (counter + 1).ToString();
						DateFormatNode.ChildNodes[3].Attributes["form"].Value = "long";
						break;
					default:
						break;
				}
			}
		}

	}
}
