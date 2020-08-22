using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for FileFormatSettings.
	/// </summary>
	public class FileFormatSettings : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private XmlNode FormatNode;
		private ConfigLoader cl;
		private System.Windows.Forms.ComboBox cmbSplitters;
		private System.Windows.Forms.ComboBox cmbCodePages;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbDateSplitters;
		private System.Windows.Forms.ComboBox cmbFieldSplitters;
		private System.Windows.Forms.TextBox tbFormatName;
		private bool ViewMode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FileFormatSettings(XmlNode node, bool isViewing)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			FormatNode = node;
			this.ViewMode = isViewing;
			cl = new ConfigLoader(App.POFormatSettingsFileName);

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileFormatSettings));
			this.cmbSplitters = new System.Windows.Forms.ComboBox();
			this.cmbCodePages = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.cmbDateSplitters = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbFieldSplitters = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbFormatName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbSplitters
			// 
			this.cmbSplitters.Location = new System.Drawing.Point(167, 48);
			this.cmbSplitters.Name = "cmbSplitters";
			this.cmbSplitters.TabIndex = 15;
			// 
			// cmbCodePages
			// 
			this.cmbCodePages.Location = new System.Drawing.Point(167, 26);
			this.cmbCodePages.Name = "cmbCodePages";
			this.cmbCodePages.Size = new System.Drawing.Size(283, 21);
			this.cmbCodePages.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(5, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(138, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Кодировка:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(156, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Разделитель дробной части:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.listBox2,
																					this.cmbDateSplitters,
																					this.label4});
			this.groupBox3.Location = new System.Drawing.Point(259, 82);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(192, 172);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Формат даты";
			// 
			// listBox2
			// 
			this.listBox2.Items.AddRange(new object[] {
														  "dd.MM.yyyy",
														  "dd.MM.yy",
														  "d.M.yy",
														  "dd/MM/yy",
														  "yyyy-MM-dd"});
			this.listBox2.Location = new System.Drawing.Point(12, 26);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(170, 108);
			this.listBox2.TabIndex = 0;
			// 
			// cmbDateSplitters
			// 
			this.cmbDateSplitters.Location = new System.Drawing.Point(100, 142);
			this.cmbDateSplitters.Name = "cmbDateSplitters";
			this.cmbDateSplitters.Size = new System.Drawing.Size(84, 21);
			this.cmbDateSplitters.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Разделитель:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.listBox1,
																					this.label3,
																					this.cmbFieldSplitters});
			this.groupBox2.Location = new System.Drawing.Point(5, 82);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 172);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Импортируемые поля";
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(10, 26);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(220, 108);
			this.listBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Разделитель:";
			// 
			// cmbFieldSplitters
			// 
			this.cmbFieldSplitters.Location = new System.Drawing.Point(98, 142);
			this.cmbFieldSplitters.Name = "cmbFieldSplitters";
			this.cmbFieldSplitters.Size = new System.Drawing.Size(134, 21);
			this.cmbFieldSplitters.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 14);
			this.label1.TabIndex = 16;
			this.label1.Text = "Наименование:";
			// 
			// tbFormatName
			// 
			this.tbFormatName.Location = new System.Drawing.Point(166, 5);
			this.tbFormatName.Name = "tbFormatName";
			this.tbFormatName.ReadOnly = true;
			this.tbFormatName.Size = new System.Drawing.Size(283, 21);
			this.tbFormatName.TabIndex = 17;
			this.tbFormatName.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnSave.Location = new System.Drawing.Point(282, 264);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 18;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnCancel.Location = new System.Drawing.Point(370, 264);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Отменить";
			// 
			// FileFormatSettings
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(458, 295);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnSave,
																		  this.tbFormatName,
																		  this.label1,
																		  this.cmbSplitters,
																		  this.cmbCodePages,
																		  this.label6,
																		  this.label5,
																		  this.groupBox3,
																		  this.groupBox2});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FileFormatSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Формат файла выписок";
			this.Load += new System.EventHandler(this.FileFormatSettings_Load);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FileFormatSettings_Load(object sender, System.EventArgs e)
		{
			this.cmbCodePages.Items.Clear();
			this.cmbSplitters.Items.Clear();
			this.cmbFieldSplitters.Items.Clear();
			this.cmbDateSplitters.Items.Clear();
			this.cmbCodePages.Items.AddRange(cl.GetAllCodepages());
			this.cmbSplitters.Items.AddRange(cl.GetAllDecimalSplitters());
			this.cmbFieldSplitters.Items.AddRange(cl.GetAllFieldSplitters());
			this.cmbDateSplitters.Items.AddRange(cl.GetAllDateSplitters());
			this.listBox1.Items.Clear();
			this.listBox1.Items.AddRange(this.cl.GetSpecifiedNodeFields(FormatNode));
			string DateFormat = cl.GetDateFormatString(FormatNode.Attributes["name"].Value.ToString());
			if(DateFormat != null)
			{
				if(!this.listBox2.Items.Contains(DateFormat))
				{
					this.listBox2.Items.Add(DateFormat);
				}
				this.listBox2.SelectedItem = DateFormat;
			}
			this.tbFormatName.Text = FormatNode.Attributes["name"].Value.ToString();
			this.cmbCodePages.SelectedItem = cl.GetSpecifiedNodeCodepage(FormatNode.Attributes["name"].Value.ToString());
			this.cmbSplitters.SelectedItem = cl.GetSpecifiedNodeDecimalSplitter(FormatNode.Attributes["name"].Value.ToString());
			this.cmbFieldSplitters.SelectedItem = cl.GetSpecifiedNodeFieldsSplitter(FormatNode.Attributes["name"].Value.ToString());
			this.cmbDateSplitters.SelectedItem = cl.GetSpecifiedNodeDateSplitter(FormatNode.Attributes["name"].Value.ToString());
			if(ViewMode)
			{
				this.cmbCodePages.Enabled = 
					this.cmbDateSplitters.Enabled = 
					this.cmbFieldSplitters.Enabled =
					this.cmbSplitters.Enabled =
					this.listBox1.Enabled =
					this.listBox2.Enabled = false;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
