using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for OrgAccountAccess.
	/// </summary>
	public class OrgAccountAccess : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqldaUsers;
		private BPS.BLL.Orgs.DataSets.dsOrgs dsOrgs1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Data.DataView dvOrgsAccount;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbOrgName;
		private System.Windows.Forms.DataGrid dgOrgsAccounts;
		private System.Windows.Forms.CheckedListBox clbUsers;
		private BPS.BLL.Orgs.DataSets.dsUsers dsUsers1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGridTextBoxColumn dtbOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn dtbAccount;
		private System.Data.DataView dvOrgs;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqldaUserOrgsAccounts;
		private BPS.BLL.Orgs.DataSets.dsUserOrgsAccounts dsUserOrgsAccounts1;
		private BPS.BLL.Orgs.Datasets.dsOrgsAccountAccess dsOrgsAccountAccess1;
		private System.Data.SqlClient.SqlCommand sqlcmdDelUserOrgAccountsAccess;
		private System.Data.SqlClient.SqlCommand sqlcmdAddUserOrgAccountsAccess;
		
		private int CurrentUserID = -1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OrgAccountAccess()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.sqlConnection1 = 
				this.sqldaUsers.SelectCommand.Connection = 
				this.sqldaUserOrgsAccounts.SelectCommand.Connection = 
				this.sqlcmdDelUserOrgAccountsAccess.Connection =
				this.sqlcmdAddUserOrgAccountsAccess.Connection = App.Connection;
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OrgAccountAccess));
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqldaUsers = new System.Data.SqlClient.SqlDataAdapter();
			this.cmbOrgName = new System.Windows.Forms.ComboBox();
			this.dsOrgs1 = new BPS.BLL.Orgs.DataSets.dsOrgs();
			this.dgOrgsAccounts = new System.Windows.Forms.DataGrid();
			this.dvOrgsAccount = new System.Data.DataView();
			this.dsOrgsAccountAccess1 = new BPS.BLL.Orgs.Datasets.dsOrgsAccountAccess();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dtbOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.btnSave = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.clbUsers = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dsUsers1 = new BPS.BLL.Orgs.DataSets.dsUsers();
			this.dvOrgs = new System.Data.DataView();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqldaUserOrgsAccounts = new System.Data.SqlClient.SqlDataAdapter();
			this.dsUserOrgsAccounts1 = new BPS.BLL.Orgs.DataSets.dsUserOrgsAccounts();
			this.sqlcmdDelUserOrgAccountsAccess = new System.Data.SqlClient.SqlCommand();
			this.sqlcmdAddUserOrgAccountsAccess = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgOrgsAccounts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsAccount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccountAccess1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsers1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUserOrgsAccounts1)).BeginInit();
			this.SuspendLayout();
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT UserID, UserName, UserPassword, GroupID, IsRemoved, IsAdmin FROM Users";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqldaUsers
			// 
			this.sqldaUsers.SelectCommand = this.sqlSelectCommand1;
			this.sqldaUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "Users", new System.Data.Common.DataColumnMapping[] {
																																																		  new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																		  new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																		  new System.Data.Common.DataColumnMapping("UserPassword", "UserPassword"),
																																																		  new System.Data.Common.DataColumnMapping("GroupID", "GroupID"),
																																																		  new System.Data.Common.DataColumnMapping("IsRemoved", "IsRemoved"),
																																																		  new System.Data.Common.DataColumnMapping("IsAdmin", "IsAdmin")})});
			// 
			// cmbOrgName
			// 
			this.cmbOrgName.DataSource = this.dsOrgs1.Orgs;
			this.cmbOrgName.DisplayMember = "OrgName";
			this.cmbOrgName.Location = new System.Drawing.Point(350, 2);
			this.cmbOrgName.MaxDropDownItems = 20;
			this.cmbOrgName.Name = "cmbOrgName";
			this.cmbOrgName.Size = new System.Drawing.Size(212, 21);
			this.cmbOrgName.TabIndex = 2;
			this.cmbOrgName.ValueMember = "OrgID";
			this.cmbOrgName.SelectedIndexChanged += new System.EventHandler(this.cmbOrgName_SelectedIndexChanged);
			// 
			// dsOrgs1
			// 
			this.dsOrgs1.DataSetName = "dsOrgs";
			this.dsOrgs1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dgOrgsAccounts
			// 
			this.dgOrgsAccounts.CaptionText = "Расчетные счета";
			this.dgOrgsAccounts.CaptionVisible = false;
			this.dgOrgsAccounts.DataMember = "";
			this.dgOrgsAccounts.DataSource = this.dvOrgsAccount;
			this.dgOrgsAccounts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrgsAccounts.Location = new System.Drawing.Point(182, 26);
			this.dgOrgsAccounts.Name = "dgOrgsAccounts";
			this.dgOrgsAccounts.Size = new System.Drawing.Size(418, 190);
			this.dgOrgsAccounts.TabIndex = 3;
			this.dgOrgsAccounts.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dataGridTableStyle1});
			// 
			// dvOrgsAccount
			// 
			this.dvOrgsAccount.AllowDelete = false;
			this.dvOrgsAccount.AllowNew = false;
			this.dvOrgsAccount.Sort = "OrgName,RAccount";
			this.dvOrgsAccount.Table = this.dsOrgsAccountAccess1.OrgAccountsAccess;
			// 
			// dsOrgsAccountAccess1
			// 
			this.dsOrgsAccountAccess1.DataSetName = "dsOrgsAccountAccess";
			this.dsOrgsAccountAccess1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgOrgsAccounts;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dtbOrgName,
																												  this.dtbAccount,
																												  this.dataGridBoolColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "OrgAccountsAccess";
			// 
			// dtbOrgName
			// 
			this.dtbOrgName.Format = "";
			this.dtbOrgName.FormatInfo = null;
			this.dtbOrgName.HeaderText = "Название организации";
			this.dtbOrgName.MappingName = "OrgName";
			this.dtbOrgName.NullText = "-";
			this.dtbOrgName.ReadOnly = true;
			this.dtbOrgName.Width = 150;
			// 
			// dtbAccount
			// 
			this.dtbAccount.Format = "";
			this.dtbAccount.FormatInfo = null;
			this.dtbAccount.HeaderText = "Р / счет";
			this.dtbAccount.MappingName = "RAccount";
			this.dtbAccount.NullText = "-";
			this.dtbAccount.ReadOnly = true;
			this.dtbAccount.Width = 135;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = false;
			this.dataGridBoolColumn1.HeaderText = "Доступен";
			this.dataGridBoolColumn1.MappingName = "Enabled";
			this.dataGridBoolColumn1.NullText = "-";
			this.dataGridBoolColumn1.NullValue = ((object)(resources.GetObject("dataGridBoolColumn1.NullValue")));
			this.dataGridBoolColumn1.TrueValue = true;
			this.dataGridBoolColumn1.Width = 60;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnSave.Location = new System.Drawing.Point(436, 222);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.button2.Location = new System.Drawing.Point(520, 222);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 26);
			this.button2.TabIndex = 5;
			this.button2.Text = "Закрыть";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// clbUsers
			// 
			this.clbUsers.Location = new System.Drawing.Point(4, 4);
			this.clbUsers.Name = "clbUsers";
			this.clbUsers.Size = new System.Drawing.Size(174, 212);
			this.clbUsers.TabIndex = 6;
			this.clbUsers.SelectedIndexChanged += new System.EventHandler(this.clbUsers_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(264, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "Организация:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// dsUsers1
			// 
			this.dsUsers1.DataSetName = "dsUsers";
			this.dsUsers1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dvOrgs
			// 
			this.dvOrgs.Table = this.dsOrgs1.Orgs;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT UserID, OrgsAccountsID FROM UserOrgsAccounts WHERE (UserID = @UserID) ORDE" +
				"R BY OrgsAccountsID";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"));
			// 
			// sqldaUserOrgsAccounts
			// 
			this.sqldaUserOrgsAccounts.SelectCommand = this.sqlSelectCommand2;
			this.sqldaUserOrgsAccounts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "UserOrgsAccounts", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																								new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID")})});
			// 
			// dsUserOrgsAccounts1
			// 
			this.dsUserOrgsAccounts1.DataSetName = "dsUserOrgsAccounts";
			this.dsUserOrgsAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlcmdDelUserOrgAccountsAccess
			// 
			this.sqlcmdDelUserOrgAccountsAccess.CommandText = "DELETE FROM UserOrgsAccounts WHERE (UserID = @UserID) AND (OrgsAccountsID = @Orgs" +
				"AccountsID)";
			this.sqlcmdDelUserOrgAccountsAccess.Connection = this.sqlConnection1;
			this.sqlcmdDelUserOrgAccountsAccess.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.sqlcmdDelUserOrgAccountsAccess.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgsAccountsID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgsAccountsID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlcmdAddUserOrgAccountsAccess
			// 
			this.sqlcmdAddUserOrgAccountsAccess.CommandText = "INSERT INTO UserOrgsAccounts (UserID, OrgsAccountsID) VALUES (@UserID, @OrgsAccou" +
				"ntsID)";
			this.sqlcmdAddUserOrgAccountsAccess.Connection = this.sqlConnection1;
			this.sqlcmdAddUserOrgAccountsAccess.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"));
			this.sqlcmdAddUserOrgAccountsAccess.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgsAccountsID", System.Data.SqlDbType.Int, 4, "OrgsAccountsID"));
			// 
			// OrgAccountAccess
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(604, 251);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.clbUsers);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dgOrgsAccounts);
			this.Controls.Add(this.cmbOrgName);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OrgAccountAccess";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Доступ к р.счетам";
			this.Load += new System.EventHandler(this.OrgAccountAccess_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgOrgsAccounts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsAccount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccountAccess1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsers1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUserOrgsAccounts1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void FillOrgsAccountAccess()
		{
			try
			{
				SqlDataAdapter daOrgsAccount = new SqlDataAdapter("",App.Connection);
				
				daOrgsAccount.SelectCommand.CommandText = 
					"SELECT Orgs.OrgName, OrgsAccounts.RAccount, OrgsAccounts.OrgsAccountsID, Orgs.OrgID " +
					" FROM OrgsAccounts INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID " +
					" WHERE     (Orgs.IsRemoved = 0) AND (Orgs.IsInner = 1) " +
					" ORDER BY OrgsAccounts.OrgsAccountsID, Orgs.OrgName, OrgsAccounts.RAccount";
				dsOrgsAccountAccess1.Clear();
				daOrgsAccount.Fill(dsOrgsAccountAccess1.OrgAccountsAccess);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		private void OrgAccountAccess_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.sqldaUsers.Fill(this.dsUsers1);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			for(int counter = 0; counter < dsUsers1.Users.Rows.Count; counter ++)
			{
				BPS.BLL.Orgs.DataSets.dsUsers.UsersRow row = (BPS.BLL.Orgs.DataSets.dsUsers.UsersRow)dsUsers1.Users.Rows[counter];
				clbUsers.Items.Add(row.UserName);
				if(row.IsAdmin)
					this.clbUsers.SetItemChecked(counter, true);
				else
					this.clbUsers.SetItemChecked(counter, false);
			}
			this.dsOrgs1.Clear();
			this.dsOrgs1 = (BPS.BLL.Orgs.DataSets.dsOrgs)App.DsOrgs.Copy();
			dvOrgs.Table = this.dsOrgs1.Orgs;
			this.cmbOrgName.DataSource = dvOrgs;
			this.cmbOrgName.DisplayMember = "OrgName";
			this.cmbOrgName.ValueMember = "OrgID";
			FillOrgsAccountAccess();
			this.dvOrgsAccount.Table = this.dsOrgsAccountAccess1.OrgAccountsAccess;
			App.SetDataGridTableStyle(this.dgOrgsAccounts.TableStyles[0]);
			BPS.BLL.Orgs.DataSets.dsOrgs.OrgsRow rw = this.dsOrgs1.Orgs.NewOrgsRow();
			rw.OrgID = 0;
			rw.OrgName = "<Все>";
			rw.OrgName2 = "<Все>";
			rw.IsNormal = true;
			rw.IsInner = true;
			rw.IsSpecial = true;
			rw.DefaultServiceCharge = 0;
			rw.CodeINN = "";
			rw.CodeKPP = "";
			this.dsOrgs1.Orgs.Rows.Add(rw);
			this.dvOrgs.Sort = "OrgName,IsNormal DESC";
			this.dvOrgs.RowFilter="IsInner=true AND IsRemoved=false";
			this.clbUsers.SelectedIndex = 0;
			CurrentUserID = (int)this.dsUsers1.Users.Rows[this.clbUsers.SelectedIndex]["UserID"];
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(this.dsOrgsAccountAccess1.HasChanges())
			{
				if(MessageBox.Show("Сохранить изменения?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SaveChanges();
				}
			}
			Close();
		}

		private void cmbOrgName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.dsOrgsAccountAccess1.HasChanges())
			{
				if(MessageBox.Show("Сохранить изменения?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SaveChanges();
				}
			}
			if(this.cmbOrgName.SelectedIndex == 0)
			{
				this.dvOrgsAccount.RowFilter = "";
			}
			else
			{
				this.dvOrgsAccount.RowFilter = "OrgID = " + this.cmbOrgName.SelectedValue.ToString();
			}
		}

		private void clbUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.dsOrgsAccountAccess1.HasChanges())
			{
				if(MessageBox.Show("Сохранить изменения?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SaveChanges();
				}
			}
			CurrentUserID = (int)this.dsUsers1.Users.Rows[this.clbUsers.SelectedIndex]["UserID"];
			try
			{
				this.dsUserOrgsAccounts1.Clear();
				this.sqldaUserOrgsAccounts.SelectCommand.Parameters["@UserID"].Value = this.dsUsers1.Users.Rows[this.clbUsers.SelectedIndex]["UserID"];
				this.sqldaUserOrgsAccounts.Fill(this.dsUserOrgsAccounts1);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			int counterindex = 0;
			for(int counter1 = 0; counter1 < this.dsOrgsAccountAccess1.OrgAccountsAccess.Rows.Count; counter1 ++)
			{
				if(counterindex >= this.dsUserOrgsAccounts1.UserOrgsAccounts.Rows.Count)
				{
					this.dsOrgsAccountAccess1.OrgAccountsAccess.Rows[counter1]["Enabled"] = false;
				}
				else
				{
					if((int)this.dsOrgsAccountAccess1.OrgAccountsAccess.Rows[counter1]["OrgsAccountsID"] == (int)this.dsUserOrgsAccounts1.UserOrgsAccounts.Rows[counterindex]["OrgsAccountsID"])
					{
						this.dsOrgsAccountAccess1.OrgAccountsAccess.Rows[counter1]["Enabled"] = true;
						counterindex ++;
					}
					else
					{
						this.dsOrgsAccountAccess1.OrgAccountsAccess.Rows[counter1]["Enabled"] = false;
					}
				}
				this.dsOrgsAccountAccess1.OrgAccountsAccess.Rows[counter1].AcceptChanges();
			}
		}

		private void SaveChanges()
		{
			bool bAllOK = true;
			sqlcmdDelUserOrgAccountsAccess.Connection.Open();
			SqlTransaction tran = sqlcmdDelUserOrgAccountsAccess.Connection.BeginTransaction();
			try
			{
				for(int counter = 0; counter < this.dvOrgsAccount.Count; counter ++)
				{
					sqlcmdDelUserOrgAccountsAccess.Transaction = tran;
					sqlcmdDelUserOrgAccountsAccess.Parameters["@UserID"].Value = CurrentUserID;
					sqlcmdDelUserOrgAccountsAccess.Parameters["@OrgsAccountsID"].Value = dvOrgsAccount[counter].Row["OrgsAccountsID"];
					sqlcmdDelUserOrgAccountsAccess.ExecuteNonQuery();
				}
				for(int counter = 0; counter < this.dvOrgsAccount.Count; counter ++)
				{
					if((bool)this.dvOrgsAccount[counter].Row["Enabled"])
					{
						sqlcmdAddUserOrgAccountsAccess.Transaction = tran;
						sqlcmdAddUserOrgAccountsAccess.Parameters["@UserID"].Value = CurrentUserID;
						sqlcmdAddUserOrgAccountsAccess.Parameters["@OrgsAccountsID"].Value = (int)this.dvOrgsAccount[counter].Row["OrgsAccountsID"];
						sqlcmdAddUserOrgAccountsAccess.ExecuteNonQuery();
					}
				}
				tran.Commit();
			}
			catch(Exception ex)
			{
				bAllOK = false;
				try
				{
					sqlcmdDelUserOrgAccountsAccess.Transaction.Rollback();
				}
				catch(Exception excep)
				{
					MessageBox.Show("Failed to rollback transaction\n" + excep.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				MessageBox.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				this.sqlcmdDelUserOrgAccountsAccess.Connection.Close();
			}
			if(bAllOK)
			{
				this.dsOrgsAccountAccess1.AcceptChanges();
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SaveChanges();
			Close();
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
