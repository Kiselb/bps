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
	/// Summary description for AccountStates_Clients.
	/// </summary>
	public class AccountStates_Clients : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS._Forms.dsClientsBalances dsClientsBalances1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSaldo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnCurrencyID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnAccountID;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuRefresh;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbRefresh;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton tbbApply;
		private System.Windows.Forms.ToolBarButton tbbReset;
		private System.Windows.Forms.ToolBarButton tbbClear;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Data.SqlClient.SqlDataAdapter daSetSaldo;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbbStore;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnGroupName;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private BPS._Forms.dsClientsGroupsBalances dsClientsGroupsBalances1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientGroupID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientGroupName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnGroupSumSaldo;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnGroupSumSumReserved;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSumSumWaited;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnGroupCurrencyID;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnSumSumFree;
		private System.ComponentModel.IContainer components;

		public AccountStates_Clients()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.sqlSelectCommand1.Parameters["@AccountType"].Value = 2;	// Лицевой счет

			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Refill();
			this.tbbStore.Visible = false;
			this.dataView1.Sort="ClientGroupName ASC, ClientName ASC";
		}
		public AccountStates_Clients(bool bIsEdit)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.sqlSelectCommand1.Parameters["@AccountType"].Value = 2;	// Лицевой счет

			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);

			this.ColumnSaldo.ReadOnly = false;
			this.dataView1.RowFilter = "";
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Refill();
			this.dataView1.Sort="ClientGroupName ASC, ClientName ASC";
			if (bIsEdit) 
			{
				this.tbbStore.Visible = true;
				this.Text += " [Изменение]";
			}
			else
				this.tbbStore.Visible = false;
		}
		
		private void Refill()
		{
			try 
			{
				if (AskConfirmStoring())
					this.sqlDataAdapter1.Fill( this.dsClientsBalances1.Accounts);
				this.dsClientsGroupsBalances1.Accounts.Clear();
				this.sqlDataAdapter2.Fill( this.dsClientsGroupsBalances1.Accounts);  
			}
			catch(Exception ex)
			{
				MsgBoxX.Show("При чтении данных произошла ошибка: " +ex.Message.ToString() ,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);	
			}

		}

		private bool updateSaldo()
		{
			try
			{
				this.daSetSaldo.Update(this.dsClientsBalances1.Accounts);
				return true;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AccountStates_Clients));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataView1 = new System.Data.DataView();
			this.dsClientsBalances1 = new BPS._Forms.dsClientsBalances();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnClientID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnGroupName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnAccountID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSaldo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnCurrencyID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuRefresh = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbStore = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbRefresh = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.tbbApply = new System.Windows.Forms.ToolBarButton();
			this.tbbReset = new System.Windows.Forms.ToolBarButton();
			this.tbbClear = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.daSetSaldo = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.dsClientsGroupsBalances1 = new BPS._Forms.dsClientsGroupsBalances();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnClientGroupID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnClientGroupName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnGroupSumSaldo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnGroupSumSumReserved = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSumSumWaited = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnSumSumFree = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnGroupCurrencyID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsBalances1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsGroupsBalances1)).BeginInit();
			this.SuspendLayout();
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
			this.dataGrid1.Size = new System.Drawing.Size(746, 276);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataView1
			// 
			this.dataView1.AllowDelete = false;
			this.dataView1.AllowNew = false;
			this.dataView1.RowFilter = "AccountTypeID=2 AND (Saldo<>0 OR DisposableSum<>0)";
			this.dataView1.Sort = "ClientName,AccountTypeID,CurrencyID";
			this.dataView1.Table = this.dsClientsBalances1.Accounts;
			// 
			// dsClientsBalances1
			// 
			this.dsClientsBalances1.DataSetName = "dsClientsBalances";
			this.dsClientsBalances1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnClientID,
																												  this.ColumnGroupName,
																												  this.ColumnClientName,
																												  this.ColumnAccountID,
																												  this.ColumnTypeName,
																												  this.ColumnSaldo,
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.ColumnCurrencyID});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Accounts";
			// 
			// ColumnClientID
			// 
			this.ColumnClientID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnClientID.Format = "";
			this.ColumnClientID.FormatInfo = null;
			this.ColumnClientID.HeaderText = "ID";
			this.ColumnClientID.MappingName = "ClientID";
			this.ColumnClientID.ReadOnly = true;
			this.ColumnClientID.Width = 40;
			// 
			// ColumnGroupName
			// 
			this.ColumnGroupName.Format = "";
			this.ColumnGroupName.FormatInfo = null;
			this.ColumnGroupName.HeaderText = "Группа";
			this.ColumnGroupName.MappingName = "ClientGroupName";
			this.ColumnGroupName.Width = 75;
			// 
			// ColumnClientName
			// 
			this.ColumnClientName.Format = "";
			this.ColumnClientName.FormatInfo = null;
			this.ColumnClientName.HeaderText = "Клиент";
			this.ColumnClientName.MappingName = "ClientName";
			this.ColumnClientName.ReadOnly = true;
			this.ColumnClientName.Width = 150;
			// 
			// ColumnAccountID
			// 
			this.ColumnAccountID.Format = "00000";
			this.ColumnAccountID.FormatInfo = null;
			this.ColumnAccountID.HeaderText = "ID Счёта";
			this.ColumnAccountID.MappingName = "AccountID";
			this.ColumnAccountID.ReadOnly = true;
			this.ColumnAccountID.Width = 2;
			// 
			// ColumnTypeName
			// 
			this.ColumnTypeName.Format = "";
			this.ColumnTypeName.FormatInfo = null;
			this.ColumnTypeName.HeaderText = "Тип Счёта";
			this.ColumnTypeName.MappingName = "TypeName";
			this.ColumnTypeName.ReadOnly = true;
			this.ColumnTypeName.Width = 2;
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
			this.dataGridTextBoxColumn1.NullText = "-";
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
			this.dataGridTextBoxColumn2.NullText = "-";
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
			this.ColumnCurrencyID.ReadOnly = true;
			this.ColumnCurrencyID.Width = 50;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Accounts", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																				  new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																				  new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																				  new System.Data.Common.DataColumnMapping("TypeName", "TypeName"),
																																																				  new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																				  new System.Data.Common.DataColumnMapping("Saldo", "Saldo"),
																																																				  new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																				  new System.Data.Common.DataColumnMapping("SumReserved", "SumReserved"),
																																																				  new System.Data.Common.DataColumnMapping("SumWaited", "SumWaited"),
																																																				  new System.Data.Common.DataColumnMapping("DisposableSum", "DisposableSum"),
																																																				  new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[SelAccounts_Clients]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
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
			this.menuItem1.Text = "Вид";
			// 
			// mnuRefresh
			// 
			this.mnuRefresh.Index = 0;
			this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.mnuRefresh.Text = "Обновить";
			this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
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
			this.toolBar1.Size = new System.Drawing.Size(746, 28);
			this.toolBar1.TabIndex = 3;
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
			// groupBox1
			// 
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(746, 29);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			this.groupBox1.Visible = false;
			// 
			// daSetSaldo
			// 
			this.daSetSaldo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "Accounts", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																			 new System.Data.Common.DataColumnMapping("Saldo", "Saldo")})});
			this.daSetSaldo.UpdateCommand = this.sqlUpdateCommand1;
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
			// panel1
			// 
			this.panel1.Controls.Add(this.dataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 57);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(746, 276);
			this.panel1.TabIndex = 5;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 333);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(746, 6);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGrid2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 339);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(746, 230);
			this.panel2.TabIndex = 7;
			// 
			// dataGrid2
			// 
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "Accounts";
			this.dataGrid2.DataSource = this.dsClientsGroupsBalances1;
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(0, 0);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.Size = new System.Drawing.Size(746, 230);
			this.dataGrid2.TabIndex = 0;
			this.dataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle2});
			// 
			// dsClientsGroupsBalances1
			// 
			this.dsClientsGroupsBalances1.DataSetName = "dsClientsGroupsBalances";
			this.dsClientsGroupsBalances1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnClientGroupID,
																												  this.ColumnClientGroupName,
																												  this.ColumnGroupSumSaldo,
																												  this.ColumnGroupSumSumReserved,
																												  this.ColumnSumSumWaited,
																												  this.ColumnSumSumFree,
																												  this.ColumnGroupCurrencyID});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "Accounts";
			// 
			// ColumnClientGroupID
			// 
			this.ColumnClientGroupID.Format = "00000";
			this.ColumnClientGroupID.FormatInfo = null;
			this.ColumnClientGroupID.HeaderText = "ID Группы";
			this.ColumnClientGroupID.MappingName = "ClientGroupID";
			this.ColumnClientGroupID.Width = 75;
			// 
			// ColumnClientGroupName
			// 
			this.ColumnClientGroupName.Format = "";
			this.ColumnClientGroupName.FormatInfo = null;
			this.ColumnClientGroupName.HeaderText = "Группа";
			this.ColumnClientGroupName.MappingName = "ClientGroupName";
			this.ColumnClientGroupName.Width = 195;
			// 
			// ColumnGroupSumSaldo
			// 
			this.ColumnGroupSumSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnGroupSumSaldo.Format = "#,##0.00;;\"-\"";
			this.ColumnGroupSumSaldo.FormatInfo = null;
			this.ColumnGroupSumSaldo.HeaderText = "Сальдо";
			this.ColumnGroupSumSaldo.MappingName = "SumSaldo";
			this.ColumnGroupSumSaldo.NullText = "-";
			this.ColumnGroupSumSaldo.Width = 90;
			// 
			// ColumnGroupSumSumReserved
			// 
			this.ColumnGroupSumSumReserved.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnGroupSumSumReserved.Format = "#,##0.00;;\"-\"";
			this.ColumnGroupSumSumReserved.FormatInfo = null;
			this.ColumnGroupSumSumReserved.HeaderText = "Зарезервировано";
			this.ColumnGroupSumSumReserved.MappingName = "SumSumReserved";
			this.ColumnGroupSumSumReserved.NullText = "-";
			this.ColumnGroupSumSumReserved.Width = 90;
			// 
			// ColumnSumSumWaited
			// 
			this.ColumnSumSumWaited.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSumSumWaited.Format = "#,##0.00;;\"-\"";
			this.ColumnSumSumWaited.FormatInfo = null;
			this.ColumnSumSumWaited.HeaderText = "Ожидается";
			this.ColumnSumSumWaited.MappingName = "SumSumWaited";
			this.ColumnSumSumWaited.NullText = "-";
			this.ColumnSumSumWaited.Width = 90;
			// 
			// ColumnSumSumFree
			// 
			this.ColumnSumSumFree.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnSumSumFree.Format = "#,##0.00;;\"-\"";
			this.ColumnSumSumFree.FormatInfo = null;
			this.ColumnSumSumFree.HeaderText = "Свободно";
			this.ColumnSumSumFree.MappingName = "SumSumFree";
			this.ColumnSumSumFree.Width = 90;
			// 
			// ColumnGroupCurrencyID
			// 
			this.ColumnGroupCurrencyID.Format = "";
			this.ColumnGroupCurrencyID.FormatInfo = null;
			this.ColumnGroupCurrencyID.HeaderText = "Валюта";
			this.ColumnGroupCurrencyID.MappingName = "CurrencyID";
			this.ColumnGroupCurrencyID.Width = 50;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Accounts", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																				  new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																				  new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																				  new System.Data.Common.DataColumnMapping("SumSaldo", "SumSaldo"),
																																																				  new System.Data.Common.DataColumnMapping("SumSumReserved", "SumSumReserved"),
																																																				  new System.Data.Common.DataColumnMapping("SumSumWaited", "SumSumWaited")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT ClientsGroups.ClientGroupID, ClientsGroups.ClientGroupName, Accounts.CurrencyID, SUM(Accounts.Saldo) AS SumSaldo, SUM(Accounts.SumReserved) AS SumSumReserved, SUM(Accounts.SumWaited) AS SumSumWaited, SUM(Accounts.Saldo) - SUM(Accounts.SumReserved) AS SumSumFree FROM Accounts INNER JOIN Clients ON Accounts.ClientID = Clients.ClientID INNER JOIN ClientsGroups ON Clients.ClientGroupID = ClientsGroups.ClientGroupID WHERE (Accounts.AccountTypeID = 2) AND (Clients.IsInner = 0) GROUP BY ClientsGroups.ClientGroupID, ClientsGroups.ClientGroupName, Accounts.CurrencyID ORDER BY ClientsGroups.ClientGroupName, Accounts.CurrencyID";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// AccountStates_Clients
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(746, 569);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "AccountStates_Clients";
			this.Text = "Счета клиентов";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.AccountStates_Clients_Closing);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsBalances1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsGroupsBalances1)).EndInit();
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
					dsClientsBalances1.AcceptChanges();
			}
			
		}

		private bool AskConfirmStoring()
		{
			CurrencyManager bm = (CurrencyManager) BindingContext[this.dataView1];
			bm.EndCurrentEdit();
			DataRow [] dr = this.dsClientsBalances1.Accounts.Select("","", DataViewRowState.ModifiedCurrent);
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


		private void AccountStates_Clients_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!AskConfirmStoring())
				e.Cancel = true;
		}

	}
}
