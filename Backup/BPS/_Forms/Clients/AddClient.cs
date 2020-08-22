using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Controls;

namespace BPS._Forms.Clients
{
	/// <summary>
	/// Summary description for AddClient.
	/// </summary>
	public class AddClient : System.Windows.Forms.Form
	{
		public delegate void AddGroupEventHandler();
		public event AddGroupEventHandler AddGroup;
		internal System.Windows.Forms.ComboBox cmbGroup;
		internal System.Windows.Forms.TextBox tbClient;
		internal System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btAddGroup;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		internal System.Data.DataView dvClientRate;
		internal System.Windows.Forms.TextBox tbPassw;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox tbConfirmPassw;
		private System.Windows.Forms.Label label5;
		private BPS.BLL.Clients.DataSets.dsInterestRate dsInterestRate1;
		private BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataGrid dgSendFrom;
		private BPS.BLL.Clients.DataSets.dsOrgsClients dsOrgsClients1;
		private System.Data.DataView dvSend;
		private System.Data.DataView dvReceive;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private DataView dvGroups;
		public AddClient(DataView dv, DataView dvRate)
		{
			//
			// Required for Windows Form Designer support
			//
			this.dvGroups = dv;
			InitializeComponent();
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle1);
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle2);
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle3);
			try
			{
				this.dataGrid1.DataSource = dvRate;
				this.dvGroups.RowFilter = "(IsInner=false and IsSpecial=false)";
				this.cmbGroup.DataSource = this.dvGroups;//dv.Table;// this.dsGroups1.Tables[0];
				this.cmbGroup.ValueMember = "ClientGroupID";
				this.cmbGroup.DisplayMember = "ClientGroupName";
				if(this.cmbGroup.Items.Count>0)
					this.cmbGroup.SelectedIndex = 0;

				this.tabControl1.Controls.Remove(this.tabPage2);
				this.tabControl1.Controls.Remove(this.tabPage3);
			}
			catch(Exception ex)
			{
				MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public AddClient(BPS.BLL.Clients.DataSets.dsClients.ClientsRow dr, DataView dv, DataView dvRate, BPS.BLL.Clients.DataSets.dsOrgsClients dsOrgsClientsEd)
		{
			this.dvGroups = dv;
			rw = dr;
			InitializeComponent();
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle1);
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle2);
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle3);
			try
			{
				//this.sqlDataAdapter2.Fill(this.dsGroups1);
				this.cmbGroup.DataSource = this.dvGroups;//dv.Table;//this.dsGroups1.Tables[0];
				this.cmbGroup.ValueMember = "ClientGroupID";
				this.cmbGroup.DisplayMember = "ClientGroupName";
				this.cmbGroup.SelectedValue = dr.ClientGroupID;//["ClientGroupID"];
				this.tbClient.Text = dr.ClientName;//["ClientName"].ToString();
				this.tbRemarks.Text = dr.ClientRemarks;//["ClientRemarks"].ToString();
				//this.cbSpecial.Checked = dr.IsSpecial;
				this.dataGrid1.DataSource = dvRate;
				if(dr.IsInner || dr.IsSpecial)
					this.cmbGroup.Enabled = false;
				else
					dv.RowFilter = "IsInner=false and IsSpecial=false";
//				this.sqlSelectClientsOrgs.Parameters["@ClientID"].Value = dr.ClientID;
//				this.sqldaSelOrgsClients.Fill(this.dsOrgsClients1);
				this.dsOrgsClients1 = dsOrgsClientsEd;
				this.dvSend.Table = this.dsOrgsClients1.OrgsClients;
				this.dvSend.RowFilter="Direction=1 and IsRemoved=0";
				this.dvReceive.Table = this.dsOrgsClients1.OrgsClients;
				this.dvReceive.RowFilter="Direction=0 and IsRemoved=0";
			}
			catch(Exception ex)
			{
				MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			if(dr.IsInner || dr.IsSpecial)
				this.cmbGroup.Enabled = false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddClient));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.cmbGroup = new System.Windows.Forms.ComboBox();
			this.tbClient = new System.Windows.Forms.TextBox();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btAddGroup = new System.Windows.Forms.Button();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.dataView1 = new System.Data.DataView();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvClientRate = new System.Data.DataView();
			this.dsInterestRate1 = new BPS.BLL.Clients.DataSets.dsInterestRate();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tbPassw = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbConfirmPassw = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dgSendFrom = new System.Windows.Forms.DataGrid();
			this.dvSend = new System.Data.DataView();
			this.dsOrgsClients1 = new BPS.BLL.Clients.DataSets.dsOrgsClients();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.dvReceive = new System.Data.DataView();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRate1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSendFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvSend)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvReceive)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbGroup
			// 
			this.cmbGroup.Location = new System.Drawing.Point(86, 2);
			this.cmbGroup.Name = "cmbGroup";
			this.cmbGroup.Size = new System.Drawing.Size(160, 21);
			this.cmbGroup.TabIndex = 0;
			this.cmbGroup.Leave += new System.EventHandler(this.cmbGroup_Leave);
			// 
			// tbClient
			// 
			this.tbClient.Location = new System.Drawing.Point(86, 24);
			this.tbClient.Name = "tbClient";
			this.tbClient.Size = new System.Drawing.Size(344, 21);
			this.tbClient.TabIndex = 2;
			this.tbClient.Text = "";
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(86, 90);
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.Size = new System.Drawing.Size(344, 21);
			this.tbRemarks.TabIndex = 5;
			this.tbRemarks.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Группа:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Клиент:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Примечание:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btAddGroup
			// 
			this.btAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btAddGroup.Image = ((System.Drawing.Bitmap)(resources.GetObject("btAddGroup.Image")));
			this.btAddGroup.Location = new System.Drawing.Point(246, 2);
			this.btAddGroup.Name = "btAddGroup";
			this.btAddGroup.Size = new System.Drawing.Size(24, 21);
			this.btAddGroup.TabIndex = 1;
			this.btAddGroup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btAddGroup.Click += new System.EventHandler(this.btAddGroup_Click);
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(272, 360);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 8;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(354, 360);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 9;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT ClientGroupID, ClientGroupName, ClientGroupRemarks FROM ClientsGroups";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.dataGrid1.CaptionText = "Процентные ставки";
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvClientRate;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.ForeColor = System.Drawing.Color.Black;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.dataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid1.Size = new System.Drawing.Size(428, 202);
			this.dataGrid1.TabIndex = 7;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle2});
			// 
			// dvClientRate
			// 
			this.dvClientRate.AllowDelete = false;
			this.dvClientRate.AllowNew = false;
			this.dvClientRate.Table = this.dsInterestRate1.InterestRate;
			// 
			// dsInterestRate1
			// 
			this.dsInterestRate1.DataSetName = "dsInterestRate";
			this.dsInterestRate1.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsInterestRate1.Namespace = "http://tempuri.org/dsInterestRate.xsd";
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGrid1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "InterestRate";
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Тип операции";
			this.dataGridTextBoxColumn3.MappingName = "ReqTypeName";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 200;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn4.Format = "0.00";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "% Норм.";
			this.dataGridTextBoxColumn4.MappingName = "RateNormal";
			this.dataGridTextBoxColumn4.NullText = "-";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn5.Format = "0.00";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "% Black";
			this.dataGridTextBoxColumn5.MappingName = "RateBlack";
			this.dataGridTextBoxColumn5.NullText = "-";
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// tbPassw
			// 
			this.tbPassw.Location = new System.Drawing.Point(86, 46);
			this.tbPassw.MaxLength = 16;
			this.tbPassw.Name = "tbPassw";
			this.tbPassw.PasswordChar = '*';
			this.tbPassw.Size = new System.Drawing.Size(344, 21);
			this.tbPassw.TabIndex = 3;
			this.tbPassw.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Пароль:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbConfirmPassw
			// 
			this.tbConfirmPassw.Location = new System.Drawing.Point(86, 68);
			this.tbConfirmPassw.Name = "tbConfirmPassw";
			this.tbConfirmPassw.PasswordChar = '*';
			this.tbConfirmPassw.Size = new System.Drawing.Size(344, 21);
			this.tbConfirmPassw.TabIndex = 4;
			this.tbConfirmPassw.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "Подтвердить:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2,
																					  this.tabPage3});
			this.tabControl1.Location = new System.Drawing.Point(2, 122);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(436, 228);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.dataGrid1});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(428, 202);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "% Обслуживания";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.dgSendFrom});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(428, 202);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Отправка";
			// 
			// dgSendFrom
			// 
			this.dgSendFrom.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dgSendFrom.BackColor = System.Drawing.Color.DarkGray;
			this.dgSendFrom.CaptionBackColor = System.Drawing.Color.White;
			this.dgSendFrom.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dgSendFrom.CaptionForeColor = System.Drawing.Color.Navy;
			this.dgSendFrom.CaptionText = "Процентные ставки";
			this.dgSendFrom.CaptionVisible = false;
			this.dgSendFrom.DataMember = "";
			this.dgSendFrom.DataSource = this.dvSend;
			this.dgSendFrom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgSendFrom.ForeColor = System.Drawing.Color.Black;
			this.dgSendFrom.GridLineColor = System.Drawing.Color.Black;
			this.dgSendFrom.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dgSendFrom.HeaderBackColor = System.Drawing.Color.Silver;
			this.dgSendFrom.HeaderForeColor = System.Drawing.Color.Black;
			this.dgSendFrom.LinkColor = System.Drawing.Color.Navy;
			this.dgSendFrom.Name = "dgSendFrom";
			this.dgSendFrom.ParentRowsBackColor = System.Drawing.Color.White;
			this.dgSendFrom.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dgSendFrom.SelectionBackColor = System.Drawing.Color.Navy;
			this.dgSendFrom.SelectionForeColor = System.Drawing.Color.White;
			this.dgSendFrom.Size = new System.Drawing.Size(428, 202);
			this.dgSendFrom.TabIndex = 8;
			this.dgSendFrom.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			// 
			// dvSend
			// 
			this.dvSend.AllowDelete = false;
			this.dvSend.AllowNew = false;
			this.dvSend.RowFilter = "Direction=1";
			this.dvSend.Table = this.dsOrgsClients1.OrgsClients;
			// 
			// dsOrgsClients1
			// 
			this.dsOrgsClients1.DataSetName = "dsOrgsClients";
			this.dsOrgsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsOrgsClients1.Namespace = "http://www.tempuri.org/dsOrgsClients.xsd";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgSendFrom;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridBoolColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "OrgsClients";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Наименование";
			this.dataGridTextBoxColumn1.MappingName = "OrgName";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 150;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "ИНН";
			this.dataGridTextBoxColumn2.MappingName = "CodeINN";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 90;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = false;
			this.dataGridBoolColumn1.HeaderText = "Разрешено";
			this.dataGridBoolColumn1.MappingName = "IsAvailable";
			this.dataGridBoolColumn1.NullValue = ((System.DBNull)(resources.GetObject("dataGridBoolColumn1.NullValue")));
			this.dataGridBoolColumn1.TrueValue = true;
			this.dataGridBoolColumn1.Width = 75;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.dataGrid2});
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(428, 202);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Прием";
			// 
			// dataGrid2
			// 
			this.dataGrid2.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid2.BackColor = System.Drawing.Color.DarkGray;
			this.dataGrid2.CaptionBackColor = System.Drawing.Color.White;
			this.dataGrid2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dataGrid2.CaptionForeColor = System.Drawing.Color.Navy;
			this.dataGrid2.CaptionText = "Процентные ставки";
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.DataSource = this.dvReceive;
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid2.ForeColor = System.Drawing.Color.Black;
			this.dataGrid2.GridLineColor = System.Drawing.Color.Black;
			this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid2.HeaderBackColor = System.Drawing.Color.Silver;
			this.dataGrid2.HeaderForeColor = System.Drawing.Color.Black;
			this.dataGrid2.LinkColor = System.Drawing.Color.Navy;
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.White;
			this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dataGrid2.SelectionBackColor = System.Drawing.Color.Navy;
			this.dataGrid2.SelectionForeColor = System.Drawing.Color.White;
			this.dataGrid2.Size = new System.Drawing.Size(428, 202);
			this.dataGrid2.TabIndex = 9;
			this.dataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle3});
			// 
			// dvReceive
			// 
			this.dvReceive.AllowDelete = false;
			this.dvReceive.AllowNew = false;
			this.dvReceive.RowFilter = "Direction=0";
			this.dvReceive.Table = this.dsOrgsClients1.OrgsClients;
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.DataGrid = this.dataGrid2;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridBoolColumn2});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "OrgsClients";
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "Наименование";
			this.dataGridTextBoxColumn6.MappingName = "OrgName";
			this.dataGridTextBoxColumn6.NullText = "-";
			this.dataGridTextBoxColumn6.Width = 150;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "ИНН";
			this.dataGridTextBoxColumn7.MappingName = "CodeINN";
			this.dataGridTextBoxColumn7.NullText = "-";
			this.dataGridTextBoxColumn7.Width = 90;
			// 
			// dataGridBoolColumn2
			// 
			this.dataGridBoolColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridBoolColumn2.AllowNull = false;
			this.dataGridBoolColumn2.FalseValue = false;
			this.dataGridBoolColumn2.HeaderText = "Разрешено";
			this.dataGridBoolColumn2.MappingName = "IsAvailable";
			this.dataGridBoolColumn2.NullText = "-";
			this.dataGridBoolColumn2.NullValue = ((System.DBNull)(resources.GetObject("dataGridBoolColumn2.NullValue")));
			this.dataGridBoolColumn2.TrueValue = true;
			this.dataGridBoolColumn2.Width = 75;
			// 
			// AddClient
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(436, 387);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1,
																		  this.label5,
																		  this.tbConfirmPassw,
																		  this.label4,
																		  this.tbPassw,
																		  this.bnCancel,
																		  this.bnOK,
																		  this.btAddGroup,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.tbRemarks,
																		  this.tbClient,
																		  this.cmbGroup});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddClient";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Клиент";
			this.Load += new System.EventHandler(this.AddClient_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRate1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSendFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvSend)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvReceive)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btAddGroup_Click(object sender, System.EventArgs e)
		{
			addingGroup(0);
		}

		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if(!validateClient())
				return;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void trimClient()
		{
			this.tbClient.Text = this.tbClient.Text.Trim(new char[]{'"',' ','<','>','\''});
			this.tbClient.Text = this.tbClient.Text.TrimStart(new char[]{'"',' ','<','>','\'','.',',','[',']','{','}','(',')',':',';','?','/','!','@','#','$','%','^','&','*'});
		}
		private bool validateClient()
		{
			this.trimClient();
			if(this.tbClient.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле ИМЯ КЛИЕНТА", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.tbClient.Focus();
				return false;
			}
			
			if(this.cmbGroup.SelectedIndex == -1)
			{
				MsgBoxX.Show("Задайте ГРУППУ", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.cmbGroup.Focus();
				return false;
			}
			if((this.tbPassw.Text.Length > 0) && (this.tbPassw.Text != this.tbConfirmPassw.Text))
			{
				MsgBoxX.Show("Неправильно введён подтверждающий пароль клиента. Введите подтверждение пароля заново.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.tbConfirmPassw.Focus();
				return false;
			}
			return true;
		}
		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void cmbGroup_Leave(object sender, System.EventArgs e)
		{
			this.cmbGroup.SelectedIndex = this.cmbGroup.FindStringExact(this.cmbGroup.Text);
			if(this.cmbGroup.SelectedIndex == -1)
			{
				addingGroup(-1);
			}
		}
		private void addingGroup(int iMode)
		{
			AddGroup ag = new AddGroup();
			if(iMode == -1)
				ag.tbName.Text = this.cmbGroup.Text;
			ag.ShowDialog();
			if(ag.DialogResult == DialogResult.OK)
			{
				try
				{
					BPS.BLL.Clients.DataSets.dsGroups.ClientsGroupsRow rw = (BPS.BLL.Clients.DataSets.dsGroups.ClientsGroupsRow) this.dvGroups.Table.NewRow();//((BPS.Clients.dsGroups.ClientsGroupsDataTable)this.cmbGroup.DataSource).NewRow();
					rw.ClientGroupName = ag.tbName.Text;
					rw.ClientGroupRemarks = ag.tbRemarks.Text;
					rw.IsInner = false;
					rw.IsSpecial = false;
					this.dvGroups.Table.Rows.Add((DataRow) rw);//((Clients.dsGroups.ClientsGroupsDataTable)this.cmbGroup.DataSource).AddClientsGroupsRow(rw);
					AddGroup();
				} 
				catch(Exception ex)
				{
					MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void AddClient_Load(object sender, System.EventArgs e)
		{
			if(rw != null)
				this.cmbGroup.SelectedValue = rw.ClientGroupID;
		}
	}
}
