using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using BPS.BLL.Credits.DataSets;

namespace BPS._Forms.Credits
{
	/// <summary>
	/// Summary description for Credits.
	/// </summary>
	public class Credits : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private AM_Controls.DataGridV dgCreditsList;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private AM_Controls.DataGridV dgCreditHistory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.Button bnPrint;
		private System.Windows.Forms.Button bnUpdOper;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.DataView dvCredits;
		private dsCredits dsCredits1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private BPS._Forms.dsCreditsOperations dsCreditsOperations1;
		private System.Data.DataView dvCreditsOperations;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dtbTransactionID;
		private System.Windows.Forms.DataGridTextBoxColumn dtbTransactionType;
		private System.Windows.Forms.DataGridTextBoxColumn dtbOperationSum;
		private System.Windows.Forms.DataGridTextBoxColumn dtbDate;
		private System.ComponentModel.IContainer components;
		private BindingManagerBase bmCredits;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private BPS.BLL.Clients.DataSets.dsGroups dsGroups1;
		private System.Data.DataView dvGroups;
		private System.Windows.Forms.ComboBox cmbClientGroup;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private BPS.BLL.Clients.DataSets.dsClients dsClients1;
		private System.Data.DataView dvClients;
		private BindingManagerBase bmCreditsOperations;
		private System.Windows.Forms.CheckBox cbFromDate;
		private System.Windows.Forms.DateTimePicker dtFromDate;
		private System.Windows.Forms.ComboBox cmbDateType;
		private System.Windows.Forms.DateTimePicker dtTillDate;
		private System.Windows.Forms.CheckBox cbTillDate;
		private System.Windows.Forms.ComboBox cmbClientName;
		private System.Windows.Forms.ComboBox cmdGranted;
		private System.Windows.Forms.ComboBox cmbCurrency;
		private System.Windows.Forms.ComboBox cmbState;
		private BindingManagerBase bmClients;
		private System.Data.DataView dvCurrs;
		private System.Windows.Forms.ToolBarButton tbbGrant;
		private System.Windows.Forms.ToolBarButton tbbClose;
		private System.Data.SqlClient.SqlCommand sqlCmdAddNewCredit;
		private System.Data.SqlClient.SqlCommand sqlCmdEditCredit;
		private System.Data.SqlClient.SqlCommand sqlCmdDelCredit;
		private System.Data.SqlClient.SqlCommand sqlCmdGrantCredit;
		private System.Data.SqlClient.SqlCommand sqlCmdCloseCredit;
		private BPS.BLL.Currency.DataSets.dsCurr dsCurr;
		private BindingManagerBase bmGroups;
		private string strGroupFilter = string.Empty;
		private string strClientFilter = string.Empty;
		private string strDirectionFilter = string.Empty;
		private string strCurrencyFilter = string.Empty;
		private string strStateFilter = string.Empty;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.Label label7;
		private System.Data.SqlClient.SqlDataAdapter sqldaCreditsListSummary;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Windows.Forms.DataGridTextBoxColumn dtbCreditSumCurr;
		private System.Windows.Forms.ToolBarButton tbbSep1;
		private System.Windows.Forms.ToolBarButton tbbSep6;
		private System.Windows.Forms.ToolBarButton tbbPayBackCredit;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnPrintCredits;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Windows.Forms.DataGridTextBoxColumn dtbPostedDate;
		private System.Data.SqlClient.SqlCommand sqlCmdCreditRedemptionParams;
		private BPS.BLL.Credits.DataSets.dsCreditsDetails dsCreditsDetails1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
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
		private AM_Controls.DataGridV dataGridV1;
		private BPS.BLL.Credits.DataSets.dsCreditsPointsInfoList dsCreditsPointsInfoList1;
		private System.Data.SqlClient.SqlDataAdapter sqldaCreditPointsInfo;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel panel13;
		private AM_Controls.DataGridV dataGridV2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TreeView trvTotals;
		private System.Windows.Forms.CheckBox cbShowZeroTran;
		private System.Data.SqlClient.SqlDataAdapter sqldaCreditGroups;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlConnection sqlConnection3;
		private BPS._Forms.dsCreditsOperationsGroups dsCreditsOperationsGroups1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnGroupID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnGroupDate;
		private System.Windows.Forms.CheckBox cbTranByGroup;
		private string strPeriodFilter = string.Empty;
		private System.Windows.Forms.ToolBarButton tbbRollbackLastGroup;
		private System.Data.SqlClient.SqlCommand sqlCmdRollbackLastCreditGroup;
		private BPS._Forms.dsCreditsListSummary dsCreditsListSummary1;
		private System.Data.DataView dvCreditsListSummary;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnInstalmentSum;
		private System.Windows.Forms.ToolBarButton tbbIncrease;
		private System.Data.SqlClient.SqlCommand sqlCmdCreditIncrease;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuDel;
		private System.Windows.Forms.MenuItem mnuGrant;
		private System.Windows.Forms.MenuItem mnuIncrease;
		private System.Windows.Forms.MenuItem mnuDebt;
		private System.Windows.Forms.MenuItem mnuClose;
		private System.Windows.Forms.MenuItem mnuUndo;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem mnuPrint;
		private System.Windows.Forms.MenuItem mnuRefresh;
		private System.Windows.Forms.MenuItem menuItem4;
		private int m_OperationsGroupIDCurrent =0;

		public Credits()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);
			App.SetDataGridTableStyle(this.dataGridTableStyle3);
			App.Clone(menuItem1.MenuItems, this.contextMenu1);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Credits));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuDel = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuGrant = new System.Windows.Forms.MenuItem();
			this.mnuIncrease = new System.Windows.Forms.MenuItem();
			this.mnuDebt = new System.Windows.Forms.MenuItem();
			this.mnuClose = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.mnuUndo = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.tbbSep1 = new System.Windows.Forms.ToolBarButton();
			this.tbbGrant = new System.Windows.Forms.ToolBarButton();
			this.tbbIncrease = new System.Windows.Forms.ToolBarButton();
			this.tbbPayBackCredit = new System.Windows.Forms.ToolBarButton();
			this.tbbClose = new System.Windows.Forms.ToolBarButton();
			this.tbbSep6 = new System.Windows.Forms.ToolBarButton();
			this.tbbRollbackLastGroup = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel13 = new System.Windows.Forms.Panel();
			this.dgCreditHistory = new AM_Controls.DataGridV();
			this.dvCreditsOperations = new System.Data.DataView();
			this.dsCreditsOperations1 = new BPS._Forms.dsCreditsOperations();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dtbTransactionID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbTransactionType = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbPostedDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbOperationSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbCreditSumCurr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.panel12 = new System.Windows.Forms.Panel();
			this.dataGridV2 = new AM_Controls.DataGridV();
			this.dsCreditsOperationsGroups1 = new BPS._Forms.dsCreditsOperationsGroups();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnGroupID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnGroupDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnInstalmentSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.bnPrint = new System.Windows.Forms.Button();
			this.bnUpdOper = new System.Windows.Forms.Button();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.dgCreditsList = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.dvCredits = new System.Data.DataView();
			this.dsCredits1 = new BPS.BLL.Credits.DataSets.dsCredits();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnPrintCredits = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel4 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbShowZeroTran = new System.Windows.Forms.CheckBox();
			this.cbTranByGroup = new System.Windows.Forms.CheckBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnFilter = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbFromDate = new System.Windows.Forms.CheckBox();
			this.dtFromDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbDateType = new System.Windows.Forms.ComboBox();
			this.dtTillDate = new System.Windows.Forms.DateTimePicker();
			this.cbTillDate = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbClientGroup = new System.Windows.Forms.ComboBox();
			this.dvGroups = new System.Data.DataView();
			this.dsGroups1 = new BPS.BLL.Clients.DataSets.dsGroups();
			this.cmbClientName = new System.Windows.Forms.ComboBox();
			this.dvClients = new System.Data.DataView();
			this.dsClients1 = new BPS.BLL.Clients.DataSets.dsClients();
			this.cmdGranted = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbCurrency = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbState = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.trvTotals = new System.Windows.Forms.TreeView();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.dvCurrs = new System.Data.DataView();
			this.sqlCmdAddNewCredit = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdEditCredit = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelCredit = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGrantCredit = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdCloseCredit = new System.Data.SqlClient.SqlCommand();
			this.sqldaCreditsListSummary = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdCreditRedemptionParams = new System.Data.SqlClient.SqlCommand();
			this.dsCreditsDetails1 = new BPS.BLL.Credits.DataSets.dsCreditsDetails();
			this.dsCreditsPointsInfoList1 = new BPS.BLL.Credits.DataSets.dsCreditsPointsInfoList();
			this.sqldaCreditPointsInfo = new System.Data.SqlClient.SqlDataAdapter();
			this.sqldaCreditGroups = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection3 = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdRollbackLastCreditGroup = new System.Data.SqlClient.SqlCommand();
			this.dsCreditsListSummary1 = new BPS._Forms.dsCreditsListSummary();
			this.dvCreditsListSummary = new System.Data.DataView();
			this.sqlCmdCreditIncrease = new System.Data.SqlClient.SqlCommand();
			this.contextMenu2 = new System.Windows.Forms.ContextMenu();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuPrint = new System.Windows.Forms.MenuItem();
			this.mnuRefresh = new System.Windows.Forms.MenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel13.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCreditHistory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCreditsOperations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsOperations1)).BeginInit();
			this.panel12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsOperationsGroups1)).BeginInit();
			this.panel9.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCreditsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCredits)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCredits1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvGroups)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsGroups1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClients1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurrs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsDetails1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsPointsInfoList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsListSummary1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCreditsListSummary)).BeginInit();
			this.SuspendLayout();
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
																					  this.mnuNew,
																					  this.mnuEdit,
																					  this.mnuDel,
																					  this.menuItem5,
																					  this.mnuGrant,
																					  this.mnuIncrease,
																					  this.mnuDebt,
																					  this.mnuClose,
																					  this.menuItem10,
																					  this.mnuUndo});
			this.menuItem1.Text = "Редактировать";
			this.menuItem1.Popup += new System.EventHandler(this.menuItem1_Popup);
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.mnuNew.Text = "Новый";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 1;
			this.mnuEdit.Text = "Изменить";
			this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
			// 
			// mnuDel
			// 
			this.mnuDel.Index = 2;
			this.mnuDel.Text = "Удалить";
			this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// mnuGrant
			// 
			this.mnuGrant.Index = 4;
			this.mnuGrant.Text = "Выдать";
			this.mnuGrant.Click += new System.EventHandler(this.mnuGrant_Click);
			// 
			// mnuIncrease
			// 
			this.mnuIncrease.Index = 5;
			this.mnuIncrease.Text = "Увеличить тело";
			this.mnuIncrease.Click += new System.EventHandler(this.mnuIncrease_Click);
			// 
			// mnuDebt
			// 
			this.mnuDebt.Index = 6;
			this.mnuDebt.Text = "Погасить";
			this.mnuDebt.Click += new System.EventHandler(this.mnuDebt_Click);
			// 
			// mnuClose
			// 
			this.mnuClose.Index = 7;
			this.mnuClose.Text = "Закрыть";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 8;
			this.menuItem10.Text = "-";
			// 
			// mnuUndo
			// 
			this.mnuUndo.Index = 9;
			this.mnuUndo.Text = "Откатить";
			this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel,
																						this.tbbSep1,
																						this.tbbGrant,
																						this.tbbIncrease,
																						this.tbbPayBackCredit,
																						this.tbbClose,
																						this.tbbSep6,
																						this.tbbRollbackLastGroup});
			this.toolBar1.ButtonSize = new System.Drawing.Size(80, 25);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(892, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "Новый";
			this.tbbNew.ToolTipText = "Создание кредита";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Открыть";
			this.tbbEdit.ToolTipText = "Изменение параметров кредита";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 3;
			this.tbbDel.Text = "Удалить";
			this.tbbDel.ToolTipText = "Удаление кредита";
			// 
			// tbbSep1
			// 
			this.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbGrant
			// 
			this.tbbGrant.ImageIndex = 14;
			this.tbbGrant.Text = "Выдать";
			this.tbbGrant.ToolTipText = "Перевод Кредита в состояние \'Активен\'";
			// 
			// tbbIncrease
			// 
			this.tbbIncrease.ImageIndex = 16;
			this.tbbIncrease.Text = "Увел. Тело";
			this.tbbIncrease.ToolTipText = "Увеличить тело кредита";
			// 
			// tbbPayBackCredit
			// 
			this.tbbPayBackCredit.ImageIndex = 13;
			this.tbbPayBackCredit.Text = "Погасить";
			this.tbbPayBackCredit.ToolTipText = "Операции по начислению % и погашению";
			// 
			// tbbClose
			// 
			this.tbbClose.ImageIndex = 12;
			this.tbbClose.Text = "Закрыть";
			this.tbbClose.ToolTipText = "Закрытие кредита";
			// 
			// tbbSep6
			// 
			this.tbbSep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbRollbackLastGroup
			// 
			this.tbbRollbackLastGroup.ImageIndex = 15;
			this.tbbRollbackLastGroup.Text = "Откатить";
			this.tbbRollbackLastGroup.ToolTipText = "Откатить последние операции";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(892, 627);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.splitter2);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(263, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(629, 627);
			this.panel2.TabIndex = 4;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel5.Controls.Add(this.panel11);
			this.panel5.Controls.Add(this.panel10);
			this.panel5.Controls.Add(this.panel9);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel5.Location = new System.Drawing.Point(0, 345);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(629, 282);
			this.panel5.TabIndex = 2;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.panel13);
			this.panel11.Controls.Add(this.splitter3);
			this.panel11.Controls.Add(this.panel12);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel11.Location = new System.Drawing.Point(0, 28);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(625, 234);
			this.panel11.TabIndex = 2;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.dgCreditHistory);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel13.Location = new System.Drawing.Point(315, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(310, 234);
			this.panel13.TabIndex = 3;
			// 
			// dgCreditHistory
			// 
			this.dgCreditHistory._CanEdit = false;
			this.dgCreditHistory._InvisibleColumn = 0;
			this.dgCreditHistory.BackgroundColor = System.Drawing.Color.LightGray;
			this.dgCreditHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgCreditHistory.CaptionText = "Операции по Кредиту";
			this.dgCreditHistory.DataMember = "";
			this.dgCreditHistory.DataSource = this.dvCreditsOperations;
			this.dgCreditHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgCreditHistory.FlatMode = true;
			this.dgCreditHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCreditHistory.Location = new System.Drawing.Point(0, 0);
			this.dgCreditHistory.Name = "dgCreditHistory";
			this.dgCreditHistory.Size = new System.Drawing.Size(310, 234);
			this.dgCreditHistory.TabIndex = 0;
			this.dgCreditHistory.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										this.dataGridTableStyle2});
			// 
			// dvCreditsOperations
			// 
			this.dvCreditsOperations.AllowDelete = false;
			this.dvCreditsOperations.AllowEdit = false;
			this.dvCreditsOperations.AllowNew = false;
			this.dvCreditsOperations.Table = this.dsCreditsOperations1.CreditsOperations;
			// 
			// dsCreditsOperations1
			// 
			this.dsCreditsOperations1.DataSetName = "dsCreditsOperations";
			this.dsCreditsOperations1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dgCreditHistory;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dtbTransactionID,
																												  this.dtbTransactionType,
																												  this.dtbDate,
																												  this.dtbPostedDate,
																												  this.dtbOperationSum,
																												  this.dtbCreditSumCurr});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "CreditsOperations";
			// 
			// dtbTransactionID
			// 
			this.dtbTransactionID.Format = "";
			this.dtbTransactionID.FormatInfo = null;
			this.dtbTransactionID.HeaderText = "Номер";
			this.dtbTransactionID.MappingName = "TransactionID";
			this.dtbTransactionID.NullText = "-";
			this.dtbTransactionID.Width = 40;
			// 
			// dtbTransactionType
			// 
			this.dtbTransactionType.Format = "";
			this.dtbTransactionType.FormatInfo = null;
			this.dtbTransactionType.HeaderText = "Тип транзакции";
			this.dtbTransactionType.MappingName = "TransactionTypeName";
			this.dtbTransactionType.NullText = "-";
			this.dtbTransactionType.Width = 220;
			// 
			// dtbDate
			// 
			this.dtbDate.Format = "dd-MMM-yy";
			this.dtbDate.FormatInfo = null;
			this.dtbDate.HeaderText = "Дата кр";
			this.dtbDate.MappingName = "OperationDate";
			this.dtbDate.NullText = "-";
			this.dtbDate.Width = 75;
			// 
			// dtbPostedDate
			// 
			this.dtbPostedDate.Format = "dd-MMM-yy";
			this.dtbPostedDate.FormatInfo = null;
			this.dtbPostedDate.HeaderText = "Дата тр";
			this.dtbPostedDate.MappingName = "PostedDate";
			this.dtbPostedDate.NullText = "-";
			this.dtbPostedDate.Width = 75;
			// 
			// dtbOperationSum
			// 
			this.dtbOperationSum.Format = "0.00";
			this.dtbOperationSum.FormatInfo = null;
			this.dtbOperationSum.HeaderText = "Сумма";
			this.dtbOperationSum.MappingName = "SumFrom";
			this.dtbOperationSum.NullText = "-";
			this.dtbOperationSum.Width = 75;
			// 
			// dtbCreditSumCurr
			// 
			this.dtbCreditSumCurr.Format = "";
			this.dtbCreditSumCurr.FormatInfo = null;
			this.dtbCreditSumCurr.HeaderText = "Валюта";
			this.dtbCreditSumCurr.MappingName = "CreditSumCurrency";
			this.dtbCreditSumCurr.NullText = "-";
			this.dtbCreditSumCurr.Width = 75;
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(310, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(5, 234);
			this.splitter3.TabIndex = 2;
			this.splitter3.TabStop = false;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.dataGridV2);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel12.Location = new System.Drawing.Point(0, 0);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(310, 234);
			this.panel12.TabIndex = 1;
			// 
			// dataGridV2
			// 
			this.dataGridV2._CanEdit = false;
			this.dataGridV2._InvisibleColumn = 0;
			this.dataGridV2.AllowSorting = false;
			this.dataGridV2.BackgroundColor = System.Drawing.Color.LightGray;
			this.dataGridV2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridV2.CaptionText = "Журнал Операций";
			this.dataGridV2.DataMember = "CreditsOperationsGroups";
			this.dataGridV2.DataSource = this.dsCreditsOperationsGroups1;
			this.dataGridV2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV2.FlatMode = true;
			this.dataGridV2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV2.Location = new System.Drawing.Point(0, 0);
			this.dataGridV2.Name = "dataGridV2";
			this.dataGridV2.ReadOnly = true;
			this.dataGridV2.Size = new System.Drawing.Size(310, 234);
			this.dataGridV2.TabIndex = 0;
			this.dataGridV2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle3});
			// 
			// dsCreditsOperationsGroups1
			// 
			this.dsCreditsOperationsGroups1.DataSetName = "dsCreditsOperationsGroups";
			this.dsCreditsOperationsGroups1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.AllowSorting = false;
			this.dataGridTableStyle3.DataGrid = this.dataGridV2;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnGroupID,
																												  this.ColumnGroupDate,
																												  this.ColumnInstalmentSum});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "CreditsOperationsGroups";
			// 
			// ColumnGroupID
			// 
			this.ColumnGroupID.Format = "";
			this.ColumnGroupID.FormatInfo = null;
			this.ColumnGroupID.HeaderText = "Группа";
			this.ColumnGroupID.MappingName = "GroupID";
			this.ColumnGroupID.NullText = "-";
			this.ColumnGroupID.Width = 75;
			// 
			// ColumnGroupDate
			// 
			this.ColumnGroupDate.Format = "dd-MMM-yy HH:mm";
			this.ColumnGroupDate.FormatInfo = null;
			this.ColumnGroupDate.HeaderText = "Дата";
			this.ColumnGroupDate.MappingName = "GroupDate";
			this.ColumnGroupDate.NullText = "-";
			this.ColumnGroupDate.Width = 75;
			// 
			// ColumnInstalmentSum
			// 
			this.ColumnInstalmentSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnInstalmentSum.Format = "#,##0.00";
			this.ColumnInstalmentSum.FormatInfo = null;
			this.ColumnInstalmentSum.HeaderText = "Взнос";
			this.ColumnInstalmentSum.MappingName = "InstalmentSum";
			this.ColumnInstalmentSum.NullText = "-";
			this.ColumnInstalmentSum.Width = 75;
			// 
			// panel10
			// 
			this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel10.Location = new System.Drawing.Point(0, 262);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(625, 16);
			this.panel10.TabIndex = 1;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.bnPrint);
			this.panel9.Controls.Add(this.bnUpdOper);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(625, 28);
			this.panel9.TabIndex = 0;
			// 
			// bnPrint
			// 
			this.bnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnPrint.Image = ((System.Drawing.Image)(resources.GetObject("bnPrint.Image")));
			this.bnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnPrint.Location = new System.Drawing.Point(2, 2);
			this.bnPrint.Name = "bnPrint";
			this.bnPrint.Size = new System.Drawing.Size(82, 23);
			this.bnPrint.TabIndex = 0;
			this.bnPrint.Text = "Печать";
			this.bnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bnPrint.Click += new System.EventHandler(this.bnPrint_Click);
			// 
			// bnUpdOper
			// 
			this.bnUpdOper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnUpdOper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnUpdOper.ImageIndex = 2;
			this.bnUpdOper.ImageList = this.imageList1;
			this.bnUpdOper.Location = new System.Drawing.Point(86, 2);
			this.bnUpdOper.Name = "bnUpdOper";
			this.bnUpdOper.Size = new System.Drawing.Size(82, 23);
			this.bnUpdOper.TabIndex = 1;
			this.bnUpdOper.Text = "Обновить";
			this.bnUpdOper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bnUpdOper.Click += new System.EventHandler(this.bnUpdOper_Click);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 340);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(629, 5);
			this.splitter2.TabIndex = 0;
			this.splitter2.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.panel8);
			this.panel3.Controls.Add(this.panel7);
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(629, 340);
			this.panel3.TabIndex = 0;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.dgCreditsList);
			this.panel8.Controls.Add(this.dataGridV1);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(0, 26);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(625, 290);
			this.panel8.TabIndex = 2;
			// 
			// dgCreditsList
			// 
			this.dgCreditsList._CanEdit = false;
			this.dgCreditsList._InvisibleColumn = 0;
			this.dgCreditsList.BackgroundColor = System.Drawing.Color.LightGray;
			this.dgCreditsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgCreditsList.CaptionText = "Список Кредитов";
			this.dgCreditsList.ContextMenu = this.contextMenu1;
			this.dgCreditsList.DataMember = "";
			this.dgCreditsList.DataSource = this.dvCredits;
			this.dgCreditsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgCreditsList.FlatMode = true;
			this.dgCreditsList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCreditsList.Location = new System.Drawing.Point(0, 0);
			this.dgCreditsList.Name = "dgCreditsList";
			this.dgCreditsList.Size = new System.Drawing.Size(625, 290);
			this.dgCreditsList.TabIndex = 1;
			this.dgCreditsList.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									  this.dataGridTableStyle1});
			this.dgCreditsList.DoubleClick += new System.EventHandler(this.dgCreditsList_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// dvCredits
			// 
			this.dvCredits.AllowDelete = false;
			this.dvCredits.AllowEdit = false;
			this.dvCredits.AllowNew = false;
			this.dvCredits.Table = this.dsCredits1.Credits;
			// 
			// dsCredits1
			// 
			this.dsCredits1.DataSetName = "dsCredits";
			this.dsCredits1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridV1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Credits";
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1.BackgroundColor = System.Drawing.Color.LightGray;
			this.dataGridV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridV1.CaptionText = "Список Кредитов";
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dvCredits;
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.FlatMode = true;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 0);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.Size = new System.Drawing.Size(625, 290);
			this.dataGridV1.TabIndex = 0;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Номер";
			this.dataGridTextBoxColumn1.MappingName = "CreditID";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 40;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Клиент";
			this.dataGridTextBoxColumn2.MappingName = "ClientName";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Группа";
			this.dataGridTextBoxColumn3.MappingName = "ClientGroupName";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Направление";
			this.dataGridTextBoxColumn4.MappingName = "GrantedText";
			this.dataGridTextBoxColumn4.NullText = "-";
			this.dataGridTextBoxColumn4.Width = 90;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Состояние";
			this.dataGridTextBoxColumn5.MappingName = "CreditStatusName";
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn6.Format = "0.00";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "Сумма";
			this.dataGridTextBoxColumn6.MappingName = "CreditSum";
			this.dataGridTextBoxColumn6.NullText = "-";
			this.dataGridTextBoxColumn6.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "Валюта";
			this.dataGridTextBoxColumn7.MappingName = "CreditSumCurrency";
			this.dataGridTextBoxColumn7.NullText = "-";
			this.dataGridTextBoxColumn7.Width = 50;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "Тип";
			this.dataGridTextBoxColumn8.MappingName = "CreditType";
			this.dataGridTextBoxColumn8.NullText = "-";
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "Выдача";
			this.dataGridTextBoxColumn9.MappingName = "StartDate";
			this.dataGridTextBoxColumn9.NullText = "-";
			this.dataGridTextBoxColumn9.Width = 75;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "Возврат";
			this.dataGridTextBoxColumn10.MappingName = "EndDate";
			this.dataGridTextBoxColumn10.NullText = "-";
			this.dataGridTextBoxColumn10.Width = 75;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "0.00%";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "%Норм";
			this.dataGridTextBoxColumn11.MappingName = "ServiceCharge";
			this.dataGridTextBoxColumn11.NullText = "-";
			this.dataGridTextBoxColumn11.Width = 50;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "0.00%";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "%Штраф";
			this.dataGridTextBoxColumn12.MappingName = "ServiceChargeExtra";
			this.dataGridTextBoxColumn12.NullText = "-";
			this.dataGridTextBoxColumn12.Width = 50;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "Примечание";
			this.dataGridTextBoxColumn13.MappingName = "Remarks";
			this.dataGridTextBoxColumn13.NullText = "-";
			this.dataGridTextBoxColumn13.Width = 75;
			// 
			// panel7
			// 
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(0, 316);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(625, 20);
			this.panel7.TabIndex = 1;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnPrintCredits);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(625, 26);
			this.panel6.TabIndex = 0;
			// 
			// btnPrintCredits
			// 
			this.btnPrintCredits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPrintCredits.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintCredits.Image")));
			this.btnPrintCredits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrintCredits.Location = new System.Drawing.Point(2, 2);
			this.btnPrintCredits.Name = "btnPrintCredits";
			this.btnPrintCredits.Size = new System.Drawing.Size(82, 23);
			this.btnPrintCredits.TabIndex = 0;
			this.btnPrintCredits.Text = "Печать";
			this.btnPrintCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrintCredits.Click += new System.EventHandler(this.btnPrintCredits_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(258, 0);
			this.splitter1.MinSize = 255;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 627);
			this.splitter1.TabIndex = 0;
			this.splitter1.TabStop = false;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.groupBox2);
			this.panel4.Controls.Add(this.btnClear);
			this.panel4.Controls.Add(this.btnReset);
			this.panel4.Controls.Add(this.btnFilter);
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.cmbClientGroup);
			this.panel4.Controls.Add(this.cmbClientName);
			this.panel4.Controls.Add(this.cmdGranted);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.cmbCurrency);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.cmbState);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Controls.Add(this.trvTotals);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(258, 627);
			this.panel4.TabIndex = 2;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbShowZeroTran);
			this.groupBox2.Controls.Add(this.cbTranByGroup);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(4, 258);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(246, 78);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Просмотр операций";
			// 
			// cbShowZeroTran
			// 
			this.cbShowZeroTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbShowZeroTran.Location = new System.Drawing.Point(24, 19);
			this.cbShowZeroTran.Name = "cbShowZeroTran";
			this.cbShowZeroTran.Size = new System.Drawing.Size(190, 24);
			this.cbShowZeroTran.TabIndex = 0;
			this.cbShowZeroTran.Text = "Операции с нулевой суммой";
			this.cbShowZeroTran.CheckedChanged += new System.EventHandler(this.cbShowZeroTran_CheckedChanged);
			// 
			// cbTranByGroup
			// 
			this.cbTranByGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbTranByGroup.Location = new System.Drawing.Point(24, 46);
			this.cbTranByGroup.Name = "cbTranByGroup";
			this.cbTranByGroup.Size = new System.Drawing.Size(190, 24);
			this.cbTranByGroup.TabIndex = 1;
			this.cbTranByGroup.Text = "По Журналу операций";
			this.cbTranByGroup.CheckedChanged += new System.EventHandler(this.cbTranByGroup_CheckedChanged);
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClear.ImageIndex = 5;
			this.btnClear.ImageList = this.imageList1;
			this.btnClear.Location = new System.Drawing.Point(170, 226);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(80, 26);
			this.btnClear.TabIndex = 7;
			this.btnClear.Text = "Очистить";
			this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnReset
			// 
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReset.ImageIndex = 7;
			this.btnReset.ImageList = this.imageList1;
			this.btnReset.Location = new System.Drawing.Point(88, 226);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(80, 26);
			this.btnReset.TabIndex = 6;
			this.btnReset.Text = "Сбросить";
			this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnFilter.ImageIndex = 6;
			this.btnFilter.ImageList = this.imageList1;
			this.btnFilter.Location = new System.Drawing.Point(6, 226);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(80, 26);
			this.btnFilter.TabIndex = 5;
			this.btnFilter.Text = "Выбрать";
			this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbFromDate);
			this.groupBox1.Controls.Add(this.dtFromDate);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cmbDateType);
			this.groupBox1.Controls.Add(this.dtTillDate);
			this.groupBox1.Controls.Add(this.cbTillDate);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(4, 118);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(246, 102);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Период";
			// 
			// cbFromDate
			// 
			this.cbFromDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbFromDate.Location = new System.Drawing.Point(24, 50);
			this.cbFromDate.Name = "cbFromDate";
			this.cbFromDate.Size = new System.Drawing.Size(41, 20);
			this.cbFromDate.TabIndex = 1;
			this.cbFromDate.Text = "C:";
			this.cbFromDate.CheckedChanged += new System.EventHandler(this.cbFromDate_CheckedChanged);
			// 
			// dtFromDate
			// 
			this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtFromDate.Location = new System.Drawing.Point(84, 50);
			this.dtFromDate.Name = "dtFromDate";
			this.dtFromDate.Size = new System.Drawing.Size(136, 20);
			this.dtFromDate.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label5.Location = new System.Drawing.Point(24, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 21);
			this.label5.TabIndex = 2;
			this.label5.Text = "Тип:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbDateType
			// 
			this.cmbDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cmbDateType.Items.AddRange(new object[] {
															 "<Нет>",
															 "Дата выдачи",
															 "Дата возврата"});
			this.cmbDateType.Location = new System.Drawing.Point(57, 19);
			this.cmbDateType.Name = "cmbDateType";
			this.cmbDateType.Size = new System.Drawing.Size(163, 21);
			this.cmbDateType.TabIndex = 0;
			this.cmbDateType.SelectedIndexChanged += new System.EventHandler(this.cmbDateType_SelectedIndexChanged);
			// 
			// dtTillDate
			// 
			this.dtTillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtTillDate.Location = new System.Drawing.Point(84, 72);
			this.dtTillDate.Name = "dtTillDate";
			this.dtTillDate.Size = new System.Drawing.Size(136, 20);
			this.dtTillDate.TabIndex = 4;
			// 
			// cbTillDate
			// 
			this.cbTillDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbTillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbTillDate.Location = new System.Drawing.Point(24, 72);
			this.cbTillDate.Name = "cbTillDate";
			this.cbTillDate.Size = new System.Drawing.Size(41, 20);
			this.cbTillDate.TabIndex = 2;
			this.cbTillDate.Text = "По:";
			this.cbTillDate.CheckedChanged += new System.EventHandler(this.cbTillDate_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Клиент:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbClientGroup
			// 
			this.cmbClientGroup.DataSource = this.dvGroups;
			this.cmbClientGroup.DisplayMember = "ClientGroupName";
			this.cmbClientGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClientGroup.Location = new System.Drawing.Point(80, 5);
			this.cmbClientGroup.Name = "cmbClientGroup";
			this.cmbClientGroup.Size = new System.Drawing.Size(170, 21);
			this.cmbClientGroup.TabIndex = 0;
			this.cmbClientGroup.ValueMember = "ClientGroupID";
			this.cmbClientGroup.SelectedIndexChanged += new System.EventHandler(this.cmbClientGroup_SelectedIndexChanged);
			// 
			// dvGroups
			// 
			this.dvGroups.Table = this.dsGroups1.ClientsGroups;
			// 
			// dsGroups1
			// 
			this.dsGroups1.DataSetName = "dsGroups";
			this.dsGroups1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cmbClientName
			// 
			this.cmbClientName.DataSource = this.dvClients;
			this.cmbClientName.DisplayMember = "ClientName";
			this.cmbClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClientName.Location = new System.Drawing.Point(80, 27);
			this.cmbClientName.Name = "cmbClientName";
			this.cmbClientName.Size = new System.Drawing.Size(170, 21);
			this.cmbClientName.TabIndex = 1;
			this.cmbClientName.ValueMember = "ClientID";
			// 
			// dvClients
			// 
			this.dvClients.Table = this.dsClients1.Clients;
			// 
			// dsClients1
			// 
			this.dsClients1.DataSetName = "dsClients";
			this.dsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cmdGranted
			// 
			this.cmdGranted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmdGranted.Items.AddRange(new object[] {
															"<Все>",
															"Выдан",
															"Получен"});
			this.cmdGranted.Location = new System.Drawing.Point(80, 49);
			this.cmdGranted.Name = "cmdGranted";
			this.cmdGranted.Size = new System.Drawing.Size(170, 21);
			this.cmdGranted.TabIndex = 2;
			this.cmdGranted.SelectedIndexChanged += new System.EventHandler(this.cmdGranted_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Направл.:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 21);
			this.label3.TabIndex = 1;
			this.label3.Text = "Группа:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 21);
			this.label4.TabIndex = 1;
			this.label4.Text = "Валюта:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCurrency
			// 
			this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurrency.Location = new System.Drawing.Point(80, 71);
			this.cmbCurrency.Name = "cmbCurrency";
			this.cmbCurrency.Size = new System.Drawing.Size(170, 21);
			this.cmbCurrency.TabIndex = 3;
			this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 93);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 21);
			this.label6.TabIndex = 1;
			this.label6.Text = "Состояние:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbState
			// 
			this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbState.Items.AddRange(new object[] {
														  "<Все>",
														  "Подготовлен",
														  "Активен",
														  "Закрыт",
														  "НЕ Закрыт"});
			this.cmbState.Location = new System.Drawing.Point(80, 93);
			this.cmbState.Name = "cmbState";
			this.cmbState.Size = new System.Drawing.Size(170, 21);
			this.cmbState.TabIndex = 4;
			this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label7.Location = new System.Drawing.Point(6, 340);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(116, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "Сводка:";
			// 
			// trvTotals
			// 
			this.trvTotals.BackColor = System.Drawing.SystemColors.Control;
			this.trvTotals.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvTotals.FullRowSelect = true;
			this.trvTotals.ImageIndex = -1;
			this.trvTotals.Location = new System.Drawing.Point(4, 362);
			this.trvTotals.Name = "trvTotals";
			this.trvTotals.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("Всего (Активных) ВЫДАННЫХ"),
																				  new System.Windows.Forms.TreeNode("Всего (Активных) ПОЛУЧЕННЫХ"),
																				  new System.Windows.Forms.TreeNode("Всего (Активных) БАЛАНС"),
																				  new System.Windows.Forms.TreeNode("Всего по ФИЛЬТРУ")});
			this.trvTotals.SelectedImageIndex = -1;
			this.trvTotals.ShowLines = false;
			this.trvTotals.Size = new System.Drawing.Size(246, 256);
			this.trvTotals.TabIndex = 11;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Credits", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																				 new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																				 new System.Data.Common.DataColumnMapping("CreditStatusName", "CreditStatusName"),
																																																				 new System.Data.Common.DataColumnMapping("CreditID", "CreditID"),
																																																				 new System.Data.Common.DataColumnMapping("CreditStatusID", "CreditStatusID"),
																																																				 new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																				 new System.Data.Common.DataColumnMapping("IsGranted", "IsGranted"),
																																																				 new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
																																																				 new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
																																																				 new System.Data.Common.DataColumnMapping("CreditSum", "CreditSum"),
																																																				 new System.Data.Common.DataColumnMapping("ServiceCharge", "ServiceCharge"),
																																																				 new System.Data.Common.DataColumnMapping("ServiceChargeExtra", "ServiceChargeExtra"),
																																																				 new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																				 new System.Data.Common.DataColumnMapping("CreditSumCurrency", "CreditSumCurrency")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[CreditsList]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditDir", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.DateTime, 8));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "CreditsOperations", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("CreditID", "CreditID"),
																																																						   new System.Data.Common.DataColumnMapping("OperationDate", "OperationDate"),
																																																						   new System.Data.Common.DataColumnMapping("TransactionID", "TransactionID"),
																																																						   new System.Data.Common.DataColumnMapping("TransactionTypeID", "TransactionTypeID"),
																																																						   new System.Data.Common.DataColumnMapping("TransactionCommited", "TransactionCommited"),
																																																						   new System.Data.Common.DataColumnMapping("TransactionPosted", "TransactionPosted"),
																																																						   new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																						   new System.Data.Common.DataColumnMapping("SumFrom", "SumFrom"),
																																																						   new System.Data.Common.DataColumnMapping("SumTo", "SumTo"),
																																																						   new System.Data.Common.DataColumnMapping("CurrencyRate", "CurrencyRate"),
																																																						   new System.Data.Common.DataColumnMapping("AccountIDFrom", "AccountIDFrom"),
																																																						   new System.Data.Common.DataColumnMapping("AccountIDTo", "AccountIDTo"),
																																																						   new System.Data.Common.DataColumnMapping("ServiceCharge", "ServiceCharge"),
																																																						   new System.Data.Common.DataColumnMapping("DocumentID", "DocumentID"),
																																																						   new System.Data.Common.DataColumnMapping("CreateDate", "CreateDate"),
																																																						   new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																						   new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																						   new System.Data.Common.DataColumnMapping("TransactionIDParent", "TransactionIDParent"),
																																																						   new System.Data.Common.DataColumnMapping("ClientRequestID", "ClientRequestID"),
																																																						   new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																						   new System.Data.Common.DataColumnMapping("Remarks", "Remarks")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT CreditsOperations.CreditID, CreditsOperations.OperationDate, Transactions.TransactionID, Transactions.TransactionTypeID, Transactions.TransactionCommited, Transactions.TransactionPosted, Transactions.ClientID, Transactions.SumFrom, Transactions.SumTo, Transactions.CurrencyRate, Transactions.AccountIDFrom, Transactions.AccountIDTo, Transactions.ServiceCharge, Transactions.DocumentID, Transactions.CreateDate, Transactions.PostedDate, Transactions.CommitedDate, Transactions.TransactionIDParent, Transactions.ClientRequestID, Transactions.Purpose, Transactions.Remarks, TransactionsTypes.TransactionTypeName, Credits.CreditSumCurrency, CreditsOperations.GroupID FROM TransactionsTypes RIGHT OUTER JOIN Transactions ON TransactionsTypes.TransactionTypeID = Transactions.TransactionTypeID RIGHT OUTER JOIN Credits INNER JOIN CreditsOperations ON Credits.CreditID = CreditsOperations.CreditID ON Transactions.TransactionID = CreditsOperations.TransactionID WHERE (CreditsOperations.CreditID = @CreditID)";
			this.sqlSelectCommand2.Connection = this.sqlConnection2;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4, "CreditID"));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ClientsGroups", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT ClientGroupName, ClientGroupID, ClientGroupRemarks, IsInner, IsSpecial FRO" +
				"M ClientsGroups ORDER BY ClientGroupName";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Clients", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																				 new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																				 new System.Data.Common.DataColumnMapping("ClientID", "ClientID")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT ClientName, ClientGroupID, ClientID, ClientRemarks, IsInner, IsSpecial, Pa" +
				"ssword FROM Clients ORDER BY ClientName";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlCmdAddNewCredit
			// 
			this.sqlCmdAddNewCredit.CommandText = "[CreditInsert]";
			this.sqlCmdAddNewCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdAddNewCredit.Connection = this.sqlConnection1;
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditStatusID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsGranted", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSum", System.Data.SqlDbType.Float, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSumCurrency", System.Data.SqlDbType.NVarChar, 3));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceChargeExtra", System.Data.SqlDbType.Float, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsExtended", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsShortTerm", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageRoundMode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageSinkMode", System.Data.SqlDbType.Bit, 1));
			// 
			// sqlCmdEditCredit
			// 
			this.sqlCmdEditCredit.CommandText = "[CreditEdit]";
			this.sqlCmdEditCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdEditCredit.Connection = this.sqlConnection1;
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditStatusID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsGranted", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSum", System.Data.SqlDbType.Float, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceChargeExtra", System.Data.SqlDbType.Float, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSumCurrency", System.Data.SqlDbType.NVarChar, 3));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsExtended", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsShortTerm", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageRoundMode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageSinkMode", System.Data.SqlDbType.Bit, 1));
			// 
			// sqlCmdDelCredit
			// 
			this.sqlCmdDelCredit.CommandText = "[CreditDelete]";
			this.sqlCmdDelCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdDelCredit.Connection = this.sqlConnection1;
			this.sqlCmdDelCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdDelCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// sqlCmdGrantCredit
			// 
			this.sqlCmdGrantCredit.CommandText = "[CreditIssue]";
			this.sqlCmdGrantCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdGrantCredit.Connection = this.sqlConnection1;
			this.sqlCmdGrantCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGrantCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdGrantCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueDate", System.Data.SqlDbType.DateTime, 8));
			// 
			// sqlCmdCloseCredit
			// 
			this.sqlCmdCloseCredit.CommandText = "[CreditClose]";
			this.sqlCmdCloseCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdCloseCredit.Connection = this.sqlConnection1;
			this.sqlCmdCloseCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCloseCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdCloseCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditCloseDate", System.Data.SqlDbType.DateTime, 8));
			// 
			// sqldaCreditsListSummary
			// 
			this.sqldaCreditsListSummary.SelectCommand = this.sqlSelectCommand6;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "[CreditsListSummary]";
			this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditStatusID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditDir", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateType", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotalCreditSumIn", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotalCreditSumOut", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotalCreditSumBalance", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TotalCreditSumFilter", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdCreditRedemptionParams
			// 
			this.sqlCmdCreditRedemptionParams.CommandText = "[CreditRedemption]";
			this.sqlCmdCreditRedemptionParams.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdCreditRedemptionParams.Connection = this.sqlConnection1;
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RedemptionDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RedemptionSum", System.Data.SqlDbType.Float, 8));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RedemptionMode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTIsShortTerm", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDirection", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTIsExtended", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditSumCurrency", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditSumRedemption", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTServiceCharge", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTServiceChargeExtra", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditStartDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditEndDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumPercentNormalCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumPercentPenaltyCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDropSumPercentNormalCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDropSumPercentPenaltyCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDueSumPercentNormalCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDueSumPercentPenaltyCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditOpLastDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargeNormal", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargePenalty", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargeNormalDrop", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargePenaltyDrop", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateCreditDrop", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditTypeText", System.Data.SqlDbType.NVarChar, 128, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTRoundMode", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTPercentSinkMode", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumForDropPercentNormal", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumForDropPercentPenalty", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditIncreaseSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditRedemptionParams.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditIncreaseLastDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// dsCreditsDetails1
			// 
			this.dsCreditsDetails1.DataSetName = "dsCreditsDetails";
			this.dsCreditsDetails1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dsCreditsPointsInfoList1
			// 
			this.dsCreditsPointsInfoList1.DataSetName = "dsCreditsPointsInfoList";
			this.dsCreditsPointsInfoList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqldaCreditPointsInfo
			// 
			this.sqldaCreditPointsInfo.SelectCommand = this.sqlCmdCreditRedemptionParams;
			// 
			// sqldaCreditGroups
			// 
			this.sqldaCreditGroups.SelectCommand = this.sqlSelectCommand5;
			this.sqldaCreditGroups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "CreditsOperationsGroups", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("GroupID", "GroupID"),
																																																								   new System.Data.Common.DataColumnMapping("GroupDate", "GroupDate"),
																																																								   new System.Data.Common.DataColumnMapping("UserID", "UserID")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT GroupID, GroupDate, UserID, InstalmentSum FROM CreditsOperationsGroups WHE" +
				"RE (CreditID = @CreditID) ORDER BY GroupDate";
			this.sqlSelectCommand5.Connection = this.sqlConnection3;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4, "CreditID"));
			// 
			// sqlConnection3
			// 
			this.sqlConnection3.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlCmdRollbackLastCreditGroup
			// 
			this.sqlCmdRollbackLastCreditGroup.CommandText = "[CreditLastGroupDelete]";
			this.sqlCmdRollbackLastCreditGroup.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdRollbackLastCreditGroup.Connection = this.sqlConnection1;
			this.sqlCmdRollbackLastCreditGroup.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdRollbackLastCreditGroup.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// dsCreditsListSummary1
			// 
			this.dsCreditsListSummary1.DataSetName = "dsCreditsListSummary";
			this.dsCreditsListSummary1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dvCreditsListSummary
			// 
			this.dvCreditsListSummary.Table = this.dsCreditsListSummary1._Table;
			// 
			// sqlCmdCreditIncrease
			// 
			this.sqlCmdCreditIncrease.CommandText = "[CreditIncrease]";
			this.sqlCmdCreditIncrease.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdCreditIncrease.Connection = this.sqlConnection3;
			this.sqlCmdCreditIncrease.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditIncrease.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdCreditIncrease.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IncreaseDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdCreditIncrease.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IncreaseSum", System.Data.SqlDbType.Float, 8));
			// 
			// contextMenu2
			// 
			this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem4,
																						 this.mnuPrint,
																						 this.mnuRefresh});
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "-";
			// 
			// mnuPrint
			// 
			this.mnuPrint.Index = 1;
			this.mnuPrint.Text = "Печать";
			this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
			// 
			// mnuRefresh
			// 
			this.mnuRefresh.Index = 2;
			this.mnuRefresh.Text = "Обновить";
			this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
			// 
			// Credits
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(892, 655);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(800, 0);
			this.Name = "Credits";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Кредиты";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Credits_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCreditHistory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCreditsOperations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsOperations1)).EndInit();
			this.panel12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsOperationsGroups1)).EndInit();
			this.panel9.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCreditsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCredits)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCredits1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvGroups)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsGroups1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClients1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurrs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsDetails1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsPointsInfoList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsListSummary1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCreditsListSummary)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Load CTor
		private void Credits_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				//this.sqlDataAdapter1.Fill(this.dsCredits1.Credits);
				//this.sqlDataAdapter2.Fill(this.dsCreditsOperations1.CreditsOperations);
				this.sqlDataAdapter3.Fill(this.dsGroups1.ClientsGroups);
				this.sqlDataAdapter4.Fill(this.dsClients1.Clients);
			}
			catch(Exception ex)
			{
				Cursor.Current = Cursors.Default;
				MessageBox.Show("Ошибка чтения справочника контрагентов: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			BPS.BLL.Clients.DataSets.dsGroups.ClientsGroupsRow row = this.dsGroups1.ClientsGroups.NewClientsGroupsRow();
			row.ClientGroupID = 0;
			row.ClientGroupName = "<Все>"; 
			row.ClientGroupRemarks = "<Все>";
			row.IsInner = false;
			row.IsSpecial = true;
			this.dsGroups1.ClientsGroups.Rows.Add(row);
			this.dvGroups.Sort = "ClientGroupName ASC";
			this.cmbClientGroup.DataSource = dvGroups;
			this.cmbClientGroup.DisplayMember = "ClientGroupName";
			this.cmbClientGroup.ValueMember = "ClientGroupID";

			BPS.BLL.Clients.DataSets.dsClients.ClientsRow row1 = this.dsClients1.Clients.NewClientsRow();
			row1.ClientID = 0;
			row1.ClientGroupID = 0;
			row1.ClientGroupName = "xxx";
			row1.ClientName = "<Все>";
			row1.ClientRemarks = "Все";
			row1.IsInner = true;
			row1.IsSpecial = true;
			row1.Password = "";
			this.dsClients1.Clients.Rows.Add(row1);
			this.dvClients.Sort = "ClientName ASC";
			this.cmbClientName.DataSource = dvClients;
			this.cmbClientName.DisplayMember = "ClientName";
			this.cmbClientName.ValueMember = "ClientID";

			this.cmbDateType.SelectedIndex = 0;

			dsCurr = (BPS.BLL.Currency.DataSets.dsCurr)App.DsCurr.Copy();
			BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow rw =  dsCurr.Currencies.NewCurrenciesRow();
			rw.CurrencyName = "<Все>";
			rw.CurrencyRate = 0;
			rw.CurrencyID = "ВСЕ";
			rw.IsBase = false;
			dsCurr.Currencies.Rows.Add(rw);
			this.dvCurrs.Table = dsCurr.Currencies;
			dvCurrs.Sort = "CurrencyRate ASC";
			this.cmbCurrency.DataSource = dvCurrs;
			this.cmbCurrency.DisplayMember = "CurrencyName";
			this.cmbCurrency.ValueMember = "CurrencyID";

			this.cmdGranted.SelectedIndex = 0;
			this.cmbState.SelectedIndex = 4; //0;

			this.dtFromDate.Enabled = 
				this.dtTillDate.Enabled = false;

			this.FillCredits();

			this.bmCredits = this.BindingContext[dvCredits];
			this.bmCreditsOperations = this.BindingContext[dvCreditsOperations];
			this.bmGroups = this.BindingContext[dvGroups];
			this.bmClients = this.BindingContext[dvClients];
			this.bmClients.CurrentChanged += new EventHandler(bmClients_CurrentChanged);
			this.bmCredits.CurrentChanged += new EventHandler(bmCredits_CurrentChanged);
			this.BindingContext[this.dsCreditsOperationsGroups1, "CreditsOperationsGroups"].CurrentChanged += new EventHandler(this.CreditsGroupsCurrentChanged);

			this.bmCredits_CurrentChanged(null, null);
			
			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region Currency Tracking
		
		private void CreditsGroupsCurrentChanged(object sender, EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsCreditsOperationsGroups1, "CreditsOperationsGroups"];
			if ( bm.Position <0) //If DataSet is Empty
			{
				this.m_OperationsGroupIDCurrent =0;
			}
			else
			{
				_Forms.dsCreditsOperationsGroups.CreditsOperationsGroupsRow rw =
					(_Forms.dsCreditsOperationsGroups.CreditsOperationsGroupsRow)((DataRowView)bm.Current).Row;
				
				this.m_OperationsGroupIDCurrent =rw.GroupID;

			}
			SetOperationsFilter();
		}

		private void bmCredits_CurrentChanged(object sender, EventArgs e)
		{
			if(this.dvCredits.Count < 1)
			{
				return;
			}
			
			this.ToolBarChangeApperance();
			this.FillOperationsGroups();	//First
			this.FillOperations();			//Second

			//			dsCredits.CreditsRow rw = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			//			this.dvCreditsOperations.RowFilter = "CreditID = " + rw.CreditID.ToString();
			//			if (this.dvCreditsOperations.Count > 0)
			//				this.dgCreditHistory.CurrentRowIndex = 0;
			//			else
			//				this.dgCreditHistory.CurrentRowIndex =-1;
		}

		private void bmClients_CurrentChanged(object sender, EventArgs e)
		{
			bInClientNameChanged = true;
			if(this.cmbClientName.SelectedIndex != 0)
			{
				//bmClients = this.BindingContext[dvClients];
				this.cmbClientGroup.SelectedValue = ((BPS.BLL.Clients.DataSets.dsClients.ClientsRow)((DataRowView)bmClients.Current).Row).ClientGroupID;
				this.cmbClientGroup.Enabled = false;
			}
			else
			{
				this.cmbClientGroup.SelectedIndex = 0;
				this.cmbClientGroup.Enabled = true;
			}
			bInClientNameChanged = false;
		}

		private void SetCurrentRow(int identifier)
		{
			for(int counter = 0; counter < this.dvCredits.Count; counter ++)
			{
				if(System.Convert.ToInt32(this.dgCreditsList[counter, 0]) == identifier)
				{
					this.dgCreditsList.CurrentRowIndex = counter;
					break;
				}
			}
		}
		#endregion
		
		#region Credits Operations
		
		private void AddNewCredit()
		{
			bool bAllOK = true;
			int id = 0;
			dsCredits.CreditsRow rw = this.dsCredits1.Credits.NewCreditsRow();
			CreditsEdit CreditsEditForm = new CreditsEdit(dsClients1, false, rw);
			CreditsEditForm.Text += " [НОВЫЙ]";
			if(CreditsEditForm.ShowDialog() == DialogResult.OK)
			{
				if(!CreditsEditForm.CreditSaved)
				{
					sqlCmdAddNewCredit.Connection.Open();
					sqlCmdAddNewCredit.Parameters["@ClientID"].Value			= rw.ClientID;
					sqlCmdAddNewCredit.Parameters["@CreditStatusID"].Value		= rw.CreditStatusID;
					sqlCmdAddNewCredit.Parameters["@IsGranted"].Value			= rw.IsGranted;
					sqlCmdAddNewCredit.Parameters["@StartDate"].Value			= rw.StartDate;
					sqlCmdAddNewCredit.Parameters["@EndDate"].Value				= rw.EndDate;
					sqlCmdAddNewCredit.Parameters["@CreditSum"].Value			= rw.CreditSum;
					sqlCmdAddNewCredit.Parameters["@CreditSumCurrency"].Value	= rw.CreditSumCurrency;
					sqlCmdAddNewCredit.Parameters["@ServiceCharge"].Value		= rw.ServiceCharge;
					sqlCmdAddNewCredit.Parameters["@ServiceChargeExtra"].Value	= rw.ServiceChargeExtra;
					sqlCmdAddNewCredit.Parameters["@Remarks"].Value				= rw.Remarks;
					sqlCmdAddNewCredit.Parameters["@IsExtended"].Value			= rw.IsExtended;
					sqlCmdAddNewCredit.Parameters["@IsShortTerm"].Value			= rw.IsShortTerm;
					sqlCmdAddNewCredit.Parameters["@PercentageRoundMode"].Value = rw.PercentageRoundMode;
					sqlCmdAddNewCredit.Parameters["@PercentageSinkMode"].Value	= rw.PercentageSinkMode;
					try
					{
						id = System.Convert.ToInt32(sqlCmdAddNewCredit.ExecuteScalar());
					}
					catch(Exception ex)
					{
						MessageBox.Show("Создание кредита отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						bAllOK = false;
					}
					finally
					{
						sqlCmdAddNewCredit.Connection.Close();
					}
				}
				if(bAllOK)
				{
					if(!CreditsEditForm.CreditSaved)
					{
						rw.CreditID = id;
					}
					dsCredits1.Credits.Rows.Add(rw);
					this.FillCredits();
					this.SetCurrentRow(id);
				}
			}
		}

		private void EditCredit()
		{
			int CurrentCreditID = 0;

			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			if(row.CreditStatusID != 1)
			{
				CreditsEdit CreditsViewForm = new CreditsEdit(dsClients1, true, row);
				CreditsViewForm.Text += " [Просмотр]";
				CreditsViewForm.ReadOnly = true;
				CreditsViewForm.ShowDialog();
				//				AM_Controls.MsgBoxX.Show("Невозможно редактировать кредит.\nКредит должен быть в состоянии [Подготовлен]", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (!App.LockStatusChange(150, CurrentCreditID = row.CreditID, true))
			{
				AM_Controls.MsgBoxX.Show("Невозможно производить операции по кредиту.\nКредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			CreditsEdit CreditsEditForm = new CreditsEdit(dsClients1, true, row);
			CreditsEditForm.Text += " [РЕДАКТИРОВАНИЕ]";
			if(CreditsEditForm.ShowDialog() == DialogResult.OK)
			{
				sqlCmdEditCredit.Connection.Open();
				sqlCmdEditCredit.Parameters["@CreditID"].Value = row.CreditID;
				sqlCmdEditCredit.Parameters["@ClientID"].Value = row.ClientID;
				sqlCmdEditCredit.Parameters["@CreditStatusID"].Value = row.CreditStatusID;
				sqlCmdEditCredit.Parameters["@IsGranted"].Value = row.IsGranted;
				sqlCmdEditCredit.Parameters["@StartDate"].Value = row.StartDate;
				sqlCmdEditCredit.Parameters["@EndDate"].Value = row.EndDate;
				sqlCmdEditCredit.Parameters["@CreditSum"].Value = row.CreditSum;
				sqlCmdEditCredit.Parameters["@CreditSumCurrency"].Value = row.CreditSumCurrency;
				sqlCmdEditCredit.Parameters["@ServiceCharge"].Value = row.ServiceCharge;
				sqlCmdEditCredit.Parameters["@ServiceChargeExtra"].Value = row.ServiceChargeExtra;
				sqlCmdEditCredit.Parameters["@Remarks"].Value = row.Remarks;
				sqlCmdEditCredit.Parameters["@IsExtended"].Value = row.IsExtended;
				sqlCmdEditCredit.Parameters["@IsShortTerm"].Value = row.IsShortTerm;
				sqlCmdEditCredit.Parameters["@PercentageRoundMode"].Value = row.PercentageRoundMode;
				sqlCmdEditCredit.Parameters["@PercentageSinkMode"].Value = row.PercentageSinkMode;

				try
				{
					CurrentCreditID = row.CreditID;
					sqlCmdEditCredit.ExecuteNonQuery();
					coCreditsPoints CreditsPoints = new coCreditsPoints();
					CreditsPoints.CalculatePointsPercents(CurrentCreditID);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Сохранение данных о кредите отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				finally
				{
					sqlCmdEditCredit.Connection.Close();
					this.FillCredits();
					this.SetCurrentRow(CurrentCreditID);
				}
			}			
			App.LockStatusChange(150, CurrentCreditID, false);
		}

		private void GrantCredit()
		{
			int CurrentCreditID = 0;
			
			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			CurrentCreditID = row.CreditID;

			if(row.CreditStatusID != 1)
			{
				MessageBox.Show("Данная операция недоступна.\nКредит находится в состоянии [Активен].", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Cursor.Current = Cursors.WaitCursor;

			if (!App.LockStatusChange(150, CurrentCreditID, true))
			{
				Cursor.Current = Cursors.Default;
				MessageBox.Show("Невозможно производить операции по кредиту.\nКредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			/* диалог выдачи/получения кредита */
			CreditOnGrantEdit CreditOnGrantEditForm = new CreditOnGrantEdit(row);
			if(CreditOnGrantEditForm.ShowDialog() != DialogResult.OK)
			{
				App.LockStatusChange(150, CurrentCreditID, false);
				MessageBox.Show("Действие отменено пользователем.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( ConnectionState.Closed ==this.sqlCmdGrantCredit.Connection.State)
				this.sqlCmdGrantCredit.Connection.Open();

			this.sqlCmdGrantCredit.Parameters["@CreditID"].Value = row.CreditID;
			this.sqlCmdGrantCredit.Parameters["@IssueDate"].Value = row.StartDate;
			try
			{
				this.sqlCmdGrantCredit.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Подтверждение выдачи кредита отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlCmdGrantCredit.Connection.State)
					this.sqlCmdGrantCredit.Connection.Close();
				
				App.LockStatusChange(150, CurrentCreditID, false);

				this.FillCredits();
				this.SetCurrentRow( CurrentCreditID);

				Cursor.Current =Cursors.Default;
			}
		}
		
		private void LastGroupRollback()
		{
			int nCreditID =0;

			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if ( DialogResult.No ==MessageBox.Show("Вы действительно хотите отменить последние операции по кредиту?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				return;

			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			nCreditID =row.CreditID;
			
			if (!App.LockStatusChange(150, nCreditID, true))
			{
				MessageBox.Show("Откат последних операций невозможен: Кредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			try
			{					
				Cursor.Current = Cursors.WaitCursor;

				if ( this.sqlCmdRollbackLastCreditGroup.Connection.State ==ConnectionState.Closed)
					this.sqlCmdRollbackLastCreditGroup.Connection.Open();
				
				this.sqlCmdRollbackLastCreditGroup.Parameters["@CreditID"].Value = row.CreditID;
				this.sqlCmdRollbackLastCreditGroup.ExecuteNonQuery(); 
				
			}
			catch( Exception ex)
			{
				MessageBox.Show("Откат последних операций невозможен: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				if ( this.sqlCmdRollbackLastCreditGroup.Connection.State ==ConnectionState.Open)
					this.sqlCmdRollbackLastCreditGroup.Connection.Close();
				
				App.LockStatusChange(150, nCreditID, false);

				this.FillCredits();
				this.SetCurrentRow(nCreditID);

				Cursor.Current = Cursors.Default;
			}
		}

		private void CreditIncrease() 
		{
			int nCreditID = 0;
			
			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			if(row.CreditStatusID != 2)
			{
				MessageBox.Show("Кредит должен находиться в состоянии [Активен]", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if( !(!row.IsShortTerm && !row.IsExtended))
			{
				MessageBox.Show("Действие отменено: Увеличение тела кредита допустимо только для долгосрочного кредита.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			nCreditID =row.CreditID;

			if (!App.LockStatusChange(150, nCreditID, true))
			{
				MessageBox.Show("Невозможно производить операции по кредиту.\nКредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			CreditsIncrease CreditsIncreaseForm = new CreditsIncrease();
			if (CreditsIncreaseForm.ShowDialog() != DialogResult.OK)
			{
				App.LockStatusChange(150, nCreditID, false);
				MessageBox.Show("Действие отменено пользователем.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			//MessageBox.Show("Действие отменено: This feature is under constraction.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//return;

			Cursor.Current =Cursors.WaitCursor;
							
			if ( ConnectionState.Closed ==this.sqlCmdCreditIncrease.Connection.State)
				this.sqlCmdCreditIncrease.Connection.Open();
			

			this.sqlCmdCreditIncrease.Parameters["@CreditID"].Value		= nCreditID;
			this.sqlCmdCreditIncrease.Parameters["@IncreaseDate"].Value = CreditsIncreaseForm.IncreaseDate;
			this.sqlCmdCreditIncrease.Parameters["@IncreaseSum"].Value  = CreditsIncreaseForm.IncreaseSum;
			
			try
			{
				this.sqlCmdCreditIncrease.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Действие отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlCmdCreditIncrease.Connection.State)
					this.sqlCmdCreditIncrease.Connection.Close();
				
				App.LockStatusChange(150, nCreditID, false);
				
				this.FillCredits();
				this.SetCurrentRow( nCreditID);

				Cursor.Current = Cursors.Default;
			}
		}

		private void CloseCredit()
		{
			int nCreditID = 0;
			
			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if ( DialogResult.No == MessageBox.Show("Вы действительно хотите закрыть кредит?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				return;
			
			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			if(row.CreditStatusID != 2)
			{
				MessageBox.Show("Кредит должен находиться в состоянии [Активен]", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			nCreditID =row.CreditID;

			if (!App.LockStatusChange(150, nCreditID, true))
			{
				MessageBox.Show("Невозможно производить операции по кредиту.\nКредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			CreditChargePcnt CreditChargePcntForm = new CreditChargePcnt();
			if (CreditChargePcntForm.ShowDialog() != DialogResult.OK) 
			{
				App.LockStatusChange(150, nCreditID, false);
				return;
			}
			Cursor.Current =Cursors.WaitCursor;
			
			//CreditChargePcntForm.ChargeDate; - дата закрытия кредита
			
			if ( ConnectionState.Closed ==this.sqlCmdCloseCredit.Connection.State)
				this.sqlCmdCloseCredit.Connection.Open();
			
			this.sqlCmdCloseCredit.Parameters["@CreditID"].Value		= nCreditID;
			this.sqlCmdCloseCredit.Parameters["@CreditCloseDate"].Value = CreditChargePcntForm.ChargeDate;
			
			try
			{
				this.sqlCmdCloseCredit.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Действие отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				if ( ConnectionState.Open ==this.sqlCmdCloseCredit.Connection.State)
					this.sqlCmdCloseCredit.Connection.Close();
				
				App.LockStatusChange(150, nCreditID, false);
				
				this.FillCredits();
				this.SetCurrentRow( nCreditID);

				Cursor.Current = Cursors.Default;
			}
		}

		private void DelCredit()
		{
			int CurrentCreditID = 0;

			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			CurrentCreditID = row.CreditID;

			if (!App.LockStatusChange(150, CurrentCreditID, true))
			{
				MessageBox.Show("Невозможно производить операции по кредиту.\nКредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( DialogResult.Yes !=MessageBox.Show("Вы действительно хотите удалить кредит №" + row.CreditID.ToString(), "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				App.LockStatusChange(150, CurrentCreditID, false);
				MessageBox.Show("Днйствие отменено пользователем.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			if (this.sqlCmdDelCredit.Connection.State ==ConnectionState.Closed) 
				this.sqlCmdDelCredit.Connection.Open();
			
			this.sqlCmdDelCredit.Parameters["@CreditID"].Value = row.CreditID;
			try
			{
				this.sqlCmdDelCredit.ExecuteNonQuery();
				this.dsCredits1.Credits.Rows.Remove(row);
				this.FillCredits();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Удаленение отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally
			{
				if (this.sqlCmdDelCredit.Connection.State ==ConnectionState.Open) 
					this.sqlCmdDelCredit.Connection.Close();
				App.LockStatusChange(150, CurrentCreditID, false);
			}
		}

		private void PayBackCredit()
		{
			int CurrentCreditID = 0;
			
			if(this.dvCredits.Count == 0) 
			{
				MessageBox.Show("Действие отменено: Не указан кредит.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			if(row.CreditStatusID != 2)
			{
				AM_Controls.MsgBoxX.Show("Кредит должен находиться в состоянии [Активен]", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			CurrentCreditID = row.CreditID;
			
			if (!App.LockStatusChange(150, CurrentCreditID, true))
			{
				AM_Controls.MsgBoxX.Show("Невозможно производить операции по кредиту.\nКредит редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			CreditsRedemption frm =new CreditsRedemption();
			frm.CreditID =CurrentCreditID;
			frm.ClientName =row.ClientName;
			frm.ShowDialog(); 
			this.FillCredits();
			this.SetCurrentRow(CurrentCreditID);

			App.LockStatusChange(150, CurrentCreditID, false);
		}

		#endregion

		#region Filter
		private void SetFilter()
		{
			Cursor.Current = Cursors.WaitCursor;

			this.dsCreditsOperations1.Clear();
			this.FillCredits();
			this.dgCreditsList.CurrentRowIndex = 0;

			Cursor.Current = Cursors.Default;
		}

		private void ResetFilter()
		{
			this.sqlDataAdapter1.SelectCommand.Parameters["@ClientGroupID"].Value =
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientGroupID"].Value = 0;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@ClientID"].Value =
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientID"].Value = 0;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@CurrencyID"].Value = 
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@CurrencyID"].Value = System.Convert.DBNull;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@CreditStatusID"].Value = 
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditStatusID"].Value = 4; //0;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@CreditDir"].Value = 
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditDir"].Value = System.Convert.DBNull;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@DateType"].Value = 
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@DateType"].Value = 0;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = 
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@StartDate"].Value = System.Convert.DBNull;
			
			this.sqlDataAdapter1.SelectCommand.Parameters["@EndDate"].Value =
			this.sqldaCreditsListSummary.SelectCommand.Parameters["@EndDate"].Value = System.Convert.DBNull;
			
			try
			{
				Cursor.Current = Cursors.WaitCursor;

				this.dsCredits1.Credits.Rows.Clear();
				this.sqlDataAdapter1.Fill(this.dsCredits1.Credits);
				
				this.dsCreditsListSummary1.Clear();
				this.sqldaCreditsListSummary.Fill( this.dsCreditsListSummary1._Table);
				this.trvTotalsFill();

				this.bmCredits = this.BindingContext[dvCredits];
				if(this.dvCredits.Count > 0)
				{
					this.dgCreditsList.CurrentRowIndex = 0;
				}
				else
				{
					this.dgCreditsList.CurrentRowIndex = -1;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения данных (Filter Reset): " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void ClearFilter()
		{
			this.sqlDataAdapter1.SelectCommand.Parameters["@ClientGroupID"].Value =
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientGroupID"].Value = 0;
			this.sqlDataAdapter1.SelectCommand.Parameters["@ClientID"].Value =
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientID"].Value = 0;
			this.sqlDataAdapter1.SelectCommand.Parameters["@CurrencyID"].Value = 
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@CurrencyID"].Value = System.Convert.DBNull;
			this.sqlDataAdapter1.SelectCommand.Parameters["@CreditStatusID"].Value = 
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditStatusID"].Value = 4; //0;
			this.sqlDataAdapter1.SelectCommand.Parameters["@CreditDir"].Value = 
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditDir"].Value = System.Convert.DBNull;
			this.sqlDataAdapter1.SelectCommand.Parameters["@DateType"].Value = 
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@DateType"].Value = 0;
			this.sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = 
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@StartDate"].Value = System.Convert.DBNull;
			this.sqlDataAdapter1.SelectCommand.Parameters["@EndDate"].Value =
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@EndDate"].Value = System.Convert.DBNull;
			try
			{
				this.dsCredits1.Credits.Rows.Clear();
				this.sqlDataAdapter1.Fill(this.dsCredits1.Credits);
				
				this.dsCreditsListSummary1.Clear();
				this.sqldaCreditsListSummary.Fill( this.dsCreditsListSummary1._Table);
				this.trvTotalsFill();

				this.bmCredits = this.BindingContext[dvCredits];
				if(this.dvCredits.Count > 0)
				{
					this.dgCreditsList.CurrentRowIndex = 0;
				}
				else
				{
					this.dgCreditsList.CurrentRowIndex = -1;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения данных (Filter Clear): " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			RefreshControls();
		}

		private void RefreshControls()
		{
			this.cmbClientGroup.SelectedIndex =
				this.cmbClientName.SelectedIndex =
				this.cmbCurrency.SelectedIndex =
				this.cmbDateType.SelectedIndex =
				this.cmdGranted.SelectedIndex = 0;
			this.cmbState.SelectedIndex = 4;
			this.cbFromDate.Checked = 
				this.cbTillDate.Checked = false;
		}

		private void SetOperationsFilter()
		{
			string szFilter ="";

			if ( !cbShowZeroTran.Checked)
				szFilter ="(SumFrom > 0.05 OR SumFrom < -0.05)";

			if ( this.cbTranByGroup.Checked) 
			{
				if ( szFilter.Length >0) szFilter +=" AND ";

				szFilter +="[GroupID]=" +this.m_OperationsGroupIDCurrent.ToString();
			}
	
			this.dvCreditsOperations.RowFilter =szFilter;
		}
		#endregion

		#region Temp
//		private void bmGroups_CurrentChanged(object sender, System.EventArgs e)
//		{
//			Clients.dsGroups.ClientsGroupsRow rw = (Clients.dsGroups.ClientsGroupsRow)((DataRowView)this.bmGroups.Current).Row;
//			if(rw.ClientGroupName.CompareTo("<Все>") == 0)
//			{
//				this.strGroupFilter = string.Empty;
//			}
//			else
//			{
//				this.strGroupFilter = "ClientGroupID = " + rw.ClientGroupID.ToString();
//			}
//		}
//
//		private void bmClient_CurrentChanged(object sender, System.EventArgs e)
//		{
//			Clients.dsClients.ClientsRow rw = (Clients.dsClients.ClientsRow)((DataRowView)this.bmClients.Current).Row;
//			if(rw.ClientName.CompareTo("<Все>") == 0)
//			{
//				this.strClientFilter = string.Empty;
//			}
//			else
//			{
//				this.strClientFilter = "ClientID = " + rw.ClientID.ToString();
//			}
//		}
		#endregion

		#region Controls Events
		private void dgCreditsList_DoubleClick(object sender, System.EventArgs e)
		{
			EditCredit();
		}

		private void cmdGranted_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.cmdGranted.Text.CompareTo("<Все>") == 0)
				this.strDirectionFilter = string.Empty;
			else
				this.strDirectionFilter = "IsGranted = " + (this.cmdGranted.SelectedIndex == 1 ? "1" : "0");
		}

		private void cmbCurrency_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.cmbCurrency.Text.CompareTo("<Все>") == 0)
				this.strCurrencyFilter = string.Empty;
			else
				this.strCurrencyFilter = "CreditSumCurrency = '" + cmbCurrency.SelectedValue.ToString() + "'";
		}

		private void cmbState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.cmbState.Text.CompareTo("<Все>") == 0)
				this.strStateFilter = string.Empty;
			else
				this.strStateFilter = "CreditStatusID = " + this.cmbState.SelectedIndex;
		}

		private void DateControlsState()
		{
			this.cbFromDate.Enabled = false;
		}

		private void cmbDateType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cbFromDate.Checked =(this.cmbDateType.SelectedIndex == 0)? false: this.cbFromDate.Checked;
			this.cbTillDate.Checked =(this.cmbDateType.SelectedIndex == 0)? false: this.cbTillDate.Checked;
			this.cbFromDate.Enabled =
			this.cbTillDate.Enabled =
				(this.cmbDateType.SelectedIndex != 0);
		}

		private void cbFromDate_CheckedChanged(object sender, System.EventArgs e)
		{
			this.dtFromDate.Enabled = this.cbFromDate.Checked;
		}

		private void cbTillDate_CheckedChanged(object sender, System.EventArgs e)
		{
			this.dtTillDate.Enabled = this.cbTillDate.Checked;
		}

		private void cbShowZeroTran_CheckedChanged(object sender, System.EventArgs e)
		{
			SetOperationsFilter();
		}

		private void cbTranByGroup_CheckedChanged(object sender, System.EventArgs e)
		{
			SetOperationsFilter();
		}

		private bool bInClientNameChanged = false;
		private void cmbClientGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(bInClientNameChanged)
				return;
			if(this.cmbClientGroup.SelectedIndex != 0)
			{
				this.cmbClientName.SelectedIndex = 0;
				this.cmbClientName.Enabled = false;
			}
			else
			{
				this.cmbClientName.Enabled = true;
				this.cmbClientName.SelectedIndex = 0;
			}
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			this.MenuChangeAppearance();
			this.contextMenu1.MenuItems.Clear();
			App.Clone(this.menuItem1.MenuItems, this.contextMenu1);
			this.contextMenu1.MergeMenu(this.contextMenu2);
		}

		private void menuItem1_Popup(object sender, System.EventArgs e)
		{
			this.MenuChangeAppearance();
		}
		#endregion

		#region Menu
		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			AddNewCredit();
		}

		private void mnuEdit_Click(object sender, System.EventArgs e)
		{
			EditCredit();
		}

		private void mnuDel_Click(object sender, System.EventArgs e)
		{
			DelCredit();
		}

		private void mnuGrant_Click(object sender, System.EventArgs e)
		{
			GrantCredit();
		}

		private void mnuClose_Click(object sender, System.EventArgs e)
		{
			CloseCredit();
		}

		private void mnuIncrease_Click(object sender, System.EventArgs e)
		{
			this.CreditIncrease();
		}

		private void mnuDebt_Click(object sender, System.EventArgs e)
		{
			this.PayBackCredit();
		}

		private void mnuUndo_Click(object sender, System.EventArgs e)
		{
			this.LastGroupRollback();
		}

		private void mnuPrint_Click(object sender, System.EventArgs e)
		{
			bnPrint_Click(this, null);
		}

		private void MenuChangeAppearance()
		{
			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			
			this.mnuGrant.Text					=(row.IsGranted) ?"Выдать" :"Получить";
			this.mnuEdit.Text					=(row.CreditStatusID ==1) ?"Изменить" :"Просмотр";
			this.mnuGrant.Enabled				=(row.CreditStatusID ==1) ?true :false;
			this.mnuClose.Enabled				=(row.CreditStatusID ==2) ?true :false;
			this.mnuDel.Enabled					=(row.CreditStatusID ==1) ?true :false;
			this.mnuIncrease.Enabled			=(!row.IsShortTerm && !row.IsExtended && row.CreditStatusID ==2);
			this.mnuUndo.Enabled				=(row.CreditStatusID !=1) ?true :false;
			this.mnuDebt.Enabled				=(row.CreditStatusID ==2) ?true :false;
		}
		#endregion

		#region Buttons

		private void bnPrint_Click(object sender, System.EventArgs e)
		{
			CreditsPrintReports CreditsPrintReportsForm = new CreditsPrintReports();
			if(CreditsPrintReportsForm.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			
			if(this.dvCredits.Count < 1)
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;

			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			RepDoc rd = new RepDoc();
			rd.LoadForDataSet("CreditOperations.rpt");
			rd.SetDataSource(dsCreditsOperations1);
			rd.DataDefinition.FormulaFields["HeaderText"].Text = "Local StringVar s:='Отчёт об операциях по кредиту №" + row.CreditID.ToString() + ".'";
			rd.DataDefinition.FormulaFields["ClientHeader"].Text = "Local StringVar s:='" + row.ClientName.ToString() + "   (Группа: " + row.ClientGroupName.ToString() + ")'";
			try
			{
				if ( this.sqlCmdCreditRedemptionParams.Connection.State ==System.Data.ConnectionState.Closed)
					this.sqlCmdCreditRedemptionParams.Connection.Open();
				//Параметры
				//ID Кредита
				this.sqlCmdCreditRedemptionParams.Parameters["@CreditID"].Value			= row.CreditID;
				//Дата расчёта состояния кредита
				this.sqlCmdCreditRedemptionParams.Parameters["@RedemptionDate"].Value	= DateTime.Now.Date;
				//Сумма для погашения: для данного режима 0
				this.sqlCmdCreditRedemptionParams.Parameters["@RedemptionSum"].Value	= 0;
				//Режим основной: 0 - только расчёт состояния
				this.sqlCmdCreditRedemptionParams.Parameters["@Mode"].Value				= 0;
				//Режим дополнительный - должен быть 0
				this.sqlCmdCreditRedemptionParams.Parameters["@RedemptionMode"].Value	= 0;
				
				this.sqlCmdCreditRedemptionParams.ExecuteNonQuery();
				
				//Тип Кредита
				rd.DataDefinition.FormulaFields["CreditTypeHeader"].Text	="Local StringVar s:='" 
					+ this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditTypeText"].Value.ToString() + "'";
				//Сумма Кредита
				rd.DataDefinition.FormulaFields["SumHeader"].Text			="Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSum"].Value).ToString("0.00") + "'";
				//Дата выдачи Кредита
				rd.DataDefinition.FormulaFields["StartDateHeader"].Text		="Local StringVar s:='" 
					+ ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditStartDate"].Value).ToString("dd-MMM-yy") + "'";
				//Дата окончания срока действия кредита
				rd.DataDefinition.FormulaFields["EndDateHeader"].Text		="Local StringVar s:='" 
					+ ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditEndDate"].Value).ToString("dd-MMM-yy") + "'";
				//Нормальная %% ставка
				rd.DataDefinition.FormulaFields["ServiceCharge"].Text		= "Local StringVar s:='" 
					+ (((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTServiceCharge"].Value) * 100).ToString("0.00") + "'";
				//Штрафная %% ставка
				rd.DataDefinition.FormulaFields["ServiceChargeExtra"].Text	= "Local StringVar s:='" 
					+ (((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTServiceChargeExtra"].Value) * 100).ToString("0.00") + "'";
				//Сумма к погашению по кредиту на @RedemptionDate (сегодня)
				rd.DataDefinition.FormulaFields["Redempted"].Text			= "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSumRedemption"].Value).ToString("0.00") + "'";
				//Непогашенное тело Кредита
				rd.DataDefinition.FormulaFields["NotRedempted"].Text		= "Local StringVar s:='" 
					+ ((double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSum"].Value) 
					+(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseSum"].Value)
					-(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSumRedemption"].Value)
					).ToString("0.00") + "'";
				//Дата последнего погашения тела Кредита
				if ( this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateCreditDrop"].Value ==System.DBNull.Value) 
					rd.DataDefinition.FormulaFields["LastRedemptionDate"].Text			= "Local StringVar s:='Не погашался'";
				else
					rd.DataDefinition.FormulaFields["LastRedemptionDate"].Text			= "Local StringVar s:='" 
						+ ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateCreditDrop"].Value).ToString("dd-MMM-yy") + "'";

				//Дата последней опрерации по Кредиту
				rd.DataDefinition.FormulaFields["CreditOpLastDate"].Text			= "Local StringVar s:='" 
					+ ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditOpLastDate"].Value).ToString("dd-MMM-yy") + "'";
				
				//Сумма начисленных %% по нормальной ставке
				rd.DataDefinition.FormulaFields["SumPercentNormalCurrent"].Text		= "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumPercentNormalCurrent"].Value).ToString("0.00") + "'";
				//Сумма погашенных %% по нормальной ставке				
				rd.DataDefinition.FormulaFields["DropSumPercentNormalCurrent"].Text = "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDropSumPercentNormalCurrent"].Value).ToString("0.00") + "'";
				//Сумма начисленных %% по нормальной ставке	на @RedemptionDate (сегодня)			
				rd.DataDefinition.FormulaFields["DueSumPercentNormalCurrent"].Text	= "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDueSumPercentNormalCurrent"].Value).ToString("0.00") + "'";
				//Сумма %% по нормальной ставке к погашению
				rd.DataDefinition.FormulaFields["SumForDropPercentNormal"].Text			= "Local StringVar s:='" 
					+ ((double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumForDropPercentNormal"].Value)).ToString("0.00") + "'";
				
				//Сумма начисленных %% по штрафной ставке
				rd.DataDefinition.FormulaFields["SumPercentPenaltyCurrent"].Text	= "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumPercentPenaltyCurrent"].Value).ToString("0.00") + "'";
				//Сумма погашенных %% по штрафной ставке				
				rd.DataDefinition.FormulaFields["DropSumPercentPenaltyCurrent"].Text= "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDropSumPercentPenaltyCurrent"].Value).ToString("0.00") + "'";
				//Сумма начисленных %% по штрафной ставке	на @RedemptionDate (сегодня)			
				rd.DataDefinition.FormulaFields["DueSumPercentPenaltyCurrent"].Text = "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDueSumPercentPenaltyCurrent"].Value).ToString("0.00") + "'";
				//Сумма %% по штрафной к погашению				
				rd.DataDefinition.FormulaFields["SumForDropPercentPenalty"].Text		= "Local StringVar s:='" + 
					(
					(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumForDropPercentPenalty"].Value) 
					).ToString("0.00") + "'";
				
				//Дата последнего начисления %% нормальной ставке
				if ( this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormal"].Value == System.DBNull.Value)
					rd.DataDefinition.FormulaFields["LastDateChargeNormal"].Text = "Local StringVar s:='Не начислялись'";
				else
					rd.DataDefinition.FormulaFields["LastDateChargeNormal"].Text = "Local StringVar s:='" + ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormal"].Value).ToString("dd-MMM-yy") + "'";
				
				//Дата последнего начисления %% по штрафной ставке
				if ( this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenalty"].Value == System.DBNull.Value)
					rd.DataDefinition.FormulaFields["LastDateChargePenalty"].Text = "Local StringVar s:='Не начислялись'";
				else
					rd.DataDefinition.FormulaFields["LastDateChargePenalty"].Text = "Local StringVar s:='" + ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenalty"].Value).ToString("dd-MMM-yy") + "'";
				
				//Дата последнего погашения нормальных %%
				if ( this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormalDrop"].Value == System.DBNull.Value)
					rd.DataDefinition.FormulaFields["LastDateChargeNormalDrop"].Text = "Local StringVar s:='Не начислялись'";
				else
					rd.DataDefinition.FormulaFields["LastDateChargeNormalDrop"].Text = "Local StringVar s:='" + ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormalDrop"].Value).ToString("dd-MMM-yy") + "'";
				
				//Дата последнего погашения штрафных %%
				if ( this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenaltyDrop"].Value == System.DBNull.Value)
					rd.DataDefinition.FormulaFields["LastDateChargePenaltyDrop"].Text = "Local StringVar s:='Не начислялись'";
				else
					rd.DataDefinition.FormulaFields["LastDateChargePenaltyDrop"].Text = "Local StringVar s:='" + ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenaltyDrop"].Value).ToString("dd-MMM-yy") + "'";
				
				//Режим округления при расчете процентов по кредиту
				rd.DataDefinition.FormulaFields["RoundMode"].Text = "Local StringVar s:='" + (((bool)this.sqlCmdCreditRedemptionParams.Parameters["@OUTRoundMode"].Value) ? App.CreditsSettings.CreditPercentageRoundModeByPeriod : App.CreditsSettings.CreditPercentageRoundModeByDay) + "'";

				//Режим погашения нормальных процентов
				rd.DataDefinition.FormulaFields["PercentSinkMode"].Text = "Local StringVar s:='" + (((bool)this.sqlCmdCreditRedemptionParams.Parameters["@OUTPercentSinkMode"].Value) ? App.CreditsSettings.CreditPercentageSinkModeByPeriod : App.CreditsSettings.CreditPercentageSinkModeByOperation) + "'";

				//Итого к погашению
				rd.DataDefinition.FormulaFields["ToDropSumTotal"].Text = "Local StringVar s:='" + 
					(
					((double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSum"].Value) 
					+(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseSum"].Value)
					-(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSumRedemption"].Value)) 
					+ 
					(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumForDropPercentNormal"].Value)
					+ 
					(double)(this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumForDropPercentPenalty"].Value) 
					).ToString("0.00") + "'";

				//Сумма увеличений тела кредита			
				rd.DataDefinition.FormulaFields["CreditIncreaseSum"].Text= "Local StringVar s:='" 
					+ ((double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseSum"].Value).ToString("0.00") + "'";

				//Дата последнего увеличений тела кредита
				if ( this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseLastDate"].Value == System.DBNull.Value)
					rd.DataDefinition.FormulaFields["CreditIncreaseLastDate"].Text = "Local StringVar s:='Не увеличивался'";
				else
					rd.DataDefinition.FormulaFields["CreditIncreaseLastDate"].Text = "Local StringVar s:='" + ((System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseLastDate"].Value).ToString("dd-MMM-yy") + "'";
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			finally
			{
				Cursor.Current = Cursors.Default;

				if ( this.sqlCmdCreditRedemptionParams.Connection.State ==System.Data.ConnectionState.Open)
					this.sqlCmdCreditRedemptionParams.Connection.Close();
			}
			// Creating "CreditsPoints" subreport
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				this.dsCreditsPointsInfoList1.Clear();
				if(row.IsShortTerm)
				{
					dsCreditsPointsInfoList._TableRow rw = this.dsCreditsPointsInfoList1._Table.New_TableRow();
					rw.PointID = 0;
					rw.PointDate = row.EndDate;
					rw.PointSum = row.CreditSum;
					TimeSpan diff = row.EndDate.Subtract(row.StartDate);
					//Warning! Round in percent sum calculation
					if(row.PercentageRoundMode)
					{
						rw.PointPercent = Math.Round(row.CreditSum * row.ServiceCharge / 365 * diff.Days, 2);
					}
					else
					{
						rw.PointPercent = Math.Round(Math.Round(row.CreditSum * row.ServiceCharge / 365, 2) * diff.Days, 2);
					}
					rw.PointSumSink = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSumRedemption"].Value;
					if(this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateCreditDrop"].Value == System.DBNull.Value)
						rw.SetPointSumSinkLastDateNull();
					else
                        rw.PointSumSinkLastDate = (DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateCreditDrop"].Value;

					rw.PointPercentNormalDebt = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumPercentNormalCurrent"].Value;
					rw.PointPercentNormalSink = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDropSumPercentNormalCurrent"].Value;
					rw.PointPercentNormalDue = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDueSumPercentNormalCurrent"].Value;
					if(this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormal"].Value == DBNull.Value)
						rw.SetPointPercentNormalDebtLastDateNull();
					else
						rw.PointPercentNormalDebtLastDate = (DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormal"].Value;
					rw.PointPercentPenaltyDebt = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumPercentPenaltyCurrent"].Value;
					rw.PointPercentPenaltySink = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDropSumPercentPenaltyCurrent"].Value;
					rw.PointPercentPenaltyDue = (double)this.sqlCmdCreditRedemptionParams.Parameters["@OUTDueSumPercentPenaltyCurrent"].Value;
					if(this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenaltyDrop"].Value == DBNull.Value)
						rw.SetPointPercentPenaltyDebtLastDateNull();
					else 
						rw.PointPercentPenaltyDebtLastDate = (System.DateTime)this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenaltyDrop"].Value;
					this.dsCreditsPointsInfoList1._Table.Rows.Add(rw);
				}
				else
				{
					this.sqldaCreditPointsInfo.SelectCommand.Parameters["@CreditID"].Value			=row.CreditID;
					this.sqldaCreditPointsInfo.SelectCommand.Parameters["@RedemptionDate"].Value	=System.DateTime.Today;
					this.sqldaCreditPointsInfo.SelectCommand.Parameters["@RedemptionSum"].Value		=0;
					this.sqldaCreditPointsInfo.SelectCommand.Parameters["@Mode"].Value				=0;
					this.sqldaCreditPointsInfo.SelectCommand.Parameters["@RedemptionMode"].Value	=0;
					this.sqldaCreditPointsInfo.Fill(this.dsCreditsPointsInfoList1);
				}
			}
			catch(Exception ex)
			{
				Cursor.Current = Cursors.Default;

				MessageBox.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			ReportDocument SubRD = rd.OpenSubreport("CreditPoints.rpt");
			SubRD.SetDataSource(this.dsCreditsPointsInfoList1);

			// Creating "CreditsOperationsGroups" subreport

			ReportDocument SubRD2 = rd.OpenSubreport("CreditsOperationsGroups.rpt");
			SubRD2.SetDataSource(this.dsCreditsOperationsGroups1);


			if(!CreditsPrintReportsForm.bNeedCreditOperationsList)
			{
				rd.ReportDefinition.Sections["Section3"].SectionFormat.EnableSuppress = true;
				rd.ReportDefinition.Sections["Section4"].SectionFormat.EnableSuppress = true;
				rd.ReportDefinition.Sections["Section8"].SectionFormat.EnableSuppress = true;
				rd.ReportDefinition.Sections["Section9"].SectionFormat.EnableSuppress = true;
			}
			if(!CreditsPrintReportsForm.bNeedCreditPointsInfo)
			{
				rd.ReportDefinition.Sections["Section16"].SectionFormat.EnableSuppress = true;
			}
			if(!CreditsPrintReportsForm.bNeedCreditOperationsGroups)
			{
				rd.ReportDefinition.Sections["Section6"].SectionFormat.EnableSuppress = true;
			}
			
			Cursor.Current =Cursors.Default;
			
			RepPreview rprv = new RepPreview();
			rprv.ShowDialog(rd);
		}

		private void btnFilter_Click(object sender, System.EventArgs e)
		{
			SetFilter();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			ResetFilter();
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			ClearFilter();
		}

		private void bnUpdOper_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			this.FillOperationsGroups();
			this.FillOperations();	

			Cursor.Current = Cursors.Default;
		}

		private void mnuRefresh_Click(object sender, System.EventArgs e)
		{
			bnUpdOper_Click(this, null);
		}

		private void btnPrintCredits_Click(object sender, System.EventArgs e)
		{
			if(this.dvCredits.Count < 1)
			{
				return;
			}
			Cursor = Cursors.WaitCursor;
			if(FillCreditsDetails() == -1)
			{
				MessageBox.Show("Произошла ошибка при сборе информации о кредитах. Действие отменено.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Cursor = Cursors.Default;
				return;
			}
			DataRow[] dr = this.dsCreditsDetails1.CreditsDetails.Select(this.dvCredits.RowFilter, this.dvCredits.Sort);
			BPS.BLL.Credits.DataSets.dsCreditsDetails ds = new BPS.BLL.Credits.DataSets.dsCreditsDetails();
			for(int counter = 0; counter < dr.Length; counter ++)
			{
				dsCreditsDetails.CreditsDetailsRow rw = ds.CreditsDetails.NewCreditsDetailsRow();
				rw.ItemArray = dr[counter].ItemArray;
				ds.CreditsDetails.AddCreditsDetailsRow(rw);
			}
			RepDoc rd = new RepDoc();
			rd.LoadForDataSet("CreditsStates.rpt");
			rd.SetDataSource(ds);
			RepPreview rprv = new RepPreview();
			Cursor = Cursors.Default;
			rprv.ShowDialog(rd);
		}

		#endregion

		#region Data Acquiring
		private void FillCredits()
		{
			if(this.cmbClientGroup.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientGroupID"].Value =
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientGroupID"].Value = 0;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientGroupID"].Value =
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientGroupID"].Value = (int)this.cmbClientGroup.SelectedValue;
			}
			if(this.cmbClientName.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientID"].Value =
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientID"].Value = 0;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientID"].Value =
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@ClientID"].Value = (int)this.cmbClientName.SelectedValue;
			}
			if(this.cmbCurrency.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CurrencyID"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@CurrencyID"].Value = System.Convert.DBNull;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CurrencyID"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@CurrencyID"].Value = this.cmbCurrency.SelectedValue.ToString();
			}
			if(this.cmbState.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditStatusID"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditStatusID"].Value = 0;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditStatusID"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditStatusID"].Value = this.cmbState.SelectedIndex;
			}
			if(this.cmdGranted.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditDir"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditDir"].Value = System.Convert.DBNull;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditDir"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@CreditDir"].Value = this.cmdGranted.SelectedIndex == 1 ? true : false;
			}

			DateTime dt1 = this.dtFromDate.Value;
			dt1 = dt1.AddHours(- dt1.Hour);
			dt1 = dt1.AddMinutes(- dt1.Minute);
			dt1 = dt1.AddSeconds(- dt1.Second);

			DateTime dt2 = this.dtTillDate.Value;
			dt2 = dt2.AddHours(- dt2.Hour);
			dt2 = dt2.AddMinutes(- dt2.Minute);
			dt2 = dt2.AddSeconds(- dt2.Second);
			dt2 = dt2.AddDays(1);
			dt2 = dt2.AddSeconds(- 1);

			this.sqlDataAdapter1.SelectCommand.Parameters["@DateType"].Value = 
				this.sqldaCreditsListSummary.SelectCommand.Parameters["@DateType"].Value = this.cmbDateType.SelectedIndex;
			if(this.cbFromDate.Checked)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@StartDate"].Value = dt1;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = 
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@StartDate"].Value = System.Convert.DBNull;
			}
			if(this.cbTillDate.Checked)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@EndDate"].Value =
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@EndDate"].Value = dt2;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@EndDate"].Value =
					this.sqldaCreditsListSummary.SelectCommand.Parameters["@EndDate"].Value = System.Convert.DBNull;
			}
			try
			{
				Cursor.Current = Cursors.WaitCursor;

				this.dsCredits1.Credits.Rows.Clear();
				this.sqlDataAdapter1.Fill(this.dsCredits1.Credits);
				
				this.dsCreditsListSummary1.Clear();
				this.sqldaCreditsListSummary.Fill( this.dsCreditsListSummary1._Table);
				this.trvTotalsFill();
 
				this.bmCredits = this.BindingContext[dvCredits];
				if(this.dvCredits.Count > 0)
					this.dgCreditsList.CurrentRowIndex = 0;
				else
					this.dgCreditsList.CurrentRowIndex = -1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения списка кредитов: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private int FillCreditsDetails()
		{
			if(this.cmbClientGroup.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientGroupID"].Value = 0;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientGroupID"].Value = (int)this.cmbClientGroup.SelectedValue;
			}
			if(this.cmbClientName.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientID"].Value = 0;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@ClientID"].Value = (int)this.cmbClientName.SelectedValue;
			}
			if(this.cmbCurrency.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CurrencyID"].Value = System.Convert.DBNull;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CurrencyID"].Value = this.cmbCurrency.SelectedValue.ToString();
			}
			if(this.cmbState.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditStatusID"].Value = 0;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditStatusID"].Value = this.cmbState.SelectedIndex;
			}
			if(this.cmdGranted.SelectedIndex == 0)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditDir"].Value = System.Convert.DBNull;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditDir"].Value = this.cmdGranted.SelectedIndex == 1 ? true : false;
			}

			DateTime dt1 = this.dtFromDate.Value;
			dt1 = dt1.AddHours( -dt1.Hour);
			dt1 = dt1.AddMinutes( -dt1.Minute);
			dt1 = dt1.AddSeconds( -dt1.Second);

			DateTime dt2 = this.dtTillDate.Value;
			dt2 = dt2.AddHours( -dt2.Hour);
			dt2 = dt2.AddMinutes( -dt2.Minute);
			dt2 = dt2.AddSeconds( -dt2.Second);
			dt2 = dt2.AddDays(1);
			dt2 = dt2.AddSeconds( -1);

			this.sqlDataAdapter1.SelectCommand.Parameters["@DateType"].Value = this.cmbDateType.SelectedIndex;
			if(this.cbFromDate.Checked)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = dt1;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = System.Convert.DBNull;
			}
			if(this.cbTillDate.Checked)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@EndDate"].Value = dt2;
			}
			else
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@EndDate"].Value = System.Convert.DBNull;
			}
			try
			{
				dsCreditsDetails1.Clear();
				this.sqlDataAdapter1.Fill(dsCreditsDetails1.CreditsDetails);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения данных о кредите(1): " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return -1;
			}
			if ( ConnectionState.Closed ==this.sqlCmdCreditRedemptionParams.Connection.State)
				this.sqlCmdCreditRedemptionParams.Connection.Open();
			try
			{
				for(int counter = 0; counter < this.dsCreditsDetails1.CreditsDetails.Rows.Count; counter ++)
				{
					dsCreditsDetails.CreditsDetailsRow row = dsCreditsDetails1.CreditsDetails[counter];
					this.sqlCmdCreditRedemptionParams.Parameters["@CreditID"].Value = row.CreditID;
					this.sqlCmdCreditRedemptionParams.Parameters["@RedemptionDate"].Value = DateTime.Now.Date;
					this.sqlCmdCreditRedemptionParams.Parameters["@RedemptionSum"].Value = 0;
					this.sqlCmdCreditRedemptionParams.Parameters["@Mode"].Value = 0;
					this.sqlCmdCreditRedemptionParams.Parameters["@RedemptionMode"].Value = 0;
					this.sqlCmdCreditRedemptionParams.ExecuteNonQuery();
					row.BeginEdit();
					row["SumPercentNormalCurrent"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumPercentNormalCurrent"].Value;
					row["SumPercentPenaltyCurrent"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumPercentPenaltyCurrent"].Value;
					row["DropSumPercentNormalCurrent"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTDropSumPercentNormalCurrent"].Value;
					row["DropSumPercentPenaltyCurrent"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTDropSumPercentPenaltyCurrent"].Value;
					row["DueSumPercentNormalCurrent"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTDueSumPercentNormalCurrent"].Value;
					row["DueSumPercentPenaltyCurrent"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTDueSumPercentPenaltyCurrent"].Value;
					row["CreditOpLastDate"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditOpLastDate"].Value;
					row["LastDateChargeNormal"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormal"].Value;
					row["LastDateChargePenalty"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenalty"].Value;
					row["LastDateChargeNormalDrop"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargeNormalDrop"].Value;
					row["LastDateChargePenaltyDrop"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateChargePenaltyDrop"].Value;
					row["LastDateCreditDrop"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTLastDateCreditDrop"].Value;
					row["CreditTypeText"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditTypeText"].Value;
					row["CreditSumRedemption"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditSumRedemption"].Value;
					row["CreditIncreaseSum"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseSum"].Value;
					row["CreditIncreaseLastDate"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTCreditIncreaseLastDate"].Value;
					row["SumForDropPercentNormal"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumForDropPercentNormal"].Value;
					row["SumForDropPercentPenalty"] = this.sqlCmdCreditRedemptionParams.Parameters["@OUTSumForDropPercentPenalty"].Value;
					row.EndEdit();
				} //for
				return 0;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения данных о кредите(2): " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return -1;
			}
			finally 
			{
				if ( ConnectionState.Open ==this.sqlCmdCreditRedemptionParams.Connection.State)
					this.sqlCmdCreditRedemptionParams.Connection.Close();
			}
		}

		private void FillOperationsGroups()
		{
			if(bmCredits.Position < 0) return;
			
			this.dsCreditsOperationsGroups1.Clear();
			try
			{
				this.sqldaCreditGroups.SelectCommand.Parameters["@CreditID"].Value = ((dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row).CreditID;
				this.sqldaCreditGroups.Fill( this.dsCreditsOperationsGroups1, "CreditsOperationsGroups");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения групп операций по кредиту: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void FillOperations()
		{
			if(bmCredits.Position < 0) return;
			
			dsCreditsOperations1.Clear();
			try
			{
				this.sqlDataAdapter2.SelectCommand.Parameters["@CreditID"].Value = ((dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row).CreditID;
				this.sqlDataAdapter2.Fill(this.dsCreditsOperations1);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка чтения операций по кредиту: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		#endregion

		#region ToolBar
		
		private void ToolBarChangeApperance()
		{
			dsCredits.CreditsRow row = (dsCredits.CreditsRow)((DataRowView)bmCredits.Current).Row;
			
			this.tbbGrant.Text					=(row.IsGranted) ?"Выдать" :"Получить";
			this.tbbEdit.Text					=(row.CreditStatusID ==1) ?"Изменить" :"Просмотр";
			this.tbbGrant.Enabled				=(row.CreditStatusID ==1) ?true :false;
			this.tbbClose.Enabled				=(row.CreditStatusID ==2) ?true :false;
			this.tbbDel.Enabled					=(row.CreditStatusID ==1) ?true :false;
			this.tbbIncrease.Enabled			=(!row.IsShortTerm && !row.IsExtended && row.CreditStatusID ==2);
			this.tbbRollbackLastGroup.Enabled	=(row.CreditStatusID !=1) ?true :false;
			this.tbbPayBackCredit.Enabled		=(row.CreditStatusID ==2) ?true :false;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbbNew)
			{
				this.AddNewCredit();
			}
			else if(e.Button == this.tbbEdit)
			{
				this.EditCredit();
			}
			else if(e.Button == this.tbbDel)
			{
				this.DelCredit();
			}
			else if(e.Button == this.tbbGrant)
			{
				this.GrantCredit();
			}
			else if(e.Button == this.tbbIncrease)
			{
				this.CreditIncrease();
			}
			else if(e.Button == this.tbbClose)
			{
				this.CloseCredit();
			}
			else if(e.Button == this.tbbPayBackCredit)
			{
				this.PayBackCredit();
			}
			else if ( e.Button ==this.tbbRollbackLastGroup)
			{
				this.LastGroupRollback();
			}
		}
		#endregion

		#region TreeTotals
		private void trvTotalsFill()
		{
			string szNodeText	="";
			string szSumFormat	="#,##0.00";
			string szDelimiter	=":  ";

			this.trvTotals.Nodes.Clear();
			
			TreeNode vNodeRoot0 =new TreeNode();
			TreeNode vNodeRoot1 =new TreeNode();
			TreeNode vNodeRoot2 =new TreeNode();
			TreeNode vNodeRoot3 =new TreeNode();

			this.dvCreditsListSummary.RowFilter ="[GrpType] =0";
			vNodeRoot0.Text ="Активных Получено: "
				+((double)(this.sqldaCreditsListSummary.SelectCommand.Parameters["@TotalCreditSumIn"].Value)).ToString( szSumFormat)
				+" " +App.MainCurrencyID +" (" +this.dvCreditsListSummary.Count.ToString() +")";
			this.trvTotals.Nodes.Add( vNodeRoot0);
			for ( int i =0; i <this.dvCreditsListSummary.Count; i++) 
			{
				_Forms.dsCreditsListSummary._TableRow rw =(_Forms.dsCreditsListSummary._TableRow)this.dvCreditsListSummary[i].Row;
				szNodeText =rw.CreditSumCurrency +szDelimiter +rw.CreditSumSum.ToString( szSumFormat);
				TreeNode vNode =new TreeNode( szNodeText);
				vNodeRoot0.Nodes.Add( vNode); 
			}
			vNodeRoot0.Expand();

			this.dvCreditsListSummary.RowFilter ="[GrpType] =1";
			vNodeRoot1.Text ="Активных Выдано: " 
				+((double)(this.sqldaCreditsListSummary.SelectCommand.Parameters["@TotalCreditSumOut"].Value)).ToString( szSumFormat)
				+" " +App.MainCurrencyID +" (" +this.dvCreditsListSummary.Count.ToString() +")";
			this.trvTotals.Nodes.Add( vNodeRoot1);
			for ( int i =0; i <this.dvCreditsListSummary.Count; i++) 
			{
				_Forms.dsCreditsListSummary._TableRow rw =(_Forms.dsCreditsListSummary._TableRow)this.dvCreditsListSummary[i].Row;
				szNodeText =rw.CreditSumCurrency +szDelimiter +rw.CreditSumSum.ToString( szSumFormat);
				TreeNode vNode =new TreeNode( szNodeText);
				vNodeRoot1.Nodes.Add( vNode); 
			}
			vNodeRoot1.Expand();

			this.dvCreditsListSummary.RowFilter ="[GrpType] =2";
			vNodeRoot2.Text ="Активных Баланс: " 
				+((double)(this.sqldaCreditsListSummary.SelectCommand.Parameters["@TotalCreditSumBalance"].Value)).ToString( szSumFormat)
				+" " +App.MainCurrencyID +" (" +this.dvCreditsListSummary.Count.ToString() +")";
			this.trvTotals.Nodes.Add( vNodeRoot2);
			for ( int i =0; i <this.dvCreditsListSummary.Count; i++) 
			{
				_Forms.dsCreditsListSummary._TableRow rw =(_Forms.dsCreditsListSummary._TableRow)this.dvCreditsListSummary[i].Row;
				szNodeText =rw.CreditSumCurrency +szDelimiter +rw.CreditSumSum.ToString( szSumFormat);
				TreeNode vNode =new TreeNode( szNodeText);
				vNodeRoot2.Nodes.Add( vNode); 
			}
			vNodeRoot2.Expand();

			this.dvCreditsListSummary.RowFilter ="[GrpType] =3";
			vNodeRoot3.Text ="По Фильтру: "
				+((double)(this.sqldaCreditsListSummary.SelectCommand.Parameters["@TotalCreditSumFilter"].Value)).ToString( szSumFormat)
				+" " +App.MainCurrencyID +" (" +this.dvCreditsListSummary.Count.ToString() +")";
			this.trvTotals.Nodes.Add( vNodeRoot3);
			for ( int i =0; i <this.dvCreditsListSummary.Count; i++) 
			{
				_Forms.dsCreditsListSummary._TableRow rw =(_Forms.dsCreditsListSummary._TableRow)this.dvCreditsListSummary[i].Row;
				szNodeText =rw.CreditSumCurrency +szDelimiter +rw.CreditSumSum.ToString( szSumFormat);
				TreeNode vNode =new TreeNode( szNodeText);
				this.trvTotals.Nodes[3].Nodes.Add( vNode); 
			}
			vNodeRoot3.Expand();
		}
		#endregion

	}
}
