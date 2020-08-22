using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for AccountStatementNewHeader.
	/// </summary>
	public class AccountStatementNewHeader : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpExtractDate;
		private System.Windows.Forms.Button bnOk;
		private System.Windows.Forms.Button bnCancel;
		private System.Data.DataView dvOrgs;
		private System.Data.DataView dvOrgsAccounts;
		private System.Windows.Forms.ComboBox cmbOrgsAccounts;
		private System.Windows.Forms.ComboBox cmbOrgs;
		private int iHeaderID;
		private BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts dsUsersOrgsAndAccounts1;
		private BPS.BLL.Orgs.UsersOrgsAndAccounts bll = new BPS.BLL.Orgs.UsersOrgsAndAccounts();

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		

		public AccountStatementNewHeader()
		{
			//
			// Required for Windows Form Designer support
			//
			App.FillOrgsAccount();
			InitializeComponent();
/*
  			this.dvOrgs.Table = App.DsOrgs.Orgs;
			this.cmbOrgs.DataSource = this.dvOrgs;
			this.cmbOrgs.DisplayMember = "OrgName";
			this.cmbOrgs.ValueMember = "OrgID";
			this.dvOrgs.RowFilter = "IsInner=true";
			this.dvOrgsAccounts.Table = App.DsOrgsAccount._Table;
			this.cmbOrgsAccounts.DataSource = this.dvOrgsAccounts;
			this.cmbOrgsAccounts.DisplayMember = "RAccount";
			this.cmbOrgsAccounts.ValueMember = "AccountID";
*/
			bll.Fill(App.UserLogonID);
			this.dsUsersOrgsAndAccounts1 = bll.DataSet;
			this.dvOrgs.Table = this.dsUsersOrgsAndAccounts1.Orgs;
			this.dvOrgs.Sort="OrgName";
			this.dvOrgsAccounts.Table = this.dsUsersOrgsAndAccounts1.OrgsAccounts;
			this.dvOrgsAccounts.Sort="RAccount";
		}

		private void AccountStatementNewHeader_Load(object sender, System.EventArgs e)
		{
			this.dtpExtractDate.Value = this.setHeaderDate(DateTime.Now.Date);
			if (cmbOrgs.Items.Count>0)
				cmbOrgs.SelectedIndex=0;
			cmbOrgs_SelectedIndexChanged(null,null);
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
		public DateTime HeaderDate
		{
			get
			{
				return this.dtpExtractDate.Value;
			}
		}
		public int OrgID
		{
			get
			{
				if(this.cmbOrgs.SelectedIndex>-1)
					return Convert.ToInt32(this.cmbOrgs.SelectedValue);
				else return -1;
			}
		}
		public int OrgAccountID
		{
			get
			{
				if(this.cmbOrgsAccounts.SelectedIndex>-1)
					return Convert.ToInt32(this.cmbOrgsAccounts.SelectedValue);
				else return -1;
			}
		}
		public int HeaderID
		{
			get
			{
				return this.iHeaderID;
			}
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AccountStatementNewHeader));
			this.cmbOrgsAccounts = new System.Windows.Forms.ComboBox();
			this.dvOrgsAccounts = new System.Data.DataView();
			this.dsUsersOrgsAndAccounts1 = new BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbOrgs = new System.Windows.Forms.ComboBox();
			this.dvOrgs = new System.Data.DataView();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpExtractDate = new System.Windows.Forms.DateTimePicker();
			this.bnOk = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsAccounts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbOrgsAccounts
			// 
			this.cmbOrgsAccounts.DataSource = this.dvOrgsAccounts;
			this.cmbOrgsAccounts.DisplayMember = "RAccount";
			this.cmbOrgsAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOrgsAccounts.Location = new System.Drawing.Point(86, 24);
			this.cmbOrgsAccounts.Name = "cmbOrgsAccounts";
			this.cmbOrgsAccounts.Size = new System.Drawing.Size(164, 21);
			this.cmbOrgsAccounts.TabIndex = 2;
			this.cmbOrgsAccounts.ValueMember = "OrgsAccountID";
			// 
			// dvOrgsAccounts
			// 
			this.dvOrgsAccounts.Table = this.dsUsersOrgsAndAccounts1.OrgsAccounts;
			// 
			// dsUsersOrgsAndAccounts1
			// 
			this.dsUsersOrgsAndAccounts1.DataSetName = "dsUsersOrgsAndAccounts";
			this.dsUsersOrgsAndAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Р/счёт:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbOrgs
			// 
			this.cmbOrgs.DataSource = this.dvOrgs;
			this.cmbOrgs.DisplayMember = "OrgName";
			this.cmbOrgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOrgs.Location = new System.Drawing.Point(86, 2);
			this.cmbOrgs.MaxDropDownItems = 20;
			this.cmbOrgs.Name = "cmbOrgs";
			this.cmbOrgs.Size = new System.Drawing.Size(164, 21);
			this.cmbOrgs.TabIndex = 1;
			this.cmbOrgs.ValueMember = "OrgID";
			this.cmbOrgs.SelectedIndexChanged += new System.EventHandler(this.cmbOrgs_SelectedIndexChanged);
			// 
			// dvOrgs
			// 
			this.dvOrgs.Table = this.dsUsersOrgsAndAccounts1.Orgs;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Организация:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(258, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Дата:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpExtractDate
			// 
			this.dtpExtractDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpExtractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpExtractDate.Location = new System.Drawing.Point(298, 2);
			this.dtpExtractDate.Name = "dtpExtractDate";
			this.dtpExtractDate.Size = new System.Drawing.Size(84, 21);
			this.dtpExtractDate.TabIndex = 3;
			// 
			// bnOk
			// 
			this.bnOk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOk.Location = new System.Drawing.Point(210, 56);
			this.bnOk.Name = "bnOk";
			this.bnOk.Size = new System.Drawing.Size(84, 26);
			this.bnOk.TabIndex = 4;
			this.bnOk.Text = "Создать";
			this.bnOk.Click += new System.EventHandler(this.bnOk_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(296, 56);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(84, 26);
			this.bnCancel.TabIndex = 5;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// AccountStatementNewHeader
			// 
			this.AcceptButton = this.bnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(388, 89);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.bnOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtpExtractDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbOrgs);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbOrgsAccounts);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AccountStatementNewHeader";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Создание новой банковской выписки";
			this.Load += new System.EventHandler(this.AccountStatementNewHeader_Load);
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsAccounts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbOrgs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.cmbOrgs.SelectedIndex>-1)
				this.dvOrgsAccounts.RowFilter = "OrgID=" + this.cmbOrgs.SelectedValue.ToString();
		}

		private void bnOk_Click(object sender, System.EventArgs e)
		{
			if(this.cmbOrgsAccounts.SelectedIndex>-1)
			{
				SqlCommand cmdInsHeader = new SqlCommand("[CheckAccountStatementHeader]", App.Connection);
				cmdInsHeader.CommandType = CommandType.StoredProcedure;
				cmdInsHeader.Parameters.Add(new SqlParameter("@OrgAccountID", SqlDbType.Int));
				cmdInsHeader.Parameters.Add(new SqlParameter("@HeaderDate", SqlDbType.DateTime));
				cmdInsHeader.Parameters.Add(new SqlParameter("@HeaderID", SqlDbType.Int));
				cmdInsHeader.Parameters["@HeaderID"].Direction = ParameterDirection.Output;
				cmdInsHeader.Parameters["@OrgAccountID"].Value = Convert.ToInt32(this.dvOrgsAccounts[this.cmbOrgsAccounts.SelectedIndex]["OrgsAccountsID"]);
				cmdInsHeader.Parameters["@HeaderDate"].Value = this.dtpExtractDate.Value.Date;
				try
				{
					App.Connection.Open();
					cmdInsHeader.ExecuteNonQuery();
					object o = cmdInsHeader.Parameters["@HeaderID"].Value;
					if(o != Convert.DBNull)
					{
						iHeaderID = Convert.ToInt32(o);
					}
					else
					{
						AM_Controls.MsgBoxX.Show("Во время выполнения программы произошла ошибка. Повторите создание выписки позже.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.Close();
					}
					if(this.iHeaderID == -1)
					{
						AM_Controls.MsgBoxX.Show("Во время выполнения программы произошла ошибка. Повторите создание выписки позже.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.Close();
					}
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				finally
				{
					App.Connection.Close();
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			return;
		}

		private DateTime setHeaderDate(DateTime dt)
		{
			if(dt.AddDays(-1).DayOfWeek == DayOfWeek.Saturday || dt.AddDays(-1).DayOfWeek == DayOfWeek.Sunday)
				return this.setHeaderDate(dt.AddDays(-1));
			else return dt.AddDays(-1);
		}
	}
}
