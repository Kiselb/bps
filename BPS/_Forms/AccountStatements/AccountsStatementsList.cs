using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for AccountsStatementsList.
	/// </summary>
	public class AccountsStatementsList : System.Windows.Forms.Form
	{
		private BPS.BLL.Orgs.UsersOrgsAndAccounts bll = new BPS.BLL.Orgs.UsersOrgsAndAccounts();

		private AM_Controls.DataGridV dataGridV1;
		private AM_Controls.DataGridV dataGridV2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Data.SqlClient.SqlDataAdapter daGetHeadersList;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		
		private System.Data.DataView dvAccountsStatementsHeaders;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn HeaderID;
		private System.Windows.Forms.DataGridTextBoxColumn HeaderDate;
		private System.Windows.Forms.DataGridTextBoxColumn OrgName;
		private System.Windows.Forms.DataGridTextBoxColumn RAccount;
		private System.Windows.Forms.DataGridTextBoxColumn SaldoStart;
		private System.Windows.Forms.DataGridTextBoxColumn SaldoEnd;
		private System.Windows.Forms.DataGridBoolColumn Confirmed;
		private System.Data.DataView dvAccountsStatementsPayments;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn OrgNameCorr;
		private System.Windows.Forms.DataGridTextBoxColumn RAccountCorr;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderDate;
		private AM_Controls.ucPeriodSimple ucPeriod1;
		private System.Data.SqlClient.SqlDataAdapter daGetPaymsList;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentNo;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn Remarks;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Data.DataView dvOrgs;
		private System.Data.DataView dvRAccount;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter daUpdHeader;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Windows.Forms.DataGridTextBoxColumn IN;
		//private BPS.BLL.AccountStatements.dsAccountsStatementsList dsAccountsStatementsList1;
        private BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList dsAccountsStatementsList1;
        private System.Windows.Forms.DataGridTextBoxColumn OUT;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem mnuiEdit;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		//BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsHeadersRow m_HeaderRow;
        BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow m_HeaderRow;
        private System.Windows.Forms.DataGridTextBoxColumn ColumnRemarks;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts dsUsersOrgsAndAccounts1;
		private BPS._Controls.OrgsAndAccounts ucOrgsAndAccounts;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDelete;
		private System.Windows.Forms.ToolBarButton tbbConfirm;
		private System.Windows.Forms.ToolBarButton tbbApply;
		private System.Windows.Forms.ToolBarButton tbbClear;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		private int iHeaderID; 
		public AccountsStatementsList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.ucPeriod1._DateFrom = this.ucPeriod1._DateFrom.AddDays(-1);
			App.FillOrgsAccount();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);
			
			this.BindingContext[this.dvAccountsStatementsHeaders].CurrentChanged += new EventHandler(ChangedBindingContext);

			this.fillDs();
			//
			bll.Fill( App.UserLogonID );
			this.ucOrgsAndAccounts.Init(bll);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsStatementsList));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucPeriod1 = new AM_Controls.ucPeriodSimple();
            this.dvOrgs = new System.Data.DataView();
            this.dsUsersOrgsAndAccounts1 = new BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbNew = new System.Windows.Forms.ToolBarButton();
            this.tbbEdit = new System.Windows.Forms.ToolBarButton();
            this.tbbDelete = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.tbbConfirm = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.tbbApply = new System.Windows.Forms.ToolBarButton();
            this.tbbClear = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridV1 = new AM_Controls.DataGridV();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.dvAccountsStatementsHeaders = new System.Data.DataView();
            this.dsAccountsStatementsList1 = new BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.HeaderID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.HeaderDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.OrgName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.RAccount = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SaldoStart = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SaldoEnd = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Confirmed = new System.Windows.Forms.DataGridBoolColumn();
            this.ColumnRemarks = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridV2 = new AM_Controls.DataGridV();
            this.dvAccountsStatementsPayments = new System.Data.DataView();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.PaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PaymentOrderDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.OrgNameCorr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.RAccountCorr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.IN = new System.Windows.Forms.DataGridTextBoxColumn();
            this.OUT = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridTextBoxColumn();
            this.daGetHeadersList = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.daGetPaymsList = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.dvRAccount = new System.Data.DataView();
            this.daUpdHeader = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuiEdit = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
            this.ucOrgsAndAccounts = new BPS._Controls.OrgsAndAccounts();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvAccountsStatementsHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccountsStatementsList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvAccountsStatementsPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvRAccount)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucPeriod1);
            this.groupBox1.Controls.Add(this.ucOrgsAndAccounts);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // ucPeriod1
            // 
            this.ucPeriod1._cbDateFrom = true;
            this.ucPeriod1._cbDateFromUse = false;
            this.ucPeriod1._cbDateTill = true;
            this.ucPeriod1._cbDateTillUse = false;
            this.ucPeriod1._DateFrom = new System.DateTime(2017, 12, 16, 0, 0, 0, 0);
            this.ucPeriod1._DateTill = new System.DateTime(2017, 12, 16, 0, 0, 0, 0);
            this.ucPeriod1._PeriodType = AM_Controls.Span.Today;
            this.ucPeriod1.Location = new System.Drawing.Point(6, 18);
            this.ucPeriod1.Modified = true;
            this.ucPeriod1.Name = "ucPeriod1";
            this.ucPeriod1.Size = new System.Drawing.Size(242, 22);
            this.ucPeriod1.TabIndex = 0;
            // 
            // dvOrgs
            // 
            this.dvOrgs.Table = this.dsUsersOrgsAndAccounts1.Orgs;
            // 
            // dsUsersOrgsAndAccounts1
            // 
            this.dsUsersOrgsAndAccounts1.DataSetName = "dsUsersOrgsAndAccounts";
            this.dsUsersOrgsAndAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.dsUsersOrgsAndAccounts1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbNew,
            this.tbbEdit,
            this.tbbDelete,
            this.toolBarButton4,
            this.tbbConfirm,
            this.toolBarButton7,
            this.tbbApply,
            this.tbbClear});
            this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(856, 28);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbNew
            // 
            this.tbbNew.ImageIndex = 0;
            this.tbbNew.Name = "tbbNew";
            this.tbbNew.Text = "Новая";
            // 
            // tbbEdit
            // 
            this.tbbEdit.ImageIndex = 1;
            this.tbbEdit.Name = "tbbEdit";
            this.tbbEdit.Text = "Открыть";
            // 
            // tbbDelete
            // 
            this.tbbDelete.ImageIndex = 2;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Text = "Удалить";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 2;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButton4.Text = "Удалить";
            // 
            // tbbConfirm
            // 
            this.tbbConfirm.ImageIndex = 7;
            this.tbbConfirm.Name = "tbbConfirm";
            this.tbbConfirm.Text = "Подтвердить";
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbApply
            // 
            this.tbbApply.ImageIndex = 9;
            this.tbbApply.Name = "tbbApply";
            this.tbbApply.Text = "Выбрать";
            // 
            // tbbClear
            // 
            this.tbbClear.ImageIndex = 11;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Text = "Очистить";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            // 
            // dataGridV1
            // 
            this.dataGridV1._CanEdit = false;
            this.dataGridV1._InvisibleColumn = 0;
            this.dataGridV1.AllowNavigation = false;
            this.dataGridV1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGridV1.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridV1.CaptionVisible = false;
            this.dataGridV1.ContextMenu = this.contextMenu1;
            this.dataGridV1.DataMember = "";
            this.dataGridV1.DataSource = this.dvAccountsStatementsHeaders;
            this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridV1.Location = new System.Drawing.Point(0, 0);
            this.dataGridV1.Name = "dataGridV1";
            this.dataGridV1.ReadOnly = true;
            this.dataGridV1.Size = new System.Drawing.Size(856, 234);
            this.dataGridV1.TabIndex = 0;
            this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGridV1.DoubleClick += new System.EventHandler(this.dataGridV1_DoubleClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem6,
            this.menuItem5,
            this.menuItem7,
            this.menuItem10,
            this.menuItem1});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem2, ((System.Drawing.Icon)(resources.GetObject("menuItem2.MenuItemImage"))));
            this.menuItem2.OwnerDraw = true;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.menuItem2.Text = "Новая выписка";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem3, ((System.Drawing.Icon)(resources.GetObject("menuItem3.MenuItemImage"))));
            this.menuItem3.OwnerDraw = true;
            this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.menuItem3.Text = "Открыть выписку";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem4, ((System.Drawing.Icon)(resources.GetObject("menuItem4.MenuItemImage"))));
            this.menuItem4.OwnerDraw = true;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
            this.menuItem4.Text = "Удалить выписку";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem6, null);
            this.menuItem6.OwnerDraw = true;
            this.menuItem6.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem5, ((System.Drawing.Icon)(resources.GetObject("menuItem5.MenuItemImage"))));
            this.menuItem5.OwnerDraw = true;
            this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.F8;
            this.menuItem5.Text = "Подтвердить";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem7, null);
            this.menuItem7.OwnerDraw = true;
            this.menuItem7.Text = "-";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 6;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem10, ((System.Drawing.Icon)(resources.GetObject("menuItem10.MenuItemImage"))));
            this.menuItem10.OwnerDraw = true;
            this.menuItem10.Text = "Выбрать по фильтру";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 7;
            this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem1, ((System.Drawing.Icon)(resources.GetObject("menuItem1.MenuItemImage"))));
            this.menuItem1.OwnerDraw = true;
            this.menuItem1.Text = "Очистить фильтр";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // dvAccountsStatementsHeaders
            // 
            this.dvAccountsStatementsHeaders.ApplyDefaultSort = true;
            this.dvAccountsStatementsHeaders.Sort = "HeaderID";
            this.dvAccountsStatementsHeaders.Table = this.dsAccountsStatementsList1.AccountsStatementsHeaders;
            // 
            // dsAccountsStatementsList1
            // 
            this.dsAccountsStatementsList1.DataSetName = "dsAccountsStatementsList";
            this.dsAccountsStatementsList1.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.dsAccountsStatementsList1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGridV1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.HeaderID,
            this.HeaderDate,
            this.OrgName,
            this.RAccount,
            this.SaldoStart,
            this.SaldoEnd,
            this.Confirmed,
            this.ColumnRemarks});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "AccountsStatementsHeaders";
            // 
            // HeaderID
            // 
            this.HeaderID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.HeaderID.Format = "";
            this.HeaderID.FormatInfo = null;
            this.HeaderID.HeaderText = "ID";
            this.HeaderID.MappingName = "HeaderID";
            this.HeaderID.NullText = "-";
            this.HeaderID.Width = 50;
            // 
            // HeaderDate
            // 
            this.HeaderDate.Format = "dd/MM/yy";
            this.HeaderDate.FormatInfo = null;
            this.HeaderDate.HeaderText = "Дата";
            this.HeaderDate.MappingName = "HeaderDate";
            this.HeaderDate.NullText = "-";
            this.HeaderDate.Width = 70;
            // 
            // OrgName
            // 
            this.OrgName.Format = "";
            this.OrgName.FormatInfo = null;
            this.OrgName.HeaderText = "Организация";
            this.OrgName.MappingName = "OrgName";
            this.OrgName.NullText = "-";
            this.OrgName.Width = 200;
            // 
            // RAccount
            // 
            this.RAccount.Format = "";
            this.RAccount.FormatInfo = null;
            this.RAccount.HeaderText = "Р. счёт";
            this.RAccount.MappingName = "RAccount";
            this.RAccount.NullText = "-";
            this.RAccount.Width = 135;
            // 
            // SaldoStart
            // 
            this.SaldoStart.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.SaldoStart.Format = "#,##0.00";
            this.SaldoStart.FormatInfo = null;
            this.SaldoStart.HeaderText = "Сальдо на начало ";
            this.SaldoStart.MappingName = "SaldoStart";
            this.SaldoStart.NullText = "-";
            this.SaldoStart.Width = 110;
            // 
            // SaldoEnd
            // 
            this.SaldoEnd.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.SaldoEnd.Format = "#,##0.00";
            this.SaldoEnd.FormatInfo = null;
            this.SaldoEnd.HeaderText = "Сальдо на конец";
            this.SaldoEnd.MappingName = "SaldoEnd";
            this.SaldoEnd.NullText = "-";
            this.SaldoEnd.Width = 110;
            // 
            // Confirmed
            // 
            this.Confirmed.HeaderText = "Принята";
            this.Confirmed.MappingName = "Confirmed";
            this.Confirmed.NullText = "-";
            this.Confirmed.Width = 80;
            // 
            // ColumnRemarks
            // 
            this.ColumnRemarks.Format = "";
            this.ColumnRemarks.FormatInfo = null;
            this.ColumnRemarks.HeaderText = "Комментарий";
            this.ColumnRemarks.MappingName = "Remarks";
            this.ColumnRemarks.NullText = "-";
            this.ColumnRemarks.Width = 200;
            // 
            // dataGridV2
            // 
            this.dataGridV2._CanEdit = false;
            this.dataGridV2._InvisibleColumn = 0;
            this.dataGridV2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGridV2.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridV2.CaptionText = "Платёжные поручения";
            this.dataGridV2.DataMember = "";
            this.dataGridV2.DataSource = this.dvAccountsStatementsPayments;
            this.dataGridV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridV2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridV2.Location = new System.Drawing.Point(0, 0);
            this.dataGridV2.Name = "dataGridV2";
            this.dataGridV2.ReadOnly = true;
            this.dataGridV2.Size = new System.Drawing.Size(856, 166);
            this.dataGridV2.TabIndex = 0;
            this.dataGridV2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dvAccountsStatementsPayments
            // 
            this.dvAccountsStatementsPayments.ApplyDefaultSort = true;
            this.dvAccountsStatementsPayments.Sort = "AccountStatementID";
            this.dvAccountsStatementsPayments.Table = this.dsAccountsStatementsList1.AccountsStatements;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dataGridV2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.PaymentNo,
            this.PaymentOrderDate,
            this.OrgNameCorr,
            this.RAccountCorr,
            this.IN,
            this.OUT,
            this.PaymentOrderPurpose,
            this.Remarks});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "AccountsStatements";
            // 
            // PaymentNo
            // 
            this.PaymentNo.Format = "";
            this.PaymentNo.FormatInfo = null;
            this.PaymentNo.HeaderText = "Номер";
            this.PaymentNo.MappingName = "PaymentNo";
            this.PaymentNo.NullText = "-";
            this.PaymentNo.Width = 50;
            // 
            // PaymentOrderDate
            // 
            this.PaymentOrderDate.Format = "dd/MM/yy";
            this.PaymentOrderDate.FormatInfo = null;
            this.PaymentOrderDate.HeaderText = "От";
            this.PaymentOrderDate.MappingName = "PaymentOrderDate";
            this.PaymentOrderDate.NullText = "-";
            this.PaymentOrderDate.Width = 50;
            // 
            // OrgNameCorr
            // 
            this.OrgNameCorr.Format = "";
            this.OrgNameCorr.FormatInfo = null;
            this.OrgNameCorr.HeaderText = "Корреспондент";
            this.OrgNameCorr.MappingName = "OrgName";
            this.OrgNameCorr.NullText = "-";
            this.OrgNameCorr.Width = 115;
            // 
            // RAccountCorr
            // 
            this.RAccountCorr.Format = "";
            this.RAccountCorr.FormatInfo = null;
            this.RAccountCorr.HeaderText = "Р.счёт";
            this.RAccountCorr.MappingName = "RAccount";
            this.RAccountCorr.NullText = "-";
            this.RAccountCorr.Width = 135;
            // 
            // IN
            // 
            this.IN.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.IN.Format = "#,##0.00";
            this.IN.FormatInfo = null;
            this.IN.HeaderText = "Приход";
            this.IN.MappingName = "IN";
            this.IN.NullText = "-";
            this.IN.Width = 60;
            // 
            // OUT
            // 
            this.OUT.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.OUT.Format = "#,##0.00";
            this.OUT.FormatInfo = null;
            this.OUT.HeaderText = "Расход";
            this.OUT.MappingName = "OUT";
            this.OUT.NullText = "-";
            this.OUT.Width = 60;
            // 
            // PaymentOrderPurpose
            // 
            this.PaymentOrderPurpose.Format = "";
            this.PaymentOrderPurpose.FormatInfo = null;
            this.PaymentOrderPurpose.HeaderText = "Основание";
            this.PaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
            this.PaymentOrderPurpose.NullText = "-";
            this.PaymentOrderPurpose.Width = 175;
            // 
            // Remarks
            // 
            this.Remarks.Format = "";
            this.Remarks.FormatInfo = null;
            this.Remarks.HeaderText = "Примечание";
            this.Remarks.MappingName = "Remarks";
            this.Remarks.NullText = "-";
            this.Remarks.Width = 105;
            // 
            // daGetHeadersList
            // 
            this.daGetHeadersList.SelectCommand = this.sqlSelectCommand1;
            this.daGetHeadersList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AccountsStatementsHeaders", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
                        new System.Data.Common.DataColumnMapping("OrgAccountID", "OrgAccountID"),
                        new System.Data.Common.DataColumnMapping("HeaderDate", "HeaderDate"),
                        new System.Data.Common.DataColumnMapping("SaldoStart", "SaldoStart"),
                        new System.Data.Common.DataColumnMapping("SaldoEnd", "SaldoEnd"),
                        new System.Data.Common.DataColumnMapping("Confirmed", "Confirmed"),
                        new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
                        new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
                        new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
                        new System.Data.Common.DataColumnMapping("IsNormal", "IsNormal"),
                        new System.Data.Common.DataColumnMapping("OrgsAccountsIDCorr", "OrgsAccountsIDCorr"),
                        new System.Data.Common.DataColumnMapping("OrgID", "OrgID")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[AccountsStatementsHeaders_Select]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(10)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@HeaderDateFrom", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@HeaderDateTill", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "0"),
            new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "0"),
            new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "0")});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // daGetPaymsList
            // 
            this.daGetPaymsList.SelectCommand = this.sqlSelectCommand2;
            this.daGetPaymsList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetAccountStatementsPaymentsList", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
                        new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
                        new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
                        new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
                        new System.Data.Common.DataColumnMapping("Direction", "Direction"),
                        new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
                        new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
                        new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
                        new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
                        new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
                        new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
                        new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
                        new System.Data.Common.DataColumnMapping("IsNormal", "IsNormal"),
                        new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID"),
                        new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[AccountsStatementsDetails_Select]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@DateFrom", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@DateTill", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4)});
            // 
            // daUpdHeader
            // 
            this.daUpdHeader.DeleteCommand = this.sqlDeleteCommand1;
            this.daUpdHeader.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AccountsStatementsHeaders", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
                        new System.Data.Common.DataColumnMapping("OrgAccountID", "OrgAccountID"),
                        new System.Data.Common.DataColumnMapping("HeaderDate", "HeaderDate"),
                        new System.Data.Common.DataColumnMapping("SaldoStart", "SaldoStart"),
                        new System.Data.Common.DataColumnMapping("SaldoEnd", "SaldoEnd"),
                        new System.Data.Common.DataColumnMapping("Confirmed", "Confirmed")})});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "[AccountsStatementsHeader_Delete]";
            this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4)});
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuiEdit});
            // 
            // mnuiEdit
            // 
            this.mnuiEdit.Index = 0;
            this.MenuItemImageProvider1.SetMenuItemImage(this.mnuiEdit, null);
            this.mnuiEdit.OwnerDraw = true;
            this.mnuiEdit.Text = "Редактирование";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 40);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 406);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridV2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 166);
            this.panel4.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 234);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(856, 6);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(856, 234);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridV1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(856, 234);
            this.panel5.TabIndex = 0;
            // 
            // MenuItemImageProvider1
            // 
            this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
            this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
            this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
            // 
            // ucOrgsAndAccounts
            // 
            this.ucOrgsAndAccounts.Location = new System.Drawing.Point(280, 14);
            this.ucOrgsAndAccounts.Name = "ucOrgsAndAccounts";
            this.ucOrgsAndAccounts.OrgAccountID = 0;
            this.ucOrgsAndAccounts.OrgID = 0;
            this.ucOrgsAndAccounts.Size = new System.Drawing.Size(508, 26);
            this.ucOrgsAndAccounts.TabIndex = 2;
            // 
            // AccountsStatementsList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(856, 474);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "AccountsStatementsList";
            this.Text = "Банковские выписки";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AccountsStatementsList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvAccountsStatementsHeaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccountsStatementsList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvAccountsStatementsPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvRAccount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void fillDs()
		{
			try
			{
				this.dsAccountsStatementsList1.AccountsStatements.Clear();
				this.dsAccountsStatementsList1.AccountsStatementsHeaders.Clear();
				//Headers
				System.DateTime dtFrom =this.ucPeriod1._DateFrom.Date;
				System.DateTime dtTill =this.ucPeriod1._DateTill.Date;

				dtFrom = dtFrom.AddHours		( -dtFrom.Hour		 );
				dtFrom = dtFrom.AddMinutes		( -dtFrom.Minute	 );
				dtFrom = dtFrom.AddSeconds		( -dtFrom.Second	 );
				dtFrom = dtFrom.AddMilliseconds	( -dtFrom.Millisecond);
				
				dtTill = dtTill.AddHours		( -dtTill.Hour		 );
				dtTill = dtTill.AddMinutes		( -dtTill.Minute	 );
				dtTill = dtTill.AddSeconds		( -dtTill.Second	 );
				dtTill = dtTill.AddMilliseconds	( -dtTill.Millisecond);
				dtTill = dtTill.AddDays( 1);
				dtTill = dtTill.AddMilliseconds	( -1);

				this.daGetHeadersList.SelectCommand.Parameters["@HeaderDateFrom"].Value = dtFrom.Date; //this.ucPeriod1._DateFrom.Date;
				this.daGetHeadersList.SelectCommand.Parameters["@HeaderDateTill"].Value = dtTill.Date; //this.ucPeriod1._DateTill.Date.AddDays(1);

				this.daGetHeadersList.SelectCommand.Parameters["@OrgID"].Value        = Convert.ToInt32( this.ucOrgsAndAccounts.OrgID );  
				this.daGetHeadersList.SelectCommand.Parameters["@OrgAccountID"].Value = Convert.ToInt32( this.ucOrgsAndAccounts.OrgAccountID);
				this.daGetHeadersList.SelectCommand.Parameters["@UserID"].Value = Convert.ToInt32( App.UserLogonID );

				this.daGetHeadersList.Fill(this.dsAccountsStatementsList1.AccountsStatementsHeaders);
				//Details
				this.daGetPaymsList.SelectCommand.Parameters["@DateFrom"].Value = dtFrom.Date; //this.ucPeriod1._DateFrom.Date;
				this.daGetPaymsList.SelectCommand.Parameters["@DateTill"].Value = dtTill.Date; //this.ucPeriod1._DateTill.Date.AddDays(1);
				this.daGetPaymsList.SelectCommand.Parameters["@OrgID"].Value        = Convert.ToInt32( this.ucOrgsAndAccounts.OrgID );  
				this.daGetPaymsList.SelectCommand.Parameters["@OrgAccountID"].Value = Convert.ToInt32( this.ucOrgsAndAccounts.OrgAccountID);
				this.daGetPaymsList.SelectCommand.Parameters["@UserID"].Value = Convert.ToInt32( App.UserLogonID );

				this.daGetPaymsList.Fill(this.dsAccountsStatementsList1.AccountsStatements);
				
				this.dataGridV1.CurrentRowIndex = 0;
					this.dataGridV2.CurrentRowIndex = 0;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private bool validateAccountStatement(BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow rw)
		{
			if(rw.SaldoStart < 0)
			{
				AM_Controls.MsgBoxX.Show("Правильно заполните ВХОДЯЩИЙ ОСТАТОК", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				
				return false;
			}
			if(rw.SaldoEnd < 0)
			{
				AM_Controls.MsgBoxX.Show("Правильно заполните ИСХОДЯЩИЙ ОСТАТОК", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				
				return false;
			}
			else return true;
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button ==this.tbbNew)
				addHeader();
			else if (e.Button ==this.tbbEdit)
				editHeader();
			else if (e.Button ==this.tbbDelete)
				delHeader();
			else if (e.Button ==this.tbbConfirm) 
			{
				if(!App.AllowAccountsStatementsConfirmed)
					return;
				confirmedHeader();
			}
			else if (e.Button ==this.tbbApply)
				this.FilterApply();
			else if (e.Button ==this.tbbClear)
				this.FilterClear();
		}
		private void delHeader()
		{
			if(!App.AllowAccountsStatementsEdit)
				return;
			if(this.dvAccountsStatementsHeaders.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvAccountsStatementsHeaders];
				BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow rw = (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;
				if(AM_Controls.MsgBoxX.Show("Удалить выписку №" + rw.HeaderID + "?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if(!rw.Confirmed)
					{
						SqlCommand cmdUpdPaymentsOrders = new SqlCommand("[UpdatePaymentsOrdersReturn]", App.Connection);
						cmdUpdPaymentsOrders.CommandType = CommandType.StoredProcedure;
						cmdUpdPaymentsOrders.Parameters.Add(new SqlParameter("@AccountStatementID", SqlDbType.Int));
						SqlCommand cmdDelPayms  = new SqlCommand("DELETE FROM AccountsStatements WHERE HeaderID=" + rw.HeaderID.ToString(), App.Connection);
						SqlCommand cmdDelHeader = new SqlCommand("DELETE FROM AccountsStatementsHeaders WHERE HeaderID=" + rw.HeaderID.ToString(), App.Connection);
						App.Connection.Open();
						SqlTransaction tr = App.Connection.BeginTransaction();
						cmdUpdPaymentsOrders.Transaction = cmdDelPayms.Transaction = cmdDelHeader.Transaction = tr;
						try
						{
							for(int i=0;i<this.dvAccountsStatementsPayments.Count;i++)
							{
								BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsRow accRow = (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsRow) this.dvAccountsStatementsPayments[i].Row;
								if(!accRow.Direction)
								{
									cmdUpdPaymentsOrders.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
									cmdUpdPaymentsOrders.ExecuteNonQuery();
								}
							}
							cmdDelPayms.ExecuteNonQuery();
							cmdDelHeader.ExecuteNonQuery();
							tr.Commit();
							((DataRowView)bm.Current).Delete();
						}
						catch(Exception ex)
						{
							tr.Rollback();
							AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						finally
						{
							App.Connection.Close();
						}
					}
					else if((this.dvAccountsStatementsPayments.Count == 0) && App.AllowEditConfirmedAccountStatement)
					{
						((DataRowView)bm.Current).Delete();
						try
						{
							this.daUpdHeader.Update(this.dsAccountsStatementsList1.AccountsStatementsHeaders);
						}
						catch(Exception ex)
						{
							AM_Controls.MsgBoxX.Show(ex.Message);
						}
					}else
						AM_Controls.MsgBoxX.Show("Удаление невозможно. Выписка уже принята.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		
		private bool checkHeader(int iHeaderID)
		{
			SqlCommand cmdCheckHeader = new SqlCommand("[CheckHeader]", App.Connection);
			cmdCheckHeader.CommandType = CommandType.StoredProcedure;
			cmdCheckHeader.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
			cmdCheckHeader.Parameters.Add(new SqlParameter("@Confirmed", SqlDbType.Bit));
			cmdCheckHeader.Parameters["@Confirmed"].Direction = ParameterDirection.Output;
			cmdCheckHeader.Parameters["@HeaderID"].Value = iHeaderID;
			try
			{
				App.Connection.Open();
				cmdCheckHeader.ExecuteNonQuery();
				object o = cmdCheckHeader.Parameters["@Confirmed"].Value;
				if((o == Convert.DBNull) || (Convert.ToBoolean(o)))
					return true;
				else 
					return false;

			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
				return false;
			}
			finally
			{
				App.Connection.Close();
			}
		}

		private void confirmedHeader()
		{
			if(this.dvAccountsStatementsHeaders.Count==0)
				return;
			if(this.dvAccountsStatementsPayments.Count == 0)
			{
				AM_Controls.MsgBoxX.Show("Выписка не принята. Нет платёжных поручений.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvAccountsStatementsHeaders];
			BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow rw = (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;
			if(rw.Confirmed || this.checkHeader(rw.HeaderID))
				return;
			if(!validateAccountStatement(rw))
			{
				return;
			}
			double dCheckSum = rw.SaldoStart;
			for(int i=0;i<this.dvAccountsStatementsPayments.Count;i++)
			{
				BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsRow accRw = (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsRow) this.dvAccountsStatementsPayments[i].Row;
				if(!accRw.Direction)
					dCheckSum -= accRw.PaymentOrderSum;
				else
					dCheckSum += accRw.PaymentOrderSum;
			}
			if(rw.SaldoEnd != Math.Round(dCheckSum,2))
			{
				AM_Controls.MsgBoxX.Show("Не сходятся суммы п/п и исходящий остаток! Проверьте правильность введённых данных.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			SqlCommand cmdConfirmedHeader = new SqlCommand("[ConfirmedHeaderNew]", App.Connection);
			cmdConfirmedHeader.CommandType = CommandType.StoredProcedure;
			cmdConfirmedHeader.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
			cmdConfirmedHeader.Parameters["@HeaderID"].Value = rw.HeaderID;
			try
			{
				App.Connection.Open();
				cmdConfirmedHeader.ExecuteNonQuery();
				rw.Confirmed = true;
				dsAccountsStatementsList1.AccountsStatementsHeaders.AcceptChanges();
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
			finally
			{
				App.Connection.Close();
			}
		}
/*
 * Первый вариант
 * 		private void confirmedHeader1()
 
		{
			if(this.dvAccountsStatementsHeaders.Count==0)
				return;
			if(this.dvAccountsStatementsPayments.Count == 0)
			{
				AM_Controls.MsgBoxX.Show("Выписка не принята. Нет платёжных поручений.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvAccountsStatementsHeaders];
			BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsHeadersRow rw = (BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;
			if(rw.Confirmed)
				return;
			if(!validateAccountStatement(rw))
			{
				return;
			}
			double dCheckSum = rw.SaldoStart;
			for(int i=0;i<this.dvAccountsStatementsPayments.Count;i++)
			{
				BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsRow accRw = (BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsRow) this.dvAccountsStatementsPayments[i].Row;
				if(!accRw.Direction)
					dCheckSum -= accRw.PaymentOrderSum;
				else
					dCheckSum += accRw.PaymentOrderSum;
			}
			if(rw.SaldoEnd != Math.Round(dCheckSum,2))
			{
				AM_Controls.MsgBoxX.Show("Не сходятся суммы п/п и исходящий остаток! Проверьте правильность введённых данных.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			//Подтверждение Header
			SqlCommand cmdUpdHeader = new SqlCommand("[ConfirmedHeader]", App.Connection);
			cmdUpdHeader.CommandType = CommandType.StoredProcedure;
			cmdUpdHeader.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
			cmdUpdHeader.Parameters["@HeaderID"].Value = rw.HeaderID;
			//Проверка PaymentsOrders
			SqlCommand cmdLikePayms = new SqlCommand("[LikePaymentsOrders]", App.Connection);
			cmdLikePayms.CommandType = CommandType.StoredProcedure;
			cmdLikePayms.Parameters.Add(new SqlParameter("@AccountStatementID",SqlDbType.Int));
			cmdLikePayms.Parameters.Add(new SqlParameter("@PaymentOrderID",SqlDbType.Int));
			cmdLikePayms.Parameters["@PaymentOrderID"].Direction = ParameterDirection.Output;
			//Добавление PaymentsOrders для всех приходов
			SqlCommand cmdInsPaym   = new SqlCommand("[InsertPaymentsOrders]", App.Connection);
			cmdInsPaym.CommandType = CommandType.StoredProcedure;
			cmdInsPaym.Parameters.Add(new SqlParameter("@HeaderID",SqlDbType.Int));
			cmdInsPaym.Parameters.Add(new SqlParameter("@PaymentOrderDate",SqlDbType.DateTime));
			cmdInsPaym.Parameters.Add(new SqlParameter("@OrgAccountID",SqlDbType.Int));
			cmdInsPaym.Parameters.Add(new SqlParameter("@OrgAccountIDCorr",SqlDbType.Int));
			cmdInsPaym.Parameters.Add(new SqlParameter("@Direction",SqlDbType.Bit));
			cmdInsPaym.Parameters.Add(new SqlParameter("@PaymentOrderSum",SqlDbType.Float));
			cmdInsPaym.Parameters.Add(new SqlParameter("@PaymentOrderPurpose",SqlDbType.NVarChar));
			cmdInsPaym.Parameters.Add(new SqlParameter("@Remarks",SqlDbType.NVarChar));
			cmdInsPaym.Parameters.Add(new SqlParameter("@PaymentsOrderStatusID",SqlDbType.Int));
			cmdInsPaym.Parameters.Add(new SqlParameter("@IsPrinted",SqlDbType.Bit));
			cmdInsPaym.Parameters.Add(new SqlParameter("@PaymentNo",SqlDbType.NVarChar));
			cmdInsPaym.Parameters.Add(new SqlParameter("@AccountStatementID", SqlDbType.Int));
			cmdInsPaym.Parameters.Add(new SqlParameter("@PaymentOrderID",SqlDbType.Int));
			cmdInsPaym.Parameters["@PaymentOrderID"].Direction = ParameterDirection.Output;
			//Изменение PaymentsOrders если найдено соответствие
			SqlCommand cmdUpdPaym   = new SqlCommand("[UpdatePaymentsOrders]", App.Connection);
			cmdUpdPaym.CommandType = CommandType.StoredProcedure;
			cmdUpdPaym.Parameters.Add(new SqlParameter("@HeaderID",SqlDbType.Int));
			cmdUpdPaym.Parameters.Add(new SqlParameter("@PaymentOrderDate",SqlDbType.DateTime));
			cmdUpdPaym.Parameters.Add(new SqlParameter("@PaymentOrderStatusID",SqlDbType.Int));
			cmdUpdPaym.Parameters.Add(new SqlParameter("@AccountStatementID",SqlDbType.Int));
			cmdUpdPaym.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar));
			cmdUpdPaym.Parameters.Add(new SqlParameter("@PaymentOrderID",SqlDbType.Int));
			cmdUpdPaym.Parameters["@PaymentOrderID"].Direction = ParameterDirection.Output;
			//Добавление Transaction для приходов
			SqlCommand cmdInsTrans = new SqlCommand("[InsertTransactions]", App.Connection);
			cmdInsTrans.CommandType = CommandType.StoredProcedure;
			cmdInsTrans.Parameters.Add(new SqlParameter("@TransactionTypeID",SqlDbType.Int));
			cmdInsTrans.Parameters.Add(new SqlParameter("@TransactionCommited",SqlDbType.Bit));
			cmdInsTrans.Parameters.Add(new SqlParameter("@SumFrom",SqlDbType.Float));
			cmdInsTrans.Parameters.Add(new SqlParameter("@SumTo",SqlDbType.Float));
			cmdInsTrans.Parameters.Add(new SqlParameter("@AccountIDFrom",SqlDbType.Int));
			cmdInsTrans.Parameters.Add(new SqlParameter("@AccountIDTo",SqlDbType.Int));
			cmdInsTrans.Parameters.Add(new SqlParameter("@DocumentID",SqlDbType.Int));
			cmdInsTrans.Parameters.Add(new SqlParameter("@InitDate",SqlDbType.DateTime));
			cmdInsTrans.Parameters.Add(new SqlParameter("@TransactionID",SqlDbType.Int));
			cmdInsTrans.Parameters["@TransactionID"].Direction = ParameterDirection.Output;
			//Изменение Transaction
			SqlCommand cmdGetTransID = new SqlCommand("[UpdateTransactions]", App.Connection);
			cmdGetTransID.CommandType = CommandType.StoredProcedure;
			cmdGetTransID.Parameters.Add(new SqlParameter("@TransactionCommited",SqlDbType.Bit));
			cmdGetTransID.Parameters.Add(new SqlParameter("@DocumentID",SqlDbType.Int));
			cmdGetTransID.Parameters.Add(new SqlParameter("@TransactionID",SqlDbType.Int));
			cmdGetTransID.Parameters["@TransactionID"].Direction = ParameterDirection.Output;
			//SqlCommand cmdGetIdentity = new SqlCommand("SELECT @@IDENTITY", App.Connection);
			SqlCommand cmdUpdTransaction = new SqlCommand("[ChangeTransactionStatus_Commiting]", App.Connection);
			cmdUpdTransaction.CommandType = CommandType.StoredProcedure;
			cmdUpdTransaction.Parameters.Add(new SqlParameter("@nTransactionID",SqlDbType.Int));
			cmdUpdTransaction.Parameters.Add(new SqlParameter("@bCommiting",SqlDbType.Bit));
			//cmdUpdTransaction.Parameters.Add(new SqlParameter("@bPosting",SqlDbType.Bit));
			App.Connection.Open();
			SqlTransaction tr = App.Connection.BeginTransaction();
			cmdUpdHeader.Transaction  = cmdInsPaym.Transaction =  cmdLikePayms.Transaction = 
				cmdUpdPaym.Transaction = cmdInsTrans.Transaction = cmdGetTransID.Transaction = cmdUpdTransaction.Transaction = tr;
				//cmdInsAccOper.Transaction = cmdUpdAccounts.Transaction = tr;
			try
			{
				cmdUpdHeader.ExecuteNonQuery();
				for(int i=0;i<this.dvAccountsStatementsPayments.Count;i++)
				{
					BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsRow accRow = (BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsRow) this.dvAccountsStatementsPayments[i].Row;
					if(!accRow.Direction)
					{
						{
							int iPaymID=0;
							cmdUpdPaym.Parameters["@HeaderID"].Value = rw.HeaderID;
							cmdUpdPaym.Parameters["@PaymentOrderDate"].Value = accRow.PaymentOrderDate;
							cmdUpdPaym.Parameters["@PaymentOrderStatusID"].Value = 3;
							cmdUpdPaym.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
							if(accRow.IsRemarksNull())
								cmdUpdPaym.Parameters["@Remarks"].Value = Convert.DBNull;
							else
								cmdUpdPaym.Parameters["@Remarks"].Value = accRow.Remarks;
							cmdUpdPaym.ExecuteNonQuery();
							iPaymID = (int) cmdUpdPaym.Parameters["@PaymentOrderID"].Value;
							if(iPaymID<1)
							{
								tr.Rollback();
								return;
							}
							/////////////
							cmdGetTransID.Parameters["@TransactionCommited"].Value = true;
							cmdGetTransID.Parameters["@DocumentID"].Value = iPaymID;
							cmdGetTransID.ExecuteNonQuery();
							
							int iTropID = (int) cmdGetTransID.Parameters["@TransactionID"].Value;
							if(iTropID<1)
							{
								tr.Rollback();
								return;
							}
							cmdUpdTransaction.Parameters["@nTransactionID"].Value = iTropID;
							cmdUpdTransaction.Parameters["@bCommiting"].Value = true;
						//	cmdUpdTransaction.Parameters["@bPosting"].Value = true;
							cmdUpdTransaction.ExecuteNonQuery();
						}
					}
					else
					{
						int iPaymID;
						int iTrID;
						cmdLikePayms.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
						cmdLikePayms.ExecuteNonQuery();
						iPaymID = (int)cmdLikePayms.Parameters["@PaymentOrderID"].Value;
						if(iPaymID >0)
						{
							cmdUpdPaym.Parameters["@HeaderID"].Value = rw.HeaderID;
							cmdUpdPaym.Parameters["@PaymentOrderDate"].Value = accRow.PaymentOrderDate;
							cmdUpdPaym.Parameters["@PaymentOrderStatusID"].Value = 3;
							cmdUpdPaym.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
							if(accRow.IsRemarksNull())
								cmdUpdPaym.Parameters["@Remarks"].Value = Convert.DBNull;
							else
								cmdUpdPaym.Parameters["@Remarks"].Value = accRow.Remarks;
							cmdUpdPaym.ExecuteNonQuery();
							iPaymID = (int) cmdUpdPaym.Parameters["@PaymentOrderID"].Value;
							if(iPaymID<1)
							{
								tr.Rollback();
								return;
							}
							cmdGetTransID.Parameters["@TransactionCommited"].Value = true;
							cmdGetTransID.Parameters["@DocumentID"].Value = iPaymID;
							cmdGetTransID.ExecuteNonQuery();
							
							iTrID = (int) cmdGetTransID.Parameters["@TransactionID"].Value;
							if(iTrID<1)
							{
								tr.Rollback();
								return;
							}
						}
						else
						{
							cmdInsPaym.Parameters["@HeaderID"].Value = rw.HeaderID;
							cmdInsPaym.Parameters["@PaymentOrderDate"].Value = accRow.PaymentOrderDate;
							cmdInsPaym.Parameters["@PaymentNo"].Value = accRow.PaymentNo;
							cmdInsPaym.Parameters["@OrgAccountID"].Value = rw.OrgAccountID;
							cmdInsPaym.Parameters["@OrgAccountIDCorr"].Value = accRow.OrgAccountIDCorr;
							cmdInsPaym.Parameters["@Direction"].Value = accRow.Direction;
							cmdInsPaym.Parameters["@PaymentOrderSum"].Value = accRow.PaymentOrderSum;
							if(accRow.IsPaymentOrderPurposeNull())
								cmdInsPaym.Parameters["@PaymentOrderPurpose"].Value = Convert.DBNull;
							else
								cmdInsPaym.Parameters["@PaymentOrderPurpose"].Value = accRow.PaymentOrderPurpose;
							if(accRow.IsRemarksNull())
								cmdInsPaym.Parameters["@Remarks"].Value = Convert.DBNull;
							else
								cmdInsPaym.Parameters["@Remarks"].Value = accRow.Remarks;
							cmdInsPaym.Parameters["@PaymentsOrderStatusID"].Value = 3;
							cmdInsPaym.Parameters["@IsPrinted"].Value = false;
							cmdInsPaym.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
							cmdInsPaym.ExecuteNonQuery();
							iPaymID = (int) cmdInsPaym.Parameters["@PaymentOrderID"].Value;
							if(iPaymID<1)
							{
								tr.Rollback();
								return;
							}
							cmdInsTrans.Parameters["@DocumentID"].Value = iPaymID;
							cmdInsTrans.Parameters["@TransactionTypeID"].Value = 1;
							cmdInsTrans.Parameters["@TransactionCommited"].Value = false;
							cmdInsTrans.Parameters["@SumFrom"].Value = accRow.PaymentOrderSum;
							cmdInsTrans.Parameters["@SumTo"].Value = accRow.PaymentOrderSum;
							cmdInsTrans.Parameters["@AccountIDFrom"].Value = accRow.AccountID;
							cmdInsTrans.Parameters["@AccountIDTo"].Value = rw.AccountID;
							cmdInsTrans.Parameters["@InitDate"].Value = DateTime.Now;
							cmdInsTrans.ExecuteNonQuery();
							iTrID = (int) cmdInsTrans.Parameters["@TransactionID"].Value;
							if(iTrID<1)
							{
								tr.Rollback();
								return;
							}
						}
						cmdUpdTransaction.Parameters["@nTransactionID"].Value = iTrID;
						cmdUpdTransaction.Parameters["@bCommiting"].Value = true;
						//cmdUpdTransaction.Parameters["@bPosting"].Value = false;
						cmdUpdTransaction.ExecuteNonQuery();
					}
				}
				tr.Commit();
				rw.Confirmed = true;
			}
			catch(Exception ex)
			{
				try
				{
					tr.Rollback();
				}
				catch{}
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				App.Connection.Close();
			}
		}
		*/

		private void editHeader()
		{
			// ReCreated by MIKE 03.06.03
			//
			if ( this.dvAccountsStatementsHeaders.Count <=0)	return; //Statements Headers List is Empty
			if ( !App.AllowAccountsStatementsEdit)				return; //Check Users Permissions
			
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvAccountsStatementsHeaders];
			BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow rwTemp = (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;
			
			if ( bm.Position <0) return;

			if ( rwTemp.Confirmed && !App.AllowEditConfirmedAccountStatement) return; //Check Users Permissions if Statement is Confirmed
					
			if ( !this.findOpenedHeader(this.MdiParent)) //Statement Header already edited 
			{
				if ( this.iHeaderID !=rwTemp.HeaderID)
					AM_Controls.MsgBoxX.Show("В данный момент редактируется другая выписка. Если Вы хотите редактировать выписку с ID=" 
						+ rwTemp.HeaderID.ToString() + " закончите редактировать текущую выписку.");
				return;
			}

			BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow rw =(BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;	
			if (!App.LockStatusChange(2, rw.HeaderID, true)) return; //Document Locked by another User

			BPS._Forms.AccountStatementEdit pe =new AccountStatementEdit( true, rw, this.dsAccountsStatementsList1);
			pe.MdiParent	=this.MdiParent;
			this.iHeaderID	=rw.HeaderID;
			pe.Text		+=( !rw.Confirmed)?" [Редактирование]" :" [Изменение]";			
			pe.Memorize +=new AccountStatementEdit.MemorizeEventHandler(pe_Memorize);
			
			pe.Show();
		}

		private bool findOpenedHeader(Form frm)
		{
			foreach( Form f in frm.MdiChildren) 
			{
				if (f.GetType()==typeof(AccountStatementEdit))
				{
					f.Show();
					f.Activate();
					return false;
				}
			}
			return true;
		}
		private void addHeader()
		{
			if(!App.AllowAccountsStatementsEdit)
				return;
			BPS._Forms.AccountStatementNewHeader nh = new BPS._Forms.AccountStatementNewHeader();
			nh.ShowDialog();
			if(nh.DialogResult == DialogResult.OK)
			{
				//
				if(!this.findOpenedHeader(this.MdiParent))
				{
					AM_Controls.MsgBoxX.Show("В данный момент редактируется другая выписка. Если Вы хотите редактировать выписку с ID=" + nh.HeaderID.ToString() + " закончите редактировать текущую выписку.");
					return;
				}
				//
				this.fillDs();
				if((nh.HeaderID == -1)||(this.dvAccountsStatementsHeaders.Count == 0))
					return;
				
				BindingManagerBase bm = this.BindingContext[this.dvAccountsStatementsHeaders];
				for(int i = 0; i < this.dvAccountsStatementsHeaders.Count; i++)
				{
					if(Convert.ToInt32(this.dvAccountsStatementsHeaders[i].Row["HeaderID"]) == nh.HeaderID)
					{
						bm.Position = i;
						break;
					}
				}
				if(Convert.ToInt32(((DataRowView)bm.Current).Row["HeaderID"]) == nh.HeaderID)
					this.editHeader();
			}
		}
		private void pe_Memorize()
		{
			this.fillDs();
			if(this.iHeaderID>0)
				this.setLastIns(iHeaderID);
		}
		private void setLastIns(int iID)
		{
			int iNewPosition = this.dvAccountsStatementsHeaders.Count-1;
			for(int j=0 ; j<this.dvAccountsStatementsHeaders.Count;j++)
			{
				if(Convert.ToInt32(this.dvAccountsStatementsHeaders[j].Row["HeaderID"]) == iID)
				{
					iNewPosition = j;
					break;
				}
			}
			this.BindingContext[this.dvAccountsStatementsHeaders].Position = iNewPosition;
		}
		private void ChangedBindingContext(object sender, EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvAccountsStatementsHeaders];
			if ( bm.Position <0) return;

			BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow rw = (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;
			this.m_HeaderRow =  (BPS.BLL.AccountStatemets.DataSets.dsAccountsStatementsList.AccountsStatementsHeadersRow)((DataRowView)bm.Current).Row;
			this.dvAccountsStatementsPayments.RowFilter = "HeaderID=" + rw.HeaderID;
		}


		private void AccountsStatementsList_Load(object sender, System.EventArgs e)
		{
			this.setPermissions();
//			AM_Lib.Menu.Clone(this.mnuiEdit.MenuItems, this.contextMenu1);
			AM_Lib.Menu.Clone (this.contextMenu1.MenuItems, this.mnuiEdit);
			FilterClear();
			FilterApply();
		}

		private void setPermissions()
		{
			this.tbbConfirm.Enabled = this.menuItem5.Enabled = App.AllowAccountsStatementsConfirmed;
			this.tbbNew.Enabled = this.menuItem2.Enabled = App.AllowAccountsStatementsEdit;
			this.tbbEdit.Enabled = this.menuItem3.Enabled = App.AllowAccountsStatementsEdit;
			this.tbbDelete.Enabled = this.menuItem4.Enabled = App.AllowAccountsStatementsEdit;
		}

		private void FilterApply()
		{
			this.fillDs();
/*
			if (this.ucPeriod1.HasChanges()) 
			{
				this.fillDs();
				this.ucPeriod1.ResetChanges();
			}
			string szFilter = "";
//			szFilter += "(HeaderDate>=" + this.getDate(ucPeriod1._DateFrom,"00:00:00") + " and HeaderDate<=" + this.getDate(this.ucPeriod1._DateTill,"23:59:59") + ")";
			if(this.cmbOrg.SelectedIndex>0) 
			{
				if (szFilter.Length!=0)
					szFilter += " AND ";
				szFilter += "OrgID=" + this.cmbOrg.SelectedValue.ToString();
			}
			if(this.cmbRAccount.SelectedIndex>0)
				szFilter += " and OrgsAccountsID=" + this.cmbRAccount.SelectedValue.ToString();
			this.dvAccountsStatementsHeaders.RowFilter = szFilter;
*/
		}

		private void FilterClear()
		{
			ucOrgsAndAccounts.OrgID = 0;
			ucOrgsAndAccounts.OrgAccountID = 0;
			this.ucPeriod1._PeriodType = AM_Controls.Span.LastTwoWorkingDays;
		}

		private string getDate(DateTime dt, string szTime)
		{
			return "#" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString() + " " + szTime + "#";
		}

		private void dataGridV1_DoubleClick(object sender, System.EventArgs e)
		{
			this.editHeader();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			//Новая
			this.addHeader();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			//изменить
			this.editHeader();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			//удалить
			this.delHeader();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			//подтвердить
			this.confirmedHeader();
		}


		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.FilterApply();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.FilterClear();
		}



	}
}
