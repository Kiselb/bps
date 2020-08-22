using System;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymentOrdersImport.
	/// </summary>
	public class PaymentOrdersImport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnNext;
		public System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbFileFormats;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbFileName;
		private int StepNumber = 1;
		private System.Windows.Forms.Button btnFormatDetails;
		private ConfigLoader cl;
		private System.Windows.Forms.Label lbDescr;
		private System.Data.DataSet ds;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaymentOrdersImport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			ds = null;
			this.btnBack.Visible = false;
			cl = new ConfigLoader(App.POFormatSettingsFileName);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymentOrdersImport));
			this.label1 = new System.Windows.Forms.Label();
			this.tbFileName = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnFormatDetails = new System.Windows.Forms.Button();
			this.lbDescr = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbFileFormats = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 310);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Файл заявок:";
			// 
			// tbFileName
			// 
			this.tbFileName.Location = new System.Drawing.Point(100, 308);
			this.tbFileName.Name = "tbFileName";
			this.tbFileName.Size = new System.Drawing.Size(282, 21);
			this.tbFileName.TabIndex = 1;
			this.tbFileName.Text = "";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.button1.Location = new System.Drawing.Point(398, 307);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Обзор";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.groupBox1,
																				 this.label1,
																				 this.tbFileName,
																				 this.button1});
			this.panel1.Location = new System.Drawing.Point(0, -2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(484, 352);
			this.panel1.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnFormatDetails,
																					this.lbDescr,
																					this.label3,
																					this.label2,
																					this.cmbFileFormats});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 292);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Тип импортируемого файла";
			// 
			// btnFormatDetails
			// 
			this.btnFormatDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFormatDetails.Location = new System.Drawing.Point(426, 26);
			this.btnFormatDetails.Name = "btnFormatDetails";
			this.btnFormatDetails.Size = new System.Drawing.Size(26, 23);
			this.btnFormatDetails.TabIndex = 4;
			this.btnFormatDetails.Text = "...";
			this.btnFormatDetails.Click += new System.EventHandler(this.btnFormatDetails_Click);
			// 
			// lbDescr
			// 
			this.lbDescr.Location = new System.Drawing.Point(126, 70);
			this.lbDescr.Name = "lbDescr";
			this.lbDescr.Size = new System.Drawing.Size(326, 106);
			this.lbDescr.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Описание:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Формат файла:";
			// 
			// cmbFileFormats
			// 
			this.cmbFileFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFileFormats.Location = new System.Drawing.Point(122, 26);
			this.cmbFileFormats.Name = "cmbFileFormats";
			this.cmbFileFormats.Size = new System.Drawing.Size(302, 21);
			this.cmbFileFormats.TabIndex = 0;
			this.cmbFileFormats.SelectedIndexChanged += new System.EventHandler(this.cmbFileFormats_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnBack,
																				 this.btnCancel,
																				 this.btnNext});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 354);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(486, 37);
			this.panel2.TabIndex = 5;
			// 
			// btnBack
			// 
			this.btnBack.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnBack.Location = new System.Drawing.Point(220, 6);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(80, 26);
			this.btnBack.TabIndex = 2;
			this.btnBack.Text = "<  Назад";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnCancel.Location = new System.Drawing.Point(397, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNext
			// 
			this.btnNext.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnNext.Location = new System.Drawing.Point(308, 6);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(80, 26);
			this.btnNext.TabIndex = 0;
			this.btnNext.Text = "Далее >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataGrid1});
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(486, 391);
			this.panel3.TabIndex = 6;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(456, 298);
			this.dataGrid1.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(486, 354);
			this.panel4.TabIndex = 7;
			// 
			// PaymentOrdersImport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(486, 391);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.panel4,
																		  this.panel2,
																		  this.panel3});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PaymentOrdersImport";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Импорт выписок";
			this.Load += new System.EventHandler(this.PaymentOrdersImport_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void PaymentOrdersImport_Load(object sender, System.EventArgs e)
		{
			string[] SC = cl.GetSettingsCollection();
			this.cmbFileFormats.Items.Clear();
			this.cmbFileFormats.Items.AddRange(SC);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				this.tbFileName.Text = this.openFileDialog1.FileName;
			}
		}

		private void ShowNeededPanel()
		{
			switch(this.StepNumber) 
			{
				case 1:
					this.panel3.SendToBack();
					this.panel4.SendToBack();
					break;
				case 2:
					this.panel1.SendToBack();
					this.panel4.SendToBack();
					break;
				case 3:
					this.panel1.SendToBack();
					this.panel3.SendToBack();
					break;
				default:
					break;
			}
			return;
		}

		private bool GenerateDataSet()
		{
			this.ds.Tables.Add("ParsedData");
			string[] fields = cl.GetSpecifiedNodeFields(cl.GetSpecifiedNode(this.cmbFileFormats.SelectedItem.ToString()));
			string[] fieldtypes = cl.GetSpecifiedNodeFieldAttributes("type", cl.GetSpecifiedNode(this.cmbFileFormats.SelectedItem.ToString()));
			for(int counter = 0; counter < fields.Length; counter ++)
			{
				this.ds.Tables["ParsedData"].Columns.Add(fields[counter], Type.GetType(fieldtypes[counter]));
			}
			return true;
		}

		private bool ParseImportingFile(string filename, string FileFormatStr)
		{
			string FieldSplitter = cl.GetSpecifiedNodeFieldsSplitter(FileFormatStr);
			FileInfo f = new FileInfo(filename);
			StreamReader sr = f.OpenText();
			string POstring = null;
			while((POstring = sr.ReadLine()) == null)
			{
				ParseString(POstring, FieldSplitter, FileFormatStr);
			}
			return true;
		}

		private struct PaymentOrder
		{
			public string Number;
			//public DateTime Date;
			public float Sum;
            public string RAccountFrom;
			public string CAccountFrom;
			public string BIKFrom;
			public string BankFrom;
			public string OrgFromINN;
			public string OrgFromKPP;
			public string OrgFromName;
			public string OrgToName;
			//public string OrgToKPP;
			//public string OrgToINN;
			//public string BankTo;
			//public string BIKTo;
			//public string CAccountTo;
			//public string RAccountTo;
			//public string Purpose;
			//public PaymentOrder(){}
		} 

		private PaymentOrder ParseString(string ParsingString, string Splitter, string FileFormatStr)
		{
			int lastpos = 0;
			int position = 0;
			int counter = 0;
			string str;
			PaymentOrder result = new PaymentOrder();
			string[] fields = cl.GetSpecifiedNodeFields(cl.GetSpecifiedNode(FileFormatStr));
			while(position < ParsingString.Length)
			{
				position = ParsingString.IndexOf(Splitter, position);
				str = ParsingString.Substring(lastpos, position - lastpos);
				lastpos = position + Splitter.Length;
				str.Trim();
				switch(fields[counter])
				{
					case "Number":
						result.Number = str;
						break;
					case "Date":
//						result.Date = ParseDate(str, FileFormatStr);
						break;
					case "Sum":
						result.Sum = System.Convert.ToSingle(str);
						break;
					case "OrgFrom":
						result.OrgFromName = str;
						break;
					case "RAccountFrom":
						result.RAccountFrom = str;
						break;
					case "CAccountFrom":
						result.CAccountFrom = str;
						break;
					case "BankFrom":
						result.BankFrom = str;
						break;
					case "BIKFrom":
						result.BIKFrom = str;
						break;
					case "OrgFromINN":
						result.OrgFromINN = str;
						break;
					case "OrgFromKPP":
						result.OrgFromKPP = str;
						break;
					case "OrgTo":
						result.OrgToName = str;
						break;
					case "RAccountTo":
						break;
					case "CAccountTo":
						break;
					case "BankTo":
						break;
					case "BIKTo":
						break;
					case "OrgToINN":
						break;
					case "OrgToKPP":
						break;
					default:
						break;
				}
				counter ++;
			}

			return result;
		}

//		private DateTime ParseDate(string DateString, string FileFormatString)
//		{
//		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			switch(this.StepNumber)
			{
				case 1:
					if(this.tbFileName.Text == null)
					{
						AM_Controls.MsgBoxX.Show("Выберите файл импорта выписок");
						return;
					}
					if(this.cmbFileFormats.Text == null)
					{
						AM_Controls.MsgBoxX.Show("Выберите формат файла импорта");
						return;
					}
					this.StepNumber ++;
					ShowNeededPanel();
					ParseImportingFile(this.tbFileName.Text, this.cmbFileFormats.Text);
					this.btnNext.Text = "Далее >";
					break;
				case 2:
					this.StepNumber ++;
					ShowNeededPanel();
					this.btnNext.Text = "Готово";
					break;
				case 3:
					/* готово */
					DialogResult = DialogResult.OK;
					Close();
					break;
				default:
					this.btnNext.Text = "Далее >";
					break;
			}
		}

		private void btnFormatDetails_Click(object sender, System.EventArgs e)
		{
			if(this.cmbFileFormats.SelectedIndex >= 0)
			{
				FileFormatSettings FileFormatSettingsForm = new FileFormatSettings(this.cl.GetSpecifiedNode(this.cmbFileFormats.SelectedItem.ToString()), true);
				FileFormatSettingsForm.ShowDialog();
			}
		}

		private void cmbFileFormats_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lbDescr.Text = cl.GetSpecifiedNodeDescription(this.cmbFileFormats.SelectedItem.ToString());
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			switch(this.StepNumber)
			{
				case 2:
					this.StepNumber --;
					ShowNeededPanel();
					this.btnBack.Visible = false;
					break;
				case 3:
					this.StepNumber --;
					ShowNeededPanel();
					this.btnNext.Text = "Далее >";
					this.btnBack.Visible = true;
					break;
				default:
					this.btnBack.Visible = true;
					break;
			}
		}
	}
}
