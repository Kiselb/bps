using System;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for FileFormatSettingsEdit.
	/// </summary>
	public class FileFormatSettingsEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbFormatName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbCodePages;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ComboBox cmbDateSplitters;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button btnAllRight;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Button btnAllLeft;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components;
		private System.Data.DataView dvFields;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Data.DataTable DBFieldsTable;
		private bool bIsEdit;
		private System.Windows.Forms.TextBox tbFormatDescription;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private string strSettingsName;
		private ConfigLoader cl;
		private System.Data.DataView dvFileFields;
		private XmlNode CurrentFormatNode;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.Button btnFieldDown;
		private System.Windows.Forms.Button btnFieldUp;
		private System.Windows.Forms.ComboBox cmbDecimalDelimiter;
		private System.Windows.Forms.Label label3;
		System.Data.DataTable dt;
		private string CurrentDateSplitter = null;

		public FileFormatSettingsEdit(ConfigLoader config_loader, string setting_name, bool IsEdit)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			CurrentDateSplitter = this.cmbDateSplitters.Text = ".";
			this.bIsEdit = IsEdit;
			this.strSettingsName = setting_name;
			DBFieldsTable = new System.Data.DataTable("DBFields");
			DBFieldsTable.Columns.Add("FieldName", System.Type.GetType("System.String"));
			DBFieldsTable.Columns.Add("Enabled", System.Type.GetType("System.Boolean"));
			DBFieldsTable.Rows.Add(new object[] {"Номер документа", true});
			DBFieldsTable.Rows.Add(new object[] {"Дата документа", true});
			DBFieldsTable.Rows.Add(new object[] {"Сумма", true});
			DBFieldsTable.Rows.Add(new object[] {"Наименование плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"ИНН плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"КПП плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"Расчетный счет плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"БИК банка плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"Наименование банка плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"Корреспондентский счет банка плательщика", true});
			DBFieldsTable.Rows.Add(new object[] {"Наименование получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"ИНН получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"КПП получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"Расчетный счет получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"БИК банка получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"Наименование банка получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"Корреспондентский счет банка получателя", true});
			DBFieldsTable.Rows.Add(new object[] {"Основание", true});
			this.dvFields.Table = DBFieldsTable;
			this.dvFields.RowFilter = "Enabled = 1";
			this.dataGrid1.DataSource = this.dvFields;
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.RowHeaderWidth = 0;
			App.SetDataGridTableStyle(this.dataGrid1.TableStyles[0]);
			/* creating format file fields */
			this.dt = new System.Data.DataTable("FormatFelds");
			dt.Columns.Add("name", System.Type.GetType("System.String"));
			dt.Columns.Add("type", System.Type.GetType("System.String"));
			dt.Columns.Add("header", System.Type.GetType("System.String"));
			dt.Columns.Add("delimiter", System.Type.GetType("System.String"));
			dt.Columns.Add("length", System.Type.GetType("System.Int32"));
			dt.Columns.Add("align", System.Type.GetType("System.String"));
			dt.Columns.Add("aligntext", System.Type.GetType("System.String"), "iif(align=0, 'По центру', iif(align=1, 'По левому краю', 'По правому краю'))");
			dt.Columns.Add("filler", System.Type.GetType("System.String"));
			/* initializing from XML file */
			cl = config_loader;
			CurrentFormatNode = cl.GetSpecifiedNode(this.strSettingsName);
			this.cmbCodePages.Items.AddRange(cl.GetAllCodepages());
			this.cmbDateSplitters.Items.AddRange(cl.GetAllDateSplitters());
			this.cmbDecimalDelimiter.Items.AddRange(cl.GetAllDecimalSplitters());
			if(this.bIsEdit)
			{
				this.tbFormatName.Text = setting_name;
				this.tbFormatDescription.Text = cl.GetSpecifiedNodeDescription(this.strSettingsName);
				this.cmbCodePages.SelectedItem = cl.GetSpecifiedNodeCodepage(this.strSettingsName);
				this.cmbDateSplitters.SelectedItem = cl.GetSpecifiedNodeDateSplitter(this.strSettingsName);
				this.cmbDecimalDelimiter.SelectedItem = cl.GetSpecifiedNodeDecimalSplitter(this.strSettingsName);
				string DateFormat = cl.GetDateFormatString(this.strSettingsName);
				if(DateFormat != null)
				{
					if(!this.listBox2.Items.Contains(DateFormat))
					{
						this.listBox2.Items.Add(DateFormat);
					}
					this.listBox2.SelectedItem = DateFormat;
				}
				dt = FillFormatFieldsTable();
				if(!EditDBFieldsTable(dt))
				{
					AM_Controls.MsgBoxX.Show("Не удалось отредактировать таблицу полей базы данных");
				}
			}
			else
			{
				/* новый формат */
				this.tbFormatName.Text = setting_name;
				this.tbFormatName.SelectAll();
				this.tbFormatName.Focus();
			}
			this.dvFileFields.Table = dt;
			this.dataGrid2.DataSource = dvFileFields;
			this.dvFileFields.AllowDelete =
				this.dvFileFields.AllowEdit =
				this.dvFileFields.AllowNew = false;
			App.SetDataGridTableStyle(this.dataGrid2.TableStyles[0]);
		}

		private bool EditDBFieldsTable(System.Data.DataTable dt)
		{
			for(int counter = 0; counter < dt.Rows.Count; counter ++)
			{
				System.Data.DataRow[] drs = DBFieldsTable.Select("FieldName = '" + dt.Rows[counter][0].ToString() + "'");
				if(drs.Length > 0)
				{
					drs[0]["Enabled"] = false;
				}
			}
			return true;
		}

		private System.Data.DataTable FillFormatFieldsTable()
		{
			string[] fields = this.cl.GetSpecifiedNodeFields(this.CurrentFormatNode);
			string[] fieldheaders = this.cl.GetSpecifiedNodeFieldAttributes("header", this.CurrentFormatNode);
			string[] fielddelimiters = this.cl.GetSpecifiedNodeFieldAttributes("delimiter", this.CurrentFormatNode);
			string[] fieldlengths = this.cl.GetSpecifiedNodeFieldAttributes("length", this.CurrentFormatNode);
			string[] fieldaligns = this.cl.GetSpecifiedNodeFieldAttributes("align", this.CurrentFormatNode);
			string[] fieldtypes = this.cl.GetSpecifiedNodeFieldAttributes("type", this.CurrentFormatNode);
			string[] fieldfillers = this.cl.GetSpecifiedNodeFieldAttributes("filler", this.CurrentFormatNode);
			int length = 0;
			for(int counter = 0; counter < fields.Length; counter ++)
			{
				if(fieldlengths[counter] == "")
				{
					length = 0;
				}
				else
				{
					length = System.Convert.ToInt32(fieldlengths[counter]);
				}
				dt.Rows.Add(new object[] {fields[counter], fieldtypes[counter], fieldheaders[counter], fielddelimiters[counter], length, fieldaligns[counter], null, fieldfillers[counter]});
			}
			return dt;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileFormatSettingsEdit));
			this.tbFormatName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbCodePages = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnFieldDown = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnFieldUp = new System.Windows.Forms.Button();
			this.btnAllLeft = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.btnAllRight = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvFields = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.cmbDateSplitters = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbFormatDescription = new System.Windows.Forms.TextBox();
			this.dvFileFields = new System.Data.DataView();
			this.cmbDecimalDelimiter = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvFields)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvFileFields)).BeginInit();
			this.SuspendLayout();
			// 
			// tbFormatName
			// 
			this.tbFormatName.Location = new System.Drawing.Point(166, 8);
			this.tbFormatName.Name = "tbFormatName";
			this.tbFormatName.Size = new System.Drawing.Size(580, 21);
			this.tbFormatName.TabIndex = 1;
			this.tbFormatName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Наименование:";
			// 
			// cmbCodePages
			// 
			this.cmbCodePages.Location = new System.Drawing.Point(166, 56);
			this.cmbCodePages.Name = "cmbCodePages";
			this.cmbCodePages.Size = new System.Drawing.Size(283, 21);
			this.cmbCodePages.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 58);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(138, 16);
			this.label6.TabIndex = 4;
			this.label6.Text = "Кодировка файла п/п:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnDel,
																					this.btnEdit,
																					this.btnAdd,
																					this.btnFieldDown,
																					this.btnFieldUp,
																					this.btnAllLeft,
																					this.btnLeft,
																					this.btnAllRight,
																					this.btnRight,
																					this.dataGrid2,
																					this.dataGrid1});
			this.groupBox1.Location = new System.Drawing.Point(4, 110);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(548, 262);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Поля";
			// 
			// btnDel
			// 
			this.btnDel.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnDel.Location = new System.Drawing.Point(428, 230);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(82, 26);
			this.btnDel.TabIndex = 8;
			this.btnDel.Text = "Удалить";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnEdit.Location = new System.Drawing.Point(316, 230);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(100, 26);
			this.btnEdit.TabIndex = 7;
			this.btnEdit.Text = "Редактировать";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnAdd.Location = new System.Drawing.Point(222, 230);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(82, 26);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "Добавить";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnFieldDown
			// 
			this.btnFieldDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnFieldDown.Image")));
			this.btnFieldDown.ImageIndex = 0;
			this.btnFieldDown.ImageList = this.imageList1;
			this.btnFieldDown.Location = new System.Drawing.Point(514, 82);
			this.btnFieldDown.Name = "btnFieldDown";
			this.btnFieldDown.Size = new System.Drawing.Size(28, 24);
			this.btnFieldDown.TabIndex = 10;
			this.btnFieldDown.Click += new System.EventHandler(this.btnFieldDown_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnFieldUp
			// 
			this.btnFieldUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnFieldUp.Image")));
			this.btnFieldUp.ImageIndex = 1;
			this.btnFieldUp.ImageList = this.imageList1;
			this.btnFieldUp.Location = new System.Drawing.Point(514, 44);
			this.btnFieldUp.Name = "btnFieldUp";
			this.btnFieldUp.Size = new System.Drawing.Size(28, 24);
			this.btnFieldUp.TabIndex = 9;
			this.btnFieldUp.Click += new System.EventHandler(this.btnFieldUp_Click);
			// 
			// btnAllLeft
			// 
			this.btnAllLeft.Location = new System.Drawing.Point(184, 152);
			this.btnAllLeft.Name = "btnAllLeft";
			this.btnAllLeft.Size = new System.Drawing.Size(30, 23);
			this.btnAllLeft.TabIndex = 4;
			this.btnAllLeft.Text = "<<";
			this.btnAllLeft.Click += new System.EventHandler(this.btnAllLeft_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.Location = new System.Drawing.Point(184, 122);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(30, 23);
			this.btnLeft.TabIndex = 3;
			this.btnLeft.Text = "<";
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnAllRight
			// 
			this.btnAllRight.Location = new System.Drawing.Point(184, 90);
			this.btnAllRight.Name = "btnAllRight";
			this.btnAllRight.Size = new System.Drawing.Size(30, 23);
			this.btnAllRight.TabIndex = 2;
			this.btnAllRight.Text = ">>";
			this.btnAllRight.Click += new System.EventHandler(this.btnAllRight_Click);
			// 
			// btnRight
			// 
			this.btnRight.Location = new System.Drawing.Point(184, 58);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(30, 23);
			this.btnRight.TabIndex = 1;
			this.btnRight.Text = ">";
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// dataGrid2
			// 
			this.dataGrid2.CaptionText = "Поля файла п/п";
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(222, 22);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(288, 202);
			this.dataGrid2.TabIndex = 5;
			this.dataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle2});
			this.dataGrid2.DoubleClick += new System.EventHandler(this.dataGrid2_DoubleClick);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "FormatFelds";
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Наименование";
			this.dataGridTextBoxColumn3.MappingName = "name";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 175;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Заголовок";
			this.dataGridTextBoxColumn4.MappingName = "header";
			this.dataGridTextBoxColumn4.NullText = "-";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Разделитель";
			this.dataGridTextBoxColumn5.MappingName = "delimiter";
			this.dataGridTextBoxColumn5.NullText = "-";
			this.dataGridTextBoxColumn5.Width = 60;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "Длина";
			this.dataGridTextBoxColumn6.MappingName = "length";
			this.dataGridTextBoxColumn6.NullText = "-";
			this.dataGridTextBoxColumn6.Width = 50;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "Выравнивание";
			this.dataGridTextBoxColumn7.MappingName = "aligntext";
			this.dataGridTextBoxColumn7.NullText = "-";
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionText = "Поля БД";
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvFields;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(10, 22);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.Size = new System.Drawing.Size(166, 204);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dvFields
			// 
			this.dvFields.AllowDelete = false;
			this.dvFields.AllowEdit = false;
			this.dvFields.AllowNew = false;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "DBFields";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Наименование";
			this.dataGridTextBoxColumn1.MappingName = "FieldName";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 200;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.listBox2,
																					this.cmbDateSplitters,
																					this.label4});
			this.groupBox3.Location = new System.Drawing.Point(556, 110);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(192, 262);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Формат даты";
			// 
			// listBox2
			// 
			this.listBox2.Items.AddRange(new object[] {
														  "d.M.yy",
														  "d.MM.yy",
														  "d.MMM.yy",
														  "d.MMMM.yy",
														  "d.M.yyyy",
														  "d.MM.yyyy",
														  "d.MMM.yyyy",
														  "d.MMMM.yyyy",
														  "dd.M.yy",
														  "dd.MM.yy",
														  "dd.MMM.yy",
														  "dd.MMMM.yy",
														  "dd.M.yyyy",
														  "dd.MM.yyyy",
														  "dd.MMM.yyyy",
														  "dd.MMMM.yyyy"});
			this.listBox2.Location = new System.Drawing.Point(12, 26);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(170, 199);
			this.listBox2.TabIndex = 0;
			// 
			// cmbDateSplitters
			// 
			this.cmbDateSplitters.Location = new System.Drawing.Point(100, 233);
			this.cmbDateSplitters.Name = "cmbDateSplitters";
			this.cmbDateSplitters.Size = new System.Drawing.Size(84, 21);
			this.cmbDateSplitters.TabIndex = 2;
			this.cmbDateSplitters.SelectedValueChanged += new System.EventHandler(this.cmbDateSplitters_SelectedValueChanged);
			this.cmbDateSplitters.Leave += new System.EventHandler(this.cmbDateSplitters_Leave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 235);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Разделитель:";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnSave.Location = new System.Drawing.Point(574, 378);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnCancel.Location = new System.Drawing.Point(668, 378);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Отменить";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Описание:";
			// 
			// tbFormatDescription
			// 
			this.tbFormatDescription.Location = new System.Drawing.Point(166, 32);
			this.tbFormatDescription.Name = "tbFormatDescription";
			this.tbFormatDescription.Size = new System.Drawing.Size(580, 21);
			this.tbFormatDescription.TabIndex = 3;
			this.tbFormatDescription.Text = "";
			// 
			// cmbDecimalDelimiter
			// 
			this.cmbDecimalDelimiter.Location = new System.Drawing.Point(166, 80);
			this.cmbDecimalDelimiter.Name = "cmbDecimalDelimiter";
			this.cmbDecimalDelimiter.Size = new System.Drawing.Size(284, 21);
			this.cmbDecimalDelimiter.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Разделитель др. части:";
			// 
			// FileFormatSettingsEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(758, 409);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbFormatDescription,
																		  this.label2,
																		  this.btnCancel,
																		  this.btnSave,
																		  this.groupBox3,
																		  this.groupBox1,
																		  this.tbFormatName,
																		  this.label1,
																		  this.cmbCodePages,
																		  this.label6,
																		  this.label3,
																		  this.cmbDecimalDelimiter});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileFormatSettingsEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Формат файла выписок";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvFields)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvFileFields)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private bool validateData()
		{
			/* listBox2 */
			if(listBox2.SelectedItem == null)
			{
				AM_Controls.MsgBoxX.Show("Выберите пожалуйста формат даты", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.listBox2.Focus();
				return false;
			}
			return true;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(!validateData())
				return;
			this.CurrentFormatNode.Attributes["name"].Value = this.tbFormatName.Text;
			this.strSettingsName = this.tbFormatName.Text;
			this.CurrentFormatNode.ChildNodes[0].InnerText = this.tbFormatDescription.Text;
			this.CurrentFormatNode.ChildNodes[1].InnerText = this.cmbCodePages.Text;
			this.CurrentFormatNode.ChildNodes[3].InnerText = this.cmbDecimalDelimiter.Text;
			string[] DateParts = this.listBox2.SelectedItem.ToString().Split(CurrentDateSplitter.ToCharArray());
			if(DateParts.Length == 3)
			{
				cl.SetDateFormat(strSettingsName, DateParts, CurrentDateSplitter);
			}
			else
			{
				AM_Controls.MsgBoxX.Show("Неправильный формат даты", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			try
			{
				cl.SaveSettings();
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			AddNewFormatFieldProps();
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			EditFormatFieldProps();
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			DelFormatFieldProps();
		}

		private void btnRight_Click(object sender, System.EventArgs e)
		{
			if(this.dvFields.Count == 0)
				return;
			BindingManagerBase bm = this.BindingContext[dvFields];
			DataRow dr = ((DataRowView)bm.Current).Row;
			AddFileField(dr);
		}

		private void AddFileField(DataRow dr)
		{
			DataRow row = this.dvFileFields.Table.NewRow();
			row["name"] = dr["FieldName"];
			row["type"] = "DBField";
			row["align"] = 2;
			row["filler"] = " ";
			if(CreateFileFieldRow(row))
			{
				dr["Enabled"] = false;

				cl.AddField(this.strSettingsName, row["header"].ToString(), row["type"].ToString(), row["delimiter"].ToString(), System.Convert.ToInt32(row["length"]), System.Convert.ToInt32(row["align"]), row["filler"].ToString(), row["name"].ToString());
			}
		}

		private bool CreateFileFieldRow(DataRow row)
		{
			FormatFieldPropsEdit FormatFieldPropsEditForm = new FormatFieldPropsEdit(row, true);
			if(FormatFieldPropsEditForm.ShowDialog() == DialogResult.OK)
			{
				for(int counter = 0; counter < row.ItemArray.Length; counter ++)
				{
					if(!row.Table.Columns[counter].ReadOnly)
					{
						row[counter] = FormatFieldPropsEditForm.FieldProperties[counter];
					}
				}
				this.dvFileFields.Table.Rows.Add(row);
				return true;
			}
			return false;
		}

		private void NewFormatFieldProps()
		{
			DataRow row = this.dvFileFields.Table.NewRow();
			row["type"] = "ExtField";
			row["align"] = 2;
			row["filler"] = " ";
			CreateFileFieldRow(row);
		}

		private void EditFormatFieldProps()
		{
			if(this.dvFileFields.Count < 1)
				return;
			BindingManagerBase bm = this.BindingContext[dvFileFields];
			DataRow row = ((DataRowView)bm.Current).Row;
			FormatFieldPropsEdit FormatFieldPropsEditForm = new FormatFieldPropsEdit(row, true);
			if(FormatFieldPropsEditForm.ShowDialog() == DialogResult.OK)
			{
				for(int counter = 0; counter < row.ItemArray.Length; counter ++)
				{
					if(!row.Table.Columns[counter].ReadOnly)
					{
						row[counter] = FormatFieldPropsEditForm.FieldProperties[counter];
					}
				}
				cl.EditField(this.strSettingsName, this.dataGrid2.CurrentRowIndex, FormatFieldPropsEditForm.FieldProperties["header"].ToString(), FormatFieldPropsEditForm.FieldProperties["type"].ToString(), FormatFieldPropsEditForm.FieldProperties["delimiter"].ToString(), System.Convert.ToInt32(FormatFieldPropsEditForm.FieldProperties["length"]), System.Convert.ToInt32(FormatFieldPropsEditForm.FieldProperties["align"]), FormatFieldPropsEditForm.FieldProperties["filler"].ToString(), FormatFieldPropsEditForm.FieldProperties["name"].ToString());
			}
		}

		private void AddNewFormatFieldProps()
		{
			DataRow row = this.dvFileFields.Table.NewRow();
			FormatFieldPropsEdit FormatFieldPropsEditForm = new FormatFieldPropsEdit(row, false);
			if(FormatFieldPropsEditForm.ShowDialog() == DialogResult.OK)
			{
				for(int counter = 0; counter < row.ItemArray.Length; counter ++)
				{
					if(!row.Table.Columns[counter].ReadOnly)
					{
						row[counter] = FormatFieldPropsEditForm.FieldProperties[counter];
					}
				}
				this.dvFileFields.Table.Rows.Add(row);
				cl.AddField(this.strSettingsName, row["header"].ToString(), row["type"].ToString(), row["delimiter"].ToString(), System.Convert.ToInt32(row["length"]), System.Convert.ToInt32(row["align"]), row["filler"].ToString(), row["name"].ToString());
			}
		}

		private void dataGrid2_DoubleClick(object sender, System.EventArgs e)
		{
			EditFormatFieldProps();
		}

		private void DelFormatFieldProps()
		{
			if(dvFileFields.Count < 1)
			{
				return;
			}
			BindingManagerBase bm = this.BindingContext[dvFileFields];
			DataRow row = ((DataRowView)bm.Current).Row;
			RemoveFileField(row);
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			btnRight_Click(null, null);
		}

		private void btnLeft_Click(object sender, System.EventArgs e)
		{
			if(this.dvFileFields.Count == 0)
				return;
			BindingManagerBase bm = this.BindingContext[dvFileFields];
			DataRow dr = ((DataRowView)bm.Current).Row;
			RemoveFileField(dr);
		}

		private bool RemoveFileField(DataRow dr)
		{
			if(dr["type"].ToString().CompareTo("DBField") == 0)
			{
				DataRow[] drs = this.dvFields.Table.Select("FieldName = '" + dr["name"] + "'");
				if(drs.Length > 0)
				{
					drs[0]["Enabled"] = true;
					cl.RemoveField(this.strSettingsName, this.dataGrid2.CurrentRowIndex);
					this.dvFileFields.Table.Rows.Remove(dr);
					return true;
				}
			}
			else
			{
				cl.RemoveField(this.strSettingsName, this.dataGrid2.CurrentRowIndex);
				this.dvFileFields.Table.Rows.Remove(dr);
			}
			return false;
		}

		private void btnAllRight_Click(object sender, System.EventArgs e)
		{
			for(int counter = 0; counter < this.dvFields.Count;)
			{
				AddFileField(this.dvFields[0].Row);
			}
		}

		private void btnAllLeft_Click(object sender, System.EventArgs e)
		{
			int number = 0;
			for(int counter = 0; counter < this.dvFileFields.Count;)
			{
				if(!RemoveFileField(this.dvFileFields[number].Row))
				{
					number ++;
					if(number == this.dvFileFields.Count)
					{
						break;
					}
				}
				else
				{
					number = 0;
				}
			}
		}

		private void btnFieldUp_Click(object sender, System.EventArgs e)
		{
			if(this.dataGrid2.CurrentRowIndex == 0)
				return;
			BindingManagerBase bm = this.BindingContext[dvFileFields];
            DataRow dr = ((DataRowView)bm.Current).Row;
			cl.MoveFieldUp(this.strSettingsName, dr["header"].ToString(), dr["type"].ToString(), dr["delimiter"].ToString(), System.Convert.ToInt32(dr["length"]), System.Convert.ToInt32(dr["align"]), dr["filler"].ToString(), dr["name"].ToString(), this.dataGrid2.CurrentRowIndex);
			DataRow dr2 = this.dvFileFields[this.dataGrid2.CurrentRowIndex - 1].Row;
			string header = dr2["header"].ToString();
			string type = dr2["type"].ToString();
			string delimiter = dr2["delimiter"].ToString();
			string length = dr2["length"].ToString();
			string align = dr2["align"].ToString();
			string filler = dr2["filler"].ToString();
			string name = dr2["name"].ToString();
			dr2["header"] = dr["header"].ToString();
			dr2["type"] = dr["type"].ToString();
			dr2["delimiter"] = dr["delimiter"].ToString();
			dr2["length"] = dr["length"].ToString();
			dr2["align"] = dr["align"].ToString();
			dr2["filler"] = dr["filler"].ToString();
			dr2["name"] = dr["name"].ToString();
			dr["header"] = header;
			dr["type"] = type;
			dr["delimiter"] = delimiter;
			dr["name"] = name;
			dr["length"] = length;
			dr["align"] = align;
			dr["filler"] = filler;
			if(this.dataGrid2.CurrentRowIndex != 0)
			{
				this.dataGrid2.UnSelect(this.dataGrid2.CurrentRowIndex);
				this.dataGrid2.CurrentRowIndex --;
				this.dataGrid2.Select(this.dataGrid2.CurrentRowIndex);
			}
		}

		private void btnFieldDown_Click(object sender, System.EventArgs e)
		{
			if(this.dataGrid2.CurrentRowIndex == this.dvFileFields.Count - 1)
				return;
			BindingManagerBase bm = this.BindingContext[dvFileFields];
			DataRow dr = ((DataRowView)bm.Current).Row;
			cl.MoveFieldDown(this.strSettingsName, dr["header"].ToString(), dr["type"].ToString(), dr["delimiter"].ToString(), System.Convert.ToInt32(dr["length"]), System.Convert.ToInt32(dr["align"]), dr["filler"].ToString(), dr["name"].ToString(), this.dataGrid2.CurrentRowIndex);
			DataRow dr2 = this.dvFileFields[this.dataGrid2.CurrentRowIndex + 1].Row;
			string header = dr2["header"].ToString();
			string type = dr2["type"].ToString();
			string delimiter = dr2["delimiter"].ToString();
			string length = dr2["length"].ToString();
			string align = dr2["align"].ToString();
			string filler = dr2["filler"].ToString();
			string name = dr2["name"].ToString();
			dr2["header"] = dr["header"].ToString();
			dr2["type"] = dr["type"].ToString();
			dr2["delimiter"] = dr["delimiter"].ToString();
			dr2["length"] = dr["length"].ToString();
			dr2["align"] = dr["align"].ToString();
			dr2["filler"] = dr["filler"].ToString();
			dr2["name"] = dr["name"].ToString();
			dr["header"] = header;
			dr["type"] = type;
			dr["delimiter"] = delimiter;
			dr["name"] = name;
			dr["length"] = length;
			dr["align"] = align;
			dr["filler"] = filler;
			if(this.dataGrid2.CurrentRowIndex != this.dvFileFields.Count - 1)
			{
				this.dataGrid2.UnSelect(this.dataGrid2.CurrentRowIndex);
				this.dataGrid2.CurrentRowIndex ++;
				this.dataGrid2.Select(this.dataGrid2.CurrentRowIndex);
			}
		}

		private void cmbDateSplitters_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(CurrentDateSplitter == null)
				return;
			for(int counter = 0; counter < this.listBox2.Items.Count; counter ++)
			{
				this.listBox2.Items[counter] = this.listBox2.Items[counter].ToString().Replace(CurrentDateSplitter, this.cmbDateSplitters.Text);
			}
			CurrentDateSplitter = this.cmbDateSplitters.Text;
		}

		private void cmbDateSplitters_Leave(object sender, System.EventArgs e)
		{
			cmbDateSplitters_SelectedValueChanged(null, null);
		}

	}
}
