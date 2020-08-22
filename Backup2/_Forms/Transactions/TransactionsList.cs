using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BPS._Forms;
using AM_Controls;
namespace BPS
{
	/// <summary>
	/// Summary description for TransactionsOut.
	/// </summary>
	public class TransactionsList : System.Windows.Forms.Form
	{
		private BPS.BLL.Orgs.UsersOrgsAndAccounts bll = new BPS.BLL.Orgs.UsersOrgsAndAccounts();

		private System.Windows.Forms.ToolBar toolBar1;
		private AM_Controls.DataGridVX dataGridV1;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Data.DataView dvClients;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Data.DataView dvTransList;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BLL.Transactions.DataSets.dsTransactionList dsTransactionList1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn TransactiontID;
		private System.Windows.Forms.DataGridTextBoxColumn ClientName;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionSum;
		private System.Windows.Forms.DataGridTextBoxColumn ServiceCharge;
		private System.Windows.Forms.DataGridBoolColumn TransactionCommited;
		private System.Windows.Forms.DataGridTextBoxColumn Remarks;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionType;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionInitDate;
		private System.Windows.Forms.DataGridBoolColumn TransactionPosted;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionCompleteDate;
		private System.Windows.Forms.DataGridTextBoxColumn SumTo;
		private System.Windows.Forms.DataGridTextBoxColumn CurrencyRate;
		private System.Windows.Forms.DataGridTextBoxColumn colCurrencyFrom;
		private System.Windows.Forms.DataGridTextBoxColumn colCurrencyTo;
		private System.Windows.Forms.DataGridTextBoxColumn OrgFrom;
		private System.Windows.Forms.DataGridTextBoxColumn OrgTo;
		private System.Windows.Forms.DataGridTextBoxColumn OrgAccFrom;
		private System.Windows.Forms.DataGridTextBoxColumn OrgAccTo;
		
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter daSelTransTypes;
		private System.Data.SqlClient.SqlDataAdapter daSelTrans;

		private BindingManagerBase bmList;
		private System.Data.DataView dvTransTypes;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuDel;
		private System.Data.SqlClient.SqlDataAdapter daUpdTrans;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelAccountID;
		private System.Windows.Forms.MenuItem mnuExec;
		private System.Data.SqlClient.SqlCommand sqlMakePOForTrans;
		private System.Data.SqlClient.SqlCommand sqlChangeTransactionStatus;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Data.SqlClient.SqlCommand sqlDoClientsTransaction;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbExec;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.ToolBarButton tbbApply;
		private System.Windows.Forms.ToolBarButton toolBarButton10;
		private System.Windows.Forms.ToolBarButton tbbConfirm;
		private System.Windows.Forms.ToolBarButton tbbClear;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuConfirm;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuFltrApply;
		private System.Windows.Forms.MenuItem mnuFltrClear;
		private System.Windows.Forms.DataGridTextBoxColumn colPurpose;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mnuCancelExec;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDAUListOrgs;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlDataAdapter sqlDAUListOrgsAccounts;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private BPS._Forms.dsUListOrgs dsUListOrgs1;
		private BPS._Forms.dsUListOrgsAccounts dsUListOrgsAccounts1;
		private System.Data.DataView dvUListOrgsPayee;
		private System.Data.DataView dvUListOrgsPayer;
		private System.Data.DataView dvUListOrgsAccsPayer;
		private System.Data.DataView dvUListOrgsAccsPayee;
		private System.Windows.Forms.MenuItem mnuCopy;
		private System.Data.SqlClient.SqlCommand sqlCancelTrans;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionCreateTime;
		private System.Windows.Forms.MenuItem mnuSetDate;
		private System.Data.SqlClient.SqlCommand sqlSetDateCmd;
		private System.Data.SqlClient.SqlDataAdapter daRefresh;
		private System.Data.SqlClient.SqlCommand sqlCommand2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private BPS._Forms.dsTransSumList dsTransSumList1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Data.DataView dvTransSumList;
		private AM_Controls.TextBoxV tbSum;
		private BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rwCurrentRow;
		private AM_Controls.TextBoxV tbTransCount;
		private AM_Controls.ucPeriodSimple cPeriod;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbClients;
		private System.Windows.Forms.CheckBox cbCreated;
		private System.Windows.Forms.CheckBox cbFinished;
		private System.Windows.Forms.CheckBox cbStarted;
		private System.Windows.Forms.CheckBox cbPayerEQPayee;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.CheckBox cbPosted;
		private System.Windows.Forms.CheckBox cbCommited;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbCompareOp;
		private AM_Controls.TextBoxV textBoxV1;
		private bool bIsLoaded = false;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Data.SqlClient.SqlCommand sqlCheckOrgAccountSaldo;
		private System.Data.SqlClient.SqlCommand sqlCheckClientSaldo;
		private System.Data.SqlClient.SqlCommand sqlCheckCash;
		private System.Data.SqlClient.SqlCommand sqlCheckCashFinal;
		private System.Data.SqlClient.SqlCommand sqlCheckClientSaldoFinal;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Data.SqlClient.SqlCommand sqlCheckClientSaldoIndirect;
		private System.Data.SqlClient.SqlCommand sqlCheckClientSaldoIndirectFinal;
		private System.Data.SqlClient.SqlCommand sqlCheckLoanSum;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox grpStatus;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnSumClear;
		private BPS._Controls.OrgsAndAccounts grpPayee;
		private BPS._Controls.OrgsAndAccounts grpPayer;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cmbCompareCurrency;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cbAnyCurrency;
		private System.Data.DataView dvFilterSumCurrency;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbPaymOrderStatus;
		private System.Windows.Forms.TextBox tbPaymOrderNo;
		private System.Windows.Forms.TextBox tbPaymOrderHeaderStatus;
		private System.Windows.Forms.TextBox tbPaymOrderHeaderID;
		private System.Windows.Forms.TextBox tbPaymOrderDate;
		private System.Windows.Forms.TextBox tbPaymOrderHeaderDate;
		private System.Windows.Forms.TextBox tbPaymOrderRem;
		private System.Windows.Forms.TextBox tbPaymOrderText;
		private System.Data.SqlClient.SqlCommand sqlCmdPaymOrderGetInfo;
		private System.Data.SqlClient.SqlConnection sqlConnection3;
		/// <summary>
		/// показывать транзакции по кредитам
		/// = false - не показывать
		/// = true  - показывать
		/// </summary>
		private const bool ShowCreditTransactions = false;

		public TransactionsList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			bll.Fill( App.UserLogonID );
			this.grpPayer.Init(bll);
			this.grpPayee.Init(bll);

			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			
			fillDGCurrSum();
			
			App.SetDataGridTableStyle(this.dataGridTableStyle2);
			
			foreach( MenuItem mi in contextMenu1.MenuItems)
				if (!mi.OwnerDraw) 
				{
					mi.OwnerDraw = true;
				}

			//App.Clone(this.menuEdit.MenuItems, this.contextMenu1);
			//this.dataGridV1.ContextMenu = this.contextMenu1;
			////////////для фильтра
		{
			this.dvClients.Table = App.DsClients.Clients.Copy();
			BPS.BLL.Clients.DataSets.dsClients.ClientsRow dr = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dvClients.Table.NewRow();
			dr.ClientName = "<Все>";
			dr.ClientID = 0;
			dr.ClientGroupID = 0;
			dr.ClientGroupName = "";
			dr.ClientRemarks = "";
			dr.IsSpecial=false;
			dr.IsInner=false;

			this.dvClients.Table.Rows.Add(dr);
			this.dvClients.Sort = "ClientName";
			this.cmbClients.DataSource = this.dvClients;
			this.cmbClients.DisplayMember = "ClientName";
			this.cmbClients.ValueMember = "ClientID";
			this.cmbClients.SelectedIndex = 0;
		}
			this.daSelTransTypes.Fill(this.dsTransactionList1.TransactionsTypes);
		{
			this.dvTransTypes.Table = this.dsTransactionList1.TransactionsTypes.Copy();
			BLL.Transactions.DataSets.dsTransactionList.TransactionsTypesRow dr = (BLL.Transactions.DataSets.dsTransactionList.TransactionsTypesRow)this.dvTransTypes.Table.NewRow();
			dr.TransactionTypeID = 0;
			dr.TransactionTypeName =  "<Все>";
			dr.IsInner = false;
			dr.UseOrgAcc = false;
			this.dvTransTypes.Table.Rows.Add(dr);
			this.dvTransTypes.Sort = "TransactionTypeID";
			this.dvTransTypes.RowFilter ="[TransactionTypeID] <19 OR [TransactionTypeID] >32";
		}			

			this.dvFilterSumCurrency.Table = App.bllCurrency.DataSet.Currencies;
			this.cmbCompareCurrency.DataSource = this.dvFilterSumCurrency;
			this.cmbCompareCurrency.DisplayMember = "CurrencyID";
			this.cmbCompareCurrency.ValueMember = "CurrencyID";

			///////////////////////////
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			bmList = (BindingManagerBase)this.BindingContext[this.dvTransList];
			bmList.CurrentChanged += new EventHandler (OnCurrentChanged);

			this.dataGridV1.LoadSettings();

			App.FillOrgsAccount();
			try 
			{
				this.sqlDAUListOrgs.Fill( this.dsUListOrgs1.UListOrgs); 
				this.sqlDAUListOrgsAccounts.Fill( this.dsUListOrgsAccounts1);
				
			}
			catch(Exception ex) 
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			FilterClear();
			FilterApply();
		}

		private void OnCurrentChanged(object sender, System.EventArgs e)
		{
			if (bmList.Position!= -1) 
			{
				rwCurrentRow = (BLL.Transactions.DataSets.dsTransactionList.TransactionsRow)((DataRowView)bmList.Current).Row;
				try 
				{
					Cursor.Current = Cursors.WaitCursor;
					
					this.tbPaymOrderDate.Text			="";
					this.tbPaymOrderHeaderDate.Text		="";
					this.tbPaymOrderHeaderID.Text		="";
					this.tbPaymOrderHeaderStatus.Text	="";
					this.tbPaymOrderNo.Text				="";
					this.tbPaymOrderRem.Text			="";
					this.tbPaymOrderStatus.Text			="";
					this.tbPaymOrderText.Text			="";

					this.sqlCmdPaymOrderGetInfo.Parameters["@InfoMode"].Value =1;
					this.sqlCmdPaymOrderGetInfo.Parameters["@EntityID"].Value =rwCurrentRow.TransactionID;

					if ( this.sqlCmdPaymOrderGetInfo.Connection.State ==System.Data.ConnectionState.Closed)
						this.sqlCmdPaymOrderGetInfo.Connection.Open();
					
					this.sqlCmdPaymOrderGetInfo.ExecuteNonQuery(); 
					
					if ( 0 <((int)this.sqlCmdPaymOrderGetInfo.Parameters["@POID"].Value)) 
					{
						this.tbPaymOrderDate.Text			=((System.DateTime)(this.sqlCmdPaymOrderGetInfo.Parameters["@PODate"].Value)).ToString("dd-MMM-yy");
						
						int nHeaderID =(int)(this.sqlCmdPaymOrderGetInfo.Parameters["@POHeaderID"].Value);
						if ( nHeaderID >0) 
						{
							this.tbPaymOrderHeaderID.Text		=nHeaderID.ToString();
							this.tbPaymOrderHeaderDate.Text		=((System.DateTime)(this.sqlCmdPaymOrderGetInfo.Parameters["@POHeaderDate"].Value)).ToString("dd-MMM-yy");
							this.tbPaymOrderHeaderStatus.Text	=((string)(this.sqlCmdPaymOrderGetInfo.Parameters["@POHeaderTStatus"].Value)).ToString();
						}
						else 
						{
							this.tbPaymOrderHeaderStatus.Text="<НЕ ВКЛЮЧЕНА>";
						}
						this.tbPaymOrderNo.Text				=((string)(this.sqlCmdPaymOrderGetInfo.Parameters["@PONo"].Value)).ToString();
						this.tbPaymOrderText.Text			=((string)(this.sqlCmdPaymOrderGetInfo.Parameters["@POText"].Value)).ToString();
						this.tbPaymOrderStatus.Text			=((string)(this.sqlCmdPaymOrderGetInfo.Parameters["@POTStatus"].Value)).ToString();
						this.tbPaymOrderRem.Text			=((string)(this.sqlCmdPaymOrderGetInfo.Parameters["@PORem"].Value)).ToString();;
					}
				}
				catch(Exception ex) 
				{
					MessageBox.Show( "Ошибка чтения данных платёжном поручении: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);  
				}
				finally 
				{
					if ( this.sqlCmdPaymOrderGetInfo.Connection.State ==System.Data.ConnectionState.Open)
						this.sqlCmdPaymOrderGetInfo.Connection.Close();
					Cursor.Current = Cursors.Default;
				}
			}
			else
				rwCurrentRow = null;
		}

		private void fillDGCurrSum()
		{
			for(int i = 0; i < App.DsCurr.Currencies.Count; i++)
			{
				dsTransSumList.TransSumListRow rw = (dsTransSumList.TransSumListRow) this.dvTransSumList.Table.NewRow();
				rw.CurrencyID = App.DsCurr.Currencies[i].CurrencyID;
				rw.Sum = 0;
				this.dvTransSumList.Table.Rows.Add((DataRow) rw);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TransactionsList));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.dvUListOrgsPayer = new System.Data.DataView();
			this.dsUListOrgs1 = new BPS._Forms.dsUListOrgs();
			this.dvTransTypes = new System.Data.DataView();
			this.dsTransactionList1 = new BPS.BLL.Transactions.DataSets.dsTransactionList();
			this.dvUListOrgsAccsPayer = new System.Data.DataView();
			this.dsUListOrgsAccounts1 = new BPS._Forms.dsUListOrgsAccounts();
			this.dvUListOrgsAccsPayee = new System.Data.DataView();
			this.dvUListOrgsPayee = new System.Data.DataView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton10 = new System.Windows.Forms.ToolBarButton();
			this.tbbExec = new System.Windows.Forms.ToolBarButton();
			this.tbbConfirm = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.tbbApply = new System.Windows.Forms.ToolBarButton();
			this.tbbClear = new System.Windows.Forms.ToolBarButton();
			this.dataGridV1 = new AM_Controls.DataGridVX();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuCopy = new System.Windows.Forms.MenuItem();
			this.mnuDel = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuExec = new System.Windows.Forms.MenuItem();
			this.mnuConfirm = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuCancelExec = new System.Windows.Forms.MenuItem();
			this.mnuSetDate = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuFltrApply = new System.Windows.Forms.MenuItem();
			this.mnuFltrClear = new System.Windows.Forms.MenuItem();
			this.dvTransList = new System.Data.DataView();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.TransactiontID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionCommited = new System.Windows.Forms.DataGridBoolColumn();
			this.TransactionPosted = new System.Windows.Forms.DataGridBoolColumn();
			this.TransactionCreateTime = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionInitDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionCompleteDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionType = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colCurrencyFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ServiceCharge = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgAccFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgAccTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Remarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CurrencyRate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.SumTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colCurrencyTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dvClients = new System.Data.DataView();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.daSelTrans = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.daSelTransTypes = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.daUpdTrans = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelAccountID = new System.Data.SqlClient.SqlCommand();
			this.sqlMakePOForTrans = new System.Data.SqlClient.SqlCommand();
			this.sqlChangeTransactionStatus = new System.Data.SqlClient.SqlCommand();
			this.sqlDoClientsTransaction = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDAUListOrgs = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDAUListOrgsAccounts = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlCancelTrans = new System.Data.SqlClient.SqlCommand();
			this.sqlSetDateCmd = new System.Data.SqlClient.SqlCommand();
			this.daRefresh = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.tbTransCount = new AM_Controls.TextBoxV();
			this.tbSum = new AM_Controls.TextBoxV();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvTransSumList = new System.Data.DataView();
			this.dsTransSumList1 = new BPS._Forms.dsTransSumList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.cPeriod = new AM_Controls.ucPeriodSimple();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbClients = new System.Windows.Forms.ComboBox();
			this.cbCreated = new System.Windows.Forms.CheckBox();
			this.cbFinished = new System.Windows.Forms.CheckBox();
			this.cbStarted = new System.Windows.Forms.CheckBox();
			this.cbPayerEQPayee = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.cbPosted = new System.Windows.Forms.CheckBox();
			this.cbCommited = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbCompareOp = new System.Windows.Forms.ComboBox();
			this.textBoxV1 = new AM_Controls.TextBoxV();
			this.sqlCheckOrgAccountSaldo = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckClientSaldo = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckCash = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckClientSaldoFinal = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckCashFinal = new System.Data.SqlClient.SqlCommand();
			this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.sqlCheckClientSaldoIndirect = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckClientSaldoIndirectFinal = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckLoanSum = new System.Data.SqlClient.SqlCommand();
			this.panel1 = new System.Windows.Forms.Panel();
			this.grpStatus = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbAnyCurrency = new System.Windows.Forms.CheckBox();
			this.cmbCompareCurrency = new System.Windows.Forms.ComboBox();
			this.btnSumClear = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.grpPayee = new BPS._Controls.OrgsAndAccounts();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grpPayer = new BPS._Controls.OrgsAndAccounts();
			this.dvFilterSumCurrency = new System.Data.DataView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tbPaymOrderNo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbPaymOrderStatus = new System.Windows.Forms.TextBox();
			this.tbPaymOrderHeaderStatus = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbPaymOrderHeaderID = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.tbPaymOrderDate = new System.Windows.Forms.TextBox();
			this.tbPaymOrderHeaderDate = new System.Windows.Forms.TextBox();
			this.tbPaymOrderRem = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tbPaymOrderText = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.sqlCmdPaymOrderGetInfo = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection3 = new System.Data.SqlClient.SqlConnection();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsPayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUListOrgs1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransactionList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsAccsPayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUListOrgsAccounts1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsAccsPayee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsPayee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransSumList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransSumList1)).BeginInit();
			this.panel1.SuspendLayout();
			this.grpStatus.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvFilterSumCurrency)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// dvUListOrgsPayer
			// 
			this.dvUListOrgsPayer.Table = this.dsUListOrgs1.UListOrgs;
			// 
			// dsUListOrgs1
			// 
			this.dsUListOrgs1.DataSetName = "dsUListOrgs";
			this.dsUListOrgs1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dvTransTypes
			// 
			this.dvTransTypes.Table = this.dsTransactionList1.TransactionsTypes;
			// 
			// dsTransactionList1
			// 
			this.dsTransactionList1.DataSetName = "dsTransactionList";
			this.dsTransactionList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dvUListOrgsAccsPayer
			// 
			this.dvUListOrgsAccsPayer.Table = this.dsUListOrgsAccounts1.OrgsAccounts;
			// 
			// dsUListOrgsAccounts1
			// 
			this.dsUListOrgsAccounts1.DataSetName = "dsUListOrgsAccounts";
			this.dsUListOrgsAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dvUListOrgsAccsPayee
			// 
			this.dvUListOrgsAccsPayee.Table = this.dsUListOrgsAccounts1.OrgsAccounts;
			// 
			// dvUListOrgsPayee
			// 
			this.dvUListOrgsPayee.Table = this.dsUListOrgs1.UListOrgs;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel,
																						this.toolBarButton10,
																						this.tbbExec,
																						this.tbbConfirm,
																						this.toolBarButton1,
																						this.toolBarButton4,
																						this.tbbApply,
																						this.tbbClear});
			this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(1040, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "Новая";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Открыть";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 3;
			this.tbbDel.Text = "Удалить";
			// 
			// toolBarButton10
			// 
			this.toolBarButton10.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbExec
			// 
			this.tbbExec.ImageIndex = 8;
			this.tbbExec.Text = "Выполнить";
			// 
			// tbbConfirm
			// 
			this.tbbConfirm.ImageIndex = 4;
			this.tbbConfirm.Text = "Подтв.";
			this.tbbConfirm.Visible = false;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Visible = false;
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbApply
			// 
			this.tbbApply.ImageIndex = 6;
			this.tbbApply.Text = "Выбрать";
			// 
			// tbbClear
			// 
			this.tbbClear.ImageIndex = 5;
			this.tbbClear.Text = "Очистить";
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1._SaveStyles = true;
			this.dataGridV1.CaptionVisible = false;
			this.dataGridV1.ContextMenu = this.contextMenu1;
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dvTransList;
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 0);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.ReadOnly = true;
			this.dataGridV1.Size = new System.Drawing.Size(1040, 368);
			this.dataGridV1.TabIndex = 1;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle2});
			this.dataGridV1.DoubleClick += new System.EventHandler(this.dataGridV1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuEdit,
																						 this.mnuNew,
																						 this.mnuCopy,
																						 this.mnuDel,
																						 this.menuItem1,
																						 this.mnuExec,
																						 this.mnuConfirm,
																						 this.menuItem2,
																						 this.mnuCancelExec,
																						 this.mnuSetDate,
																						 this.menuItem4,
																						 this.mnuFltrApply,
																						 this.mnuFltrClear});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// mnuEdit
			// 
			this.mnuEdit.DefaultItem = true;
			this.mnuEdit.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuEdit, ((System.Drawing.Icon)(resources.GetObject("mnuEdit.MenuItemImage"))));
			this.mnuEdit.OwnerDraw = true;
			this.mnuEdit.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.mnuEdit.Text = "Открыть";
			this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuNew, ((System.Drawing.Icon)(resources.GetObject("mnuNew.MenuItemImage"))));
			this.mnuNew.OwnerDraw = true;
			this.mnuNew.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.mnuNew.Text = "Новая";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuCopy
			// 
			this.mnuCopy.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCopy, ((System.Drawing.Icon)(resources.GetObject("mnuCopy.MenuItemImage"))));
			this.mnuCopy.OwnerDraw = true;
			this.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlF3;
			this.mnuCopy.Text = "Копировать";
			this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
			// 
			// mnuDel
			// 
			this.mnuDel.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuDel, ((System.Drawing.Icon)(resources.GetObject("mnuDel.MenuItemImage"))));
			this.mnuDel.OwnerDraw = true;
			this.mnuDel.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.mnuDel.Text = "Удалить";
			this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem1, null);
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "-";
			// 
			// mnuExec
			// 
			this.mnuExec.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuExec, ((System.Drawing.Icon)(resources.GetObject("mnuExec.MenuItemImage"))));
			this.mnuExec.OwnerDraw = true;
			this.mnuExec.Shortcut = System.Windows.Forms.Shortcut.F8;
			this.mnuExec.Text = "Начать выполнение";
			this.mnuExec.Click += new System.EventHandler(this.mnuExec_Click);
			// 
			// mnuConfirm
			// 
			this.mnuConfirm.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuConfirm, ((System.Drawing.Icon)(resources.GetObject("mnuConfirm.MenuItemImage"))));
			this.mnuConfirm.OwnerDraw = true;
			this.mnuConfirm.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftF8;
			this.mnuConfirm.Text = "Подтвердить выполнение";
			this.mnuConfirm.Click += new System.EventHandler(this.mnuConfirm_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem2, null);
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "-";
			// 
			// mnuCancelExec
			// 
			this.mnuCancelExec.Index = 8;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCancelExec, ((System.Drawing.Icon)(resources.GetObject("mnuCancelExec.MenuItemImage"))));
			this.mnuCancelExec.OwnerDraw = true;
			this.mnuCancelExec.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftF12;
			this.mnuCancelExec.Text = "Отменить выполнение";
			this.mnuCancelExec.Click += new System.EventHandler(this.mnuCancelExec_Click);
			// 
			// mnuSetDate
			// 
			this.mnuSetDate.Index = 9;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuSetDate, ((System.Drawing.Icon)(resources.GetObject("mnuSetDate.MenuItemImage"))));
			this.mnuSetDate.OwnerDraw = true;
			this.mnuSetDate.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.mnuSetDate.Text = "Установить дату";
			this.mnuSetDate.Click += new System.EventHandler(this.mnuSetDate_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 10;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem4, null);
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Text = "-";
			// 
			// mnuFltrApply
			// 
			this.mnuFltrApply.Index = 11;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuFltrApply, ((System.Drawing.Icon)(resources.GetObject("mnuFltrApply.MenuItemImage"))));
			this.mnuFltrApply.OwnerDraw = true;
			this.mnuFltrApply.Text = "Выбрать по фильтру";
			this.mnuFltrApply.Click += new System.EventHandler(this.mnuFltrApply_Click);
			// 
			// mnuFltrClear
			// 
			this.mnuFltrClear.Index = 12;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuFltrClear, ((System.Drawing.Icon)(resources.GetObject("mnuFltrClear.MenuItemImage"))));
			this.mnuFltrClear.OwnerDraw = true;
			this.mnuFltrClear.Text = "Очистить фильтр";
			this.mnuFltrClear.Click += new System.EventHandler(this.mnuFltrClear_Click);
			// 
			// dvTransList
			// 
			this.dvTransList.ApplyDefaultSort = true;
			this.dvTransList.Sort = "TransactionID";
			this.dvTransList.Table = this.dsTransactionList1.Transactions;
			this.dvTransList.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.dvTransList_ListChanged);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGridV1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.TransactiontID,
																												  this.TransactionCommited,
																												  this.TransactionPosted,
																												  this.TransactionCreateTime,
																												  this.TransactionInitDate,
																												  this.TransactionCompleteDate,
																												  this.TransactionType,
																												  this.ClientName,
																												  this.TransactionSum,
																												  this.colCurrencyFrom,
																												  this.ServiceCharge,
																												  this.OrgFrom,
																												  this.OrgAccFrom,
																												  this.OrgTo,
																												  this.OrgAccTo,
																												  this.Remarks,
																												  this.CurrencyRate,
																												  this.SumTo,
																												  this.colCurrencyTo,
																												  this.colPurpose});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "Transactions";
			// 
			// TransactiontID
			// 
			this.TransactiontID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.TransactiontID.Format = "";
			this.TransactiontID.FormatInfo = null;
			this.TransactiontID.HeaderText = "ID";
			this.TransactiontID.MappingName = "TransactionID";
			this.TransactiontID.NullText = "";
			this.TransactiontID.Width = 40;
			// 
			// TransactionCommited
			// 
			this.TransactionCommited.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.TransactionCommited.FalseValue = false;
			this.TransactionCommited.HeaderText = "C";
			this.TransactionCommited.MappingName = "TransactionCommited";
			this.TransactionCommited.NullText = "";
			this.TransactionCommited.NullValue = ((object)(resources.GetObject("TransactionCommited.NullValue")));
			this.TransactionCommited.TrueValue = true;
			this.TransactionCommited.Width = 15;
			// 
			// TransactionPosted
			// 
			this.TransactionPosted.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.TransactionPosted.FalseValue = false;
			this.TransactionPosted.HeaderText = "P";
			this.TransactionPosted.MappingName = "TransactionPosted";
			this.TransactionPosted.NullValue = ((object)(resources.GetObject("TransactionPosted.NullValue")));
			this.TransactionPosted.TrueValue = true;
			this.TransactionPosted.Width = 15;
			// 
			// TransactionCreateTime
			// 
			this.TransactionCreateTime.Format = "dd/MM/yy";
			this.TransactionCreateTime.FormatInfo = null;
			this.TransactionCreateTime.HeaderText = "Создана";
			this.TransactionCreateTime.MappingName = "CreateDate";
			this.TransactionCreateTime.NullText = "-";
			this.TransactionCreateTime.Width = 50;
			// 
			// TransactionInitDate
			// 
			this.TransactionInitDate.Format = "dd/MM/yy";
			this.TransactionInitDate.FormatInfo = null;
			this.TransactionInitDate.HeaderText = "Начата";
			this.TransactionInitDate.MappingName = "InitDate";
			this.TransactionInitDate.NullText = "-";
			this.TransactionInitDate.Width = 50;
			// 
			// TransactionCompleteDate
			// 
			this.TransactionCompleteDate.Format = "dd/MM/yy";
			this.TransactionCompleteDate.FormatInfo = null;
			this.TransactionCompleteDate.HeaderText = "Завершена";
			this.TransactionCompleteDate.MappingName = "CompleteDate";
			this.TransactionCompleteDate.NullText = "-";
			this.TransactionCompleteDate.Width = 50;
			// 
			// TransactionType
			// 
			this.TransactionType.Format = "";
			this.TransactionType.FormatInfo = null;
			this.TransactionType.HeaderText = "Тип";
			this.TransactionType.MappingName = "TransactionTypeName";
			this.TransactionType.NullText = "";
			this.TransactionType.Width = 80;
			// 
			// ClientName
			// 
			this.ClientName.Format = "";
			this.ClientName.FormatInfo = null;
			this.ClientName.HeaderText = "Клиент";
			this.ClientName.MappingName = "TrClientName";
			this.ClientName.NullText = "-";
			this.ClientName.Width = 75;
			// 
			// TransactionSum
			// 
			this.TransactionSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.TransactionSum.Format = "#,##0.00";
			this.TransactionSum.FormatInfo = null;
			this.TransactionSum.HeaderText = "Сумма";
			this.TransactionSum.MappingName = "SumFrom";
			this.TransactionSum.NullText = "-";
			this.TransactionSum.Width = 75;
			// 
			// colCurrencyFrom
			// 
			this.colCurrencyFrom.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.colCurrencyFrom.Format = "";
			this.colCurrencyFrom.FormatInfo = null;
			this.colCurrencyFrom.MappingName = "CurrencyFrom";
			this.colCurrencyFrom.NullText = "-";
			this.colCurrencyFrom.Width = 30;
			// 
			// ServiceCharge
			// 
			this.ServiceCharge.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ServiceCharge.Format = "0.00%";
			this.ServiceCharge.FormatInfo = null;
			this.ServiceCharge.HeaderText = "%%";
			this.ServiceCharge.MappingName = "ServiceCharge";
			this.ServiceCharge.NullText = "-";
			this.ServiceCharge.Width = 50;
			// 
			// OrgFrom
			// 
			this.OrgFrom.Format = "";
			this.OrgFrom.FormatInfo = null;
			this.OrgFrom.HeaderText = "Плательщик";
			this.OrgFrom.MappingName = "OrgNameFrom";
			this.OrgFrom.NullText = "-";
			this.OrgFrom.Width = 75;
			// 
			// OrgAccFrom
			// 
			this.OrgAccFrom.Format = "";
			this.OrgAccFrom.FormatInfo = null;
			this.OrgAccFrom.MappingName = "RAccountFrom";
			this.OrgAccFrom.NullText = "-";
			this.OrgAccFrom.Width = 130;
			// 
			// OrgTo
			// 
			this.OrgTo.Format = "";
			this.OrgTo.FormatInfo = null;
			this.OrgTo.HeaderText = "Получатель";
			this.OrgTo.MappingName = "OrgNameTo";
			this.OrgTo.NullText = "-";
			this.OrgTo.Width = 75;
			// 
			// OrgAccTo
			// 
			this.OrgAccTo.Format = "";
			this.OrgAccTo.FormatInfo = null;
			this.OrgAccTo.MappingName = "RAccountTo";
			this.OrgAccTo.NullText = "-";
			this.OrgAccTo.Width = 130;
			// 
			// Remarks
			// 
			this.Remarks.Format = "";
			this.Remarks.FormatInfo = null;
			this.Remarks.HeaderText = "Примечание";
			this.Remarks.MappingName = "Remarks";
			this.Remarks.NullText = "-";
			this.Remarks.Width = 300;
			// 
			// CurrencyRate
			// 
			this.CurrencyRate.Format = "#,##0.0000";
			this.CurrencyRate.FormatInfo = null;
			this.CurrencyRate.HeaderText = "Курс";
			this.CurrencyRate.MappingName = "CurrencyRate";
			this.CurrencyRate.NullText = "-";
			this.CurrencyRate.Width = 75;
			// 
			// SumTo
			// 
			this.SumTo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.SumTo.Format = "#,##0.00";
			this.SumTo.FormatInfo = null;
			this.SumTo.HeaderText = "Сумма";
			this.SumTo.MappingName = "SumTo";
			this.SumTo.NullText = "-";
			this.SumTo.Width = 75;
			// 
			// colCurrencyTo
			// 
			this.colCurrencyTo.Format = "";
			this.colCurrencyTo.FormatInfo = null;
			this.colCurrencyTo.MappingName = "CurrencyTo";
			this.colCurrencyTo.NullText = "-";
			this.colCurrencyTo.Width = 30;
			// 
			// colPurpose
			// 
			this.colPurpose.Format = "";
			this.colPurpose.FormatInfo = null;
			this.colPurpose.MappingName = "Purpose";
			this.colPurpose.Width = 75;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuEdit});
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuEdit, null);
			this.menuEdit.MergeOrder = 1;
			this.menuEdit.OwnerDraw = true;
			this.menuEdit.Text = "Редактирование";
			// 
			// daSelTrans
			// 
			this.daSelTrans.SelectCommand = this.sqlSelectCommand1;
			this.daSelTrans.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "TransactionsSelect", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																					   new System.Data.Common.DataColumnMapping("TransactionIsInner", "TransactionIsInner"),
																																																					   new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																					   new System.Data.Common.DataColumnMapping("ClientIsInner", "ClientIsInner"),
																																																					   new System.Data.Common.DataColumnMapping("RAccountFrom", "RAccountFrom"),
																																																					   new System.Data.Common.DataColumnMapping("RAccountTo", "RAccountTo"),
																																																					   new System.Data.Common.DataColumnMapping("OrgNameFrom", "OrgNameFrom"),
																																																					   new System.Data.Common.DataColumnMapping("OrgIDFrom", "OrgIDFrom"),
																																																					   new System.Data.Common.DataColumnMapping("OrgIDTo", "OrgIDTo"),
																																																					   new System.Data.Common.DataColumnMapping("OrgNameTo", "OrgNameTo"),
																																																					   new System.Data.Common.DataColumnMapping("PaymentOrderStatusName", "PaymentOrderStatusName"),
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
																																																					   new System.Data.Common.DataColumnMapping("ServiceChargeTo", "ServiceChargeTo"),
																																																					   new System.Data.Common.DataColumnMapping("DocumentID", "DocumentID"),
																																																					   new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																					   new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																					   new System.Data.Common.DataColumnMapping("CreateDate", "CreateDate"),
																																																					   new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																					   new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																					   new System.Data.Common.DataColumnMapping("TransactionIDParent", "TransactionIDParent"),
																																																					   new System.Data.Common.DataColumnMapping("ClientRequestID", "ClientRequestID"),
																																																					   new System.Data.Common.DataColumnMapping("PaymentOrderStatusID", "PaymentOrderStatusID"),
																																																					   new System.Data.Common.DataColumnMapping("CurrencyFrom", "CurrencyFrom"),
																																																					   new System.Data.Common.DataColumnMapping("CurrencyTo", "CurrencyTo"),
																																																					   new System.Data.Common.DataColumnMapping("TrClientName", "TrClientName")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[TransactionsSelect]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection2;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseStartDate", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseFinishDate", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseCreateDate", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTill", System.Data.SqlDbType.DateTime, 8));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// daSelTransTypes
			// 
			this.daSelTransTypes.SelectCommand = this.sqlSelectCommand2;
			this.daSelTransTypes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "TransactionTypesSelect", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("TransactionTypeID", "TransactionTypeID"),
																																																								new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																								new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																								new System.Data.Common.DataColumnMapping("UseOrgAcc", "UseOrgAcc")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[TransactionTypesSelect]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection2;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// daUpdTrans
			// 
			this.daUpdTrans.DeleteCommand = this.sqlDeleteCommand1;
			this.daUpdTrans.InsertCommand = this.sqlInsertCommand1;
			this.daUpdTrans.SelectCommand = this.sqlSelectCommand3;
			this.daUpdTrans.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "Transactions", new System.Data.Common.DataColumnMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("ServiceChargeTo", "ServiceChargeTo"),
																																																				 new System.Data.Common.DataColumnMapping("DocumentID", "DocumentID"),
																																																				 new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																				 new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																				 new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																				 new System.Data.Common.DataColumnMapping("TransactionIDParent", "TransactionIDParent"),
																																																				 new System.Data.Common.DataColumnMapping("ClientRequestID", "ClientRequestID")})});
			this.daUpdTrans.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "[TransactionDeleteCommand]";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection2;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransactionID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "[TransactionInsertCommand]";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection2;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionTypeID", System.Data.SqlDbType.Int, 4, "TransactionTypeID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionCommited", System.Data.SqlDbType.Bit, 1, "TransactionCommited"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionPosted", System.Data.SqlDbType.Bit, 1, "TransactionPosted"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumFrom", System.Data.SqlDbType.Float, 8, "SumFrom"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumTo", System.Data.SqlDbType.Float, 8, "SumTo"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyRate", System.Data.SqlDbType.Float, 8, "CurrencyRate"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDFrom", System.Data.SqlDbType.Int, 4, "AccountIDFrom"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDTo", System.Data.SqlDbType.Int, 4, "AccountIDTo"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8, "ServiceCharge"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceChargeTo", System.Data.SqlDbType.Float, 8, "ServiceChargeTo"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocumentID", System.Data.SqlDbType.Int, 4, "DocumentID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256, "Remarks"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Purpose", System.Data.SqlDbType.NVarChar, 256, "Purpose"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InitDate", System.Data.SqlDbType.DateTime, 8, "InitDate"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompleteDate", System.Data.SqlDbType.DateTime, 8, "CompleteDate"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionIDParent", System.Data.SqlDbType.Int, 4, "TransactionIDParent"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientRequestID", System.Data.SqlDbType.Int, 4, "ClientRequestID"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[TransactionSelectCommand]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Connection = this.sqlConnection2;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "[TransactionUpdateCommand]";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection2;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionTypeID", System.Data.SqlDbType.Int, 4, "TransactionTypeID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionCommited", System.Data.SqlDbType.Bit, 1, "TransactionCommited"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionPosted", System.Data.SqlDbType.Bit, 1, "TransactionPosted"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumFrom", System.Data.SqlDbType.Float, 8, "SumFrom"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumTo", System.Data.SqlDbType.Float, 8, "SumTo"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyRate", System.Data.SqlDbType.Float, 8, "CurrencyRate"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDFrom", System.Data.SqlDbType.Int, 4, "AccountIDFrom"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDTo", System.Data.SqlDbType.Int, 4, "AccountIDTo"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8, "ServiceCharge"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceChargeTo", System.Data.SqlDbType.Float, 8, "ServiceChargeTo"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocumentID", System.Data.SqlDbType.Int, 4, "DocumentID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256, "Remarks"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Purpose", System.Data.SqlDbType.NVarChar, 256, "Purpose"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InitDate", System.Data.SqlDbType.DateTime, 8, "InitDate"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompleteDate", System.Data.SqlDbType.DateTime, 8, "CompleteDate"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionIDParent", System.Data.SqlDbType.Int, 4, "TransactionIDParent"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientRequestID", System.Data.SqlDbType.Int, 4, "ClientRequestID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransactionID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4, "TransactionID"));
			// 
			// sqlSelAccountID
			// 
			this.sqlSelAccountID.CommandText = "[SelectAccountID]";
			this.sqlSelAccountID.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelAccountID.Connection = this.sqlConnection2;
			this.sqlSelAccountID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.VarChar, 3));
			// 
			// sqlMakePOForTrans
			// 
			this.sqlMakePOForTrans.CommandText = "[xPaymOrderFromTransaction]";
			this.sqlMakePOForTrans.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlMakePOForTrans.Connection = this.sqlConnection2;
			this.sqlMakePOForTrans.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlMakePOForTrans.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlChangeTransactionStatus
			// 
			this.sqlChangeTransactionStatus.CommandText = "[ChangeTransactionStatus]";
			this.sqlChangeTransactionStatus.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlChangeTransactionStatus.Connection = this.sqlConnection2;
			this.sqlChangeTransactionStatus.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlChangeTransactionStatus.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nTransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlChangeTransactionStatus.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bCommiting", System.Data.SqlDbType.Bit, 1));
			this.sqlChangeTransactionStatus.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bPosting", System.Data.SqlDbType.Bit, 1));
			// 
			// sqlDoClientsTransaction
			// 
			this.sqlDoClientsTransaction.CommandText = "[DoClientsTransaction]";
			this.sqlDoClientsTransaction.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDoClientsTransaction.Connection = this.sqlConnection2;
			this.sqlDoClientsTransaction.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDoClientsTransaction.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "[xPaymOrderFromTransaction]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection2;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDAUListOrgs
			// 
			this.sqlDAUListOrgs.SelectCommand = this.sqlSelectCommand4;
			this.sqlDAUListOrgs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "UListOrgs", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																				  new System.Data.Common.DataColumnMapping("OrgName", "OrgName")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "[UListOrgs]";
			this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand4.Connection = this.sqlConnection2;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDAUListOrgsAccounts
			// 
			this.sqlDAUListOrgsAccounts.SelectCommand = this.sqlSelectCommand5;
			this.sqlDAUListOrgsAccounts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "OrgsAccounts", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							 new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																							 new System.Data.Common.DataColumnMapping("OrgID", "OrgID")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "[UListOrgsAccounts]";
			this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand5.Connection = this.sqlConnection2;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCancelTrans
			// 
			this.sqlCancelTrans.CommandText = "[xPaymOrderFromTransaction]";
			this.sqlCancelTrans.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCancelTrans.Connection = this.sqlConnection2;
			this.sqlCancelTrans.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCancelTrans.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSetDateCmd
			// 
			this.sqlSetDateCmd.CommandText = "[SetTransDate]";
			this.sqlSetDateCmd.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSetDateCmd.Connection = this.sqlConnection2;
			this.sqlSetDateCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSetDateCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SetPostedDate", System.Data.SqlDbType.Bit, 1));
			this.sqlSetDateCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PostedDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlSetDateCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SetCommitedDate", System.Data.SqlDbType.Bit, 1));
			this.sqlSetDateCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CommitedDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlSetDateCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// daRefresh
			// 
			this.daRefresh.SelectCommand = this.sqlCommand2;
			this.daRefresh.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "TransactionsSelectRefresh", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							 new System.Data.Common.DataColumnMapping("TransactionIsInner", "TransactionIsInner"),
																																																							 new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							 new System.Data.Common.DataColumnMapping("ClientIsInner", "ClientIsInner"),
																																																							 new System.Data.Common.DataColumnMapping("RAccountFrom", "RAccountFrom"),
																																																							 new System.Data.Common.DataColumnMapping("RAccountTo", "RAccountTo"),
																																																							 new System.Data.Common.DataColumnMapping("OrgNameFrom", "OrgNameFrom"),
																																																							 new System.Data.Common.DataColumnMapping("OrgIDFrom", "OrgIDFrom"),
																																																							 new System.Data.Common.DataColumnMapping("OrgIDTo", "OrgIDTo"),
																																																							 new System.Data.Common.DataColumnMapping("OrgNameTo", "OrgNameTo"),
																																																							 new System.Data.Common.DataColumnMapping("PaymentOrderStatusName", "PaymentOrderStatusName"),
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
																																																							 new System.Data.Common.DataColumnMapping("ServiceChargeTo", "ServiceChargeTo"),
																																																							 new System.Data.Common.DataColumnMapping("DocumentID", "DocumentID"),
																																																							 new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																							 new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																							 new System.Data.Common.DataColumnMapping("CreateDate", "CreateDate"),
																																																							 new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							 new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							 new System.Data.Common.DataColumnMapping("TransactionIDParent", "TransactionIDParent"),
																																																							 new System.Data.Common.DataColumnMapping("ClientRequestID", "ClientRequestID"),
																																																							 new System.Data.Common.DataColumnMapping("PaymentOrderStatusID", "PaymentOrderStatusID"),
																																																							 new System.Data.Common.DataColumnMapping("CurrencyFrom", "CurrencyFrom"),
																																																							 new System.Data.Common.DataColumnMapping("CurrencyTo", "CurrencyTo"),
																																																							 new System.Data.Common.DataColumnMapping("TrClientName", "TrClientName")})});
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "[TransactionsSelectRefresh]";
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection2;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 8));
			// 
			// tbTransCount
			// 
			this.tbTransCount.AllowDrop = true;
			this.tbTransCount.BackColor = System.Drawing.SystemColors.Control;
			this.tbTransCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbTransCount.dValue = 0;
			this.tbTransCount.IsPcnt = false;
			this.tbTransCount.Location = new System.Drawing.Point(934, 16);
			this.tbTransCount.MaxDecPos = 0;
			this.tbTransCount.MaxPos = 12;
			this.tbTransCount.Name = "tbTransCount";
			this.tbTransCount.Negative = System.Drawing.Color.Empty;
			this.tbTransCount.nValue = ((long)(0));
			this.tbTransCount.Positive = System.Drawing.Color.Empty;
			this.tbTransCount.ReadOnly = true;
			this.tbTransCount.Size = new System.Drawing.Size(86, 14);
			this.tbTransCount.TabIndex = 2;
			this.tbTransCount.Text = "";
			this.tbTransCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTransCount.TextMode = false;
			this.tbTransCount.Zero = System.Drawing.Color.Empty;
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.BackColor = System.Drawing.SystemColors.Control;
			this.tbSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbSum.dValue = 0;
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(934, 46);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 12;
			this.tbSum.Name = "tbSum";
			this.tbSum.Negative = System.Drawing.Color.Empty;
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Positive = System.Drawing.Color.Empty;
			this.tbSum.ReadOnly = true;
			this.tbSum.Size = new System.Drawing.Size(86, 14);
			this.tbSum.TabIndex = 1;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			this.tbSum.Zero = System.Drawing.Color.Empty;
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ColumnHeadersVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvTransSumList;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(862, 80);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsVisible = false;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.RowHeaderWidth = 15;
			this.dataGrid1.Size = new System.Drawing.Size(158, 70);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dvTransSumList
			// 
			this.dvTransSumList.Table = this.dsTransSumList1.TransSumList;
			// 
			// dsTransSumList1
			// 
			this.dsTransSumList1.DataSetName = "dsTransSumList";
			this.dsTransSumList1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.ColumnHeadersVisible = false;
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "TransSumList";
			this.dataGridTableStyle1.RowHeadersVisible = false;
			this.dataGridTableStyle1.RowHeaderWidth = 15;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn2.Format = "#,##0.00";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Сумма";
			this.dataGridTextBoxColumn2.MappingName = "Sum";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 110;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Валюта";
			this.dataGridTextBoxColumn1.MappingName = "CurrencyID";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// cPeriod
			// 
			this.cPeriod._cbDateFrom = true;
			this.cPeriod._cbDateFromUse = false;
			this.cPeriod._cbDateTill = true;
			this.cPeriod._cbDateTillUse = false;
			this.cPeriod._DateFrom = new System.DateTime(2004, 1, 26, 0, 0, 0, 0);
			this.cPeriod._DateTill = new System.DateTime(2004, 1, 26, 0, 0, 0, 0);
			this.cPeriod._PeriodType = AM_Controls.Span.Today;
			this.cPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cPeriod.Location = new System.Drawing.Point(7, 20);
			this.cPeriod.Modified = true;
			this.cPeriod.Name = "cPeriod";
			this.cPeriod.Size = new System.Drawing.Size(122, 48);
			this.cPeriod.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 18);
			this.label1.TabIndex = 23;
			this.label1.Text = "Клиент:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbClients
			// 
			this.cmbClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbClients.ItemHeight = 13;
			this.cmbClients.Location = new System.Drawing.Point(53, 26);
			this.cmbClients.MaxDropDownItems = 20;
			this.cmbClients.Name = "cmbClients";
			this.cmbClients.Size = new System.Drawing.Size(188, 21);
			this.cmbClients.TabIndex = 0;
			// 
			// cbCreated
			// 
			this.cbCreated.Checked = true;
			this.cbCreated.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCreated.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbCreated.Location = new System.Drawing.Point(44, 70);
			this.cbCreated.Name = "cbCreated";
			this.cbCreated.Size = new System.Drawing.Size(87, 16);
			this.cbCreated.TabIndex = 33;
			this.cbCreated.Text = "Создания";
			// 
			// cbFinished
			// 
			this.cbFinished.Checked = true;
			this.cbFinished.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbFinished.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbFinished.Location = new System.Drawing.Point(44, 102);
			this.cbFinished.Name = "cbFinished";
			this.cbFinished.Size = new System.Drawing.Size(87, 16);
			this.cbFinished.TabIndex = 33;
			this.cbFinished.Text = "Завершения";
			// 
			// cbStarted
			// 
			this.cbStarted.Checked = true;
			this.cbStarted.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbStarted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbStarted.Location = new System.Drawing.Point(44, 86);
			this.cbStarted.Name = "cbStarted";
			this.cbStarted.Size = new System.Drawing.Size(87, 16);
			this.cbStarted.TabIndex = 33;
			this.cbStarted.Text = "Начала";
			// 
			// cbPayerEQPayee
			// 
			this.cbPayerEQPayee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbPayerEQPayee.Location = new System.Drawing.Point(93, -2);
			this.cbPayerEQPayee.Name = "cbPayerEQPayee";
			this.cbPayerEQPayee.Size = new System.Drawing.Size(134, 21);
			this.cbPayerEQPayee.TabIndex = 32;
			this.cbPayerEQPayee.Text = "Уст. по Плательщику";
			this.cbPayerEQPayee.CheckedChanged += new System.EventHandler(this.cbPayerEQPayee_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 18);
			this.label2.TabIndex = 29;
			this.label2.Text = "Тип:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbType
			// 
			this.cmbType.DataSource = this.dvTransTypes;
			this.cmbType.DisplayMember = "TransactionTypeName";
			this.cmbType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbType.ItemHeight = 13;
			this.cmbType.Location = new System.Drawing.Point(53, 4);
			this.cmbType.MaxDropDownItems = 15;
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(188, 21);
			this.cmbType.TabIndex = 28;
			this.cmbType.ValueMember = "TransactionTypeID";
			// 
			// cbPosted
			// 
			this.cbPosted.Checked = true;
			this.cbPosted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.cbPosted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbPosted.Location = new System.Drawing.Point(28, 44);
			this.cbPosted.Name = "cbPosted";
			this.cbPosted.Size = new System.Drawing.Size(176, 16);
			this.cbPosted.TabIndex = 5;
			this.cbPosted.Text = "Проведена (установлен P)";
			this.cbPosted.ThreeState = true;
			// 
			// cbCommited
			// 
			this.cbCommited.Checked = true;
			this.cbCommited.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.cbCommited.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbCommited.Location = new System.Drawing.Point(28, 22);
			this.cbCommited.Name = "cbCommited";
			this.cbCommited.Size = new System.Drawing.Size(176, 18);
			this.cbCommited.TabIndex = 4;
			this.cbCommited.Text = "Выполнена (установлен С)";
			this.cbCommited.ThreeState = true;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(6, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 27;
			this.label4.Text = "Сравнение:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCompareOp
			// 
			this.cmbCompareOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompareOp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbCompareOp.ItemHeight = 13;
			this.cmbCompareOp.Items.AddRange(new object[] {
															  ">",
															  "<",
															  "="});
			this.cmbCompareOp.Location = new System.Drawing.Point(72, 20);
			this.cmbCompareOp.Name = "cmbCompareOp";
			this.cmbCompareOp.Size = new System.Drawing.Size(45, 21);
			this.cmbCompareOp.TabIndex = 1;
			// 
			// textBoxV1
			// 
			this.textBoxV1.AllowDrop = true;
			this.textBoxV1.dValue = 0;
			this.textBoxV1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxV1.IsPcnt = false;
			this.textBoxV1.Location = new System.Drawing.Point(55, 42);
			this.textBoxV1.MaxDecPos = 2;
			this.textBoxV1.MaxPos = 8;
			this.textBoxV1.Name = "textBoxV1";
			this.textBoxV1.Negative = System.Drawing.Color.Empty;
			this.textBoxV1.nValue = ((long)(0));
			this.textBoxV1.Positive = System.Drawing.Color.Empty;
			this.textBoxV1.Size = new System.Drawing.Size(90, 21);
			this.textBoxV1.TabIndex = 2;
			this.textBoxV1.Text = "";
			this.textBoxV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV1.TextMode = false;
			this.textBoxV1.Zero = System.Drawing.Color.Empty;
			// 
			// sqlCheckOrgAccountSaldo
			// 
			this.sqlCheckOrgAccountSaldo.CommandText = "[xCheckOrgAccountSaldo]";
			this.sqlCheckOrgAccountSaldo.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckOrgAccountSaldo.Connection = this.sqlConnection2;
			this.sqlCheckOrgAccountSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckOrgAccountSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckOrgAccountSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCheckClientSaldo
			// 
			this.sqlCheckClientSaldo.CommandText = "[xCheckClientSaldo]";
			this.sqlCheckClientSaldo.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckClientSaldo.Connection = this.sqlConnection2;
			this.sqlCheckClientSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckClientSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCheckCash
			// 
			this.sqlCheckCash.CommandText = "[xCheckCash]";
			this.sqlCheckCash.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckCash.Connection = this.sqlConnection2;
			this.sqlCheckCash.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckCash.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckCash.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckCash.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCheckClientSaldoFinal
			// 
			this.sqlCheckClientSaldoFinal.CommandText = "[xCheckClientSaldoFinal]";
			this.sqlCheckClientSaldoFinal.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckClientSaldoFinal.Connection = this.sqlConnection2;
			this.sqlCheckClientSaldoFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldoFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckClientSaldoFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldoFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCheckCashFinal
			// 
			this.sqlCheckCashFinal.CommandText = "[xCheckCashFinal]";
			this.sqlCheckCashFinal.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckCashFinal.Connection = this.sqlConnection2;
			this.sqlCheckCashFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckCashFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckCashFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckCashFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// MenuItemImageProvider1
			// 
			this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
			// 
			// menuItem16
			// 
			this.menuItem16.Index = -1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem16, null);
			this.menuItem16.OwnerDraw = true;
			this.menuItem16.Text = "";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = -1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem3, null);
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "a";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = -1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem5, null);
			this.menuItem5.OwnerDraw = true;
			this.menuItem5.Text = "b";
			// 
			// sqlCheckClientSaldoIndirect
			// 
			this.sqlCheckClientSaldoIndirect.CommandText = "[xCheckClientSaldoIndirect]";
			this.sqlCheckClientSaldoIndirect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckClientSaldoIndirect.Connection = this.sqlConnection2;
			this.sqlCheckClientSaldoIndirect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldoIndirect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckClientSaldoIndirect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldoIndirect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCheckClientSaldoIndirectFinal
			// 
			this.sqlCheckClientSaldoIndirectFinal.CommandText = "[xCheckClientSaldoIndirectFinal]";
			this.sqlCheckClientSaldoIndirectFinal.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckClientSaldoIndirectFinal.Connection = this.sqlConnection2;
			this.sqlCheckClientSaldoIndirectFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldoIndirectFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckClientSaldoIndirectFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckClientSaldoIndirectFinal.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCheckLoanSum
			// 
			this.sqlCheckLoanSum.CommandText = "[xCheckLoanSum]";
			this.sqlCheckLoanSum.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckLoanSum.Connection = this.sqlConnection2;
			this.sqlCheckLoanSum.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckLoanSum.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int, 4));
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.grpStatus);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cmbClients);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cmbType);
			this.panel1.Controls.Add(this.tbTransCount);
			this.panel1.Controls.Add(this.tbSum);
			this.panel1.Controls.Add(this.dataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1040, 156);
			this.panel1.TabIndex = 7;
			// 
			// grpStatus
			// 
			this.grpStatus.Controls.Add(this.cbPosted);
			this.grpStatus.Controls.Add(this.cbCommited);
			this.grpStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpStatus.Location = new System.Drawing.Point(5, 51);
			this.grpStatus.Name = "grpStatus";
			this.grpStatus.Size = new System.Drawing.Size(243, 95);
			this.grpStatus.TabIndex = 34;
			this.grpStatus.TabStop = false;
			this.grpStatus.Text = "Состояние";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbAnyCurrency);
			this.groupBox4.Controls.Add(this.cmbCompareCurrency);
			this.groupBox4.Controls.Add(this.btnSumClear);
			this.groupBox4.Controls.Add(this.textBoxV1);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.cmbCompareOp);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(615, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(174, 142);
			this.groupBox4.TabIndex = 42;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Сумма транзакции";
			// 
			// cbAnyCurrency
			// 
			this.cbAnyCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbAnyCurrency.Location = new System.Drawing.Point(101, 64);
			this.cbAnyCurrency.Name = "cbAnyCurrency";
			this.cbAnyCurrency.Size = new System.Drawing.Size(66, 24);
			this.cbAnyCurrency.TabIndex = 43;
			this.cbAnyCurrency.Text = "Любая";
			// 
			// cmbCompareCurrency
			// 
			this.cmbCompareCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompareCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbCompareCurrency.Location = new System.Drawing.Point(55, 64);
			this.cmbCompareCurrency.Name = "cmbCompareCurrency";
			this.cmbCompareCurrency.Size = new System.Drawing.Size(45, 21);
			this.cmbCompareCurrency.TabIndex = 42;
			this.cmbCompareCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCompareCurrency_SelectedIndexChanged);
			// 
			// btnSumClear
			// 
			this.btnSumClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSumClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnSumClear.ForeColor = System.Drawing.Color.RosyBrown;
			this.btnSumClear.Location = new System.Drawing.Point(147, 42);
			this.btnSumClear.Name = "btnSumClear";
			this.btnSumClear.Size = new System.Drawing.Size(21, 21);
			this.btnSumClear.TabIndex = 41;
			this.btnSumClear.Text = "●";
			this.btnSumClear.Click += new System.EventHandler(this.btnSumClear_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(6, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 27;
			this.label5.Text = "Валюта:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(6, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 27;
			this.label6.Text = "Сумма:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cPeriod);
			this.groupBox3.Controls.Add(this.cbCreated);
			this.groupBox3.Controls.Add(this.cbFinished);
			this.groupBox3.Controls.Add(this.cbStarted);
			this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(481, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(136, 142);
			this.groupBox3.TabIndex = 37;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Фильтр по Дате";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(794, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 14);
			this.label9.TabIndex = 40;
			this.label9.Text = "Суммы по валютам:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(794, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(136, 28);
			this.label7.TabIndex = 39;
			this.label7.Text = "Общая Сумма по фильтру (в баз. валюте):";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(794, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 28);
			this.label3.TabIndex = 38;
			this.label3.Text = "Отобрано транзакций по фильтру:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.grpPayee);
			this.groupBox2.Controls.Add(this.cbPayerEQPayee);
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(246, 74);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(237, 72);
			this.groupBox2.TabIndex = 36;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Получатель";
			// 
			// grpPayee
			// 
			this.grpPayee.Location = new System.Drawing.Point(5, 15);
			this.grpPayee.Name = "grpPayee";
			this.grpPayee.OrgAccountID = 0;
			this.grpPayee.OrgID = 0;
			this.grpPayee.Size = new System.Drawing.Size(228, 53);
			this.grpPayee.TabIndex = 33;
			this.grpPayee.OrgsAcoountIDChanged += new BPS._Controls.OrgsAndAccounts.OrgsAcoountIDChangedEventHandler(this.grpPayee_OrgsAcoountIDChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.grpPayer);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(246, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(237, 78);
			this.groupBox1.TabIndex = 35;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Плательщик";
			// 
			// grpPayer
			// 
			this.grpPayer.Location = new System.Drawing.Point(5, 15);
			this.grpPayer.Name = "grpPayer";
			this.grpPayer.OrgAccountID = 0;
			this.grpPayer.OrgID = 0;
			this.grpPayer.Size = new System.Drawing.Size(228, 61);
			this.grpPayer.TabIndex = 0;
			this.grpPayer.OrgsAcoountIDChanged += new BPS._Controls.OrgsAndAccounts.OrgsAcoountIDChangedEventHandler(this.grpPayer_OrgsAcoountIDChanged);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 184);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1040, 3);
			this.splitter1.TabIndex = 8;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 187);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1040, 428);
			this.panel2.TabIndex = 9;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.dataGridV1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 4);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(1040, 368);
			this.panel5.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.tbPaymOrderNo);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.tbPaymOrderStatus);
			this.panel4.Controls.Add(this.tbPaymOrderHeaderStatus);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Controls.Add(this.tbPaymOrderHeaderID);
			this.panel4.Controls.Add(this.label11);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Controls.Add(this.label13);
			this.panel4.Controls.Add(this.label14);
			this.panel4.Controls.Add(this.tbPaymOrderDate);
			this.panel4.Controls.Add(this.tbPaymOrderHeaderDate);
			this.panel4.Controls.Add(this.tbPaymOrderRem);
			this.panel4.Controls.Add(this.label15);
			this.panel4.Controls.Add(this.label16);
			this.panel4.Controls.Add(this.tbPaymOrderText);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 372);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1040, 56);
			this.panel4.TabIndex = 1;
			// 
			// tbPaymOrderNo
			// 
			this.tbPaymOrderNo.Location = new System.Drawing.Point(234, 4);
			this.tbPaymOrderNo.Name = "tbPaymOrderNo";
			this.tbPaymOrderNo.ReadOnly = true;
			this.tbPaymOrderNo.TabIndex = 2;
			this.tbPaymOrderNo.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(4, 4);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 21);
			this.label8.TabIndex = 1;
			this.label8.Text = "Плат. Поручение:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPaymOrderStatus
			// 
			this.tbPaymOrderStatus.Location = new System.Drawing.Point(106, 4);
			this.tbPaymOrderStatus.Name = "tbPaymOrderStatus";
			this.tbPaymOrderStatus.ReadOnly = true;
			this.tbPaymOrderStatus.TabIndex = 0;
			this.tbPaymOrderStatus.Text = "";
			// 
			// tbPaymOrderHeaderStatus
			// 
			this.tbPaymOrderHeaderStatus.Location = new System.Drawing.Point(106, 28);
			this.tbPaymOrderHeaderStatus.Name = "tbPaymOrderHeaderStatus";
			this.tbPaymOrderHeaderStatus.ReadOnly = true;
			this.tbPaymOrderHeaderStatus.TabIndex = 0;
			this.tbPaymOrderHeaderStatus.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(4, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 21);
			this.label10.TabIndex = 1;
			this.label10.Text = "Выписка:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPaymOrderHeaderID
			// 
			this.tbPaymOrderHeaderID.Location = new System.Drawing.Point(234, 28);
			this.tbPaymOrderHeaderID.Name = "tbPaymOrderHeaderID";
			this.tbPaymOrderHeaderID.ReadOnly = true;
			this.tbPaymOrderHeaderID.TabIndex = 2;
			this.tbPaymOrderHeaderID.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(210, 4);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(22, 21);
			this.label11.TabIndex = 1;
			this.label11.Text = "№:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(336, 4);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(21, 21);
			this.label12.TabIndex = 1;
			this.label12.Text = "от:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(210, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(22, 21);
			this.label13.TabIndex = 1;
			this.label13.Text = "ID:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(336, 28);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 21);
			this.label14.TabIndex = 1;
			this.label14.Text = "от:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPaymOrderDate
			// 
			this.tbPaymOrderDate.Location = new System.Drawing.Point(358, 4);
			this.tbPaymOrderDate.Name = "tbPaymOrderDate";
			this.tbPaymOrderDate.ReadOnly = true;
			this.tbPaymOrderDate.TabIndex = 2;
			this.tbPaymOrderDate.Text = "";
			// 
			// tbPaymOrderHeaderDate
			// 
			this.tbPaymOrderHeaderDate.Location = new System.Drawing.Point(358, 28);
			this.tbPaymOrderHeaderDate.Name = "tbPaymOrderHeaderDate";
			this.tbPaymOrderHeaderDate.ReadOnly = true;
			this.tbPaymOrderHeaderDate.TabIndex = 2;
			this.tbPaymOrderHeaderDate.Text = "";
			// 
			// tbPaymOrderRem
			// 
			this.tbPaymOrderRem.Location = new System.Drawing.Point(504, 28);
			this.tbPaymOrderRem.Name = "tbPaymOrderRem";
			this.tbPaymOrderRem.ReadOnly = true;
			this.tbPaymOrderRem.Size = new System.Drawing.Size(532, 21);
			this.tbPaymOrderRem.TabIndex = 2;
			this.tbPaymOrderRem.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(462, 4);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 21);
			this.label15.TabIndex = 1;
			this.label15.Text = "Осн.:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(462, 28);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 21);
			this.label16.TabIndex = 1;
			this.label16.Text = "Прим.:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPaymOrderText
			// 
			this.tbPaymOrderText.Location = new System.Drawing.Point(504, 4);
			this.tbPaymOrderText.Name = "tbPaymOrderText";
			this.tbPaymOrderText.ReadOnly = true;
			this.tbPaymOrderText.Size = new System.Drawing.Size(532, 21);
			this.tbPaymOrderText.TabIndex = 2;
			this.tbPaymOrderText.Text = "";
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1040, 4);
			this.panel3.TabIndex = 0;
			// 
			// sqlCmdPaymOrderGetInfo
			// 
			this.sqlCmdPaymOrderGetInfo.CommandText = "[PaymentOrdersGetInfo]";
			this.sqlCmdPaymOrderGetInfo.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdPaymOrderGetInfo.Connection = this.sqlConnection3;
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InfoMode", System.Data.SqlDbType.Int, 4));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EntityID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POASID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PONStatus", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POTStatus", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PONo", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PODate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POText", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PORem", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POBDir", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POTDir", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POHeaderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POHeaderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POHeaderBStatus", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdPaymOrderGetInfo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@POHeaderTStatus", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection3
			// 
			this.sqlConnection3.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// TransactionsList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(1040, 615);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "TransactionsList";
			this.Text = "Транзакции";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.TransactionsList_Closing);
			this.Load += new System.EventHandler(this.TransactionsOut_Load);
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsPayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUListOrgs1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransactionList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsAccsPayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUListOrgsAccounts1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsAccsPayee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUListOrgsPayee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransSumList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTransSumList1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.grpStatus.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvFilterSumCurrency)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbApply)
				this.FilterApply();
			else if (e.Button == this.tbbClear)
				this.FilterClear();
			else if (e.Button == this.tbbNew)
				TransAdd();
			else if (e.Button == this.tbbEdit)
				TransEdit();
			else if (e.Button == this.tbbDel)
				TransDelete();					
			else if (e.Button == this.tbbExec)
				TransExec();
			else if (e.Button == this.tbbConfirm)
				TransConfirm();
		
		}
		
		private void updateTransactionsTable()
		{
			try
			{
				this.daUpdTrans.Update(this.dsTransactionList1.Transactions);
				//???????				this.fillDs();
				this.RefreshDs();

				//				this.dsTransactionList1.TransactionsList.AcceptChanges();
			}
			catch(Exception ex)
			{
				//				this.dsTransactionList1.TransactionsList.RejectChanges();
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		private void TransAdd()
		{
			if (!App.AllowTransactionsEdit) return;

			BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rw = (BLL.Transactions.DataSets.dsTransactionList.TransactionsRow) this.dvTransList.Table.NewRow();
		
			rw.TransactionCommited = false;
			rw.TransactionPosted = false;
			rw.TransactionIsInner = false;
			rw.ClientIsInner = false;

			TransactionBN_Edit nt = new BPS._Forms.TransactionBN_Edit(false, null, this.dsTransactionList1);
			nt.ShowDialog();
			if(nt.DialogResult == DialogResult.OK)
			{
				//				this.dvTransList.Table.Rows.Add((DataRow) rw);
				this.updateTransactionsTable();
				this.dataGridV1.UnSelect(this.BindingContext[this.dvTransList].Position);
				this.rwCurrentRow = rw;
				int i=rw.TransactionID;
//				this.SelectLastInsertedRow(rw.TransactionID);
				this.RefreshDs();
				this.SelectLastInsertedRow(i);
			}
		}

		private void TransEdit()
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if ( !(this.dvTransList.Count>0 && this.rwCurrentRow!=null)) return;
			if (!App.AllowTransactionsEdit) return;
			
			if (this.rwCurrentRow.TransactionTypeID==14) 
			{
				Trans14Msg();
				return;
			}

			if(!LockTrans())
				return;
			try 
			{
				if ( this.rwCurrentRow.TransactionTypeID ==1 || this.rwCurrentRow.TransactionTypeID ==2) 
				{
					MessageBox.Show("Действие отменено: Транзакции данного типа редактировать запрещено.", "BPS",MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
					return;
				}
				TransactionBN_Edit nt = new BPS._Forms.TransactionBN_Edit(true, this.rwCurrentRow, this.dsTransactionList1);
				nt.ShowDialog();
				
				if (nt.DialogResult == DialogResult.OK)
					this.updateTransactionsTable();
				this.dataGridV1.Select(bmList.Position);

			}
			finally
			{
				UnlockTrans();
			}
		}
		
		private void TransDelete()
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if ( !(this.dvTransList.Count>0))	return; 
			if (!App.AllowTransactionsEdit)		return;

			if (rwCurrentRow.TransactionTypeID ==  14 ) 
			{
				Trans14Msg();
				return;
			}
			if(!LockTrans())
				return;
			try 
			{
			if( (!this.rwCurrentRow.TransactionCommited && !this.rwCurrentRow.TransactionPosted) ||
				this.rwCurrentRow.TransactionTypeID == 10 || this.rwCurrentRow.TransactionTypeID == 1
				)
			{
				if(AM_Controls.MsgBoxX.Show("Вы действительно хотите удалить транзакцию №" + rwCurrentRow.TransactionID.ToString(), "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)!=DialogResult.Yes)
					return;
				if ( (this.rwCurrentRow.TransactionTypeID == 10 ||this.rwCurrentRow.TransactionTypeID == 1) &&
					AM_Controls.MsgBoxX.Show("Будут удалены соответствующие платежное поручение и строка выписки?" + rwCurrentRow.TransactionID.ToString(), "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)!=DialogResult.Yes) 
					return;
				((DataRowView)bmList.Current).Delete();
				this.updateTransactionsTable();
			}
			else
				AM_Controls.MsgBoxX.Show("Невозможно удалить выполняющуюся или выполненную транзакцию." );
			}
			finally
			{
				UnlockTrans();
			}
	}

		private void fillDs()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				this.dsTransactionList1.Transactions.Clear();
				this.daSelTrans.SelectCommand.Parameters["@UseCreateDate"].Value = this.cbCreated.Checked;
				this.daSelTrans.SelectCommand.Parameters["@UseStartDate"].Value = this.cbStarted.Checked;
				this.daSelTrans.SelectCommand.Parameters["@UseFinishDate"].Value = this.cbFinished.Checked;
				this.daSelTrans.SelectCommand.Parameters["@DateFrom"].Value = this.cPeriod._DateFrom.Date;
				this.daSelTrans.SelectCommand.Parameters["@DateTill"].Value = this.cPeriod._DateTill.Date.AddDays(1);
				this.daSelTrans.Fill(this.dsTransactionList1.Transactions);
				if (bmList.Count>0)
					bmList.Position = bmList.Count-1;
				Cursor.Current = Cursors.Default;
			}
			catch(Exception ex)
			{
				Cursor.Current = Cursors.Default;
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			if(dvTransList.RowFilter == "")
			{
				if(!ShowCreditTransactions)
				{
					dvTransList.RowFilter = "NOT(TransactionTypeID > 18 AND TransactionTypeID < 33)";
				}
			}
		}
		/*
				private void updateDs()
				{
					try
					{
						//this.sqlDataAdapter1.Update(this.dsTransOutPayms1.TransOutPayms);
					}
					catch(Exception ex)
					{
						AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						//this.dsTransOutPayms1.TransOutPayms.RejectChanges();
					}
				}


				*/

		/*
				private void acceptedTrans()
				{
				}
		*/
		#region Filter
		private void btnFilterSet_Click(object sender, System.EventArgs e)
		{
			FilterApply();
		}

		private void FilterApply()
		{
			AM_Lib.FilterBuilder Filter = new AM_Lib.FilterBuilder ();

			if ( this.cmbClients.SelectedIndex > 0)
			{
				Filter.Append("ClientName LIKE '" + this.cmbClients.Text + "*'");
			}
			if ( this.cmbType.SelectedIndex >0) 
			{
				Filter.Append("[TransactionTypeID] =" ,(int)this.cmbType.SelectedValue);
			}			
			if (this.cmbCompareOp.SelectedIndex > -1 && this.textBoxV1.dValue >0)
			{
				System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
				nfi.NumberDecimalSeparator = ".";
				
				Filter.Append("SumFrom" + this.cmbCompareOp.Text +this.textBoxV1.dValue.ToString( nfi));
				if ( !this.cbAnyCurrency.Checked && this.cmbCompareCurrency.Text.Length >0) 
				{
					Filter.Append("((CurrencyFrom ='" +this.cmbCompareCurrency.Text +"') OR (CurrencyTo ='" +this.cmbCompareCurrency.Text +"'))");
				}
			}
			if (this.cbPosted.CheckState != CheckState.Indeterminate)
			{
				Filter.Append( "TransactionPosted=" , this.cbPosted.Checked);
			}
			if (this.cbCommited.CheckState != CheckState.Indeterminate)
			{
				Filter.Append("TransactionCommited=", this.cbCommited.Checked);
			}
	
			AM_Lib.FilterBuilder FilterPayer = new AM_Lib.FilterBuilder ();
			if (( this.grpPayer.OrgID >0 ) || ( this.grpPayer.OrgAccountID >0)) 
			{
				if ( this.grpPayer.OrgID >0 )
					FilterPayer.Append("[OrgIDFrom] =", (int)this.grpPayer.OrgID); 
				if ( this.grpPayer.OrgAccountID >0) 
					FilterPayer.Append("[RAccountFrom] ='" +this.grpPayer.OrgAccountName +"'");  
			}

			AM_Lib.FilterBuilder FilterPayee = new AM_Lib.FilterBuilder ();
			if (( this.grpPayee.OrgID >0 ) || ( this.grpPayee.OrgAccountID >0)) 
			{					
				if ( this.grpPayee.OrgID >0 )
					FilterPayee.Append("[OrgIDTo] =" , (int)this.grpPayee.OrgID);
				if ( this.grpPayee.OrgAccountID >0) 
					FilterPayee.Append("[RAccountTo] ='" +this.grpPayee.OrgAccountName  +"'");
			}
			if ( this.cbPayerEQPayee.Checked)  
			{
				Filter.Append( "("+ FilterPayer.Text+ " OR " + FilterPayee.Text + ")" );
			}
			else 
			{
				if (FilterPayer.Text.Length>0)
					Filter.Append( FilterPayer.Text );
				if (FilterPayee.Text.Length>0)
					Filter.Append( FilterPayee.Text );
			}
			if(!ShowCreditTransactions)
			{
				Filter.Append("NOT(TransactionTypeID > 18 AND TransactionTypeID < 33)");
			}

			AM_Lib.FilterBuilder DateFilter1 = new AM_Lib.FilterBuilder ();
			AM_Lib.FilterBuilder DateFilter2 = new AM_Lib.FilterBuilder ();
			
			DateTime dtTill = this.cPeriod._DateTill.Date.AddDays(1);
			if (this.cbFinished.Checked) 
			{
				DateFilter1.Append("CompleteDate >= " , this.cPeriod._DateFrom.Date);
				DateFilter1.Append("CompleteDate < " , dtTill);
			}

			string sFD="";
			if (this.cbStarted.Checked) 
			{
				DateFilter2.Append("InitDate >= " , this.cPeriod._DateFrom.Date);
				DateFilter2.Append("InitDate < " , dtTill);
				if (DateFilter1.Text.Length>0) 
				{
					sFD = DateFilter1.Text + " OR ";
				}
				sFD += DateFilter2.Text;
			}

			if (sFD.Length>0) 
			{
				string sF = "(("+sFD+") OR (CompleteDate IS NULL OR InitDate IS NULL))";
				Filter.Append( sF );
			}

			this.fillDs();
			this.dvTransList.RowFilter = Filter.Text;
		}

		private void FilterClear()
		{
			this.cmbClients.SelectedIndex	= 0;
			this.cbPosted.CheckState		= CheckState.Indeterminate;
			this.cbCommited.CheckState		= CheckState.Indeterminate;
			this.cmbCompareOp.SelectedIndex = 0;
			this.textBoxV1.Text				= "";
			this.cPeriod._PeriodType		= AM_Controls.Span.Today;
			this.cPeriod._DateFrom			= this.cPeriod._DateFrom.AddDays(-1);
			
			if (this.cmbType.SelectedIndex !=0) this.cmbType.SelectedIndex	=0; 
			
			this.grpPayer.OrgID			=0;
			this.grpPayer.OrgAccountID	=0;
			
			this.cbPayerEQPayee.Checked =false; 
			
			this.grpPayee.OrgID			=0;
			this.grpPayee.OrgAccountID	=0;
		}


		#endregion

		private void TransactionsOut_Load(object sender, System.EventArgs e)
		{
			bIsLoaded = true;
			this.setPermissions();
			//			App.Clone(this.menuEdit.MenuItems, this.contextMenu1);
			App.Clone(this.contextMenu1.MenuItems, this.menuEdit);
			this.getTransSum();
		}

		private void setPermissions()
		{
			this.tbbNew.Enabled = this.tbbEdit.Enabled = this.tbbDel.Enabled 
				= this.mnuCopy.Enabled = this.mnuNew.Enabled = this.mnuEdit.Enabled 
				= this.mnuDel.Enabled = App.AllowTransactionsEdit;
			this.tbbExec.Enabled = this.mnuExec.Enabled = this.mnuConfirm.Enabled 
				= this.mnuCancelExec.Enabled = App.AllowTransactionsExecute;
		}

		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			TransAdd();
		}

		private void mnuEdit_Click(object sender, System.EventArgs e)
		{
			TransEdit();
		}

		private void mnuDel_Click(object sender, System.EventArgs e)
		{
			TransDelete();
		}

		private void mnuExec_Click(object sender, System.EventArgs e)
		{
			TransExec();
		}

		private bool LockTrans()
		{
			return App.LockStatusChange(1, rwCurrentRow.TransactionID, true);
		}

		private bool UnlockTrans()
		{
			return App.LockStatusChange(1, rwCurrentRow.TransactionID, false);
		}

		private bool MakePaymOrder()
		{
			return CheckClientSaldo() &&
				MakePaymOrder2();
		}

		private bool MakePaymOrder2()
		{
			sqlCheckOrgAccountSaldo.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			if (!AM_Lib.sqlData.ExecuteNonQuery(sqlCheckOrgAccountSaldo) )	// Ошибка исполнения команды
				return false;
			if ( (int)sqlCheckOrgAccountSaldo.Parameters["@RETURN_VALUE"].Value == 0) 
			{
				double dRemainder= (double)sqlCheckOrgAccountSaldo.Parameters["@Remainder"].Value;
				if ( AM_Controls.MsgBoxX.Show("Недостаточно средств на расчетном счете.\n Не хватает " + dRemainder.ToString("0.00 руб..\n") +
					"Продолжить создание платежного поручения?",
					"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return false;
			}

			sqlMakePOForTrans.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			return AM_Lib.sqlData.ExecuteNonQuery(sqlMakePOForTrans);
		}

		private bool  DoClientsTransaction()
		{
			this.sqlDoClientsTransaction.Parameters["@TransactionID"].Value=rwCurrentRow.TransactionID;
			if (AM_Lib.sqlData.ExecuteNonQuery(sqlDoClientsTransaction)) 
			{
				this.RefreshDs();
				return true;
			}
			return false;
		}

		private bool ChangeTransStatus(bool bCommited, bool bPosted)
		{
			this.sqlChangeTransactionStatus.Parameters["@nTransactionID"].Value=rwCurrentRow.TransactionID;
			this.sqlChangeTransactionStatus.Parameters["@bCommiting"].Value=bCommited;
			this.sqlChangeTransactionStatus.Parameters["@bPosting"].Value=bPosted;
			if (AM_Lib.sqlData.ExecuteNonQuery(sqlChangeTransactionStatus)) 
			{
				this.RefreshDs();
				return true;
			}
			return false;
		}

		private bool CheckClientSaldoFinal()
		{
			sqlCheckClientSaldoFinal.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			return AM_Lib.sqlData.ExecuteNonQuery(sqlCheckClientSaldoFinal);
		}
		private bool CheckLoanSum()
		{
			sqlCheckLoanSum.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			return AM_Lib.sqlData.ExecuteNonQuery(sqlCheckLoanSum);
		}
		private bool CheckClientSaldoIndirectFinal()
		{
			sqlCheckClientSaldoIndirectFinal.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			return AM_Lib.sqlData.ExecuteNonQuery(sqlCheckClientSaldoIndirectFinal);
		}

		private bool CheckClientSaldo()
		{
			sqlCheckClientSaldo.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			if (AM_Lib.sqlData.ExecuteNonQuery(sqlCheckClientSaldo)) 
			{
				if ( (int)sqlCheckClientSaldo.Parameters["@RETURN_VALUE"].Value == 0) 
				{
					double dRemainder= (double)sqlCheckClientSaldo.Parameters["@Remainder"].Value;
					string sCurrency = sqlCheckClientSaldo.Parameters["@CurrencyID"].Value.ToString();
					if ( this.rwCurrentRow.TransactionTypeID ==33) 
					{
						if ( AM_Controls.MsgBoxX.Show("Недостаточно средств на внешнем лицевом счете.\nНе хватает " + dRemainder.ToString("0.00") + " "+ sCurrency + "\n"+
							"Продолжить выполнение операции?",
							"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
						{
							return false;
						}
					}
					else 
					{
						if ( AM_Controls.MsgBoxX.Show("Недостаточно средств на лицевом счете.\nНе хватает " + dRemainder.ToString("0.00") + " "+ sCurrency + "\n"+
							"Продолжить выполнение операции?",
							"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
						{
							return false;
						}
					}
				}
				return true;	
			}
			return false;
		}

/// <summary>
/// Проверка лицевого счета клиента для транзакции "Клиенту из разв"
/// </summary>
/// <returns></returns>
		private bool CheckClientSaldoIndirect()
		{
			sqlCheckClientSaldoIndirect.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			if (AM_Lib.sqlData.ExecuteNonQuery(sqlCheckClientSaldoIndirect)) 
			{
				if ( (int)sqlCheckClientSaldoIndirect.Parameters["@RETURN_VALUE"].Value == 0) 
				{
					double dRemainder= (double)sqlCheckClientSaldoIndirect.Parameters["@Remainder"].Value;
					string sCurrency = sqlCheckClientSaldoIndirect.Parameters["@CurrencyID"].Value.ToString();
					if ( AM_Controls.MsgBoxX.Show("Недостаточно средств на лицевом счете клиента.\nНе хватает " + dRemainder.ToString("0.00") + " "+ sCurrency + "\n"+
						"Продолжить выполнение операции?",
						"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
					{
						return false;
					}
				}
				return true;	
			}
			return false;
		}


		private bool CheckCashFinal()
		{
			sqlCheckCashFinal.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			return AM_Lib.sqlData.ExecuteNonQuery(sqlCheckCashFinal);
		}

		private bool CheckCash()
		{
			sqlCheckCash.Parameters["@TransactionID"].Value = this.rwCurrentRow.TransactionID;	
			if (AM_Lib.sqlData.ExecuteNonQuery(sqlCheckCash)) 
			{
				if ( (int)sqlCheckCash.Parameters["@RETURN_VALUE"].Value == 0) 
				{
					double dRemainder= (double)sqlCheckCash.Parameters["@Remainder"].Value;
					string sCurrency = sqlCheckCash.Parameters["@CurrencyID"].Value.ToString();
					if ( AM_Controls.MsgBoxX.Show("Недостаточно средств в кассе.\nНе хватает " + dRemainder.ToString("0.00") + " "+ sCurrency + "\n"+
						"Продолжить выполнение операции?",
						"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
					{
						return false;
					}
				}
				return true;	
			}
			return false;

		}

		private void TransConfirm()
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if(!App.AllowTransactionsExecute)
				return;
			if (!rwCurrentRow.TransactionCommited && !rwCurrentRow.TransactionPosted) 
			{
				if ( !TransExec() )
					return;
			}
			if ( 
				rwCurrentRow.TransactionTypeID ==   3 || // НАЛ от Клиента
				rwCurrentRow.TransactionTypeID ==   4 || // НАЛ Клиенту
				rwCurrentRow.TransactionTypeID ==   5 || // Конвертация Клиенту
				rwCurrentRow.TransactionTypeID ==   8 || // НАЛ из Развития
				rwCurrentRow.TransactionTypeID ==   9 || // Конвертация Кассы
				rwCurrentRow.TransactionTypeID ==  12 || // НАЛ Доход
				rwCurrentRow.TransactionTypeID ==  13 || // НАЛ Расход
				rwCurrentRow.TransactionTypeID ==  16 ||
				rwCurrentRow.TransactionTypeID ==  17 ||
				rwCurrentRow.TransactionTypeID ==  18 ||
				rwCurrentRow.TransactionTypeID ==  33    // Клиенту из разв
				)   // Взаимозачёт
			{
					
				if (!LockTrans()) 
					return;
				try 
				{
					switch (this.rwCurrentRow.TransactionTypeID	) 
					{
						case  4:	// Выплата Кл
						case  5:	// Конвертация клиенту
						case  9:	// Конвертация Кассы
						case 13:	// НАЛ расход
							if (CheckClientSaldoFinal() &&
								CheckCashFinal())
								ChangeTransStatus( true, true);
							break;

						case  8:	// Нал из развития
						case 16:	// Взаимозачёт
							if ( CheckClientSaldoFinal())
								ChangeTransStatus( true, true);
							break;
						case 18:	// Ссуда (Кредит) возврат
							if ( CheckLoanSum() && CheckClientSaldoFinal() )
								ChangeTransStatus( true, true);
							break;
						case 33:	// 
							if ( CheckClientSaldoIndirectFinal() && 
								CheckClientSaldoFinal())
								ChangeTransStatus( true, true);
							break;

						default:
							ChangeTransStatus( true, true);
							break;
					}
					return ;
				}
				finally
				{
					UnlockTrans();
				}
			}
			else if ( rwCurrentRow.TransactionTypeID == 11 && rwCurrentRow.TransactionCommited && !rwCurrentRow.TransactionPosted) // БН расход 
			{
				if (LockTrans())
					ChangeTransStatus(true, true);	
				UnlockTrans();
			}
			else if (rwCurrentRow.TransactionTypeID != 17 && rwCurrentRow.TransactionTypeID != 18)
			{
				MessageBox.Show("Операция неприменима к транзакции данного типа", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
			}
		}
			
		private bool TransExec()
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return false;
			}
			if(!App.AllowTransactionsExecute) 
			{
				MessageBox.Show("Действие отменено: Недостаточный уровень доступа.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return false;
			}
			if (rwCurrentRow.TransactionCommited || rwCurrentRow.TransactionPosted) 
			{
				MessageBox.Show("Действие отменено: Транзакция уже выполнена или выполняется", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return  false;
			}

			if (!LockTrans()) 
				return false;
			try 
			{
				switch (this.rwCurrentRow.TransactionTypeID	) 
				{
					case  14: // Перемещение прием
						Trans14Msg();
						return false;

					case  2: // Отправка БН Клиента
					case  6: // Перемещение отправка
					case  7: // БН на развитие
					case 11: // БН расход
						if ( !MakePaymOrder()) 
							return false;
					{	// Проверить сальдо клиента и сальдо р.счета
						this.RefreshDs();

					}
						break;

					case  4:	// Выплата Кл			//Mike 09.06.03
					case 13:	// НАЛ расход			//Mike 25.07.03
						return (
							CheckClientSaldo() && 
							CheckCash() && 
							ChangeTransStatus( false, true));
						break;

					case  8:	// Нал из развития		//Mike 25.07.03
						return ( CheckClientSaldo() &&
							ChangeTransStatus( false, true));
						break;

					case  3:	// Нал от клиента		//Mike 25.07.03
					case 12:	// НАЛ доход			//Mike 25.07.03
					case 16:	// Взамозачёт Кл		//Mike 25.07.03
						return ChangeTransStatus( false, true);
						break;
					
					case  5:	// Конвертация клиенту
					case  9:	// Конвертация Кассы
						return ( CheckClientSaldo() && CheckCash() &&
							ChangeTransStatus( false, true) ); 
						break;

					case 17:	// Ссуда (Кредит) выдача
						return ChangeTransStatus( false, true);
						break;
					case 18:	// Ссуда (Кредит) возврат
						return ( CheckLoanSum() && CheckClientSaldo() &&
							ChangeTransStatus( false, true));
						break;
					case 33:
						return ( CheckClientSaldo() && CheckClientSaldoIndirect()  && 
							ChangeTransStatus( false, true) ); 
						break;
				}
				return false;
			}
			finally
			{
				UnlockTrans();
			}

		}

		private void mnuCancelExec_Click(object sender, System.EventArgs e)
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if (!App.AllowTransactionsExecute)
			{
				MessageBox.Show("Действие отменено: Недостаточный уровень доступа.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if (rwCurrentRow.TransactionTypeID ==14) 
			{
				Trans14Msg();
				return;
			}
			if (!rwCurrentRow.TransactionCommited && !rwCurrentRow.TransactionPosted) 
			{
				MsgBoxX.Show("Транзакция не выполняется");
				return;
			}
			if (DialogResult.Yes !=AM_Controls.MsgBoxX.Show("Вы действительно хотите отменить выполнение транзакции №" + rwCurrentRow.TransactionID.ToString(), "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				return;

			if (	// Транзакции, которые находятся только в двух состояниях
				rwCurrentRow.TransactionTypeID ==   3 ||
				rwCurrentRow.TransactionTypeID ==   4 ||
				rwCurrentRow.TransactionTypeID ==   5 ||
				//rwCurrentRow.TransactionTypeID ==   7 ||
				rwCurrentRow.TransactionTypeID ==   8 ||
				rwCurrentRow.TransactionTypeID ==   9 ||
				rwCurrentRow.TransactionTypeID ==  12 ||
				rwCurrentRow.TransactionTypeID ==  13 ||
				rwCurrentRow.TransactionTypeID ==  16 ||
				rwCurrentRow.TransactionTypeID ==  17 ||
				rwCurrentRow.TransactionTypeID ==  18 ||
				rwCurrentRow.TransactionTypeID ==  33
				)
			{
				//				ChangeTransStatus(false,false);
			}
			else 
			{
				if ( AM_Controls.MsgBoxX.Show("Будут удалены соответствующие платежное поручение и строка выписки?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)!=DialogResult.Yes) 
					return;
				//				ChangeTransStatus(false,false);
				//				return;
			}
			try {
				if (!this.LockTrans())
					return;
				if ( ChangeTransStatus(false,false) )
				this.RefreshDs();
			}
			finally
			{
				UnlockTrans();
			}
		}

		private void dataGridV1_DoubleClick(object sender, System.EventArgs e)
		{
			TransEdit();
		}

		private void mnuFltrApply_Click(object sender, System.EventArgs e)
		{
			this.FilterApply();
		}
		
		private void mnuFltrClear_Click(object sender, System.EventArgs e)
		{
			this.FilterClear();		
		}

		private void mnuConfirm_Click(object sender, System.EventArgs e)
		{
			this.TransConfirm();
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			//this.mnuConfirm.Visible = this.rwCurrentRow.TransactionTypeID == 8;
			if ( this.dvTransList.Count > 0)
				this.mnuCancelExec.Enabled = rwCurrentRow.TransactionCommited || rwCurrentRow.TransactionPosted;
		}

		private void TransactionsList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			this.dataGridV1._SaveStyles =true;
			this.dataGridV1.SaveSettings(); 
		}
		
		private bool bChangeInnerPayee	=false;
		private bool bChangeInnerEQ		=false;

		private void grpPayer_OrgsAcoountIDChanged(object sender, System.EventArgs e)
		{
			if ( this.cbPayerEQPayee.Checked) 
			{
				bChangeInnerPayee			=true;
				this.grpPayee.OrgID			=this.grpPayer.OrgID;
				this.grpPayee.OrgAccountID	=this.grpPayer.OrgAccountID;
				bChangeInnerPayee			=false;
			}
			else 
			{
				bChangeInnerEQ				=true;
				this.cbPayerEQPayee.Checked =false;
				bChangeInnerEQ				=false;
			}
		}

		private void grpPayee_OrgsAcoountIDChanged(object sender, System.EventArgs e)
		{
			if ( bChangeInnerPayee) return;

			bChangeInnerEQ				=true;
			this.cbPayerEQPayee.Checked =false; 
			bChangeInnerEQ				=false;
		}

		private void cbPayerEQPayee_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( bChangeInnerEQ) 
			{
				bChangeInnerEQ =false;
				return;
			}
			if ( this.cbPayerEQPayee.Checked) 
			{
				bChangeInnerPayee			=true;
				this.grpPayee.OrgID			=this.grpPayer.OrgID;
				this.grpPayee.OrgAccountID	=this.grpPayer.OrgAccountID;
				bChangeInnerPayee			=false;
			}
			else 
			{
				bChangeInnerPayee			=true;
				this.grpPayee.OrgID			=0;
				this.grpPayee.OrgAccountID	=0;
				bChangeInnerPayee			=false;
			}
		}

		private void mnuCopy_Click(object sender, System.EventArgs e)
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if(!App.AllowTransactionsEdit)
				return;
			if(this.dvTransList.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvTransList];
			BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rwOld = (BLL.Transactions.DataSets.dsTransactionList.TransactionsRow) ((DataRowView) bm.Current).Row;
			if((rwOld.TransactionTypeID==1)||(rwOld.TransactionTypeID==2)||(rwOld.TransactionTypeID==4)||(rwOld.TransactionTypeID==5)||(rwOld.TransactionTypeID==14))
			{
				AM_Controls.MsgBoxX.Show("Для транзакции типа <" + rwOld.TransactionTypeName + "> операция копирования не возможна");
				return;
			}
			BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rwNew = (BLL.Transactions.DataSets.dsTransactionList.TransactionsRow)this.dvTransList.Table.NewRow();
			for(int i = 0; i< rwOld.Table.Columns.Count; i++)
			{
				if(rwOld[i] != Convert.DBNull) 
				{
					if ( rwOld.Table.Columns[i].ReadOnly)
						rwOld.Table.Columns[i].ReadOnly= false;
					if (!rwOld.Table.Columns[i].Unique)
						rwNew[i] = rwOld[i];
				}
			}
			rwNew.SetCompleteDateNull();
			rwNew.SetDocumentIDNull();
			//			rwNew.InitDate = DateTime.Now;
			rwNew.SetInitDateNull();
			rwNew.SetCompleteDateNull();
			rwNew.TransactionCommited = false;
			rwNew.SetTransactionIDParentNull();
			rwNew.TransactionPosted = false;
			rwNew.SetPaymentOrderStatusIDNull();
			rwNew.SetPaymentOrderStatusNameNull();
			this.dvTransList.Table.Rows.Add((DataRow) rwNew);
			this.updateTransactionsTable();
			int iTransID = rwNew.TransactionID;
			SelectLastInsertedRow(iTransID);

		}

		private void SelectLastInsertedRow(int iID)
		{
			int iNewPosition = this.dvTransList.Count-1;
			for(int j=0 ; j<this.dvTransList.Count;j++)
			{
				if(Convert.ToInt32(this.dvTransList[j].Row["TransactionID"]) == iID)
				{
					iNewPosition = j;
					break;
				}
			}
			this.BindingContext[this.dvTransList].Position = iNewPosition;
			this.dataGridV1.Select(iNewPosition);

		}
	

		private void Trans14Msg()
		{
			AM_Controls.MsgBoxX.Show("Действие недопустимо для данного типа транзакции");
		}

		private DateTime LastSetDate = DateTime.Now;
		private void mnuSetDate_Click(object sender, System.EventArgs e)
		{
			if ( rwCurrentRow.TransactionTypeID >=19 && rwCurrentRow.TransactionTypeID <=32) 
			{
				MessageBox.Show("Действие отменено: Для данного типа транзакций запрошенная операция не допустима.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			if (!this.rwCurrentRow.TransactionPosted && !this.rwCurrentRow.TransactionCommited) 
			{
				MessageBox.Show( "Транзакция находится в исходном(неисполняемом) состоянии.");
				return;
			}

			AskDate dlg = new AskDate();
			dlg.Date = LastSetDate;
			if ( dlg.ShowDialog() == DialogResult.OK) 
			{
				LastSetDate = dlg.Date;
				this.sqlSetDateCmd.Parameters["@SetPostedDate"].Value = true;
				this.sqlSetDateCmd.Parameters["@PostedDate"].Value = LastSetDate;
				this.sqlSetDateCmd.Parameters["@SetCommitedDate"].Value = false;
				this.sqlSetDateCmd.Parameters["@CommitedDate"].Value = LastSetDate;
				this.sqlSetDateCmd.Parameters["@TransactionID"].Value = rwCurrentRow.TransactionID;

				switch (this.rwCurrentRow.TransactionTypeID	) 
				{
					case  14: // Перемещение прием
						Trans14Msg();
						return;

					case  2: // Отправка БН Клиента
					case  6: // Перемещение отправка
					case  7: // БН на развитие
					case 11: // БН расход
						break;
					case  4:		// Выплата Кл
					case  5:	// Конвертация клинту
					case  8:	// Нал из развития
					case  9:	// Конвертация Кассы
					case 13:	// НАЛ расход
					case 18:	// кредит возврат
						
					case  3:	// Нал от клиента
					case 12:	// НАЛ доход
					case 16:	// Взамозачёт Кл
					case 17:	// Кредит выдача
						this.sqlSetDateCmd.Parameters["@SetCommitedDate"].Value = true;
						break;
				}
				if ( AM_Lib.sqlData.ExecuteNonQuery(sqlSetDateCmd) )
					RefreshDs();
			}
		}

		private void RefreshDs()
		{
			int n;
			try
			{
				this.daRefresh.SelectCommand.Parameters["@TransactionID"].Value = rwCurrentRow.TransactionID;
				n = this.daRefresh.Fill(this.dsTransactionList1.Transactions);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		private void dvTransList_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			this.getTransSum();
		}

		private void getTransSum()
		{
			if(!bIsLoaded)
				return;
			this.tbSum.dValue = 0;
			this.tbTransCount.dValue = this.dvTransList.Count;
			DataRow [] drBaseCurr = App.DsCurr.Currencies.Select("IsBase=true");
			string szBaseCurr = drBaseCurr[0]["CurrencyID"].ToString();
			for(int i = 0; i < this.dvTransSumList.Count; i++)
			{
				dsTransSumList.TransSumListRow rwSum = (dsTransSumList.TransSumListRow) this.dvTransSumList[i].Row;
				rwSum.Sum = 0;
				DataRow [] drRate = App.DsCurr.Currencies.Select("CurrencyID='" + rwSum.CurrencyID + "'");
				double dRate = 0;
				if(drRate.Length == 1)
					dRate = Convert.ToDouble(drRate[0]["CurrencyRate"]);
				string szFilter;
				if(dvTransList.RowFilter.Length == 0)
					szFilter = "CurrencyFrom='" + rwSum.CurrencyID + "'";
				else
					szFilter = dvTransList.RowFilter + " AND CurrencyFrom='" + rwSum.CurrencyID + "'";
				DataRow [] dr = dsTransactionList1.Transactions.Select(szFilter);
				for(int j = 0; j < dr.Length; j++)
				{
					BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rw = (BLL.Transactions.DataSets.dsTransactionList.TransactionsRow) dr[j];

					if (rw.TransactionTypeID==14)	// Перем.Прием
						continue;

					rwSum.Sum += rw.SumFrom;
					this.tbSum.dValue += rw.SumFrom * dRate;
				}
			}
		}

		private void btnSumClear_Click(object sender, System.EventArgs e)
		{
			this.textBoxV1.Text ="";
		}

		private void cmbCompareCurrency_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.cbAnyCurrency.Checked =false;
		}

	}
}

