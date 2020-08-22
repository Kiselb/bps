using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AM_Controls;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for Balance.
	/// </summary>
	public class Balance : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private BPS._Forms.dsBalanceAccountsState dsBalanceAccountsState1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGrid dgAccountsState;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnAccountTypeID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSumSaldo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnCurrencyID;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ToolBarButton tbtnRefresh;
		private System.Windows.Forms.ImageList imageList1;
		private AM_Controls.TextBoxV tbSumSettlement;
		private AM_Controls.TextBoxV tbSumOuter;
		private AM_Controls.TextBoxV tbSumPersonal;
		private AM_Controls.TextBoxV tbSumCash;
		private AM_Controls.TextBoxV tbSumService;
		private AM_Controls.TextBoxV tbSumProgress;
		private AM_Controls.TextBoxV tbBalance;
		private AM_Controls.TextBoxV tbSumExpenditure;
		private AM_Controls.TextBoxV tbSumRevenue;
		private AM_Controls.TextBoxV tbState;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private AM_Controls.TextBoxV tbUnknownIncomes;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuRefresh;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSumSumReserved;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSumSumWaited;
		private AM_Controls.TextBoxV tbSumOuterR;
		private AM_Controls.TextBoxV tbSumSettlementR;
		private AM_Controls.TextBoxV tbSumCashR;
		private AM_Controls.TextBoxV tbSumOuterW;
		private AM_Controls.TextBoxV tbSumSettlementW;
		private AM_Controls.TextBoxV tbSumCashW;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private AM_Controls.TextBoxV tbSumOuterA;
		private AM_Controls.TextBoxV tbSumSettlementA;
		private AM_Controls.TextBoxV tbSumCashA;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private AM_Controls.TextBoxV textBoxV9;
		private AM_Controls.TextBoxV textBoxV6;
		private AM_Controls.TextBoxV textBoxV7;
		private AM_Controls.TextBoxV tbSumPersonalA;
		private AM_Controls.TextBoxV tbStateW;
		private AM_Controls.TextBoxV tbStateA;
		private AM_Controls.TextBoxV tbSumPersonalR;
		private AM_Controls.TextBoxV tbStateR;
		private AM_Controls.TextBoxV tbSumPersonalW;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSumSumFree;
		private System.Windows.Forms.Label label20;
		private AM_Controls.TextBoxV textBoxV1;
		private System.Windows.Forms.Label label21;
		private AM_Controls.TextBoxV textBoxV2;
		private AM_Controls.TextBoxV textBoxV3;
		private AM_Controls.TextBoxV tbUnknownRevenue;
		private System.Windows.Forms.Label label22;
		private AM_Controls.TextBoxV textBoxV5;
		private AM_Controls.TextBoxV textBoxV8;
		private AM_Controls.TextBoxV textBoxV10;
		private AM_Controls.TextBoxV tbSumCredits;
		private AM_Controls.TextBoxV tbBalanceReserved;
		private AM_Controls.TextBoxV tbBalanceWaited;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private AM_Controls.TextBoxV tbTransferTotals;
		private AM_Controls.TextBoxV tbTransferShort;
		private AM_Controls.TextBoxV tbTransferLong;
		private System.Windows.Forms.Label label30;
		private AM_Controls.TextBoxV textBoxV4;
		private AM_Controls.TextBoxV tbUnknownExpenditure;
		private AM_Controls.TextBoxV textBoxV12;
		private AM_Controls.TextBoxV textBoxV13;
		private System.Windows.Forms.Label label31;
		private AM_Controls.TextBoxV textBoxV11;
		private AM_Controls.TextBoxV textBoxV14;
		private AM_Controls.TextBoxV textBoxV15;
		private AM_Controls.TextBoxV tbSumCreditsOut;
		private System.Windows.Forms.Label label32;
		private AM_Controls.TextBoxV tbSumCreditsIn;
		private AM_Controls.TextBoxV textBoxV17;
		private AM_Controls.TextBoxV textBoxV18;
		private AM_Controls.TextBoxV textBoxV19;
		private System.Windows.Forms.Label label33;
		private AM_Controls.TextBoxV tbSumExchange;
		private AM_Controls.TextBoxV tbSumTransit;
		private System.ComponentModel.IContainer components;

		public Balance()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//App.OnSetStyle( this.dataGridTableStyle1);
			this.DataRefresh();
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Balance));
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsBalanceAccountsState1 = new BPS._Forms.dsBalanceAccountsState();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.tbSumOuter = new AM_Controls.TextBoxV();
			this.label1 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbSumPersonal = new AM_Controls.TextBoxV();
			this.label7 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tbSumSettlement = new AM_Controls.TextBoxV();
			this.tbState = new AM_Controls.TextBoxV();
			this.label2 = new System.Windows.Forms.Label();
			this.tbUnknownIncomes = new AM_Controls.TextBoxV();
			this.tbSumCash = new AM_Controls.TextBoxV();
			this.label10 = new System.Windows.Forms.Label();
			this.tbBalance = new AM_Controls.TextBoxV();
			this.tbSumOuterR = new AM_Controls.TextBoxV();
			this.tbSumSettlementR = new AM_Controls.TextBoxV();
			this.tbSumCashR = new AM_Controls.TextBoxV();
			this.tbSumOuterW = new AM_Controls.TextBoxV();
			this.tbSumSettlementW = new AM_Controls.TextBoxV();
			this.tbSumCashW = new AM_Controls.TextBoxV();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.tbSumOuterA = new AM_Controls.TextBoxV();
			this.tbSumSettlementA = new AM_Controls.TextBoxV();
			this.label16 = new System.Windows.Forms.Label();
			this.tbSumCashA = new AM_Controls.TextBoxV();
			this.label17 = new System.Windows.Forms.Label();
			this.tbSumPersonalA = new AM_Controls.TextBoxV();
			this.tbStateW = new AM_Controls.TextBoxV();
			this.tbStateA = new AM_Controls.TextBoxV();
			this.label18 = new System.Windows.Forms.Label();
			this.tbSumPersonalR = new AM_Controls.TextBoxV();
			this.tbStateR = new AM_Controls.TextBoxV();
			this.label19 = new System.Windows.Forms.Label();
			this.textBoxV6 = new AM_Controls.TextBoxV();
			this.textBoxV7 = new AM_Controls.TextBoxV();
			this.tbSumPersonalW = new AM_Controls.TextBoxV();
			this.textBoxV9 = new AM_Controls.TextBoxV();
			this.label20 = new System.Windows.Forms.Label();
			this.textBoxV1 = new AM_Controls.TextBoxV();
			this.label21 = new System.Windows.Forms.Label();
			this.textBoxV2 = new AM_Controls.TextBoxV();
			this.textBoxV3 = new AM_Controls.TextBoxV();
			this.tbUnknownRevenue = new AM_Controls.TextBoxV();
			this.tbSumCredits = new AM_Controls.TextBoxV();
			this.label22 = new System.Windows.Forms.Label();
			this.textBoxV5 = new AM_Controls.TextBoxV();
			this.textBoxV8 = new AM_Controls.TextBoxV();
			this.textBoxV10 = new AM_Controls.TextBoxV();
			this.tbBalanceReserved = new AM_Controls.TextBoxV();
			this.tbBalanceWaited = new AM_Controls.TextBoxV();
			this.label23 = new System.Windows.Forms.Label();
			this.tbTransferTotals = new AM_Controls.TextBoxV();
			this.tbTransferShort = new AM_Controls.TextBoxV();
			this.tbTransferLong = new AM_Controls.TextBoxV();
			this.label30 = new System.Windows.Forms.Label();
			this.textBoxV4 = new AM_Controls.TextBoxV();
			this.tbUnknownExpenditure = new AM_Controls.TextBoxV();
			this.textBoxV12 = new AM_Controls.TextBoxV();
			this.textBoxV13 = new AM_Controls.TextBoxV();
			this.label31 = new System.Windows.Forms.Label();
			this.textBoxV11 = new AM_Controls.TextBoxV();
			this.textBoxV14 = new AM_Controls.TextBoxV();
			this.textBoxV15 = new AM_Controls.TextBoxV();
			this.tbSumCreditsOut = new AM_Controls.TextBoxV();
			this.label32 = new System.Windows.Forms.Label();
			this.tbSumCreditsIn = new AM_Controls.TextBoxV();
			this.textBoxV17 = new AM_Controls.TextBoxV();
			this.textBoxV18 = new AM_Controls.TextBoxV();
			this.textBoxV19 = new AM_Controls.TextBoxV();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tbSumRevenue = new AM_Controls.TextBoxV();
			this.tbSumProgress = new AM_Controls.TextBoxV();
			this.label3 = new System.Windows.Forms.Label();
			this.tbSumService = new AM_Controls.TextBoxV();
			this.tbSumExchange = new AM_Controls.TextBoxV();
			this.tbSumExpenditure = new AM_Controls.TextBoxV();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSumTransit = new AM_Controls.TextBoxV();
			this.label33 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgAccountsState = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnAccountTypeID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSumSaldo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSumSumReserved = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSumSumWaited = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSumSumFree = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnCurrencyID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuRefresh = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dsBalanceAccountsState1)).BeginInit();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAccountsState)).BeginInit();
			this.SuspendLayout();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "BalanceAccountsByTypeSummary", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																									  new System.Data.Common.DataColumnMapping("TypeName", "TypeName"),
																																																									  new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																									  new System.Data.Common.DataColumnMapping("SumSaldo", "SumSaldo")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[BalanceAccountsByTypeSummary]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fGrossAccountFact", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fGrossAccountFactW", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fGrossAccountFactR", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fGrossAccountCalc", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalRevenue", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalExpenditure", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalSettlement", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalSettlementW", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalSettlementR", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalCash", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalCashW", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalCashR", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalOuter", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalOuterW", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalOuterR", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalPersonal", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalPersonalW", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalPersonalR", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalService", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalExchange", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalProgress", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalCreditsOut", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalCreditsIn", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fBalance", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fUnknownIncomes", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fUnknownRevenue", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumReservedCalc", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumReservedFact", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumWaitedCalc", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumWaitedFact", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fSumTransferShort", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fSumTransferLong", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fSumTransferTotals", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fUnknownExpenditure", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fSumCreditsOut", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fSumCreditsIn", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fTotalTransit", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// dsBalanceAccountsState1
			// 
			this.dsBalanceAccountsState1.DataSetName = "dsBalanceAccountsState";
			this.dsBalanceAccountsState1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(840, 7);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 273);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(840, 248);
			this.panel2.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(840, 248);
			this.tabControl1.TabIndex = 16;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label27);
			this.tabPage1.Controls.Add(this.label28);
			this.tabPage1.Controls.Add(this.label29);
			this.tabPage1.Controls.Add(this.label24);
			this.tabPage1.Controls.Add(this.label25);
			this.tabPage1.Controls.Add(this.label26);
			this.tabPage1.Controls.Add(this.tbSumOuter);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.tbSumPersonal);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.tbSumSettlement);
			this.tabPage1.Controls.Add(this.tbState);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.tbUnknownIncomes);
			this.tabPage1.Controls.Add(this.tbSumCash);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.tbBalance);
			this.tabPage1.Controls.Add(this.tbSumOuterR);
			this.tabPage1.Controls.Add(this.tbSumSettlementR);
			this.tabPage1.Controls.Add(this.tbSumCashR);
			this.tabPage1.Controls.Add(this.tbSumOuterW);
			this.tabPage1.Controls.Add(this.tbSumSettlementW);
			this.tabPage1.Controls.Add(this.tbSumCashW);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.tbSumOuterA);
			this.tabPage1.Controls.Add(this.tbSumSettlementA);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.tbSumCashA);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.tbSumPersonalA);
			this.tabPage1.Controls.Add(this.tbStateW);
			this.tabPage1.Controls.Add(this.tbStateA);
			this.tabPage1.Controls.Add(this.label18);
			this.tabPage1.Controls.Add(this.tbSumPersonalR);
			this.tabPage1.Controls.Add(this.tbStateR);
			this.tabPage1.Controls.Add(this.label19);
			this.tabPage1.Controls.Add(this.textBoxV6);
			this.tabPage1.Controls.Add(this.textBoxV7);
			this.tabPage1.Controls.Add(this.tbSumPersonalW);
			this.tabPage1.Controls.Add(this.textBoxV9);
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.textBoxV1);
			this.tabPage1.Controls.Add(this.label21);
			this.tabPage1.Controls.Add(this.textBoxV2);
			this.tabPage1.Controls.Add(this.textBoxV3);
			this.tabPage1.Controls.Add(this.tbUnknownRevenue);
			this.tabPage1.Controls.Add(this.tbSumCredits);
			this.tabPage1.Controls.Add(this.label22);
			this.tabPage1.Controls.Add(this.textBoxV5);
			this.tabPage1.Controls.Add(this.textBoxV8);
			this.tabPage1.Controls.Add(this.textBoxV10);
			this.tabPage1.Controls.Add(this.tbBalanceReserved);
			this.tabPage1.Controls.Add(this.tbBalanceWaited);
			this.tabPage1.Controls.Add(this.label23);
			this.tabPage1.Controls.Add(this.tbTransferTotals);
			this.tabPage1.Controls.Add(this.tbTransferShort);
			this.tabPage1.Controls.Add(this.tbTransferLong);
			this.tabPage1.Controls.Add(this.label30);
			this.tabPage1.Controls.Add(this.textBoxV4);
			this.tabPage1.Controls.Add(this.tbUnknownExpenditure);
			this.tabPage1.Controls.Add(this.textBoxV12);
			this.tabPage1.Controls.Add(this.textBoxV13);
			this.tabPage1.Controls.Add(this.label31);
			this.tabPage1.Controls.Add(this.textBoxV11);
			this.tabPage1.Controls.Add(this.textBoxV14);
			this.tabPage1.Controls.Add(this.textBoxV15);
			this.tabPage1.Controls.Add(this.tbSumCreditsOut);
			this.tabPage1.Controls.Add(this.label32);
			this.tabPage1.Controls.Add(this.tbSumCreditsIn);
			this.tabPage1.Controls.Add(this.textBoxV17);
			this.tabPage1.Controls.Add(this.textBoxV18);
			this.tabPage1.Controls.Add(this.textBoxV19);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(832, 222);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Баланс";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(524, 172);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(75, 18);
			this.label27.TabIndex = 21;
			this.label27.Text = "Основной:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(600, 172);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(75, 18);
			this.label28.TabIndex = 20;
			this.label28.Text = "Резервир.:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(676, 172);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(75, 18);
			this.label29.TabIndex = 19;
			this.label29.Text = "Ожидаемых:";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(106, 172);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(75, 18);
			this.label24.TabIndex = 18;
			this.label24.Text = "Всего:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(182, 172);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(75, 18);
			this.label25.TabIndex = 17;
			this.label25.Text = "ВнутриБанк:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(258, 172);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(75, 18);
			this.label26.TabIndex = 16;
			this.label26.Text = "МежБанк:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSumOuter
			// 
			this.tbSumOuter.AllowDrop = true;
			this.tbSumOuter.dValue = 0;
			this.tbSumOuter.IsPcnt = false;
			this.tbSumOuter.Location = new System.Drawing.Point(105, 72);
			this.tbSumOuter.MaxDecPos = 2;
			this.tbSumOuter.MaxPos = 14;
			this.tbSumOuter.Name = "tbSumOuter";
			this.tbSumOuter.Negative = System.Drawing.Color.Empty;
			this.tbSumOuter.nValue = ((long)(0));
			this.tbSumOuter.Positive = System.Drawing.Color.Empty;
			this.tbSumOuter.ReadOnly = true;
			this.tbSumOuter.Size = new System.Drawing.Size(75, 20);
			this.tbSumOuter.TabIndex = 0;
			this.tbSumOuter.Text = "0";
			this.tbSumOuter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumOuter.TextMode = false;
			this.tbSumOuter.Zero = System.Drawing.Color.Empty;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Расчетные счета:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(411, 30);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(86, 18);
			this.label12.TabIndex = 15;
			this.label12.Text = "Неопознанные:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(411, 95);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Клиентов:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSumPersonal
			// 
			this.tbSumPersonal.AllowDrop = true;
			this.tbSumPersonal.dValue = 0;
			this.tbSumPersonal.IsPcnt = false;
			this.tbSumPersonal.Location = new System.Drawing.Point(524, 93);
			this.tbSumPersonal.MaxDecPos = 2;
			this.tbSumPersonal.MaxPos = 14;
			this.tbSumPersonal.Name = "tbSumPersonal";
			this.tbSumPersonal.Negative = System.Drawing.Color.Empty;
			this.tbSumPersonal.nValue = ((long)(0));
			this.tbSumPersonal.Positive = System.Drawing.Color.Empty;
			this.tbSumPersonal.ReadOnly = true;
			this.tbSumPersonal.Size = new System.Drawing.Size(75, 20);
			this.tbSumPersonal.TabIndex = 0;
			this.tbSumPersonal.Text = "0";
			this.tbSumPersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumPersonal.TextMode = false;
			this.tbSumPersonal.Zero = System.Drawing.Color.Empty;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(2, 73);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(98, 18);
			this.label7.TabIndex = 11;
			this.label7.Text = "Внешние счета:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(411, 117);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(86, 18);
			this.label11.TabIndex = 15;
			this.label11.Text = "Наше:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSumSettlement
			// 
			this.tbSumSettlement.AllowDrop = true;
			this.tbSumSettlement.dValue = 0;
			this.tbSumSettlement.IsPcnt = false;
			this.tbSumSettlement.Location = new System.Drawing.Point(105, 30);
			this.tbSumSettlement.MaxDecPos = 2;
			this.tbSumSettlement.MaxPos = 14;
			this.tbSumSettlement.Name = "tbSumSettlement";
			this.tbSumSettlement.Negative = System.Drawing.Color.Empty;
			this.tbSumSettlement.nValue = ((long)(0));
			this.tbSumSettlement.Positive = System.Drawing.Color.Empty;
			this.tbSumSettlement.ReadOnly = true;
			this.tbSumSettlement.Size = new System.Drawing.Size(75, 20);
			this.tbSumSettlement.TabIndex = 0;
			this.tbSumSettlement.Text = "0";
			this.tbSumSettlement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumSettlement.TextMode = false;
			this.tbSumSettlement.Zero = System.Drawing.Color.Empty;
			// 
			// tbState
			// 
			this.tbState.AllowDrop = true;
			this.tbState.dValue = 0;
			this.tbState.IsPcnt = false;
			this.tbState.Location = new System.Drawing.Point(524, 114);
			this.tbState.MaxDecPos = 2;
			this.tbState.MaxPos = 14;
			this.tbState.Name = "tbState";
			this.tbState.Negative = System.Drawing.Color.Empty;
			this.tbState.nValue = ((long)(0));
			this.tbState.Positive = System.Drawing.Color.Empty;
			this.tbState.ReadOnly = true;
			this.tbState.Size = new System.Drawing.Size(75, 20);
			this.tbState.TabIndex = 6;
			this.tbState.Text = "0";
			this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbState.TextMode = false;
			this.tbState.Zero = System.Drawing.Color.Empty;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(2, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Кассы:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbUnknownIncomes
			// 
			this.tbUnknownIncomes.AllowDrop = true;
			this.tbUnknownIncomes.dValue = 0;
			this.tbUnknownIncomes.IsPcnt = false;
			this.tbUnknownIncomes.Location = new System.Drawing.Point(524, 30);
			this.tbUnknownIncomes.MaxDecPos = 2;
			this.tbUnknownIncomes.MaxPos = 14;
			this.tbUnknownIncomes.Name = "tbUnknownIncomes";
			this.tbUnknownIncomes.Negative = System.Drawing.Color.Empty;
			this.tbUnknownIncomes.nValue = ((long)(0));
			this.tbUnknownIncomes.Positive = System.Drawing.Color.Empty;
			this.tbUnknownIncomes.ReadOnly = true;
			this.tbUnknownIncomes.Size = new System.Drawing.Size(75, 20);
			this.tbUnknownIncomes.TabIndex = 6;
			this.tbUnknownIncomes.Text = "0";
			this.tbUnknownIncomes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbUnknownIncomes.TextMode = false;
			this.tbUnknownIncomes.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumCash
			// 
			this.tbSumCash.AllowDrop = true;
			this.tbSumCash.dValue = 0;
			this.tbSumCash.IsPcnt = false;
			this.tbSumCash.Location = new System.Drawing.Point(105, 51);
			this.tbSumCash.MaxDecPos = 2;
			this.tbSumCash.MaxPos = 14;
			this.tbSumCash.Name = "tbSumCash";
			this.tbSumCash.Negative = System.Drawing.Color.Empty;
			this.tbSumCash.nValue = ((long)(0));
			this.tbSumCash.Positive = System.Drawing.Color.Empty;
			this.tbSumCash.ReadOnly = true;
			this.tbSumCash.Size = new System.Drawing.Size(75, 20);
			this.tbSumCash.TabIndex = 0;
			this.tbSumCash.Text = "0";
			this.tbSumCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCash.TextMode = false;
			this.tbSumCash.Zero = System.Drawing.Color.Empty;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(411, 194);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 18);
			this.label10.TabIndex = 15;
			this.label10.Text = "Баланс:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBalance
			// 
			this.tbBalance.AllowDrop = true;
			this.tbBalance.BackColor = System.Drawing.Color.LavenderBlush;
			this.tbBalance.dValue = 0;
			this.tbBalance.IsPcnt = false;
			this.tbBalance.Location = new System.Drawing.Point(524, 192);
			this.tbBalance.MaxDecPos = 2;
			this.tbBalance.MaxPos = 14;
			this.tbBalance.Name = "tbBalance";
			this.tbBalance.Negative = System.Drawing.Color.Empty;
			this.tbBalance.nValue = ((long)(0));
			this.tbBalance.Positive = System.Drawing.Color.Empty;
			this.tbBalance.ReadOnly = true;
			this.tbBalance.Size = new System.Drawing.Size(75, 20);
			this.tbBalance.TabIndex = 6;
			this.tbBalance.Text = "0";
			this.tbBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbBalance.TextMode = false;
			this.tbBalance.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumOuterR
			// 
			this.tbSumOuterR.AllowDrop = true;
			this.tbSumOuterR.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumOuterR.dValue = 0;
			this.tbSumOuterR.IsPcnt = false;
			this.tbSumOuterR.Location = new System.Drawing.Point(181, 72);
			this.tbSumOuterR.MaxDecPos = 2;
			this.tbSumOuterR.MaxPos = 14;
			this.tbSumOuterR.Name = "tbSumOuterR";
			this.tbSumOuterR.Negative = System.Drawing.Color.Empty;
			this.tbSumOuterR.nValue = ((long)(0));
			this.tbSumOuterR.Positive = System.Drawing.Color.Empty;
			this.tbSumOuterR.ReadOnly = true;
			this.tbSumOuterR.Size = new System.Drawing.Size(75, 20);
			this.tbSumOuterR.TabIndex = 0;
			this.tbSumOuterR.Text = "0";
			this.tbSumOuterR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumOuterR.TextMode = false;
			this.tbSumOuterR.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumSettlementR
			// 
			this.tbSumSettlementR.AllowDrop = true;
			this.tbSumSettlementR.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumSettlementR.dValue = 0;
			this.tbSumSettlementR.IsPcnt = false;
			this.tbSumSettlementR.Location = new System.Drawing.Point(181, 30);
			this.tbSumSettlementR.MaxDecPos = 2;
			this.tbSumSettlementR.MaxPos = 14;
			this.tbSumSettlementR.Name = "tbSumSettlementR";
			this.tbSumSettlementR.Negative = System.Drawing.Color.Empty;
			this.tbSumSettlementR.nValue = ((long)(0));
			this.tbSumSettlementR.Positive = System.Drawing.Color.Empty;
			this.tbSumSettlementR.ReadOnly = true;
			this.tbSumSettlementR.Size = new System.Drawing.Size(75, 20);
			this.tbSumSettlementR.TabIndex = 0;
			this.tbSumSettlementR.Text = "0";
			this.tbSumSettlementR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumSettlementR.TextMode = false;
			this.tbSumSettlementR.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumCashR
			// 
			this.tbSumCashR.AllowDrop = true;
			this.tbSumCashR.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumCashR.dValue = 0;
			this.tbSumCashR.IsPcnt = false;
			this.tbSumCashR.Location = new System.Drawing.Point(181, 51);
			this.tbSumCashR.MaxDecPos = 2;
			this.tbSumCashR.MaxPos = 14;
			this.tbSumCashR.Name = "tbSumCashR";
			this.tbSumCashR.Negative = System.Drawing.Color.Empty;
			this.tbSumCashR.nValue = ((long)(0));
			this.tbSumCashR.Positive = System.Drawing.Color.Empty;
			this.tbSumCashR.ReadOnly = true;
			this.tbSumCashR.Size = new System.Drawing.Size(75, 20);
			this.tbSumCashR.TabIndex = 0;
			this.tbSumCashR.Text = "0";
			this.tbSumCashR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCashR.TextMode = false;
			this.tbSumCashR.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumOuterW
			// 
			this.tbSumOuterW.AllowDrop = true;
			this.tbSumOuterW.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumOuterW.dValue = 0;
			this.tbSumOuterW.IsPcnt = false;
			this.tbSumOuterW.Location = new System.Drawing.Point(257, 72);
			this.tbSumOuterW.MaxDecPos = 2;
			this.tbSumOuterW.MaxPos = 14;
			this.tbSumOuterW.Name = "tbSumOuterW";
			this.tbSumOuterW.Negative = System.Drawing.Color.Empty;
			this.tbSumOuterW.nValue = ((long)(0));
			this.tbSumOuterW.Positive = System.Drawing.Color.Empty;
			this.tbSumOuterW.ReadOnly = true;
			this.tbSumOuterW.Size = new System.Drawing.Size(75, 20);
			this.tbSumOuterW.TabIndex = 0;
			this.tbSumOuterW.Text = "0";
			this.tbSumOuterW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumOuterW.TextMode = false;
			this.tbSumOuterW.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumSettlementW
			// 
			this.tbSumSettlementW.AllowDrop = true;
			this.tbSumSettlementW.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumSettlementW.dValue = 0;
			this.tbSumSettlementW.IsPcnt = false;
			this.tbSumSettlementW.Location = new System.Drawing.Point(257, 30);
			this.tbSumSettlementW.MaxDecPos = 2;
			this.tbSumSettlementW.MaxPos = 14;
			this.tbSumSettlementW.Name = "tbSumSettlementW";
			this.tbSumSettlementW.Negative = System.Drawing.Color.Empty;
			this.tbSumSettlementW.nValue = ((long)(0));
			this.tbSumSettlementW.Positive = System.Drawing.Color.Empty;
			this.tbSumSettlementW.ReadOnly = true;
			this.tbSumSettlementW.Size = new System.Drawing.Size(75, 20);
			this.tbSumSettlementW.TabIndex = 0;
			this.tbSumSettlementW.Text = "0";
			this.tbSumSettlementW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumSettlementW.TextMode = false;
			this.tbSumSettlementW.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumCashW
			// 
			this.tbSumCashW.AllowDrop = true;
			this.tbSumCashW.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumCashW.dValue = 0;
			this.tbSumCashW.IsPcnt = false;
			this.tbSumCashW.Location = new System.Drawing.Point(257, 51);
			this.tbSumCashW.MaxDecPos = 2;
			this.tbSumCashW.MaxPos = 14;
			this.tbSumCashW.Name = "tbSumCashW";
			this.tbSumCashW.Negative = System.Drawing.Color.Empty;
			this.tbSumCashW.nValue = ((long)(0));
			this.tbSumCashW.Positive = System.Drawing.Color.Empty;
			this.tbSumCashW.ReadOnly = true;
			this.tbSumCashW.Size = new System.Drawing.Size(75, 20);
			this.tbSumCashW.TabIndex = 0;
			this.tbSumCashW.Text = "0";
			this.tbSumCashW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCashW.TextMode = false;
			this.tbSumCashW.Zero = System.Drawing.Color.Empty;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(106, 10);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(75, 18);
			this.label13.TabIndex = 1;
			this.label13.Text = "Сальдо:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(182, 10);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(75, 18);
			this.label14.TabIndex = 1;
			this.label14.Text = "Резерв:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(258, 10);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(75, 18);
			this.label15.TabIndex = 1;
			this.label15.Text = "Ожидается:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSumOuterA
			// 
			this.tbSumOuterA.AllowDrop = true;
			this.tbSumOuterA.BackColor = System.Drawing.Color.Cornsilk;
			this.tbSumOuterA.dValue = 0;
			this.tbSumOuterA.IsPcnt = false;
			this.tbSumOuterA.Location = new System.Drawing.Point(333, 72);
			this.tbSumOuterA.MaxDecPos = 2;
			this.tbSumOuterA.MaxPos = 14;
			this.tbSumOuterA.Name = "tbSumOuterA";
			this.tbSumOuterA.Negative = System.Drawing.Color.Empty;
			this.tbSumOuterA.nValue = ((long)(0));
			this.tbSumOuterA.Positive = System.Drawing.Color.Empty;
			this.tbSumOuterA.ReadOnly = true;
			this.tbSumOuterA.Size = new System.Drawing.Size(75, 20);
			this.tbSumOuterA.TabIndex = 0;
			this.tbSumOuterA.Text = "0";
			this.tbSumOuterA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumOuterA.TextMode = false;
			this.tbSumOuterA.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumSettlementA
			// 
			this.tbSumSettlementA.AllowDrop = true;
			this.tbSumSettlementA.BackColor = System.Drawing.Color.Cornsilk;
			this.tbSumSettlementA.dValue = 0;
			this.tbSumSettlementA.IsPcnt = false;
			this.tbSumSettlementA.Location = new System.Drawing.Point(333, 30);
			this.tbSumSettlementA.MaxDecPos = 2;
			this.tbSumSettlementA.MaxPos = 14;
			this.tbSumSettlementA.Name = "tbSumSettlementA";
			this.tbSumSettlementA.Negative = System.Drawing.Color.Empty;
			this.tbSumSettlementA.nValue = ((long)(0));
			this.tbSumSettlementA.Positive = System.Drawing.Color.Empty;
			this.tbSumSettlementA.ReadOnly = true;
			this.tbSumSettlementA.Size = new System.Drawing.Size(75, 20);
			this.tbSumSettlementA.TabIndex = 0;
			this.tbSumSettlementA.Text = "0";
			this.tbSumSettlementA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumSettlementA.TextMode = false;
			this.tbSumSettlementA.Zero = System.Drawing.Color.Empty;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(334, 10);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(75, 18);
			this.label16.TabIndex = 1;
			this.label16.Text = "Доступно:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSumCashA
			// 
			this.tbSumCashA.AllowDrop = true;
			this.tbSumCashA.BackColor = System.Drawing.Color.Cornsilk;
			this.tbSumCashA.dValue = 0;
			this.tbSumCashA.IsPcnt = false;
			this.tbSumCashA.Location = new System.Drawing.Point(333, 51);
			this.tbSumCashA.MaxDecPos = 2;
			this.tbSumCashA.MaxPos = 14;
			this.tbSumCashA.Name = "tbSumCashA";
			this.tbSumCashA.Negative = System.Drawing.Color.Empty;
			this.tbSumCashA.nValue = ((long)(0));
			this.tbSumCashA.Positive = System.Drawing.Color.Empty;
			this.tbSumCashA.ReadOnly = true;
			this.tbSumCashA.Size = new System.Drawing.Size(75, 20);
			this.tbSumCashA.TabIndex = 0;
			this.tbSumCashA.Text = "0";
			this.tbSumCashA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCashA.TextMode = false;
			this.tbSumCashA.Zero = System.Drawing.Color.Empty;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(600, 10);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(75, 18);
			this.label17.TabIndex = 1;
			this.label17.Text = "Резерв:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSumPersonalA
			// 
			this.tbSumPersonalA.AllowDrop = true;
			this.tbSumPersonalA.BackColor = System.Drawing.Color.Cornsilk;
			this.tbSumPersonalA.dValue = 0;
			this.tbSumPersonalA.IsPcnt = false;
			this.tbSumPersonalA.Location = new System.Drawing.Point(752, 93);
			this.tbSumPersonalA.MaxDecPos = 2;
			this.tbSumPersonalA.MaxPos = 14;
			this.tbSumPersonalA.Name = "tbSumPersonalA";
			this.tbSumPersonalA.Negative = System.Drawing.Color.Empty;
			this.tbSumPersonalA.nValue = ((long)(0));
			this.tbSumPersonalA.Positive = System.Drawing.Color.Empty;
			this.tbSumPersonalA.ReadOnly = true;
			this.tbSumPersonalA.Size = new System.Drawing.Size(75, 20);
			this.tbSumPersonalA.TabIndex = 0;
			this.tbSumPersonalA.Text = "0";
			this.tbSumPersonalA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumPersonalA.TextMode = false;
			this.tbSumPersonalA.Zero = System.Drawing.Color.Empty;
			// 
			// tbStateW
			// 
			this.tbStateW.AllowDrop = true;
			this.tbStateW.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbStateW.dValue = 0;
			this.tbStateW.IsPcnt = false;
			this.tbStateW.Location = new System.Drawing.Point(676, 114);
			this.tbStateW.MaxDecPos = 2;
			this.tbStateW.MaxPos = 14;
			this.tbStateW.Name = "tbStateW";
			this.tbStateW.Negative = System.Drawing.Color.Empty;
			this.tbStateW.nValue = ((long)(0));
			this.tbStateW.Positive = System.Drawing.Color.Empty;
			this.tbStateW.ReadOnly = true;
			this.tbStateW.Size = new System.Drawing.Size(75, 20);
			this.tbStateW.TabIndex = 0;
			this.tbStateW.Text = "0";
			this.tbStateW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbStateW.TextMode = false;
			this.tbStateW.Zero = System.Drawing.Color.Empty;
			// 
			// tbStateA
			// 
			this.tbStateA.AllowDrop = true;
			this.tbStateA.BackColor = System.Drawing.Color.Cornsilk;
			this.tbStateA.dValue = 0;
			this.tbStateA.IsPcnt = false;
			this.tbStateA.Location = new System.Drawing.Point(752, 114);
			this.tbStateA.MaxDecPos = 2;
			this.tbStateA.MaxPos = 14;
			this.tbStateA.Name = "tbStateA";
			this.tbStateA.Negative = System.Drawing.Color.Empty;
			this.tbStateA.nValue = ((long)(0));
			this.tbStateA.Positive = System.Drawing.Color.Empty;
			this.tbStateA.ReadOnly = true;
			this.tbStateA.Size = new System.Drawing.Size(75, 20);
			this.tbStateA.TabIndex = 0;
			this.tbStateA.Text = "0";
			this.tbStateA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbStateA.TextMode = false;
			this.tbStateA.Zero = System.Drawing.Color.Empty;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(752, 10);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(75, 18);
			this.label18.TabIndex = 1;
			this.label18.Text = "Доступно:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSumPersonalR
			// 
			this.tbSumPersonalR.AllowDrop = true;
			this.tbSumPersonalR.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumPersonalR.dValue = 0;
			this.tbSumPersonalR.IsPcnt = false;
			this.tbSumPersonalR.Location = new System.Drawing.Point(600, 93);
			this.tbSumPersonalR.MaxDecPos = 2;
			this.tbSumPersonalR.MaxPos = 14;
			this.tbSumPersonalR.Name = "tbSumPersonalR";
			this.tbSumPersonalR.Negative = System.Drawing.Color.Empty;
			this.tbSumPersonalR.nValue = ((long)(0));
			this.tbSumPersonalR.Positive = System.Drawing.Color.Empty;
			this.tbSumPersonalR.ReadOnly = true;
			this.tbSumPersonalR.Size = new System.Drawing.Size(75, 20);
			this.tbSumPersonalR.TabIndex = 0;
			this.tbSumPersonalR.Text = "0";
			this.tbSumPersonalR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumPersonalR.TextMode = false;
			this.tbSumPersonalR.Zero = System.Drawing.Color.Empty;
			// 
			// tbStateR
			// 
			this.tbStateR.AllowDrop = true;
			this.tbStateR.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbStateR.dValue = 0;
			this.tbStateR.IsPcnt = false;
			this.tbStateR.Location = new System.Drawing.Point(600, 114);
			this.tbStateR.MaxDecPos = 2;
			this.tbStateR.MaxPos = 14;
			this.tbStateR.Name = "tbStateR";
			this.tbStateR.Negative = System.Drawing.Color.Empty;
			this.tbStateR.nValue = ((long)(0));
			this.tbStateR.Positive = System.Drawing.Color.Empty;
			this.tbStateR.ReadOnly = true;
			this.tbStateR.Size = new System.Drawing.Size(75, 20);
			this.tbStateR.TabIndex = 0;
			this.tbStateR.Text = "0";
			this.tbStateR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbStateR.TextMode = false;
			this.tbStateR.Zero = System.Drawing.Color.Empty;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(676, 10);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(75, 18);
			this.label19.TabIndex = 1;
			this.label19.Text = "Ожидается:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxV6
			// 
			this.textBoxV6.AllowDrop = true;
			this.textBoxV6.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV6.dValue = 0;
			this.textBoxV6.Enabled = false;
			this.textBoxV6.IsPcnt = false;
			this.textBoxV6.Location = new System.Drawing.Point(676, 30);
			this.textBoxV6.MaxDecPos = 2;
			this.textBoxV6.MaxPos = 14;
			this.textBoxV6.Name = "textBoxV6";
			this.textBoxV6.Negative = System.Drawing.Color.Empty;
			this.textBoxV6.nValue = ((long)(0));
			this.textBoxV6.Positive = System.Drawing.Color.Empty;
			this.textBoxV6.ReadOnly = true;
			this.textBoxV6.Size = new System.Drawing.Size(75, 20);
			this.textBoxV6.TabIndex = 0;
			this.textBoxV6.Text = "0";
			this.textBoxV6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV6.TextMode = false;
			this.textBoxV6.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV7
			// 
			this.textBoxV7.AllowDrop = true;
			this.textBoxV7.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV7.dValue = 0;
			this.textBoxV7.Enabled = false;
			this.textBoxV7.IsPcnt = false;
			this.textBoxV7.Location = new System.Drawing.Point(600, 30);
			this.textBoxV7.MaxDecPos = 2;
			this.textBoxV7.MaxPos = 14;
			this.textBoxV7.Name = "textBoxV7";
			this.textBoxV7.Negative = System.Drawing.Color.Empty;
			this.textBoxV7.nValue = ((long)(0));
			this.textBoxV7.Positive = System.Drawing.Color.Empty;
			this.textBoxV7.ReadOnly = true;
			this.textBoxV7.Size = new System.Drawing.Size(75, 20);
			this.textBoxV7.TabIndex = 0;
			this.textBoxV7.Text = "0";
			this.textBoxV7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV7.TextMode = false;
			this.textBoxV7.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumPersonalW
			// 
			this.tbSumPersonalW.AllowDrop = true;
			this.tbSumPersonalW.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbSumPersonalW.dValue = 0;
			this.tbSumPersonalW.IsPcnt = false;
			this.tbSumPersonalW.Location = new System.Drawing.Point(676, 93);
			this.tbSumPersonalW.MaxDecPos = 2;
			this.tbSumPersonalW.MaxPos = 14;
			this.tbSumPersonalW.Name = "tbSumPersonalW";
			this.tbSumPersonalW.Negative = System.Drawing.Color.Empty;
			this.tbSumPersonalW.nValue = ((long)(0));
			this.tbSumPersonalW.Positive = System.Drawing.Color.Empty;
			this.tbSumPersonalW.ReadOnly = true;
			this.tbSumPersonalW.Size = new System.Drawing.Size(75, 20);
			this.tbSumPersonalW.TabIndex = 0;
			this.tbSumPersonalW.Text = "0";
			this.tbSumPersonalW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumPersonalW.TextMode = false;
			this.tbSumPersonalW.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV9
			// 
			this.textBoxV9.AllowDrop = true;
			this.textBoxV9.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV9.dValue = 0;
			this.textBoxV9.Enabled = false;
			this.textBoxV9.IsPcnt = false;
			this.textBoxV9.Location = new System.Drawing.Point(752, 30);
			this.textBoxV9.MaxDecPos = 2;
			this.textBoxV9.MaxPos = 14;
			this.textBoxV9.Name = "textBoxV9";
			this.textBoxV9.Negative = System.Drawing.Color.Empty;
			this.textBoxV9.nValue = ((long)(0));
			this.textBoxV9.Positive = System.Drawing.Color.Empty;
			this.textBoxV9.ReadOnly = true;
			this.textBoxV9.Size = new System.Drawing.Size(75, 20);
			this.textBoxV9.TabIndex = 0;
			this.textBoxV9.Text = "0";
			this.textBoxV9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV9.TextMode = false;
			this.textBoxV9.Zero = System.Drawing.Color.Empty;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(524, 10);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(75, 18);
			this.label20.TabIndex = 1;
			this.label20.Text = "Сальдо:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxV1
			// 
			this.textBoxV1.AllowDrop = true;
			this.textBoxV1.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV1.dValue = 0;
			this.textBoxV1.Enabled = false;
			this.textBoxV1.IsPcnt = false;
			this.textBoxV1.Location = new System.Drawing.Point(600, 51);
			this.textBoxV1.MaxDecPos = 2;
			this.textBoxV1.MaxPos = 14;
			this.textBoxV1.Name = "textBoxV1";
			this.textBoxV1.Negative = System.Drawing.Color.Empty;
			this.textBoxV1.nValue = ((long)(0));
			this.textBoxV1.Positive = System.Drawing.Color.Empty;
			this.textBoxV1.ReadOnly = true;
			this.textBoxV1.Size = new System.Drawing.Size(75, 20);
			this.textBoxV1.TabIndex = 0;
			this.textBoxV1.Text = "0";
			this.textBoxV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV1.TextMode = false;
			this.textBoxV1.Zero = System.Drawing.Color.Empty;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(411, 52);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(109, 18);
			this.label21.TabIndex = 15;
			this.label21.Text = "Непровед. Доходы:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxV2
			// 
			this.textBoxV2.AllowDrop = true;
			this.textBoxV2.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV2.dValue = 0;
			this.textBoxV2.Enabled = false;
			this.textBoxV2.IsPcnt = false;
			this.textBoxV2.Location = new System.Drawing.Point(676, 51);
			this.textBoxV2.MaxDecPos = 2;
			this.textBoxV2.MaxPos = 14;
			this.textBoxV2.Name = "textBoxV2";
			this.textBoxV2.Negative = System.Drawing.Color.Empty;
			this.textBoxV2.nValue = ((long)(0));
			this.textBoxV2.Positive = System.Drawing.Color.Empty;
			this.textBoxV2.ReadOnly = true;
			this.textBoxV2.Size = new System.Drawing.Size(75, 20);
			this.textBoxV2.TabIndex = 0;
			this.textBoxV2.Text = "0";
			this.textBoxV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV2.TextMode = false;
			this.textBoxV2.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV3
			// 
			this.textBoxV3.AllowDrop = true;
			this.textBoxV3.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV3.dValue = 0;
			this.textBoxV3.Enabled = false;
			this.textBoxV3.IsPcnt = false;
			this.textBoxV3.Location = new System.Drawing.Point(752, 51);
			this.textBoxV3.MaxDecPos = 2;
			this.textBoxV3.MaxPos = 14;
			this.textBoxV3.Name = "textBoxV3";
			this.textBoxV3.Negative = System.Drawing.Color.Empty;
			this.textBoxV3.nValue = ((long)(0));
			this.textBoxV3.Positive = System.Drawing.Color.Empty;
			this.textBoxV3.ReadOnly = true;
			this.textBoxV3.Size = new System.Drawing.Size(75, 20);
			this.textBoxV3.TabIndex = 0;
			this.textBoxV3.Text = "0";
			this.textBoxV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV3.TextMode = false;
			this.textBoxV3.Zero = System.Drawing.Color.Empty;
			// 
			// tbUnknownRevenue
			// 
			this.tbUnknownRevenue.AllowDrop = true;
			this.tbUnknownRevenue.dValue = 0;
			this.tbUnknownRevenue.IsPcnt = false;
			this.tbUnknownRevenue.Location = new System.Drawing.Point(524, 51);
			this.tbUnknownRevenue.MaxDecPos = 2;
			this.tbUnknownRevenue.MaxPos = 14;
			this.tbUnknownRevenue.Name = "tbUnknownRevenue";
			this.tbUnknownRevenue.Negative = System.Drawing.Color.Empty;
			this.tbUnknownRevenue.nValue = ((long)(0));
			this.tbUnknownRevenue.Positive = System.Drawing.Color.Empty;
			this.tbUnknownRevenue.ReadOnly = true;
			this.tbUnknownRevenue.Size = new System.Drawing.Size(75, 20);
			this.tbUnknownRevenue.TabIndex = 6;
			this.tbUnknownRevenue.Text = "0";
			this.tbUnknownRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbUnknownRevenue.TextMode = false;
			this.tbUnknownRevenue.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumCredits
			// 
			this.tbSumCredits.AllowDrop = true;
			this.tbSumCredits.dValue = 0;
			this.tbSumCredits.IsPcnt = false;
			this.tbSumCredits.Location = new System.Drawing.Point(105, 93);
			this.tbSumCredits.MaxDecPos = 2;
			this.tbSumCredits.MaxPos = 14;
			this.tbSumCredits.Name = "tbSumCredits";
			this.tbSumCredits.Negative = System.Drawing.Color.Empty;
			this.tbSumCredits.nValue = ((long)(0));
			this.tbSumCredits.Positive = System.Drawing.Color.Empty;
			this.tbSumCredits.ReadOnly = true;
			this.tbSumCredits.Size = new System.Drawing.Size(75, 20);
			this.tbSumCredits.TabIndex = 0;
			this.tbSumCredits.Text = "0";
			this.tbSumCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCredits.TextMode = false;
			this.tbSumCredits.Zero = System.Drawing.Color.Empty;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(2, 94);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(101, 18);
			this.label22.TabIndex = 11;
			this.label22.Text = "Ссуд выдано:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxV5
			// 
			this.textBoxV5.AllowDrop = true;
			this.textBoxV5.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV5.dValue = 0;
			this.textBoxV5.Enabled = false;
			this.textBoxV5.IsPcnt = false;
			this.textBoxV5.Location = new System.Drawing.Point(333, 93);
			this.textBoxV5.MaxDecPos = 2;
			this.textBoxV5.MaxPos = 14;
			this.textBoxV5.Name = "textBoxV5";
			this.textBoxV5.Negative = System.Drawing.Color.Empty;
			this.textBoxV5.nValue = ((long)(0));
			this.textBoxV5.Positive = System.Drawing.Color.Empty;
			this.textBoxV5.ReadOnly = true;
			this.textBoxV5.Size = new System.Drawing.Size(75, 20);
			this.textBoxV5.TabIndex = 0;
			this.textBoxV5.Text = "0";
			this.textBoxV5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV5.TextMode = false;
			this.textBoxV5.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV8
			// 
			this.textBoxV8.AllowDrop = true;
			this.textBoxV8.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV8.dValue = 0;
			this.textBoxV8.Enabled = false;
			this.textBoxV8.IsPcnt = false;
			this.textBoxV8.Location = new System.Drawing.Point(257, 93);
			this.textBoxV8.MaxDecPos = 2;
			this.textBoxV8.MaxPos = 14;
			this.textBoxV8.Name = "textBoxV8";
			this.textBoxV8.Negative = System.Drawing.Color.Empty;
			this.textBoxV8.nValue = ((long)(0));
			this.textBoxV8.Positive = System.Drawing.Color.Empty;
			this.textBoxV8.ReadOnly = true;
			this.textBoxV8.Size = new System.Drawing.Size(75, 20);
			this.textBoxV8.TabIndex = 0;
			this.textBoxV8.Text = "0";
			this.textBoxV8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV8.TextMode = false;
			this.textBoxV8.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV10
			// 
			this.textBoxV10.AllowDrop = true;
			this.textBoxV10.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV10.dValue = 0;
			this.textBoxV10.Enabled = false;
			this.textBoxV10.IsPcnt = false;
			this.textBoxV10.Location = new System.Drawing.Point(181, 93);
			this.textBoxV10.MaxDecPos = 2;
			this.textBoxV10.MaxPos = 14;
			this.textBoxV10.Name = "textBoxV10";
			this.textBoxV10.Negative = System.Drawing.Color.Empty;
			this.textBoxV10.nValue = ((long)(0));
			this.textBoxV10.Positive = System.Drawing.Color.Empty;
			this.textBoxV10.ReadOnly = true;
			this.textBoxV10.Size = new System.Drawing.Size(75, 20);
			this.textBoxV10.TabIndex = 0;
			this.textBoxV10.Text = "0";
			this.textBoxV10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV10.TextMode = false;
			this.textBoxV10.Zero = System.Drawing.Color.Empty;
			// 
			// tbBalanceReserved
			// 
			this.tbBalanceReserved.AllowDrop = true;
			this.tbBalanceReserved.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbBalanceReserved.dValue = 0;
			this.tbBalanceReserved.IsPcnt = false;
			this.tbBalanceReserved.Location = new System.Drawing.Point(600, 192);
			this.tbBalanceReserved.MaxDecPos = 2;
			this.tbBalanceReserved.MaxPos = 14;
			this.tbBalanceReserved.Name = "tbBalanceReserved";
			this.tbBalanceReserved.Negative = System.Drawing.Color.Empty;
			this.tbBalanceReserved.nValue = ((long)(0));
			this.tbBalanceReserved.Positive = System.Drawing.Color.Empty;
			this.tbBalanceReserved.ReadOnly = true;
			this.tbBalanceReserved.Size = new System.Drawing.Size(75, 20);
			this.tbBalanceReserved.TabIndex = 6;
			this.tbBalanceReserved.Text = "0";
			this.tbBalanceReserved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbBalanceReserved.TextMode = false;
			this.tbBalanceReserved.Zero = System.Drawing.Color.Empty;
			// 
			// tbBalanceWaited
			// 
			this.tbBalanceWaited.AllowDrop = true;
			this.tbBalanceWaited.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbBalanceWaited.dValue = 0;
			this.tbBalanceWaited.IsPcnt = false;
			this.tbBalanceWaited.Location = new System.Drawing.Point(676, 192);
			this.tbBalanceWaited.MaxDecPos = 2;
			this.tbBalanceWaited.MaxPos = 14;
			this.tbBalanceWaited.Name = "tbBalanceWaited";
			this.tbBalanceWaited.Negative = System.Drawing.Color.Empty;
			this.tbBalanceWaited.nValue = ((long)(0));
			this.tbBalanceWaited.Positive = System.Drawing.Color.Empty;
			this.tbBalanceWaited.ReadOnly = true;
			this.tbBalanceWaited.Size = new System.Drawing.Size(75, 20);
			this.tbBalanceWaited.TabIndex = 6;
			this.tbBalanceWaited.Text = "0";
			this.tbBalanceWaited.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbBalanceWaited.TextMode = false;
			this.tbBalanceWaited.Zero = System.Drawing.Color.Empty;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(2, 194);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(84, 18);
			this.label23.TabIndex = 15;
			this.label23.Text = "Перемещение:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTransferTotals
			// 
			this.tbTransferTotals.AllowDrop = true;
			this.tbTransferTotals.BackColor = System.Drawing.SystemColors.Window;
			this.tbTransferTotals.dValue = 0;
			this.tbTransferTotals.IsPcnt = false;
			this.tbTransferTotals.Location = new System.Drawing.Point(105, 192);
			this.tbTransferTotals.MaxDecPos = 2;
			this.tbTransferTotals.MaxPos = 14;
			this.tbTransferTotals.Name = "tbTransferTotals";
			this.tbTransferTotals.Negative = System.Drawing.Color.Empty;
			this.tbTransferTotals.nValue = ((long)(0));
			this.tbTransferTotals.Positive = System.Drawing.Color.Empty;
			this.tbTransferTotals.ReadOnly = true;
			this.tbTransferTotals.Size = new System.Drawing.Size(75, 20);
			this.tbTransferTotals.TabIndex = 6;
			this.tbTransferTotals.Text = "0";
			this.tbTransferTotals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTransferTotals.TextMode = false;
			this.tbTransferTotals.Zero = System.Drawing.Color.Empty;
			// 
			// tbTransferShort
			// 
			this.tbTransferShort.AllowDrop = true;
			this.tbTransferShort.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbTransferShort.dValue = 0;
			this.tbTransferShort.IsPcnt = false;
			this.tbTransferShort.Location = new System.Drawing.Point(181, 192);
			this.tbTransferShort.MaxDecPos = 2;
			this.tbTransferShort.MaxPos = 14;
			this.tbTransferShort.Name = "tbTransferShort";
			this.tbTransferShort.Negative = System.Drawing.Color.Empty;
			this.tbTransferShort.nValue = ((long)(0));
			this.tbTransferShort.Positive = System.Drawing.Color.Empty;
			this.tbTransferShort.ReadOnly = true;
			this.tbTransferShort.Size = new System.Drawing.Size(75, 20);
			this.tbTransferShort.TabIndex = 6;
			this.tbTransferShort.Text = "0";
			this.tbTransferShort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTransferShort.TextMode = false;
			this.tbTransferShort.Zero = System.Drawing.Color.Empty;
			// 
			// tbTransferLong
			// 
			this.tbTransferLong.AllowDrop = true;
			this.tbTransferLong.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tbTransferLong.dValue = 0;
			this.tbTransferLong.IsPcnt = false;
			this.tbTransferLong.Location = new System.Drawing.Point(257, 192);
			this.tbTransferLong.MaxDecPos = 2;
			this.tbTransferLong.MaxPos = 14;
			this.tbTransferLong.Name = "tbTransferLong";
			this.tbTransferLong.Negative = System.Drawing.Color.Empty;
			this.tbTransferLong.nValue = ((long)(0));
			this.tbTransferLong.Positive = System.Drawing.Color.Empty;
			this.tbTransferLong.ReadOnly = true;
			this.tbTransferLong.Size = new System.Drawing.Size(75, 20);
			this.tbTransferLong.TabIndex = 6;
			this.tbTransferLong.Text = "0";
			this.tbTransferLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTransferLong.TextMode = false;
			this.tbTransferLong.Zero = System.Drawing.Color.Empty;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(411, 73);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(112, 18);
			this.label30.TabIndex = 15;
			this.label30.Text = "Непровед. Расходы:";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxV4
			// 
			this.textBoxV4.AllowDrop = true;
			this.textBoxV4.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV4.dValue = 0;
			this.textBoxV4.Enabled = false;
			this.textBoxV4.IsPcnt = false;
			this.textBoxV4.Location = new System.Drawing.Point(600, 72);
			this.textBoxV4.MaxDecPos = 2;
			this.textBoxV4.MaxPos = 14;
			this.textBoxV4.Name = "textBoxV4";
			this.textBoxV4.Negative = System.Drawing.Color.Empty;
			this.textBoxV4.nValue = ((long)(0));
			this.textBoxV4.Positive = System.Drawing.Color.Empty;
			this.textBoxV4.ReadOnly = true;
			this.textBoxV4.Size = new System.Drawing.Size(75, 20);
			this.textBoxV4.TabIndex = 0;
			this.textBoxV4.Text = "0";
			this.textBoxV4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV4.TextMode = false;
			this.textBoxV4.Zero = System.Drawing.Color.Empty;
			// 
			// tbUnknownExpenditure
			// 
			this.tbUnknownExpenditure.AllowDrop = true;
			this.tbUnknownExpenditure.dValue = 0;
			this.tbUnknownExpenditure.IsPcnt = false;
			this.tbUnknownExpenditure.Location = new System.Drawing.Point(524, 72);
			this.tbUnknownExpenditure.MaxDecPos = 2;
			this.tbUnknownExpenditure.MaxPos = 14;
			this.tbUnknownExpenditure.Name = "tbUnknownExpenditure";
			this.tbUnknownExpenditure.Negative = System.Drawing.Color.Empty;
			this.tbUnknownExpenditure.nValue = ((long)(0));
			this.tbUnknownExpenditure.Positive = System.Drawing.Color.Empty;
			this.tbUnknownExpenditure.ReadOnly = true;
			this.tbUnknownExpenditure.Size = new System.Drawing.Size(75, 20);
			this.tbUnknownExpenditure.TabIndex = 6;
			this.tbUnknownExpenditure.Text = "0";
			this.tbUnknownExpenditure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbUnknownExpenditure.TextMode = false;
			this.tbUnknownExpenditure.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV12
			// 
			this.textBoxV12.AllowDrop = true;
			this.textBoxV12.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV12.dValue = 0;
			this.textBoxV12.Enabled = false;
			this.textBoxV12.IsPcnt = false;
			this.textBoxV12.Location = new System.Drawing.Point(676, 72);
			this.textBoxV12.MaxDecPos = 2;
			this.textBoxV12.MaxPos = 14;
			this.textBoxV12.Name = "textBoxV12";
			this.textBoxV12.Negative = System.Drawing.Color.Empty;
			this.textBoxV12.nValue = ((long)(0));
			this.textBoxV12.Positive = System.Drawing.Color.Empty;
			this.textBoxV12.ReadOnly = true;
			this.textBoxV12.Size = new System.Drawing.Size(75, 20);
			this.textBoxV12.TabIndex = 0;
			this.textBoxV12.Text = "0";
			this.textBoxV12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV12.TextMode = false;
			this.textBoxV12.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV13
			// 
			this.textBoxV13.AllowDrop = true;
			this.textBoxV13.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV13.dValue = 0;
			this.textBoxV13.Enabled = false;
			this.textBoxV13.IsPcnt = false;
			this.textBoxV13.Location = new System.Drawing.Point(752, 72);
			this.textBoxV13.MaxDecPos = 2;
			this.textBoxV13.MaxPos = 14;
			this.textBoxV13.Name = "textBoxV13";
			this.textBoxV13.Negative = System.Drawing.Color.Empty;
			this.textBoxV13.nValue = ((long)(0));
			this.textBoxV13.Positive = System.Drawing.Color.Empty;
			this.textBoxV13.ReadOnly = true;
			this.textBoxV13.Size = new System.Drawing.Size(75, 20);
			this.textBoxV13.TabIndex = 0;
			this.textBoxV13.Text = "0";
			this.textBoxV13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV13.TextMode = false;
			this.textBoxV13.Zero = System.Drawing.Color.Empty;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(2, 116);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(101, 18);
			this.label31.TabIndex = 11;
			this.label31.Text = "Кредитов выдано:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxV11
			// 
			this.textBoxV11.AllowDrop = true;
			this.textBoxV11.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV11.dValue = 0;
			this.textBoxV11.Enabled = false;
			this.textBoxV11.IsPcnt = false;
			this.textBoxV11.Location = new System.Drawing.Point(333, 114);
			this.textBoxV11.MaxDecPos = 2;
			this.textBoxV11.MaxPos = 14;
			this.textBoxV11.Name = "textBoxV11";
			this.textBoxV11.Negative = System.Drawing.Color.Empty;
			this.textBoxV11.nValue = ((long)(0));
			this.textBoxV11.Positive = System.Drawing.Color.Empty;
			this.textBoxV11.ReadOnly = true;
			this.textBoxV11.Size = new System.Drawing.Size(75, 20);
			this.textBoxV11.TabIndex = 0;
			this.textBoxV11.Text = "0";
			this.textBoxV11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV11.TextMode = false;
			this.textBoxV11.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV14
			// 
			this.textBoxV14.AllowDrop = true;
			this.textBoxV14.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV14.dValue = 0;
			this.textBoxV14.Enabled = false;
			this.textBoxV14.IsPcnt = false;
			this.textBoxV14.Location = new System.Drawing.Point(257, 114);
			this.textBoxV14.MaxDecPos = 2;
			this.textBoxV14.MaxPos = 14;
			this.textBoxV14.Name = "textBoxV14";
			this.textBoxV14.Negative = System.Drawing.Color.Empty;
			this.textBoxV14.nValue = ((long)(0));
			this.textBoxV14.Positive = System.Drawing.Color.Empty;
			this.textBoxV14.ReadOnly = true;
			this.textBoxV14.Size = new System.Drawing.Size(75, 20);
			this.textBoxV14.TabIndex = 0;
			this.textBoxV14.Text = "0";
			this.textBoxV14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV14.TextMode = false;
			this.textBoxV14.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV15
			// 
			this.textBoxV15.AllowDrop = true;
			this.textBoxV15.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV15.dValue = 0;
			this.textBoxV15.Enabled = false;
			this.textBoxV15.IsPcnt = false;
			this.textBoxV15.Location = new System.Drawing.Point(181, 114);
			this.textBoxV15.MaxDecPos = 2;
			this.textBoxV15.MaxPos = 14;
			this.textBoxV15.Name = "textBoxV15";
			this.textBoxV15.Negative = System.Drawing.Color.Empty;
			this.textBoxV15.nValue = ((long)(0));
			this.textBoxV15.Positive = System.Drawing.Color.Empty;
			this.textBoxV15.ReadOnly = true;
			this.textBoxV15.Size = new System.Drawing.Size(75, 20);
			this.textBoxV15.TabIndex = 0;
			this.textBoxV15.Text = "0";
			this.textBoxV15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV15.TextMode = false;
			this.textBoxV15.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumCreditsOut
			// 
			this.tbSumCreditsOut.AllowDrop = true;
			this.tbSumCreditsOut.dValue = 0;
			this.tbSumCreditsOut.IsPcnt = false;
			this.tbSumCreditsOut.Location = new System.Drawing.Point(105, 114);
			this.tbSumCreditsOut.MaxDecPos = 2;
			this.tbSumCreditsOut.MaxPos = 14;
			this.tbSumCreditsOut.Name = "tbSumCreditsOut";
			this.tbSumCreditsOut.Negative = System.Drawing.Color.Empty;
			this.tbSumCreditsOut.nValue = ((long)(0));
			this.tbSumCreditsOut.Positive = System.Drawing.Color.Empty;
			this.tbSumCreditsOut.ReadOnly = true;
			this.tbSumCreditsOut.Size = new System.Drawing.Size(75, 20);
			this.tbSumCreditsOut.TabIndex = 0;
			this.tbSumCreditsOut.Text = "0";
			this.tbSumCreditsOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCreditsOut.TextMode = false;
			this.tbSumCreditsOut.Zero = System.Drawing.Color.Empty;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(2, 137);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(101, 18);
			this.label32.TabIndex = 11;
			this.label32.Text = "Кредитов получ.:";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSumCreditsIn
			// 
			this.tbSumCreditsIn.AllowDrop = true;
			this.tbSumCreditsIn.dValue = 0;
			this.tbSumCreditsIn.IsPcnt = false;
			this.tbSumCreditsIn.Location = new System.Drawing.Point(105, 135);
			this.tbSumCreditsIn.MaxDecPos = 2;
			this.tbSumCreditsIn.MaxPos = 14;
			this.tbSumCreditsIn.Name = "tbSumCreditsIn";
			this.tbSumCreditsIn.Negative = System.Drawing.Color.Empty;
			this.tbSumCreditsIn.nValue = ((long)(0));
			this.tbSumCreditsIn.Positive = System.Drawing.Color.Empty;
			this.tbSumCreditsIn.ReadOnly = true;
			this.tbSumCreditsIn.Size = new System.Drawing.Size(75, 20);
			this.tbSumCreditsIn.TabIndex = 0;
			this.tbSumCreditsIn.Text = "0";
			this.tbSumCreditsIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumCreditsIn.TextMode = false;
			this.tbSumCreditsIn.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV17
			// 
			this.textBoxV17.AllowDrop = true;
			this.textBoxV17.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV17.dValue = 0;
			this.textBoxV17.Enabled = false;
			this.textBoxV17.IsPcnt = false;
			this.textBoxV17.Location = new System.Drawing.Point(257, 135);
			this.textBoxV17.MaxDecPos = 2;
			this.textBoxV17.MaxPos = 14;
			this.textBoxV17.Name = "textBoxV17";
			this.textBoxV17.Negative = System.Drawing.Color.Empty;
			this.textBoxV17.nValue = ((long)(0));
			this.textBoxV17.Positive = System.Drawing.Color.Empty;
			this.textBoxV17.ReadOnly = true;
			this.textBoxV17.Size = new System.Drawing.Size(75, 20);
			this.textBoxV17.TabIndex = 0;
			this.textBoxV17.Text = "0";
			this.textBoxV17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV17.TextMode = false;
			this.textBoxV17.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV18
			// 
			this.textBoxV18.AllowDrop = true;
			this.textBoxV18.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV18.dValue = 0;
			this.textBoxV18.Enabled = false;
			this.textBoxV18.IsPcnt = false;
			this.textBoxV18.Location = new System.Drawing.Point(333, 135);
			this.textBoxV18.MaxDecPos = 2;
			this.textBoxV18.MaxPos = 14;
			this.textBoxV18.Name = "textBoxV18";
			this.textBoxV18.Negative = System.Drawing.Color.Empty;
			this.textBoxV18.nValue = ((long)(0));
			this.textBoxV18.Positive = System.Drawing.Color.Empty;
			this.textBoxV18.ReadOnly = true;
			this.textBoxV18.Size = new System.Drawing.Size(75, 20);
			this.textBoxV18.TabIndex = 0;
			this.textBoxV18.Text = "0";
			this.textBoxV18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV18.TextMode = false;
			this.textBoxV18.Zero = System.Drawing.Color.Empty;
			// 
			// textBoxV19
			// 
			this.textBoxV19.AllowDrop = true;
			this.textBoxV19.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxV19.dValue = 0;
			this.textBoxV19.Enabled = false;
			this.textBoxV19.IsPcnt = false;
			this.textBoxV19.Location = new System.Drawing.Point(181, 135);
			this.textBoxV19.MaxDecPos = 2;
			this.textBoxV19.MaxPos = 14;
			this.textBoxV19.Name = "textBoxV19";
			this.textBoxV19.Negative = System.Drawing.Color.Empty;
			this.textBoxV19.nValue = ((long)(0));
			this.textBoxV19.Positive = System.Drawing.Color.Empty;
			this.textBoxV19.ReadOnly = true;
			this.textBoxV19.Size = new System.Drawing.Size(75, 20);
			this.textBoxV19.TabIndex = 0;
			this.textBoxV19.Text = "0";
			this.textBoxV19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV19.TextMode = false;
			this.textBoxV19.Zero = System.Drawing.Color.Empty;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tbSumRevenue);
			this.tabPage2.Controls.Add(this.tbSumProgress);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.tbSumService);
			this.tabPage2.Controls.Add(this.tbSumExchange);
			this.tabPage2.Controls.Add(this.tbSumExpenditure);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.tbSumTransit);
			this.tabPage2.Controls.Add(this.label33);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(832, 222);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Наше";
			// 
			// tbSumRevenue
			// 
			this.tbSumRevenue.AllowDrop = true;
			this.tbSumRevenue.dValue = 0;
			this.tbSumRevenue.IsPcnt = false;
			this.tbSumRevenue.Location = new System.Drawing.Point(204, 72);
			this.tbSumRevenue.MaxDecPos = 2;
			this.tbSumRevenue.MaxPos = 14;
			this.tbSumRevenue.Name = "tbSumRevenue";
			this.tbSumRevenue.Negative = System.Drawing.Color.Empty;
			this.tbSumRevenue.nValue = ((long)(0));
			this.tbSumRevenue.Positive = System.Drawing.Color.Empty;
			this.tbSumRevenue.ReadOnly = true;
			this.tbSumRevenue.TabIndex = 14;
			this.tbSumRevenue.Text = "0";
			this.tbSumRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumRevenue.TextMode = false;
			this.tbSumRevenue.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumProgress
			// 
			this.tbSumProgress.AllowDrop = true;
			this.tbSumProgress.dValue = 0;
			this.tbSumProgress.IsPcnt = false;
			this.tbSumProgress.Location = new System.Drawing.Point(204, 28);
			this.tbSumProgress.MaxDecPos = 2;
			this.tbSumProgress.MaxPos = 14;
			this.tbSumProgress.Name = "tbSumProgress";
			this.tbSumProgress.Negative = System.Drawing.Color.Empty;
			this.tbSumProgress.nValue = ((long)(0));
			this.tbSumProgress.Positive = System.Drawing.Color.Empty;
			this.tbSumProgress.ReadOnly = true;
			this.tbSumProgress.TabIndex = 5;
			this.tbSumProgress.Text = "0";
			this.tbSumProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumProgress.TextMode = false;
			this.tbSumProgress.Zero = System.Drawing.Color.Empty;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(190, 18);
			this.label3.TabIndex = 7;
			this.label3.Text = "Сумма на У/С Затрат на Развитие:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSumService
			// 
			this.tbSumService.AllowDrop = true;
			this.tbSumService.dValue = 0;
			this.tbSumService.IsPcnt = false;
			this.tbSumService.Location = new System.Drawing.Point(204, 6);
			this.tbSumService.MaxDecPos = 2;
			this.tbSumService.MaxPos = 14;
			this.tbSumService.Name = "tbSumService";
			this.tbSumService.Negative = System.Drawing.Color.Empty;
			this.tbSumService.nValue = ((long)(0));
			this.tbSumService.Positive = System.Drawing.Color.Empty;
			this.tbSumService.ReadOnly = true;
			this.tbSumService.TabIndex = 3;
			this.tbSumService.Text = "0";
			this.tbSumService.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumService.TextMode = false;
			this.tbSumService.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumExchange
			// 
			this.tbSumExchange.AllowDrop = true;
			this.tbSumExchange.dValue = 0;
			this.tbSumExchange.IsPcnt = false;
			this.tbSumExchange.Location = new System.Drawing.Point(204, 94);
			this.tbSumExchange.MaxDecPos = 2;
			this.tbSumExchange.MaxPos = 14;
			this.tbSumExchange.Name = "tbSumExchange";
			this.tbSumExchange.Negative = System.Drawing.Color.Empty;
			this.tbSumExchange.nValue = ((long)(0));
			this.tbSumExchange.Positive = System.Drawing.Color.Empty;
			this.tbSumExchange.ReadOnly = true;
			this.tbSumExchange.TabIndex = 4;
			this.tbSumExchange.Text = "0";
			this.tbSumExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumExchange.TextMode = false;
			this.tbSumExchange.Zero = System.Drawing.Color.Empty;
			// 
			// tbSumExpenditure
			// 
			this.tbSumExpenditure.AllowDrop = true;
			this.tbSumExpenditure.dValue = 0;
			this.tbSumExpenditure.IsPcnt = false;
			this.tbSumExpenditure.Location = new System.Drawing.Point(204, 50);
			this.tbSumExpenditure.MaxDecPos = 2;
			this.tbSumExpenditure.MaxPos = 14;
			this.tbSumExpenditure.Name = "tbSumExpenditure";
			this.tbSumExpenditure.Negative = System.Drawing.Color.Empty;
			this.tbSumExpenditure.nValue = ((long)(0));
			this.tbSumExpenditure.Positive = System.Drawing.Color.Empty;
			this.tbSumExpenditure.ReadOnly = true;
			this.tbSumExpenditure.TabIndex = 12;
			this.tbSumExpenditure.Text = "0";
			this.tbSumExpenditure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumExpenditure.TextMode = false;
			this.tbSumExpenditure.Zero = System.Drawing.Color.Empty;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(10, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(190, 18);
			this.label9.TabIndex = 15;
			this.label9.Text = "Сумма Расходов:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(190, 18);
			this.label5.TabIndex = 9;
			this.label5.Text = "Сумма на У/С %% Обсл.:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(10, 50);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(190, 18);
			this.label8.TabIndex = 13;
			this.label8.Text = "Сумма Доходов:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(190, 18);
			this.label4.TabIndex = 8;
			this.label4.Text = "Сумма на У/С Курсовых:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSumTransit
			// 
			this.tbSumTransit.AllowDrop = true;
			this.tbSumTransit.dValue = 0;
			this.tbSumTransit.IsPcnt = false;
			this.tbSumTransit.Location = new System.Drawing.Point(204, 116);
			this.tbSumTransit.MaxDecPos = 2;
			this.tbSumTransit.MaxPos = 14;
			this.tbSumTransit.Name = "tbSumTransit";
			this.tbSumTransit.Negative = System.Drawing.Color.Empty;
			this.tbSumTransit.nValue = ((long)(0));
			this.tbSumTransit.Positive = System.Drawing.Color.Empty;
			this.tbSumTransit.ReadOnly = true;
			this.tbSumTransit.TabIndex = 4;
			this.tbSumTransit.Text = "0";
			this.tbSumTransit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumTransit.TextMode = false;
			this.tbSumTransit.Zero = System.Drawing.Color.Empty;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(10, 118);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(190, 18);
			this.label33.TabIndex = 8;
			this.label33.Text = "Сумма на У/С Транзита:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgAccountsState);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 35);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(840, 238);
			this.panel3.TabIndex = 2;
			// 
			// dgAccountsState
			// 
			this.dgAccountsState.CaptionVisible = false;
			this.dgAccountsState.DataMember = "BalanceAccountsByTypeSummary";
			this.dgAccountsState.DataSource = this.dsBalanceAccountsState1;
			this.dgAccountsState.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgAccountsState.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAccountsState.Location = new System.Drawing.Point(0, 0);
			this.dgAccountsState.Name = "dgAccountsState";
			this.dgAccountsState.ReadOnly = true;
			this.dgAccountsState.Size = new System.Drawing.Size(840, 238);
			this.dgAccountsState.TabIndex = 0;
			this.dgAccountsState.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgAccountsState;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnAccountTypeID,
																												  this.ColumnTypeName,
																												  this.ColumnSumSaldo,
																												  this.ColumnSumSumReserved,
																												  this.ColumnSumSumWaited,
																												  this.ColumnSumSumFree,
																												  this.ColumnCurrencyID});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "BalanceAccountsByTypeSummary";
			// 
			// ColumnAccountTypeID
			// 
			this.ColumnAccountTypeID.Format = "0000";
			this.ColumnAccountTypeID.FormatInfo = null;
			this.ColumnAccountTypeID.HeaderText = "ID Типа";
			this.ColumnAccountTypeID.MappingName = "AccountTypeID";
			this.ColumnAccountTypeID.Width = 90;
			// 
			// ColumnTypeName
			// 
			this.ColumnTypeName.Format = "";
			this.ColumnTypeName.FormatInfo = null;
			this.ColumnTypeName.HeaderText = "Тип";
			this.ColumnTypeName.MappingName = "TypeName";
			this.ColumnTypeName.Width = 250;
			// 
			// ColumnSumSaldo
			// 
			this.ColumnSumSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSumSaldo.Format = "#,##0.00;;\"-\"";
			this.ColumnSumSaldo.FormatInfo = null;
			this.ColumnSumSaldo.HeaderText = "Сальдо";
			this.ColumnSumSaldo.MappingName = "SumSaldo";
			this.ColumnSumSaldo.NullText = "-";
			this.ColumnSumSaldo.Width = 90;
			// 
			// ColumnSumSumReserved
			// 
			this.ColumnSumSumReserved.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSumSumReserved.Format = "#,##0.00;;\"-\"";
			this.ColumnSumSumReserved.FormatInfo = null;
			this.ColumnSumSumReserved.HeaderText = "Резерв";
			this.ColumnSumSumReserved.MappingName = "SumSumReserved";
			this.ColumnSumSumReserved.Width = 90;
			// 
			// ColumnSumSumWaited
			// 
			this.ColumnSumSumWaited.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSumSumWaited.Format = "#,##0.00;;\"-\"";
			this.ColumnSumSumWaited.FormatInfo = null;
			this.ColumnSumSumWaited.HeaderText = "Ожидается";
			this.ColumnSumSumWaited.MappingName = "SumSumWaited";
			this.ColumnSumSumWaited.Width = 90;
			// 
			// ColumnSumSumFree
			// 
			this.ColumnSumSumFree.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSumSumFree.Format = "#,##0.00;;\"-\"";
			this.ColumnSumSumFree.FormatInfo = null;
			this.ColumnSumSumFree.HeaderText = "Доступно";
			this.ColumnSumSumFree.MappingName = "SumSumFree";
			this.ColumnSumSumFree.Width = 90;
			// 
			// ColumnCurrencyID
			// 
			this.ColumnCurrencyID.Format = "";
			this.ColumnCurrencyID.FormatInfo = null;
			this.ColumnCurrencyID.HeaderText = "Валюта";
			this.ColumnCurrencyID.MappingName = "CurrencyID";
			this.ColumnCurrencyID.NullText = "-";
			this.ColumnCurrencyID.Width = 50;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbtnRefresh});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(840, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbtnRefresh
			// 
			this.tbtnRefresh.ImageIndex = 0;
			this.tbtnRefresh.Text = "Обновить";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
																					  this.mnuRefresh});
			this.menuItem1.MergeOrder = 2;
			this.menuItem1.Text = "Редактировать";
			// 
			// mnuRefresh
			// 
			this.mnuRefresh.Index = 0;
			this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.mnuRefresh.Text = "Обновить";
			this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
			// 
			// Balance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(840, 521);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Balance";
			this.Text = "Баланс Конторы";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dsBalanceAccountsState1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgAccountsState)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
	
		private void DataRefresh()
		{
			try 
			{
				this.dsBalanceAccountsState1.BalanceAccountsByTypeSummary.Clear();
				this.sqlDataAdapter1.Fill( this.dsBalanceAccountsState1.BalanceAccountsByTypeSummary);

				this.tbBalance.dValue 			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fBalance"].Value;   
				
				this.tbSumCash.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalCash"].Value;   
				this.tbSumCashR.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalCashR"].Value;   
				this.tbSumCashW.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalCashW"].Value;   
				this.tbSumCashA.dValue			=this.tbSumCash.dValue -this.tbSumCashR.dValue;
				
				this.tbSumOuter.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalOuter"].Value;   
				this.tbSumOuterR.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalOuterR"].Value;   
				this.tbSumOuterW.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalOuterW"].Value;   
				this.tbSumOuterA.dValue			=this.tbSumOuter.dValue -this.tbSumOuterR.dValue;

				this.tbSumSettlement.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalSettlement"].Value;   
				this.tbSumSettlementR.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalSettlementR"].Value;   
				this.tbSumSettlementW.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalSettlementW"].Value;   
				this.tbSumSettlementA.dValue	=this.tbSumSettlement.dValue -this.tbSumSettlementR.dValue;

				this.tbSumExchange.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalExchange"].Value;   
				this.tbSumExpenditure.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalExpenditure"].Value;   
				this.tbSumTransit.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalTransit"].Value;

				this.tbSumPersonal.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalPersonal"].Value;   
				this.tbSumPersonalR.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalPersonalR"].Value;   
				this.tbSumPersonalW.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalPersonalW"].Value;   
				this.tbSumPersonalA.dValue		=this.tbSumPersonal.dValue -this.tbSumPersonalR.dValue;   
				
				this.tbSumProgress.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalProgress"].Value;   
				this.tbSumRevenue.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalRevenue"].Value;   
				this.tbSumService.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalService"].Value;   

				this.tbSumCredits.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fTotalCreditsOut"].Value;   
				
				this.tbUnknownIncomes.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fUnknownIncomes"].Value;   
				this.tbUnknownRevenue.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fUnknownRevenue"].Value;   
				
				this.tbState.dValue				=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fGrossAccountFact"].Value;   
				this.tbStateR.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fGrossAccountFactR"].Value;   
				this.tbStateW.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fGrossAccountFactW"].Value;   
				this.tbStateA.dValue			=this.tbState.dValue -this.tbStateR.dValue;  
 
				this.tbBalanceReserved.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@SumReservedCalc"].Value
													-(double)this.sqlDataAdapter1.SelectCommand.Parameters["@SumReservedFact"].Value; 
				this.tbBalanceWaited.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@SumWaitedCalc"].Value
													-(double)this.sqlDataAdapter1.SelectCommand.Parameters["@SumWaitedFact"].Value; 
				
				this.tbTransferTotals.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fSumTransferTotals"].Value;   
				this.tbTransferShort.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fSumTransferShort"].Value;   
				this.tbTransferLong.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fSumTransferLong"].Value;   
				
				this.tbUnknownExpenditure.dValue =(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fUnknownExpenditure"].Value;
				
				this.tbSumCreditsOut.dValue =(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fSumCreditsOut"].Value;
				this.tbSumCreditsIn.dValue  =(double)this.sqlDataAdapter1.SelectCommand.Parameters["@fSumCreditsIn"].Value;
				//
			}
			catch(Exception ex) 
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button ==this.tbtnRefresh)
				this.DataRefresh();
		}

		private void mnuRefresh_Click(object sender, System.EventArgs e)
		{
			this.DataRefresh();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}
}
