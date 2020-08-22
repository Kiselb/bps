using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Lib;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CheckOrgTo.
	/// </summary>
	public class CheckOrgTo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button bnNew;
		private System.Windows.Forms.Button bnSelect;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.DataView dvOrgs;
		private System.Data.DataView dvRAccounts;
		private System.Data.DataView dvBanks;
		private System.Windows.Forms.TextBox tbMessage;
		private BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rwReq;
		
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn OrgsName;
		private System.Windows.Forms.DataGridTextBoxColumn CodeINN;
		private System.Windows.Forms.DataGridTextBoxColumn AddrReg;
		private bool bIsRAccountExist;
		private bool bIsNewOrg = false;
		private int iCheckType;
		private int iOrgID;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn RAccount;
		private System.Windows.Forms.DataGridTextBoxColumn CurrencyID;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn BankName;
		private System.Windows.Forms.DataGridTextBoxColumn CityName;
		private System.Windows.Forms.DataGridTextBoxColumn CodeBIK;
		private System.Windows.Forms.DataGridTextBoxColumn KAccount;
		private int iOrgAccountID;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private int iBankID;

		private BPS.BLL.Bank.coBanks bllBank ;
		private BPS.BLL.City.coCities bllCity ;

		public CheckOrgTo(BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw, int iCheckType)
		{
			//
			// Required for Windows Form Designer support
			//
			this.rwReq = rw;
			this.iCheckType = iCheckType;
			//App.FillOrgsAccount();
			InitializeComponent();

			if(iCheckType == 1)
			{
				App.SetDataGridTableStyle(this.dataGridTableStyle1);
				this.dataGridTableStyle1.SelectionForeColor = System.Drawing.Color.Red;
				this.tbMessage.Text = "Не найдена организация получатель <" + rw.OrgTo + "> с ИНН " + rw.OrgToINN + ".\r\n Возможно есть неточность в реквизитах.\r\n" +
					"Если в списке организаций имеется подходящая, выделите её и нажмите кнопку <Выбрать>. \r\nДля создания новой организации нажмите <Новая>.";
				this.dvOrgs.Table = App.DsOrgs.Orgs;
			}
		}
		public CheckOrgTo(BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw, int iCheckType, int iOrgIDOrgAccountID)
		{
			//
			// Required for Windows Form Designer support
			//
			this.rwReq = rw;
			this.iCheckType = iCheckType;
			//App.FillOrgsAccount();
			this.iOrgID = iOrgIDOrgAccountID;
			this.iOrgAccountID = iOrgIDOrgAccountID;
			InitializeComponent();

			if(iCheckType == 2)
			{
				App.FillOrgsAccount();
				this.dvRAccounts.Table = App.DsOrgsAccount.OrgsAccounts;
				this.dvRAccounts.RowFilter = "OrgID=" + iOrgID + " and CurrencyID='" + rw.CurrencyFrom + "'"; 
				this.dataGrid1.DataSource = this.dvRAccounts;
				App.SetDataGridTableStyle(this.dataGridTableStyle2);
				this.dataGridTableStyle2.SelectionForeColor = System.Drawing.Color.Red;
				if(this.dvRAccounts.Count == 0)
					this.bnSelect.Enabled = false;
				this.tbMessage.Text = "Не найден р.счёт организации получателя <" + rw.OrgTo + "> с ИНН " + rw.OrgToINN + ".\r\n Возможно есть неточность в реквизитах.\r\n" +
					"Если в списке счетов имеется подходящий, выделите его и нажмите кнопку <Выбрать>.\r\n Для создания нового счёта нажмите <Новый>.";
			}
			else
			{
				bllBank = new BPS.BLL.Bank.coBanks();
				bllCity = new BPS.BLL.City.coCities();
				bllBank.Fill();
				bllCity.Fill();
//				this.dvBanks.Table = App.DsBanks.Banks;
				this.dvBanks.Table = bllBank.DataSet.Banks;
				this.dataGrid1.DataSource = this.dvBanks;
				App.SetDataGridTableStyle(this.dataGridTableStyle3);
				this.dataGridTableStyle3.SelectionForeColor = System.Drawing.Color.Red;
				this.tbMessage.Text = "Не найден банк организации получателя <" + rw.OrgTo + "> с ИНН " + rw.OrgToINN + ".\r\n Возможно есть неточность в реквизитах.\r\n" +
					"Если в списке банков имеется подходящий, выделите его и нажмите кнопку <Выбрать>. \r\nДля создания нового банка нажмите <Новый>.";
			}
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CheckOrgTo));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bnCancel = new System.Windows.Forms.Button();
			this.bnSelect = new System.Windows.Forms.Button();
			this.bnNew = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvOrgs = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.OrgsName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CodeINN = new System.Windows.Forms.DataGridTextBoxColumn();
			this.AddrReg = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.RAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CurrencyID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.BankName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CityName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CodeBIK = new System.Windows.Forms.DataGridTextBoxColumn();
			this.KAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dvRAccounts = new System.Data.DataView();
			this.dvBanks = new System.Data.DataView();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccounts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvBanks)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tbMessage});
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(444, 92);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// tbMessage
			// 
			this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbMessage.Location = new System.Drawing.Point(3, 17);
			this.tbMessage.Multiline = true;
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.ReadOnly = true;
			this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbMessage.Size = new System.Drawing.Size(438, 72);
			this.tbMessage.TabIndex = 0;
			this.tbMessage.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.bnCancel,
																				 this.bnSelect,
																				 this.bnNew});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 341);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(444, 28);
			this.panel1.TabIndex = 2;
			// 
			// bnCancel
			// 
			this.bnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(364, 4);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 24);
			this.bnCancel.TabIndex = 2;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// bnSelect
			// 
			this.bnSelect.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.bnSelect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnSelect.Location = new System.Drawing.Point(274, 4);
			this.bnSelect.Name = "bnSelect";
			this.bnSelect.Size = new System.Drawing.Size(80, 24);
			this.bnSelect.TabIndex = 1;
			this.bnSelect.Text = "Выбрать";
			this.bnSelect.Click += new System.EventHandler(this.bnSelect_Click);
			// 
			// bnNew
			// 
			this.bnNew.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.bnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnNew.Location = new System.Drawing.Point(192, 4);
			this.bnNew.Name = "bnNew";
			this.bnNew.Size = new System.Drawing.Size(80, 24);
			this.bnNew.TabIndex = 0;
			this.bnNew.Text = "Новая";
			this.bnNew.Click += new System.EventHandler(this.bnNew_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvOrgs;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 92);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(444, 249);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1,
																								  this.dataGridTableStyle2,
																								  this.dataGridTableStyle3});
			this.dataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseDown);
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.OrgsName,
																												  this.CodeINN,
																												  this.AddrReg});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Orgs";
			// 
			// OrgsName
			// 
			this.OrgsName.Format = "";
			this.OrgsName.FormatInfo = null;
			this.OrgsName.HeaderText = "Наименование";
			this.OrgsName.MappingName = "OrgName";
			this.OrgsName.NullText = "-";
			this.OrgsName.Width = 120;
			// 
			// CodeINN
			// 
			this.CodeINN.Format = "";
			this.CodeINN.FormatInfo = null;
			this.CodeINN.HeaderText = "ИНН";
			this.CodeINN.MappingName = "CodeINN";
			this.CodeINN.NullText = "-";
			this.CodeINN.Width = 75;
			// 
			// AddrReg
			// 
			this.AddrReg.Format = "";
			this.AddrReg.FormatInfo = null;
			this.AddrReg.HeaderText = "Адрес";
			this.AddrReg.MappingName = "AddrReg";
			this.AddrReg.NullText = "-";
			this.AddrReg.Width = 150;
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGrid1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.RAccount,
																												  this.CurrencyID});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "Table";
			// 
			// RAccount
			// 
			this.RAccount.Format = "";
			this.RAccount.FormatInfo = null;
			this.RAccount.HeaderText = "Р. счёт";
			this.RAccount.MappingName = "RAccount";
			this.RAccount.NullText = "-";
			this.RAccount.Width = 120;
			// 
			// CurrencyID
			// 
			this.CurrencyID.Format = "";
			this.CurrencyID.FormatInfo = null;
			this.CurrencyID.HeaderText = "Валюта";
			this.CurrencyID.MappingName = "CurrencyID";
			this.CurrencyID.NullText = "-";
			this.CurrencyID.Width = 75;
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.DataGrid = this.dataGrid1;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.BankName,
																												  this.CityName,
																												  this.CodeBIK,
																												  this.KAccount});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "Banks";
			// 
			// BankName
			// 
			this.BankName.Format = "";
			this.BankName.FormatInfo = null;
			this.BankName.HeaderText = "Банк";
			this.BankName.MappingName = "BankName";
			this.BankName.NullText = "-";
			this.BankName.Width = 120;
			// 
			// CityName
			// 
			this.CityName.Format = "";
			this.CityName.FormatInfo = null;
			this.CityName.HeaderText = "Город";
			this.CityName.MappingName = "CityName";
			this.CityName.NullText = "-";
			this.CityName.Width = 75;
			// 
			// CodeBIK
			// 
			this.CodeBIK.Format = "";
			this.CodeBIK.FormatInfo = null;
			this.CodeBIK.HeaderText = "БИК";
			this.CodeBIK.MappingName = "CodeBIK";
			this.CodeBIK.NullText = "-";
			this.CodeBIK.Width = 75;
			// 
			// KAccount
			// 
			this.KAccount.Format = "";
			this.KAccount.FormatInfo = null;
			this.KAccount.HeaderText = "К. Счёт";
			this.KAccount.MappingName = "KAccount";
			this.KAccount.NullText = "-";
			this.KAccount.Width = 75;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// CheckOrgTo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(444, 369);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid1,
																		  this.panel1,
																		  this.groupBox1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CheckOrgTo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Внимание";
			this.Load += new System.EventHandler(this.CheckOrgTo_Load);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccounts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvBanks)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		public int OrgID
		{
			get
			{
				return this.iOrgID;
			}
		}
		public int OrgAccountID
		{
			get
			{
				return this.iOrgAccountID;
			}
		}
		public bool RAccountExist
		{
			get
			{
				return this.bIsRAccountExist;
			}
		}
		public bool IsNewOrg
		{
			get
			{
				return this.bIsNewOrg;
			}
		}
		public int BankID
		{
			get
			{
				return this.iBankID;
			}
		}
		public void NewAccount()
		{
			//this.bnNew.PerformClick();
			//bIsNewOrg = true;
			//this.ShowDialog();
			this.selectRAccount(true);
			this.bIsRAccountExist = false;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void selectOrg(bool isNew)
		{
			if(isNew)
			{
				SqlCommand cmdInsOrg = new SqlCommand("INSERT INTO Orgs (OrgName, CodeINN, CodeKPP) VALUES (@OrgName,@CodeINN,@CodeKPP);SELECT SCOPE_IDENTITY()");
				cmdInsOrg.Parameters.Add(new SqlParameter("@OrgName", SqlDbType.NVarChar));
				cmdInsOrg.Parameters.Add(new SqlParameter("@CodeINN", SqlDbType.NVarChar));
				cmdInsOrg.Parameters.Add(new SqlParameter("@CodeKPP", SqlDbType.NVarChar));
				cmdInsOrg.Parameters["@OrgName"].Value = this.rwReq.OrgTo;
				cmdInsOrg.Parameters["@CodeINN"].Value = this.rwReq.OrgToINN;
				cmdInsOrg.Parameters["@CodeKPP"].Value = this.rwReq.OrgToKPP;
				
				object o = AM_Lib.sqlData.ExecuteScalar(cmdInsOrg);
				if(o!=null && o != Convert.DBNull)
				{
					this.iOrgID = Convert.ToInt32(o);
				}
				else this.iOrgID = 0;
/*			
				SqlCommand cmdInsOrg = new SqlCommand("[InsertOrg]", this.sqlConnection1);
				cmdInsOrg.CommandType = CommandType.StoredProcedure;
				cmdInsOrg.Parameters.Add(new SqlParameter("@OrgName", SqlDbType.NVarChar));
				cmdInsOrg.Parameters.Add(new SqlParameter("@CodeINN", SqlDbType.NVarChar));
				cmdInsOrg.Parameters.Add(new SqlParameter("@CodeKPP", SqlDbType.NVarChar));
				cmdInsOrg.Parameters.Add(new SqlParameter("@OrgID", SqlDbType.Int));
				cmdInsOrg.Parameters["@OrgID"].Direction = ParameterDirection.Output;
				cmdInsOrg.Parameters["@OrgName"].Value = this.rwReq.OrgTo;
				cmdInsOrg.Parameters["@CodeINN"].Value = this.rwReq.OrgToINN;
				cmdInsOrg.Parameters["@CodeKPP"].Value = this.rwReq.OrgToKPP;
				this.sqlConnection1.Open();
				try
				{
					cmdInsOrg.ExecuteNonQuery();
					object o = cmdInsOrg.Parameters["@OrgID"].Value;
					if(o != Convert.DBNull)
					{
						this.iOrgID = Convert.ToInt32(o);
					}
					else this.iOrgID = 0;
				}
				catch
				{
					this.iOrgID = 0;
				}
				finally
				{
					this.sqlConnection1.Close();
				}
*/
			}
			else
			{
				if(this.dvOrgs.Count>0)
				{
					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvOrgs];
					this.iOrgID = Convert.ToInt32(this.dvOrgs[bm.Position]["OrgID"]);
					this.rwReq.OrgTo = this.dvOrgs[bm.Position]["OrgName"].ToString();
					this.rwReq.OrgToINN = this.dvOrgs[bm.Position]["CodeINN"].ToString();
				}
				else
				{
					this.iOrgID = 0;
				}
			}
		}
		private void selectRAccount(bool isNew)
		{
			if(isNew)
			{
				SqlCommand cmdInsertOrgAccount = new SqlCommand("[OrgAccount_Insert]", this.sqlConnection1);
				cmdInsertOrgAccount.CommandType = CommandType.StoredProcedure;
				cmdInsertOrgAccount.Parameters.Add(new SqlParameter("@OrgID", SqlDbType.Int));
				cmdInsertOrgAccount.Parameters.Add(new SqlParameter("@RAccount", SqlDbType.NVarChar));
				cmdInsertOrgAccount.Parameters.Add(new SqlParameter("@CurrencyID", SqlDbType.NVarChar));
				cmdInsertOrgAccount.Parameters.Add(new SqlParameter("@OrgAccountID", SqlDbType.Int));
				cmdInsertOrgAccount.Parameters["@OrgAccountID"].Direction = ParameterDirection.Output;
				cmdInsertOrgAccount.Parameters["@OrgID"].Value = this.iOrgID;
				cmdInsertOrgAccount.Parameters["@RAccount"].Value = this.rwReq.AccountTo;
				cmdInsertOrgAccount.Parameters["@CurrencyID"].Value = this.rwReq.CurrencyFrom;
				if ( AM_Lib.sqlData.ExecuteNonQuery(cmdInsertOrgAccount) ) 
				{
					object o = cmdInsertOrgAccount.Parameters["@OrgAccountID"].Value;
					if(o!=Convert.DBNull)
						this.iOrgAccountID = Convert.ToInt32(o);
					else 
						this.iOrgAccountID = 0;
				}
				else
					this.iOrgAccountID = 0;

/*				this.sqlConnection1.Open();
				try
				{
					cmdInsertOrgAccount.ExecuteNonQuery();
					object o = cmdInsertOrgAccount.Parameters["@OrgAccountID"].Value;
					if(o!=Convert.DBNull)
						this.iOrgAccountID = Convert.ToInt32(o);
					else this.iOrgAccountID = 0;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					this.iOrgAccountID = 0;
				}
				finally
				{
					this.sqlConnection1.Close();
				}
*/
}
			else
			{
				if(this.dvRAccounts.Count>0)
				{
					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvRAccounts];
					this.iOrgAccountID = Convert.ToInt32(this.dvRAccounts[bm.Position]["OrgsAccountsID"]);
					this.rwReq.AccountTo = this.dvRAccounts[bm.Position]["RAccount"].ToString();
					this.rwReq.CurrencyTo = this.dvRAccounts[bm.Position]["CurrencyID"].ToString();
				}
				else
				{
					this.iOrgAccountID = 0;
				}
			}
		}
		private void selectBank(bool isNew)
		{
			if(isNew)
			{

				BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw = this.bllBank.DataSet.Banks.NewBanksRow();
				rw.BankName = this.rwReq.BankName;
				rw.CodeBIK = this.rwReq.CodeBIK;
				BPS.Forms.Bank.EditBank eb = new BPS.Forms.Bank.EditBank(rw, this.bllCity);

				eb.ShowDialog();
				if(eb.DialogResult == DialogResult.OK)
				{
					iBankID=bllBank.AddBank(rw);
				}

		
		
/*
 				AddBankForClientRequest ab = new AddBankForClientRequest();
				ab.BankName = this.rwReq.BankName;
				ab.BIK = this.rwReq.CodeBIK;
				ab.ShowDialog();
				string szKAccount = "";
				int iCityID = 0;
				if(ab.DialogResult == DialogResult.OK)
				{
					szKAccount = ab.KAccount;
					iCityID = ab.CityID;
					this.rwReq.CodeBIK = ab.BIK;
				}
				else
				{
					this.iBankID = 0;
					return;
				}
				SqlCommand cmdInsBank = new SqlCommand("[InsertBank]", this.sqlConnection1);
				cmdInsBank.CommandType = CommandType.StoredProcedure;
				cmdInsBank.Parameters.Add(new SqlParameter("@OrgAccountID", SqlDbType.Int));
				cmdInsBank.Parameters.Add(new SqlParameter("@BankName", SqlDbType.NVarChar));
				cmdInsBank.Parameters.Add(new SqlParameter("@CodeBIK", SqlDbType.NVarChar));
				cmdInsBank.Parameters.Add(new SqlParameter("@BankID", SqlDbType.Int));
				cmdInsBank.Parameters.Add(new SqlParameter("@KAccount", SqlDbType.NVarChar));
				cmdInsBank.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int));
				cmdInsBank.Parameters["@BankID"].Direction = ParameterDirection.Output;
				cmdInsBank.Parameters["@OrgAccountID"].Value = this.iOrgAccountID;
				cmdInsBank.Parameters["@BankName"].Value = this.rwReq.BankName;
				cmdInsBank.Parameters["@CodeBIK"].Value = this.rwReq.CodeBIK;
				cmdInsBank.Parameters["@KAccount"].Value = szKAccount;
				cmdInsBank.Parameters["@CityID"].Value = iCityID;
				this.sqlConnection1.Open();
				try
				{
					cmdInsBank.ExecuteNonQuery();
					object o = cmdInsBank.Parameters["@BankID"].Value;
					if(o != Convert.DBNull)
						this.iBankID = Convert.ToInt32(o);
					else this.iBankID = 0;
				}
				catch
				{
					this.iBankID = 0;
				}
				finally
				{
					this.sqlConnection1.Close();
				}
*/
			}
			else
			{
				if(this.dvBanks.Count>0)
				{
					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvBanks];
					this.iBankID = Convert.ToInt32(this.dvBanks[bm.Position]["BankID"]);
					this.rwReq.CodeBIK = this.dvBanks[bm.Position]["CodeBIK"].ToString();
					this.rwReq.BankName = this.dvBanks[bm.Position]["BankName"].ToString();
				}
				else
				{
					this.iBankID = 0;
				}
			}
		}

		private void bnNew_Click(object sender, System.EventArgs e)
		{
			if(iCheckType == 1)
			{
				this.selectOrg(true);
				this.bIsNewOrg = true;
			}
			else if(iCheckType == 2)
			{
				this.selectRAccount(true);
				this.bIsRAccountExist = false;
			}
			else
			{
				this.selectBank(true);
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bnSelect_Click(object sender, System.EventArgs e)
		{
			if(iCheckType == 1)
			{
				this.selectOrg(false);
				this.bIsNewOrg = false;
			}
			else if(iCheckType == 2)
			{
				this.selectRAccount(false);
				this.bIsRAccountExist = true;
			}
			else
			{
				this.selectBank(false);
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void dataGrid1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.dataGrid1.CurrentRowIndex>=0)
			{
				//SendKeys.Send("+ ");
			}
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.bnSelect.PerformClick();
		}

		private void CheckOrgTo_Load(object sender, System.EventArgs e)
		{
			
		}
	}
}
