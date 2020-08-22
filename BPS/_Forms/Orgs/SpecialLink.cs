using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BPS._Forms.Orgs
{
	/// <summary>
	/// Summary description for SpecialLink.
	/// </summary>
	public class SpecialLink : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button bnSelect;
		private System.Windows.Forms.Button bnNew;
		private System.Windows.Forms.Button bnCancel;
		private System.Data.DataView dvClientList;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private int iClientID=-1;
		private string szOrgName;
		private string szClientName;
		public string ClientName
		{
			get
			{
				return this.szClientName;
			}
		}
		public string OrgName
		{
			set
			{
				this.szOrgName = value;
			}
		}
		public int ClientID
		{
			get
			{
				return this.iClientID;
			}
			set
			{
				this.iClientID = value;
				
			}
		}
		public SpecialLink()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			this.dvClientList.Table = App.DsClients.Clients;
			this.dvClientList.RowFilter = "IsSpecial=true";
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SpecialLink));
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvClientList = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bnCancel = new System.Windows.Forms.Button();
			this.bnNew = new System.Windows.Forms.Button();
			this.bnSelect = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientList)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.groupBox1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(404, 64);
			this.panel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label1});
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(404, 64);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(398, 44);
			this.label1.TabIndex = 0;
			this.label1.Text = "При нажатии кнопки <Выбрать> организация будет связана с выделенным клиентом. При" +
				" нажатии на кнопку <Новый> будет создан новый специальный клиент и организация б" +
				"удет связана с ним.";
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvClientList;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(404, 177);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Clients";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "ID";
			this.dataGridTextBoxColumn1.MappingName = "ClientID";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Имя";
			this.dataGridTextBoxColumn2.MappingName = "ClientName";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Примечание";
			this.dataGridTextBoxColumn3.MappingName = "ClientRemarks";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 160;
			// 
			// panel2
			// 
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.bnCancel,
																				 this.bnNew,
																				 this.bnSelect});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 241);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(404, 32);
			this.panel2.TabIndex = 2;
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(326, 6);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.TabIndex = 2;
			this.bnCancel.Text = "Отмена";
			// 
			// bnNew
			// 
			this.bnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnNew.Location = new System.Drawing.Point(244, 6);
			this.bnNew.Name = "bnNew";
			this.bnNew.TabIndex = 1;
			this.bnNew.Text = "Новый";
			this.bnNew.Click += new System.EventHandler(this.bnNew_Click);
			// 
			// bnSelect
			// 
			this.bnSelect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnSelect.Location = new System.Drawing.Point(168, 6);
			this.bnSelect.Name = "bnSelect";
			this.bnSelect.TabIndex = 0;
			this.bnSelect.Text = "Выбрать";
			this.bnSelect.Click += new System.EventHandler(this.bnSelect_Click);
			// 
			// SpecialLink
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(404, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid1,
																		  this.panel2,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SpecialLink";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Выбор специального клиента";
			this.Load += new System.EventHandler(this.SpecialLink_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientList)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void bnSelect_Click(object sender, System.EventArgs e)
		{
			BindingManagerBase bm = this.BindingContext[this.dvClientList];
			if(bm.Position < 0)
				return;
			BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow) ((DataRowView) bm.Current).Row;
			this.iClientID = rw.ClientID;
			this.szClientName = rw.ClientName;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bnNew_Click(object sender, System.EventArgs e)
		{
			AddSpecialClients asc = new AddSpecialClients();
			asc.ShowDialog();
			if(asc.DialogResult == DialogResult.OK)
			{
				SqlCommand cmdCreateClients = new SqlCommand("[CreateIsSpecialClient]", App.Connection);
				cmdCreateClients.CommandType = CommandType.StoredProcedure;
				cmdCreateClients.Parameters.Add(new SqlParameter("@ClientName", SqlDbType.NVarChar));
				cmdCreateClients.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.Int));
				cmdCreateClients.Parameters["@ClientName"].Value = asc.ClientName;//this.szOrgName;
				cmdCreateClients.Parameters["@ClientID"].Direction = ParameterDirection.Output;
				try
				{
					App.Connection.Open();
					cmdCreateClients.ExecuteNonQuery();
					object o = cmdCreateClients.Parameters["@ClientID"].Value;
					if(o == Convert.DBNull)
					{
						AM_Controls.MsgBoxX.Show("Ошибка создания специального клиента.");
						this.iClientID = -1;
					}
					else
					{
						this.iClientID = (int) o;
						this.szClientName = asc.ClientName;
					}
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message);
				}
				finally
				{
					App.Connection.Close();
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}else
				return;
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.bnSelect.PerformClick();
		}

		private void SpecialLink_Load(object sender, System.EventArgs e)
		{
			if(this.ClientID>0)
			{
				for(int i = 0; i<this.dvClientList.Count; i++)
				{
					if(Convert.ToInt32(this.dvClientList[i].Row["ClientID"]) == this.iClientID)
						this.BindingContext[this.dvClientList].Position = i;
				}
			}
		}

		
		
	}
}
