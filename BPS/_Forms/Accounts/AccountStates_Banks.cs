using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AM_Controls;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for AccountStates_Banks.
	/// </summary>
	public class AccountStates_Banks : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
        private BPS.BLL.Accounts.DataSets.dsBankAccountsStates dsBankAccountsStates1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSaldo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnCurrencyID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnAccountID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnKAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnBankName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnCityName;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuRefresh;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbRefresh;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton tbbApply;
		private System.Windows.Forms.ToolBarButton tbbReset;
		private System.Windows.Forms.ToolBarButton tbbClear;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlDataAdapter daSetSaldo;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Windows.Forms.ToolBarButton tbbStore;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private bool bIsEdit = false;
		public AccountStates_Banks()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.tbbStore.Visible = false;
			Refill();
		}
		public AccountStates_Banks(bool bIsEdit)
		{
			this.bIsEdit = bIsEdit;
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			this.ColumnSaldo.ReadOnly = false;
			//this.dataGridTableStyle1.GridColumnStyles[2].ReadOnly = false;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Refill();
			if (this.bIsEdit) 
			{
				this.tbbStore.Visible = true;
				this.Text += "[Изменение]";
			}
			else
				this.tbbStore.Visible = false;

		}
		private void Refill()
			{
				try 
			{
					if (AskConfirmStoring())
						this.sqlDataAdapter1.Fill( this.dsBankAccountsStates1.Orgs);  
			}
			catch(Exception ex) 
		{
			MsgBoxX.Show("При чтении данных произошла ошибка: " +ex.Message.ToString() ,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);	
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AccountStates_Banks));
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataView1 = new System.Data.DataView();
            this.dsBankAccountsStates1 = new BPS.BLL.Accounts.DataSets.dsBankAccountsStates();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnAccountID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSaldo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnCurrencyID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnBankName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnKAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnCityName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuRefresh = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbStore = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbRefresh = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.tbbApply = new System.Windows.Forms.ToolBarButton();
			this.tbbReset = new System.Windows.Forms.ToolBarButton();
			this.tbbClear = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.daSetSaldo = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsBankAccountsStates1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dataGrid1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 71);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(926, 430);
			this.panel3.TabIndex = 2;
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(926, 430);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataView1
			// 
			this.dataView1.AllowDelete = false;
			this.dataView1.AllowNew = false;
			this.dataView1.Sort = "OrgName";
			this.dataView1.Table = this.dsBankAccountsStates1.Orgs;
			// 
			// dsBankAccountsStates1
			// 
			this.dsBankAccountsStates1.DataSetName = "dsBankAccountsStates";
			this.dsBankAccountsStates1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnAccountID,
																												  this.ColumnOrgName,
																												  this.ColumnSaldo,
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.ColumnCurrencyID,
																												  this.ColumnRAccount,
																												  this.ColumnBankName,
																												  this.ColumnKAccount,
																												  this.ColumnCityName});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Orgs";
			// 
			// ColumnAccountID
			// 
			this.ColumnAccountID.Format = "00000";
			this.ColumnAccountID.FormatInfo = null;
			this.ColumnAccountID.HeaderText = "ID";
			this.ColumnAccountID.MappingName = "AccountID";
			this.ColumnAccountID.NullText = "-";
			this.ColumnAccountID.ReadOnly = true;
			this.ColumnAccountID.Width = 45;
			// 
			// ColumnOrgName
			// 
			this.ColumnOrgName.Format = "";
			this.ColumnOrgName.FormatInfo = null;
			this.ColumnOrgName.HeaderText = "Организация";
			this.ColumnOrgName.MappingName = "OrgName";
			this.ColumnOrgName.NullText = "-";
			this.ColumnOrgName.ReadOnly = true;
			this.ColumnOrgName.Width = 170;
			// 
			// ColumnSaldo
			// 
			this.ColumnSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSaldo.Format = "#,##0.00;;\"-\"";
			this.ColumnSaldo.FormatInfo = null;
			this.ColumnSaldo.HeaderText = "Сальдо";
			this.ColumnSaldo.MappingName = "Saldo";
			this.ColumnSaldo.NullText = "-";
			this.ColumnSaldo.ReadOnly = true;
			this.ColumnSaldo.Width = 90;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn1.Format = "#,##0.00;;\"-\"";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Зарезервировано";
			this.dataGridTextBoxColumn1.MappingName = "SumReserved";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 90;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn2.Format = "#,##0.00;;\"-\"";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Ожидается";
			this.dataGridTextBoxColumn2.MappingName = "SumWaited";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 90;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn3.Format = "#,##0.00;;\"-\"";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Свободно";
			this.dataGridTextBoxColumn3.MappingName = "DisposableSum";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 90;
			// 
			// ColumnCurrencyID
			// 
			this.ColumnCurrencyID.Format = "";
			this.ColumnCurrencyID.FormatInfo = null;
			this.ColumnCurrencyID.HeaderText = "Валюта";
			this.ColumnCurrencyID.MappingName = "CurrencyID";
			this.ColumnCurrencyID.NullText = "-";
			this.ColumnCurrencyID.ReadOnly = true;
			this.ColumnCurrencyID.Width = 40;
			// 
			// ColumnRAccount
			// 
			this.ColumnRAccount.Format = "";
			this.ColumnRAccount.FormatInfo = null;
			this.ColumnRAccount.HeaderText = "Расчётный Счёт";
			this.ColumnRAccount.MappingName = "RAccount";
			this.ColumnRAccount.NullText = "-";
			this.ColumnRAccount.ReadOnly = true;
			this.ColumnRAccount.Width = 120;
			// 
			// ColumnBankName
			// 
			this.ColumnBankName.Format = "";
			this.ColumnBankName.FormatInfo = null;
			this.ColumnBankName.HeaderText = "Банк";
			this.ColumnBankName.MappingName = "BankName";
			this.ColumnBankName.NullText = "-";
			this.ColumnBankName.ReadOnly = true;
			this.ColumnBankName.Width = 75;
			// 
			// ColumnKAccount
			// 
			this.ColumnKAccount.Format = "";
			this.ColumnKAccount.FormatInfo = null;
			this.ColumnKAccount.HeaderText = "Корреспондирующий Счёт";
			this.ColumnKAccount.MappingName = "KAccount";
			this.ColumnKAccount.NullText = "-";
			this.ColumnKAccount.ReadOnly = true;
			this.ColumnKAccount.Width = 120;
			// 
			// ColumnCityName
			// 
			this.ColumnCityName.Format = "";
			this.ColumnCityName.FormatInfo = null;
			this.ColumnCityName.HeaderText = "Город";
			this.ColumnCityName.MappingName = "CityName";
			this.ColumnCityName.NullText = "-";
			this.ColumnCityName.ReadOnly = true;
			this.ColumnCityName.Width = 75;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "OrgAccountsBalances", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							 new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																							 new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																							 new System.Data.Common.DataColumnMapping("KAccount", "KAccount"),
																																																							 new System.Data.Common.DataColumnMapping("CityName", "CityName"),
																																																							 new System.Data.Common.DataColumnMapping("Saldo", "Saldo"),
																																																							 new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							 new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							 new System.Data.Common.DataColumnMapping("BankID", "BankID"),
																																																							 new System.Data.Common.DataColumnMapping("CityID", "CityID"),
																																																							 new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID"),
																																																							 new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							 new System.Data.Common.DataColumnMapping("SumReserved", "SumReserved"),
																																																							 new System.Data.Common.DataColumnMapping("SumWaited", "SumWaited"),
																																																							 new System.Data.Common.DataColumnMapping("DisposableSum", "DisposableSum")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[SelAccounts_OurOrgs]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
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
			this.menuItem1.MergeOrder = 1;
			this.menuItem1.Text = "Вид";
			// 
			// mnuRefresh
			// 
			this.mnuRefresh.Index = 0;
			this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.mnuRefresh.Text = "Обновить";
			this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(926, 43);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			this.groupBox1.Visible = false;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbStore,
																						this.toolBarButton1,
																						this.tbbRefresh,
																						this.toolBarButton7,
																						this.tbbApply,
																						this.tbbReset,
																						this.tbbClear});
			this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(926, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbStore
			// 
			this.tbbStore.ImageIndex = 4;
			this.tbbStore.Text = "Сохранить";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.ImageIndex = 2;
			this.tbbRefresh.Text = "Обновить";
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbApply
			// 
			this.tbbApply.ImageIndex = 6;
			this.tbbApply.Text = "Выбрать";
			// 
			// tbbReset
			// 
			this.tbbReset.ImageIndex = 7;
			this.tbbReset.Text = "Cбросить";
			// 
			// tbbClear
			// 
			this.tbbClear.ImageIndex = 5;
			this.tbbClear.Text = "Очистить";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// daSetSaldo
			// 
			this.daSetSaldo.DeleteCommand = this.sqlDeleteCommand1;
			this.daSetSaldo.InsertCommand = this.sqlInsertCommand1;
			this.daSetSaldo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "Accounts", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																			 new System.Data.Common.DataColumnMapping("Saldo", "Saldo")})});
			this.daSetSaldo.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM Accounts WHERE (AccountID = @Original_AccountID) AND (Saldo = @Origin" +
				"al_Saldo)";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Saldo", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Saldo", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO Accounts(Saldo) VALUES (@Saldo); SELECT AccountID, Saldo FROM Account" +
				"s WHERE (AccountID = @@IDENTITY)";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Float, 8, "Saldo"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "[SetSaldo]";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Float, 8, "Saldo"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AccountID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Saldo", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Saldo", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountID", System.Data.SqlDbType.Int, 4, "AccountID"));
			// 
			// AccountStates_Banks
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(926, 501);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "AccountStates_Banks";
			this.Text = "Состояние Расчётных Счетов";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.AccountStates_Banks_Closing);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsBankAccountsStates1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		private void mnuRefresh_Click(object sender, System.EventArgs e)
		{
			Refill();		
		}

		public void ReFresh()
		{
			Refill();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if ( e.Button == this.tbbRefresh)
				Refill();
			else if ( e.Button == this.tbbStore) 
			{
					if(this.updateSaldo())
						dsBankAccountsStates1.AcceptChanges();
			}

		
		}
		private bool updateSaldo()
		{
			try
			{
				this.daSetSaldo.Update(this.dsBankAccountsStates1.Orgs);
				return true;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}


		private bool AskConfirmStoring()
		{
			this.BindingContext[this.dsBankAccountsStates1,"Orgs"].EndCurrentEdit();
			DataRow [] dr = this.dsBankAccountsStates1.Orgs.Select("","", DataViewRowState.ModifiedCurrent);
			if(dr.Length>0)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if(!this.updateSaldo())
						return false;
				}
			}
			return true;
		}

		
		private void AccountStates_Banks_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!AskConfirmStoring())
				e.Cancel = true;
		}
	}
}
