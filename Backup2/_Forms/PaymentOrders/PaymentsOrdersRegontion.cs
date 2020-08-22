using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb; 
using AM_Controls;
using BPS;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymentsOrdersRegontion.
	/// </summary>
	public class PaymentsOrdersRecognition : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.DataGrid dgAccStatementsList;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS.BLL.AccountStatements.dsAccStatementsList dsAccStatementsList1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnHeaderDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnBankName;
		private System.Windows.Forms.DataGridBoolColumn ColumnConfirmed;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnKAccount;
		private System.Windows.Forms.ComboBox cmbOrg;
		private System.Windows.Forms.ComboBox cmbOrgAccount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private BPS._Forms.dsOrgsUList dsOrgsUList1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private BPS._Forms.dsOrgAccountsUList dsOrgAccountsUList1;
		private System.Data.DataView dvOrgsUList;
		private System.Data.DataView dvOrgAccountsUList;
		private System.Data.DataView dvAccStatementsList;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnEditLink;
		private System.Windows.Forms.DataGrid dgAccStatementDetails;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private BPS.BLL.AccountStatements.dsAccStatementsListDetails dsAccStatementsListDetails1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentNo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnContraOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnContraRAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnContraKAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnContraBankName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnContraCityName;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private BPS._Forms.dsRequestsNotLinked dsRequestsNotLinked1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRequestID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRequestTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnOrgNameFrom;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnOrgNameTo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRAccountFrom;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderSum;
		private System.Windows.Forms.DataGridBoolColumn ColumnDirection;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRAccountTo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRequestDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRemarks;
		private System.Windows.Forms.DataGridBoolColumn ColumnLinked;
		private System.ComponentModel.IContainer components;

		private int m_CurrentPaymentOrderID		=0;
		private System.Data.SqlClient.SqlCommand sqlCommandSetLink;
		private System.Data.SqlClient.SqlCommand sqlCommandDropLink;
		private System.Windows.Forms.DataGrid dgRequestsNotLinked;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnExecutedSum;
		private System.Windows.Forms.TextBox tbClientName;
		private System.Windows.Forms.TextBox tbStatementRemarks;
		private System.Windows.Forms.TextBox tbRequestID;
		private System.Windows.Forms.TextBox tbRequestTypeName;
		private System.Windows.Forms.TextBox tbRequestDate;
		private System.Windows.Forms.TextBox tbRequestPurpose;
		private System.Windows.Forms.TextBox tbRequestRemarks;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbtnSetLink;
		private System.Windows.Forms.ToolBarButton tbtnDropLink;
		private System.Windows.Forms.ImageList imgButtons;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRequiredSum;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRequestCurrencyTo;
		private AM_Controls.TextBoxV textBoxV1;
		private AM_Controls.TextBoxV tbRequestSum;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbRequestCurrency;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolBarButton Separator1;
		private System.Windows.Forms.ToolBarButton Separator2;
		private System.Windows.Forms.ToolBarButton tbtnFilterApply;
		private System.Windows.Forms.ToolBarButton tbtnFilterClear;
		private AM_Controls.ucPeriodSimple ucStatementsPeriodSimple;
		private System.Windows.Forms.Label label10;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Windows.Forms.ToolBarButton tbtnUnLinkedList;
		private System.Windows.Forms.ToolBarButton tbbHistory;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label label3;
		private AM_Controls.TextBoxV tbServiceCharge;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbClients;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private BPS._Forms.dsPaymentsOrdersUnknownList dsPaymentsOrdersUnknownList1;
		private System.Data.DataView dvUnknownList;
		private System.Data.DataView dvClients;
		private System.Data.SqlClient.SqlCommand sqlCmdSetLinkByClient;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridUITableStyle;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIHeaderID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIHeaderDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIPaymentOrderID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIPaymentNo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIPaymentOrderDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIPaymentOrderSum;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIRAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUICodeINN;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIOrgNameContra;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIRAccountContra;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUICodeINNContra;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIPaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUIRemarks;
		private System.Windows.Forms.ToolBarButton tbtnSetClientLink;
		private System.Windows.Forms.ToolBarButton tbtnSetAsRevenue;
		private System.Data.SqlClient.SqlCommand sqlCmdSetTypeRevenue;
		private System.Data.SqlClient.SqlCommand sqlCmdGetServiceCharge;
		private System.Windows.Forms.Button btnGetLast;
		private System.Windows.Forms.ToolBarButton tbtnRefresh;
		private System.Windows.Forms.CheckBox cbViewExceedSum;
		private int m_CurrentClientRequestID	=0;

		public PaymentsOrdersRecognition()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			//dsAccStatementsListDetails1 - GetPaymentsOrders.RequestSum
			try 
			{
				this.tbtnSetClientLink.Enabled	=false;
				this.tbtnSetAsRevenue.Enabled	=false;

				this.dvClients.Table = App.DsClients.Clients;
				this.cmbClients.DataSource = this.dvClients;
				this.cmbClients.DisplayMember = "ClientName";
				this.cmbClients.ValueMember = "ClientID";
				this.dvClients.RowFilter = "IsInner=false and IsSpecial=false";

				App.SetDataGridTableStyle( this.dataGridTableStyle1);
				App.SetDataGridTableStyle( this.dataGridTableStyle2);
				App.SetDataGridTableStyle( this.dataGridTableStyle3);
				App.SetDataGridTableStyle( this.dataGridUITableStyle);

				this.sqlDataAdapter1.Fill( this.dsAccStatementsList1);
				this.sqlDataAdapter2.Fill( this.dsOrgsUList1);
				this.sqlDataAdapter3.Fill( this.dsOrgAccountsUList1); 
				this.sqlDataAdapter5.Fill( this.dsRequestsNotLinked1,"GetRequestsNotLinked");
				this.sqlDataAdapter6.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders); 
  
				this.BindingContext[this.dvAccStatementsList].CurrentChanged += new EventHandler(this.CurrentStatementChanged);
				this.BindingContext[this.dsAccStatementsListDetails1, "GetPaymentsOrders"].CurrentChanged += new EventHandler(this.CurrentPaymentOrderChanged);
				this.BindingContext[this.dsRequestsNotLinked1, "GetRequestsNotLinked"].CurrentChanged += new EventHandler(this.CurrentRequestChanged);
				
				this.CurrentStatementChanged	( null, null);
				this.CurrentPaymentOrderChanged	( null, null);
				this.CurrentRequestChanged		( null, null); 
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Ошибка чтения данных: " +ex.Message.ToString(), "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
			}
			FilterClear();
			FilterApply();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymentsOrdersRecognition));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel12 = new System.Windows.Forms.Panel();
			this.dgAccStatementsList = new System.Windows.Forms.DataGrid();
			this.dvAccStatementsList = new System.Data.DataView();
			this.dsAccStatementsList1 = new BPS.BLL.AccountStatements.dsAccStatementsList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnHeaderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnConfirmed = new System.Windows.Forms.DataGridBoolColumn();
			this.ColumnOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnBankName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnKAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.ucStatementsPeriodSimple = new AM_Controls.ucPeriodSimple();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbOrg = new System.Windows.Forms.ComboBox();
			this.dvOrgsUList = new System.Data.DataView();
			this.dsOrgsUList1 = new BPS._Forms.dsOrgsUList();
			this.cmbOrgAccount = new System.Windows.Forms.ComboBox();
			this.dvOrgAccountsUList = new System.Data.DataView();
			this.dsOrgAccountsUList1 = new BPS._Forms.dsOrgAccountsUList();
			this.label2 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgAccStatementDetails = new System.Windows.Forms.DataGrid();
			this.dsAccStatementsListDetails1 = new BPS.BLL.AccountStatements.dsAccStatementsListDetails();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnPaymentOrderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentOrderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnDirection = new System.Windows.Forms.DataGridBoolColumn();
			this.ColumnPaymentOrderSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnLinked = new System.Windows.Forms.DataGridBoolColumn();
			this.ColumnContraOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnContraRAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnContraKAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnContraBankName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnContraCityName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbRequestCurrency = new System.Windows.Forms.Label();
			this.textBoxV1 = new AM_Controls.TextBoxV();
			this.btnEditLink = new System.Windows.Forms.Button();
			this.tbClientName = new System.Windows.Forms.TextBox();
			this.tbStatementRemarks = new System.Windows.Forms.TextBox();
			this.tbRequestID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbRequestTypeName = new System.Windows.Forms.TextBox();
			this.tbRequestDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbRequestSum = new AM_Controls.TextBoxV();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel14 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvUnknownList = new System.Data.DataView();
			this.dsPaymentsOrdersUnknownList1 = new BPS._Forms.dsPaymentsOrdersUnknownList();
			this.dataGridUITableStyle = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnUIHeaderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIHeaderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIPaymentOrderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIPaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIPaymentOrderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIPaymentOrderSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIOrgNameContra = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIPaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUICodeINNContra = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIRAccountContra = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIRAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUICodeINN = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUIRemarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel13 = new System.Windows.Forms.Panel();
			this.btnGetLast = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tbServiceCharge = new AM_Controls.TextBoxV();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbClients = new System.Windows.Forms.ComboBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.dgRequestsNotLinked = new System.Windows.Forms.DataGrid();
			this.dsRequestsNotLinked1 = new BPS._Forms.dsRequestsNotLinked();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnRequestID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRequestDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRequiredSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRequestCurrencyTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnExecutedSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnOrgNameFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRAccountFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRequestTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnOrgNameTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRAccountTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRemarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel8 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.tbRequestPurpose = new System.Windows.Forms.TextBox();
			this.tbRequestRemarks = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommandSetLink = new System.Data.SqlClient.SqlCommand();
			this.sqlCommandDropLink = new System.Data.SqlClient.SqlCommand();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbtnSetLink = new System.Windows.Forms.ToolBarButton();
			this.tbtnDropLink = new System.Windows.Forms.ToolBarButton();
			this.tbtnSetClientLink = new System.Windows.Forms.ToolBarButton();
			this.tbtnSetAsRevenue = new System.Windows.Forms.ToolBarButton();
			this.Separator1 = new System.Windows.Forms.ToolBarButton();
			this.tbtnUnLinkedList = new System.Windows.Forms.ToolBarButton();
			this.tbbHistory = new System.Windows.Forms.ToolBarButton();
			this.Separator2 = new System.Windows.Forms.ToolBarButton();
			this.tbtnFilterApply = new System.Windows.Forms.ToolBarButton();
			this.tbtnFilterClear = new System.Windows.Forms.ToolBarButton();
			this.tbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.imgButtons = new System.Windows.Forms.ImageList(this.components);
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dvClients = new System.Data.DataView();
			this.sqlCmdSetLinkByClient = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetTypeRevenue = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetServiceCharge = new System.Data.SqlClient.SqlCommand();
			this.cbViewExceedSum = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.panel12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAccStatementsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAccStatementsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccStatementsList1)).BeginInit();
			this.panel10.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsUList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsUList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgAccountsUList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgAccountsUList1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel6.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAccStatementDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccStatementsListDetails1)).BeginInit();
			this.panel5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnknownList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentsOrdersUnknownList1)).BeginInit();
			this.panel13.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRequestsNotLinked)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRequestsNotLinked1)).BeginInit();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel12);
			this.panel1.Controls.Add(this.panel11);
			this.panel1.Controls.Add(this.panel10);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(344, 601);
			this.panel1.TabIndex = 0;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.dgAccStatementsList);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel12.Location = new System.Drawing.Point(0, 112);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(344, 465);
			this.panel12.TabIndex = 2;
			// 
			// dgAccStatementsList
			// 
			this.dgAccStatementsList.CaptionText = "Выписки";
			this.dgAccStatementsList.DataMember = "";
			this.dgAccStatementsList.DataSource = this.dvAccStatementsList;
			this.dgAccStatementsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgAccStatementsList.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgAccStatementsList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAccStatementsList.Location = new System.Drawing.Point(0, 0);
			this.dgAccStatementsList.Name = "dgAccStatementsList";
			this.dgAccStatementsList.ReadOnly = true;
			this.dgAccStatementsList.Size = new System.Drawing.Size(344, 465);
			this.dgAccStatementsList.TabIndex = 0;
			this.dgAccStatementsList.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											this.dataGridTableStyle1});
			// 
			// dvAccStatementsList
			// 
			this.dvAccStatementsList.Table = this.dsAccStatementsList1.AccountsStatementsHeaders;
			// 
			// dsAccStatementsList1
			// 
			this.dsAccStatementsList1.DataSetName = "dsAccStatementsList";
			this.dsAccStatementsList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgAccStatementsList;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnHeaderDate,
																												  this.ColumnConfirmed,
																												  this.ColumnOrgName,
																												  this.ColumnRAccount,
																												  this.ColumnBankName,
																												  this.ColumnKAccount});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "AccountsStatementsHeaders";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// ColumnHeaderDate
			// 
			this.ColumnHeaderDate.Format = "dd-MM-yy";
			this.ColumnHeaderDate.FormatInfo = null;
			this.ColumnHeaderDate.HeaderText = "Дата";
			this.ColumnHeaderDate.MappingName = "HeaderDate";
			this.ColumnHeaderDate.NullText = "-";
			this.ColumnHeaderDate.Width = 55;
			// 
			// ColumnConfirmed
			// 
			this.ColumnConfirmed.FalseValue = false;
			this.ColumnConfirmed.HeaderText = "<>";
			this.ColumnConfirmed.MappingName = "Confirmed";
			this.ColumnConfirmed.NullValue = "false";
			this.ColumnConfirmed.TrueValue = true;
			this.ColumnConfirmed.Width = 25;
			// 
			// ColumnOrgName
			// 
			this.ColumnOrgName.Format = "";
			this.ColumnOrgName.FormatInfo = null;
			this.ColumnOrgName.HeaderText = "Организация";
			this.ColumnOrgName.MappingName = "OrgName";
			this.ColumnOrgName.Width = 75;
			// 
			// ColumnRAccount
			// 
			this.ColumnRAccount.Format = "";
			this.ColumnRAccount.FormatInfo = null;
			this.ColumnRAccount.HeaderText = "Р/С";
			this.ColumnRAccount.MappingName = "RAccount";
			this.ColumnRAccount.NullText = "-";
			this.ColumnRAccount.Width = 135;
			// 
			// ColumnBankName
			// 
			this.ColumnBankName.Format = "";
			this.ColumnBankName.FormatInfo = null;
			this.ColumnBankName.HeaderText = "Банк";
			this.ColumnBankName.MappingName = "BankName";
			this.ColumnBankName.NullText = "-";
			this.ColumnBankName.Width = 75;
			// 
			// ColumnKAccount
			// 
			this.ColumnKAccount.Format = "";
			this.ColumnKAccount.FormatInfo = null;
			this.ColumnKAccount.HeaderText = "К/С";
			this.ColumnKAccount.MappingName = "KAccount";
			this.ColumnKAccount.NullText = "-";
			this.ColumnKAccount.Width = 60;
			// 
			// panel11
			// 
			this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel11.Location = new System.Drawing.Point(0, 577);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(344, 24);
			this.panel11.TabIndex = 1;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.groupBox1);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(344, 112);
			this.panel10.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.ucStatementsPeriodSimple);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmbOrg);
			this.groupBox1.Controls.Add(this.cmbOrgAccount);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(6, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(322, 98);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр Просмотра Выписок";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label10.Location = new System.Drawing.Point(8, 71);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 18);
			this.label10.TabIndex = 7;
			this.label10.Text = "Период:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ucStatementsPeriodSimple
			// 
			this.ucStatementsPeriodSimple._cbDateFrom = true;
			this.ucStatementsPeriodSimple._cbDateFromUse = true;
			this.ucStatementsPeriodSimple._cbDateTill = true;
			this.ucStatementsPeriodSimple._cbDateTillUse = true;
			this.ucStatementsPeriodSimple._DateFrom = new System.DateTime(2003, 12, 18, 0, 0, 0, 0);
			this.ucStatementsPeriodSimple._DateTill = new System.DateTime(2003, 12, 19, 0, 0, 0, 0);
			this.ucStatementsPeriodSimple._PeriodType = AM_Controls.Span.LastTwoWorkingDays;
			this.ucStatementsPeriodSimple.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.ucStatementsPeriodSimple.Location = new System.Drawing.Point(74, 70);
			this.ucStatementsPeriodSimple.Modified = true;
			this.ucStatementsPeriodSimple.Name = "ucStatementsPeriodSimple";
			this.ucStatementsPeriodSimple.Size = new System.Drawing.Size(240, 22);
			this.ucStatementsPeriodSimple.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(8, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Р/С:";
			// 
			// cmbOrg
			// 
			this.cmbOrg.DataSource = this.dvOrgsUList;
			this.cmbOrg.DisplayMember = "OrgName";
			this.cmbOrg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cmbOrg.Location = new System.Drawing.Point(48, 22);
			this.cmbOrg.MaxDropDownItems = 20;
			this.cmbOrg.Name = "cmbOrg";
			this.cmbOrg.Size = new System.Drawing.Size(264, 21);
			this.cmbOrg.TabIndex = 0;
			this.cmbOrg.ValueMember = "OrgID";
			this.cmbOrg.SelectedIndexChanged += new System.EventHandler(this.cmbOrg_SelectedIndexChanged);
			// 
			// dvOrgsUList
			// 
			this.dvOrgsUList.Table = this.dsOrgsUList1.GetOrgsUList;
			// 
			// dsOrgsUList1
			// 
			this.dsOrgsUList1.DataSetName = "dsOrgsUList";
			this.dsOrgsUList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cmbOrgAccount
			// 
			this.cmbOrgAccount.DataSource = this.dvOrgAccountsUList;
			this.cmbOrgAccount.DisplayMember = "OrgsAccountsWide";
			this.cmbOrgAccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cmbOrgAccount.Location = new System.Drawing.Point(48, 44);
			this.cmbOrgAccount.Name = "cmbOrgAccount";
			this.cmbOrgAccount.Size = new System.Drawing.Size(264, 21);
			this.cmbOrgAccount.TabIndex = 0;
			this.cmbOrgAccount.ValueMember = "OrgsAccountsID";
			// 
			// dvOrgAccountsUList
			// 
			this.dvOrgAccountsUList.Table = this.dsOrgAccountsUList1.GetOrgAccountsUList;
			// 
			// dsOrgAccountsUList1
			// 
			this.dsOrgAccountsUList1.DataSetName = "dsOrgAccountsUList";
			this.dsOrgAccountsUList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Орг-я:";
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Control;
			this.splitter1.Location = new System.Drawing.Point(344, 28);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 601);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel6);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(350, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(714, 312);
			this.panel2.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.tabControl1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 8);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(714, 304);
			this.panel6.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(714, 304);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgAccStatementDetails);
			this.tabPage1.Controls.Add(this.panel5);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(706, 278);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Состав выписки";
			// 
			// dgAccStatementDetails
			// 
			this.dgAccStatementDetails.CaptionText = "Платёжные поручения";
			this.dgAccStatementDetails.DataMember = "GetPaymentsOrders";
			this.dgAccStatementDetails.DataSource = this.dsAccStatementsListDetails1;
			this.dgAccStatementDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgAccStatementDetails.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgAccStatementDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAccStatementDetails.Location = new System.Drawing.Point(0, 0);
			this.dgAccStatementDetails.Name = "dgAccStatementDetails";
			this.dgAccStatementDetails.ReadOnly = true;
			this.dgAccStatementDetails.Size = new System.Drawing.Size(706, 230);
			this.dgAccStatementDetails.TabIndex = 0;
			this.dgAccStatementDetails.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											  this.dataGridTableStyle2});
			// 
			// dsAccStatementsListDetails1
			// 
			this.dsAccStatementsListDetails1.DataSetName = "dsAccStatementsListDetails";
			this.dsAccStatementsListDetails1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dgAccStatementDetails;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnPaymentOrderID,
																												  this.ColumnPaymentNo,
																												  this.ColumnPaymentOrderDate,
																												  this.ColumnDirection,
																												  this.ColumnPaymentOrderSum,
																												  this.ColumnLinked,
																												  this.ColumnContraOrgName,
																												  this.ColumnPaymentOrderPurpose,
																												  this.ColumnContraRAccount,
																												  this.ColumnContraKAccount,
																												  this.ColumnContraBankName,
																												  this.ColumnContraCityName});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "GetPaymentsOrders";
			// 
			// ColumnPaymentOrderID
			// 
			this.ColumnPaymentOrderID.Format = "000000";
			this.ColumnPaymentOrderID.FormatInfo = null;
			this.ColumnPaymentOrderID.HeaderText = "ID";
			this.ColumnPaymentOrderID.MappingName = "PaymentOrderID";
			this.ColumnPaymentOrderID.Width = 50;
			// 
			// ColumnPaymentNo
			// 
			this.ColumnPaymentNo.Format = "";
			this.ColumnPaymentNo.FormatInfo = null;
			this.ColumnPaymentNo.HeaderText = "№ П/П";
			this.ColumnPaymentNo.MappingName = "PaymentNo";
			this.ColumnPaymentNo.NullText = "-";
			this.ColumnPaymentNo.Width = 65;
			// 
			// ColumnPaymentOrderDate
			// 
			this.ColumnPaymentOrderDate.Format = "dd-MMM-yy";
			this.ColumnPaymentOrderDate.FormatInfo = null;
			this.ColumnPaymentOrderDate.HeaderText = "Дата П/П";
			this.ColumnPaymentOrderDate.MappingName = "PaymentOrderDate";
			this.ColumnPaymentOrderDate.NullText = "-";
			this.ColumnPaymentOrderDate.Width = 60;
			// 
			// ColumnDirection
			// 
			this.ColumnDirection.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnDirection.FalseValue = false;
			this.ColumnDirection.HeaderText = "П";
			this.ColumnDirection.MappingName = "Direction";
			this.ColumnDirection.NullValue = "False";
			this.ColumnDirection.TrueValue = true;
			this.ColumnDirection.Width = 25;
			// 
			// ColumnPaymentOrderSum
			// 
			this.ColumnPaymentOrderSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPaymentOrderSum.Format = "#,##0.00";
			this.ColumnPaymentOrderSum.FormatInfo = null;
			this.ColumnPaymentOrderSum.HeaderText = "Сумма";
			this.ColumnPaymentOrderSum.MappingName = "PaymentOrderSum";
			this.ColumnPaymentOrderSum.NullText = "-";
			this.ColumnPaymentOrderSum.Width = 90;
			// 
			// ColumnLinked
			// 
			this.ColumnLinked.FalseValue = false;
			this.ColumnLinked.HeaderText = "<+>";
			this.ColumnLinked.MappingName = "PaymOrderLinked";
			this.ColumnLinked.NullText = "-";
			this.ColumnLinked.NullValue = ((object)(resources.GetObject("ColumnLinked.NullValue")));
			this.ColumnLinked.TrueValue = true;
			this.ColumnLinked.Width = 25;
			// 
			// ColumnContraOrgName
			// 
			this.ColumnContraOrgName.Format = "";
			this.ColumnContraOrgName.FormatInfo = null;
			this.ColumnContraOrgName.HeaderText = "Контрагент";
			this.ColumnContraOrgName.MappingName = "OrgName";
			this.ColumnContraOrgName.NullText = "-";
			this.ColumnContraOrgName.Width = 120;
			// 
			// ColumnPaymentOrderPurpose
			// 
			this.ColumnPaymentOrderPurpose.Format = "";
			this.ColumnPaymentOrderPurpose.FormatInfo = null;
			this.ColumnPaymentOrderPurpose.HeaderText = "Основание";
			this.ColumnPaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
			this.ColumnPaymentOrderPurpose.NullText = "-";
			this.ColumnPaymentOrderPurpose.Width = 250;
			// 
			// ColumnContraRAccount
			// 
			this.ColumnContraRAccount.Format = "";
			this.ColumnContraRAccount.FormatInfo = null;
			this.ColumnContraRAccount.HeaderText = "Р/С";
			this.ColumnContraRAccount.MappingName = "RAccount";
			this.ColumnContraRAccount.NullText = "-";
			this.ColumnContraRAccount.Width = 135;
			// 
			// ColumnContraKAccount
			// 
			this.ColumnContraKAccount.Format = "";
			this.ColumnContraKAccount.FormatInfo = null;
			this.ColumnContraKAccount.HeaderText = "К/С";
			this.ColumnContraKAccount.MappingName = "KAccount";
			this.ColumnContraKAccount.NullText = "-";
			this.ColumnContraKAccount.Width = 75;
			// 
			// ColumnContraBankName
			// 
			this.ColumnContraBankName.Format = "";
			this.ColumnContraBankName.FormatInfo = null;
			this.ColumnContraBankName.HeaderText = "Банк";
			this.ColumnContraBankName.MappingName = "BankName";
			this.ColumnContraBankName.NullText = "-";
			this.ColumnContraBankName.Width = 50;
			// 
			// ColumnContraCityName
			// 
			this.ColumnContraCityName.Format = "";
			this.ColumnContraCityName.FormatInfo = null;
			this.ColumnContraCityName.HeaderText = "Город";
			this.ColumnContraCityName.MappingName = "CityName";
			this.ColumnContraCityName.NullText = "-";
			this.ColumnContraCityName.Width = 50;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lbRequestCurrency);
			this.panel5.Controls.Add(this.textBoxV1);
			this.panel5.Controls.Add(this.btnEditLink);
			this.panel5.Controls.Add(this.tbClientName);
			this.panel5.Controls.Add(this.tbStatementRemarks);
			this.panel5.Controls.Add(this.tbRequestID);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.tbRequestTypeName);
			this.panel5.Controls.Add(this.tbRequestDate);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Controls.Add(this.label6);
			this.panel5.Controls.Add(this.tbRequestSum);
			this.panel5.Controls.Add(this.label9);
			this.panel5.Controls.Add(this.textBox1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(0, 230);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(706, 48);
			this.panel5.TabIndex = 1;
			// 
			// lbRequestCurrency
			// 
			this.lbRequestCurrency.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.CurrencyTo"));
			this.lbRequestCurrency.Location = new System.Drawing.Point(611, 6);
			this.lbRequestCurrency.Name = "lbRequestCurrency";
			this.lbRequestCurrency.Size = new System.Drawing.Size(29, 18);
			this.lbRequestCurrency.TabIndex = 6;
			// 
			// textBoxV1
			// 
			this.textBoxV1.AllowDrop = true;
			this.textBoxV1.BackColor = System.Drawing.SystemColors.Info;
			this.textBoxV1.DataBindings.Add(new System.Windows.Forms.Binding("dValue", this.dsAccStatementsListDetails1, "GetPaymentsOrders.ServiceCharge"));
			this.textBoxV1.dValue = 0;
			this.textBoxV1.IsPcnt = true;
			this.textBoxV1.Location = new System.Drawing.Point(529, 25);
			this.textBoxV1.MaxDecPos = 2;
			this.textBoxV1.MaxPos = 8;
			this.textBoxV1.Name = "textBoxV1";
			this.textBoxV1.Negative = System.Drawing.Color.Empty;
			this.textBoxV1.nValue = ((long)(0));
			this.textBoxV1.Positive = System.Drawing.Color.Empty;
			this.textBoxV1.ReadOnly = true;
			this.textBoxV1.Size = new System.Drawing.Size(80, 20);
			this.textBoxV1.TabIndex = 5;
			this.textBoxV1.Text = "0";
			this.textBoxV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV1.TextMode = false;
			this.textBoxV1.Zero = System.Drawing.Color.Empty;
			// 
			// btnEditLink
			// 
			this.btnEditLink.Location = new System.Drawing.Point(2, 26);
			this.btnEditLink.Name = "btnEditLink";
			this.btnEditLink.Size = new System.Drawing.Size(42, 18);
			this.btnEditLink.TabIndex = 4;
			this.btnEditLink.Text = "...";
			// 
			// tbClientName
			// 
			this.tbClientName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.ClientName"));
			this.tbClientName.Location = new System.Drawing.Point(329, 4);
			this.tbClientName.Name = "tbClientName";
			this.tbClientName.ReadOnly = true;
			this.tbClientName.Size = new System.Drawing.Size(150, 20);
			this.tbClientName.TabIndex = 3;
			this.tbClientName.Text = "";
			// 
			// tbStatementRemarks
			// 
			this.tbStatementRemarks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.Purpose"));
			this.tbStatementRemarks.Location = new System.Drawing.Point(47, 25);
			this.tbStatementRemarks.Name = "tbStatementRemarks";
			this.tbStatementRemarks.ReadOnly = true;
			this.tbStatementRemarks.Size = new System.Drawing.Size(235, 20);
			this.tbStatementRemarks.TabIndex = 2;
			this.tbStatementRemarks.Text = "";
			// 
			// tbRequestID
			// 
			this.tbRequestID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.ClientRequestID"));
			this.tbRequestID.Location = new System.Drawing.Point(47, 4);
			this.tbRequestID.Name = "tbRequestID";
			this.tbRequestID.ReadOnly = true;
			this.tbRequestID.Size = new System.Drawing.Size(60, 20);
			this.tbRequestID.TabIndex = 1;
			this.tbRequestID.Text = "";
			// 
			// label4
			// 
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Location = new System.Drawing.Point(1, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Заявка:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRequestTypeName
			// 
			this.tbRequestTypeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.RequestTypeName"));
			this.tbRequestTypeName.Location = new System.Drawing.Point(182, 4);
			this.tbRequestTypeName.Name = "tbRequestTypeName";
			this.tbRequestTypeName.ReadOnly = true;
			this.tbRequestTypeName.TabIndex = 1;
			this.tbRequestTypeName.Text = "";
			// 
			// tbRequestDate
			// 
			this.tbRequestDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.RequestDate"));
			this.tbRequestDate.Location = new System.Drawing.Point(107, 4);
			this.tbRequestDate.Name = "tbRequestDate";
			this.tbRequestDate.ReadOnly = true;
			this.tbRequestDate.Size = new System.Drawing.Size(75, 20);
			this.tbRequestDate.TabIndex = 1;
			this.tbRequestDate.Text = "";
			this.tbRequestDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Location = new System.Drawing.Point(283, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Клиент:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new System.Drawing.Point(482, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(28, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "%%:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRequestSum
			// 
			this.tbRequestSum.AllowDrop = true;
			this.tbRequestSum.BackColor = System.Drawing.SystemColors.Info;
			this.tbRequestSum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.RequestSum"));
			this.tbRequestSum.dValue = 0;
			this.tbRequestSum.IsPcnt = false;
			this.tbRequestSum.Location = new System.Drawing.Point(529, 4);
			this.tbRequestSum.MaxDecPos = 2;
			this.tbRequestSum.MaxPos = 8;
			this.tbRequestSum.Name = "tbRequestSum";
			this.tbRequestSum.Negative = System.Drawing.Color.Empty;
			this.tbRequestSum.nValue = ((long)(0));
			this.tbRequestSum.Positive = System.Drawing.Color.Empty;
			this.tbRequestSum.ReadOnly = true;
			this.tbRequestSum.Size = new System.Drawing.Size(80, 20);
			this.tbRequestSum.TabIndex = 5;
			this.tbRequestSum.Text = "0";
			this.tbRequestSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbRequestSum.TextMode = false;
			this.tbRequestSum.Zero = System.Drawing.Color.Empty;
			// 
			// label9
			// 
			this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.Location = new System.Drawing.Point(482, 6);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "Сумма:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAccStatementsListDetails1, "GetPaymentsOrders.ClientRequestRemarks"));
			this.textBox1.Location = new System.Drawing.Point(282, 25);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(197, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel14);
			this.tabPage2.Controls.Add(this.panel13);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(706, 278);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Неопознанные";
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.dataGrid1);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel14.Location = new System.Drawing.Point(0, 35);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(706, 243);
			this.panel14.TabIndex = 1;
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvUnknownList;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(706, 243);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridUITableStyle});
			// 
			// dvUnknownList
			// 
			this.dvUnknownList.Table = this.dsPaymentsOrdersUnknownList1.PaymentsOrders;
			// 
			// dsPaymentsOrdersUnknownList1
			// 
			this.dsPaymentsOrdersUnknownList1.DataSetName = "dsPaymentsOrdersUnknownList";
			this.dsPaymentsOrdersUnknownList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridUITableStyle
			// 
			this.dataGridUITableStyle.DataGrid = this.dataGrid1;
			this.dataGridUITableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												   this.ColumnUIHeaderID,
																												   this.ColumnUIHeaderDate,
																												   this.ColumnUIPaymentOrderID,
																												   this.ColumnUIPaymentNo,
																												   this.ColumnUIPaymentOrderDate,
																												   this.ColumnUIPaymentOrderSum,
																												   this.ColumnUIOrgNameContra,
																												   this.ColumnUIPaymentOrderPurpose,
																												   this.ColumnUICodeINNContra,
																												   this.ColumnUIRAccountContra,
																												   this.ColumnUIOrgName,
																												   this.ColumnUIRAccount,
																												   this.ColumnUICodeINN,
																												   this.ColumnUIRemarks});
			this.dataGridUITableStyle.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dataGridUITableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridUITableStyle.MappingName = "PaymentsOrders";
			// 
			// ColumnUIHeaderID
			// 
			this.ColumnUIHeaderID.Format = "00000";
			this.ColumnUIHeaderID.FormatInfo = null;
			this.ColumnUIHeaderID.HeaderText = "ID";
			this.ColumnUIHeaderID.MappingName = "HeaderID";
			this.ColumnUIHeaderID.Width = 3;
			// 
			// ColumnUIHeaderDate
			// 
			this.ColumnUIHeaderDate.Format = "dd-MMM-yy";
			this.ColumnUIHeaderDate.FormatInfo = null;
			this.ColumnUIHeaderDate.HeaderText = "Выписка";
			this.ColumnUIHeaderDate.MappingName = "HeaderDate";
			this.ColumnUIHeaderDate.NullText = "-";
			this.ColumnUIHeaderDate.Width = 60;
			// 
			// ColumnUIPaymentOrderID
			// 
			this.ColumnUIPaymentOrderID.Format = "000000";
			this.ColumnUIPaymentOrderID.FormatInfo = null;
			this.ColumnUIPaymentOrderID.HeaderText = "ID П/П";
			this.ColumnUIPaymentOrderID.MappingName = "PaymentOrderID";
			this.ColumnUIPaymentOrderID.Width = 3;
			// 
			// ColumnUIPaymentNo
			// 
			this.ColumnUIPaymentNo.Format = "";
			this.ColumnUIPaymentNo.FormatInfo = null;
			this.ColumnUIPaymentNo.HeaderText = "№ П/П ";
			this.ColumnUIPaymentNo.MappingName = "PaymentNo";
			this.ColumnUIPaymentNo.NullText = "-";
			this.ColumnUIPaymentNo.Width = 60;
			// 
			// ColumnUIPaymentOrderDate
			// 
			this.ColumnUIPaymentOrderDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnUIPaymentOrderDate.Format = "dd-MMM-yy";
			this.ColumnUIPaymentOrderDate.FormatInfo = null;
			this.ColumnUIPaymentOrderDate.HeaderText = "Дата П/П";
			this.ColumnUIPaymentOrderDate.MappingName = "PaymentOrderDate";
			this.ColumnUIPaymentOrderDate.NullText = "-";
			this.ColumnUIPaymentOrderDate.Width = 60;
			// 
			// ColumnUIPaymentOrderSum
			// 
			this.ColumnUIPaymentOrderSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnUIPaymentOrderSum.Format = "#,##0.00";
			this.ColumnUIPaymentOrderSum.FormatInfo = null;
			this.ColumnUIPaymentOrderSum.HeaderText = "Сумма";
			this.ColumnUIPaymentOrderSum.MappingName = "PaymentOrderSum";
			this.ColumnUIPaymentOrderSum.NullText = "-";
			this.ColumnUIPaymentOrderSum.Width = 75;
			// 
			// ColumnUIOrgNameContra
			// 
			this.ColumnUIOrgNameContra.Format = "";
			this.ColumnUIOrgNameContra.FormatInfo = null;
			this.ColumnUIOrgNameContra.HeaderText = "Плательщик";
			this.ColumnUIOrgNameContra.MappingName = "OrgNameContra";
			this.ColumnUIOrgNameContra.NullText = "-";
			this.ColumnUIOrgNameContra.Width = 120;
			// 
			// ColumnUIPaymentOrderPurpose
			// 
			this.ColumnUIPaymentOrderPurpose.Format = "";
			this.ColumnUIPaymentOrderPurpose.FormatInfo = null;
			this.ColumnUIPaymentOrderPurpose.HeaderText = "Основание";
			this.ColumnUIPaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
			this.ColumnUIPaymentOrderPurpose.NullText = "-";
			this.ColumnUIPaymentOrderPurpose.Width = 250;
			// 
			// ColumnUICodeINNContra
			// 
			this.ColumnUICodeINNContra.Format = "";
			this.ColumnUICodeINNContra.FormatInfo = null;
			this.ColumnUICodeINNContra.HeaderText = "ИНН Плательщика";
			this.ColumnUICodeINNContra.MappingName = "CodeINNContra";
			this.ColumnUICodeINNContra.NullText = "-";
			this.ColumnUICodeINNContra.Width = 85;
			// 
			// ColumnUIRAccountContra
			// 
			this.ColumnUIRAccountContra.Format = "";
			this.ColumnUIRAccountContra.FormatInfo = null;
			this.ColumnUIRAccountContra.HeaderText = "Счёт Плательщика";
			this.ColumnUIRAccountContra.MappingName = "RAccountContra";
			this.ColumnUIRAccountContra.NullText = "-";
			this.ColumnUIRAccountContra.Width = 135;
			// 
			// ColumnUIOrgName
			// 
			this.ColumnUIOrgName.Format = "";
			this.ColumnUIOrgName.FormatInfo = null;
			this.ColumnUIOrgName.HeaderText = "Получатель";
			this.ColumnUIOrgName.MappingName = "OrgName";
			this.ColumnUIOrgName.NullText = "-";
			this.ColumnUIOrgName.Width = 75;
			// 
			// ColumnUIRAccount
			// 
			this.ColumnUIRAccount.Format = "";
			this.ColumnUIRAccount.FormatInfo = null;
			this.ColumnUIRAccount.HeaderText = "Получатель-Счёт";
			this.ColumnUIRAccount.MappingName = "RAccount";
			this.ColumnUIRAccount.Width = 135;
			// 
			// ColumnUICodeINN
			// 
			this.ColumnUICodeINN.Format = "";
			this.ColumnUICodeINN.FormatInfo = null;
			this.ColumnUICodeINN.HeaderText = "Получатель ИНН";
			this.ColumnUICodeINN.MappingName = "CodeINN";
			this.ColumnUICodeINN.NullText = "-";
			this.ColumnUICodeINN.Width = 85;
			// 
			// ColumnUIRemarks
			// 
			this.ColumnUIRemarks.Format = "";
			this.ColumnUIRemarks.FormatInfo = null;
			this.ColumnUIRemarks.HeaderText = "Примечание";
			this.ColumnUIRemarks.MappingName = "Remarks";
			this.ColumnUIRemarks.NullText = "-";
			this.ColumnUIRemarks.Width = 75;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.btnGetLast);
			this.panel13.Controls.Add(this.label3);
			this.panel13.Controls.Add(this.tbServiceCharge);
			this.panel13.Controls.Add(this.label11);
			this.panel13.Controls.Add(this.cmbClients);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(706, 35);
			this.panel13.TabIndex = 0;
			// 
			// btnGetLast
			// 
			this.btnGetLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnGetLast.Location = new System.Drawing.Point(472, 6);
			this.btnGetLast.Name = "btnGetLast";
			this.btnGetLast.Size = new System.Drawing.Size(140, 23);
			this.btnGetLast.TabIndex = 8;
			this.btnGetLast.Text = "Показать Последний";
			this.btnGetLast.Click += new System.EventHandler(this.btnGetLast_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(316, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "% Обслуживания:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbServiceCharge
			// 
			this.tbServiceCharge.AllowDrop = true;
			this.tbServiceCharge.dValue = 0;
			this.tbServiceCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbServiceCharge.IsPcnt = true;
			this.tbServiceCharge.Location = new System.Drawing.Point(418, 7);
			this.tbServiceCharge.MaxDecPos = 2;
			this.tbServiceCharge.MaxPos = 8;
			this.tbServiceCharge.Name = "tbServiceCharge";
			this.tbServiceCharge.Negative = System.Drawing.Color.Empty;
			this.tbServiceCharge.nValue = ((long)(0));
			this.tbServiceCharge.Positive = System.Drawing.Color.Empty;
			this.tbServiceCharge.Size = new System.Drawing.Size(50, 20);
			this.tbServiceCharge.TabIndex = 6;
			this.tbServiceCharge.Text = "0";
			this.tbServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceCharge.TextMode = false;
			this.tbServiceCharge.Zero = System.Drawing.Color.Empty;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label11.Location = new System.Drawing.Point(4, 10);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(50, 16);
			this.label11.TabIndex = 5;
			this.label11.Text = "Клиент:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbClients
			// 
			this.cmbClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cmbClients.Location = new System.Drawing.Point(56, 7);
			this.cmbClients.Name = "cmbClients";
			this.cmbClients.Size = new System.Drawing.Size(248, 21);
			this.cmbClients.TabIndex = 4;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(714, 8);
			this.panel4.TabIndex = 0;
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.SystemColors.Control;
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(350, 340);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(714, 6);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel9);
			this.panel3.Controls.Add(this.panel8);
			this.panel3.Controls.Add(this.panel7);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(350, 346);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(714, 283);
			this.panel3.TabIndex = 4;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.dgRequestsNotLinked);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new System.Drawing.Point(0, 8);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(714, 207);
			this.panel9.TabIndex = 2;
			// 
			// dgRequestsNotLinked
			// 
			this.dgRequestsNotLinked.AllowNavigation = false;
			this.dgRequestsNotLinked.CaptionText = "Заявки Клиентов";
			this.dgRequestsNotLinked.DataMember = "GetRequestsNotLinked";
			this.dgRequestsNotLinked.DataSource = this.dsRequestsNotLinked1;
			this.dgRequestsNotLinked.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgRequestsNotLinked.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgRequestsNotLinked.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgRequestsNotLinked.Location = new System.Drawing.Point(0, 0);
			this.dgRequestsNotLinked.Name = "dgRequestsNotLinked";
			this.dgRequestsNotLinked.ReadOnly = true;
			this.dgRequestsNotLinked.Size = new System.Drawing.Size(714, 207);
			this.dgRequestsNotLinked.TabIndex = 0;
			this.dgRequestsNotLinked.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											this.dataGridTableStyle3});
			// 
			// dsRequestsNotLinked1
			// 
			this.dsRequestsNotLinked1.DataSetName = "dsRequestsNotLinked";
			this.dsRequestsNotLinked1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.DataGrid = this.dgRequestsNotLinked;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnRequestID,
																												  this.ColumnRequestDate,
																												  this.ColumnRequiredSum,
																												  this.ColumnRequestCurrencyTo,
																												  this.ColumnExecutedSum,
																												  this.ColumnClientName,
																												  this.ColumnOrgNameFrom,
																												  this.ColumnRAccountFrom,
																												  this.ColumnPurpose,
																												  this.ColumnRequestTypeName,
																												  this.ColumnOrgNameTo,
																												  this.ColumnRAccountTo,
																												  this.ColumnRemarks});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "GetRequestsNotLinked";
			this.dataGridTableStyle3.ReadOnly = true;
			// 
			// ColumnRequestID
			// 
			this.ColumnRequestID.Format = "000000";
			this.ColumnRequestID.FormatInfo = null;
			this.ColumnRequestID.HeaderText = "ID";
			this.ColumnRequestID.MappingName = "RequestID";
			this.ColumnRequestID.NullText = "-";
			this.ColumnRequestID.Width = 50;
			// 
			// ColumnRequestDate
			// 
			this.ColumnRequestDate.Format = "dd-MMM-yy";
			this.ColumnRequestDate.FormatInfo = null;
			this.ColumnRequestDate.HeaderText = "Дата";
			this.ColumnRequestDate.MappingName = "RequestDate";
			this.ColumnRequestDate.NullText = "-";
			this.ColumnRequestDate.Width = 60;
			// 
			// ColumnRequiredSum
			// 
			this.ColumnRequiredSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnRequiredSum.Format = "#,##0.00";
			this.ColumnRequiredSum.FormatInfo = null;
			this.ColumnRequiredSum.HeaderText = "Сумма";
			this.ColumnRequiredSum.MappingName = "RequestSum";
			this.ColumnRequiredSum.NullText = "-";
			this.ColumnRequiredSum.Width = 75;
			// 
			// ColumnRequestCurrencyTo
			// 
			this.ColumnRequestCurrencyTo.Format = "";
			this.ColumnRequestCurrencyTo.FormatInfo = null;
			this.ColumnRequestCurrencyTo.HeaderText = "Валюта";
			this.ColumnRequestCurrencyTo.MappingName = "CurrencyTo";
			this.ColumnRequestCurrencyTo.NullText = "-";
			this.ColumnRequestCurrencyTo.Width = 30;
			// 
			// ColumnExecutedSum
			// 
			this.ColumnExecutedSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnExecutedSum.Format = "#,##0.00;;\"-\"";
			this.ColumnExecutedSum.FormatInfo = null;
			this.ColumnExecutedSum.HeaderText = "Вып Сумма";
			this.ColumnExecutedSum.MappingName = "ExecutedSum";
			this.ColumnExecutedSum.NullText = "-";
			this.ColumnExecutedSum.Width = 75;
			// 
			// ColumnClientName
			// 
			this.ColumnClientName.Format = "";
			this.ColumnClientName.FormatInfo = null;
			this.ColumnClientName.HeaderText = "Клиент";
			this.ColumnClientName.MappingName = "ClientName";
			this.ColumnClientName.NullText = "-";
			this.ColumnClientName.Width = 120;
			// 
			// ColumnOrgNameFrom
			// 
			this.ColumnOrgNameFrom.Format = "";
			this.ColumnOrgNameFrom.FormatInfo = null;
			this.ColumnOrgNameFrom.HeaderText = "Отправитель";
			this.ColumnOrgNameFrom.MappingName = "OrgFrom";
			this.ColumnOrgNameFrom.NullText = "-";
			this.ColumnOrgNameFrom.Width = 120;
			// 
			// ColumnRAccountFrom
			// 
			this.ColumnRAccountFrom.Format = "";
			this.ColumnRAccountFrom.FormatInfo = null;
			this.ColumnRAccountFrom.HeaderText = "Р/С Отпр";
			this.ColumnRAccountFrom.MappingName = "AccountFrom";
			this.ColumnRAccountFrom.NullText = "-";
			this.ColumnRAccountFrom.Width = 75;
			// 
			// ColumnPurpose
			// 
			this.ColumnPurpose.Format = "";
			this.ColumnPurpose.FormatInfo = null;
			this.ColumnPurpose.HeaderText = "Основание";
			this.ColumnPurpose.MappingName = "Purpose";
			this.ColumnPurpose.NullText = "-";
			this.ColumnPurpose.Width = 75;
			// 
			// ColumnRequestTypeName
			// 
			this.ColumnRequestTypeName.Format = "";
			this.ColumnRequestTypeName.FormatInfo = null;
			this.ColumnRequestTypeName.HeaderText = "Тип";
			this.ColumnRequestTypeName.MappingName = "RequestTypeName";
			this.ColumnRequestTypeName.Width = 50;
			// 
			// ColumnOrgNameTo
			// 
			this.ColumnOrgNameTo.Format = "";
			this.ColumnOrgNameTo.FormatInfo = null;
			this.ColumnOrgNameTo.HeaderText = "Получатель";
			this.ColumnOrgNameTo.MappingName = "OrgTo";
			this.ColumnOrgNameTo.NullText = "-";
			this.ColumnOrgNameTo.Width = 120;
			// 
			// ColumnRAccountTo
			// 
			this.ColumnRAccountTo.Format = "";
			this.ColumnRAccountTo.FormatInfo = null;
			this.ColumnRAccountTo.HeaderText = "Р/С Получателя";
			this.ColumnRAccountTo.MappingName = "AccountTo";
			this.ColumnRAccountTo.NullText = "-";
			this.ColumnRAccountTo.Width = 75;
			// 
			// ColumnRemarks
			// 
			this.ColumnRemarks.Format = "";
			this.ColumnRemarks.FormatInfo = null;
			this.ColumnRemarks.HeaderText = "Комментарий";
			this.ColumnRemarks.MappingName = "Remarks";
			this.ColumnRemarks.NullText = "-";
			this.ColumnRemarks.Width = 75;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.cbViewExceedSum);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.tbRequestPurpose);
			this.panel8.Controls.Add(this.tbRequestRemarks);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel8.Location = new System.Drawing.Point(0, 215);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(714, 68);
			this.panel8.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(117, 23);
			this.label7.TabIndex = 1;
			this.label7.Text = "Основание (Заявка):";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRequestPurpose
			// 
			this.tbRequestPurpose.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsRequestsNotLinked1, "GetRequestsNotLinked.Purpose"));
			this.tbRequestPurpose.Location = new System.Drawing.Point(122, 22);
			this.tbRequestPurpose.Name = "tbRequestPurpose";
			this.tbRequestPurpose.ReadOnly = true;
			this.tbRequestPurpose.Size = new System.Drawing.Size(516, 20);
			this.tbRequestPurpose.TabIndex = 0;
			this.tbRequestPurpose.Text = "";
			// 
			// tbRequestRemarks
			// 
			this.tbRequestRemarks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsRequestsNotLinked1, "GetRequestsNotLinked.Remarks"));
			this.tbRequestRemarks.Location = new System.Drawing.Point(122, 42);
			this.tbRequestRemarks.Name = "tbRequestRemarks";
			this.tbRequestRemarks.ReadOnly = true;
			this.tbRequestRemarks.Size = new System.Drawing.Size(516, 20);
			this.tbRequestRemarks.TabIndex = 0;
			this.tbRequestRemarks.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(108, 23);
			this.label8.TabIndex = 1;
			this.label8.Text = "Прим.  (Заявка):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(714, 8);
			this.panel7.TabIndex = 0;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "AccountsStatementsHeaders", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID"),
																																																								   new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																								   new System.Data.Common.DataColumnMapping("HeaderDate", "HeaderDate"),
																																																								   new System.Data.Common.DataColumnMapping("Confirmed", "Confirmed"),
																																																								   new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																								   new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																								   new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																								   new System.Data.Common.DataColumnMapping("KAccount", "KAccount")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT OrgsAccounts.OrgsAccountsID, AccountsStatementsHeaders.HeaderID, AccountsStatementsHeaders.HeaderDate, AccountsStatementsHeaders.Confirmed, Orgs.OrgName, Banks.BankName, OrgsAccounts.RAccount, Banks.KAccount, Banks.BankID, Orgs.OrgID FROM AccountsStatementsHeaders INNER JOIN OrgsAccounts ON AccountsStatementsHeaders.OrgAccountID = OrgsAccounts.OrgsAccountsID INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID INNER JOIN Banks ON OrgsAccounts.BankID = Banks.BankID ORDER BY AccountsStatementsHeaders.HeaderDate DESC, Orgs.OrgName, Banks.BankName";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GetOrgsUList", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																					  new System.Data.Common.DataColumnMapping("OrgName", "OrgName")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[GetOrgsUList]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GetOrgAccountsUList", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID"),
																																																							 new System.Data.Common.DataColumnMapping("OrgsAccountsWide", "OrgsAccountsWide"),
																																																							 new System.Data.Common.DataColumnMapping("OrgID", "OrgID")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[GetOrgAccountsUList]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GetPaymentsOrders", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																						   new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																						   new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																						   new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																						   new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																						   new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																						   new System.Data.Common.DataColumnMapping("KAccount", "KAccount"),
																																																						   new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																						   new System.Data.Common.DataColumnMapping("CityName", "CityName"),
																																																						   new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																						   new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																						   new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																						   new System.Data.Common.DataColumnMapping("ClientRequestID", "ClientRequestID"),
																																																						   new System.Data.Common.DataColumnMapping("RequestTypeName", "RequestTypeName"),
																																																						   new System.Data.Common.DataColumnMapping("RequestDate", "RequestDate"),
																																																						   new System.Data.Common.DataColumnMapping("ServiceCharge", "ServiceCharge"),
																																																						   new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																						   new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																						   new System.Data.Common.DataColumnMapping("PaymOrderLinked", "PaymOrderLinked")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "[GetPaymentsOrders]";
			this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand4.Connection = this.sqlConnection2;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GetRequestsNotLinked", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("RequestID", "RequestID"),
																																																							  new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID"),
																																																							  new System.Data.Common.DataColumnMapping("RequestTypeName", "RequestTypeName"),
																																																							  new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																							  new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							  new System.Data.Common.DataColumnMapping("RequestSum", "RequestSum"),
																																																							  new System.Data.Common.DataColumnMapping("AccountIDFrom", "AccountIDFrom"),
																																																							  new System.Data.Common.DataColumnMapping("AccountIDTo", "AccountIDTo"),
																																																							  new System.Data.Common.DataColumnMapping("OrgIDFrom", "OrgIDFrom"),
																																																							  new System.Data.Common.DataColumnMapping("OrgIDTo", "OrgIDTo"),
																																																							  new System.Data.Common.DataColumnMapping("OrgNameFrom", "OrgNameFrom"),
																																																							  new System.Data.Common.DataColumnMapping("OrgNameTo", "OrgNameTo"),
																																																							  new System.Data.Common.DataColumnMapping("RAccountFrom", "RAccountFrom"),
																																																							  new System.Data.Common.DataColumnMapping("RAccountTo", "RAccountTo"),
																																																							  new System.Data.Common.DataColumnMapping("BankNameFrom", "BankNameFrom"),
																																																							  new System.Data.Common.DataColumnMapping("BankNameTo", "BankNameTo"),
																																																							  new System.Data.Common.DataColumnMapping("KAccountFrom", "KAccountFrom"),
																																																							  new System.Data.Common.DataColumnMapping("KAccountTo", "KAccountTo"),
																																																							  new System.Data.Common.DataColumnMapping("RequestLinked", "RequestLinked")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "[GetRequestsNotLinked]";
			this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommandSetLink
			// 
			this.sqlCommandSetLink.CommandText = "[ClientsRequestLinkToTransaction]";
			this.sqlCommandSetLink.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommandSetLink.Connection = this.sqlConnection2;
			this.sqlCommandSetLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommandSetLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nClientRequestID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommandSetLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nLinkedTransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommandSetLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dServiceChargeValue", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommandDropLink
			// 
			this.sqlCommandDropLink.CommandText = "[ClientsRequestDropLinkToTransaction]";
			this.sqlCommandDropLink.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommandDropLink.Connection = this.sqlConnection2;
			this.sqlCommandDropLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommandDropLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nLinkedTransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbtnSetLink,
																						this.tbtnDropLink,
																						this.tbtnSetClientLink,
																						this.tbtnSetAsRevenue,
																						this.Separator1,
																						this.tbtnUnLinkedList,
																						this.tbbHistory,
																						this.Separator2,
																						this.tbtnFilterApply,
																						this.tbtnFilterClear,
																						this.tbtnRefresh});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imgButtons;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(1064, 28);
			this.toolBar1.TabIndex = 6;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbtnSetLink
			// 
			this.tbtnSetLink.ImageIndex = 0;
			this.tbtnSetLink.Text = "Связать";
			// 
			// tbtnDropLink
			// 
			this.tbtnDropLink.ImageIndex = 1;
			this.tbtnDropLink.Text = "Разорвать";
			// 
			// tbtnSetClientLink
			// 
			this.tbtnSetClientLink.ImageIndex = 9;
			this.tbtnSetClientLink.Text = "Связать с Кл.";
			// 
			// tbtnSetAsRevenue
			// 
			this.tbtnSetAsRevenue.ImageIndex = 8;
			this.tbtnSetAsRevenue.Text = "В Доход";
			// 
			// Separator1
			// 
			this.Separator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnUnLinkedList
			// 
			this.tbtnUnLinkedList.ImageIndex = 6;
			this.tbtnUnLinkedList.Text = "Неопознанные";
			this.tbtnUnLinkedList.Visible = false;
			// 
			// tbbHistory
			// 
			this.tbbHistory.ImageIndex = 7;
			this.tbbHistory.Text = "История";
			// 
			// Separator2
			// 
			this.Separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnFilterApply
			// 
			this.tbtnFilterApply.ImageIndex = 4;
			this.tbtnFilterApply.Text = "Выбрать";
			// 
			// tbtnFilterClear
			// 
			this.tbtnFilterClear.ImageIndex = 5;
			this.tbtnFilterClear.Text = "Очистить";
			// 
			// tbtnRefresh
			// 
			this.tbtnRefresh.ImageIndex = 2;
			this.tbtnRefresh.Text = "Обновить";
			// 
			// imgButtons
			// 
			this.imgButtons.ImageSize = new System.Drawing.Size(16, 16);
			this.imgButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgButtons.ImageStream")));
			this.imgButtons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlCommand1;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "PaymentsOrders", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																						new System.Data.Common.DataColumnMapping("HeaderDate", "HeaderDate"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																						new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																						new System.Data.Common.DataColumnMapping("Confirmed", "Confirmed"),
																																																						new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																						new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																						new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																						new System.Data.Common.DataColumnMapping("RAccountContra", "RAccountContra"),
																																																						new System.Data.Common.DataColumnMapping("OrgNameContra", "OrgNameContra"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																						new System.Data.Common.DataColumnMapping("CodeINNContra", "CodeINNContra")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = @"SELECT AccountsStatementsHeaders.HeaderID, AccountsStatementsHeaders.HeaderDate, PaymentsOrders.PaymentOrderID, PaymentsOrders.PaymentNo, PaymentsOrders.PaymentOrderDate, AccountsStatementsHeaders.Confirmed, OrgsAccounts.RAccount, Orgs.OrgName, Orgs.CodeINN, OrgsAccounts_1.RAccount AS RAccountContra, Orgs_1.OrgName AS OrgNameContra, PaymentsOrders.PaymentOrderSum, PaymentsOrders.PaymentOrderPurpose, Orgs_1.CodeINN AS CodeINNContra, OrgsAccounts_1.OrgsAccountsID, Orgs_1.OrgID, OrgsAccounts.OrgsAccountsID AS OrgsAccountsIDContra, Orgs.OrgID AS OrgIDContra, PaymentsOrders.Remarks, Transactions.TransactionID FROM PaymentsOrders INNER JOIN AccountsStatementsHeaders ON PaymentsOrders.HeaderID = AccountsStatementsHeaders.HeaderID INNER JOIN OrgsAccounts ON AccountsStatementsHeaders.OrgAccountID = OrgsAccounts.OrgsAccountsID INNER JOIN Accounts ON OrgsAccounts.AccountID = Accounts.AccountID INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID INNER JOIN OrgsAccounts OrgsAccounts_1 ON PaymentsOrders.OrgAccountIDCorr = OrgsAccounts_1.OrgsAccountsID INNER JOIN Orgs Orgs_1 ON OrgsAccounts_1.OrgID = Orgs_1.OrgID LEFT OUTER JOIN Transactions ON PaymentsOrders.PaymentOrderID = Transactions.DocumentID WHERE (AccountsStatementsHeaders.Confirmed = 1) AND (PaymentsOrders.Direction = 1) AND (Transactions.TransactionTypeID = 1 OR Transactions.TransactionTypeID = 10) AND (Transactions.ClientRequestID IS NULL) AND (Transactions.TransactionCommited = 1) AND (Transactions.TransactionPosted = 0)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			// 
			// sqlCmdSetLinkByClient
			// 
			this.sqlCmdSetLinkByClient.CommandText = "[ClientsRequestLinkToTransactionAuto]";
			this.sqlCmdSetLinkByClient.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetLinkByClient.Connection = this.sqlConnection2;
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nPaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dServiceChargeValue", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdSetTypeRevenue
			// 
			this.sqlCmdSetTypeRevenue.CommandText = "[ChangeTransactionSetTypeRevenue]";
			this.sqlCmdSetTypeRevenue.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetTypeRevenue.Connection = this.sqlConnection2;
			this.sqlCmdSetTypeRevenue.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetTypeRevenue.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nTransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdGetServiceCharge
			// 
			this.sqlCmdGetServiceCharge.CommandText = "[GetServiceChargeByClientByOrg]";
			this.sqlCmdGetServiceCharge.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdGetServiceCharge.Connection = this.sqlConnection2;
			this.sqlCmdGetServiceCharge.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetServiceCharge.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetServiceCharge.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nOrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetServiceCharge.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bMode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdGetServiceCharge.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fServiceCharge", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(15)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cbViewExceedSum
			// 
			this.cbViewExceedSum.Location = new System.Drawing.Point(14, 2);
			this.cbViewExceedSum.Name = "cbViewExceedSum";
			this.cbViewExceedSum.Size = new System.Drawing.Size(624, 18);
			this.cbViewExceedSum.TabIndex = 2;
			this.cbViewExceedSum.Text = "НЕ показывать заявки с выполненной суммой, превышающей сумму заявки";
			this.cbViewExceedSum.Visible = false;
			this.cbViewExceedSum.CheckedChanged += new System.EventHandler(this.cbViewExceedSum_CheckedChanged);
			// 
			// PaymentsOrdersRecognition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1064, 629);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PaymentsOrdersRecognition";
			this.Text = "Распознание Платежей";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgAccStatementsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAccStatementsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccStatementsList1)).EndInit();
			this.panel10.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsUList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsUList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgAccountsUList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgAccountsUList1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgAccStatementDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccStatementsListDetails1)).EndInit();
			this.panel5.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnknownList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentsOrdersUnknownList1)).EndInit();
			this.panel13.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgRequestsNotLinked)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRequestsNotLinked1)).EndInit();
			this.panel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Controls Filling

		private void PaymentsOrdersList_Refresh()
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvAccStatementsList];
			DataRowView drv  =(DataRowView) bm.Current;
			//
			this.sqlDataAdapter4.SelectCommand.Parameters["@HeaderID"].Value =System.Convert.ToInt32(drv["HeaderID"]);
			
			this.m_CurrentPaymentOrderID  =0;

			try 
			{
				this.dsAccStatementsListDetails1.Tables["GetPaymentsOrders"].Clear();
				this.sqlDataAdapter4.Fill( this.dsAccStatementsListDetails1, "GetPaymentsOrders");

				this.dgAccStatementDetails.CurrentRowIndex =0; //Drop DataGrig control selection 
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ClientsRequestsList_Refresh()
		{
			try 
			{
				this.m_CurrentClientRequestID =0;

				this.dsRequestsNotLinked1.Tables["GetRequestsNotLinked"].Clear();
				this.sqlDataAdapter5.Fill( this.dsRequestsNotLinked1, "GetRequestsNotLinked");
				
				this.dgRequestsNotLinked.CurrentRowIndex =0; //Drop DataGrig control selection

			}
			catch(Exception ex)
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PaymentsOrdersUnknownList_Refresh()
		{
			try 
			{
				this.dsPaymentsOrdersUnknownList1.PaymentsOrders.Clear();
				this.sqlDataAdapter6.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders);
 
				this.dataGrid1.CurrentRowIndex =0;
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormDataReFill()
		{
			try 
			{
				Cursor.Current =Cursors.WaitCursor;

				this.dsAccStatementsList1.AccountsStatementsHeaders.Clear();
				this.sqlDataAdapter1.Fill( this.dsAccStatementsList1);

				this.dsOrgsUList1.GetOrgsUList.Clear(); 
				this.sqlDataAdapter2.Fill( this.dsOrgsUList1);

				this.dsOrgAccountsUList1.GetOrgAccountsUList.Clear(); 
				this.sqlDataAdapter3.Fill( this.dsOrgAccountsUList1);
 
				this.dsRequestsNotLinked1.Tables["GetRequestsNotLinked"].Clear();
				this.sqlDataAdapter5.Fill( this.dsRequestsNotLinked1, "GetRequestsNotLinked");

				this.dsPaymentsOrdersUnknownList1.PaymentsOrders.Clear();
				this.sqlDataAdapter6.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders);
 
				this.dataGrid1.CurrentRowIndex			 =0;
				this.dgAccStatementsList.CurrentRowIndex =0;
				this.dgRequestsNotLinked.CurrentRowIndex =0;
 
				//this.CurrentStatementChanged		( null, null);
				//this.CurrentPaymentOrderChanged	( null, null);
				//this.CurrentRequestChanged		( null, null); 
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Ошибка чтения данных: " +ex.Message.ToString(), "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
			}
			finally 
			{
				Cursor.Current =Cursors.Default;
			}
		}

		#endregion

		#region Controls Events

		private void cmbOrg_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int nOrgID =0;

			if (this.cmbOrg.SelectedIndex >=0) 
			{
				nOrgID =System.Convert.ToInt32( this.cmbOrg.SelectedValue);
				if ( nOrgID >0) 
				{
					this.dvOrgAccountsUList.RowFilter ="([OrgID]=" +nOrgID.ToString() +") OR [OrgsAccountsID] =0";
					this.dvOrgAccountsUList.Sort ="[OrgsAccountsWide]"; 
				}
				else 
				{
					this.dvOrgAccountsUList.RowFilter ="";
					this.dvOrgAccountsUList.Sort ="[OrgsAccountsWide]"; 
				}
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool bBtnEn =false;
			
			bBtnEn =(this.tabControl1.SelectedIndex ==0);
			
			this.tbtnSetClientLink.Enabled	=!bBtnEn;  
			this.tbtnSetAsRevenue.Enabled	=!bBtnEn;  
			this.tbtnDropLink.Enabled		=bBtnEn;  
			this.tbtnSetLink.Enabled		=bBtnEn;  
		}

		#endregion

		#region Currencies
		private void CurrentStatementChanged(object sender, System.EventArgs e) 
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvAccStatementsList];
			if ( bm.Position <0)
				return;
			DataRowView drv  =(DataRowView) bm.Current;
			//
			this.sqlDataAdapter4.SelectCommand.Parameters["@HeaderID"].Value =System.Convert.ToInt32(drv["HeaderID"]);
			
			this.m_CurrentPaymentOrderID  =0;
			//this.m_CurrentClientRequestID =0; 

			try 
			{
				this.dsAccStatementsListDetails1.Tables["GetPaymentsOrders"].Clear();
				this.sqlDataAdapter4.Fill( this.dsAccStatementsListDetails1, "GetPaymentsOrders");

				this.dgAccStatementDetails.CurrentRowIndex =0; //Drop DataGrig control selection 
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void CurrentPaymentOrderChanged(object sender, System.EventArgs e) 
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsAccStatementsListDetails1,"GetPaymentsOrders"];
			if ( bm.Position <0) //If DataSet is Empty
			{
				this.m_CurrentPaymentOrderID =0;
			}
			else 
			{
				BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow rw = 
					(BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow)((DataRowView)bm.Current).Row;
			
				this.m_CurrentPaymentOrderID =rw.PaymentOrderID;
			}
		}
		
		private void CurrentRequestChanged(object sender, System.EventArgs e) 
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsRequestsNotLinked1,"GetRequestsNotLinked"];
			if ( bm.Position <0) //If DataSet is Empty
			{
				this.m_CurrentClientRequestID =0;
			}
			else
			{
				_Forms.dsRequestsNotLinked.GetRequestsNotLinkedRow rw =
					(_Forms.dsRequestsNotLinked.GetRequestsNotLinkedRow)((DataRowView)bm.Current).Row;

				this.m_CurrentClientRequestID =rw.RequestID;
			}
		}
		
		#endregion

		#region Account Statement Linking
		
		private void LinkSet() 
		{
			double dServiceCharge =0;
			System.Globalization.CultureInfo ci =new System.Globalization.CultureInfo(""); 
			
			BindingManagerBase bmPayms = (BindingManagerBase)this.BindingContext[this.dsAccStatementsListDetails1, "GetPaymentsOrders"];
			if ( bmPayms.Position <0) //If DataSet is Empty
			{
				MessageBox.Show("Связывание отменено: Не указано Входящее платёжное поручение.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			BindingManagerBase bmRequests = (BindingManagerBase)this.BindingContext[this.dsRequestsNotLinked1, "GetRequestsNotLinked"];
			if ( bmRequests.Position <0) //If DataSet is Empty
			{
				MessageBox.Show("Связывание отменено: Не указана Заявка клиента.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			_Forms.dsRequestsNotLinked.GetRequestsNotLinkedRow rwRequest =
				(_Forms.dsRequestsNotLinked.GetRequestsNotLinkedRow)((DataRowView)bmRequests.Current).Row;
			
			BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow  rwPaym = 
				(BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow)((DataRowView)bmPayms.Current).Row;
			
			if ( !rwPaym.Direction) 
			{
				MessageBox.Show("Связывание отменено: Связывание допустимо только для приходных платёжных поручений.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( !rwPaym.IsClientRequestIDNull()) 
			{
				MessageBox.Show("Связывание отменено: Связь уже существует.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( rwRequest.RequestTypeID !=1) 
			{
				MessageBox.Show("Связывание отменено: Связывание допустимо только для заявок на приём.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			// Проверка на совпадение имён организаций
			//
			if (( rwPaym.IsNull("OrgName")) || ( rwRequest.IsNull("OrgFrom"))) 
			{
				if ( rwPaym.IsNull("OrgName")) 
				{
					if ( DialogResult.No ==MessageBox.Show("Невозможно определить Организацию получателя. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						return;
				}
				if ( rwRequest.IsNull("OrgFrom")) 
				{
					if ( DialogResult.No ==MessageBox.Show("Невозможно определить Организацию отправителя. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						return;
				}
			}
			else 
			{
				if ( String.Compare( rwPaym.OrgName, rwRequest.OrgFrom, true, ci) !=0) 
				{
					if ( DialogResult.No ==MessageBox.Show("Несовпадение имён организаций в Завке и Платёжном поручении. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						return;
				}
			}
			// Проверка на совпадение расчётных счётов
			//
			if (( rwPaym.IsNull("RAccount")) || ( rwRequest.IsNull("AccountFrom"))) 
			{
				if ( rwPaym.IsNull("RAccount"))
				{
					if ( DialogResult.No ==MessageBox.Show("Невозможно определить Расчётный Счёт получателя. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						return;
				}
				if ( rwRequest.IsNull("AccountFrom"))
				{
					if ( DialogResult.No ==MessageBox.Show("Невозможно определить Расчётный Счёт отправителя. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						return;
				}
			}
			else 
			{
				if ( String.Compare( rwPaym.RAccount, rwRequest.AccountFrom, true, ci) !=0) 
				{
					if ( DialogResult.No ==MessageBox.Show("Несовпадение р/с организаций в Заявке и Платёжном поручении. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						return;
				}
			}
			// Проверка Сумм
			//
			if ( rwRequest.RequiredSum <rwPaym.PaymentOrderSum) 
			{
				if ( DialogResult.No ==MessageBox.Show("Сумма в Платёжном поручении превышает сумму в Заявке. Связать?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
					return;
			}
			// Проверка Валют
			// ?
			_Forms.RequestLinkParams frm =new _Forms.RequestLinkParams(rwRequest);
			
			//frm.PercentValue =0.05;
			frm.ShowDialog();
			
			if ( frm.DialogResult ==DialogResult.OK) 
			{
				dServiceCharge =frm.PercentValue; 
			}
			else 
			{
				MessageBox.Show("Связывание отменено: Операция прервана пользователем.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (dServiceCharge >=1) 
			{
				MessageBox.Show("Связывание отменено: Недопустимое значение (>100) процента обслуживания.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try 
			{
				this.sqlCommandSetLink.Parameters["@nClientRequestID"].Value		=rwRequest.RequestID;
				this.sqlCommandSetLink.Parameters["@nLinkedTransactionID"].Value	=rwPaym.TransactionID;
				this.sqlCommandSetLink.Parameters["@dServiceChargeValue"].Value		=dServiceCharge;
				App.ExecSql(this.sqlCommandSetLink);

				this.PaymentsOrdersList_Refresh();
				this.ClientsRequestsList_Refresh(); 
				this.PaymentsOrdersUnknownList_Refresh();
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Связывание отменено: При связывании возникла ошибка:" +ex.Message +".", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void LinkDrop()
		{
			BindingManagerBase bmPayms = (BindingManagerBase)this.BindingContext[this.dsAccStatementsListDetails1, "GetPaymentsOrders"];
			if ( bmPayms.Position <0) //If DataSet is Empty
			{
				MessageBox.Show("Удаление связи отменено: Не указано Входящее платёжное поручение.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow  rwPaym = 
				(BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow)((DataRowView)bmPayms.Current).Row;

			if ( !rwPaym.Direction) 
			{
				MessageBox.Show("Удаление связи отменено: Операция допустима только для приходных платёжных поручений.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( rwPaym.IsClientRequestIDNull()) 
			{
				MessageBox.Show("Удаление связи отменено: Связь уже удалена.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			if (DialogResult.No ==MessageBox.Show("Разорвать связь?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				MessageBox.Show("Удаление связи отменено: Операция прервана пользователем.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try 
			{
				this.sqlCommandDropLink.Parameters["@nLinkedTransactionID"].Value =rwPaym.TransactionID;
				App.ExecSql(this.sqlCommandDropLink);

				this.PaymentsOrdersList_Refresh();
				this.ClientsRequestsList_Refresh(); 
				this.PaymentsOrdersUnknownList_Refresh();
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Удаление связи отменено: При удалении связи возникла ошибка:" +ex.Message +".", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SetLinkByClient()
		{
			int nClientID			=0;
			int nPaymOrderID		=0;
			double dServiceCharge	=0;

			if (DialogResult.No ==MessageBox.Show("Произвести привязку к Клиенту, Вы уверены?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
				return;
			
			BindingManagerBase bmPaymOrder = (BindingManagerBase)this.BindingContext[this.dvUnknownList];
			if ( bmPaymOrder.Position <0) //If DataSet is Empty
			{
				MessageBox.Show("Связывание отменено: Не указан платёжный Документ.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow rwPaymOrder =
				(_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow)((DataRowView)bmPaymOrder.Current).Row;
			
			nPaymOrderID =rwPaymOrder.PaymentOrderID;
			dServiceCharge =this.tbServiceCharge.dValue;
  
			if (dServiceCharge <0) 
			{
				MessageBox.Show("Связывание отменено: Процент обслуживания не может быть отрицательным.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (dServiceCharge <0.000001)
				if (DialogResult.No ==MessageBox.Show("Стоимость обслуживания равна 0. Продолжить?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
					return;
			
			if (this.cmbClients.SelectedIndex <0) 
			{
				MessageBox.Show("Связывание отменено: Не указан Клиент.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			nClientID =(int)this.cmbClients.SelectedValue;  
			
			try 
			{
				this.sqlCmdSetLinkByClient.Parameters["@nPaymentOrderID"].Value			=nPaymOrderID;
				this.sqlCmdSetLinkByClient.Parameters["@nClientID"].Value				=nClientID;
				this.sqlCmdSetLinkByClient.Parameters["@dServiceChargeValue"].Value		=dServiceCharge;
				App.ExecSql(this.sqlCmdSetLinkByClient);

				//this.dsPaymentsOrdersUnknownList1.PaymentsOrders.Clear();
				//this.sqlDataAdapter6.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders);
				//
				//this.dataGrid1.CurrentRowIndex =0;
				this.PaymentsOrdersUnknownList_Refresh();
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Связывание отменено: При связывании возникла ошибка:" +ex.Message +".", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void SetAsRevenue()
		{
			int nTransID			=0;

			if (DialogResult.No ==MessageBox.Show("Изменить Тип Транзакции, Вы уверены?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
				return;
			
			BindingManagerBase bmPaymOrder = (BindingManagerBase)this.BindingContext[this.dvUnknownList];
			if ( bmPaymOrder.Position <0) //If DataSet is Empty
			{
				MessageBox.Show("Связывание отменено: Не указан платёжный Документ.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow rwPaymOrder =
				(_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow)((DataRowView)bmPaymOrder.Current).Row;
			
			nTransID =rwPaymOrder.TransactionID;
  
			try 
			{
				this.sqlCmdSetTypeRevenue.Parameters["@nTransactionID"].Value =nTransID;
				App.ExecSql(this.sqlCmdSetTypeRevenue);

				this.dsPaymentsOrdersUnknownList1.PaymentsOrders.Clear();
				this.sqlDataAdapter6.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders);
 
				this.dataGrid1.CurrentRowIndex =0;
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Связывание отменено: При изменении типа возникла ошибка:" +ex.Message +".", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		#endregion

		#region Account Statements Filter

		private void FilterApply()
		{
			string szRowFilter	="";
			

			 StatementsListFill( this.ucStatementsPeriodSimple._cbDateFrom, 
										this.ucStatementsPeriodSimple._cbDateTill, 
										this.ucStatementsPeriodSimple._DateFrom,
										this.ucStatementsPeriodSimple._DateTill);	
				
				int nOrgID			=0;
				int nOrgAccountID	=0;

				nOrgID =System.Convert.ToInt32( this.cmbOrg.SelectedValue); 
				nOrgAccountID =System.Convert.ToInt32( this.cmbOrgAccount.SelectedValue); 

				if ( nOrgID >0) 
					szRowFilter ="([OrgID] =" +nOrgID.ToString() +")";
				if ( nOrgAccountID >0) 
				{
					if (szRowFilter.Length >0)
						szRowFilter +=" AND ";
					szRowFilter +="([OrgsAccountsID]= " +nOrgAccountID.ToString() +")";
				}

			this.dvAccStatementsList.RowFilter =szRowFilter; 
		}
		
		private bool StatementsListFill( bool bDateFrom, bool bDateTill, DateTime dtDateFrom, DateTime dtDateTill)
		{
			//SELECT OrgsAccounts.OrgsAccountsID, AccountsStatementsHeaders.HeaderID, AccountsStatementsHeaders.HeaderDate, 
			//AccountsStatementsHeaders.Confirmed, Orgs.OrgName, Banks.BankName, OrgsAccounts.RAccount, Banks.KAccount, 
			//Banks.BankID, Orgs.OrgID FROM AccountsStatementsHeaders INNER JOIN OrgsAccounts ON AccountsStatementsHeaders.OrgAccountID 
			//= OrgsAccounts.OrgsAccountsID INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID INNER JOIN Banks ON OrgsAccounts.BankID 
			//= Banks.BankID ORDER BY AccountsStatementsHeaders.HeaderDate DESC, Orgs.OrgName, Banks.BankName

			string szCmdText	="";
			string szOrderBy	="";
			string szWhere		="";
			string szDateFrom	="";
			string szDateTill	="";

			szCmdText ="SELECT OrgsAccounts.OrgsAccountsID, AccountsStatementsHeaders.HeaderID, AccountsStatementsHeaders.HeaderDate," 
				+ " AccountsStatementsHeaders.Confirmed, Orgs.OrgName, Banks.BankName, OrgsAccounts.RAccount, Banks.KAccount," 
				+ " Banks.BankID, Orgs.OrgID FROM AccountsStatementsHeaders INNER JOIN OrgsAccounts ON AccountsStatementsHeaders.OrgAccountID" 
				+ " = OrgsAccounts.OrgsAccountsID INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID INNER JOIN Banks ON OrgsAccounts.BankID" 
				+ " = Banks.BankID";
			szOrderBy =" ORDER BY AccountsStatementsHeaders.HeaderDate DESC, Orgs.OrgName, Banks.BankName";

			if ( bDateFrom || bDateTill) 
			{
				szWhere =" WHERE ";
				if ( bDateFrom) 
				{
					szDateFrom =this.TranslateDate( dtDateFrom, false); 
					szWhere +="(AccountsStatementsHeaders.HeaderDate >= " +szDateFrom +")";
				}
				if ( bDateTill) 
				{
					szDateTill =this.TranslateDate( dtDateTill, true); 
					if ( bDateFrom) szWhere +=" AND ";
					szWhere +="(AccountsStatementsHeaders.HeaderDate <= " +szDateTill +")";
				}
			}
			szCmdText =szCmdText +szWhere +szOrderBy;

			try 
			{
				this.dsAccStatementsList1.AccountsStatementsHeaders.Clear();
				this.sqlDataAdapter1.SelectCommand.CommandText =szCmdText; 
				this.sqlDataAdapter1.Fill( this.dsAccStatementsList1);
				
				this.dgAccStatementsList.CurrentRowIndex =0;

				return true;
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Ошибка чтения данных: " +ex.Message.ToString(), "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);   
				return false;
			}
		}

		private void FilterClear()
		{
			this.cmbOrg.SelectedIndex =0;
			this.cmbOrgAccount.SelectedIndex =0;
			this.ucStatementsPeriodSimple._PeriodType =AM_Controls.Span.LastTwoWorkingDays;
		}

		#endregion

		#region ToolBar and Buttons

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbtnSetLink)
				this.LinkSet();
			else if (e.Button == this.tbtnDropLink)
				this.LinkDrop();
			else if(e.Button == this.tbbHistory)
			{
				this.showPaymentsOrdersHistory();
			}
			else if (e.Button == this.tbtnFilterApply)
				this.FilterApply( );
			else if (e.Button == this.tbtnFilterClear)
				this.FilterClear();
			else if (e.Button == this.tbtnRefresh)
				this.FormDataReFill();
			else if (e.Button == this.tbtnSetClientLink )//tbtnSetAsRevenue
				this.SetLinkByClient();
			else if (e.Button == this.tbtnSetAsRevenue )
				this.SetAsRevenue();
			else if (e.Button == this.tbtnUnLinkedList) 
			{
				//BPS.App.FindOpenedForm(typeof(BPS._Forms.PaymsOrdersUnknownList));
				foreach( Form f in this.MdiParent.MdiChildren) 
				{
					if (f.GetType()==typeof(BPS._Forms.PaymsOrdersUnknownList))
					{
						f.Show();
						f.Activate();
						return;
					}
				}
				
				BPS._Forms.PaymsOrdersUnknownList frmList =new BPS._Forms.PaymsOrdersUnknownList();
				frmList.MdiParent =this.MdiParent; 
				frmList.TopMost =true;
				frmList.Show();
			}
			else 
				MessageBox.Show("Unknown Error occured.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		private void btnGetLast_Click(object sender, System.EventArgs e)
		{
			int nOrgID		=0;
			int nClientID	=0;
			
			if ( this.cmbClients.SelectedIndex >=0 ) 
			{
				BindingManagerBase bmPaymOrder = (BindingManagerBase)this.BindingContext[this.dvUnknownList];
				if ( bmPaymOrder.Position <0) //If DataSet is Empty
				{
					this.tbServiceCharge.dValue =0;
					return;
				}
				_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow rwPaymOrder =
					(_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow)((DataRowView)bmPaymOrder.Current).Row;
			
				nOrgID =rwPaymOrder.OrgIDContra;
				nClientID =(int)this.cmbClients.SelectedValue;

				this.tbServiceCharge.dValue =GetRecentlyUsedServiceCharge( nOrgID, nClientID,true); 
			}		
		}

		#endregion

		private void showPaymentsOrdersHistory()
		{
			BindingManagerBase bm;

			string szINN		="";
			string szOrgName	="";
			string szRAccount	="";

			if (this.tabControl1.SelectedIndex ==0) 
			{
				bm = this.BindingContext[this.dsAccStatementsListDetails1,"GetPaymentsOrders"];
				if ( bm.Position <0) return;
				
				BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow rw1 = (BLL.AccountStatements.dsAccStatementsListDetails.GetPaymentsOrdersRow) ((DataRowView) bm.Current).Row;
				DataRow [] dr = App.DsOrgs.Orgs.Select("OrgID=" + rw1.OrgID);
				
				if ( dr.Length !=1)
				{
					MessageBox.Show("Невозможно определить организацию получателя.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				szINN		=dr[0]["CodeINN"].ToString();
				szOrgName	=rw1.OrgName;
				szRAccount	=rw1.RAccount;
			}
			else 
			{
				bm = this.BindingContext[this.dvUnknownList];
				dsPaymentsOrdersUnknownList.PaymentsOrdersRow rw2 = (dsPaymentsOrdersUnknownList.PaymentsOrdersRow) ((DataRowView) bm.Current).Row;
				szINN		=rw2.CodeINNContra;
				szOrgName	=rw2.OrgNameContra;
				szRAccount	=rw2.RAccountContra;
			}

			PaymentsOrdersLinkHistory frmHistory = new PaymentsOrdersLinkHistory();
			frmHistory.SelectClient += new PaymentsOrdersLinkHistory.SelectClientEventHandler(select_Client);
			frmHistory.UpdateList( szRAccount, szOrgName, szINN);
			frmHistory.ShowDialog();
		}

		private void select_Client(int ClientID)
		{
			this.cmbClients.SelectedValue = ClientID;
			BindingManagerBase bmPaymOrder = (BindingManagerBase)this.BindingContext[this.dvUnknownList];
			if ( bmPaymOrder.Position <0) //If DataSet is Empty
			{
				this.tbServiceCharge.dValue =0;
				return;
			}
			_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow rwPaymOrder =
				(_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow)((DataRowView)bmPaymOrder.Current).Row;

			int nOrgID = rwPaymOrder.OrgIDContra;
			this.tbServiceCharge.dValue = GetRecentlyUsedServiceCharge( nOrgID, ClientID, false); 
		}

		private string TranslateDate(DateTime dt, bool bUp)
		{
			string szTime =( bUp)?("23:59:59"):("00:00:00");
			return  "CONVERT(DATETIME, '" +dt.Year.ToString() +"-" +dt.Month.ToString() +"-" +dt.Day.ToString() +" " +szTime +"', 102)";
		}

		private double GetRecentlyUsedServiceCharge(int nOrgID, int nClientID, bool bMode) 
		{
			try 
			{
				this.sqlCmdGetServiceCharge.Parameters["@nOrgID"].Value		=nOrgID;
				this.sqlCmdGetServiceCharge.Parameters["@nClientID"].Value	=nClientID;
				this.sqlCmdGetServiceCharge.Parameters["@bMode"].Value		=bMode;
				App.ExecSql(this.sqlCmdGetServiceCharge);
				
				if ((int)this.sqlCmdGetServiceCharge.Parameters["@RETURN_VALUE"].Value ==2) 
				{
					MessageBox.Show("Невозможно определить последний используемый % Обслуживания: Нет операций.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return 0;
				}
			
				return((double)this.sqlCmdGetServiceCharge.Parameters["@fServiceCharge"].Value);
			}
			catch(Exception ex) 
			{
				MessageBox.Show("При определении %% Обслуживания возникла ошибка:" +ex.Message +".", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		private void cbViewExceedSum_CheckedChanged(object sender, System.EventArgs e)
		{

			//if ( this.cbViewExceedSum.Checked)		
			//	this.dsRequestsNotLinked1.Tables["GetRequestsNotLinked"].d.Ts.DefaultView.RowFilter ="[ExecutedSum]>[RequestSum]";
			//else
			//	this.dsRequestsNotLinked1.Tables["GetRequestsNotLinked"].DefaultView.RowFilter ="";
		}
	}
}
