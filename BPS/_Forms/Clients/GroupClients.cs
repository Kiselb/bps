using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace BPS._Forms.Clients
{
	public delegate void ClientIDChangedEventHandler(object sender, EventArgs e);

	public class GroupClients : AM_Controls.GroupMembers
	{
		private System.Windows.Forms.Button btnAddClient;
		private System.ComponentModel.IContainer components = null;
		private int FourthSpaceWidth = 10;

		/// <summary>
		/// Расстояние между правой границей combobox'a членов групп и левой 
		/// границей кнопки добавления нового клиента
		/// </summary>
		[Category("_Layout"), Description("Расстояние между правой границей combobox'a членов групп и левой границей кнопки добавления нового клиента")]
		public int _FourthSpaceWidth
		{
			get
			{
				return this.FourthSpaceWidth;
			}
			set
			{
				this.FourthSpaceWidth = value;
				this.SetControlsPositions(null, null);
			}
		}
		
		/// <summary>
		/// Событие, возникающее при изменении активного клиента
		/// </summary>
		[Category("Property Changed"), Description("Событие, возникающее при изменении активного клиента")]
		public event ClientIDChangedEventHandler ClientIDChanged;

		public GroupClients()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GroupClients));
			this.btnAddClient = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dvGroups)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvMembers)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbGroups
			// 
			this.cmbGroups.ItemHeight = 13;
			this.cmbGroups.Name = "cmbGroups";
			// 
			// cmbMembers
			// 
			this.cmbMembers.ItemHeight = 13;
			this.cmbMembers.Location = new System.Drawing.Point(280, 2);
			this.cmbMembers.Name = "cmbMembers";
			this.cmbMembers.LocationChanged += new System.EventHandler(this.cmbMembers_LocationChanged);
			this.cmbMembers.SelectedIndexChanged += new System.EventHandler(this.cmbMembers_SelectedIndexChanged);
			// 
			// btnAddClient
			// 
			this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddClient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddClient.Image")));
			this.btnAddClient.Location = new System.Drawing.Point(408, 2);
			this.btnAddClient.Name = "btnAddClient";
			this.btnAddClient.Size = new System.Drawing.Size(24, 21);
			this.btnAddClient.TabIndex = 5;
			this.btnAddClient.TabStop = false;
			this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
			// 
			// GroupClients
			// 
			this.Controls.Add(this.btnAddClient);
			this.Name = "GroupClients";
			this.Size = new System.Drawing.Size(436, 30);
			this.Load += new System.EventHandler(this.GroupClients_Load);
			this.Controls.SetChildIndex(this.btnAddClient, 0);
			this.Controls.SetChildIndex(this.cmbGroups, 0);
			this.Controls.SetChildIndex(this.cmbMembers, 0);
			((System.ComponentModel.ISupportInitialize)(this.dvGroups)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvMembers)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void AddGroup()
		{
		
		}
		
		private bool bUsageForFilter = false;

		[Category("_Behaviour"), Description("")]
		public bool __UsageForFilter
		{
			set { bUsageForFilter=value; }
			get { return bUsageForFilter; }
		}

		private void btnAddClient_Click(object sender, System.EventArgs e)
		{
			BPS.BLL.Clients.coInterestRates InterestRates = new BPS.BLL.Clients.coInterestRates();
			InterestRates.FillDSReqType();
			System.Data.DataView dvRates = new System.Data.DataView(InterestRates.DsInterestRates.InterestRate);
			dvRates.AllowDelete = 
				dvRates.AllowNew = false;
			dvRates.AllowEdit = true;
			BPS._Forms.Clients.AddClient AddClientForm = new BPS._Forms.Clients.AddClient(base.dvGroups, dvRates);
			if(this.cmbGroups.SelectedIndex == -1 || this.cmbMembers.SelectedIndex == -1)
			{
				AddClientForm.tbClient.Text = this.cmbMembers.Text;
				AddClientForm.cmbGroup.Text = this.cmbGroups.Text;
			}
			AddClientForm.AddGroup += new BPS._Forms.Clients.AddClient.AddGroupEventHandler(AddGroup);
			AddClientForm.ShowDialog();
			if(AddClientForm.DialogResult == DialogResult.OK)
			{
				try
				{
					BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dvMembers.Table.NewRow();
					rw.ClientGroupID = (int)AddClientForm.cmbGroup.SelectedValue;
					rw.ClientName = AddClientForm.tbClient.Text;
					rw.ClientRemarks = AddClientForm.tbRemarks.Text;
					rw.IsInner = false;
					rw.IsSpecial = false;
					rw.Password = AddClientForm.tbPassw.Text;
					this.dvMembers.Table.Rows.Add(rw);
					App.BPSClients.UpdateGroups();
					App.BPSClients.UpdateClients();
					this.cmbGroups.SelectedIndex = this.dvGroups.Find(rw.ClientGroupID);
					this.cmbMembers.SelectedIndex = this.dvMembers.Find(rw.ClientID);
				} 
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void GroupClients_Load(object sender, System.EventArgs e)
		{
			if(!DesignMode)
			{
				((System.ComponentModel.ISupportInitialize)(this.dvGroups)).BeginInit();
				base.SettingValueNow = true;
				this._GroupsTable = App.BPSClients.DsGroups.ClientsGroups.Copy();
				((System.ComponentModel.ISupportInitialize)(this.dvGroups)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.dvMembers)).BeginInit();
				base.SettingValueNow = true;
				this._MembersTable = App.BPSClients.DsClients.Clients.Copy();
				((System.ComponentModel.ISupportInitialize)(this.dvMembers)).EndInit();
				base.SettingValueNow = true;
				this._GroupIDColunmName = "ClientGroupID";
				base.SettingValueNow = true;
				this._GroupNameColumnName = "ClientGroupName";
				base.SettingValueNow = true;
				this._MemberIDColumnName = "ClientID";
				base.SettingValueNow = true;
				this._MemberNameColumnName = "ClientName";
				base.SettingValueNow = true;
				this._MembersGroupColumnName = "ClientGroupID";
				this.dvGroups.Sort = "ClientGroupID ASC";
				this.dvMembers.Sort = "ClientID ASC";
				this.dvGroups.AllowNew = true;
				AddAllRow(0, false);
				AddAllRow(-1, true);
				if (bUsageForFilter) 
				{
					BPS.BLL.Clients.DataSets.dsClients.ClientsRow rwClient = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dvMembers.Table.NewRow();
					rwClient.ClientID = 0;
					rwClient.ClientGroupID = -1;
					rwClient.ClientName= "<Все>";
					rwClient.ClientRemarks = "<Все>";
					rwClient.ClientGroupName="";
					this.dvMembers.Table.Rows.Add(rwClient);
				}
			}
			this.BehaviourChanged += new AM_Controls.BehaviourChangedEventHandler(this.SetControlsPositions);
		}

		private void AddAllRow(int identifier, bool condition)
		{
			BPS.BLL.Clients.DataSets.dsGroups.ClientsGroupsRow rw = (BPS.BLL.Clients.DataSets.dsGroups.ClientsGroupsRow)this.dvGroups.Table.NewRow();
			rw.ClientGroupID = identifier;
			rw.ClientGroupName = "<Все>";
			rw.ClientGroupRemarks = "<Все>";
			rw.IsInner = condition;
			rw.IsSpecial = condition;
			this.dvGroups.Table.Rows.Add(rw);
		}

		private void RemoveAllRow()
		{
			System.Data.DataRow[] drs = this.dvGroups.Table.Select(this._GroupIDColunmName + " = 0");
				if(drs.Length == 1)
				{
					this.dvGroups.Table.Rows.Remove(drs[0]);
				}
		}

		/// <summary>
		/// Check for set of all 
		/// </summary>
		/// <returns>
		/// true	- All required properties set
		/// false	- Not all required properties set
		/// </returns>
		private bool CheckAllPropertiesSet()
		{
			if(this._GroupsTable == null || 
				this._GroupIDColunmName == string.Empty ||
				this._GroupNameColumnName == string.Empty ||
				this._MembersTable == null ||
				this._MemberIDColumnName == string.Empty ||
				this._MemberNameColumnName == string.Empty ||
				this._MembersGroupColumnName == string.Empty)
				return false;
			return true;
		}

		private void cmbMembers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ClientIDChanged != null && CheckAllPropertiesSet())
			{
				ClientIDChanged(this, e);
			}
		}

		public void SetControlsPositions(object sender, EventArgs e)
		{
			base.EventSet = true;
			base.SetControlsPositions();
			this.btnAddClient.Left = this.cmbMembers.Location.X + this.cmbMembers.Width + FourthSpaceWidth;
			base.EventSet = false;
		}

		private void cmbMembers_LocationChanged(object sender, System.EventArgs e)
		{
			if(!DesignMode)
			{
				// можно было просто привязать кнопку к cmbMembers 
				this.btnAddClient.Left = this.cmbMembers.Location.X + this.cmbMembers.Width + FourthSpaceWidth;
			}
		}

	}
}

