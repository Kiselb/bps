using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Controls;

namespace BPS._Forms.Orgs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class OrgsList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		//private System.Windows.Forms.DataGrid dataGrid1;
		private AM_Controls.DataGridV dataGrid1;
		private System.Data.DataView dataView1;
		private BLL.Orgs.DataSets.dsOrgs dsOrgs1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbInn;
		private System.Windows.Forms.CheckBox cbOut;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn3;
		private System.Windows.Forms.CheckBox cbSpecial;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.CheckBox cbRemoved;
		private System.Windows.Forms.DataGridTextBoxColumn ClientName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbClients;
		private System.Data.DataView dvClients;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuRestore;
		private System.Windows.Forms.MenuItem mnuBlock;
		private System.Windows.Forms.DataGridBoolColumn colIsRemoved;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		
		private BPS.BLL.Orgs.coOrgs bllOrgs;


		public OrgsList()
		{
			bllOrgs = App.bllOrgs;

			InitializeComponent();

			AM_Lib.Styles.SetDataGridTableStyle(this.dataGridTableStyle1);

			this.dataView1.Table = bllOrgs.DataSet.Orgs;

			this.dvClients.Table = App.DsClients.Clients.Copy();
			DataRow dr = this.dvClients.Table.NewRow();
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).ClientGroupID = 0;
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).ClientGroupName = "";
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).ClientID = 0;
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).ClientName = "<Все>";
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).ClientRemarks = "";
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).IsInner = false;
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).IsSpecial = true;
			((BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dr).Password = "";
			this.dvClients.Table.Rows.Add(dr);
			this.dvClients.RowFilter = "IsSpecial=true";
			this.dvClients.Sort = "ClientName";
			this.cmbClients.DataSource = this.dvClients;
			this.cmbClients.DisplayMember = "ClientName";
			this.cmbClients.ValueMember = "ClientID";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OrgsList));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbClients = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbRemoved = new System.Windows.Forms.CheckBox();
			this.cbOut = new System.Windows.Forms.CheckBox();
			this.cbInn = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbSpecial = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuBlock = new System.Windows.Forms.MenuItem();
			this.mnuRestore = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.dataView1 = new System.Data.DataView();
			this.dsOrgs1 = new BPS.BLL.Orgs.DataSets.dsOrgs();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colIsRemoved = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridBoolColumn3 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.dvClients = new System.Data.DataView();
			this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton4,
																						this.toolBarButton3,
																						this.toolBarButton5,
																						this.toolBarButton6,
																						this.toolBarButton7,
																						this.toolBarButton8,
																						this.toolBarButton9});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(738, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 2;
			this.toolBarButton1.Text = "Новый";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 4;
			this.toolBarButton2.Text = "Открыть";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 0;
			this.toolBarButton4.Text = "Удалить";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 3;
			this.toolBarButton5.Text = "Обновить";
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.ImageIndex = 6;
			this.toolBarButton7.Text = "Выбрать";
			// 
			// toolBarButton8
			// 
			this.toolBarButton8.ImageIndex = 5;
			this.toolBarButton8.Text = "Сбросить";
			// 
			// toolBarButton9
			// 
			this.toolBarButton9.ImageIndex = 7;
			this.toolBarButton9.Text = "Очистить";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.toolBar1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(738, 68);
			this.panel1.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbClients);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cbRemoved);
			this.groupBox1.Controls.Add(this.cbOut);
			this.groupBox1.Controls.Add(this.cbInn);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Controls.Add(this.cbSpecial);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(738, 40);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			// 
			// cmbClients
			// 
			this.cmbClients.Location = new System.Drawing.Point(610, 16);
			this.cmbClients.Name = "cmbClients";
			this.cmbClients.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(562, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Клиент:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbRemoved
			// 
			this.cbRemoved.Location = new System.Drawing.Point(474, 18);
			this.cbRemoved.Name = "cbRemoved";
			this.cbRemoved.Size = new System.Drawing.Size(82, 16);
			this.cbRemoved.TabIndex = 9;
			this.cbRemoved.Text = "Удалённые";
			this.cbRemoved.ThreeState = true;
			// 
			// cbOut
			// 
			this.cbOut.Checked = true;
			this.cbOut.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.cbOut.Location = new System.Drawing.Point(308, 18);
			this.cbOut.Name = "cbOut";
			this.cbOut.Size = new System.Drawing.Size(68, 16);
			this.cbOut.TabIndex = 2;
			this.cbOut.Text = "IsNormal";
			this.cbOut.ThreeState = true;
			// 
			// cbInn
			// 
			this.cbInn.Checked = true;
			this.cbInn.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.cbInn.Location = new System.Drawing.Point(254, 18);
			this.cbInn.Name = "cbInn";
			this.cbInn.Size = new System.Drawing.Size(52, 16);
			this.cbInn.TabIndex = 1;
			this.cbInn.Text = "Наши";
			this.cbInn.ThreeState = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 20);
			this.label1.TabIndex = 8;
			this.label1.Text = "Название:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(68, 14);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(182, 21);
			this.tbName.TabIndex = 0;
			this.tbName.Text = "";
			// 
			// cbSpecial
			// 
			this.cbSpecial.Checked = true;
			this.cbSpecial.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.cbSpecial.Location = new System.Drawing.Point(378, 18);
			this.cbSpecial.Name = "cbSpecial";
			this.cbSpecial.Size = new System.Drawing.Size(94, 16);
			this.cbSpecial.TabIndex = 2;
			this.cbSpecial.Text = "Специальные";
			this.cbSpecial.ThreeState = true;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 443);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(738, 2);
			this.panel2.TabIndex = 5;
			// 
			// dataGrid1
			// 
			this.dataGrid1._CanEdit = false;
			this.dataGrid1._InvisibleColumn = 0;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 68);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(738, 375);
			this.dataGrid1.TabIndex = 6;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem2,
																						 this.menuItem3,
																						 this.mnuBlock,
																						 this.mnuRestore,
																						 this.menuItem1,
																						 this.menuItem4,
																						 this.menuItem6,
																						 this.menuItem8,
																						 this.menuItem9});
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem2, ((System.Drawing.Icon)(resources.GetObject("menuItem2.MenuItemImage"))));
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem2.Text = "Новая";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem3, ((System.Drawing.Icon)(resources.GetObject("menuItem3.MenuItemImage"))));
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.menuItem3.Text = "Изменить";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// mnuBlock
			// 
			this.mnuBlock.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuBlock, null);
			this.mnuBlock.OwnerDraw = true;
			this.mnuBlock.Text = "Исключить";
			this.mnuBlock.Click += new System.EventHandler(this.mnuBlock_Click);
			// 
			// mnuRestore
			// 
			this.mnuRestore.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuRestore, null);
			this.mnuRestore.OwnerDraw = true;
			this.mnuRestore.Text = "Восстановить";
			this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem1, null);
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem4, ((System.Drawing.Icon)(resources.GetObject("menuItem4.MenuItemImage"))));
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.menuItem4.Text = "Удалить";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem6, null);
			this.menuItem6.OwnerDraw = true;
			this.menuItem6.Text = "-";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem8, ((System.Drawing.Icon)(resources.GetObject("menuItem8.MenuItemImage"))));
			this.menuItem8.OwnerDraw = true;
			this.menuItem8.Text = "Выбрать по фильтру";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem9, ((System.Drawing.Icon)(resources.GetObject("menuItem9.MenuItemImage"))));
			this.menuItem9.OwnerDraw = true;
			this.menuItem9.Text = "Сбросить фильтр";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// dataView1
			// 
			this.dataView1.Sort = "IsInner desc,OrgName";
			this.dataView1.Table = this.dsOrgs1.Orgs;
			// 
			// dsOrgs1
			// 
			this.dsOrgs1.DataSetName = "dsOrgs";
			this.dsOrgs1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.colIsRemoved,
																												  this.dataGridBoolColumn1,
																												  this.dataGridBoolColumn2,
																												  this.dataGridBoolColumn3,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn4,
																												  this.ClientName,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Orgs";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.MappingName = "OrgID";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// colIsRemoved
			// 
			this.colIsRemoved.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.colIsRemoved.FalseValue = false;
			this.colIsRemoved.HeaderText = "У";
			this.colIsRemoved.MappingName = "IsRemoved";
			this.colIsRemoved.NullValue = ((object)(resources.GetObject("colIsRemoved.NullValue")));
			this.colIsRemoved.ReadOnly = true;
			this.colIsRemoved.TrueValue = true;
			this.colIsRemoved.Width = 20;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.FalseValue = false;
			this.dataGridBoolColumn1.HeaderText = "Н";
			this.dataGridBoolColumn1.MappingName = "IsInner";
			this.dataGridBoolColumn1.NullText = "";
			this.dataGridBoolColumn1.NullValue = ((object)(resources.GetObject("dataGridBoolColumn1.NullValue")));
			this.dataGridBoolColumn1.TrueValue = true;
			this.dataGridBoolColumn1.Width = 20;
			// 
			// dataGridBoolColumn2
			// 
			this.dataGridBoolColumn2.FalseValue = false;
			this.dataGridBoolColumn2.HeaderText = "B";
			this.dataGridBoolColumn2.MappingName = "IsNormal";
			this.dataGridBoolColumn2.NullText = "";
			this.dataGridBoolColumn2.NullValue = ((object)(resources.GetObject("dataGridBoolColumn2.NullValue")));
			this.dataGridBoolColumn2.TrueValue = true;
			this.dataGridBoolColumn2.Width = 20;
			// 
			// dataGridBoolColumn3
			// 
			this.dataGridBoolColumn3.FalseValue = false;
			this.dataGridBoolColumn3.HeaderText = "S";
			this.dataGridBoolColumn3.MappingName = "IsSpecial";
			this.dataGridBoolColumn3.NullText = "";
			this.dataGridBoolColumn3.NullValue = ((object)(resources.GetObject("dataGridBoolColumn3.NullValue")));
			this.dataGridBoolColumn3.TrueValue = true;
			this.dataGridBoolColumn3.Width = 20;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Название";
			this.dataGridTextBoxColumn2.MappingName = "OrgName";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn3.Format = "0.00%";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "%%";
			this.dataGridTextBoxColumn3.MappingName = "DefaultServiceCharge";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 50;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "Телефон1";
			this.dataGridTextBoxColumn8.MappingName = "Phone1";
			this.dataGridTextBoxColumn8.NullText = "-";
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "Контактное лицо";
			this.dataGridTextBoxColumn12.MappingName = "ContactPerson";
			this.dataGridTextBoxColumn12.NullText = "-";
			this.dataGridTextBoxColumn12.Width = 80;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "ИНН";
			this.dataGridTextBoxColumn4.MappingName = "CodeINN";
			this.dataGridTextBoxColumn4.NullText = "-";
			this.dataGridTextBoxColumn4.Width = 85;
			// 
			// ClientName
			// 
			this.ClientName.Format = "";
			this.ClientName.FormatInfo = null;
			this.ClientName.HeaderText = "Клиент";
			this.ClientName.MappingName = "ClientName";
			this.ClientName.NullText = "-";
			this.ClientName.Width = 75;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "КПП";
			this.dataGridTextBoxColumn5.MappingName = "CodeKPP";
			this.dataGridTextBoxColumn5.NullText = "-";
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "Юридический адрес";
			this.dataGridTextBoxColumn6.MappingName = "AddrReg";
			this.dataGridTextBoxColumn6.NullText = "-";
			this.dataGridTextBoxColumn6.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "Фактический адрес";
			this.dataGridTextBoxColumn7.MappingName = "AddrFact";
			this.dataGridTextBoxColumn7.NullText = "-";
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "Телефон2";
			this.dataGridTextBoxColumn9.MappingName = "Phone2";
			this.dataGridTextBoxColumn9.NullText = "-";
			this.dataGridTextBoxColumn9.Width = 75;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "Факс1";
			this.dataGridTextBoxColumn10.MappingName = "Fax1";
			this.dataGridTextBoxColumn10.NullText = "-";
			this.dataGridTextBoxColumn10.Width = 75;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Факс2";
			this.dataGridTextBoxColumn11.MappingName = "Fax2";
			this.dataGridTextBoxColumn11.NullText = "-";
			this.dataGridTextBoxColumn11.Width = 75;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "ОКПО";
			this.dataGridTextBoxColumn13.MappingName = "OKPO";
			this.dataGridTextBoxColumn13.NullText = "-";
			this.dataGridTextBoxColumn13.Width = 75;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "ОКОНХ";
			this.dataGridTextBoxColumn14.MappingName = "OKONH";
			this.dataGridTextBoxColumn14.NullText = "-";
			this.dataGridTextBoxColumn14.Width = 75;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuEdit});
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuEdit, null);
			this.mnuEdit.OwnerDraw = true;
			this.mnuEdit.Text = "Редактировать";
			// 
			// MenuItemImageProvider1
			// 
			this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
			// 
			// OrgsList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(738, 445);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "OrgsList";
			this.Text = "Организации";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.OrgsList_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (this.toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					addOrg();
					break;
				case 1:
					editOrg();
					break;
				case 2:
					deleteOrg();
					break;
				case 4:
					bllOrgs.Fill();
					break;
				case 6:
					this.applyFilter();
					break;
				case 7:
					this.dataView1.RowFilter = "";
					break;
				case 8:
					this.resetFilter();
					break;
			}
		}

		private void addOrg()
		{
			if(!App.AllowOrgDirChange)
				return;
			int nOrgID = EditOrgs.AddOrgDialog(App.bllOrgs,"","");
			if ( nOrgID >0  ) 
			{
//				int ix = this.dataView1.Find(nOrgID);
				for (int i=0; i<this.dataView1.Count; i++) 
				{
					if ( Convert.ToInt32(this.dataView1[i]["OrgID"]) == nOrgID ) 
					{
						this.BindingContext[this.dataView1].Position = i;
						break;
					}
				}


			}
		}


		private void editOrg()
		{
			if(!App.AllowOrgDirChange)
				return;
			if(this.dataView1.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
				BLL.Orgs.DataSets.dsOrgs.OrgsRow rw = (BLL.Orgs.DataSets.dsOrgs.OrgsRow)((DataRowView)bm.Current).Row;
				EditOrgs eo = new EditOrgs(rw);
				eo.ShowDialog();
				if(eo.DialogResult == DialogResult.OK)
				{
					if ( !bllOrgs.Update() )
						bllOrgs.DataSet.RejectChanges();
				}
			}
		}

		private void deleteOrg()
		{
			if(!App.AllowOrgDirChange)
				return;
			if(this.dataView1.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
				BLL.Orgs.DataSets.dsOrgs.OrgsRow rw = (BLL.Orgs.DataSets.dsOrgs.OrgsRow)((DataRowView)bm.Current).Row;
				if(MsgBoxX.Show("Вы действительно хотите удалить организацию " + rw.OrgName + "?","BPS",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					((DataRowView)bm.Current).Delete();
					if ( !bllOrgs.Update() )
						bllOrgs.DataSet.RejectChanges();

				}
			}
		}

		private void mnuBlock_Click(object sender, System.EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
			BLL.Orgs.DataSets.dsOrgs.OrgsRow rw = (BLL.Orgs.DataSets.dsOrgs.OrgsRow)((DataRowView)bm.Current).Row;
			if(rw.IsInner && !this.checkBalans(rw.OrgID))
			{
				AM_Controls.MsgBoxX.Show("Невозможно исключить организацию \'" + rw.OrgName + "\'.\n Остаток на р.счетах не равен нулю.","BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
			rw.IsRemoved = true;
			if ( !bllOrgs.Update() )
				bllOrgs.DataSet.RejectChanges();
		}

		private void mnuRestore_Click(object sender, System.EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
			BLL.Orgs.DataSets.dsOrgs.OrgsRow rw = (BLL.Orgs.DataSets.dsOrgs.OrgsRow)((DataRowView)bm.Current).Row;
			rw.IsRemoved = false;		
			bllOrgs.Update();
		}

		private bool checkBalans(int iOrgID)
		{

			object o = AM_Lib.sqlData.ExecuteScalar(
							"SELECT SUM(Accounts.Saldo)	FROM OrgsAccounts INNER JOIN Accounts ON OrgsAccounts.AccountID = Accounts.AccountID WHERE OrgsAccounts.OrgID ="+ iOrgID.ToString()
							);
			if(o == Convert.DBNull)
				return true;
			else if(Math.Abs(Convert.ToDouble(o)) < 0.005)
				return true;
			return false;
/*
	SqlCommand cmdGetBalance = new SqlCommand("[BalanceOrg]", App.Connection);
			cmdGetBalance.CommandType = CommandType.StoredProcedure;
			cmdGetBalance.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Float));
			cmdGetBalance.Parameters["@Balance"].Direction = ParameterDirection.Output;
			cmdGetBalance.Parameters.Add(new SqlParameter("@OrgID", SqlDbType.Float));
			cmdGetBalance.Parameters["@OrgID"].Value = iOrgID;
			App.Connection.Open();
			try
			{
				cmdGetBalance.ExecuteNonQuery();
				object o = cmdGetBalance.Parameters["@Balance"].Value;
				if(o == Convert.DBNull)
					return true;
				else if(Math.Abs(Convert.ToDouble(o)) < 0.005)
					return true;

			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
			finally
			{
				App.Connection.Close();
			}
			return false;
*/
		}

		private void applyFilter()
		{
			string szFilter = "";
			if(this.tbName.Text.Length>0)
			{
				szFilter = "OrgName LIKE'" + this.tbName.Text + "*'"; 
			}
			if(this.cbInn.CheckState != CheckState.Indeterminate)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				if(this.cbInn.Checked)
					szFilter += "IsInner=true";
				else
					szFilter += "IsInner=false";
			}
			if(this.cbOut.CheckState != CheckState.Indeterminate)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				if(this.cbOut.Checked)
					szFilter += "IsNormal=true";
				else
					szFilter += "IsNormal=false";
			}
			if(this.cbSpecial.CheckState != CheckState.Indeterminate)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				if(this.cbSpecial.Checked)
					szFilter += "IsSpecial=true";
				else
					szFilter += "IsSpecial=false";
			}
			if(this.cbRemoved.CheckState != CheckState.Indeterminate)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				if(this.cbRemoved.Checked)
					szFilter += "IsRemoved=true";
				else
					szFilter += "IsRemoved=false";
			}
			if(this.cmbClients.SelectedIndex >0)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				szFilter += "ClientID=" + this.cmbClients.SelectedValue.ToString();
			}
			this.dataView1.RowFilter = szFilter;
		}
		private void resetFilter()
		{
			this.dataView1.RowFilter = "";
			this.cbInn.CheckState = CheckState.Indeterminate;
			this.cbOut.CheckState = CheckState.Indeterminate;
			this.cbSpecial.CheckState = CheckState.Indeterminate;
			this.cbRemoved.CheckState = CheckState.Unchecked;
			this.cmbClients.SelectedIndex = 0;
			this.tbName.Text = "";
		}
		private void bnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.editOrg();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.addOrg();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.editOrg();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.deleteOrg();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			bllOrgs.Fill();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.applyFilter();
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.dataView1.RowFilter = "";
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.resetFilter();
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public void Clone(System.Windows.Forms.Menu.MenuItemCollection pattern, ContextMenu clone)
		{
			while (clone.MenuItems.Count>0)
				clone.MenuItems.RemoveAt(0);
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
		}

		private void OrgsList_Load(object sender, System.EventArgs e)
		{
			this.setPermissions();
//			this.Clone(this.mnuEdit.MenuItems, this.contextMenu1);
			AM_Lib.Menu.Clone(this.contextMenu1.MenuItems, this.mnuEdit);
		}
		private void setPermissions()
		{
			this.menuItem2.Enabled = this.menuItem3.Enabled = this.menuItem4.Enabled = 
				this.toolBarButton1.Enabled = this.toolBarButton2.Enabled = this.toolBarButton4.Enabled = App.AllowOrgDirChange;
		}
		private void setLastIns(int iID)
		{
			int iNewPosition = this.dataView1.Count-1;
			for(int j=0 ; j<this.dataView1.Count;j++)
			{
				if(Convert.ToInt32(this.dataView1[j].Row["OrgID"]) == iID)
				{
					iNewPosition = j;
					break;
				}
			}
			this.BindingContext[this.dataView1].Position = iNewPosition;
		}

	}
}
