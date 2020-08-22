using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for LocksView.
	/// </summary>
	public class LocksView : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS._Forms.Locks.dsLocksList dsLocksList1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnEntityTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnEntityID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUserID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnUserName;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbtnRefresh;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.ComponentModel.IContainer components;

		public LocksView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			App.SetDataGridTableStyle( this.dataGridTableStyle1);
			try 
			{
				this.sqlDataAdapter1.Fill( this.dsLocksList1.Locks);   
			}
			catch(Exception ex) 
			{
				MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LocksView));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dsLocksList1 = new BPS._Forms.Locks.dsLocksList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnEntityTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnEntityID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUserID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnUserName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsLocksList1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbtnRefresh});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(544, 25);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbtnRefresh
			// 
			this.tbtnRefresh.ImageIndex = 0;
			this.tbtnRefresh.Text = "Обновить";
			this.tbtnRefresh.ToolTipText = "Обновить список блокировок";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(544, 0);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 229);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(544, 0);
			this.panel2.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataGrid1});
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 25);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(544, 204);
			this.panel3.TabIndex = 3;
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "Locks";
			this.dataGrid1.DataSource = this.dsLocksList1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(544, 204);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dsLocksList1
			// 
			this.dsLocksList1.DataSetName = "dsLocksList";
			this.dsLocksList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsLocksList1.Namespace = "http://www.tempuri.org/dsLocksList.xsd";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnEntityTypeName,
																												  this.ColumnEntityID,
																												  this.ColumnUserID,
																												  this.ColumnUserName});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Locks";
			// 
			// ColumnEntityTypeName
			// 
			this.ColumnEntityTypeName.Format = "";
			this.ColumnEntityTypeName.FormatInfo = null;
			this.ColumnEntityTypeName.HeaderText = "Тип Блокировки";
			this.ColumnEntityTypeName.MappingName = "EntityTypeName";
			this.ColumnEntityTypeName.NullText = "-";
			this.ColumnEntityTypeName.Width = 150;
			// 
			// ColumnEntityID
			// 
			this.ColumnEntityID.Format = "";
			this.ColumnEntityID.FormatInfo = null;
			this.ColumnEntityID.HeaderText = "ID";
			this.ColumnEntityID.MappingName = "EntityID";
			this.ColumnEntityID.NullText = "-";
			this.ColumnEntityID.Width = 75;
			// 
			// ColumnUserID
			// 
			this.ColumnUserID.Format = "";
			this.ColumnUserID.FormatInfo = null;
			this.ColumnUserID.HeaderText = "ID Польз.";
			this.ColumnUserID.MappingName = "UserID";
			this.ColumnUserID.Width = 75;
			// 
			// ColumnUserName
			// 
			this.ColumnUserName.Format = "";
			this.ColumnUserName.FormatInfo = null;
			this.ColumnUserName.HeaderText = "Имя Пользователя";
			this.ColumnUserName.MappingName = "UserName";
			this.ColumnUserName.Width = 200;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Locks", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("EntityTypeID", "EntityTypeID"),
																																																			   new System.Data.Common.DataColumnMapping("EntityID", "EntityID"),
																																																			   new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																			   new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																			   new System.Data.Common.DataColumnMapping("EntityTypeName", "EntityTypeName")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT Locks.EntityTypeID, Locks.EntityID, Users.UserName, Users.UserID, LocksEnt" +
				"ities.EntityTypeName FROM Locks LEFT OUTER JOIN LocksEntities ON Locks.EntityTyp" +
				"eID = LocksEntities.EntityTypeID LEFT OUTER JOIN Users ON Locks.UserID = Users.U" +
				"serID";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// LocksView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 229);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel3,
																		  this.panel2,
																		  this.panel1,
																		  this.toolBar1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LocksView";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Блокировки";
			this.TopMost = true;
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsLocksList1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button ==this.tbtnRefresh ) 
			{
				try 
				{
					this.dsLocksList1.Locks.Clear();
					this.sqlDataAdapter1.Fill( this.dsLocksList1.Locks);   
				}
				catch(Exception ex) 
				{
					MessageBox.Show( "Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
