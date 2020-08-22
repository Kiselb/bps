using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Controls;
using System.Security.Cryptography;

namespace BPS._Forms.Clients
{
	/// <summary>
	/// Summary description for ClientView.
	/// </summary>
	public class ClientView : System.Windows.Forms.Form
	{
		// Set new datagrid style
		public delegate void DataGridStyleEventHandler(DataGridTableStyle GridStyle);
		public event DataGridStyleEventHandler DataGridStyle;
		// Update DSClients
		public delegate bool UpdateDsEventHandler(bool isAdding);
		public event UpdateDsEventHandler UpdateDs;
		// Add Group
		public delegate void UpdateGroupEventHandler();
		public event UpdateGroupEventHandler AddGroup;
		// Refresh DSClients
		public delegate void RefreshEventHandler();
		public event RefreshEventHandler RefreshDs;
		// Update DSOrgsClients
		public delegate void UpdateDSOrgsClientsEventHandler();
		public event UpdateDSOrgsClientsEventHandler UpdateDSOrgsClients;
		// Fill DSOrgsClients
		public delegate void FillDSOrgsClientsEventHandler(int ClientID);
		public event FillDSOrgsClientsEventHandler FillDSOrgsClients;

		private BPS.BLL.Clients.DataSets.dsClients dsClients1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		//private System.Windows.Forms.DataGrid dataGrid1;
		private AM_Controls.DataGridV dataGrid1;
		//private BPS._Forms.dsClientsView dsClientsView1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Data.DataView dvGroups;
		private System.Windows.Forms.TextBox tbName;
		private bool bIsDgPaint = false;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel3;
		private AM_Controls.DataGridV dataGridV1;
		private System.Data.DataView dvClientRate;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn ReqType;
		private System.Windows.Forms.DataGridTextBoxColumn ReqTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn RateNormal;
		private System.Windows.Forms.DataGridTextBoxColumn RateBlack;
		private System.Data.DataView dvRateList;
		private BPS.BLL.ClientRequest.DataSets.dsReqTypes dsReqTypes1;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.Panel panel1;
		private BPS.BLL.Clients.DataSets.dsInterestRate dsInterestRate1;
		private System.Windows.Forms.CheckBox cbIsInner;
		private System.Windows.Forms.CheckBox cbSpecial;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private BPS.BLL.Clients.DataSets.dsOrgsClients dsOrgsClients1;
		private BPS.BLL.Clients.coInterestRates InterestRates;
		private BPS.BLL.Clients.DataSets.dsInterestRateList dsInterestRateList1;
		private System.ComponentModel.IContainer components;

		public BPS.BLL.Clients.DataSets.dsOrgsClients DSOrgsClients
		{
			set
			{
				this.dsOrgsClients1 = value;
			}
		}

		public ClientView(BPS.BLL.Clients.DataSets.dsClients dsClnt, BPS.BLL.Clients.DataSets.dsGroups dsGroups)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InterestRates = new BPS.BLL.Clients.coInterestRates();
			this.dvClientRate.Table = dsInterestRate1.InterestRate;
			BPS.App.SetDataGridTableStyle(this.dataGridTableStyle2);
			this.BindingContext[this.dataView1].CurrentChanged += new EventHandler(BindingContextChange);
			this.dsClients1 = dsClnt;
			this.dataView1.Table = dsClients1.Clients;
			// Groups
			this.dvGroups.Table = dsGroups.ClientsGroups;
			// InterestRates
			dsInterestRate1 = InterestRates.DsInterestRates;
			this.dvClientRate.Table = dsInterestRate1.InterestRate;
			// ReqTypes
			InterestRates.FillDSReqType();
			// InterestRatesList
			InterestRates.FillDSInterestRateList();
			this.dsInterestRateList1 = this.InterestRates.DSInterestRateList;
			this.dvRateList.Table = this.dsInterestRateList1.InterestRates;
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

		private void BindingContextChange(object sender, EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dataView1];
			BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)((DataRowView)bm.Current).Row;
			if(this.dataView1.Count == 0)
			{
				InterestRates.DsInterestRates.Clear();
				return;
			}
			this.dvRateList.RowFilter = "ClientID = " + rw.ClientID.ToString();
			this.InterestRates.createRateView(rw);
		}

		private void addGroup()
		{
			AddGroup();
		}

		private void addClient()
		{		
			if(!App.AllowClientsDirChange)
				return;
			InterestRates.CreateRateView();

			AddClient ac = new AddClient(this.dvGroups, this.dvClientRate);
			ac.AddGroup += new AddClient.AddGroupEventHandler(addGroup);
			ac.Text += " [Новый]";
			ac.ShowDialog();
			if(ac.DialogResult == DialogResult.OK)
			{
				try
				{				
					BPS.BLL.Clients.DataSets.dsClients.ClientsRow newRow = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow) this.dataView1.Table.NewRow();//this.dsClients1._Table.NewRow();
					newRow.ClientName = ac.tbClient.Text;
					if(ac.tbRemarks.Text.Length > 0)
						newRow.ClientRemarks = ac.tbRemarks.Text;
					else
						newRow.ClientRemarks = "-";
					newRow.ClientGroupID = Convert.ToInt32(ac.cmbGroup.SelectedValue);
					newRow.ClientGroupName = ac.cmbGroup.Text;
					if(ac.tbPassw.Text.Length > 0)
					{
						string szPwd = ac.tbPassw.Text;
						byte [] bPwd = new Byte[szPwd.Length];
						for(int i=0; i<szPwd.Length; i++)
						{
							bPwd[i] = Convert.ToByte(szPwd[i]);
						}
						MD5 md5 = new MD5CryptoServiceProvider();
						byte [] resPwd = md5.ComputeHash(bPwd);
						newRow.Password = BitConverter.ToString(resPwd);
					}
					this.dataView1.Table.Rows.Add((DataRow) newRow);
					UpdateDs(true);
					InterestRates.SaveChangesRates(newRow);
				}
				catch(Exception ex)
				{
					MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			this.dvGroups.RowFilter = "";
		}

		private void editClient()
		{
			if(!App.AllowClientsDirChange)
				return;
			if(this.dataView1.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)((DataRowView)bm.Current).Row;
				try
				{
					FillDSOrgsClients(rw.ClientID);
					AddClient ec = new AddClient(rw,this.dvGroups, this.dvClientRate, this.dsOrgsClients1);
					ec.Text += " [Редактирование]";
					ec.AddGroup += new AddClient.AddGroupEventHandler(addGroup);
					ec.ShowDialog();
					if(ec.DialogResult == DialogResult.OK)
					{
						rw.ClientGroupID = Convert.ToInt32(ec.cmbGroup.SelectedValue);
						rw.ClientName = ec.tbClient.Text;
						rw.ClientRemarks = ec.tbRemarks.Text;
						rw.ClientGroupName = ec.cmbGroup.Text;
						//rw.IsSpecial = ec.cbSpecial.Checked;
						if(ec.tbPassw.Text.Length > 0)
						{
							string szPwd = ec.tbPassw.Text;
							byte [] bPwd = new Byte[szPwd.Length];
							for(int i=0; i<szPwd.Length; i++)
							{
								bPwd[i] = Convert.ToByte(szPwd[i]);
							}
							MD5 md5 = new MD5CryptoServiceProvider();
							byte [] resPwd = md5.ComputeHash(bPwd);
							rw.Password = BitConverter.ToString(resPwd);
						}
						UpdateDs(false);
						InterestRates.SaveChangesRates(rw);
						UpdateDSOrgsClients();
					}
					else
						this.dsInterestRate1.RejectChanges();
				}
				catch(Exception ex)
				{
					MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
		}
		private void deleteClient()
		{
			if(!App.AllowClientsDirChange)
				return;
			if(this.dataView1.Count>0)
			{
				try
				{
					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
					BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)((DataRowView)bm.Current).Row;
					if(MsgBoxX.Show("Вы действительно хотите удалить клиента " + rw.ClientName + "?","BPS",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						//((DataRowView)bm.Current).Row.Delete();
						rw.Delete();
						UpdateDs(false);
					}
				}
				catch(Exception ex)
				{
					MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ClientView));
			this.dsClients1 = new BPS.BLL.Clients.DataSets.dsClients();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbSpecial = new System.Windows.Forms.CheckBox();
			this.cbIsInner = new System.Windows.Forms.CheckBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid1 = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.dataView1 = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
			this.dvGroups = new System.Data.DataView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.dvClientRate = new System.Data.DataView();
			this.dsInterestRate1 = new BPS.BLL.Clients.DataSets.dsInterestRate();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.ReqType = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ReqTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RateNormal = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RateBlack = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dvRateList = new System.Data.DataView();
			this.dsInterestRateList1 = new BPS.BLL.Clients.DataSets.dsInterestRateList();
			this.dsReqTypes1 = new BPS.BLL.ClientRequest.DataSets.dsReqTypes();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.dsOrgsClients1 = new BPS.BLL.Clients.DataSets.dsOrgsClients();
			((System.ComponentModel.ISupportInitialize)(this.dsClients1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvGroups)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRateList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRateList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).BeginInit();
			this.SuspendLayout();
			// 
			// dsClients1
			// 
			this.dsClients1.DataSetName = "dsClients";
			this.dsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbSpecial);
			this.groupBox1.Controls.Add(this.cbIsInner);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(792, 38);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			// 
			// cbSpecial
			// 
			this.cbSpecial.Location = new System.Drawing.Point(520, 14);
			this.cbSpecial.Name = "cbSpecial";
			this.cbSpecial.TabIndex = 4;
			this.cbSpecial.Text = "Специальные";
			// 
			// cbIsInner
			// 
			this.cbIsInner.Location = new System.Drawing.Point(414, 14);
			this.cbIsInner.Name = "cbIsInner";
			this.cbIsInner.Size = new System.Drawing.Size(88, 24);
			this.cbIsInner.TabIndex = 3;
			this.cbIsInner.Text = "Внутренний";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(64, 16);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(184, 21);
			this.tbName.TabIndex = 0;
			this.tbName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Клиент:";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGrid1
			// 
			this.dataGrid1._CanEdit = false;
			this.dataGrid1._InvisibleColumn = 0;
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGrid1.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.GridLineColor = System.Drawing.Color.LightGray;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(792, 391);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			this.dataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGrid1_Paint);
			// 
			// dataView1
			// 
			this.dataView1.Table = this.dsClients1.Clients;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.dataGridTableStyle1.BackColor = System.Drawing.Color.Gainsboro;
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.LightGray;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Clients";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.MappingName = "ClientID";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 40;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Группа";
			this.dataGridTextBoxColumn3.MappingName = "ClientGroupName";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 130;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Имя клиента";
			this.dataGridTextBoxColumn2.MappingName = "ClientName";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 250;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Примечание";
			this.dataGridTextBoxColumn4.MappingName = "ClientRemarks";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.Width = 330;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.toolBar1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(792, 66);
			this.panel2.TabIndex = 10;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton4,
																						this.toolBarButton3,
																						this.toolBarButton5,
																						this.toolBarButton6,
																						this.toolBarButton7,
																						this.toolBarButton8,
																						this.toolBarButton9});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 0;
			this.toolBarButton1.Text = "Новый";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 1;
			this.toolBarButton2.Text = "Открыть";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 2;
			this.toolBarButton4.Text = "Удалить";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.ImageIndex = 2;
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 3;
			this.toolBarButton5.Text = "Обновить";
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.ImageIndex = 5;
			this.toolBarButton7.Text = "Выбрать";
			// 
			// toolBarButton8
			// 
			this.toolBarButton8.ImageIndex = 6;
			this.toolBarButton8.Text = "Сбросить";
			// 
			// toolBarButton9
			// 
			this.toolBarButton9.ImageIndex = 7;
			this.toolBarButton9.Text = "Очистить";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dataGrid1);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 66);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(792, 507);
			this.panel3.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dataGridV1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 391);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 116);
			this.panel1.TabIndex = 3;
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGridV1.CaptionForeColor = System.Drawing.SystemColors.WindowText;
			this.dataGridV1.CaptionText = "Процентные ставки";
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dvClientRate;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 0);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.ReadOnly = true;
			this.dataGridV1.Size = new System.Drawing.Size(440, 116);
			this.dataGridV1.TabIndex = 2;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
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
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGridV1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ReqType,
																												  this.ReqTypeName,
																												  this.RateNormal,
																												  this.RateBlack});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "InterestRate";
			// 
			// ReqType
			// 
			this.ReqType.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ReqType.Format = "";
			this.ReqType.FormatInfo = null;
			this.ReqType.HeaderText = "ID";
			this.ReqType.MappingName = "ReqType";
			this.ReqType.Width = 40;
			// 
			// ReqTypeName
			// 
			this.ReqTypeName.Format = "";
			this.ReqTypeName.FormatInfo = null;
			this.ReqTypeName.HeaderText = "Тип операции";
			this.ReqTypeName.MappingName = "ReqTypeName";
			this.ReqTypeName.NullText = "-";
			this.ReqTypeName.Width = 200;
			// 
			// RateNormal
			// 
			this.RateNormal.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.RateNormal.Format = "#,##0.00";
			this.RateNormal.FormatInfo = null;
			this.RateNormal.HeaderText = "Процент н.";
			this.RateNormal.MappingName = "RateNormal";
			this.RateNormal.NullText = "-";
			this.RateNormal.Width = 80;
			// 
			// RateBlack
			// 
			this.RateBlack.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.RateBlack.Format = "#,##0.00";
			this.RateBlack.FormatInfo = null;
			this.RateBlack.HeaderText = "Процент ч.";
			this.RateBlack.MappingName = "RateBlack";
			this.RateBlack.NullText = "-";
			this.RateBlack.Width = 80;
			// 
			// dvRateList
			// 
			this.dvRateList.Table = this.dsInterestRateList1.InterestRates;
			// 
			// dsInterestRateList1
			// 
			this.dsInterestRateList1.DataSetName = "dsInterestRateList";
			this.dsInterestRateList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dsReqTypes1
			// 
			this.dsReqTypes1.DataSetName = "dsReqTypes";
			this.dsReqTypes1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuEdit});
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 0;
			this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem2,
																					this.menuItem3,
																					this.menuItem4,
																					this.menuItem5,
																					this.menuItem6,
																					this.menuItem7,
																					this.menuItem8,
																					this.menuItem9,
																					this.menuItem10});
			this.mnuEdit.Text = "Редактирование";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem2.Text = "Новый";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.menuItem3.Text = "Изменить";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.menuItem4.Text = "Удалить";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem6.Text = "Обновить";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 5;
			this.menuItem7.Text = "-";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 6;
			this.menuItem8.Text = "Выбрать";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 7;
			this.menuItem9.Text = "Сбросить";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 8;
			this.menuItem10.Text = "Очистить";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// dsOrgsClients1
			// 
			this.dsOrgsClients1.DataSetName = "dsOrgsClients";
			this.dsOrgsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// ClientView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "ClientView";
			this.Text = "Клиенты";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MdiChildActivate += new System.EventHandler(this.ClientView_MdiChildActivate);
			this.Load += new System.EventHandler(this.ClientView_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsClients1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvGroups)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRateList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRateList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void bnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (this.toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					addClient();
					break;
				case 1:
					editClient();
					break;
				case 2:
					deleteClient();
					break;
				case 4:
					this.RefreshDs();
					break;
				case 6:
					applyFilter();
					break;
				case 7:
					this.dataView1.RowFilter = "IsInner=false and IsSpecial=false";
					if(this.dataView1.Count > 0)
					{
						this.dataGrid1.CurrentRowIndex = 0;
					}
					break;
				case 8:
					this.clearFilter();
					if(this.dataView1.Count > 0)
					{
						this.dataGrid1.CurrentRowIndex = 0;
					}
					break;
			}
		}

		private void clearFilter()
		{
			this.tbName.Text = "";
			this.cbIsInner.Checked = false;
			this.cbSpecial.Checked = false;
		}
		private void applyFilter()
		{
			string szFilter = "";
			if(this.tbName.Text.Length>0)
			{
				szFilter += "ClientName LIKE'" + this.tbName.Text + "*'";
			}
			if(this.cbIsInner.Checked || this.cbSpecial.Checked)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				szFilter += "(";
				if(this.cbIsInner.Checked)
				{
					szFilter += "IsInner=true";
					if(this.cbSpecial.Checked)
						szFilter += " or ";
				}
				if(this.cbSpecial.Checked)
				{
					szFilter += "IsSpecial=true";
				}
				szFilter += ")";
			}
			else
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				szFilter += "IsInner=false and IsSpecial=false";
			}
			try
			{
				this.dataView1.RowFilter = szFilter;
			}
			catch(System.Data.EvaluateException)
			{
				MessageBox.Show("Введена некорректная последовательность символов в фильтре", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.dataView1.RowFilter = "";
				return;
			}
			if(this.dataView1.Count == 0)
			{
				this.dsInterestRate1.InterestRate.Clear();
				this.dataGrid1.CurrentRowIndex = -1;
			}
		}

	
		private void ClientView_MdiChildActivate(object sender, System.EventArgs e)
		{
			
		}

		private void dataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(!bIsDgPaint)
			{
				this.DataGridStyle(this.dataGridTableStyle1);
				bIsDgPaint = true;
			}
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.editClient();
		}

		private void ClientView_Load(object sender, System.EventArgs e)
		{
			this.menuItem2.Enabled = this.menuItem4.Enabled = this.menuItem3.Enabled = 
				this.toolBarButton1.Enabled = this.toolBarButton2.Enabled = this.toolBarButton4.Enabled = App.AllowClientsDirChange;
			App.Clone(this.mnuEdit.MenuItems, this.contextMenu1);
			this.applyFilter();
			if(this.dataView1.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dataView1];
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow)((DataRowView)bm.Current).Row;
				this.InterestRates.createRateView(rw);
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			//новый
			this.addClient();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.editClient();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.deleteClient();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			this.RefreshDs();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.applyFilter();
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.clearFilter();
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.dataView1.RowFilter = "IsInner=false and IsSpecial=false";
		}
	}
}
