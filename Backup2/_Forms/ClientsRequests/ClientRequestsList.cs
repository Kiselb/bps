using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Controls;
using AM_Lib;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for ClientRequestsList.
	/// </summary>
	public class ClientRequestsList : System.Windows.Forms.Form
	{
		private BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rwCurrentRow;
		private BindingManagerBase bmClientRequest;

		private System.Windows.Forms.Panel panel2;
		private AM_Controls.DataGridV dataGridV1;
		//private System.Windows.Forms.DataGrid dataGridV1;
		private System.Windows.Forms.GroupBox groupBox1;
		private AM_Controls.ucPeriodSimple cPeriod;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BLL.ClientsRequests.DataSets.dsClientsRequests dsClientsRequests1;
		private System.Data.DataView dvClientRequest;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn RequestID;
		private System.Windows.Forms.DataGridTextBoxColumn RequestTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn RequestDate;
		private System.Windows.Forms.DataGridTextBoxColumn ClientName;
		private System.Windows.Forms.DataGridTextBoxColumn RequestSum;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label label2;
		private System.Data.DataView dvClients;
		private BPS.BLL.ClientRequest.DataSets.dsReqTypes dsReqTypes1;
		private System.Data.DataView dvReqTypes;
		private System.Windows.Forms.DataGridTextBoxColumn RequestStateName;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuDel;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuExec;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Windows.Forms.MenuItem mnuSelReset;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuEditItem;
		private System.Data.SqlClient.SqlCommand sqlInsPO;
		private System.Data.SqlClient.SqlCommand sqlInsTrOp;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridTextBoxColumn AccountFrom;
		private System.Windows.Forms.DataGridTextBoxColumn OrgFrom;
		private System.Windows.Forms.DataGridTextBoxColumn OrgFromINN;
		private System.Windows.Forms.DataGridTextBoxColumn OrgTo;
		private System.Windows.Forms.DataGridTextBoxColumn AccountTo;
		private System.Windows.Forms.DataGridTextBoxColumn OrgToINN;
		private System.Windows.Forms.DataGridTextBoxColumn Remarks;
		private System.Windows.Forms.DataGridTextBoxColumn CurrencyFrom;
		private System.Windows.Forms.DataGridTextBoxColumn CurrencyTo;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton10;
		private System.Windows.Forms.ToolBarButton tbbExec;
		private System.Windows.Forms.ToolBarButton tbbConfirm;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton tbbApply;
		private System.Windows.Forms.ToolBarButton tbbClear;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuUndoExec;
		private System.Windows.Forms.MenuItem mnuCompleteExec;
		private System.Windows.Forms.MenuItem mnuCopy;
		private System.Windows.Forms.CheckBox cbConfirm;
		private System.Windows.Forms.CheckBox cbProceess;
		private System.Windows.Forms.CheckBox cbComplete;
		private System.Windows.Forms.DataGridTextBoxColumn ExecutedSum;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGridTextBoxColumn Purpose;
		private BPS._Forms.Clients.GroupClients groupClients1;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		private System.Windows.Forms.MenuItem menuItem2;

		public BPS.BLL.ClientsRequests.coRequest bllRequests;
		
		public ClientRequestsList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);

			bllRequests =  App.bllRequests;
			this.dvClientRequest.Table = bllRequests.DataSet.ClientsRequests;



		{
			//Тип запроса
			this.dvReqTypes.Table = bllRequests.ReqTypesDirectory.ClientsRequestTypes.Copy();
			DataRow dr = this.dvReqTypes.Table.NewRow();
			dr["RequestTypeID"] = 0;
			dr["RequestTypeName"] = "<Все>";
			dr["IsInner"] = false;
			this.dvReqTypes.Table.Rows.Add(dr);
			this.dvReqTypes.Sort = "RequestTypeID";
			
		}

//			AM_Lib.Menu.Clone(this.mnuEditItem.MenuItems, this.contextMenu1);
			AM_Lib.Menu.Clone(this.contextMenu1.MenuItems, this.mnuEditItem);

			bmClientRequest = (BindingManagerBase)this.BindingContext[this.dvClientRequest];
			bmClientRequest.CurrentChanged += new EventHandler(this.CurrentRequestChanged);

			setPermissions();


			FilterClear();			
			FilterApply();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ClientRequestsList));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupClients1 = new BPS._Forms.Clients.GroupClients();
			this.cbComplete = new System.Windows.Forms.CheckBox();
			this.cbProceess = new System.Windows.Forms.CheckBox();
			this.cbConfirm = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.dvReqTypes = new System.Data.DataView();
			this.dsReqTypes1 = new BPS.BLL.ClientRequest.DataSets.dsReqTypes();
			this.cPeriod = new AM_Controls.ucPeriodSimple();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.dvClientRequest = new System.Data.DataView();
			this.dsClientsRequests1 = new BPS.BLL.ClientsRequests.DataSets.dsClientsRequests();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.RequestID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RequestDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RequestTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RequestStateName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RequestSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ExecutedSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Purpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.AccountFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgFromINN = new System.Windows.Forms.DataGridTextBoxColumn();
			this.AccountTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgToINN = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CurrencyFrom = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CurrencyTo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Remarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuCopy = new System.Windows.Forms.MenuItem();
			this.mnuDel = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuExec = new System.Windows.Forms.MenuItem();
			this.mnuCompleteExec = new System.Windows.Forms.MenuItem();
			this.mnuUndoExec = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuSelReset = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.dvClients = new System.Data.DataView();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuEditItem = new System.Windows.Forms.MenuItem();
			this.sqlInsPO = new System.Data.SqlClient.SqlCommand();
			this.sqlInsTrOp = new System.Data.SqlClient.SqlCommand();
			this.panel3 = new System.Windows.Forms.Panel();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton10 = new System.Windows.Forms.ToolBarButton();
			this.tbbExec = new System.Windows.Forms.ToolBarButton();
			this.tbbConfirm = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.tbbApply = new System.Windows.Forms.ToolBarButton();
			this.tbbClear = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvReqTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientRequest)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsRequests1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupClients1);
			this.groupBox1.Controls.Add(this.cbComplete);
			this.groupBox1.Controls.Add(this.cbProceess);
			this.groupBox1.Controls.Add(this.cbConfirm);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbType);
			this.groupBox1.Controls.Add(this.cPeriod);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1028, 46);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			// 
			// groupClients1
			// 
			this.groupClients1.__UsageForFilter = true;
			this.groupClients1._FirstSpaceWidth = 0;
			this.groupClients1._FourthSpaceWidth = 10;
			this.groupClients1._GroupID = -1;
			this.groupClients1._GroupIDColunmName = null;
			this.groupClients1._GroupLabelText = "Группа";
			this.groupClients1._GroupNameColumnName = null;
			this.groupClients1._GroupsLabelWidth = 46;
			this.groupClients1._GroupsTable = null;
			this.groupClients1._MemberID = -1;
			this.groupClients1._MemberIDColumnName = null;
			this.groupClients1._MemberNameColumnName = null;
			this.groupClients1._MembersFilter = "";
			this.groupClients1._MembersGroupColumnName = null;
			this.groupClients1._MembersLabelText = "Клиент";
			this.groupClients1._MembersLabelWidth = 46;
			this.groupClients1._MembersTable = null;
			this.groupClients1._SecondSpaceWidth = 10;
			this.groupClients1._ThirdSpaceWidth = 0;
			this.groupClients1._Vertical = false;
			this.groupClients1.Location = new System.Drawing.Point(252, 17);
			this.groupClients1.Name = "groupClients1";
			this.groupClients1.Size = new System.Drawing.Size(356, 26);
			this.groupClients1.TabIndex = 23;
			// 
			// cbComplete
			// 
			this.cbComplete.Location = new System.Drawing.Point(922, 20);
			this.cbComplete.Name = "cbComplete";
			this.cbComplete.Size = new System.Drawing.Size(92, 18);
			this.cbComplete.TabIndex = 22;
			this.cbComplete.Text = "Выполненые";
			// 
			// cbProceess
			// 
			this.cbProceess.Checked = true;
			this.cbProceess.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbProceess.Location = new System.Drawing.Point(832, 20);
			this.cbProceess.Name = "cbProceess";
			this.cbProceess.Size = new System.Drawing.Size(88, 18);
			this.cbProceess.TabIndex = 21;
			this.cbProceess.Text = "В обработке";
			// 
			// cbConfirm
			// 
			this.cbConfirm.Checked = true;
			this.cbConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbConfirm.Location = new System.Drawing.Point(754, 20);
			this.cbConfirm.Name = "cbConfirm";
			this.cbConfirm.Size = new System.Drawing.Size(76, 18);
			this.cbConfirm.TabIndex = 20;
			this.cbConfirm.Text = "Принятые";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(616, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 18);
			this.label2.TabIndex = 17;
			this.label2.Text = "Тип:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbType
			// 
			this.cmbType.DataSource = this.dvReqTypes;
			this.cmbType.DisplayMember = "RequestTypeName";
			this.cmbType.Location = new System.Drawing.Point(654, 19);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(92, 21);
			this.cmbType.TabIndex = 16;
			this.cmbType.ValueMember = "RequestTypeID";
			// 
			// dvReqTypes
			// 
			this.dvReqTypes.Table = this.dsReqTypes1.ClientsRequestTypes;
			// 
			// dsReqTypes1
			// 
			this.dsReqTypes1.DataSetName = "dsReqTypes";
			this.dsReqTypes1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cPeriod
			// 
			this.cPeriod._cbDateFrom = true;
			this.cPeriod._cbDateFromUse = false;
			this.cPeriod._cbDateTill = true;
			this.cPeriod._cbDateTillUse = false;
			this.cPeriod._DateFrom = new System.DateTime(2004, 1, 27, 0, 0, 0, 0);
			this.cPeriod._DateTill = new System.DateTime(2004, 1, 27, 0, 0, 0, 0);
			this.cPeriod._PeriodType = AM_Controls.Span.Today;
			this.cPeriod.Location = new System.Drawing.Point(4, 18);
			this.cPeriod.Modified = false;
			this.cPeriod.Name = "cPeriod";
			this.cPeriod.Size = new System.Drawing.Size(240, 22);
			this.cPeriod.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 571);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 2);
			this.panel2.TabIndex = 1;
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1.CaptionVisible = false;
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dvClientRequest;
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 74);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.ReadOnly = true;
			this.dataGridV1.Size = new System.Drawing.Size(1028, 495);
			this.dataGridV1.TabIndex = 2;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			this.dataGridV1.DoubleClick += new System.EventHandler(this.dataGridV1_DoubleClick);
			// 
			// dvClientRequest
			// 
			this.dvClientRequest.AllowDelete = false;
			this.dvClientRequest.AllowNew = false;
			this.dvClientRequest.ApplyDefaultSort = true;
			this.dvClientRequest.Sort = "RequestDate";
			this.dvClientRequest.Table = this.dsClientsRequests1.ClientsRequests;
			// 
			// dsClientsRequests1
			// 
			this.dsClientsRequests1.DataSetName = "dsClientsRequests";
			this.dsClientsRequests1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridV1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.RequestID,
																												  this.RequestDate,
																												  this.ClientName,
																												  this.RequestTypeName,
																												  this.RequestStateName,
																												  this.RequestSum,
																												  this.ExecutedSum,
																												  this.CurrencyFrom,
																												  this.CurrencyTo,
																												  this.OrgFrom,
																												  this.OrgTo,
																												  this.Purpose,
																												  this.AccountFrom,
																												  this.OrgFromINN,
																												  this.AccountTo,
																												  this.OrgToINN,
																												  this.Remarks});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "ClientsRequests";
			// 
			// RequestID
			// 
			this.RequestID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.RequestID.Format = "";
			this.RequestID.FormatInfo = null;
			this.RequestID.HeaderText = "ID";
			this.RequestID.MappingName = "RequestID";
			this.RequestID.NullText = "-";
			this.RequestID.ReadOnly = true;
			this.RequestID.Width = 30;
			// 
			// RequestDate
			// 
			this.RequestDate.Format = "dd/MM/yy";
			this.RequestDate.FormatInfo = null;
			this.RequestDate.HeaderText = "Дата";
			this.RequestDate.MappingName = "RequestDate";
			this.RequestDate.NullText = "-";
			this.RequestDate.ReadOnly = true;
			this.RequestDate.Width = 50;
			// 
			// ClientName
			// 
			this.ClientName.Format = "";
			this.ClientName.FormatInfo = null;
			this.ClientName.HeaderText = "Клиент";
			this.ClientName.MappingName = "ClientName";
			this.ClientName.NullText = "-";
			this.ClientName.ReadOnly = true;
			this.ClientName.Width = 75;
			// 
			// RequestTypeName
			// 
			this.RequestTypeName.Format = "";
			this.RequestTypeName.FormatInfo = null;
			this.RequestTypeName.HeaderText = "Тип";
			this.RequestTypeName.MappingName = "RequestTypeName";
			this.RequestTypeName.NullText = "-";
			this.RequestTypeName.ReadOnly = true;
			this.RequestTypeName.Width = 65;
			// 
			// RequestStateName
			// 
			this.RequestStateName.Format = "";
			this.RequestStateName.FormatInfo = null;
			this.RequestStateName.HeaderText = "Состояние";
			this.RequestStateName.MappingName = "RequestStateName";
			this.RequestStateName.NullText = "-";
			this.RequestStateName.ReadOnly = true;
			this.RequestStateName.Width = 75;
			// 
			// RequestSum
			// 
			this.RequestSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.RequestSum.Format = "#,##0.00";
			this.RequestSum.FormatInfo = null;
			this.RequestSum.HeaderText = "Сумма";
			this.RequestSum.MappingName = "RequestSum";
			this.RequestSum.NullText = "-";
			this.RequestSum.ReadOnly = true;
			this.RequestSum.Width = 75;
			// 
			// ExecutedSum
			// 
			this.ExecutedSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ExecutedSum.Format = "#,##0.00";
			this.ExecutedSum.FormatInfo = null;
			this.ExecutedSum.HeaderText = "Выполнено";
			this.ExecutedSum.MappingName = "ExecutedSum";
			this.ExecutedSum.NullText = "-";
			this.ExecutedSum.Width = 75;
			// 
			// OrgFrom
			// 
			this.OrgFrom.Format = "";
			this.OrgFrom.FormatInfo = null;
			this.OrgFrom.HeaderText = "Плательщик";
			this.OrgFrom.MappingName = "OrgFrom";
			this.OrgFrom.NullText = "-";
			this.OrgFrom.Width = 85;
			// 
			// OrgTo
			// 
			this.OrgTo.Format = "";
			this.OrgTo.FormatInfo = null;
			this.OrgTo.HeaderText = "Получатель";
			this.OrgTo.MappingName = "OrgTo";
			this.OrgTo.NullText = "-";
			this.OrgTo.Width = 85;
			// 
			// Purpose
			// 
			this.Purpose.Format = "";
			this.Purpose.FormatInfo = null;
			this.Purpose.MappingName = "Purpose";
			this.Purpose.Width = 150;
			// 
			// AccountFrom
			// 
			this.AccountFrom.Format = "";
			this.AccountFrom.FormatInfo = null;
			this.AccountFrom.HeaderText = "Р. счёт пл.";
			this.AccountFrom.MappingName = "AccountFrom";
			this.AccountFrom.NullText = "-";
			this.AccountFrom.Width = 130;
			// 
			// OrgFromINN
			// 
			this.OrgFromINN.Format = "";
			this.OrgFromINN.FormatInfo = null;
			this.OrgFromINN.HeaderText = "ИНН  пл.";
			this.OrgFromINN.MappingName = "OrgFromINN";
			this.OrgFromINN.NullText = "-";
			this.OrgFromINN.Width = 90;
			// 
			// AccountTo
			// 
			this.AccountTo.Format = "";
			this.AccountTo.FormatInfo = null;
			this.AccountTo.HeaderText = "Р. счёт пол.";
			this.AccountTo.MappingName = "AccountTo";
			this.AccountTo.NullText = "-";
			this.AccountTo.Width = 130;
			// 
			// OrgToINN
			// 
			this.OrgToINN.Format = "";
			this.OrgToINN.FormatInfo = null;
			this.OrgToINN.HeaderText = "ИНН пол.";
			this.OrgToINN.MappingName = "OrgToINN";
			this.OrgToINN.NullText = "-";
			this.OrgToINN.Width = 90;
			// 
			// CurrencyFrom
			// 
			this.CurrencyFrom.Format = "";
			this.CurrencyFrom.FormatInfo = null;
			this.CurrencyFrom.HeaderText = "Из валюты";
			this.CurrencyFrom.MappingName = "CurrencyFrom";
			this.CurrencyFrom.NullText = "-";
			this.CurrencyFrom.Width = 75;
			// 
			// CurrencyTo
			// 
			this.CurrencyTo.Format = "";
			this.CurrencyTo.FormatInfo = null;
			this.CurrencyTo.HeaderText = "В валюту";
			this.CurrencyTo.MappingName = "CurrencyTo";
			this.CurrencyTo.NullText = "-";
			this.CurrencyTo.Width = 75;
			// 
			// Remarks
			// 
			this.Remarks.Format = "";
			this.Remarks.FormatInfo = null;
			this.Remarks.HeaderText = "Примечание";
			this.Remarks.MappingName = "Remarks";
			this.Remarks.NullText = "-";
			this.Remarks.Width = 150;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuEdit,
																						 this.mnuNew,
																						 this.mnuCopy,
																						 this.mnuDel,
																						 this.menuItem1,
																						 this.mnuExec,
																						 this.mnuCompleteExec,
																						 this.mnuUndoExec,
																						 this.menuItem3,
																						 this.mnuSelReset,
																						 this.menuItem2,
																						 this.menuItem4,
																						 this.menuItem6});
			// 
			// mnuEdit
			// 
			this.mnuEdit.DefaultItem = true;
			this.mnuEdit.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuEdit, ((System.Drawing.Icon)(resources.GetObject("mnuEdit.MenuItemImage"))));
			this.mnuEdit.OwnerDraw = true;
			this.mnuEdit.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.mnuEdit.Text = "Открыть";
			this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuNew, ((System.Drawing.Icon)(resources.GetObject("mnuNew.MenuItemImage"))));
			this.mnuNew.OwnerDraw = true;
			this.mnuNew.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.mnuNew.Text = "Новая";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuCopy
			// 
			this.mnuCopy.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCopy, ((System.Drawing.Icon)(resources.GetObject("mnuCopy.MenuItemImage"))));
			this.mnuCopy.OwnerDraw = true;
			this.mnuCopy.Text = "Копировать";
			this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
			// 
			// mnuDel
			// 
			this.mnuDel.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuDel, ((System.Drawing.Icon)(resources.GetObject("mnuDel.MenuItemImage"))));
			this.mnuDel.OwnerDraw = true;
			this.mnuDel.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.mnuDel.Text = "Удалить";
			this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem1, null);
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "-";
			// 
			// mnuExec
			// 
			this.mnuExec.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuExec, ((System.Drawing.Icon)(resources.GetObject("mnuExec.MenuItemImage"))));
			this.mnuExec.OwnerDraw = true;
			this.mnuExec.Shortcut = System.Windows.Forms.Shortcut.F8;
			this.mnuExec.Text = "Выполнить";
			this.mnuExec.Click += new System.EventHandler(this.mnuExec_Click);
			// 
			// mnuCompleteExec
			// 
			this.mnuCompleteExec.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCompleteExec, ((System.Drawing.Icon)(resources.GetObject("mnuCompleteExec.MenuItemImage"))));
			this.mnuCompleteExec.OwnerDraw = true;
			this.mnuCompleteExec.Text = "Завершить выполнение";
			this.mnuCompleteExec.Click += new System.EventHandler(this.mnuCompleteExec_Click);
			// 
			// mnuUndoExec
			// 
			this.mnuUndoExec.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuUndoExec, ((System.Drawing.Icon)(resources.GetObject("mnuUndoExec.MenuItemImage"))));
			this.mnuUndoExec.OwnerDraw = true;
			this.mnuUndoExec.Text = "Отменить выполнение";
			this.mnuUndoExec.Click += new System.EventHandler(this.mnuUndoExec_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 8;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem3, null);
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "-";
			// 
			// mnuSelReset
			// 
			this.mnuSelReset.Index = 9;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuSelReset, null);
			this.mnuSelReset.OwnerDraw = true;
			this.mnuSelReset.Text = "Сбросить отметки";
			this.mnuSelReset.Visible = false;
			this.mnuSelReset.Click += new System.EventHandler(this.mnuSelReset_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 10;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem2, null);
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "-";
			this.menuItem2.Visible = false;
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 11;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem4, ((System.Drawing.Icon)(resources.GetObject("menuItem4.MenuItemImage"))));
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Text = "Выбрать по фильтру";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 12;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem6, ((System.Drawing.Icon)(resources.GetObject("menuItem6.MenuItemImage"))));
			this.menuItem6.OwnerDraw = true;
			this.menuItem6.Text = "Очистить фильтр";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuEditItem});
			// 
			// mnuEditItem
			// 
			this.mnuEditItem.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuEditItem, null);
			this.mnuEditItem.OwnerDraw = true;
			this.mnuEditItem.Text = "Редактировать";
			// 
			// sqlInsPO
			// 
			this.sqlInsPO.CommandText = @"INSERT INTO PaymentsOrders (ClientRequestID, PaymentOrderSum, PaymentOrderPurpose, Direction, PaymentOrderStatusID, PaymentNo, OrgAccountID, OrgAccountIDCorr) SELECT ClientsRequests.RequestID AS ClientRequestID, ClientsRequests.RequestSum AS PaymentOrderSum, ClientsRequests.Remarks AS PaymentOrderPurpose, 1 AS Direction, 1 AS PaymentOrderStatusID, 'N' AS PaymentNo, OrgsAccounts.OrgsAccountsID AS OrgAccountID, OrgsAccounts_1.OrgsAccountsID AS OrgAccountIDCorr FROM ClientsRequests INNER JOIN OrgsAccounts ON ClientsRequests.AccountIDFrom = OrgsAccounts.AccountID INNER JOIN OrgsAccounts OrgsAccounts_1 ON ClientsRequests.AccountIDTo = OrgsAccounts_1.AccountID WHERE (ClientsRequests.RequestID = @RequestID)";
			this.sqlInsPO.Connection = this.sqlConnection2;
			this.sqlInsPO.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestID", System.Data.SqlDbType.Int, 4, "ClientRequestID"));
			// 
			// sqlInsTrOp
			// 
			this.sqlInsTrOp.CommandText = @"INSERT INTO PaymentsOrders (ClientRequestID, PaymentOrderSum, PaymentOrderPurpose, Direction, PaymentOrderStatusID, PaymentNo, OrgAccountID, OrgAccountIDCorr) SELECT ClientsRequests.RequestID AS ClientRequestID, ClientsRequests.RequestSum AS PaymentOrderSum, ClientsRequests.Remarks AS PaymentOrderPurpose, 1 AS Direction, 1 AS PaymentOrderStatusID, 'N' AS PaymentNo, OrgsAccounts.OrgsAccountsID AS OrgAccountID, OrgsAccounts_1.OrgsAccountsID AS OrgAccountIDCorr FROM ClientsRequests INNER JOIN OrgsAccounts ON ClientsRequests.AccountIDFrom = OrgsAccounts.AccountID INNER JOIN OrgsAccounts OrgsAccounts_1 ON ClientsRequests.AccountIDTo = OrgsAccounts_1.AccountID WHERE (ClientsRequests.RequestID = @RequestID)";
			this.sqlInsTrOp.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsTrOp.Connection = this.sqlConnection2;
			this.sqlInsTrOp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestID", System.Data.SqlDbType.Int, 4, "ClientRequestID"));
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 569);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1028, 2);
			this.panel3.TabIndex = 3;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel,
																						this.toolBarButton10,
																						this.tbbExec,
																						this.tbbConfirm,
																						this.toolBarButton6,
																						this.tbbApply,
																						this.tbbClear});
			this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(1028, 28);
			this.toolBar1.TabIndex = 4;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "Новая";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Открыть";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 3;
			this.tbbDel.Text = "Удалить";
			// 
			// toolBarButton10
			// 
			this.toolBarButton10.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbExec
			// 
			this.tbbExec.ImageIndex = 8;
			this.tbbExec.Text = "Выполнить";
			// 
			// tbbConfirm
			// 
			this.tbbConfirm.ImageIndex = 8;
			this.tbbConfirm.Text = "Подтвердить";
			this.tbbConfirm.Visible = false;
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbApply
			// 
			this.tbbApply.ImageIndex = 6;
			this.tbbApply.Text = "Выбрать";
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
			// MenuItemImageProvider1
			// 
			this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
			// 
			// ClientRequestsList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(1028, 573);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.dataGridV1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "ClientRequestsList";
			this.Text = "Заявки клиентов";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.ClientRequestsList_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvReqTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClientRequest)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsRequests1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion 

		private void setPermissions()
		{
			this.tbbNew.Enabled = this.tbbEdit.Enabled = this.tbbDel.Enabled = 
				this.mnuNew.Enabled = this.mnuDel.Enabled = this.mnuEdit.Enabled = this.mnuCopy.Enabled = App.AllowClientsRequestsEdit;
			this.tbbExec.Enabled = this.mnuCompleteExec.Enabled = this.mnuExec.Enabled = 
				this.mnuUndoExec.Enabled = App.AllowClientsRequestsExecute;
		}


		private void CurrentRequestChanged(object sender, System.EventArgs e)
		{
			if ( bmClientRequest.Position!= -1)
				rwCurrentRow = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow)((DataRowView)bmClientRequest.Current).Row;
			else
				rwCurrentRow = null;
		}



		private bool checkingOrgTo(BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw)
		{
			int iOrgID = 0;
			string sOrgKPP="";
			bool bIsNewOrg = false;
			int iOrgAccountID = 0;
			int iBankID = 0;

			SqlCommand cmdCheckOrg = new SqlCommand(
				"SELECT Orgs.CodeKPP, Orgs.OrgID	FROM ClientsRequests INNER JOIN Orgs ON ClientsRequests.OrgToINN = Orgs.CodeINN "+
				" WHERE ClientsRequests.RequestID = " + rw.RequestID.ToString() );
			
			System.Data.SqlClient.SqlDataReader dr = AM_Lib.sqlData.ExecuteReader(cmdCheckOrg);
			if (dr==null)		// Ошибка выполнения команды
				return false;
			
			if  (dr.Read()) // Организация с таким ИНН найдена
			{
				iOrgID = Convert.ToInt32(dr["OrgID"]);
				sOrgKPP = Convert.ToString(dr["CodeKPP"]);
				dr.Close();
				if (sOrgKPP != rw.OrgToKPP) 
				{
					DialogResult res = AM_Controls.MsgBoxX.Show("Не совпадают КПП,указанный в заявке,и КПП в справочнике.\nЗаменить КПП в справочнике на новый?","BPS",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					if (res == DialogResult.Cancel)
						return false;
					if (res == DialogResult.Yes) 
					{
						SqlCommand cmdReplKPP = new SqlCommand(
							"UPDATE Orgs SET CodeKPP=\'" + rw.OrgToKPP + "\'" +" WHERE OrgID =" + iOrgID.ToString() );
						if ( !AM_Lib.sqlData.ExecuteNonQuery (cmdReplKPP) ) 		// Ошибка выполнения команды
						{
							return false;
						}
					}
				}
			}
			else 
			{
				dr.Close();
				BPS._Forms.CheckOrgTo cho = new BPS._Forms.CheckOrgTo(rw,1);
				cho.ShowDialog();
				if(cho.DialogResult == DialogResult.OK && cho.OrgID!=0)
				{
					iOrgID = cho.OrgID;
					bIsNewOrg = cho.IsNewOrg;
				}
				else 
					return false;
			}
			
			if (bIsNewOrg) 
			{
				// Проверка существования банка. По совпадению БИК или наименования
				object o = AM_Lib.sqlData.ExecuteScalar("SELECT BankID FROM Banks WHERE (BankName = \'"+rw.BankName+"\') OR (CodeBIK = \'"+rw.CodeBIK+"\')");
				if(o !=null && o != Convert.DBNull)
					iBankID = Convert.ToInt32(o);
				else 
				{
					BPS._Forms.CheckOrgTo chb = new BPS._Forms.CheckOrgTo(rw,3,-1);
					chb.ShowDialog();
					if(chb.DialogResult != DialogResult.OK)
					{
						return false;//Отказ от выбора или создания банка
					}
					else
						iBankID = chb.BankID;
				}	
			}

			// Поверка существования указанного р.счета для организации
			System.Data.SqlClient.SqlDataReader drOrgAcc = AM_Lib.sqlData.ExecuteReader(
				"SELECT     OrgsAccountsID,BankID FROM OrgsAccounts " +
				" WHERE     (OrgID = "+ iOrgID.ToString() + ") AND (RAccount = \'" +rw.AccountTo +"\')"
				);
			if (drOrgAcc==null)		// Ошибка выполнения команды
				return false;
			
			if  (!drOrgAcc.Read()) // Такой р.счет для организации не найден
			{
				drOrgAcc.Close();
				BPS._Forms.CheckOrgTo cha = new BPS._Forms.CheckOrgTo(rw,2,iOrgID);
					
				if(bIsNewOrg) 
				{
					cha.NewAccount();
					if ( !AM_Lib.sqlData.ExecuteNonQuery(
						"UPDATE OrgsAccounts SET BankID = " + iBankID.ToString() + " WHERE OrgsAccountsID="+cha.OrgAccountID.ToString()) )
						return false;
				}
				else
					cha.ShowDialog();
				if(cha.DialogResult == DialogResult.OK)
				{
					iOrgAccountID = cha.OrgAccountID;
					if(cha.RAccountExist)
					{
						this.updateDsReq();
						return true;
					}
					else
					{
						// Проверка существования банка. По совпадению БИК или наименования
						object o = AM_Lib.sqlData.ExecuteScalar("SELECT BankID FROM Banks WHERE (BankName = \'"+rw.BankName+"\') OR (CodeBIK = \'"+rw.CodeBIK+"\')");
						if(o !=null && o != Convert.DBNull)
							iBankID = Convert.ToInt32(o);
						else 
						{
							BPS._Forms.CheckOrgTo chb = new BPS._Forms.CheckOrgTo(rw,3,-1);
							chb.ShowDialog();
							if(chb.DialogResult != DialogResult.OK)
							{
								return false;//Отказ от выбора или создания банка
							}
							else
								iBankID = chb.BankID;
						}	
						if ( !AM_Lib.sqlData.ExecuteNonQuery(
							"UPDATE OrgsAccounts SET BankID = " + iBankID.ToString() + " WHERE OrgsAccountsID="+cha.OrgAccountID.ToString()) )
							return false;
					}
				}
				else 
					return false;
			}
			else 
			{
				drOrgAcc.Close();
				this.updateDsReq();
				return true;
			}
			
			return true;
		}
		
		private void executeRequest()
		{
			if ( !App.AllowClientsRequestsExecute) return;
			if ( this.dvClientRequest.Count >0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvClientRequest];
				BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow)((DataRowView)bm.Current).Row;
				
				int nLockedRequestID =rw.RequestID;

				if ( !App.LockStatusChange(4, nLockedRequestID, true)) 
				{
					MessageBox.Show("Редактирование заявки невозможно: Заявка редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}				
				if ( rw.RequestStateID == 1)
				{
					if ( rw.RequestTypeID == 2)
					{
						if ( !this.checkingOrgTo(rw))
						{
							App.LockStatusChange(4, nLockedRequestID, false);

							AM_Controls.MsgBoxX.Show("Неудалось направить заявку в обработку.\nПроверьте правильность реквизитов получателя.","BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							return;
						}
					}
					SqlCommand cmdExecuteRequest = new SqlCommand("[ExecuteClientRequest]", App.Connection);
					cmdExecuteRequest.CommandType = CommandType.StoredProcedure;
					cmdExecuteRequest.Parameters.Add(new SqlParameter("@RequestID",SqlDbType.Int));
					cmdExecuteRequest.Parameters["@RequestID"].Value = rw.RequestID;
					if ( AM_Lib.sqlData.ExecuteNonQuery(cmdExecuteRequest) )
					{						
						rw.RequestStateID = 2;
						rw.RequestStateName = "В обработке";
						this.dsClientsRequests1.AcceptChanges();
					}
					App.LockStatusChange(4, nLockedRequestID, false);
				}
				else
				{
					AM_Controls.MsgBoxX.Show("Заявка уже выполняется.","BPS",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
		}
		
		private bool EditDialogIsOpened()
		{
			return App.FindWindow(typeof(BPS._Forms.ClientRequestEdit));
		}

		
		private void EditRq(BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw, bool bNew)
		{
			if (!EditDialogIsOpened())
			{
				BPS._Forms.ClientRequestEdit ocr = new BPS._Forms.ClientRequestEdit(rw);
				ocr.Memorize += new BPS._Forms.ClientRequestEdit.MemorizeEventHandler(UpdateDS);
				ocr.Show();
			}
		}

		private void editRequest()
		{
			if ( !App.AllowClientsRequestsEdit) return;
			
			if ( this.dvClientRequest.Count >0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvClientRequest];
				BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow)((DataRowView)bm.Current).Row;
				rwCurrentRow = rw;

				if (!EditDialogIsOpened())
				{
					if ( !App.LockStatusChange(4, rw.RequestID, true)) 
					{
						MessageBox.Show("Редактирование заявки невозможно: Заявка редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					BPS._Forms.ClientRequestEdit ocr = new BPS._Forms.ClientRequestEdit(rw);
					ocr.MdiParent = this.MdiParent;
					ocr.Memorize += new BPS._Forms.ClientRequestEdit.MemorizeEventHandler(UpdateDS);
					ocr.Show();
				}
				else
				{
					AM_Controls.MsgBoxX.Show("В данный момент редактируется другая заявка.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		
		private void delRequest()
		{
			if ( !App.AllowClientsRequestsEdit) return;
			if ( this.dvClientRequest.Count >0)
			{
				if ( rwCurrentRow !=null)
				{
					if ( AM_Controls.MsgBoxX.Show("Вы действительно хотите удалить заявку №" + rwCurrentRow.RequestID.ToString(), "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						if(rwCurrentRow.RequestStateID == 3)
						{
							MessageBox.Show("Невозможно удалить заявку №" + rwCurrentRow.RequestID.ToString() + ". Заявка уже выполнена.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						
						int nLockedRequestID =rwCurrentRow.RequestID;

						if ( !App.LockStatusChange(4, nLockedRequestID, true)) 
						{
							MessageBox.Show("Редактирование заявки невозможно: Заявка редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						rwCurrentRow.Delete();
						this.updateDsReq();

						App.LockStatusChange(4, nLockedRequestID, false);
					}
				}
			}
		}

		private void addRequest()
		{
			if ( !App.AllowClientsRequestsEdit) return;
			if ( !EditDialogIsOpened())
			{
				BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow) this.dvClientRequest.Table.NewRow();
				rwCurrentRow = rw;
				BPS._Forms.ClientRequestEdit ocr = new BPS._Forms.ClientRequestEdit(rw);
				ocr.MdiParent = this.MdiParent;
				ocr.Memorize += new BPS._Forms.ClientRequestEdit.MemorizeEventHandler(UpdateDS);
				ocr.Show();
			}
		}

		private void updateDsReq()
		{
			this.bllRequests.Update();
		}

		public void UpdateDS()
		{
			int i = rwCurrentRow.RequestID;
			this.updateDsReq();

			this.SelectLastInsertedRow(i);
		}


		#region Filter functions

		private void FilterApply()
		{
			AM_Lib.FilterBuilder Filter = new FilterBuilder();
			
//			if(this.cmbClients.SelectedIndex>0)
//				Filter.Append("ClientID=" , this.cmbClients.SelectedValue);
			if (this.groupClients1._MemberID>0)
				Filter.Append("ClientID=" , this.groupClients1._MemberID);
			else 
			{
				if (this.groupClients1._GroupID>0)
					Filter.Append("ClientGroupID=" , this.groupClients1._GroupID);
			}



			if(this.cbConfirm.Checked || this.cbProceess.Checked || this.cbComplete.Checked)
			{
				string szFilter="";
				szFilter += "(";
				if(this.cbConfirm.Checked)
					szFilter += "RequestStateID=1";
				if(this.cbProceess.Checked)
				{
					if(this.cbConfirm.Checked)
						szFilter += " or ";
					szFilter += "RequestStateID=2";
				}
				if(this.cbComplete.Checked)
				{
					if(this.cbConfirm.Checked || this.cbProceess.Checked)
						szFilter += " or ";
					szFilter += "RequestStateID=3";
				}
				szFilter += ")";
				Filter.Append(szFilter);
			}

			if(this.cmbType.SelectedIndex>0)
			{
				Filter.Append("RequestTypeID=", this.cmbType.SelectedIndex);
			}

			/*
						if (this.cPeriod._cbDateFrom) 
						{
							Filter.Append("RequestDate>=" , cPeriod._DateFrom);
						}
	
						if (this.cPeriod._cbDateTill) {
							Filter.Append("RequestDate<=" , cPeriod._DateTill);
						}
			*/
			Cursor=Cursors.WaitCursor;
			this.bllRequests.Fill(cPeriod._DateFrom, cPeriod._DateTill);
			if(this.dvClientRequest.Count>0)
				this.dataGridV1.CurrentRowIndex = 0;

			this.dvClientRequest.RowFilter = Filter.Text;
			Cursor=Cursors.Default;
		}


		private void FilterClear()
		{
//			this.cmbClients.SelectedIndex = 0;
			this.groupClients1._GroupID  = 0;
			this.groupClients1._MemberID = 0;
			this.cmbType.SelectedIndex = 0;
			this.cPeriod._PeriodType = AM_Controls.Span.LastTwoWorkingDays;
			this.cbComplete.Checked = false;
			this.cbConfirm.Checked = true;
			this.cbProceess.Checked = true;
		}


		#endregion


		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			this.addRequest();
		}

		private void dataGridV1_DoubleClick(object sender, System.EventArgs e)
		{
			this.editRequest();
		}

		private void mnuEdit_Click(object sender, System.EventArgs e)
		{
			this.editRequest();
		}

		private void mnuSelReset_Click(object sender, System.EventArgs e)
		{
			/*bmClientRequest.EndCurrentEdit();
			foreach  ( dsClientsRequests.ClientsRequestsRow rw in this.dsClientsRequests1.ClientsRequests.Rows )
			{
				//rw.Selected = false;
			}*/
		}

		private void mnuExec_Click(object sender, System.EventArgs e)
		{
			this.executeRequest();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuDel_Click(object sender, System.EventArgs e)
		{
			this.delRequest();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbApply)
				this.FilterApply();
			else if (e.Button == this.tbbClear)
				this.FilterClear();
			else if (e.Button == this.tbbNew)
				addRequest();
			else if (e.Button == this.tbbEdit)
				this.editRequest();
			else if (e.Button == this.tbbDel)
				this.delRequest();	
			else if (e.Button == this.tbbExec)
				this.executeRequest();
		}


		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.FilterApply();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			this.FilterClear();
		}

		private void mnuUndoExec_Click(object sender, System.EventArgs e)
		{
			if(!App.AllowClientsRequestsExecute)
				return;
			if(this.dvClientRequest.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvClientRequest];
			BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow) ((DataRowView) bm.Current).Row;
			if(rw.RequestTypeID != 1)
			{
				AM_Controls.MsgBoxX.Show("Отменить выполнение можно только для заявки на принятие средств от клиента. Для остальных типов заявок воспользуйтесь отменой и удалением соответствующей заявке транзакции.");
				return;
			}
			if((rw.RequestTypeID == 1) && (rw.RequestStateID == 3))
			{
				AM_Controls.MsgBoxX.Show("Невозможно отменить выполнение заявки. Заявка уже выполнена.");
				return;
			}
			if((rw.RequestTypeID == 1) && (rw.ExecutedSum>0))
			{
				AM_Controls.MsgBoxX.Show("Невозможно отменить выполнение заявки. Заявка частично выполнена.");
				return;
			}
			if(rw.RequestTypeID == 1)
			{
				int nLockedRequestID =rw.RequestID;

				if ( !App.LockStatusChange(4, nLockedRequestID, true)) 
				{
					MessageBox.Show("Отменить выполнение заявки невозможно: Заявка редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				rw.RequestStateID = 1;
				rw.RequestStateName = "Принята";
				this.updateDsReq();

				App.LockStatusChange(4, nLockedRequestID, false);
			}
		}


		private void mnuCompleteExec_Click(object sender, System.EventArgs e)
		{
			if(!App.AllowClientsRequestsExecute)
				return;
			if(this.dvClientRequest.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvClientRequest];
			BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow) ((DataRowView) bm.Current).Row;
			if(rw.RequestTypeID != 1)
			{
				AM_Controls.MsgBoxX.Show("Завершить выполнение можно только для заявки на принятие средств от клиента.");
				return;
			}
			if((rw.RequestTypeID == 1) && (rw.RequestStateID == 3))
			{
				AM_Controls.MsgBoxX.Show("Заявка уже выполнена.");
				return;
			}
			if((rw.RequestTypeID == 1) && (rw.RequestStateID == 1))
			{
				AM_Controls.MsgBoxX.Show("Невозможно завершить выполнение заявки.Заявка не в обработке.");
				return;
			}
			if((rw.RequestTypeID == 1) && (rw.RequestStateID == 2))
			{
				int nLockedRequestID =rw.RequestID;

				if ( !App.LockStatusChange(4, nLockedRequestID, true)) 
				{
					MessageBox.Show("Завершить выполнение заявки невозможно: Заявка редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				rw.RequestStateID = 3;
				rw.RequestStateName = "Выполнена";
				this.updateDsReq();

				App.LockStatusChange(4, nLockedRequestID, false);
			}
		}


		private void SelectLastInsertedRow(int iID)
		{
			int iNewPosition = this.dvClientRequest.Count-1;
			for(int j=0 ; j<this.dvClientRequest.Count;j++)
			{
				if(Convert.ToInt32(this.dvClientRequest[j].Row["RequestID"]) == iID)
				{
					iNewPosition = j;
					break;
				}
			}
			this.BindingContext[this.dvClientRequest].Position = iNewPosition;
		}


		private void mnuCopy_Click(object sender, System.EventArgs e)
		{
			if(!App.AllowClientsRequestsEdit)
				return;
			if(this.dvClientRequest.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dvClientRequest];
			BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rwOld = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow) ((DataRowView) bm.Current).Row;
			BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rwNew = (BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow) this.dvClientRequest.Table.NewRow();
			object [] o = rwOld.ItemArray;
			for(int i = 0; i< rwOld.Table.Columns.Count; i++)
			{
				if(rwOld[i] != Convert.DBNull) 
				{
					if ( rwOld.Table.Columns[i].ReadOnly)
						rwOld.Table.Columns[i].ReadOnly= false;
					if (!rwOld.Table.Columns[i].Unique)
						rwNew[i] = rwOld[i];
				}
			}
			rwNew.RequestDate = DateTime.Now;
			rwNew.RequestStateID = 1;
			rwNew.RequestStateName = "Принята";
			rwNew.ExecutedSum = 0;
			this.dvClientRequest.Table.Rows.Add((DataRow) rwNew);
			this.updateDsReq();

			SelectLastInsertedRow (rwNew.RequestID);
			editRequest();

/*
 * 			BPS._Forms.ClientRequestEdit ocr = new BPS._Forms.ClientRequestEdit(rwNew );
			ocr.ShowDialog();
			if(ocr.DialogResult == DialogResult.OK)
			{
				this.updateDsReq();
			}
*/
		}

		private void ClientRequestsList_Load(object sender, System.EventArgs e)
		{
			groupClients1._MembersFilter = "IsInner=false AND IsSpecial=false";
		}
	}
}
