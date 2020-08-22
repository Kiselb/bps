using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace BPS._Controls
{
	/// <summary>
	/// Summary description for OrgsAndAccounts.
	/// </summary>
	public class OrgsAndAccounts : System.Windows.Forms.UserControl
	{
		private BPS.BLL.Orgs.UsersOrgsAndAccounts bll;

		private System.Windows.Forms.ComboBox cmbRAccount;
		private System.Windows.Forms.ComboBox cmbOrg;
		private BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts dsUsersOrgsAndAccounts1;
		private System.Data.DataView dvRAccount;
		private System.Data.DataView dvOrgs;
		private System.Windows.Forms.Panel pnlOrg;
		private System.Windows.Forms.Panel pnlAccount;
		private System.Windows.Forms.Label lblAccountHeader;
		private System.Windows.Forms.Label lblOrgHeader;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public OrgsAndAccounts()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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

		
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmbRAccount = new System.Windows.Forms.ComboBox();
			this.dvRAccount = new System.Data.DataView();
			this.dsUsersOrgsAndAccounts1 = new BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts();
			this.lblAccountHeader = new System.Windows.Forms.Label();
			this.cmbOrg = new System.Windows.Forms.ComboBox();
			this.dvOrgs = new System.Data.DataView();
			this.lblOrgHeader = new System.Windows.Forms.Label();
			this.pnlOrg = new System.Windows.Forms.Panel();
			this.pnlAccount = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dvRAccount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).BeginInit();
			this.pnlOrg.SuspendLayout();
			this.pnlAccount.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbRAccount
			// 
			this.cmbRAccount.DataSource = this.dvRAccount;
			this.cmbRAccount.DisplayMember = "RAccount";
			this.cmbRAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRAccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cmbRAccount.Location = new System.Drawing.Point(27, 2);
			this.cmbRAccount.Name = "cmbRAccount";
			this.cmbRAccount.Size = new System.Drawing.Size(150, 21);
			this.cmbRAccount.TabIndex = 7;
			this.cmbRAccount.ValueMember = "OrgsAccountsID";
			this.cmbRAccount.SelectedIndexChanged += new System.EventHandler(this.cmbRAccount_SelectedIndexChanged);
			// 
			// dvRAccount
			// 
			this.dvRAccount.Table = this.dsUsersOrgsAndAccounts1.OrgsAccounts;
			// 
			// dsUsersOrgsAndAccounts1
			// 
			this.dsUsersOrgsAndAccounts1.DataSetName = "dsUsersOrgsAndAccounts";
			this.dsUsersOrgsAndAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// lblAccountHeader
			// 
			this.lblAccountHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lblAccountHeader.Location = new System.Drawing.Point(0, 5);
			this.lblAccountHeader.Name = "lblAccountHeader";
			this.lblAccountHeader.Size = new System.Drawing.Size(26, 14);
			this.lblAccountHeader.TabIndex = 8;
			this.lblAccountHeader.Text = "Р/C:";
			this.lblAccountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbOrg
			// 
			this.cmbOrg.DataSource = this.dvOrgs;
			this.cmbOrg.DisplayMember = "OrgName";
			this.cmbOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOrg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cmbOrg.Location = new System.Drawing.Point(77, 2);
			this.cmbOrg.MaxDropDownItems = 20;
			this.cmbOrg.Name = "cmbOrg";
			this.cmbOrg.Size = new System.Drawing.Size(150, 21);
			this.cmbOrg.TabIndex = 5;
			this.cmbOrg.ValueMember = "OrgID";
			this.cmbOrg.SelectedIndexChanged += new System.EventHandler(this.cmbOrg_SelectedIndexChanged);
			// 
			// dvOrgs
			// 
			this.dvOrgs.Table = this.dsUsersOrgsAndAccounts1.Orgs;
			// 
			// lblOrgHeader
			// 
			this.lblOrgHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lblOrgHeader.Location = new System.Drawing.Point(0, 5);
			this.lblOrgHeader.Name = "lblOrgHeader";
			this.lblOrgHeader.Size = new System.Drawing.Size(76, 14);
			this.lblOrgHeader.TabIndex = 6;
			this.lblOrgHeader.Text = "Организация:";
			this.lblOrgHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlOrg
			// 
			this.pnlOrg.Controls.Add(this.cmbOrg);
			this.pnlOrg.Controls.Add(this.lblOrgHeader);
			this.pnlOrg.Location = new System.Drawing.Point(0, 0);
			this.pnlOrg.Name = "pnlOrg";
			this.pnlOrg.Size = new System.Drawing.Size(227, 24);
			this.pnlOrg.TabIndex = 9;
			// 
			// pnlAccount
			// 
			this.pnlAccount.Controls.Add(this.lblAccountHeader);
			this.pnlAccount.Controls.Add(this.cmbRAccount);
			this.pnlAccount.Location = new System.Drawing.Point(235, 0);
			this.pnlAccount.Name = "pnlAccount";
			this.pnlAccount.Size = new System.Drawing.Size(179, 24);
			this.pnlAccount.TabIndex = 10;
			// 
			// OrgsAndAccounts
			// 
			this.Controls.Add(this.pnlAccount);
			this.Controls.Add(this.pnlOrg);
			this.Name = "OrgsAndAccounts";
			this.Size = new System.Drawing.Size(418, 26);
			this.SizeChanged += new System.EventHandler(this.OrgsAndAccounts_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dvRAccount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgs)).EndInit();
			this.pnlOrg.ResumeLayout(false);
			this.pnlAccount.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		#region Инициализация DataSource ComboBox'ов
		public void Init()
		{
			bll = new BPS.BLL.Orgs.UsersOrgsAndAccounts(App.Connection);
			bll.Fill( App.UserLogonID );
			Init(bll);
		}

		public void Init(BPS.BLL.Orgs.UsersOrgsAndAccounts bll )
		{
			this.dvOrgs.Table = bll.DataSet.Orgs.Copy();
			if (this.dvOrgs.Table.Rows.Count>1) 
			{
				DataRow dr = this.dvOrgs.Table.NewRow();
				dr["OrgID"] = 0;
				dr["OrgName"] = "<Все>";
				this.dvOrgs.Table.Rows.Add(dr);
			}
			this.dvOrgs.Sort = "OrgName";
			this.cmbOrg.DataSource = this.dvOrgs;
			this.dvRAccount.Table = bll.DataSet.OrgsAccounts.Copy();
			if (this.dvRAccount.Table.Rows.Count>1)
			{
				DataRow dr = this.dvRAccount.Table.NewRow();
				dr["OrgsAccountsID"] = 0;
				dr["AccountID"] = 0;
				dr["OrgID"] = 0;
				dr["RAccount"] = "<Все>";
				this.dvRAccount.Table.Rows.Add(dr);
			}
			this.dvRAccount.Sort = "RAccount";
			this.cmbRAccount.DataSource = this.dvRAccount;
			this.cmbRAccount.DisplayMember = "RAccount";
			this.cmbRAccount.ValueMember = "OrgsAccountsID";
			this.SetFilterForRAccount();
		}
		#endregion

		
		
		#region Private Functions And Controls Event Handlers

		private void cmbOrg_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.SetFilterForRAccount();
		}

		private void SetFilterForRAccount()
		{
			if(this.cmbOrg.SelectedValue!=null && Convert.ToInt32(this.cmbOrg.SelectedValue)!=0)
			{
				this.dvRAccount.RowFilter = "OrgID=" + this.cmbOrg.SelectedValue.ToString() + " or OrgID=0";
				if(this.dvRAccount.Count == 2)	// <Все> + один р.счет
				{
					this.dvRAccount.RowFilter = "OrgID=" + this.cmbOrg.SelectedValue.ToString();
				}
			} 
			else
			{
				this.dvRAccount.RowFilter = "";
			}

			if(this.dvRAccount.Count == 0)
				this.cmbRAccount.Text = "";
			this.cmbRAccount_SelectedIndexChanged( null, null);
		}

		private void cmbRAccount_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (OrgsAcoountIDChanged!=null)
				OrgsAcoountIDChanged(this,e);
		}

		#endregion

		private bool bVertical=false;
		private void SetControlsPositions()
		{
			if (bVertical) 
			{
				this.pnlAccount.Top = this.pnlOrg.Top + this.pnlOrg.Height;
				this.pnlAccount.Left = this.pnlOrg.Left;
				this.pnlAccount.Width =this.pnlOrg.Size.Width;
				this.cmbRAccount.Left=this.cmbOrg.Left; 
			}
			else
			{
				this.pnlAccount.Top = this.pnlOrg.Top;
				this.pnlAccount.Left = this.pnlOrg.Left + this.pnlOrg.Width +8;
				this.cmbRAccount.Left=3 +this.lblAccountHeader.Size.Width +3;
				this.pnlAccount.Width = this.cmbRAccount.Left +this.cmbRAccount.Size.Width +3;
			}
		}

		private void OrgsAndAccounts_SizeChanged(object sender, System.EventArgs e)
		{
			bVertical = (this.Height >= (this.pnlOrg.Height + 2)*2)  ;
			SetControlsPositions();		
		}



		#region События

		public delegate void OrgsAcoountIDChangedEventHandler (object sender, EventArgs e);
		public event OrgsAcoountIDChangedEventHandler OrgsAcoountIDChanged;


		#endregion

		#region Свойства
		public int OrgID
		{
			get {return this.cmbOrg.SelectedValue==null ? 0: Convert.ToInt32(this.cmbOrg.SelectedValue);}
			set {this.cmbOrg.SelectedValue=value;}
		}
		public int OrgAccountID
		{
			get {return this.cmbRAccount.SelectedValue==null ? 0: Convert.ToInt32(this.cmbRAccount.SelectedValue);}
			set {this.cmbRAccount.SelectedValue=value;}
		}
		public string OrgAccountName 
		{
			get {return this.cmbRAccount.SelectedValue==null ? "": this.cmbRAccount.Text;}
		}

		#endregion
	}
}
