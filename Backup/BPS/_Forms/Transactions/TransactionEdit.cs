using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace BPS._Forms
{
	/// <summary>
	/// Summary description for TransactionBN_Edit.
	/// </summary>
	public class TransactionBN_Edit : System.Windows.Forms.Form
	{
		private bool UseClientsAccount=false;
		private int nTransType = -1;

		private System.Windows.Forms.ComboBox cmbOrgFrom;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbBankFrom;
		private System.Windows.Forms.ComboBox cmbOrgAccountFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbOrgTo;
		private System.Windows.Forms.ComboBox cmbOrgAccountTo;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox tbBankTo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbTransType;
		private System.Windows.Forms.Label label3;
		private AM_Controls.TextBoxV tbSum;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		private System.Data.DataView dvTransTypes;
		private System.Data.DataView dvClients;
		private System.Data.DataView dvOrgFrom;
		private System.Data.DataView dvRAccountFrom;
		private System.Data.DataView dvOrgTo;
		private System.Data.DataView dvRAccountTo;

		private BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rw;
		private bool bIsEdit;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbCurrencyFrom;
		private System.Windows.Forms.ComboBox cmbCurrencyTo;
		private AM_Controls.TextBoxV tbRate;
		private AM_Controls.TextBoxV tbSumTo;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Data.DataView dvCurrFrom;
		private System.Data.DataView dvCurrTo;
		private System.Windows.Forms.GroupBox gbFrom;
		private System.Windows.Forms.GroupBox gbTo;
		private System.Windows.Forms.Label label14;
		private AM_Controls.TextBoxV tbServiceCharge;
		private System.Windows.Forms.TextBox tbRemarks;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public double TransSum
		{
			set {this.tbSum.dValue = value;}
		}
		
		private int InnerTransID=-1;
		private System.Windows.Forms.Button btnPlus;
		private System.Windows.Forms.Button btnMinus;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbPurpose;
		private System.Data.SqlClient.SqlCommand sqlSelAccountIDForClient;
		private System.Data.SqlClient.SqlCommand sqlSelAccountIDForSpecialClient;
		private System.Data.SqlClient.SqlCommand sqlSelAccountIDForKontora;
		private System.Data.SqlClient.SqlCommand sqlSelAccountIDForBlackHole;
		private AM_Controls.TextBoxV tbINNFrom;
		private AM_Controls.TextBoxV tbINNTo;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Data.DataView dvClientsTo;
		private System.Data.SqlClient.SqlCommand sqlClientFromAccount;
		private AM_Controls.TextBoxV tbVAT;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button btnAddVATText;
		private System.Windows.Forms.Button bnGetPurpose;
		private System.Data.SqlClient.SqlCommand cmdGetLastPurpose;
		private System.Windows.Forms.Button btnPurposeList;
		private System.Windows.Forms.ComboBox cmbVAT;
		private System.Windows.Forms.Panel pnlOrganizations;
		private System.Windows.Forms.Panel pnlCurrencyExchange;
		private System.Windows.Forms.Panel pnlClient;
		private BPS._Forms.Clients.GroupClients groupClients;
		private System.Windows.Forms.GroupBox groupBox1;
		private BPS._Forms.Clients.GroupClients groupClientsTo;
		
		public bool Inner
		{
			set 
			{
				this.groupClients._MembersFilter    = value ? "IsInner=true" : "";
				this.dvTransTypes.RowFilter = value ? "IsInner=true" : "";
				this.groupClients.Enabled  = !value;
			}
		}

		public int TransType
		{
			set	
			{
				InnerTransID=value;
				this.groupClients._MembersFilter = "IsInner=true";
			}
		}

		private BLL.Transactions.DataSets.dsTransactionList dsTransactions;
		private BPS.BLL.Orgs.DataSets.dsOrgs dsOrgs1;
		private BPS.BLL.Orgs.DataSets.dsOrgsAccount dsOrgsAccount1;
		private AM_Controls.TextBoxV tbServiceChargeTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel pnlServiceChargeTo;
		private BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rwEdit;

		public TransactionBN_Edit(bool IsEdit, BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rw, BLL.Transactions.DataSets.dsTransactionList dsTrans )
		{

			InitializeComponent();

			dsTransactions = dsTrans;
			rwEdit = rw;
			//
			// Required for Windows Form Designer support
			//

			this.bIsEdit = IsEdit;
			this.rw = rwEdit;
			
			// Валюта

			this.dvCurrFrom.Table = App.bllCurrency.DataSet.Currencies; //App.BPSCurr.ds.Currencies;
			this.cmbCurrencyFrom.DataSource = this.dvCurrFrom;
			this.cmbCurrencyFrom.DisplayMember = "CurrencyID";
			this.cmbCurrencyFrom.ValueMember = "CurrencyID";
			
			this.dvCurrTo.Table = App.bllCurrency.DataSet.Currencies; //App.BPSCurr.ds.Currencies;
			this.cmbCurrencyTo.DataSource = this.dvCurrTo;
			this.cmbCurrencyTo.DisplayMember = "CurrencyID";
			this.cmbCurrencyTo.ValueMember = "CurrencyID";

			//Тип
			this.dvTransTypes.Table = dsTransactions.TransactionsTypes;
			this.cmbTransType.DataSource = this.dvTransTypes;
			this.cmbTransType.DisplayMember = "TransactionTypeName";
			this.cmbTransType.ValueMember = "TransactionTypeID";

/*
 			this.dvOrgFrom.Table = App.DsOrgs.Orgs;
			this.cmbOrgFrom.DataSource = this.dvOrgFrom;
			this.cmbOrgFrom.DisplayMember = "OrgName";
			this.cmbOrgFrom.ValueMember = "OrgID";
			
			this.dvRAccountFrom.Table = App.DsOrgsAccount.OrgsAccounts;
			this.cmbOrgAccountFrom.DataSource = this.dvRAccountFrom;
			this.cmbOrgAccountFrom.DisplayMember = "RAccount";
			this.cmbOrgAccountFrom.ValueMember = "AccountID";
			
			
			this.dvOrgTo.Table = App.DsOrgs.Orgs;
			this.cmbOrgTo.DataSource = this.dvOrgTo;
			this.cmbOrgTo.DisplayMember = "OrgName";
			this.cmbOrgTo.ValueMember = "OrgID";
			
			this.dvRAccountTo.Table = App.DsOrgsAccount.OrgsAccounts;
			this.cmbOrgAccountTo.DataSource = this.dvRAccountTo;
			this.cmbOrgAccountTo.DisplayMember = "RAccount";
			this.cmbOrgAccountTo.ValueMember = "AccountID";
*/
			this.dvOrgFrom.Table = App.DsOrgs.Orgs;
			this.dvRAccountFrom.Table = App.DsOrgsAccount.OrgsAccounts;
			this.dvOrgTo.Table = App.DsOrgs.Orgs.Copy();
			this.dvRAccountTo.Table = App.DsOrgsAccount.OrgsAccounts.Copy();
			
			if (!bIsEdit) 
			{
/*				BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rwNew = dsTransactions.Transactions.NewTransactionsRow();
				this.rw = rwNew;
				this.rw.TransactionCommited		=false;
				this.rw.TransactionPosted		=false;
				this.rw.TransactionIsInner		=false;
				this.rw.ClientIsInner			=false;
				
				this.groupClients._MembersFilter    ="IsInner=true";
				this.groupClientsTo._MembersFilter ="IsInner=false";
				this.dvTransTypes.RowFilter ="IsInner=true and ShowOrder < 100 AND NOT(ShowOrder < 66 AND ShowOrder > 53)";
				
				if ( this.dvOrgTo.RowFilter.Length >0)
					this.dvOrgTo.RowFilter +=" AND [IsRemoved] =false";
				else
					this.dvOrgTo.RowFilter ="[IsRemoved] =false";
				
				if ( this.dvOrgFrom.RowFilter.Length >0)
					this.dvOrgFrom.RowFilter +=" AND [IsRemoved] =false";
				else
					this.dvOrgFrom.RowFilter ="[IsRemoved] =false";

				DataRow [] currRw = App.DsCurr.Currencies.Select("IsBase=" + true);

 				if(currRw.Length == 1)
				{
					this.cmbCurrencyFrom.SelectedValue = currRw[0]["CurrencyID"].ToString();
					this.cmbCurrencyTo.SelectedValue = currRw[0]["CurrencyID"].ToString();
				}

*/			}
			else 
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TransactionBN_Edit));
			this.gbFrom = new System.Windows.Forms.GroupBox();
			this.label17 = new System.Windows.Forms.Label();
			this.tbINNFrom = new AM_Controls.TextBoxV();
			this.tbBankFrom = new System.Windows.Forms.TextBox();
			this.cmbOrgFrom = new System.Windows.Forms.ComboBox();
			this.dvOrgFrom = new System.Data.DataView();
			this.dsOrgs1 = new BPS.BLL.Orgs.DataSets.dsOrgs();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cmbOrgAccountFrom = new System.Windows.Forms.ComboBox();
			this.dvRAccountFrom = new System.Data.DataView();
			this.dsOrgsAccount1 = new BPS.BLL.Orgs.DataSets.dsOrgsAccount();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.gbTo = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.tbINNTo = new AM_Controls.TextBoxV();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbOrgTo = new System.Windows.Forms.ComboBox();
			this.dvOrgTo = new System.Data.DataView();
			this.cmbOrgAccountTo = new System.Windows.Forms.ComboBox();
			this.dvRAccountTo = new System.Data.DataView();
			this.button4 = new System.Windows.Forms.Button();
			this.tbBankTo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbTransType = new System.Windows.Forms.ComboBox();
			this.dvTransTypes = new System.Data.DataView();
			this.label3 = new System.Windows.Forms.Label();
			this.tbSum = new AM_Controls.TextBoxV();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.dvClients = new System.Data.DataView();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbCurrencyFrom = new System.Windows.Forms.ComboBox();
			this.cmbCurrencyTo = new System.Windows.Forms.ComboBox();
			this.tbRate = new AM_Controls.TextBoxV();
			this.tbSumTo = new AM_Controls.TextBoxV();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.dvCurrFrom = new System.Data.DataView();
			this.dvCurrTo = new System.Data.DataView();
			this.label14 = new System.Windows.Forms.Label();
			this.tbServiceCharge = new AM_Controls.TextBoxV();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.sqlSelAccountIDForClient = new System.Data.SqlClient.SqlCommand();
			this.sqlSelAccountIDForSpecialClient = new System.Data.SqlClient.SqlCommand();
			this.btnPlus = new System.Windows.Forms.Button();
			this.btnMinus = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.tbPurpose = new System.Windows.Forms.TextBox();
			this.sqlSelAccountIDForKontora = new System.Data.SqlClient.SqlCommand();
			this.sqlSelAccountIDForBlackHole = new System.Data.SqlClient.SqlCommand();
			this.dvClientsTo = new System.Data.DataView();
			this.sqlClientFromAccount = new System.Data.SqlClient.SqlCommand();
			this.tbVAT = new AM_Controls.TextBoxV();
			this.label21 = new System.Windows.Forms.Label();
			this.btnAddVATText = new System.Windows.Forms.Button();
			this.cmbVAT = new System.Windows.Forms.ComboBox();
			this.bnGetPurpose = new System.Windows.Forms.Button();
			this.cmdGetLastPurpose = new System.Data.SqlClient.SqlCommand();
			this.btnPurposeList = new System.Windows.Forms.Button();
			this.pnlOrganizations = new System.Windows.Forms.Panel();
			this.pnlCurrencyExchange = new System.Windows.Forms.Panel();
			this.pnlClient = new System.Windows.Forms.Panel();
			this.pnlServiceChargeTo = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.tbServiceChargeTo = new AM_Controls.TextBoxV();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupClientsTo = new BPS._Forms.Clients.GroupClients();
			this.groupClients = new BPS._Forms.Clients.GroupClients();
			this.gbFrom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccountFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccount1)).BeginInit();
			this.gbTo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccountTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurrFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurrTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientsTo)).BeginInit();
			this.pnlOrganizations.SuspendLayout();
			this.pnlCurrencyExchange.SuspendLayout();
			this.pnlClient.SuspendLayout();
			this.pnlServiceChargeTo.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbFrom
			// 
			this.gbFrom.Controls.Add(this.label17);
			this.gbFrom.Controls.Add(this.tbINNFrom);
			this.gbFrom.Controls.Add(this.tbBankFrom);
			this.gbFrom.Controls.Add(this.cmbOrgFrom);
			this.gbFrom.Controls.Add(this.button1);
			this.gbFrom.Controls.Add(this.button2);
			this.gbFrom.Controls.Add(this.cmbOrgAccountFrom);
			this.gbFrom.Controls.Add(this.label1);
			this.gbFrom.Controls.Add(this.label6);
			this.gbFrom.Controls.Add(this.label9);
			this.gbFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbFrom.Location = new System.Drawing.Point(4, 26);
			this.gbFrom.Name = "gbFrom";
			this.gbFrom.Size = new System.Drawing.Size(396, 146);
			this.gbFrom.TabIndex = 12;
			this.gbFrom.TabStop = false;
			this.gbFrom.Text = "Плательщик";
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label17.Location = new System.Drawing.Point(12, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(32, 23);
			this.label17.TabIndex = 0;
			this.label17.Text = "ИНН:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbINNFrom
			// 
			this.tbINNFrom.AllowDrop = true;
			this.tbINNFrom.dValue = 0;
			this.tbINNFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbINNFrom.IsPcnt = false;
			this.tbINNFrom.Location = new System.Drawing.Point(88, 16);
			this.tbINNFrom.MaxDecPos = 0;
			this.tbINNFrom.MaxLength = 12;
			this.tbINNFrom.MaxPos = 12;
			this.tbINNFrom.Name = "tbINNFrom";
			this.tbINNFrom.Negative = System.Drawing.Color.Empty;
			this.tbINNFrom.nValue = ((long)(0));
			this.tbINNFrom.Positive = System.Drawing.Color.Empty;
			this.tbINNFrom.Size = new System.Drawing.Size(112, 21);
			this.tbINNFrom.TabIndex = 1;
			this.tbINNFrom.Text = "";
			this.tbINNFrom.TextMode = true;
			this.tbINNFrom.Zero = System.Drawing.Color.Empty;
			this.tbINNFrom.Leave += new System.EventHandler(this.tbINNFrom_Leave);
			// 
			// tbBankFrom
			// 
			this.tbBankFrom.BackColor = System.Drawing.Color.Gainsboro;
			this.tbBankFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBankFrom.Location = new System.Drawing.Point(88, 82);
			this.tbBankFrom.Multiline = true;
			this.tbBankFrom.Name = "tbBankFrom";
			this.tbBankFrom.ReadOnly = true;
			this.tbBankFrom.Size = new System.Drawing.Size(300, 56);
			this.tbBankFrom.TabIndex = 7;
			this.tbBankFrom.TabStop = false;
			this.tbBankFrom.Text = "";
			// 
			// cmbOrgFrom
			// 
			this.cmbOrgFrom.DataSource = this.dvOrgFrom;
			this.cmbOrgFrom.DisplayMember = "OrgName";
			this.cmbOrgFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgFrom.Location = new System.Drawing.Point(88, 38);
			this.cmbOrgFrom.MaxDropDownItems = 20;
			this.cmbOrgFrom.Name = "cmbOrgFrom";
			this.cmbOrgFrom.Size = new System.Drawing.Size(274, 21);
			this.cmbOrgFrom.TabIndex = 3;
			this.cmbOrgFrom.ValueMember = "OrgID";
			this.cmbOrgFrom.SelectedIndexChanged += new System.EventHandler(this.cmbOrgFrom_SelectedIndexChanged);
			this.cmbOrgFrom.Leave += new System.EventHandler(this.cmbOrgFrom_Leave);
			// 
			// dvOrgFrom
			// 
			this.dvOrgFrom.Table = this.dsOrgs1.Orgs;
			// 
			// dsOrgs1
			// 
			this.dsOrgs1.DataSetName = "dsOrgs";
			this.dsOrgs1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(364, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 21);
			this.button1.TabIndex = 2;
			this.button1.TabStop = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(364, 60);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(24, 21);
			this.button2.TabIndex = 5;
			this.button2.TabStop = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// cmbOrgAccountFrom
			// 
			this.cmbOrgAccountFrom.DataSource = this.dvRAccountFrom;
			this.cmbOrgAccountFrom.DisplayMember = "RAccount";
			this.cmbOrgAccountFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgAccountFrom.Location = new System.Drawing.Point(88, 60);
			this.cmbOrgAccountFrom.MaxDropDownItems = 20;
			this.cmbOrgAccountFrom.MaxLength = 20;
			this.cmbOrgAccountFrom.Name = "cmbOrgAccountFrom";
			this.cmbOrgAccountFrom.Size = new System.Drawing.Size(274, 21);
			this.cmbOrgAccountFrom.TabIndex = 5;
			this.cmbOrgAccountFrom.ValueMember = "AccountID";
			this.cmbOrgAccountFrom.SelectedIndexChanged += new System.EventHandler(this.cmbOrgAccountFrom_SelectedIndexChanged);
			this.cmbOrgAccountFrom.Leave += new System.EventHandler(this.cmbOrgAccountFrom_Leave);
			// 
			// dvRAccountFrom
			// 
			this.dvRAccountFrom.Table = this.dsOrgsAccount1.OrgsAccounts;
			// 
			// dsOrgsAccount1
			// 
			this.dsOrgsAccount1.DataSetName = "dsOrgsAccount";
			this.dsOrgsAccount1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Организация:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(12, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 18);
			this.label6.TabIndex = 4;
			this.label6.Text = "Р/cчет:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(12, 84);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 18);
			this.label9.TabIndex = 6;
			this.label9.Text = "Банк:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gbTo
			// 
			this.gbTo.Controls.Add(this.label18);
			this.gbTo.Controls.Add(this.tbINNTo);
			this.gbTo.Controls.Add(this.label2);
			this.gbTo.Controls.Add(this.button3);
			this.gbTo.Controls.Add(this.label7);
			this.gbTo.Controls.Add(this.cmbOrgTo);
			this.gbTo.Controls.Add(this.cmbOrgAccountTo);
			this.gbTo.Controls.Add(this.button4);
			this.gbTo.Controls.Add(this.tbBankTo);
			this.gbTo.Controls.Add(this.label8);
			this.gbTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbTo.Location = new System.Drawing.Point(4, 178);
			this.gbTo.Name = "gbTo";
			this.gbTo.Size = new System.Drawing.Size(396, 147);
			this.gbTo.TabIndex = 1;
			this.gbTo.TabStop = false;
			this.gbTo.Text = "Получатель";
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.Location = new System.Drawing.Point(12, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(38, 23);
			this.label18.TabIndex = 0;
			this.label18.Text = "ИНН:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbINNTo
			// 
			this.tbINNTo.AllowDrop = true;
			this.tbINNTo.dValue = 0;
			this.tbINNTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbINNTo.IsPcnt = false;
			this.tbINNTo.Location = new System.Drawing.Point(88, 16);
			this.tbINNTo.MaxDecPos = 0;
			this.tbINNTo.MaxLength = 12;
			this.tbINNTo.MaxPos = 8;
			this.tbINNTo.Name = "tbINNTo";
			this.tbINNTo.Negative = System.Drawing.Color.Empty;
			this.tbINNTo.nValue = ((long)(0));
			this.tbINNTo.Positive = System.Drawing.Color.Empty;
			this.tbINNTo.Size = new System.Drawing.Size(112, 21);
			this.tbINNTo.TabIndex = 1;
			this.tbINNTo.Text = "";
			this.tbINNTo.TextMode = true;
			this.tbINNTo.Zero = System.Drawing.Color.Empty;
			this.tbINNTo.Leave += new System.EventHandler(this.tbINNTo_Leave);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Организация:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(364, 38);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(24, 21);
			this.button3.TabIndex = 2;
			this.button3.TabStop = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(12, 62);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 18);
			this.label7.TabIndex = 4;
			this.label7.Text = "Р/cчет:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbOrgTo
			// 
			this.cmbOrgTo.DataSource = this.dvOrgTo;
			this.cmbOrgTo.DisplayMember = "OrgName";
			this.cmbOrgTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgTo.Location = new System.Drawing.Point(88, 38);
			this.cmbOrgTo.MaxDropDownItems = 20;
			this.cmbOrgTo.Name = "cmbOrgTo";
			this.cmbOrgTo.Size = new System.Drawing.Size(274, 21);
			this.cmbOrgTo.TabIndex = 3;
			this.cmbOrgTo.ValueMember = "OrgID";
			this.cmbOrgTo.SelectedIndexChanged += new System.EventHandler(this.cmbOrgTo_SelectedIndexChanged);
			this.cmbOrgTo.Leave += new System.EventHandler(this.cmbOrgTo_Leave);
			// 
			// dvOrgTo
			// 
			this.dvOrgTo.Table = this.dsOrgs1.Orgs;
			// 
			// cmbOrgAccountTo
			// 
			this.cmbOrgAccountTo.DataSource = this.dvRAccountTo;
			this.cmbOrgAccountTo.DisplayMember = "RAccount";
			this.cmbOrgAccountTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgAccountTo.Location = new System.Drawing.Point(88, 60);
			this.cmbOrgAccountTo.MaxDropDownItems = 20;
			this.cmbOrgAccountTo.MaxLength = 20;
			this.cmbOrgAccountTo.Name = "cmbOrgAccountTo";
			this.cmbOrgAccountTo.Size = new System.Drawing.Size(274, 21);
			this.cmbOrgAccountTo.TabIndex = 5;
			this.cmbOrgAccountTo.ValueMember = "AccountID";
			this.cmbOrgAccountTo.SelectedIndexChanged += new System.EventHandler(this.cmbOrgAccountTo_SelectedIndexChanged);
			this.cmbOrgAccountTo.Leave += new System.EventHandler(this.cmbOrgAccountTo_Leave);
			// 
			// dvRAccountTo
			// 
			this.dvRAccountTo.Table = this.dsOrgsAccount1.OrgsAccounts;
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.Location = new System.Drawing.Point(364, 60);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(24, 21);
			this.button4.TabIndex = 5;
			this.button4.TabStop = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// tbBankTo
			// 
			this.tbBankTo.BackColor = System.Drawing.Color.Gainsboro;
			this.tbBankTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBankTo.Location = new System.Drawing.Point(88, 82);
			this.tbBankTo.Multiline = true;
			this.tbBankTo.Name = "tbBankTo";
			this.tbBankTo.ReadOnly = true;
			this.tbBankTo.Size = new System.Drawing.Size(300, 56);
			this.tbBankTo.TabIndex = 7;
			this.tbBankTo.TabStop = false;
			this.tbBankTo.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(12, 84);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 18);
			this.label8.TabIndex = 6;
			this.label8.Text = "Банк:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbTransType
			// 
			this.cmbTransType.DataSource = this.dvTransTypes;
			this.cmbTransType.DisplayMember = "TransactionTypeName";
			this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTransType.DropDownWidth = 160;
			this.cmbTransType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbTransType.Location = new System.Drawing.Point(78, 4);
			this.cmbTransType.MaxDropDownItems = 15;
			this.cmbTransType.Name = "cmbTransType";
			this.cmbTransType.Size = new System.Drawing.Size(210, 22);
			this.cmbTransType.TabIndex = 1;
			this.cmbTransType.ValueMember = "TransactionTypeID";
			this.cmbTransType.SelectedIndexChanged += new System.EventHandler(this.cmbTransType_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Тип:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.dValue = 0;
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(78, 52);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 8;
			this.tbSum.Name = "tbSum";
			this.tbSum.Negative = System.Drawing.Color.Empty;
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Positive = System.Drawing.Color.Empty;
			this.tbSum.Size = new System.Drawing.Size(90, 21);
			this.tbSum.TabIndex = 7;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			this.tbSum.Zero = System.Drawing.Color.Empty;
			this.tbSum.Leave += new System.EventHandler(this.tbSum_Leave);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(6, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 18);
			this.label5.TabIndex = 6;
			this.label5.Text = "Сумма:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Enabled = false;
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(332, 4);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(82, 21);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// bnOK
			// 
			this.bnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(242, 540);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(86, 26);
			this.bnOK.TabIndex = 18;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(330, 540);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(86, 26);
			this.bnCancel.TabIndex = 19;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(292, 4);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(38, 20);
			this.label11.TabIndex = 2;
			this.label11.Text = "Дата:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCurrencyFrom
			// 
			this.cmbCurrencyFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurrencyFrom.Location = new System.Drawing.Point(169, 52);
			this.cmbCurrencyFrom.Name = "cmbCurrencyFrom";
			this.cmbCurrencyFrom.Size = new System.Drawing.Size(52, 21);
			this.cmbCurrencyFrom.TabIndex = 8;
			// 
			// cmbCurrencyTo
			// 
			this.cmbCurrencyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurrencyTo.Location = new System.Drawing.Point(292, 25);
			this.cmbCurrencyTo.Name = "cmbCurrencyTo";
			this.cmbCurrencyTo.Size = new System.Drawing.Size(52, 21);
			this.cmbCurrencyTo.TabIndex = 5;
			// 
			// tbRate
			// 
			this.tbRate.AllowDrop = true;
			this.tbRate.dValue = 0;
			this.tbRate.IsPcnt = false;
			this.tbRate.Location = new System.Drawing.Point(207, 3);
			this.tbRate.MaxDecPos = 4;
			this.tbRate.MaxPos = 8;
			this.tbRate.Name = "tbRate";
			this.tbRate.Negative = System.Drawing.Color.Empty;
			this.tbRate.nValue = ((long)(0));
			this.tbRate.Positive = System.Drawing.Color.Empty;
			this.tbRate.Size = new System.Drawing.Size(84, 21);
			this.tbRate.TabIndex = 1;
			this.tbRate.Text = "";
			this.tbRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbRate.TextMode = false;
			this.tbRate.Zero = System.Drawing.Color.Empty;
			this.tbRate.Leave += new System.EventHandler(this.tbRate_Leave);
			// 
			// tbSumTo
			// 
			this.tbSumTo.AllowDrop = true;
			this.tbSumTo.dValue = 0;
			this.tbSumTo.IsPcnt = false;
			this.tbSumTo.Location = new System.Drawing.Point(207, 25);
			this.tbSumTo.MaxDecPos = 2;
			this.tbSumTo.MaxPos = 8;
			this.tbSumTo.Name = "tbSumTo";
			this.tbSumTo.Negative = System.Drawing.Color.Empty;
			this.tbSumTo.nValue = ((long)(0));
			this.tbSumTo.Positive = System.Drawing.Color.Empty;
			this.tbSumTo.Size = new System.Drawing.Size(84, 21);
			this.tbSumTo.TabIndex = 4;
			this.tbSumTo.Text = "";
			this.tbSumTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumTo.TextMode = false;
			this.tbSumTo.Zero = System.Drawing.Color.Empty;
			this.tbSumTo.Leave += new System.EventHandler(this.tbSumTo_Leave);
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(6, 6);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(194, 18);
			this.label12.TabIndex = 0;
			this.label12.Text = "Курс (Рублей за 1 Ед. Валюты):";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label13.Location = new System.Drawing.Point(6, 27);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(132, 18);
			this.label13.TabIndex = 0;
			this.label13.Text = "Зачисляемая Сумма:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label14.Location = new System.Drawing.Point(276, 54);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 18);
			this.label14.TabIndex = 9;
			this.label14.Text = "% Обсл:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbServiceCharge
			// 
			this.tbServiceCharge.AllowDrop = true;
			this.tbServiceCharge.dValue = 0;
			this.tbServiceCharge.IsPcnt = true;
			this.tbServiceCharge.Location = new System.Drawing.Point(334, 52);
			this.tbServiceCharge.MaxDecPos = 4;
			this.tbServiceCharge.MaxPos = 8;
			this.tbServiceCharge.Name = "tbServiceCharge";
			this.tbServiceCharge.Negative = System.Drawing.Color.Empty;
			this.tbServiceCharge.nValue = ((long)(0));
			this.tbServiceCharge.Positive = System.Drawing.Color.Empty;
			this.tbServiceCharge.Size = new System.Drawing.Size(80, 21);
			this.tbServiceCharge.TabIndex = 10;
			this.tbServiceCharge.Text = "0.0000";
			this.tbServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceCharge.TextMode = false;
			this.tbServiceCharge.Zero = System.Drawing.Color.Empty;
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(4, 494);
			this.tbRemarks.Multiline = true;
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbRemarks.Size = new System.Drawing.Size(412, 33);
			this.tbRemarks.TabIndex = 17;
			this.tbRemarks.Text = "";
			// 
			// sqlSelAccountIDForClient
			// 
			this.sqlSelAccountIDForClient.CommandText = "[SelectAccountIDForClient]";
			this.sqlSelAccountIDForClient.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelAccountIDForClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.VarChar, 3));
			// 
			// sqlSelAccountIDForSpecialClient
			// 
			this.sqlSelAccountIDForSpecialClient.CommandText = "[SelectAccountIDForSpecialClient]";
			this.sqlSelAccountIDForSpecialClient.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelAccountIDForSpecialClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForSpecialClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForSpecialClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForSpecialClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.VarChar, 3));
			// 
			// btnPlus
			// 
			this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
			this.btnPlus.Location = new System.Drawing.Point(224, 54);
			this.btnPlus.Name = "btnPlus";
			this.btnPlus.Size = new System.Drawing.Size(24, 21);
			this.btnPlus.TabIndex = 2;
			this.btnPlus.TabStop = false;
			this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
			// 
			// btnMinus
			// 
			this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnMinus.Image = ((System.Drawing.Image)(resources.GetObject("btnMinus.Image")));
			this.btnMinus.Location = new System.Drawing.Point(249, 54);
			this.btnMinus.Name = "btnMinus";
			this.btnMinus.Size = new System.Drawing.Size(24, 21);
			this.btnMinus.TabIndex = 2;
			this.btnMinus.TabStop = false;
			this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label16.Location = new System.Drawing.Point(4, 478);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(92, 16);
			this.label16.TabIndex = 15;
			this.label16.Text = "Примечание:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPurpose
			// 
			this.tbPurpose.Location = new System.Drawing.Point(4, 442);
			this.tbPurpose.Multiline = true;
			this.tbPurpose.Name = "tbPurpose";
			this.tbPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbPurpose.Size = new System.Drawing.Size(412, 33);
			this.tbPurpose.TabIndex = 3;
			this.tbPurpose.Text = "";
			// 
			// sqlSelAccountIDForKontora
			// 
			this.sqlSelAccountIDForKontora.CommandText = "[SelectAccountIDForKontora]";
			this.sqlSelAccountIDForKontora.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelAccountIDForKontora.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForKontora.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForKontora.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.VarChar, 3));
			// 
			// sqlSelAccountIDForBlackHole
			// 
			this.sqlSelAccountIDForBlackHole.CommandText = "[SelectAccountIDForBlackHole]";
			this.sqlSelAccountIDForBlackHole.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelAccountIDForBlackHole.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForBlackHole.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTypeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelAccountIDForBlackHole.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.VarChar, 3));
			// 
			// sqlClientFromAccount
			// 
			this.sqlClientFromAccount.CommandText = "[SelectClientIDFromAccountID]";
			this.sqlClientFromAccount.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlClientFromAccount.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlClientFromAccount.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// tbVAT
			// 
			this.tbVAT.AllowDrop = true;
			this.tbVAT.dValue = 0.2;
			this.tbVAT.IsPcnt = true;
			this.tbVAT.Location = new System.Drawing.Point(48, 2);
			this.tbVAT.MaxDecPos = 2;
			this.tbVAT.MaxPos = 4;
			this.tbVAT.Name = "tbVAT";
			this.tbVAT.Negative = System.Drawing.Color.Empty;
			this.tbVAT.nValue = ((long)(0));
			this.tbVAT.Positive = System.Drawing.Color.Empty;
			this.tbVAT.Size = new System.Drawing.Size(62, 21);
			this.tbVAT.TabIndex = 6;
			this.tbVAT.Text = "20.00";
			this.tbVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVAT.TextMode = false;
			this.tbVAT.Visible = false;
			this.tbVAT.Zero = System.Drawing.Color.Empty;
			this.tbVAT.TextChanged += new System.EventHandler(this.tbVAT_TextChanged);
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.Location = new System.Drawing.Point(166, 4);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(105, 18);
			this.label21.TabIndex = 9;
			this.label21.Text = "Ставка НДС (%):";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAddVATText
			// 
			this.btnAddVATText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddVATText.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVATText.Image")));
			this.btnAddVATText.Location = new System.Drawing.Point(362, 418);
			this.btnAddVATText.Name = "btnAddVATText";
			this.btnAddVATText.Size = new System.Drawing.Size(24, 21);
			this.btnAddVATText.TabIndex = 2;
			this.btnAddVATText.TabStop = false;
			this.btnAddVATText.Click += new System.EventHandler(this.btnAddVATText_Click);
			// 
			// cmbVAT
			// 
			this.cmbVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVAT.Items.AddRange(new object[] {
														"0.00%",
														"10.00%",
														"18.00%",
														"20.00%",
														"Не облагается"});
			this.cmbVAT.Location = new System.Drawing.Point(274, 2);
			this.cmbVAT.Name = "cmbVAT";
			this.cmbVAT.Size = new System.Drawing.Size(126, 21);
			this.cmbVAT.TabIndex = 0;
			// 
			// bnGetPurpose
			// 
			this.bnGetPurpose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnGetPurpose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnGetPurpose.Location = new System.Drawing.Point(4, 418);
			this.bnGetPurpose.Name = "bnGetPurpose";
			this.bnGetPurpose.Size = new System.Drawing.Size(145, 21);
			this.bnGetPurpose.TabIndex = 2;
			this.bnGetPurpose.Text = "Назначение платежа:";
			this.bnGetPurpose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnGetPurpose.Click += new System.EventHandler(this.bnGetPurpose_Click);
			// 
			// cmdGetLastPurpose
			// 
			this.cmdGetLastPurpose.CommandText = "[GetLastTransactionPurpose]";
			this.cmdGetLastPurpose.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionID", System.Data.SqlDbType.Int));
			this.cmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionTypeID", System.Data.SqlDbType.Int));
			this.cmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDFrom", System.Data.SqlDbType.Int));
			this.cmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDTo", System.Data.SqlDbType.Int));
			this.cmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Purpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// btnPurposeList
			// 
			this.btnPurposeList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPurposeList.Image = ((System.Drawing.Image)(resources.GetObject("btnPurposeList.Image")));
			this.btnPurposeList.Location = new System.Drawing.Point(388, 418);
			this.btnPurposeList.Name = "btnPurposeList";
			this.btnPurposeList.Size = new System.Drawing.Size(24, 21);
			this.btnPurposeList.TabIndex = 5;
			this.btnPurposeList.TabStop = false;
			this.btnPurposeList.Click += new System.EventHandler(this.btnPurposeList_Click);
			// 
			// pnlOrganizations
			// 
			this.pnlOrganizations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlOrganizations.Controls.Add(this.gbFrom);
			this.pnlOrganizations.Controls.Add(this.gbTo);
			this.pnlOrganizations.Controls.Add(this.label21);
			this.pnlOrganizations.Controls.Add(this.cmbVAT);
			this.pnlOrganizations.Controls.Add(this.tbVAT);
			this.pnlOrganizations.Location = new System.Drawing.Point(4, 80);
			this.pnlOrganizations.Name = "pnlOrganizations";
			this.pnlOrganizations.Size = new System.Drawing.Size(410, 336);
			this.pnlOrganizations.TabIndex = 11;
			// 
			// pnlCurrencyExchange
			// 
			this.pnlCurrencyExchange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlCurrencyExchange.Controls.Add(this.tbRate);
			this.pnlCurrencyExchange.Controls.Add(this.label12);
			this.pnlCurrencyExchange.Controls.Add(this.tbSumTo);
			this.pnlCurrencyExchange.Controls.Add(this.cmbCurrencyTo);
			this.pnlCurrencyExchange.Controls.Add(this.label13);
			this.pnlCurrencyExchange.Location = new System.Drawing.Point(4, 80);
			this.pnlCurrencyExchange.Name = "pnlCurrencyExchange";
			this.pnlCurrencyExchange.Size = new System.Drawing.Size(410, 56);
			this.pnlCurrencyExchange.TabIndex = 11;
			// 
			// pnlClient
			// 
			this.pnlClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlClient.Controls.Add(this.pnlServiceChargeTo);
			this.pnlClient.Controls.Add(this.groupBox1);
			this.pnlClient.Location = new System.Drawing.Point(4, 80);
			this.pnlClient.Name = "pnlClient";
			this.pnlClient.Size = new System.Drawing.Size(410, 80);
			this.pnlClient.TabIndex = 11;
			// 
			// pnlServiceChargeTo
			// 
			this.pnlServiceChargeTo.Controls.Add(this.label4);
			this.pnlServiceChargeTo.Controls.Add(this.tbServiceChargeTo);
			this.pnlServiceChargeTo.Location = new System.Drawing.Point(8, 48);
			this.pnlServiceChargeTo.Name = "pnlServiceChargeTo";
			this.pnlServiceChargeTo.Size = new System.Drawing.Size(184, 28);
			this.pnlServiceChargeTo.TabIndex = 23;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 18);
			this.label4.TabIndex = 21;
			this.label4.Text = "% Обсл:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbServiceChargeTo
			// 
			this.tbServiceChargeTo.AllowDrop = true;
			this.tbServiceChargeTo.dValue = 0;
			this.tbServiceChargeTo.IsPcnt = true;
			this.tbServiceChargeTo.Location = new System.Drawing.Point(98, 2);
			this.tbServiceChargeTo.MaxDecPos = 4;
			this.tbServiceChargeTo.MaxPos = 8;
			this.tbServiceChargeTo.Name = "tbServiceChargeTo";
			this.tbServiceChargeTo.Negative = System.Drawing.Color.Empty;
			this.tbServiceChargeTo.nValue = ((long)(0));
			this.tbServiceChargeTo.Positive = System.Drawing.Color.Empty;
			this.tbServiceChargeTo.Size = new System.Drawing.Size(80, 21);
			this.tbServiceChargeTo.TabIndex = 22;
			this.tbServiceChargeTo.Text = "0.0000";
			this.tbServiceChargeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceChargeTo.TextMode = false;
			this.tbServiceChargeTo.Zero = System.Drawing.Color.Empty;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupClientsTo);
			this.groupBox1.Location = new System.Drawing.Point(5, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 48);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Клиенту:";
			// 
			// groupClientsTo
			// 
			this.groupClientsTo.__UsageForFilter = false;
			this.groupClientsTo._FirstSpaceWidth = 1;
			this.groupClientsTo._FourthSpaceWidth = 5;
			this.groupClientsTo._GroupID = -1;
			this.groupClientsTo._GroupIDColunmName = null;
			this.groupClientsTo._GroupLabelText = "Группа";
			this.groupClientsTo._GroupNameColumnName = null;
			this.groupClientsTo._GroupsLabelWidth = 46;
			this.groupClientsTo._GroupsTable = null;
			this.groupClientsTo._MemberID = -1;
			this.groupClientsTo._MemberIDColumnName = null;
			this.groupClientsTo._MemberNameColumnName = null;
			this.groupClientsTo._MembersFilter = "";
			this.groupClientsTo._MembersGroupColumnName = null;
			this.groupClientsTo._MembersLabelText = "Клиент";
			this.groupClientsTo._MembersLabelWidth = 48;
			this.groupClientsTo._MembersTable = null;
			this.groupClientsTo._SecondSpaceWidth = 5;
			this.groupClientsTo._ThirdSpaceWidth = 1;
			this.groupClientsTo._Vertical = false;
			this.groupClientsTo.Location = new System.Drawing.Point(8, 16);
			this.groupClientsTo.Name = "groupClientsTo";
			this.groupClientsTo.Size = new System.Drawing.Size(384, 26);
			this.groupClientsTo.TabIndex = 5;
			// 
			// groupClients
			// 
			this.groupClients.__UsageForFilter = false;
			this.groupClients._FirstSpaceWidth = 24;
			this.groupClients._FourthSpaceWidth = 3;
			this.groupClients._GroupID = -1;
			this.groupClients._GroupIDColunmName = null;
			this.groupClients._GroupLabelText = "Группа";
			this.groupClients._GroupNameColumnName = null;
			this.groupClients._GroupsLabelWidth = 46;
			this.groupClients._GroupsTable = null;
			this.groupClients._MemberID = -1;
			this.groupClients._MemberIDColumnName = null;
			this.groupClients._MemberNameColumnName = null;
			this.groupClients._MembersFilter = "";
			this.groupClients._MembersGroupColumnName = null;
			this.groupClients._MembersLabelText = "Клиент";
			this.groupClients._MembersLabelWidth = 48;
			this.groupClients._MembersTable = null;
			this.groupClients._SecondSpaceWidth = 12;
			this.groupClients._ThirdSpaceWidth = 5;
			this.groupClients._Vertical = false;
			this.groupClients.Location = new System.Drawing.Point(4, 26);
			this.groupClients.Name = "groupClients";
			this.groupClients.Size = new System.Drawing.Size(418, 26);
			this.groupClients.TabIndex = 20;
			this.groupClients.ClientIDChanged += new BPS._Forms.Clients.ClientIDChangedEventHandler(this.groupClients_ClientIDChanged);
			// 
			// TransactionBN_Edit
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(418, 567);
			this.Controls.Add(this.groupClients);
			this.Controls.Add(this.tbRemarks);
			this.Controls.Add(this.tbSum);
			this.Controls.Add(this.tbServiceCharge);
			this.Controls.Add(this.tbPurpose);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.cmbTransType);
			this.Controls.Add(this.cmbCurrencyFrom);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.btnPlus);
			this.Controls.Add(this.btnMinus);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.pnlOrganizations);
			this.Controls.Add(this.pnlCurrencyExchange);
			this.Controls.Add(this.pnlClient);
			this.Controls.Add(this.btnAddVATText);
			this.Controls.Add(this.btnPurposeList);
			this.Controls.Add(this.bnGetPurpose);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TransactionBN_Edit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Транзакция";
			this.Load += new System.EventHandler(this.TransactionBN_Edit_Load);
			this.Closed += new System.EventHandler(this.TransactionBN_Edit_Closed);
			this.gbFrom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvOrgFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccountFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccount1)).EndInit();
			this.gbTo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvOrgTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccountTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvTransTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurrFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurrTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientsTo)).EndInit();
			this.pnlOrganizations.ResumeLayout(false);
			this.pnlCurrencyExchange.ResumeLayout(false);
			this.pnlClient.ResumeLayout(false);
			this.pnlServiceChargeTo.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void drawBankString(DataView dv,TextBox tb, int iNdex)
		{
			if(iNdex>-1)
			{
				DataRow [] dr = App.DsBanks.Banks.Select("BankID=" + dv[iNdex]["BankID"].ToString());//.cmbOrgAccount.SelectedValue);
				if(dr.Length>0)
				{
					tb.Text = dr[0]["BankName"] + ", " + dr[0]["CityName"] + ", БИК: " + dr[0]["CodeBIK"] + ", К/С: " + dr[0]["KAccount"];
				}
			}
			else tb.Text = "";
		}
	
		private int GetAccount(SqlCommand	sqlCmd, int AccountType, string Currency)
		{
			bool bCloseConnection = false;

			sqlCmd.Connection = App.Connection;
			try 
			{
				if ( sqlCmd.Connection.State == ConnectionState.Closed) 
				{
					sqlCmd.Connection.Open();
					bCloseConnection = true;
				}

				object ob;
				sqlCmd.Parameters["@CurrencyID"].Value = Currency;
				sqlCmd.Parameters["@AccountTypeID"].Value = AccountType;

				ob = sqlCmd.ExecuteScalar();
				if (ob == Convert.DBNull) 
				{
					throw new Exception("Account не найден.\n Тип =" + AccountType.ToString() + " CurrencyID=" + Currency );
				}
				return (int) ob;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка поиска AccountID:\n " + ex.Message,"BPS");
				return -1;
			}

			finally
			{
				if ( bCloseConnection )
					sqlCmd.Connection.Close();
			}
		}

		private int GetClientID(int AccountID)
		{
			bool bCloseConnection = false;

			sqlClientFromAccount.Connection = App.Connection;
			try 
			{
				if ( sqlClientFromAccount.Connection.State == ConnectionState.Closed) 
				{
					sqlClientFromAccount.Connection.Open();
					bCloseConnection = true;
				}

				object ob;
				sqlClientFromAccount.Parameters["@AccountID"].Value = AccountID;

				ob = sqlClientFromAccount.ExecuteScalar();
				if (ob == Convert.DBNull) 
				{
					throw new Exception("Клиент не найден.");
				}
				return (int) ob;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка поиска AccountID:\n " + ex.Message,"BPS");
				return -1;
			}

			finally
			{
				if ( bCloseConnection )
					sqlClientFromAccount.Connection.Close();
			}
		}
		
		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if (rw.TransactionCommited || rw.TransactionPosted) 
			{
				MessageBox.Show("Изменение заявки в этом состоянии невозможно");
				return;
			}

			if(!this.ValidateRequest())
				return;
			
			if (nTransType!=5 && nTransType!=9) 
			{
				this.tbRate.dValue = 1;
				this.tbSumTo.dValue = this.tbSum.dValue;
			}

			string szCurrencyFrom	=this.cmbCurrencyFrom.SelectedValue.ToString();
			string szCurrencyTo		=this.cmbCurrencyTo.SelectedValue.ToString();

			if (UseClientsAccount) 
			{
				int AccountIDFrom=-1,	AccountIDTo=-1;
				this.sqlSelAccountIDForClient.Parameters["@ClientID"].Value = this.groupClients._MemberID;
				switch (nTransType)
				{
					case 12:	// Внесение НАЛ Доход
						AccountIDFrom = GetAccount(sqlSelAccountIDForBlackHole,12,szCurrencyFrom );	// Касса BlackHole
						AccountIDTo   = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyFrom );		// Касса
						break;
					case 3:	// Внесение НАЛ Кл
						AccountIDFrom = GetAccount(sqlSelAccountIDForClient,3,szCurrencyFrom);		// Касса ClientID 
						AccountIDTo   = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyFrom );		// Касса
						break;
					case 13:	// НАЛ Расход
						AccountIDFrom   = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyFrom );		// Касса
						AccountIDTo     = GetAccount(sqlSelAccountIDForBlackHole,12,szCurrencyFrom );	// Касса BlackHole
						break;
					case 4:	// Выпплата НАЛ Кл
						AccountIDFrom  = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyFrom );		// Касса
						AccountIDTo    = GetAccount(sqlSelAccountIDForClient,3,szCurrencyFrom);		// Касса ClientID 
						break;
					case 8:	// НАЛ из развития
//						sqlSelAccountIDForSpecialClient.Parameters["OrgID"].Value = this.cmbOrgFrom.SelectedValue;
						AccountIDFrom  = GetAccount(sqlSelAccountIDForClient,3,szCurrencyFrom );		// Развивающий
						AccountIDTo    = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyFrom );		// Касса
						break;

					case 5:	// Конвертация Кл
						AccountIDFrom  = GetAccount(sqlSelAccountIDForClient,2,szCurrencyFrom );
						AccountIDTo    = GetAccount(sqlSelAccountIDForClient,2,szCurrencyTo);
						break;
					case 9:	// Конвертация КАССЫ
						AccountIDFrom  = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyFrom );
						AccountIDTo    = GetAccount(sqlSelAccountIDForKontora,3,szCurrencyTo);
						break;
					case 17:	// Кредит выдача
						AccountIDFrom   = GetAccount(sqlSelAccountIDForKontora,13,szCurrencyFrom );	// Кредитный счет
						AccountIDTo     = GetAccount(sqlSelAccountIDForClient,13,szCurrencyFrom );	// Кредитный счет
						break;
					case 18:	// Кредит возврат
						AccountIDFrom   = GetAccount(sqlSelAccountIDForClient,13,szCurrencyFrom );	// Кредитный счет
						AccountIDTo     = GetAccount(sqlSelAccountIDForKontora,13,szCurrencyFrom );	// Кредитный счет
						break;
					case 16:	// Взаимозачет
						this.sqlSelAccountIDForClient.Parameters["@ClientID"].Value = this.groupClients._MemberID;
						AccountIDFrom   = GetAccount(sqlSelAccountIDForClient,2,szCurrencyFrom );	// 
						this.sqlSelAccountIDForClient.Parameters["@ClientID"].Value = this.groupClientsTo._MemberID;
						AccountIDTo     = GetAccount(sqlSelAccountIDForClient,2,szCurrencyFrom );	// 
						break;
					case 33:	// Клиенту из развития
						this.sqlSelAccountIDForClient.Parameters["@ClientID"].Value = this.groupClients._MemberID;
						AccountIDFrom   = GetAccount(sqlSelAccountIDForClient,3,szCurrencyFrom );	// Развивающий
						this.sqlSelAccountIDForClient.Parameters["@ClientID"].Value = this.groupClientsTo._MemberID;
						AccountIDTo     = GetAccount(sqlSelAccountIDForClient,21,szCurrencyFrom );	// 
						break;
				}
				if (AccountIDFrom==-1 || AccountIDTo==-1)
					return;
				rw.AccountIDFrom = AccountIDFrom;
				rw.AccountIDTo = AccountIDTo;
			}
			else 
			{
				rw.AccountIDFrom = (int) this.cmbOrgAccountFrom.SelectedValue;
				rw.AccountIDTo = (int) this.cmbOrgAccountTo.SelectedValue;
			}

			rw.ClientID = (int) this.groupClients._MemberID;
			rw.ClientName = this.groupClients._MemberName;
//			rw.ClientGroupName = this.cmbClients.Text;
			if (!UseClientsAccount) 
			{
				rw.OrgNameFrom = this.cmbOrgFrom.Text;
				rw.OrgNameTo = this.cmbOrgTo.Text;
				rw.RAccountFrom = this.cmbOrgAccountFrom.Text;
				rw.RAccountTo = this.cmbOrgAccountTo.Text;
			}
			else
			{
				rw.OrgNameFrom = 
				rw.OrgNameTo = 
				rw.RAccountFrom = 
				rw.RAccountTo = "-";
			}

//			rw.InitDate = dateTimePicker1.Value;// DateTime.Now;
			rw.SumFrom = this.tbSum.dValue;
			rw.SumTo = this.tbSumTo.dValue;
			rw.CurrencyRate = this.tbRate.dValue;

			rw.CurrencyFrom = this.cmbCurrencyFrom.SelectedValue.ToString();
			rw.CurrencyTo = this.cmbCurrencyTo.SelectedValue.ToString();
			rw.TransactionTypeID= (int) this.cmbTransType.SelectedValue;
			rw.TransactionTypeName = this.cmbTransType.Text;

/*
			if ( this.cmbOrgFrom.SelectedValue!=null)
				rw.OrgIDFrom = (int) this.cmbOrgFrom.SelectedValue;
//			else
//				rw.SetOrgIDFromNull();

			if ( this.cmbOrgTo.SelectedValue!=null)
				rw.OrgIDTo = (int) this.cmbOrgTo.SelectedValue;
//			else
//				rw.SetOrgIDToNull();

*/
			rw.ServiceCharge = this.tbServiceCharge.dValue;
			rw.ServiceChargeTo = this.tbServiceChargeTo.dValue;
			// Mike 03.06.03
			if ( this.tbRemarks.Text.Length >0) //Don't save Zero length string
				rw.Remarks =this.tbRemarks.Text;
			else
				rw.SetRemarksNull();
			
			if ( this.tbPurpose.Text.Length >0) //Don't save Zero length string
				rw.Purpose =this.tbPurpose.Text;
			else
				rw.SetPurposeNull();
			//

//			rw.IsInner = (bool) this.dvClients[this.cmbClients.SelectedIndex]["IsInner"];
//			rw.OrgIsInner = (bool) this.dvOrgFrom[this.cmbOrgFrom.SelectedIndex]["IsInner"];
//			rw.OrgIsInnerTo = (bool) this.dvOrgTo[this.cmbOrgTo.SelectedIndex]["IsInner"];
			
			
			if (!this.bIsEdit) 
			{

				dsTransactions.Transactions.AddTransactionsRow(rw);
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private bool ValidateRequest()
		{
			if(this.groupClients._MemberID == -1)
			{
				AM_Controls.MsgBoxX.Show("Выберите КЛИЕНТА", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.groupClients.Focus();
				return false;
			}

			if (this.tbSum.Text.Length==0 || this.tbSum.dValue==0) 
			{
				AM_Controls.MsgBoxX.Show("Введите сумму операции", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbSum.Focus();
				return false;
			}

			if (this.cmbCurrencyFrom.SelectedValue == null ) 
			{
				AM_Controls.MsgBoxX.Show("Укажите валюту операции", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.cmbCurrencyFrom.Focus();
				return false;
			}
			if((this.nTransType == 16 || this.nTransType == 33) && (this.groupClientsTo._MemberID == -1))
			{
				AM_Controls.MsgBoxX.Show("Укажите клиента-получателя", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.groupClientsTo.Focus();
				return false;
			}
			if (this.nTransType==5 || this.nTransType==9) 
			{
				if (this.tbRate.dValue==0 || this.tbSumTo.dValue==0) 
				{
					AM_Controls.MsgBoxX.Show("Введите курс конвертации или результирующую сумму");
					if (this.tbRate.dValue==0)
						this.tbRate.Focus();
					else
						this.tbSumTo.Focus();
					return false;
				}

				if (this.cmbCurrencyTo.SelectedValue == null || this.cmbCurrencyFrom.SelectedValue.ToString() == this.cmbCurrencyTo.SelectedValue.ToString()) 
				{
					AM_Controls.MsgBoxX.Show("Укажите валюту конвертации", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbCurrencyTo.Focus();
					return false;
				}

				if (this.cmbCurrencyFrom.SelectedValue.ToString() != "RUR" && this.cmbCurrencyTo.SelectedValue.ToString() != "RUR") 
				{
					AM_Controls.MsgBoxX.Show("Конвертация возможна только из/в рубли", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbCurrencyTo.Focus();
					return false;
				}
			}

			if (!UseClientsAccount) 
			{
				if(this.cmbOrgFrom.SelectedIndex == -1)
				{
					AM_Controls.MsgBoxX.Show("Укажите ПЛАТЕЛЬЩИКА", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbOrgFrom.Focus();
					return false;
				}
				if(this.cmbOrgAccountFrom.SelectedIndex == -1 )
				{
					AM_Controls.MsgBoxX.Show("Укажите Р/СЧЁТ плательщика", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbOrgAccountFrom.Focus();
					return false;
				}
				if(this.cmbOrgTo.SelectedIndex == -1)
				{
					AM_Controls.MsgBoxX.Show("Укажите ПОЛУЧАТЕЛЯ", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbOrgTo.Focus();
					return false;
				}
				if(this.cmbOrgAccountTo.SelectedIndex == -1 )
				{
					AM_Controls.MsgBoxX.Show("Укажите Р/СЧЁТ получателя", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbOrgAccountTo.Focus();
					return false;
				}
				if (this.cmbOrgAccountFrom.SelectedValue.ToString() == this.cmbOrgAccountTo.SelectedValue.ToString()) 
				{
					AM_Controls.MsgBoxX.Show("Рассчетные счета Плательщика и Получателя не могут совпадать", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.cmbOrgAccountTo.Focus();
					return false;
				}
			}
			return true;
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbOrgFrom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!bLoaded)
				return;
			if(this.cmbOrgFrom.SelectedIndex>-1) 
			{
					this.dvRAccountFrom.RowFilter = "OrgID=" + this.cmbOrgFrom.SelectedValue.ToString();
				if (nTransType==8) // НАЛ из развития
				{
					int nOrgID =  Convert.ToInt32(this.cmbOrgFrom.SelectedValue);
					BPS.BLL.Orgs.DataSets.dsOrgs.OrgsRow rw=
						App.bllOrgs.DataSet.Orgs.FindByOrgID(nOrgID );
					this.tbServiceCharge.dValue = rw.DefaultServiceCharge;
				}

			}
			else
				this.dvRAccountFrom.RowFilter = "OrgID=-1";

			if(this.dvRAccountFrom.Count == 0)
			{
				this.cmbOrgAccountFrom.SelectedIndex =  -1;
				this.cmbOrgAccountFrom.Text = "";
				this.tbBankFrom.Text = "";

				this.cmbCurrencyFrom.SelectedIndex = -1;
				this.cmbCurrencyTo.SelectedIndex = -1;
			}
			else
			{
				this.cmbOrgAccountFrom.SelectedIndex =  0;
			}
			cmbOrgAccountFrom_SelectedIndexChanged(null,null);

			if(this.bLoaded)
				this.getINN(this.cmbOrgFrom, this.tbINNFrom, this.dvOrgFrom);
		}


		private void cmbOrgAccountFrom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!bLoaded)
				return;
			if(this.cmbOrgAccountFrom.SelectedIndex>-1) 
			{
				string szCurr=	this.dvRAccountFrom[this.cmbOrgAccountFrom.SelectedIndex]["CurrencyID"].ToString();
				this.cmbCurrencyFrom.SelectedValue = szCurr;
				this.drawBankString(this.dvRAccountFrom, this.tbBankFrom, this.cmbOrgAccountFrom.SelectedIndex);
			}
			else 
			{
				this.tbBankFrom.Text = "";
			}
		}

		private void cmbOrgTo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!bLoaded)
				return;
			if(this.cmbOrgTo.SelectedIndex>-1 
				) // && this.cmbOrgAccountFrom.SelectedIndex>-1)
			{
				this.dvRAccountTo.RowFilter = "OrgID=" + this.cmbOrgTo.SelectedValue.ToString() ;//+ " and CurrencyID='" + this.dvRAccountFrom[this.cmbOrgAccountFrom.SelectedIndex]["CurrencyID"].ToString() + "'";
			}
			else 
				this.dvRAccountTo.RowFilter = "OrgID=-1";

			if(this.dvRAccountTo.Count == 0)
			{
				this.cmbOrgAccountTo.SelectedIndex = -1;
				this.cmbOrgAccountTo.Text = "";
				this.tbBankTo.Text = "";
			}
			else 
			{
				this.cmbOrgAccountTo.SelectedIndex =  0;
				cmbOrgAccountTo_SelectedIndexChanged(null,null);
			}

			if(this.cmbOrgTo.SelectedIndex!=-1)
			{
				if (nTransType==8) // НАЛ из развития
				{
					int nOrgID =  Convert.ToInt32(this.cmbOrgTo.SelectedValue);
					BPS.BLL.Orgs.DataSets.dsOrgs.OrgsRow rw=
						App.bllOrgs.DataSet.Orgs.FindByOrgID(nOrgID );
					this.tbServiceCharge.dValue = rw.DefaultServiceCharge;
					}
			}
			if(this.bLoaded)
				this.getINN(this.cmbOrgTo, this.tbINNTo, this.dvOrgTo);
		}

		
		private void cmbOrgAccountTo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!bLoaded)
				return;
			if(this.cmbOrgAccountTo.SelectedIndex>-1) 
			{
				this.cmbCurrencyTo.SelectedValue =
					this.dvRAccountTo[this.cmbOrgAccountTo.SelectedIndex]["CurrencyID"].ToString();
				this.drawBankString(this.dvRAccountTo, this.tbBankTo, this.cmbOrgAccountTo.SelectedIndex);
			}
			else
				this.tbBankTo.Text = "";
		}

		private void cmbOrgFrom_Leave(object sender, System.EventArgs e)
		{
			cmbOrgFrom.SelectedIndex = cmbOrgFrom.FindStringExact(cmbOrgFrom.Text);
			if (cmbOrgFrom.SelectedIndex == -1 )
			{
					this.dvRAccountFrom.RowFilter = "OrgID=-1";
					this.tbINNFrom.Text = "";
					this.cmbOrgAccountFrom.Text = "";
					this.tbBankFrom.Text = "";
					this.cmbCurrencyFrom.SelectedIndex = -1;
					this.cmbCurrencyTo.SelectedIndex = -1;
				NewOrg(cmbOrgFrom);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			NewOrg(cmbOrgFrom);
		}


		private void btnPurposeList_Click(object sender, System.EventArgs e)
		{
			// Created by MIKE 31.05.03
			if (this.cmbOrgAccountFrom.SelectedIndex == -1 || this.cmbOrgAccountTo.SelectedIndex == -1)
				return;
  
			SelectPurpose sp	=new SelectPurpose();
			sp.AccountIDFrom	=(int)this.cmbOrgAccountFrom.SelectedValue;
			sp.AccountIDTo		=(int)this.cmbOrgAccountTo.SelectedValue;
			sp.ClientID         =(int)this.groupClients._MemberID;
			sp.LoadData(); 
			sp.ShowDialog();
			if(sp.DialogResult == DialogResult.OK) this.tbPurpose.Text = sp.Purpose;
					
		}

		private void tbVAT_TextChanged(object sender, System.EventArgs e)
		{
			if(this.tbVAT.dValue>1)
				this.tbVAT.dValue = 0.2;
		}

		private void bnGetPurpose_Click(object sender, System.EventArgs e)
		{
			this.cmdGetLastPurpose.Connection = App.Connection;
			if(rw == null)
				cmdGetLastPurpose.Parameters["@TransactionID"].Value = 0;
			else
				cmdGetLastPurpose.Parameters["@TransactionID"].Value = this.rw.TransactionID;
			cmdGetLastPurpose.Parameters["@TransactionTypeID"].Value = this.cmbTransType.SelectedValue;//rw.TransactionTypeID;
			if(this.cmbOrgAccountFrom.SelectedValue != null)
				cmdGetLastPurpose.Parameters["@AccountIDFrom"].Value = this.cmbOrgAccountFrom.SelectedValue;//rw.AccountIDFrom;
			if(this.cmbOrgAccountTo.SelectedValue != null)
				cmdGetLastPurpose.Parameters["@AccountIDTo"].Value = this.cmbOrgAccountTo.SelectedValue;//rw.AccountIDTo;
	
			try
			{
				App.Connection.Open();
				cmdGetLastPurpose.ExecuteNonQuery();
				object o = cmdGetLastPurpose.Parameters["@Purpose"].Value;
				if(o == Convert.DBNull)
					this.tbPurpose.Text = "";
				else if(o.ToString().Length>0)
				{
					this.tbPurpose.Text = this.replaceVAT(o.ToString());
					this.AddVATText();
				}
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
				this.tbPurpose.Text = "";
			}
			finally
			{
				App.Connection.Close();
			}
		}
		private string replaceVAT(string szPurpose)
		{
			string szPP = szPurpose.ToUpper();
			int iLastIndex = szPP.LastIndexOf("В Т.Ч. НДС");
			if(iLastIndex < 0)
				iLastIndex = szPP.LastIndexOf("НДС НЕ");
			if(iLastIndex >= 0)
				szPurpose = szPurpose.Substring(0, iLastIndex);
			return szPurpose ;//+ "НДС " + tbVAT.Text;
		}

		private void AddVATText()
		{
//			if (this.tbVAT.dValue>0) 
			{
				if (this.tbSum.dValue<0.005) 
				{
					AM_Controls.MsgBoxX.Show("Введите сумму");
					this.tbSum.Focus();
					return;
				}
				if (cmbVAT.Text=="Не облагается") 
				{
					this.tbPurpose.Text += "НДС не облагается.";
				}
				else
				{
					int nPcntPos = cmbVAT.Text.IndexOf("%");
					this.tbVAT.Text = cmbVAT.Text.Substring(0,nPcntPos);
					double dVATSum = Math.Round(this.tbSum.dValue *this.tbVAT.dValue /(1+this.tbVAT.dValue),2);
					this.tbPurpose.Text = this.tbPurpose.Text + "В т.ч. НДС (" + tbVAT.Text + "%) " + dVATSum.ToString("0.00")+"руб.";
				}
			}
		}
		
		private void btnAddVATText_Click(object sender, System.EventArgs e)
		{
			this.tbPurpose.Text = replaceVAT(this.tbPurpose.Text);
			AddVATText();
		}

		private void TransactionBN_Edit_Closed(object sender, System.EventArgs e)
		{
//			if(this.bIsEdit)
//				App.LockStatusChange(1,rw.TransactionID, false);
		}

		private void tbINNTo_Leave(object sender, System.EventArgs e)
		{
			if((this.tbINNTo.Text.Length > 0) && (this.tbINNTo.Text.Length < 10))
			{
				AM_Controls.MsgBoxX.Show("ИНН должен содержать 10-12 цифр.");
				this.tbINNTo.Focus();
				return;
			}
			DataRow [] dr = this.dvOrgTo.Table.Select("CodeINN='" + this.tbINNTo.Text + "'");
			if(dr.Length != 1)
			{
				NewOrg(this.cmbOrgTo, this.tbINNTo.Text);
				return;
			}
			this.cmbOrgTo.SelectedValue = dr[0]["OrgID"];
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			NewOrg(cmbOrgTo);
		}

		private void cmbOrgTo_Leave(object sender, System.EventArgs e)
		{
			cmbOrgTo.SelectedIndex = cmbOrgTo.FindStringExact(cmbOrgTo.Text);
			if (cmbOrgTo.SelectedIndex == -1 )
			{
					this.dvRAccountTo.RowFilter = "OrgID=-1";
					this.tbINNTo.Text = "";
					this.cmbOrgAccountTo.Text = "";
					this.tbBankTo.Text = "";
				NewOrg(cmbOrgTo);
			}
		}

		private void insOrgAccount(object oOrgID, string szOrgName, string szRAccount)
		{
			BPS._Forms.OrgAccountEdit oa = new _Forms.OrgAccountEdit();
			oa.OrgName = szOrgName;
			oa.RAccount = szRAccount;
			oa.ShowDialog();
			if(oa.DialogResult == DialogResult.OK)
			{
				BPS.BLL.Orgs.coOrgAccount  oaAcc = new BPS.BLL.Orgs.coOrgAccount(App.Connection);
				if ( oaAcc.Add(Convert.ToInt32(oOrgID),oa.RAccount, oa.BankID, oa.CurrID,oa.OrgNameStr))
					App.FillOrgsAccount();
/*
				SqlConnection conn = new SqlConnection(App.Connection.ConnectionString);
				//conn.ConnectionString = ;
				if(conn.State == ConnectionState.Closed)
					conn.Open();
				SqlCommand cmdInsAccount = new SqlCommand("", conn);
				SqlCommand cmdInsOrgsAccount = new SqlCommand("", conn);
				SqlCommand cmdGetAccountID = new SqlCommand("SELECT @@IDENTITY", conn);
				
				SqlTransaction tr = conn.BeginTransaction();
				cmdInsAccount.Transaction = tr;
				cmdInsOrgsAccount.Transaction = tr;
				cmdGetAccountID.Transaction = tr;
				try
				{
					
					cmdInsAccount.CommandText = "INSERT INTO Accounts (AccountTypeID,CurrencyID) VALUES (1,'" + oa.CurrID.ToString() + "')";
					cmdInsAccount.ExecuteNonQuery();
					//object oAccountID = cmdGetAccountID.ExecuteScalar();
					int iAccountID = Convert.ToInt32(cmdGetAccountID.ExecuteScalar());
					cmdInsOrgsAccount.CommandText = "INSERT INTO OrgsAccounts (AccountID, OrgID,RAccount,BankID) VALUES " +
						"(" + iAccountID.ToString() + "," + oOrgID + ",'" + oa.RAccount + "'," + oa.BankID.ToString() + ")";
					cmdInsOrgsAccount.ExecuteNonQuery();
					tr.Commit();
					App.FillOrgsAccount();
					
				}
				catch(Exception ex)
				{
					tr.Rollback();
					AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
				finally
				{
					if(conn.State == ConnectionState.Open)
						conn.Close();
				}
*/			}
		}

		private void groupClients_ClientIDChanged(object sender, System.EventArgs e)
		{
			if ( bLoaded  && groupClients._MemberID != -1 ) 
			{
				if ( this.nTransType == 8) 
				{
					if ( this.dvOrgFrom.RowFilter.Length >0) 
						this.dvOrgFrom.RowFilter +="AND ClientID =" +this.groupClients._MemberID.ToString();
					else
						this.dvOrgFrom.RowFilter ="ClientID =" +this.groupClients._MemberID.ToString();

					if ( this.dvOrgFrom.Count==0 )
						this.groupClients._MemberID =  -1;
				}
				cmbOrgTo_SelectedIndexChanged(null,null);
				cmbOrgAccountTo_SelectedIndexChanged(null,null);
			}
		}

		private void cmbTransType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.pnlOrganizations.Visible	 =false;
			this.pnlClient.Visible			 =false; 
			this.pnlCurrencyExchange.Visible =false;
 
			if (bLoaded  && (cmbTransType.SelectedIndex!= -1 || InnerTransID != -1)) 
			{
				nTransType = Convert.ToInt32( cmbTransType.SelectedValue );
				this.groupClients.Enabled = false;
				if (nTransType == 3 || nTransType == 4 || nTransType == 5 || nTransType == 17 ||nTransType == 18)
				{
					if (!this.bIsEdit)
						this.groupClients._MembersFilter = "IsInner=false AND IsSpecial=false";
				}
				else 
				{
					if (!this.bIsEdit)
						this.groupClients._MembersFilter = "IsInner=true";
				}

				
				this.groupClientsTo.Enabled = false;
				this.pnlServiceChargeTo.Visible = false;
				switch (nTransType)
				{
					case 10:	// Принять БН 
					case  1:	// Принять БН Кл
						this.pnlOrganizations.Visible	=true; 
						cmbCurrencyFrom.Enabled			=false; 

						this.dvOrgFrom.RowFilter	="IsInner <>1 AND IsSpecial =0";
						this.dvOrgTo.RowFilter		="IsInner =1";

						UseClientsAccount =false;
						break;
					case 11:	// Отправить
					case  2:	// Отправить
						this.pnlOrganizations.Visible =true; 
						this.cmbCurrencyFrom.Enabled  =false; 

						this.dvOrgFrom.RowFilter	="IsInner =1";
						this.dvOrgTo.RowFilter		="IsInner <>1"; // AND IsSpecial=0";

						UseClientsAccount =false;
						break;
					case 12:	// Внесение НАЛ Доход
						cmbCurrencyFrom.Enabled = (!this.bIsEdit); //true; MIKE
						cmbCurrencyFrom.Enabled = true; //10.09.03 Andrew
						UseClientsAccount = true;
						break;
					case 3:		// Внесение НАЛ Кл
					case 17:	// Кредит выдача
					case 18:	// Кредит возврат
						this.groupClients.Enabled = true;
						cmbCurrencyFrom.Enabled = (!this.bIsEdit); //true; MIKE
						cmbCurrencyFrom.Enabled = true; //10.09.03 Andrew
						UseClientsAccount = true;
						break;
					case 13:	// НАЛ Расход
						cmbCurrencyFrom.Enabled = (!this.bIsEdit); //true; MIKE
						cmbCurrencyFrom.Enabled = true; //10.09.03 Andrew
						UseClientsAccount = true;
						break;
					case 4:	// Выплата НАЛ Кл
						this.groupClients.Enabled = true;
						cmbCurrencyFrom.Enabled = (!this.bIsEdit); //true; MIKE
						cmbCurrencyFrom.Enabled = true; //10.09.03 Andrew
						UseClientsAccount = true;
						break;
					case 5:	// Конвертация Кл
						this.groupClients.Enabled = true;
						this.pnlCurrencyExchange.Visible =true; 
						
						cmbCurrencyFrom.Enabled =(!this.bIsEdit); //MIKE
						cmbCurrencyTo.Enabled	=(!this.bIsEdit); // 

						cmbCurrencyFrom.Enabled = true; //10.09.03 Andrew
						cmbCurrencyTo.Enabled = true; //10.09.03 Andrew
						
						UseClientsAccount =true;
						break;
					case 9:	// Конвертация КАССЫ
						this.pnlCurrencyExchange.Visible =true; 
						
						cmbCurrencyFrom.Enabled =(!this.bIsEdit); //MIKE
						cmbCurrencyTo.Enabled	=(!this.bIsEdit); //

						cmbCurrencyFrom.Enabled = true; //10.09.03 Andrew
						cmbCurrencyTo.Enabled = true; //10.09.03 Andrew
						
						UseClientsAccount =true;
						break;
					case 6:	// Перемещение
						this.pnlOrganizations.Visible =true; 
						this.cmbCurrencyFrom.Enabled =false; 
						
						this.dvOrgFrom.RowFilter	="IsInner =1";
						this.dvOrgTo.RowFilter		="IsInner =1";
						
						UseClientsAccount =false;
						break;
					case 7:	// Отправка на развитие
						this.pnlOrganizations.Visible =true; 
						this.cmbCurrencyFrom.Enabled =false; 
						
						this.dvOrgFrom.RowFilter	="IsInner =1";
						this.dvOrgTo.RowFilter		="IsSpecial =1";

						UseClientsAccount =false;
						break;
					case 8:	// НАЛ из развития
						this.groupClients._MembersFilter = "IsSpecial=1";
						this.groupClients.Enabled = true;

//						this.dvOrgFrom.RowFilter = "ClientID="+this.cmbClients.SelectedValue.ToString();
//						this.cmbOrgFrom.SelectedIndex = 0;

						this.cmbCurrencyFrom.SelectedValue = "RUR";
						this.cmbCurrencyFrom.Enabled =false; 

						UseClientsAccount = true;
						break;
					case 16:	// Взаимозачет между клиентами
						this.groupClientsTo._MembersFilter = this.groupClients._MembersFilter = "IsInner=false AND IsSpecial=false";

						this.pnlClient.Visible		 =true; 
						this.groupClients.Enabled		 =true;
						this.groupClientsTo.Enabled	 =true;
						this.cmbCurrencyFrom.Enabled =true;
						
						UseClientsAccount =true;
						break;
					case 33:	// Клиенту из развития
						this.groupClientsTo._MembersFilter = "IsInner=false AND IsSpecial=false";
						this.groupClients._MembersFilter = "IsSpecial=true";

						this.pnlClient.Visible		 =true; 
						this.groupClients.Enabled		 =true;
						this.groupClientsTo.Enabled	 =true;
						this.cmbCurrencyFrom.Enabled =true;
						this.pnlServiceChargeTo.Visible = true;
					
						UseClientsAccount =true;
						break;
				}
				DataRow [] dr = App.DsCurr.Currencies.Select("IsBase=true");
				if(dr.Length>0)
					cmbCurrencyFrom.SelectedValue = dr[0]["CurrencyID"];
				
				if(!this.bIsEdit && !UseClientsAccount)
				{
					if(this.dvOrgFrom.RowFilter.Length > 0)
						this.dvOrgFrom.RowFilter += " and IsRemoved=false";
					else 
						this.dvOrgFrom.RowFilter += "IsRemoved=false";
					if(this.dvOrgTo.RowFilter.Length > 0)
						this.dvOrgTo.RowFilter += " and IsRemoved=false";
					else
						this.dvOrgTo.RowFilter += "IsRemoved=false";
				}
			}
		}


		private void button2_Click(object sender, System.EventArgs e)
		{
			int iOrgAccCount = App.DsOrgsAccount.OrgsAccounts.Count;
			insOrgAccount(this.cmbOrgFrom.SelectedValue, this.cmbOrgFrom.Text, this.cmbOrgAccountFrom.Text);
			if(iOrgAccCount < App.DsOrgsAccount.OrgsAccounts.Count)
				this.cmbOrgAccountFrom.SelectedValue = App.DsOrgsAccount.OrgsAccounts[iOrgAccCount].AccountID;
			this.drawBankString(this.dvRAccountFrom, this.tbBankFrom, this.cmbOrgAccountFrom.SelectedIndex);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			int iOrgAccCount = App.DsOrgsAccount.OrgsAccounts.Count;
			insOrgAccount(this.cmbOrgTo.SelectedValue, this.cmbOrgTo.Text, this.cmbOrgAccountTo.Text);
			if(iOrgAccCount < App.DsOrgsAccount.OrgsAccounts.Count)
				this.cmbOrgAccountTo.SelectedValue = App.DsOrgsAccount.OrgsAccounts[iOrgAccCount].AccountID;
			this.drawBankString(this.dvRAccountTo, this.tbBankTo, this.cmbOrgAccountTo.SelectedIndex);
		}

		private bool bLoaded = false;
		private void TransactionBN_Edit_Load(object sender, System.EventArgs e)
		{
			bLoaded = true;
			cmbVAT.SelectedIndex = 2;
			if(bIsEdit)
			{
//				Inner = false;
				//this.dvTransTypes.RowFilter ="IsInner=true and ShowOrder < 100 AND NOT(ShowOrder < 66 AND ShowOrder > 53)";
				this.cmbTransType.SelectedIndex = -1;
				
				this.cmbTransType.SelectedValue = rw.TransactionTypeID;
				cmbTransType_SelectedIndexChanged(null,null);
				this.cmbTransType.Enabled =false;

				this.dateTimePicker1.Value = rw.CreateDate;
				if ( !rw.IsClientIDNull()) 
				{
					this.groupClients._MemberID = rw.ClientID;
				}
				else
					this.groupClients._MemberID = -1;

// изменено 10.09.03

				if (!rw.IsOrgIDFromNull())
					this.cmbOrgFrom.SelectedValue = rw.OrgIDFrom;

				this.cmbOrgAccountFrom.SelectedValue = rw.AccountIDFrom;

				if (!rw.IsOrgIDToNull())
					this.cmbOrgTo.SelectedValue = rw.OrgIDTo;

				this.cmbOrgAccountTo.SelectedValue = rw.AccountIDTo;

				this.tbSum.dValue = rw.SumFrom;
				this.tbSumTo.dValue = rw.SumTo;
				this.tbRate.dValue = rw.CurrencyRate;
				this.tbServiceCharge.dValue = rw.ServiceCharge;
				if (!rw.IsServiceChargeToNull())
					this.tbServiceChargeTo.dValue = rw.ServiceChargeTo;
				this.tbRemarks.Text = rw.IsRemarksNull()? "" : rw.Remarks;
				this.tbPurpose.Text = rw.IsPurposeNull()? "" : rw.Purpose;
				this.cmbCurrencyFrom.SelectedValue = rw.CurrencyFrom;
				this.cmbCurrencyTo.SelectedValue = rw.CurrencyTo;
				if (rw.TransactionCommited || rw.TransactionPosted) 
				{
					this.tbSum.Enabled = false;
					this.cmbCurrencyFrom.Enabled = false;
					this.tbSumTo.Enabled = false;
					this.cmbCurrencyTo.Enabled = false;
					this.tbRate.Enabled = false;
					this.tbServiceCharge.Enabled = false;
					this.gbFrom.Enabled = this.gbTo.Enabled = false;
					this.groupClients.Enabled = false;
					this.cmbTransType.Enabled = false;
					btnMinus.Enabled= btnPlus.Enabled = false;
				}
//				this.bnOK.Enabled = !rw.TransactionCommited && !rw.TransactionPosted;

 				if (rw.TransactionTypeID==16 || rw.TransactionTypeID==33) 
				{
					this.groupClientsTo._MemberID =GetClientID( rw.AccountIDTo);
				}


			}
			else 
			{
				BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rwNew = dsTransactions.Transactions.NewTransactionsRow();
				this.rw = rwNew;
				this.rw.TransactionCommited		=false;
				this.rw.TransactionPosted		=false;
				this.rw.TransactionIsInner		=false;
				this.rw.ClientIsInner			=false;
				
				this.groupClients._MembersFilter    ="IsInner=true";
				this.groupClientsTo._MembersFilter ="IsInner=false";
				this.dvTransTypes.RowFilter ="IsInner=true and ShowOrder <100"; // AND NOT(ShowOrder < 66 AND ShowOrder > 53)";
				
				if ( this.dvOrgTo.RowFilter.Length >0)
					this.dvOrgTo.RowFilter +=" AND [IsRemoved] =false";
				else
					this.dvOrgTo.RowFilter ="[IsRemoved] =false";
				
				if ( this.dvOrgFrom.RowFilter.Length >0)
					this.dvOrgFrom.RowFilter +=" AND [IsRemoved] =false";
				else
					this.dvOrgFrom.RowFilter ="[IsRemoved] =false";

				DataRow [] currRw = App.DsCurr.Currencies.Select("IsBase=" + true);

				if(currRw.Length == 1)
				{
					this.cmbCurrencyFrom.SelectedValue = currRw[0]["CurrencyID"].ToString();
					this.cmbCurrencyTo.SelectedValue = currRw[0]["CurrencyID"].ToString();
				}


				groupClients._MemberID = 0;
				if (this.InnerTransID == -1) 
				{
					cmbTransType.SelectedIndex = -1;
					cmbTransType.SelectedIndex = 0;
				}
				else 
				{
					this.groupClients._MemberID = -1;
					this.groupClients._MemberID = 0;
					this.cmbTransType.SelectedIndex = -1;
					this.cmbTransType.SelectedValue = this.InnerTransID;
//					this.groupClients.Enabled=false;
//					this.cmbTransType.Enabled = false;
				}

				this.Text += " [Новая]"	;
				this.cmbOrgFrom.SelectedIndex=0;
				cmbOrgFrom_SelectedIndexChanged(null,null);
				cmbOrgAccountFrom_SelectedIndexChanged(null,null);
				this.cmbOrgTo.SelectedIndex=0;
				cmbOrgTo_SelectedIndexChanged(null,null);
				cmbOrgAccountTo_SelectedIndexChanged(null,null);
			}

			this.getINN(this.cmbOrgFrom, this.tbINNFrom, this.dvOrgFrom);
			this.getINN(this.cmbOrgTo, this.tbINNTo, this.dvOrgTo);
		}

		private void btnPlus_Click(object sender, System.EventArgs e)
		{
			this.tbSum.dValue = this.tbSum.dValue+ Math.Ceiling(this.tbSum.dValue*this.tbServiceCharge.dValue*100)/100;
		}

		private void btnMinus_Click(object sender, System.EventArgs e)
		{
			this.tbSum.dValue = this.tbSum.dValue/(1+this.tbServiceCharge.dValue);
		}

		private bool bLastChangedSumTo=false;
		private bool bAutoRate = false;

		private void tbRate_Leave(object sender, System.EventArgs e)
		{
			if (this.tbRate.Changed) 
			{
				bAutoRate = false;
				this.tbRate.BorderStyle = BorderStyle.Fixed3D;
				RecalcSum();
			}
		}

		private void tbSumTo_Leave(object sender, System.EventArgs e)
		{
			if (this.tbSumTo.Changed) 
			{
				bLastChangedSumTo=true;
				RecalcSum();
			}
		}
		
		private void RecalcSum()
		{
			if ( this.tbRate.dValue!=0 && !bAutoRate) 
			{
				if ( this.cmbCurrencyFrom.SelectedValue!=null && this.cmbCurrencyFrom.SelectedValue.ToString() == "RUR" ) 
				{
					if (bLastChangedSumTo) 
						this.tbSum.dValue = Math.Round(this.tbSumTo.dValue * this.tbRate.dValue,2);
					else
						this.tbSumTo.dValue = Math.Round(this.tbSum.dValue / this.tbRate.dValue,2);
				}

				if ( this.cmbCurrencyTo.SelectedValue!=null && this.cmbCurrencyTo.SelectedValue.ToString() == "RUR" ) 
				{
					if (bLastChangedSumTo) 
						this.tbSum.dValue = Math.Round(this.tbSumTo.dValue / this.tbRate.dValue,2);
					else
						this.tbSumTo.dValue = Math.Round(this.tbSum.dValue * this.tbRate.dValue,2);
				}
			}
			else 
			{
				bAutoRate = true;
				this.tbRate.BorderStyle = BorderStyle.FixedSingle;
				if ( this.cmbCurrencyFrom.SelectedValue!=null && this.cmbCurrencyFrom.SelectedValue.ToString() == "RUR" ) 
				{
					if (this.tbSumTo.dValue!=0)
						this.tbRate.dValue = this.tbSum.dValue/this.tbSumTo.dValue;
				}

				if ( this.cmbCurrencyTo.SelectedValue!=null && this.cmbCurrencyTo.SelectedValue.ToString() == "RUR" ) 
				{
					if (this.tbSum.dValue!=0)
						this.tbRate.dValue = this.tbSumTo.dValue/this.tbSum.dValue;
				}

			}
		}

		private void tbSum_Leave(object sender, System.EventArgs e)
		{
			if (this.tbSum.Changed) {
				bLastChangedSumTo=false;
				RecalcSum();
			}
		}

		private void cmbOrgAccountFrom_Leave(object sender, System.EventArgs e)
		{
			this.cmbOrgAccountFrom.SelectedIndex = this.cmbOrgAccountFrom.FindStringExact(this.cmbOrgAccountFrom.Text);
			if(this.cmbOrgAccountFrom.SelectedIndex == -1)
			{
				insOrgAccount(this.cmbOrgFrom.SelectedValue, this.cmbOrgFrom.Text, this.cmbOrgAccountFrom.Text);
				this.drawBankString(this.dvRAccountFrom, this.tbBankFrom, this.cmbOrgAccountFrom.SelectedIndex);
			}
		}

		private void cmbOrgAccountTo_Leave(object sender, System.EventArgs e)
		{
			this.cmbOrgAccountTo.SelectedIndex = this.cmbOrgAccountTo.FindStringExact(this.cmbOrgAccountTo.Text);
			if(this.cmbOrgAccountTo.SelectedIndex == -1)
			{
				insOrgAccount(this.cmbOrgTo.SelectedValue, this.cmbOrgTo.Text, this.cmbOrgAccountTo.Text);
				this.drawBankString(this.dvRAccountTo, this.tbBankTo, this.cmbOrgAccountTo.SelectedIndex);
			}
		}

		private void tbINNFrom_Leave(object sender, System.EventArgs e)
		{
			if((this.tbINNFrom.Text.Length > 0) && (this.tbINNFrom.Text.Length < 10))
			{
				AM_Controls.MsgBoxX.Show("ИНН должен содержать 10-12 цифр.");
				this.tbINNFrom.Focus();
				return;
			}
			DataRow [] dr = this.dvOrgFrom.Table.Select("CodeINN='" + this.tbINNFrom.Text + "'");
			if(dr.Length != 1)
			{
				NewOrg(this.cmbOrgFrom, this.tbINNFrom.Text);
				return;
			}
			this.cmbOrgFrom.SelectedValue = dr[0]["OrgID"];
		}
		private void getINN(ComboBox cmb, AM_Controls.TextBoxV tb, DataView dv)
		{
			if(cmb.SelectedIndex == -1)
			{
				tb.Text = "";
				return;
			}
			DataRow [] dr = dv.Table.Select("OrgID=" + cmb.SelectedValue.ToString());
			if(dr.Length != 1)
			{
				tb.Text = "";
			}
			else
				tb.Text = dr[0]["CodeINN"].ToString();
		}

		
		
		private void NewOrg(ComboBox cmb, string szINN)
		{

			int nNewOrgID = BPS._Forms.Orgs.EditOrgs.AddOrgDialog(App.bllOrgs,"", szINN);
//			if ((cmb.SelectedValue = App.ShowAddOrg("", szINN)) == null)
			if ((cmb.SelectedValue = nNewOrgID ) == null)
				cmb.Focus();

		}


		
		
		private void NewOrg(System.Windows.Forms.ComboBox cmb)
		{
			//			int nNewID = App.ShowAddOrg(cmb.Text);
			int nNewID = BPS._Forms.Orgs.EditOrgs.AddOrgDialog(App.bllOrgs,cmb.Text,"");
			if (nNewID!=-1) 
			{
				cmb.SelectedValue = nNewID;
			}
		}


	}
}

