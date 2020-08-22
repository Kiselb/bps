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
	/// Summary description for AccountStatementEdit.
	/// </summary>
	public class AccountStatementEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dtpExtractDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbInnerOrgs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbInnerAccount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private AM_Controls.TextBoxV tbSaldoStart;
		private AM_Controls.TextBoxV tbSaldoEnd;
		private AM_Controls.DataGridV dataGridV1;
		private System.Data.DataView dvPaymsList;
		private System.Data.DataView dvInnerOrgs;
		private System.Data.DataView dvInnerAccount;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS._Forms.dsPaymentOrderListX dsPaymentOrderListX1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentNo;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderSum;
		private System.Windows.Forms.DataGridTextBoxColumn OrgName;
		private System.Windows.Forms.DataGridTextBoxColumn Remarks;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn RAccount;
		private System.Windows.Forms.DataGridTextBoxColumn Direct;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Data.SqlClient.SqlDataAdapter daPaymsList;
		private bool bIsLoaded = false;
		private bool bIsEdit;
		public delegate void MemorizeEventHandler();
		public event MemorizeEventHandler Memorize;
		BPS.BLL.AccountStatements.dsAccountsStatementsList dsPaymsList;
		private AM_Controls.DataGridV dataGridV2;
		private System.Data.DataView dvUnLinkedPaymList;
		private System.Data.SqlClient.SqlDataAdapter daGetUnlinkedPaymList;
		private BPS._Forms.dsUnlinkedPaymList dsUnlinkedPaymList1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderID;
		private System.Windows.Forms.DataGridTextBoxColumn OrgNameCorr;
		private System.Windows.Forms.DataGridTextBoxColumn RAccountCorr;
		private System.Windows.Forms.DataGridTextBoxColumn сPaymentOrderSum;
		private System.Windows.Forms.DataGridTextBoxColumn сPaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn сRemarks;
		private System.Windows.Forms.DataGridTextBoxColumn Date;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Data.SqlClient.SqlDataAdapter daUpdAccStatements;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		private System.Data.SqlClient.SqlDataAdapter daUpdPaymentsOrders;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
		BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsHeadersRow rwHeader;
		private System.Windows.Forms.DataGridTextBoxColumn сPaymentNo;
		private System.Windows.Forms.TabControl tabControl1;
		private AM_Controls.DataGridV dataGridV3;
		private System.Data.DataView dvUnlinkedPaymInList;
		private BPS._Forms.dsUnlinkedPaymList dsUnlinkedPaymInList;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn ID;
		private System.Windows.Forms.DataGridTextBoxColumn DateIn;
		private System.Windows.Forms.DataGridTextBoxColumn No;
		private System.Windows.Forms.DataGridTextBoxColumn Sum;
		private System.Windows.Forms.DataGridTextBoxColumn OrgCorr;
		private System.Windows.Forms.DataGridTextBoxColumn RAccountCorrIn;
		private System.Windows.Forms.DataGridTextBoxColumn Purp;
		private System.Windows.Forms.DataGridTextBoxColumn Rem;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlDataAdapter daGetUnlinkedPaymInList;
		private System.Windows.Forms.TabPage tabPageOut;
		private System.Windows.Forms.TabPage tabPageIn;
		private int iHeaderID;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private int iOrgAccountID;
		private System.Data.SqlClient.SqlCommand cmdCheckPaym;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private bool bIsNew;
		private bool m_bIsConfirmed =false;

		public AccountStatementEdit(bool bIsEdit, int OrgID, int OrgAccountID, DateTime dt, int iHeaderID)
		{
			//
			// Required for Windows Form Designer support
			//
			bIsNew = true;
			this.bIsEdit = bIsEdit;
			this.iHeaderID = iHeaderID;
			this.iOrgAccountID = OrgAccountID;
			App.FillOrgsAccount();
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);
			App.SetDataGridTableStyle(this.dataGridTableStyle3);
			this.dvInnerOrgs.Table = App.DsOrgs.Orgs;
			this.dvInnerAccount.Table = App.DsOrgsAccount.OrgsAccounts;
			this.dvInnerOrgs.RowFilter = "IsInner=true";
			this.cmbInnerOrgs.DataSource = this.dvInnerOrgs;
			this.cmbInnerOrgs.DisplayMember = "OrgName";
			this.cmbInnerOrgs.ValueMember = "OrgID";			
			this.cmbInnerAccount.DataSource = this.dvInnerAccount;
			this.cmbInnerAccount.DisplayMember = "RAccount";
			this.cmbInnerAccount.ValueMember = "AccountID";
			this.fillDsUnlinkedPaymList();
			this.fillDsUnlinkedPaymInList();
			this.cmbInnerOrgs.SelectedValue = OrgID;
			this.cmbInnerOrgs.Enabled = false;
			//this.cmbInnerAccount.SelectedValue = OrgAccountID;
			this.cmbInnerAccount.Enabled = false;
			this.dtpExtractDate.Value = dt;
			this.dtpExtractDate.Enabled = false;
			
		}
		public AccountStatementEdit(bool bIsEdit, BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsHeadersRow rw, BPS.BLL.AccountStatements.dsAccountsStatementsList ds)
		{
			//
			// Required for Windows Form Designer support
			//
			bIsNew = false;
			this.bIsEdit = bIsEdit;
			this.iHeaderID = rw.HeaderID;
			App.FillOrgsAccount();
			InitializeComponent();
			 
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);
			App.SetDataGridTableStyle(this.dataGridTableStyle3);
			this.dvInnerOrgs.Table = App.DsOrgs.Orgs;
			this.dvInnerAccount.Table = App.DsOrgsAccount.OrgsAccounts;
			this.dvInnerOrgs.RowFilter = "IsInner=true";
			this.cmbInnerOrgs.DataSource = this.dvInnerOrgs;
			this.cmbInnerOrgs.DisplayMember = "OrgName";
			this.cmbInnerOrgs.ValueMember = "OrgID";			
			this.cmbInnerAccount.DataSource = this.dvInnerAccount;
			this.cmbInnerAccount.DisplayMember = "RAccount";
			this.cmbInnerAccount.ValueMember = "AccountID";
			if(bIsEdit)
			{
				this.iOrgAccountID				=rw.AccountID;
				this.rwHeader					=rw;
				this.dsPaymsList				=ds;
				this.dtpExtractDate.Value		=rw.HeaderDate;
				this.cmbInnerOrgs.SelectedValue =rw.OrgID;
				this.cmbInnerOrgs.Enabled		=false;
				this.tbSaldoStart.dValue		=rw.SaldoStart;
				this.tbSaldoEnd.dValue			=rw.SaldoEnd;
				
				this.tbRemarks.Text	=""; 
				if ( !rw.IsRemarksNull()) this.tbRemarks.Text =rw.Remarks; 

				this.convertToPaymListX();
			/*	if(rwHeader.Confirmed)
				{
					this.tbSaldoEnd.ReadOnly = true;
					this.tbSaldoStart.ReadOnly = true;
				}*/
			}
			this.m_bIsConfirmed =rw.Confirmed;

			this.fillDsUnlinkedPaymList();
            this.fillDsUnlinkedPaymInList();			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AccountStatementEdit));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.tbSaldoEnd = new AM_Controls.TextBoxV();
			this.tbSaldoStart = new AM_Controls.TextBoxV();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbInnerAccount = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbInnerOrgs = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpExtractDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.dvPaymsList = new System.Data.DataView();
			this.dsPaymentOrderListX1 = new BPS._Forms.dsPaymentOrderListX();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Direct = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentOrderSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Remarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dvInnerOrgs = new System.Data.DataView();
			this.dvInnerAccount = new System.Data.DataView();
			this.daPaymsList = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageOut = new System.Windows.Forms.TabPage();
			this.dataGridV2 = new AM_Controls.DataGridV();
			this.dvUnLinkedPaymList = new System.Data.DataView();
			this.dsUnlinkedPaymList1 = new BPS._Forms.dsUnlinkedPaymList();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.PaymentOrderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridTextBoxColumn();
			this.сPaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.сPaymentOrderSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgNameCorr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RAccountCorr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.сPaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.сRemarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabPageIn = new System.Windows.Forms.TabPage();
			this.dataGridV3 = new AM_Controls.DataGridV();
			this.dvUnlinkedPaymInList = new System.Data.DataView();
			this.dsUnlinkedPaymInList = new BPS._Forms.dsUnlinkedPaymList();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.ID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.DateIn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.No = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Sum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgCorr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RAccountCorrIn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Purp = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Rem = new System.Windows.Forms.DataGridTextBoxColumn();
			this.daGetUnlinkedPaymList = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.daUpdAccStatements = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.daUpdPaymentsOrders = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
			this.daGetUnlinkedPaymInList = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.cmdCheckPaym = new System.Data.SqlClient.SqlCommand();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPaymsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentOrderListX1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvInnerOrgs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvInnerAccount)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPageOut.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnLinkedPaymList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUnlinkedPaymList1)).BeginInit();
			this.tabPageIn.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnlinkedPaymInList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUnlinkedPaymInList)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbRemarks);
			this.groupBox1.Controls.Add(this.tbSaldoEnd);
			this.groupBox1.Controls.Add(this.tbSaldoStart);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cmbInnerAccount);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cmbInnerOrgs);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.dtpExtractDate);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(4, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(922, 62);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(220, 36);
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.Size = new System.Drawing.Size(485, 21);
			this.tbRemarks.TabIndex = 8;
			this.tbRemarks.Text = "";
			this.tbRemarks.Leave += new System.EventHandler(this.tbRemarks_Leave);
			// 
			// tbSaldoEnd
			// 
			this.tbSaldoEnd.AllowDrop = true;
			this.tbSaldoEnd.dValue = 0;
			this.tbSaldoEnd.IsPcnt = false;
			this.tbSaldoEnd.Location = new System.Drawing.Point(827, 36);
			this.tbSaldoEnd.MaxDecPos = 2;
			this.tbSaldoEnd.MaxPos = 10;
			this.tbSaldoEnd.Name = "tbSaldoEnd";
			this.tbSaldoEnd.Negative = System.Drawing.Color.Empty;
			this.tbSaldoEnd.nValue = ((long)(0));
			this.tbSaldoEnd.Positive = System.Drawing.Color.Empty;
			this.tbSaldoEnd.Size = new System.Drawing.Size(86, 21);
			this.tbSaldoEnd.TabIndex = 4;
			this.tbSaldoEnd.Text = "";
			this.tbSaldoEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSaldoEnd.TextMode = false;
			this.tbSaldoEnd.Zero = System.Drawing.Color.Empty;
			this.tbSaldoEnd.Leave += new System.EventHandler(this.tbSaldoEnd_Leave);
			// 
			// tbSaldoStart
			// 
			this.tbSaldoStart.AllowDrop = true;
			this.tbSaldoStart.dValue = 0;
			this.tbSaldoStart.IsPcnt = false;
			this.tbSaldoStart.Location = new System.Drawing.Point(827, 14);
			this.tbSaldoStart.MaxDecPos = 2;
			this.tbSaldoStart.MaxPos = 10;
			this.tbSaldoStart.Name = "tbSaldoStart";
			this.tbSaldoStart.Negative = System.Drawing.Color.Empty;
			this.tbSaldoStart.nValue = ((long)(0));
			this.tbSaldoStart.Positive = System.Drawing.Color.Empty;
			this.tbSaldoStart.Size = new System.Drawing.Size(86, 21);
			this.tbSaldoStart.TabIndex = 3;
			this.tbSaldoStart.Text = "";
			this.tbSaldoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSaldoStart.TextMode = false;
			this.tbSaldoStart.Zero = System.Drawing.Color.Empty;
			this.tbSaldoStart.Leave += new System.EventHandler(this.tbSaldoStart_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(711, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 18);
			this.label5.TabIndex = 7;
			this.label5.Text = "Исходящий остаток:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(711, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Входящий остаток:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbInnerAccount
			// 
			this.cmbInnerAccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbInnerAccount.Location = new System.Drawing.Point(505, 14);
			this.cmbInnerAccount.Name = "cmbInnerAccount";
			this.cmbInnerAccount.Size = new System.Drawing.Size(200, 21);
			this.cmbInnerAccount.TabIndex = 2;
			this.cmbInnerAccount.SelectedIndexChanged += new System.EventHandler(this.cmbInnerAccount_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(474, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Р/С:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbInnerOrgs
			// 
			this.cmbInnerOrgs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbInnerOrgs.Location = new System.Drawing.Point(220, 14);
			this.cmbInnerOrgs.Name = "cmbInnerOrgs";
			this.cmbInnerOrgs.Size = new System.Drawing.Size(248, 21);
			this.cmbInnerOrgs.TabIndex = 1;
			this.cmbInnerOrgs.SelectedIndexChanged += new System.EventHandler(this.cmbInnerOrgs_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(140, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Организация:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Дата:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpExtractDate
			// 
			this.dtpExtractDate.Enabled = false;
			this.dtpExtractDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpExtractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpExtractDate.Location = new System.Drawing.Point(47, 14);
			this.dtpExtractDate.Name = "dtpExtractDate";
			this.dtpExtractDate.Size = new System.Drawing.Size(84, 21);
			this.dtpExtractDate.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(140, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 18);
			this.label6.TabIndex = 2;
			this.label6.Text = "Комментарий:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1.CaptionVisible = false;
			this.dataGridV1.ContextMenu = this.contextMenu1;
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dvPaymsList;
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 0);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.ReadOnly = true;
			this.dataGridV1.Size = new System.Drawing.Size(930, 195);
			this.dataGridV1.TabIndex = 1;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			this.dataGridV1.DoubleClick += new System.EventHandler(this.dataGridV1_DoubleClick);
			// 
			// dvPaymsList
			// 
			this.dvPaymsList.Table = this.dsPaymentOrderListX1.AccountsStatements;
			// 
			// dsPaymentOrderListX1
			// 
			this.dsPaymentOrderListX1.DataSetName = "dsPaymentOrderListX";
			this.dsPaymentOrderListX1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridV1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.PaymentNo,
																												  this.Direct,
																												  this.PaymentOrderSum,
																												  this.OrgName,
																												  this.RAccount,
																												  this.PaymentOrderPurpose,
																												  this.Remarks});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "AccountsStatements";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "ID";
			this.dataGridTextBoxColumn1.MappingName = "AccountStatementID";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// PaymentNo
			// 
			this.PaymentNo.Format = "";
			this.PaymentNo.FormatInfo = null;
			this.PaymentNo.HeaderText = "Номер";
			this.PaymentNo.MappingName = "PaymentNo";
			this.PaymentNo.NullText = "-";
			this.PaymentNo.Width = 40;
			// 
			// Direct
			// 
			this.Direct.Format = "";
			this.Direct.FormatInfo = null;
			this.Direct.HeaderText = "Тип";
			this.Direct.MappingName = "Direct";
			this.Direct.NullText = "-";
			this.Direct.Width = 75;
			// 
			// PaymentOrderSum
			// 
			this.PaymentOrderSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.PaymentOrderSum.Format = "#,##0.00";
			this.PaymentOrderSum.FormatInfo = null;
			this.PaymentOrderSum.HeaderText = "Сумма";
			this.PaymentOrderSum.MappingName = "PaymentOrderSum";
			this.PaymentOrderSum.NullText = "-";
			this.PaymentOrderSum.Width = 75;
			// 
			// OrgName
			// 
			this.OrgName.Format = "";
			this.OrgName.FormatInfo = null;
			this.OrgName.HeaderText = "Организация";
			this.OrgName.MappingName = "OrgName";
			this.OrgName.NullText = "-";
			this.OrgName.Width = 75;
			// 
			// RAccount
			// 
			this.RAccount.Format = "";
			this.RAccount.FormatInfo = null;
			this.RAccount.HeaderText = "Р/счёт";
			this.RAccount.MappingName = "RAccount";
			this.RAccount.NullText = "-";
			this.RAccount.Width = 110;
			// 
			// PaymentOrderPurpose
			// 
			this.PaymentOrderPurpose.Format = "";
			this.PaymentOrderPurpose.FormatInfo = null;
			this.PaymentOrderPurpose.HeaderText = "Основание";
			this.PaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
			this.PaymentOrderPurpose.NullText = "-";
			this.PaymentOrderPurpose.Width = 250;
			// 
			// Remarks
			// 
			this.Remarks.Format = "";
			this.Remarks.FormatInfo = null;
			this.Remarks.HeaderText = "Примечание";
			this.Remarks.MappingName = "Remarks";
			this.Remarks.NullText = "-";
			this.Remarks.Width = 200;
			// 
			// daPaymsList
			// 
			this.daPaymsList.DeleteCommand = this.sqlDeleteCommand1;
			this.daPaymsList.InsertCommand = this.sqlInsertCommand1;
			this.daPaymsList.SelectCommand = this.sqlSelectCommand1;
			this.daPaymsList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "AccountsStatements", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID"),
																																																						new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																						new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																						new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
																																																						new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																						new System.Data.Common.DataColumnMapping("Remarks", "Remarks")})});
			this.daPaymsList.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "[AccountsStatementsDetails_Delete]";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountStatementID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountStatementID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HeaderID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountIDCorr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentNo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentNo", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderPurpose", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderSum", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Remarks", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Remarks", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "[AccountsStatementsDetails_Insert]";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, "HeaderID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, "OrgAccountIDCorr"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.Bit, 1, "Direction"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderSum", System.Data.SqlDbType.Float, 8, "PaymentOrderSum"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 50, "PaymentOrderPurpose"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 50, "Remarks"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[GetAccountsStatements]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "[AccountsStatementsDetails_Update]";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, "HeaderID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, "OrgAccountIDCorr"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.Bit, 1, "Direction"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderSum", System.Data.SqlDbType.Float, 8, "PaymentOrderSum"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 50, "PaymentOrderPurpose"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 50, "Remarks"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountStatementID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountStatementID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HeaderID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountIDCorr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentNo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentNo", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderPurpose", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderSum", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Remarks", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Remarks", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountStatementID", System.Data.SqlDbType.Int, 4, "AccountStatementID"));
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "Редактировать";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem2.Text = "Новая строка";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.menuItem3.Text = "Изменить";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.menuItem4.Text = "Удалить";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(4, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(134, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Убрать из выписки";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(140, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Добавить в выписку";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageOut);
			this.tabControl1.Controls.Add(this.tabPageIn);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(930, 214);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageOut
			// 
			this.tabPageOut.Controls.Add(this.dataGridV2);
			this.tabPageOut.Location = new System.Drawing.Point(4, 22);
			this.tabPageOut.Name = "tabPageOut";
			this.tabPageOut.Size = new System.Drawing.Size(922, 188);
			this.tabPageOut.TabIndex = 0;
			this.tabPageOut.Text = "Расход";
			// 
			// dataGridV2
			// 
			this.dataGridV2._CanEdit = false;
			this.dataGridV2._InvisibleColumn = 0;
			this.dataGridV2.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGridV2.CaptionForeColor = System.Drawing.SystemColors.WindowText;
			this.dataGridV2.CaptionText = "Несвязанные платежи по выплатам";
			this.dataGridV2.DataMember = "";
			this.dataGridV2.DataSource = this.dvUnLinkedPaymList;
			this.dataGridV2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV2.Location = new System.Drawing.Point(0, 0);
			this.dataGridV2.Name = "dataGridV2";
			this.dataGridV2.ReadOnly = true;
			this.dataGridV2.Size = new System.Drawing.Size(922, 188);
			this.dataGridV2.TabIndex = 1;
			this.dataGridV2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle2});
			this.dataGridV2.DoubleClick += new System.EventHandler(this.dataGridV2_DoubleClick);
			// 
			// dvUnLinkedPaymList
			// 
			this.dvUnLinkedPaymList.Table = this.dsUnlinkedPaymList1.GetUnlinkedPaymList;
			// 
			// dsUnlinkedPaymList1
			// 
			this.dsUnlinkedPaymList1.DataSetName = "dsUnlinkedPaymList";
			this.dsUnlinkedPaymList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGridV2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.PaymentOrderID,
																												  this.Date,
																												  this.сPaymentNo,
																												  this.сPaymentOrderSum,
																												  this.OrgNameCorr,
																												  this.RAccountCorr,
																												  this.сPaymentOrderPurpose,
																												  this.сRemarks});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "GetUnlinkedPaymList";
			// 
			// PaymentOrderID
			// 
			this.PaymentOrderID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.PaymentOrderID.Format = "";
			this.PaymentOrderID.FormatInfo = null;
			this.PaymentOrderID.HeaderText = "ID";
			this.PaymentOrderID.MappingName = "PaymentOrderID";
			this.PaymentOrderID.NullText = "-";
			this.PaymentOrderID.Width = 30;
			// 
			// Date
			// 
			this.Date.Format = "dd/MM/yy";
			this.Date.FormatInfo = null;
			this.Date.HeaderText = "Дата";
			this.Date.MappingName = "PaymentOrderDate";
			this.Date.NullText = "-";
			this.Date.Width = 50;
			// 
			// сPaymentNo
			// 
			this.сPaymentNo.Format = "";
			this.сPaymentNo.FormatInfo = null;
			this.сPaymentNo.HeaderText = "Номер";
			this.сPaymentNo.MappingName = "PaymentNo";
			this.сPaymentNo.NullText = "-";
			this.сPaymentNo.Width = 50;
			// 
			// сPaymentOrderSum
			// 
			this.сPaymentOrderSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.сPaymentOrderSum.Format = "#,##0.00";
			this.сPaymentOrderSum.FormatInfo = null;
			this.сPaymentOrderSum.HeaderText = "Сумма";
			this.сPaymentOrderSum.MappingName = "PaymentOrderSum";
			this.сPaymentOrderSum.NullText = "-";
			this.сPaymentOrderSum.Width = 75;
			// 
			// OrgNameCorr
			// 
			this.OrgNameCorr.Format = "";
			this.OrgNameCorr.FormatInfo = null;
			this.OrgNameCorr.HeaderText = "Организация";
			this.OrgNameCorr.MappingName = "OrgNameCorr";
			this.OrgNameCorr.NullText = "-";
			this.OrgNameCorr.Width = 120;
			// 
			// RAccountCorr
			// 
			this.RAccountCorr.Format = "";
			this.RAccountCorr.FormatInfo = null;
			this.RAccountCorr.HeaderText = "Р. счёт";
			this.RAccountCorr.MappingName = "RAccountCorr";
			this.RAccountCorr.NullText = "-";
			this.RAccountCorr.Width = 90;
			// 
			// сPaymentOrderPurpose
			// 
			this.сPaymentOrderPurpose.Format = "";
			this.сPaymentOrderPurpose.FormatInfo = null;
			this.сPaymentOrderPurpose.HeaderText = "Основание";
			this.сPaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
			this.сPaymentOrderPurpose.NullText = "-";
			this.сPaymentOrderPurpose.Width = 220;
			// 
			// сRemarks
			// 
			this.сRemarks.Format = "";
			this.сRemarks.FormatInfo = null;
			this.сRemarks.HeaderText = "Примечание";
			this.сRemarks.MappingName = "Remarks";
			this.сRemarks.NullText = "-";
			this.сRemarks.Width = 220;
			// 
			// tabPageIn
			// 
			this.tabPageIn.Controls.Add(this.dataGridV3);
			this.tabPageIn.Location = new System.Drawing.Point(4, 22);
			this.tabPageIn.Name = "tabPageIn";
			this.tabPageIn.Size = new System.Drawing.Size(922, 188);
			this.tabPageIn.TabIndex = 1;
			this.tabPageIn.Text = "Приход";
			// 
			// dataGridV3
			// 
			this.dataGridV3._CanEdit = false;
			this.dataGridV3._InvisibleColumn = 0;
			this.dataGridV3.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGridV3.CaptionForeColor = System.Drawing.SystemColors.WindowText;
			this.dataGridV3.CaptionText = "Несвязанные платежи по поступлению ( внутреннее перемещение средств)";
			this.dataGridV3.DataMember = "";
			this.dataGridV3.DataSource = this.dvUnlinkedPaymInList;
			this.dataGridV3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV3.Location = new System.Drawing.Point(0, 0);
			this.dataGridV3.Name = "dataGridV3";
			this.dataGridV3.ReadOnly = true;
			this.dataGridV3.Size = new System.Drawing.Size(922, 188);
			this.dataGridV3.TabIndex = 0;
			this.dataGridV3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle3});
			// 
			// dvUnlinkedPaymInList
			// 
			this.dvUnlinkedPaymInList.Table = this.dsUnlinkedPaymInList.GetUnlinkedPaymList;
			// 
			// dsUnlinkedPaymInList
			// 
			this.dsUnlinkedPaymInList.DataSetName = "dsUnlinkedPaymList";
			this.dsUnlinkedPaymInList.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.DataGrid = this.dataGridV3;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ID,
																												  this.DateIn,
																												  this.No,
																												  this.Sum,
																												  this.OrgCorr,
																												  this.RAccountCorrIn,
																												  this.Purp,
																												  this.Rem});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "GetUnlinkedPaymList";
			// 
			// ID
			// 
			this.ID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ID.Format = "";
			this.ID.FormatInfo = null;
			this.ID.HeaderText = "ID";
			this.ID.MappingName = "PaymentOrderID";
			this.ID.NullText = "-";
			this.ID.Width = 30;
			// 
			// DateIn
			// 
			this.DateIn.Format = "";
			this.DateIn.FormatInfo = null;
			this.DateIn.HeaderText = "Дата";
			this.DateIn.MappingName = "PaymentOrderDate";
			this.DateIn.NullText = "-";
			this.DateIn.Width = 50;
			// 
			// No
			// 
			this.No.Format = "";
			this.No.FormatInfo = null;
			this.No.HeaderText = "Номер";
			this.No.MappingName = "PaymentNo";
			this.No.NullText = "-";
			this.No.Width = 50;
			// 
			// Sum
			// 
			this.Sum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.Sum.Format = "#,##0.00";
			this.Sum.FormatInfo = null;
			this.Sum.HeaderText = "Сумма";
			this.Sum.MappingName = "PaymentOrderSum";
			this.Sum.NullText = "-";
			this.Sum.Width = 75;
			// 
			// OrgCorr
			// 
			this.OrgCorr.Format = "";
			this.OrgCorr.FormatInfo = null;
			this.OrgCorr.HeaderText = "Организация";
			this.OrgCorr.MappingName = "OrgNameCorr";
			this.OrgCorr.NullText = "-";
			this.OrgCorr.Width = 120;
			// 
			// RAccountCorrIn
			// 
			this.RAccountCorrIn.Format = "";
			this.RAccountCorrIn.FormatInfo = null;
			this.RAccountCorrIn.HeaderText = "Р. счёт";
			this.RAccountCorrIn.MappingName = "RAccountCorr";
			this.RAccountCorrIn.NullText = "-";
			this.RAccountCorrIn.Width = 90;
			// 
			// Purp
			// 
			this.Purp.Format = "";
			this.Purp.FormatInfo = null;
			this.Purp.HeaderText = "Основание";
			this.Purp.MappingName = "PaymentOrderPurpose";
			this.Purp.NullText = "-";
			this.Purp.Width = 220;
			// 
			// Rem
			// 
			this.Rem.Format = "";
			this.Rem.FormatInfo = null;
			this.Rem.HeaderText = "Примечание";
			this.Rem.MappingName = "Remarks";
			this.Rem.NullText = "-";
			this.Rem.Width = 220;
			// 
			// daGetUnlinkedPaymList
			// 
			this.daGetUnlinkedPaymList.SelectCommand = this.sqlSelectCommand2;
			this.daGetUnlinkedPaymList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "GetUnlinkedPaymList", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("RAccountCorr", "RAccountCorr"),
																																																								   new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																								   new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																								   new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																								   new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																								   new System.Data.Common.DataColumnMapping("PaymentOrderStatusID", "PaymentOrderStatusID"),
																																																								   new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																								   new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																								   new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																								   new System.Data.Common.DataColumnMapping("OrgAccountID", "OrgAccountID"),
																																																								   new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
																																																								   new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																								   new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																								   new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																								   new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																								   new System.Data.Common.DataColumnMapping("IsPrinted", "IsPrinted"),
																																																								   new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID"),
																																																								   new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID"),
																																																								   new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																								   new System.Data.Common.DataColumnMapping("Expr3", "Expr3"),
																																																								   new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																								   new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																								   new System.Data.Common.DataColumnMapping("AccountIDCorr", "AccountIDCorr"),
																																																								   new System.Data.Common.DataColumnMapping("CurrencyIDCorr", "CurrencyIDCorr")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[GetUnlinkedPaymList]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// daUpdAccStatements
			// 
			this.daUpdAccStatements.DeleteCommand = this.sqlDeleteCommand2;
			this.daUpdAccStatements.InsertCommand = this.sqlInsertCommand2;
			this.daUpdAccStatements.SelectCommand = this.sqlSelectCommand3;
			this.daUpdAccStatements.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "AccountsStatements", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID"),
																																																							   new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																							   new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							   new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							   new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
																																																							   new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																							   new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																							   new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																							   new System.Data.Common.DataColumnMapping("Remarks", "Remarks")})});
			this.daUpdAccStatements.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "[AccountsStatementsDeleteCommand]";
			this.sqlDeleteCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountStatementID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountStatementID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HeaderID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountIDCorr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentNo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentNo", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderPurpose", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderSum", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Remarks", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Remarks", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "[AccountsStatementsInsertCommand]";
			this.sqlInsertCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, "HeaderID"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, "OrgAccountIDCorr"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.Bit, 1, "Direction"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderSum", System.Data.SqlDbType.Float, 8, "PaymentOrderSum"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, "PaymentOrderPurpose"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 50, "Remarks"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[AccountsStatementsSelectCommand]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "[AccountsStatementsUpdateCommand]";
			this.sqlUpdateCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, "HeaderID"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, "OrgAccountIDCorr"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.Bit, 1, "Direction"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderSum", System.Data.SqlDbType.Float, 8, "PaymentOrderSum"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, "PaymentOrderPurpose"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 50, "Remarks"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountStatementID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountStatementID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HeaderID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountIDCorr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentNo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentNo", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderPurpose", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderSum", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Remarks", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Remarks", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountStatementID", System.Data.SqlDbType.Int, 4, "AccountStatementID"));
			// 
			// daUpdPaymentsOrders
			// 
			this.daUpdPaymentsOrders.DeleteCommand = this.sqlDeleteCommand3;
			this.daUpdPaymentsOrders.InsertCommand = this.sqlInsertCommand3;
			this.daUpdPaymentsOrders.SelectCommand = this.sqlSelectCommand4;
			this.daUpdPaymentsOrders.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "PaymentsOrders", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderStatusID", "PaymentOrderStatusID"),
																																																							new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("OrgAccountID", "OrgAccountID"),
																																																							new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																							new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																							new System.Data.Common.DataColumnMapping("IsPrinted", "IsPrinted"),
																																																							new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID")})});
			this.daUpdPaymentsOrders.UpdateCommand = this.sqlUpdateCommand3;
			// 
			// sqlDeleteCommand3
			// 
			this.sqlDeleteCommand3.CommandText = "[PaymentsOrdersDeleteCommand]";
			this.sqlDeleteCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand3.Connection = this.sqlConnection1;
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountStatementID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountStatementID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HeaderID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsPrinted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsPrinted", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountIDCorr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentNo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentNo", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderPurpose", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderStatusID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderSum", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Remarks", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Remarks", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "[PaymentsOrdersInsertCommand]";
			this.sqlInsertCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand3.Connection = this.sqlConnection1;
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderStatusID", System.Data.SqlDbType.Int, 4, "PaymentOrderStatusID"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, "HeaderID"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4, "OrgAccountID"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, "OrgAccountIDCorr"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.Bit, 1, "Direction"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderSum", System.Data.SqlDbType.Float, 8, "PaymentOrderSum"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, "PaymentOrderPurpose"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 50, "Remarks"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsPrinted", System.Data.SqlDbType.Bit, 1, "IsPrinted"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountStatementID", System.Data.SqlDbType.Int, 4, "AccountStatementID"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "[PaymentsOrdersSelectCommand]";
			this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand3
			// 
			this.sqlUpdateCommand3.CommandText = "[PaymentsOrdersUpdateCommand]";
			this.sqlUpdateCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand3.Connection = this.sqlConnection1;
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderStatusID", System.Data.SqlDbType.Int, 4, "PaymentOrderStatusID"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, "HeaderID"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4, "OrgAccountID"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, "OrgAccountIDCorr"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.Bit, 1, "Direction"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderSum", System.Data.SqlDbType.Float, 8, "PaymentOrderSum"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, "PaymentOrderPurpose"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256, "Remarks"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsPrinted", System.Data.SqlDbType.Bit, 1, "IsPrinted"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountStatementID", System.Data.SqlDbType.Int, 4, "AccountStatementID"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountStatementID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountStatementID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "HeaderID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsPrinted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsPrinted", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgAccountIDCorr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgAccountIDCorr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentNo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentNo", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderPurpose", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderStatusID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PaymentOrderSum", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Remarks", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Remarks", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderID", System.Data.SqlDbType.Int, 4, "PaymentOrderID"));
			// 
			// daGetUnlinkedPaymInList
			// 
			this.daGetUnlinkedPaymInList.SelectCommand = this.sqlSelectCommand5;
			this.daGetUnlinkedPaymInList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "GetUnlinkedPaymInList", new System.Data.Common.DataColumnMapping[] {
																																																									   new System.Data.Common.DataColumnMapping("RAccountCorr", "RAccountCorr"),
																																																									   new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																									   new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																									   new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																									   new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																									   new System.Data.Common.DataColumnMapping("PaymentOrderStatusID", "PaymentOrderStatusID"),
																																																									   new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																									   new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																									   new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																									   new System.Data.Common.DataColumnMapping("OrgAccountID", "OrgAccountID"),
																																																									   new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
																																																									   new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																									   new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																									   new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																									   new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																									   new System.Data.Common.DataColumnMapping("IsPrinted", "IsPrinted"),
																																																									   new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID"),
																																																									   new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID"),
																																																									   new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																									   new System.Data.Common.DataColumnMapping("Expr3", "Expr3"),
																																																									   new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																									   new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																									   new System.Data.Common.DataColumnMapping("AccountIDCorr", "AccountIDCorr"),
																																																									   new System.Data.Common.DataColumnMapping("CurrencyIDCorr", "CurrencyIDCorr")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "[GetUnlinkedPaymInList]";
			this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdCheckPaym
			// 
			this.cmdCheckPaym.CommandText = "SELECT AccountStatementID FROM PaymentsOrders WHERE (PaymentOrderID = @PaymID)";
			this.cmdCheckPaym.Connection = this.sqlConnection1;
			this.cmdCheckPaym.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymID", System.Data.SqlDbType.Int, 4, "PaymentOrderID"));
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton4});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(930, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 0;
			this.toolBarButton1.Text = "Новая строка";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 1;
			this.toolBarButton2.Text = "Изменить";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 2;
			this.toolBarButton4.Text = "Удалить";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.toolBar1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(930, 320);
			this.panel1.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.dataGridV1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 95);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(930, 195);
			this.panel5.TabIndex = 4;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 290);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(930, 30);
			this.panel4.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.groupBox1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 28);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(930, 67);
			this.panel3.TabIndex = 2;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 320);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(930, 5);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 325);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(930, 214);
			this.panel2.TabIndex = 2;
			// 
			// AccountStatementEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(930, 539);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "AccountStatementEdit";
			this.Text = "Выписка";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.AccountStatementEdit_Closing);
			this.Load += new System.EventHandler(this.PaymentsExtraction_Load);
			this.Closed += new System.EventHandler(this.AccountStatementEdit_Closed);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPaymsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentOrderListX1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvInnerOrgs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvInnerAccount)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPageOut.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnLinkedPaymList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUnlinkedPaymList1)).EndInit();
			this.tabPageIn.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnlinkedPaymInList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUnlinkedPaymInList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void fillDsUnlinkedPaymList()
		{
			try
			{
				this.dsUnlinkedPaymList1.Clear();
				this.daGetUnlinkedPaymList.Fill(this.dsUnlinkedPaymList1.GetUnlinkedPaymList);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void fillDsUnlinkedPaymInList()
		{
			try
			{
				this.dsUnlinkedPaymInList.Clear();
				this.daGetUnlinkedPaymInList.Fill(this.dsUnlinkedPaymInList.GetUnlinkedPaymList);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void updateAccountStatements()
		{
			try
			{
				this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void updatePaymentsOrders()
		{
			try
			{
				this.daUpdPaymentsOrders.Update(this.dsUnlinkedPaymList1.GetUnlinkedPaymList);
				if(this.dvUnLinkedPaymList.Count>0)
				{
					string s = dvUnLinkedPaymList.RowFilter;
					dvUnLinkedPaymList.RowFilter = "";
					dvUnLinkedPaymList.RowFilter = s;
					this.BindingContext[this.dvUnLinkedPaymList].Position=0;
				}
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void updatePaymentsOrders(DataTable dt, DataView dv)
		{
			try
			{
				this.daUpdPaymentsOrders.Update(dt);
				if(dv.Count >0)
				{
					string s = dv.RowFilter;
					dv.RowFilter = "";
					dv.RowFilter = s;
					this.BindingContext[dv].Position = 0;
				}
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void PaymentsExtraction_Load(object sender, System.EventArgs e)
		{
			App.Clone(this.menuItem1.MenuItems, this.contextMenu1);
			this.bIsLoaded = true;
			this.selectInnerAccount();
			if(this.bIsEdit)
			{
				this.cmbInnerAccount.SelectedValue = this.iOrgAccountID;//rwHeader.AccountID;
			}
			this.cmbInnerAccount.Enabled = false;
			this.dvUnLinkedPaymList.RowFilter = "AccountStatementID IS Null and OrgAccountID=" + this.dvInnerAccount[this.cmbInnerAccount.SelectedIndex]["OrgsAccountsID"].ToString();
			this.dvUnlinkedPaymInList.RowFilter = "AccountStatementID IS Null and OrgAccountID=" + this.dvInnerAccount[this.cmbInnerAccount.SelectedIndex]["OrgsAccountsID"].ToString();
		}
		private void convertToPaymListX()
		{
			DataRow [] dr = this.dsPaymsList.AccountsStatements.Select("HeaderID=" + this.rwHeader.HeaderID.ToString());
			for(int i=0; i<dr.Length; i++)
			{
				BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsRow accRow = (BPS.BLL.AccountStatements.dsAccountsStatementsList.AccountsStatementsRow) dr[i];
				BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwList = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList.Table.NewRow();
				rwList.CurrencyID = rwHeader.CurrencyID;//accRow.CurrencyID;
				rwList.OrgName = accRow.OrgName;
				rwList.RAccount = accRow.RAccount;
				rwList.AccountID = accRow.AccountID;
				rwList.OrgID = accRow.OrgID;
				rwList.AccountStatementID = accRow.AccountStatementID;
				rwList.HeaderID = accRow.HeaderID;
				rwList.PaymentOrderDate = accRow.PaymentOrderDate;
				rwList.PaymentNo = accRow.PaymentNo;
				rwList.OrgAccountIDCorr = accRow.OrgAccountIDCorr;
				rwList.Direction = accRow.Direction;
				rwList.PaymentOrderSum = accRow.PaymentOrderSum;
				if(!accRow.IsPaymentOrderPurposeNull())
					rwList.PaymentOrderPurpose = accRow.PaymentOrderPurpose;
				if(!accRow.IsRemarksNull())
					rwList.Remarks = accRow.Remarks;
				if(accRow.Direction)
					rwList.Direct = "Приход";
				else
					rwList.Direct = "Расход";
				this.dvPaymsList.Table.Rows.Add((DataRow) rwList);
			}
			this.dsPaymentOrderListX1.AcceptChanges();
		}
		private void cmbInnerOrgs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.selectInnerAccount();
		}
		private void selectInnerAccount()
		{
			if(this.bIsLoaded)
			{
				if(this.dvInnerOrgs.Count>0)
				{
					this.dvInnerAccount.RowFilter = "OrgID=" + this.cmbInnerOrgs.SelectedValue.ToString();
					if(this.dvInnerAccount.Count==0)
						this.cmbInnerAccount.Text = "";
				}
			}
		}
		private void editPaym()
		{
			if(this.checkHeader(this.iHeaderID))
				return;
			//Редактирование
			if(this.dvPaymsList.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvPaymsList];
				BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow)((DataRowView)bm.Current).Row;
				bool isInPaym = false;
				if(rw.Direction)
				{
					DataRow [] dr = this.dvUnlinkedPaymInList.Table.Select("AccountStatementID=" + rw.AccountStatementID.ToString());
					if(dr.Length != 0)
						isInPaym = true;										
				}
				AccountStatementPaymentEdit ap = new AccountStatementPaymentEdit(rw, false, isInPaym);
				ap.Text += " [Редактирование]";
				ap.DsPaymsList = this.dsPaymentOrderListX1;
				ap.Currency = rw.CurrencyID;

				if ( this.cmbInnerOrgs.SelectedIndex >=0)
					ap.OwnerOrgID =(int)this.cmbInnerOrgs.SelectedValue; 
			
				if ( this.cmbInnerAccount.SelectedIndex >=0)
					ap.OwnerOrgAccountID =(int)this.dvInnerAccount[this.cmbInnerAccount.SelectedIndex]["OrgsAccountsID"];

				ap.ShowDialog();
				if(ap.DialogResult == DialogResult.OK)
				{
					this.updateAccountStatements();
				}
			}
		}
		private void delPaym()
		{
			if(this.checkHeader(this.iHeaderID))
				return;
			if(this.dvPaymsList.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvPaymsList];
				BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow)((DataRowView)bm.Current).Row;
				if(rw.Direction)
				{
					DataRow [] dr = this.dvUnlinkedPaymInList.Table.Select("AccountStatementID=" + rw.AccountStatementID.ToString());
					if(dr.Length != 0)
					{						
						AM_Controls.MsgBoxX.Show("Для удаления п/п по внутреннему перемещению средств воспользуйтесь кнопкой 'Убрать из выписки'", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					if(AM_Controls.MsgBoxX.Show("Удалить п/п №" + rw.PaymentNo + "?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						((DataRowView)bm.Current).Delete();
						this.updateAccountStatements();
					}
				}
				else
				{
					DataRow [] dr = this.dvUnLinkedPaymList.Table.Select("AccountStatementID=" + rw.AccountStatementID.ToString());
					if(dr.Length != 0)
					{						
						AM_Controls.MsgBoxX.Show("Для удаления п/п по выплате воспользуйтесь кнопкой 'Убрать из выписки'", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					if(AM_Controls.MsgBoxX.Show("Удалить п/п №" + rw.PaymentNo + "?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						((DataRowView)bm.Current).Delete();
						this.updateAccountStatements();
					}
				}
			}
		}
		private void addPaym()
		{
			if(this.checkHeader(this.iHeaderID))
				return;
			//Добавить п/п
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvInnerAccount];
			BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow rw = (BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwPaym = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList.Table.NewRow();
			
			AccountStatementPaymentEdit ap = new AccountStatementPaymentEdit(rwPaym, true, false);
			ap.Text += " [Новое]";
			ap.DsPaymsList = this.dsPaymentOrderListX1;
			ap.Currency = rw.CurrencyID;
			
			if ( this.cmbInnerOrgs.SelectedIndex >=0)
				ap.OwnerOrgID =(int)this.cmbInnerOrgs.SelectedValue; 
			
			if ( this.cmbInnerAccount.SelectedIndex >=0)
				ap.OwnerOrgAccountID =(int)this.dvInnerAccount[this.cmbInnerAccount.SelectedIndex]["OrgsAccountsID"];

			ap.ShowDialog();
			
			if(ap.DialogResult == DialogResult.OK)
			{
					rwPaym.HeaderID = this.iHeaderID;
					this.dvPaymsList.Table.Rows.Add((DataRow) rwPaym);
					this.updateAccountStatements();
			}
		}
		private void bnMemory_Click(object sender, System.EventArgs e)
		{
			//Проверка и запись выписки
			if(!this.validatePaymExtract())
				return;
			double dCheckSum = this.tbSaldoStart.dValue;
			for(int i=0; i<this.dvPaymsList.Count; i++)
			{
				BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList[i].Row;
				if(!rw.Direction)
					dCheckSum -= rw.PaymentOrderSum;
				else
					dCheckSum += rw.PaymentOrderSum;
			}
			if(this.tbSaldoEnd.dValue != Math.Round(dCheckSum,2))
			{
				AM_Controls.MsgBoxX.Show("Не сходятся суммы п/п и исходящий остаток! Проверьте правильность введённых данных.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if(!this.bIsEdit)
				this.newStatements();
			else this.editStatements();
		}
		private void editStatements()
		{
			System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
			nfi.NumberDecimalSeparator = ".";
			
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvInnerAccount];
			BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow rwOrg = (BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			
			SqlCommand cmdUpdHeader = new SqlCommand("UPDATE AccountsStatementsHeaders SET OrgAccountID=" + rwOrg.OrgsAccountsID + ", HeaderDate=@HeaderDate, SaldoStart=" + this.tbSaldoStart.dValue.ToString(nfi) + ", SaldoEnd=" + this.tbSaldoEnd.dValue.ToString(nfi) + ", Remarks =@szRemarks WHERE HeaderID=" + this.rwHeader.HeaderID, App.Connection);
			cmdUpdHeader.Parameters.Add(new SqlParameter("@Headerdate", SqlDbType.DateTime));
			cmdUpdHeader.Parameters["@Headerdate"].Value = this.dtpExtractDate.Value.Date;
			cmdUpdHeader.Parameters.Add(new SqlParameter("@szRemarks", SqlDbType.NVarChar));
			if (this.tbRemarks.Text.Length >0) 
			{
				cmdUpdHeader.Parameters["@szRemarks"].Value =this.tbRemarks.Text.Substring(0, 255);
			}
			else 
			{
				cmdUpdHeader.Parameters["@szRemarks"].Value =System.DBNull.Value;
			}
			this.daPaymsList.UpdateCommand.Connection = App.Connection;
			App.Connection.Open();
			
			SqlTransaction tr = App.Connection.BeginTransaction();
			cmdUpdHeader.Transaction = this.daPaymsList.UpdateCommand.Transaction = tr;
			try
			{
				cmdUpdHeader.ExecuteNonQuery();
				this.daPaymsList.Update(this.dsPaymentOrderListX1.AccountsStatements);
				tr.Commit();
				this.Memorize();
				//this.bnMemory.Enabled = false;
				this.toolBar1.Enabled = false;
			}
			catch(Exception ex)
			{
				tr.Rollback();
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			finally
			{
				if(App.Connection.State == ConnectionState.Open)
					App.Connection.Close();
			}
		}
		private void newStatements()
		{
			System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
			nfi.NumberDecimalSeparator = ".";
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvInnerAccount];
			BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow rwOrg = (BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			SqlCommand cmdCheckHeader = new SqlCommand("SELECT COUNT(HeaderID) FROM AccountsStatementsHeaders WHERE OrgAccountID=@OrgAccount AND HeaderDate=@Headerdate", App.Connection);
			cmdCheckHeader.Parameters.Add(new SqlParameter("@OrgAccount", SqlDbType.Int));
			cmdCheckHeader.Parameters.Add(new SqlParameter("@Headerdate", SqlDbType.DateTime));
			cmdCheckHeader.Parameters["@OrgAccount"].Value = rwOrg.OrgsAccountsID;
			cmdCheckHeader.Parameters["@Headerdate"].Value = this.dtpExtractDate.Value.Date;
			SqlCommand cmdInsHeader = new SqlCommand("INSERT INTO AccountsStatementsHeaders (OrgAccountID, HeaderDate, SaldoStart, SaldoEnd) " +
				"VALUES (" + rwOrg.OrgsAccountsID + ",@HeaderDate," + this.tbSaldoStart.dValue.ToString(nfi) + "," + this.tbSaldoEnd.dValue.ToString(nfi) + "@szRemarks)", App.Connection);
			cmdInsHeader.Parameters.Add(new SqlParameter("@Headerdate", SqlDbType.DateTime));
			cmdInsHeader.Parameters.Add(new SqlParameter("@szRemarks", SqlDbType.NVarChar));
			cmdInsHeader.Parameters["@Headerdate"].Value = this.dtpExtractDate.Value.Date;
			if (this.tbRemarks.Text.Length >0) 
			{
				cmdInsHeader.Parameters["@szRemarks"].Value =this.tbRemarks.Text.Substring(0, 255);
			}
			else 
			{
				cmdInsHeader.Parameters["@szRemarks"].Value =System.DBNull.Value;
			}
			SqlCommand cmdGetHeaderID = new SqlCommand("SELECT @@IDENTITY", App.Connection);
			this.daPaymsList.InsertCommand.Connection = App.Connection;
			App.Connection.Open();
			SqlTransaction tr = App.Connection.BeginTransaction();
			cmdCheckHeader.Transaction = cmdInsHeader.Transaction = cmdGetHeaderID.Transaction = 
				this.daPaymsList.InsertCommand.Transaction = tr;
			try
			{
				
				object o = cmdCheckHeader.ExecuteScalar();
				if(o != Convert.DBNull)
				{
					if(Convert.ToInt32(o) > 0)
					{
						tr.Rollback();
						AM_Controls.MsgBoxX.Show("Выписка на дату " + this.dtpExtractDate.Value.Date.ToString() + " по счёту " + this.cmbInnerAccount.Text + " уже существует.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);						
						return;
					}
					else 
					{
						cmdInsHeader.ExecuteNonQuery();
						o = cmdGetHeaderID.ExecuteScalar();
						if(o!= Convert.DBNull)
						{
							for(int i=0; i<this.dvPaymsList.Count; i++)
							{
								BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList[i].Row;
								rw.HeaderID = Convert.ToInt32(o);					
							}
							this.daPaymsList.Update(this.dsPaymentOrderListX1.AccountsStatements);
						}
						else
						{
							tr.Rollback();
							AM_Controls.MsgBoxX.Show(" ", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
					}
				}
				else
				{
					tr.Rollback();
					return;
				}
				tr.Commit();
				this.Memorize();
				//this.bnMemory.Enabled = false;
				this.toolBar1.Enabled = false;
			}
			catch(Exception ex)
			{
				tr.Rollback();
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			finally
			{
				if(App.Connection.State == ConnectionState.Open)
					App.Connection.Close();
			}
		}
		private bool validatePaymExtract()
		{
			if(this.cmbInnerOrgs.SelectedIndex == -1)
			{
				AM_Controls.MsgBoxX.Show("Правильно выберите ОРГАНИЗАЦИЮ", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.cmbInnerOrgs.Focus();
				return false;
			}
			if(this.cmbInnerAccount.SelectedIndex == -1)
			{
				AM_Controls.MsgBoxX.Show("Правильно выберите Р/СЧЁТ", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.cmbInnerAccount.Focus();
				return false;
			}
			if(this.tbSaldoStart.dValue == 0)
			{
				AM_Controls.MsgBoxX.Show("Правильно заполните ВХОДЯЩИЙ ОСТАТОК", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbSaldoStart.Focus();
				return false;
			}
			if(this.tbSaldoEnd.dValue == 0)
			{
				AM_Controls.MsgBoxX.Show("Правильно заполните ИСХОДЯЩИЙ ОСТАТОК", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbSaldoEnd.Focus();
				return false;
			}
			else return true;
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Memorize();
			this.Close();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (this.toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					if(!this.bIsNew && rwHeader.Confirmed)
						addConfirmedPaym();
					else
						addPaym();
					break;
				case 1:	
					if(!this.bIsNew && !rwHeader.Confirmed)
						editPaym();
					else if(this.bIsNew && !rwHeader.Confirmed)
						editPaym();
					else
						AM_Controls.MsgBoxX.Show("Невозможно изменить платёж. Выписка принята.","BPS",MessageBoxButtons.OK,MessageBoxIcon.Information);
					break;
				case 2:
					if(!this.bIsNew && this.checkHeader(this.iHeaderID))
					{
						int iTransTypeID = this.checkInnerPaymInConfirmedHeader();
						if((iTransTypeID == 1) || ((iTransTypeID == 10)))
							delConfirmedPaym();
						else if(iTransTypeID == 0)
						{
							AM_Controls.MsgBoxX.Show("Во время удаления п/п произошла ошибка. Повторите попытку позже.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
							
						}
						else
						{
							AM_Controls.MsgBoxX.Show("Для удаления п/п по внутреннему перемещению средств воспользуйтесь кнопкой 'Убрать из выписки'", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
							
						}
					}
					else
						delPaym();
					break;
			}
		}
		private int checkInnerPaymInConfirmedHeader()
		{
			if(this.dvPaymsList.Count == 0)
				return 0;
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvPaymsList];
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow)((DataRowView)bm.Current).Row;
			SqlCommand cmdCheckPaym = new SqlCommand("[checkInnerPaymInConfirmedHeader]", App.Connection);
			cmdCheckPaym.CommandType = CommandType.StoredProcedure;
			cmdCheckPaym.Parameters.Add(new SqlParameter("@AccountStatementID", SqlDbType.Int));
			cmdCheckPaym.Parameters.Add(new SqlParameter("@TransactionTypeID", SqlDbType.Int));
			cmdCheckPaym.Parameters["@TransactionTypeID"].Direction = ParameterDirection.Output;
			cmdCheckPaym.Parameters["@AccountStatementID"].Value = rw.AccountStatementID;
			try
			{
				App.Connection.Open();
				cmdCheckPaym.ExecuteNonQuery();
				object o = cmdCheckPaym.Parameters["@TransactionTypeID"].Value;
				if(o == Convert.DBNull)
					return 0;
				else return (int) o;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
			finally
			{
				App.Connection.Close();
			}
			return 0;
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
	/*	private void addConfirmedPaym1()
		{
			//Добавить п/п в принятую выписку
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvInnerAccount];
			BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow rw = (BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwPaym = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList.Table.NewRow();
			AccountStatementPaymentEdit ap = new AccountStatementPaymentEdit(rwPaym, true, false);
			ap.Text += " [Новый]";
			ap.DsPaymsList = this.dsPaymentOrderListX1;
			ap.Currency = rw.CurrencyID;
			ap.ShowDialog();
			if(ap.DialogResult == DialogResult.OK)
			{
				rwPaym.HeaderID = this.iHeaderID;
				this.dvPaymsList.Table.Rows.Add((DataRow) rwPaym);
				if(!this.confirmedPaym(rwPaym))
				{
					this.dsPaymentOrderListX1.AccountsStatements[dsPaymentOrderListX1.AccountsStatements.Count-1].Delete();
					this.dsPaymentOrderListX1.AccountsStatements.AcceptChanges();
					return;
				}
				if(rwPaym.Direction)
					this.tbSaldoEnd.dValue += rwPaym.PaymentOrderSum;
				else
					this.tbSaldoEnd.dValue -= rwPaym.PaymentOrderSum;
				setHeaderSaldo();
			}
		}  */
		private void addConfirmedPaym()
		{
			//Добавить п/п в принятую выписку
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvInnerAccount];
			BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow rw = (BPS.BLL.Orgs.DataSets.dsOrgsAccount.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwPaym = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList.Table.NewRow();
			
			AccountStatementPaymentEdit ap = new AccountStatementPaymentEdit(rwPaym, true, false);
			ap.Text += " [Новое]";
			ap.DsPaymsList = this.dsPaymentOrderListX1;
			ap.Currency = rw.CurrencyID;

			if ( this.cmbInnerOrgs.SelectedIndex >=0)
				ap.OwnerOrgID =(int)this.cmbInnerOrgs.SelectedValue; 
			
			if ( this.cmbInnerAccount.SelectedIndex >=0)
				ap.OwnerOrgAccountID =(int)this.dvInnerAccount[this.cmbInnerAccount.SelectedIndex]["OrgsAccountsID"];

			ap.ShowDialog();
			if(ap.DialogResult == DialogResult.OK)
			{
				rwPaym.HeaderID = this.iHeaderID;
				this.dvPaymsList.Table.Rows.Add((DataRow) rwPaym);
				//----------
				SqlCommand cmdConfPaym = new SqlCommand("[ConfirmedPayment]", App.Connection);
				cmdConfPaym.CommandType = CommandType.StoredProcedure;
				cmdConfPaym.Parameters.Add(new SqlParameter("@AccountStatementID", SqlDbType.Int));
				cmdConfPaym.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
				
				this.daUpdAccStatements.InsertCommand.Connection = App.Connection;
				App.Connection.Open();
				SqlTransaction tr = App.Connection.BeginTransaction();
				this.daUpdAccStatements.InsertCommand.Transaction = cmdConfPaym.Transaction = tr;
				try
				{
					this.daUpdAccStatements.Update(dsPaymentOrderListX1.AccountsStatements);
					cmdConfPaym.Parameters["@AccountStatementID"].Value = rwPaym.AccountStatementID;
					cmdConfPaym.Parameters["@HeaderID"].Value = rwPaym.HeaderID;
					cmdConfPaym.ExecuteNonQuery();
					tr.Commit();
				}
				catch(Exception ex)
				{
					try
					{
						tr.Rollback();
					}
					catch{}
					AM_Controls.MsgBoxX.Show(ex.Message);
					this.dsPaymentOrderListX1.AccountsStatements[dsPaymentOrderListX1.AccountsStatements.Count-1].Delete();
					this.dsPaymentOrderListX1.AccountsStatements.AcceptChanges();
                    return;					
				}
				finally
				{
					App.Connection.Close();
				}
				if(rwPaym.Direction)
					this.tbSaldoEnd.dValue += rwPaym.PaymentOrderSum;
				else
					this.tbSaldoEnd.dValue -= rwPaym.PaymentOrderSum;
				setHeaderSaldo();
				//----------
			}
		}
		private bool confirmedPaym(BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow accRow)
		{
			SqlCommand cmdConfPaym = new SqlCommand("[ConfirmedPayment]", App.Connection);
			cmdConfPaym.CommandType = CommandType.StoredProcedure;
			cmdConfPaym.Parameters.Add(new SqlParameter("@AccountStatementID", SqlDbType.Int));
			cmdConfPaym.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
			cmdConfPaym.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
			cmdConfPaym.Parameters["@HeaderID"].Value = accRow.HeaderID;
			try
			{
				App.Connection.Open();
				cmdConfPaym.ExecuteNonQuery();
				return true;
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
	/*	private bool confirmedPaym1(BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow accRow)
		{
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
			SqlCommand cmdUpdTransaction = new SqlCommand("[ChangeTransactionStatus_Commiting]", App.Connection);
			cmdUpdTransaction.CommandType = CommandType.StoredProcedure;
			cmdUpdTransaction.Parameters.Add(new SqlParameter("@nTransactionID",SqlDbType.Int));
			cmdUpdTransaction.Parameters.Add(new SqlParameter("@bCommiting",SqlDbType.Bit));
			this.daUpdAccStatements.InsertCommand.Connection = App.Connection;
			App.Connection.Open();
			SqlTransaction tr = App.Connection.BeginTransaction();
			
			cmdInsPaym.Transaction =  cmdLikePayms.Transaction = 
			this.daUpdAccStatements.InsertCommand.Transaction =	cmdUpdPaym.Transaction = cmdInsTrans.Transaction = cmdGetTransID.Transaction = cmdUpdTransaction.Transaction = tr;
			try
			{
				this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
					if(!accRow.Direction)
					{
					{
						int iPaymID=0;
						cmdUpdPaym.Parameters["@HeaderID"].Value = rwHeader.HeaderID;
						cmdUpdPaym.Parameters["@PaymentOrderDate"].Value = accRow.PaymentOrderDate;
						cmdUpdPaym.Parameters["@PaymentOrderStatusID"].Value = 3;
						cmdUpdPaym.Parameters["@AccountStatementID"].Value = accRow.AccountStatementID;
						if(accRow.IsRemarksNull())
							cmdUpdPaym.Parameters["@Remarks"].Value = Convert.DBNull;
						else
							cmdUpdPaym.Parameters["@Remarks"].Value = accRow.Remarks;
						cmdUpdPaym.ExecuteNonQuery();
						object o = cmdUpdPaym.Parameters["@PaymentOrderID"].Value;
						if(o == Convert.DBNull)
						{
							tr.Rollback();
							return false;
						}
						iPaymID = (int) o;
						if(iPaymID<1)
						{
							tr.Rollback();
							return false;
						}
						/////////////
						cmdGetTransID.Parameters["@TransactionCommited"].Value = true;
						cmdGetTransID.Parameters["@DocumentID"].Value = iPaymID;
						cmdGetTransID.ExecuteNonQuery();
							
						int iTropID = (int) cmdGetTransID.Parameters["@TransactionID"].Value;
						if(iTropID<1)
						{
							tr.Rollback();
							this.dsPaymentOrderListX1.AccountsStatements.RejectChanges();
							return false;
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
							cmdUpdPaym.Parameters["@HeaderID"].Value = rwHeader.HeaderID;
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
								
								return false;
							}
							cmdGetTransID.Parameters["@TransactionCommited"].Value = true;
							cmdGetTransID.Parameters["@DocumentID"].Value = iPaymID;
							cmdGetTransID.ExecuteNonQuery();
							
							iTrID = (int) cmdGetTransID.Parameters["@TransactionID"].Value;
							if(iTrID<1)
							{
								tr.Rollback();
								
								return false;
							}
						}
						else
						{
							cmdInsPaym.Parameters["@HeaderID"].Value = rwHeader.HeaderID;
							cmdInsPaym.Parameters["@PaymentOrderDate"].Value = accRow.PaymentOrderDate;
							cmdInsPaym.Parameters["@PaymentNo"].Value = accRow.PaymentNo;
							cmdInsPaym.Parameters["@OrgAccountID"].Value = rwHeader.OrgAccountID;
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
								
								return false;
							}
							cmdInsTrans.Parameters["@DocumentID"].Value = iPaymID;
							cmdInsTrans.Parameters["@TransactionTypeID"].Value = 1;
							cmdInsTrans.Parameters["@TransactionCommited"].Value = false;
							cmdInsTrans.Parameters["@SumFrom"].Value = accRow.PaymentOrderSum;
							cmdInsTrans.Parameters["@SumTo"].Value = accRow.PaymentOrderSum;
							cmdInsTrans.Parameters["@AccountIDFrom"].Value = accRow.AccountID;
							cmdInsTrans.Parameters["@AccountIDTo"].Value = rwHeader.AccountID;
							cmdInsTrans.Parameters["@InitDate"].Value = DateTime.Now;
							cmdInsTrans.ExecuteNonQuery();
							iTrID = (int) cmdInsTrans.Parameters["@TransactionID"].Value;
							if(iTrID<1)
							{
								tr.Rollback();
								
								return false;
							}
						}
						cmdUpdTransaction.Parameters["@nTransactionID"].Value = iTrID;
						cmdUpdTransaction.Parameters["@bCommiting"].Value = true;
						//cmdUpdTransaction.Parameters["@bPosting"].Value = false;
						cmdUpdTransaction.ExecuteNonQuery();
					}
				
				tr.Commit();
			}
			catch(Exception ex)
			{
				
				try
				{
					tr.Rollback();
				}
				catch{}
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				
				return false;
			}
			finally
			{
				App.Connection.Close();
				
			}
			return true;
		}   */
		private void delConfirmedPaym()
		{
			if(this.dvPaymsList.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvPaymsList];
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow)((DataRowView)bm.Current).Row;
			if(AM_Controls.MsgBoxX.Show("Убрать п/п №" + rw.PaymentNo + " из принятой выписки?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;
			SqlCommand cmdDelConfirmedPaym = new SqlCommand("[DeletePaymentOrder]", App.Connection);
			cmdDelConfirmedPaym.CommandType = CommandType.StoredProcedure;
			cmdDelConfirmedPaym.Parameters.Add(new SqlParameter("@AccountStatementID", SqlDbType.Int));
			
			App.Connection.Open();
			try
			{
				cmdDelConfirmedPaym.Parameters["@AccountStatementID"].Value = rw.AccountStatementID;
				double dSum = rw.PaymentOrderSum;
				bool bDirect = rw.Direction;
				cmdDelConfirmedPaym.ExecuteNonQuery();
				((DataRowView)bm.Current).Delete();
				dsPaymentOrderListX1.AccountsStatements.AcceptChanges();
				if(bDirect)
				{
					this.tbSaldoEnd.dValue -= dSum;
					this.fillDsUnlinkedPaymInList();
				}
				else
				{
					this.tbSaldoEnd.dValue += dSum;
					this.fillDsUnlinkedPaymList();
				}
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
		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.tabControl1.SelectedIndex == 0)
				this.insOutPaym();
			else 
				this.insInPaym();
		}
		private void insOutPaym()
		{
			//Добавить выплату
			if(this.dvUnLinkedPaymList.Count <= 0) return;

			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvUnLinkedPaymList];
			BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow rw = (BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow)((DataRowView)bm.Current).Row;
			if(!this.chekPayment(rw.PaymentOrderID))
			{
				AM_Controls.MsgBoxX.Show("Невозможно добавить этот платёж в выписку. Данный платёж уже связан с другой выпиской.");
				return;
			}
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwAcc = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList.Table.NewRow();
			rwAcc.AccountID = rw.AccountIDCorr;
			rwAcc.CurrencyID = rw.CurrencyIDCorr;
			rwAcc.Direct = "Расход";
			rwAcc.Direction = rw.Direction;
			rwAcc.HeaderID = this.iHeaderID;
			rwAcc.OrgAccountIDCorr = rw.OrgAccountIDCorr;
			rwAcc.OrgID = rw.OrgIDCorr;
			rwAcc.OrgName = rw.OrgNameCorr;
			rwAcc.PaymentNo = rw.PaymentNo;
			rwAcc.PaymentOrderDate = rw.PaymentOrderDate;
			if(!rw.IsPaymentOrderPurposeNull())
				rwAcc.PaymentOrderPurpose = rw.PaymentOrderPurpose;
			rwAcc.PaymentOrderSum = rw.PaymentOrderSum;
			rwAcc.RAccount = rw.RAccountCorr;
			if(!rw.IsRemarksNull())
				rwAcc.Remarks = rw.Remarks;
			this.dvPaymsList.Table.Rows.Add((DataRow) rwAcc);
			
			if ( ConnectionState.Closed ==this.sqlConnection1.State) this.sqlConnection1.Open();

			SqlTransaction tr1 = this.sqlConnection1.BeginTransaction();
			this.daUpdAccStatements.InsertCommand.Transaction = this.daUpdPaymentsOrders.UpdateCommand.Transaction = tr1;
			try
			{
				this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
				rw.AccountStatementID = rwAcc.AccountStatementID;
				this.daUpdPaymentsOrders.Update(this.dsUnlinkedPaymList1.GetUnlinkedPaymList);
				tr1.Commit();
				if(this.dvUnLinkedPaymList.Count>0)
				{
					string s = dvUnLinkedPaymList.RowFilter;
					dvUnLinkedPaymList.RowFilter = "";
					dvUnLinkedPaymList.RowFilter = s;
					this.BindingContext[this.dvUnLinkedPaymList].Position=0;
				}
			}
			catch(Exception ex)
			{
				tr1.Rollback();
				AM_Controls.MsgBoxX.Show(ex.Message);
				return;
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlConnection1.State) this.sqlConnection1.Close();
			}
		/*	this.updateAccountStatements();
			rw.AccountStatementID = rwAcc.AccountStatementID;
			this.updatePaymentsOrders();*/
			if(rwHeader.Confirmed || this.checkHeader(this.iHeaderID))
			{
				if(!this.confirmedPaym(rwAcc))
				{
					rw.SetAccountStatementIDNull();
					this.sqlConnection1.Open();
					SqlTransaction tr = this.sqlConnection1.BeginTransaction();
					this.daUpdPaymentsOrders.UpdateCommand.Transaction = this.daUpdAccStatements.DeleteCommand.Transaction = tr;
					try
					{
						this.updatePaymentsOrders();
						this.dsPaymentOrderListX1.AccountsStatements[dsPaymentOrderListX1.AccountsStatements.Count-1].Delete();
						this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
						tr.Commit();

					}
					catch(Exception ex)
					{
						tr.Rollback();
						AM_Controls.MsgBoxX.Show(ex.Message);
					}			
					finally
					{
						if ( ConnectionState.Open ==this.sqlConnection1.State) this.sqlConnection1.Close();
					}
					return;
				}
				if(rwAcc.Direction)
					this.tbSaldoEnd.dValue += rwAcc.PaymentOrderSum;
				else
					this.tbSaldoEnd.dValue -= rwAcc.PaymentOrderSum;
				setHeaderSaldo();
			}
		}
		private void insInPaym()
		{
			//Добавить внутренний приход
			if(this.dvUnlinkedPaymInList.Count == 0) return;

			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvUnlinkedPaymInList];
			BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow rw = (BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow) ((DataRowView)bm.Current).Row;
			if(!this.chekPayment(rw.PaymentOrderID))
			{
				AM_Controls.MsgBoxX.Show("Невозможно добавить этот платёж в выписку. Данный платёж уже связан с другой выпиской.");
				return;
			}
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwAcc = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList.Table.NewRow();
			rwAcc.AccountID = rw.AccountIDCorr;
			rwAcc.CurrencyID = rw.CurrencyIDCorr;
			rwAcc.Direct = "Приход";
			rwAcc.Direction = rw.Direction;
			rwAcc.HeaderID = this.iHeaderID;
			rwAcc.OrgAccountIDCorr = rw.OrgAccountIDCorr;
			rwAcc.OrgID = rw.OrgIDCorr;
			rwAcc.OrgName = rw.OrgNameCorr;
			rwAcc.PaymentNo = rw.PaymentNo;
			rwAcc.PaymentOrderDate = rw.PaymentOrderDate;
			//rwAcc.PaymentOrderDate = this.dtpExtractDate.Value;
			if(!rw.IsPaymentOrderPurposeNull())
				rwAcc.PaymentOrderPurpose = rw.PaymentOrderPurpose;
			rwAcc.PaymentOrderSum = rw.PaymentOrderSum;
			rwAcc.RAccount = rw.RAccountCorr;
			if(!rw.IsRemarksNull())
				rwAcc.Remarks = rw.Remarks;
			this.dvPaymsList.Table.Rows.Add((DataRow) rwAcc);
			
			if ( ConnectionState.Closed ==this.sqlConnection1.State) this.sqlConnection1.Open();

			SqlTransaction tr1 = this.sqlConnection1.BeginTransaction();
			this.daUpdAccStatements.InsertCommand.Transaction = this.daUpdPaymentsOrders.UpdateCommand.Transaction = tr1;

			try
			{
				this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
				rw.AccountStatementID = rwAcc.AccountStatementID;
				this.daUpdPaymentsOrders.Update(this.dsUnlinkedPaymInList.GetUnlinkedPaymList);
				tr1.Commit();
				if(this.dvUnlinkedPaymInList.Count>0)
				{
					string s = this.dvUnlinkedPaymInList.RowFilter;
					this.dvUnlinkedPaymInList.RowFilter = "";
					this.dvUnlinkedPaymInList.RowFilter = s;
					this.BindingContext[this.dvUnlinkedPaymInList].Position=0;
				}
			}
			catch(Exception ex)
			{
				tr1.Rollback();
				AM_Controls.MsgBoxX.Show(ex.Message);
				return;
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlConnection1.State) this.sqlConnection1.Close();
			}
	/*		this.updateAccountStatements();
			rw.AccountStatementID = rwAcc.AccountStatementID;
			this.updatePaymentsOrders(this.dsUnlinkedPaymInList.GetUnlinkedPaymList, this.dvUnlinkedPaymInList);
	*/		if(rwHeader.Confirmed || this.checkHeader(this.iHeaderID))
			{
				if(!this.confirmedPaym(rwAcc))
				{
					rw.SetAccountStatementIDNull();
					
					if ( ConnectionState.Closed ==this.sqlConnection1.State) this.sqlConnection1.Open();

					SqlTransaction tr = this.sqlConnection1.BeginTransaction();
					this.daUpdPaymentsOrders.UpdateCommand.Transaction = this.daUpdAccStatements.DeleteCommand.Transaction = tr;
					try
					{
						this.updatePaymentsOrders(this.dsUnlinkedPaymInList.GetUnlinkedPaymList, this.dvUnlinkedPaymInList);
						this.dsPaymentOrderListX1.AccountsStatements[dsPaymentOrderListX1.AccountsStatements.Count-1].Delete();
						this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
						tr.Commit();
					}
					catch(Exception ex)
					{
						tr.Rollback();
						AM_Controls.MsgBoxX.Show(ex.Message);
					}
					finally
					{
						if ( ConnectionState.Open ==this.sqlConnection1.State) this.sqlConnection1.Close();
					}
					return;
				}
				if(rwAcc.Direction)
					this.tbSaldoEnd.dValue += rwAcc.PaymentOrderSum;
				else
					this.tbSaldoEnd.dValue -= rwAcc.PaymentOrderSum;
				setHeaderSaldo();
			}
		}
		
		private bool chekPayment(int iPaymID)
		{
			cmdCheckPaym.Connection = App.Connection;
			cmdCheckPaym.Parameters["@PaymID"].Value = iPaymID;
			try
			{
				App.Connection.Open();
				object o = cmdCheckPaym.ExecuteScalar();
				if(o != Convert.DBNull)
					return false;
				else
					return true;
			}
			catch//(Exception ex)
			{
				return false;
			}
			finally
			{
				App.Connection.Close();
			}
		}
		private void cmbInnerAccount_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if(this.bIsLoaded)
				//this.dvUnLinkedPaymList.RowFilter = "AccountStatementID isnull and OrgAccountID=" + this.dvInnerAccount[this.cmbInnerAccount.SelectedIndex]["OrgAccountID"].ToString();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(!this.bIsNew && this.checkHeader(this.iHeaderID))
			{
				int iTransTypeID = this.checkInnerPaymInConfirmedHeader();
				if((iTransTypeID == 1) || ((iTransTypeID == 10)))
				{
			//		AM_Controls.MsgBoxX.Show("Для удаления п/п по внутреннему перемещению средств воспользуйтесь кнопкой 'Убрать из выписки'", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				else if(iTransTypeID == 0)
				{
					AM_Controls.MsgBoxX.Show("Во время удаления п/п произошла ошибка. Повторите попытку позже.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;		
				}
				else
				{
					delConfirmedPaym();
					return;							
				}
			}
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvPaymsList];
			//BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow rw = (BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow)((DataRowView)bm.Current).Row;
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwAcc = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) ((DataRowView)bm.Current).Row;
			if(!rwAcc.Direction)
	//		if(this.tabControl1.SelectedIndex == 0)
				this.delOutPaym();			
			else
				this.delInPaym();
		}
		private void delOutPaym()
		{
			if(this.dvPaymsList.Count == 0) return;
			
			//Удалить выплату из выписки
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvPaymsList];
			//BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow rw = (BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow)((DataRowView)bm.Current).Row;
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwAcc = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) ((DataRowView)bm.Current).Row;
			if(rwAcc.Direction || rwHeader.Confirmed || this.checkHeader(this.iHeaderID)) return;

			DataRow [] dr = this.dvUnLinkedPaymList.Table.Select("AccountStatementID=" + rwAcc.AccountStatementID.ToString());
			if ( dr.Length == 0)	return;

			BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow rw = (BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow) dr[0];
			
			rw.SetAccountStatementIDNull();
			((DataRowView)bm.Current).Delete();
			
			if ( ConnectionState.Closed ==this.sqlConnection1.State) this.sqlConnection1.Open();
			
			SqlTransaction tr = this.sqlConnection1.BeginTransaction();
			this.daUpdPaymentsOrders.UpdateCommand.Transaction = this.daUpdAccStatements.DeleteCommand.Transaction = tr;
			try
			{
				this.daUpdPaymentsOrders.Update(this.dsUnlinkedPaymList1.GetUnlinkedPaymList);
				this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
				tr.Commit();
				if(this.dvUnLinkedPaymList.Count>0)
				{
					string s = dvUnLinkedPaymList.RowFilter;
					dvUnLinkedPaymList.RowFilter = "";
					dvUnLinkedPaymList.RowFilter = s;
					this.BindingContext[this.dvUnLinkedPaymList].Position=0;
				}
			}
			catch(Exception ex)
			{
				tr.Rollback();
				MessageBox.Show("Действие отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlConnection1.State) this.sqlConnection1.Close();
			}
	//		this.updatePaymentsOrders();
	//		this.updateAccountStatements();
			if(this.dvUnLinkedPaymList.Count>0)
			{
				//this.dataGridV2.Update();
				this.dataGridV2.CurrentRowIndex = 0;
				
			}
		}
		private void delInPaym()
		{
			if (this.dvPaymsList.Count == 0) return;

			//Удаление внутреннего прихода из выписки
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvPaymsList];
			BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rwAcc = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) ((DataRowView)bm.Current).Row;
			
			if (!rwAcc.Direction || rwHeader.Confirmed || this.checkHeader(this.iHeaderID)) return;

			DataRow [] dr = this.dvUnlinkedPaymInList.Table.Select("AccountStatementID=" + rwAcc.AccountStatementID.ToString());
			if (dr.Length == 0) return;

			BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow rw = (BPS._Forms.dsUnlinkedPaymList.GetUnlinkedPaymListRow) dr[0];
			
			rw.SetAccountStatementIDNull();
			((DataRowView)bm.Current).Delete();
			
			if ( ConnectionState.Closed ==this.sqlConnection1.State) this.sqlConnection1.Open();
			
			SqlTransaction tr = this.sqlConnection1.BeginTransaction();
			this.daUpdPaymentsOrders.UpdateCommand.Transaction = this.daUpdAccStatements.DeleteCommand.Transaction = tr;
			try
			{
				this.daUpdPaymentsOrders.Update(this.dsUnlinkedPaymInList.GetUnlinkedPaymList);
				this.daUpdAccStatements.Update(this.dsPaymentOrderListX1.AccountsStatements);
				tr.Commit();
				if (this.dvUnlinkedPaymInList.Count>0)
				{
					string s = this.dvUnlinkedPaymInList.RowFilter;
					this.dvUnlinkedPaymInList.RowFilter = "";
					this.dvUnlinkedPaymInList.RowFilter = s;
					this.BindingContext[this.dvUnlinkedPaymInList].Position=0;
				}
			}
			catch(Exception ex)
			{
				tr.Rollback();
				MessageBox.Show("Действие отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlConnection1.State) this.sqlConnection1.Close();
			}
	//		this.updatePaymentsOrders(this.dsUnlinkedPaymInList.GetUnlinkedPaymList, this.dvUnlinkedPaymInList);
	//		this.updateAccountStatements();
			if (this.dvUnlinkedPaymInList.Count>0)
			{
				//this.dataGridV2.Update();
				this.dataGridV3.CurrentRowIndex = 0;
				
			}
		}
		private void setHeaderSaldo()
		{
			SqlCommand cmdUpdHeader = new SqlCommand("[UpdateSaldoInHeader]", App.Connection);
			cmdUpdHeader.CommandType = CommandType.StoredProcedure;
			cmdUpdHeader.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
			cmdUpdHeader.Parameters.Add(new SqlParameter("@SaldoStart", SqlDbType.Float));
			cmdUpdHeader.Parameters.Add(new SqlParameter("@SaldoEnd", SqlDbType.Float));
			cmdUpdHeader.Parameters.Add(new SqlParameter("@szRemarks", SqlDbType.NVarChar));
			cmdUpdHeader.Parameters["@HeaderID"].Value = this.iHeaderID;
			cmdUpdHeader.Parameters["@SaldoStart"].Value = this.tbSaldoStart.dValue;
			cmdUpdHeader.Parameters["@SaldoEnd"].Value = this.tbSaldoEnd.dValue;
			cmdUpdHeader.Parameters["@szRemarks"].Value = this.tbRemarks.Text;
			try
			{
				if ( ConnectionState.Closed ==App.Connection.State) App.Connection.Open();
				cmdUpdHeader.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка обновления сальдо: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				if ( ConnectionState.Open ==App.Connection.State) App.Connection.Close();
			}
		}

		private void tbSaldoStart_Leave(object sender, System.EventArgs e)
		{
			if(this.bIsLoaded && rwHeader.RowState != DataRowState.Detached && rwHeader.Confirmed)
				checkSum(true);
			this.setHeaderSaldo();
		}

		private void tbSaldoEnd_Leave(object sender, System.EventArgs e)
		{
			if(this.bIsLoaded && rwHeader.RowState != DataRowState.Detached && rwHeader.Confirmed)
				checkSum(false);
			this.setHeaderSaldo();
		}

		private void dataGridV1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.tabControl1.SelectedIndex == 0)
				this.delOutPaym();			
			else
				this.delInPaym();
		}

		private void dataGridV2_DoubleClick(object sender, System.EventArgs e)
		{
			this.insOutPaym();
		}

		private void AccountStatementEdit_Closed(object sender, System.EventArgs e)
		{
			if(this.bIsEdit)
				App.LockStatusChange(2,this.iHeaderID, false);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			//Новое п.п
			addPaym();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			//изменить п.п
			if(!this.bIsNew && !rwHeader.Confirmed)
				editPaym();
			else if(this.bIsNew && !rwHeader.Confirmed)
				editPaym();
			else
				AM_Controls.MsgBoxX.Show("Невозможно изменить платёж. Выписка принята.","BPS",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			//удалить п.п
			if(!this.bIsNew && rwHeader.Confirmed)
				delConfirmedPaym();
			else
				delPaym();
		}

		private void AccountStatementEdit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
			if ( this.tbSaldoStart.Focused) 
			{
				if( this.bIsLoaded && this.m_bIsConfirmed) //rwHeader.Confirmed)
					checkSum(true);
				//this.setHeaderSaldo();
			}
			if ( this.tbSaldoEnd.Focused) 
			{
				if ( this.bIsLoaded && this.m_bIsConfirmed) //rwHeader.Confirmed)
					checkSum(false);
				//this.setHeaderSaldo();
			}
			
			//if(!this.bIsNew && !rwHeader.Confirmed)
			this.setHeaderSaldo();
			
			this.Memorize();
			
		}

		private void checkSum(bool bIsStart)
		{
			double dSum = 0;
			for(int i=0; i<this.dvPaymsList.Count; i++)
			{
				dsPaymentOrderListX.AccountsStatementsRow rw = (dsPaymentOrderListX.AccountsStatementsRow) this.dvPaymsList[i].Row;
				if(rw.Direction)
					dSum += rw.PaymentOrderSum;
				else
					dSum -= rw.PaymentOrderSum;
			}
			if(bIsStart)
				this.tbSaldoEnd.dValue = this.tbSaldoStart.dValue + dSum;
			else
				this.tbSaldoStart.dValue = this.tbSaldoEnd.dValue - dSum;
		}

		private void tbRemarks_Leave(object sender, System.EventArgs e)
		{
			//if ( rwHeader.Confirmed) this.setHeaderSaldo();	
		}


	}
}
