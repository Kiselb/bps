using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace AuthControl
{
	/// <summary>
	/// Summary description for Users.
	/// </summary>
	public class Users : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
		//private AM_Controls.DataGridV dataGridV1;
		private System.Windows.Forms.DataGrid dataGridV1;
		private System.Data.OleDb.OleDbDataAdapter daUsers;
		private System.Data.OleDb.OleDbConnection sqlConnection1;
		private System.Data.OleDb.OleDbDataAdapter daUserGroups;
		private System.Windows.Forms.ImageList imageList1;
		private System.Data.OleDb.OleDbDataAdapter daUsersPermissions;
		
		private System.Data.DataView dvUsersPermissions;
		private System.Data.OleDb.OleDbDataAdapter daGroupsPermissions;
		private System.Data.DataView dvGroupsPermissions;		
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn Description;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn PerDescription;
		private System.Windows.Forms.DataGridBoolColumn perAllow;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imglTb;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Data.OleDb.OleDbDataAdapter daPermissionList;
		
		private System.Windows.Forms.ToolBarButton tbbNewGroup;
		private System.Windows.Forms.ToolBarButton tbbNewUser;
		private System.Windows.Forms.ToolBarButton tbbChangePwd;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		
		private System.Windows.Forms.Button bnSave;
		private System.Windows.Forms.Button bnClose;
	
		private System.Data.OleDb.OleDbCommand sqlSelectCommand1;
		private System.Data.OleDb.OleDbCommand sqlInsertCommand1;
		private System.Data.OleDb.OleDbCommand sqlUpdateCommand1;
		private System.Data.OleDb.OleDbCommand sqlDeleteCommand1;
		private System.Data.OleDb.OleDbCommand sqlSelectCommand4;
		private System.Data.OleDb.OleDbCommand sqlInsertCommand5;
		private System.Data.OleDb.OleDbCommand sqlUpdateCommand5;
		private System.Data.OleDb.OleDbCommand sqlDeleteCommand5;
		private System.Data.OleDb.OleDbCommand sqlSelectCommand5;
		private System.Data.OleDb.OleDbCommand sqlSelectCommand3;
		private System.Data.OleDb.OleDbCommand sqlInsertCommand4;
		private System.Data.OleDb.OleDbCommand sqlUpdateCommand4;
		private System.Data.OleDb.OleDbCommand sqlDeleteCommand4;
		private System.Windows.Forms.ToolBarButton tbbShowRem;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private bool bIsShowRem = false;
		private System.Data.OleDb.OleDbCommand sqlSelectCommand2;
		private System.Data.OleDb.OleDbCommand sqlInsertCommand2;
		private System.Data.OleDb.OleDbCommand sqlUpdateCommand2;
		private System.Data.OleDb.OleDbCommand sqlDeleteCommand2;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.ToolBarButton tbbRestore;
		private AuthControl.XSD.dsGroupsPermissions dsGroupsPermissions1;
		private AuthControl.XSD.dsPermissionsList dsPermissionsList1;
		private AuthControl.XSD.dsUserGroups dsUserGroups1;
		private AuthControl.XSD.dsUsers dsUsers1;
		private AuthControl.XSD.dsUsersPermissions dsUsersPermissions1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private bool bIsTreeLeave = true;
		private System.Windows.Forms.DataGridBoolColumn Allow;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		BindingManagerBase bm;
		public Users(string szConnectionString)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.sqlConnection1.ConnectionString = szConnectionString;
			this.fillDs();
			this.fillTree();
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
		public DataGridTableStyle StyleDgUsers
		{
			get
			{
				return this.dataGridTableStyle1;
			}
		}
		public DataGridTableStyle StyleDgGroups
		{
			get
			{
				return this.dataGridTableStyle2;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Users));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.bnSave = new System.Windows.Forms.Button();
			this.dataGridV1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.Description = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Allow = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.PerDescription = new System.Windows.Forms.DataGridTextBoxColumn();
			this.perAllow = new System.Windows.Forms.DataGridBoolColumn();
			this.daUsers = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.daUserGroups = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.sqlDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.daUsersPermissions = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.sqlDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.dvUsersPermissions = new System.Data.DataView();
			this.dsUsersPermissions1 = new AuthControl.XSD.dsUsersPermissions();
			this.daGroupsPermissions = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.dvGroupsPermissions = new System.Data.DataView();
			this.dsGroupsPermissions1 = new AuthControl.XSD.dsGroupsPermissions();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNewGroup = new System.Windows.Forms.ToolBarButton();
			this.tbbNewUser = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbChangePwd = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbbShowRem = new System.Windows.Forms.ToolBarButton();
			this.tbbRestore = new System.Windows.Forms.ToolBarButton();
			this.imglTb = new System.Windows.Forms.ImageList(this.components);
			this.daPermissionList = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.bnClose = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.dsPermissionsList1 = new AuthControl.XSD.dsPermissionsList();
			this.dsUserGroups1 = new AuthControl.XSD.dsUserGroups();
			this.dsUsers1 = new AuthControl.XSD.dsUsers();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUsersPermissions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersPermissions1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvGroupsPermissions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsGroupsPermissions1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPermissionsList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUserGroups1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsers1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.FullRowSelect = true;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(220, 402);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
			this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
			this.treeView1.Enter += new System.EventHandler(this.treeView1_Enter);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// bnSave
			// 
			this.bnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnSave.Location = new System.Drawing.Point(360, 8);
			this.bnSave.Name = "bnSave";
			this.bnSave.Size = new System.Drawing.Size(80, 26);
			this.bnSave.TabIndex = 3;
			this.bnSave.Text = "Сохранить";
			this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
			// 
			// dataGridV1
			// 
			this.dataGridV1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGridV1.CaptionForeColor = System.Drawing.SystemColors.WindowText;
			this.dataGridV1.CaptionText = "Разрешения";
			this.dataGridV1.DataMember = "";
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(224, 0);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.Size = new System.Drawing.Size(390, 402);
			this.dataGridV1.TabIndex = 1;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1,
																								   this.dataGridTableStyle2});
			this.dataGridV1.Click += new System.EventHandler(this.dataGridV1_Click);
			this.dataGridV1.Leave += new System.EventHandler(this.dataGridV1_Leave);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridV1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.Description,
																												  this.Allow});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "UsersPermissions";
			// 
			// Description
			// 
			this.Description.Format = "";
			this.Description.FormatInfo = null;
			this.Description.HeaderText = "Действие";
			this.Description.MappingName = "Description";
			this.Description.NullText = "-";
			this.Description.ReadOnly = true;
			this.Description.Width = 250;
			// 
			// Allow
			// 
			this.Allow.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.Allow.AllowNull = false;
			this.Allow.FalseValue = false;
			this.Allow.HeaderText = "Разрешить";
			this.Allow.MappingName = "Allow";
			this.Allow.NullValue = null;
			this.Allow.TrueValue = true;
			this.Allow.Width = 75;
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGridV1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.PerDescription,
																												  this.perAllow});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "UserGroupsPermissions";
			// 
			// PerDescription
			// 
			this.PerDescription.Format = "";
			this.PerDescription.FormatInfo = null;
			this.PerDescription.HeaderText = "Действие";
			this.PerDescription.MappingName = "Description";
			this.PerDescription.NullText = "-";
			this.PerDescription.ReadOnly = true;
			this.PerDescription.Width = 250;
			// 
			// perAllow
			// 
			this.perAllow.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.perAllow.AllowNull = false;
			this.perAllow.FalseValue = false;
			this.perAllow.HeaderText = "Разрешить";
			this.perAllow.MappingName = "Allow";
			this.perAllow.NullText = "-";
			this.perAllow.NullValue = null;
			this.perAllow.TrueValue = true;
			this.perAllow.Width = 75;
			// 
			// daUsers
			// 
			this.daUsers.DeleteCommand = this.oleDbDeleteCommand2;
			this.daUsers.InsertCommand = this.oleDbInsertCommand2;
			this.daUsers.SelectCommand = this.oleDbSelectCommand2;
			this.daUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "Users", new System.Data.Common.DataColumnMapping[] {
																																																	   new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																	   new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																	   new System.Data.Common.DataColumnMapping("UserPassword", "UserPassword"),
																																																	   new System.Data.Common.DataColumnMapping("GroupID", "GroupID"),
																																																	   new System.Data.Common.DataColumnMapping("IsRemoved", "IsRemoved")})});
			this.daUsers.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM Users WHERE (UserID = ?) AND (IsRemoved = ?) AND (UserName = ? OR ? I" +
				"S NULL AND UserName IS NULL) AND (UserPassword = ? OR ? IS NULL AND UserPassword" +
				" IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.sqlConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsRemoved", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserPassword", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserPassword1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPassword", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO Users(UserName, UserPassword, GroupID, IsRemoved) VALUES (?, ?, ?, ?)" +
				"";
			this.oleDbInsertCommand2.Connection = this.sqlConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarWChar, 50, "UserName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserPassword", System.Data.OleDb.OleDbType.VarWChar, 50, "UserPassword"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("GroupID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "GroupID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "IsRemoved"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT UserID, UserName, UserPassword, GroupID, IsRemoved FROM Users";
			this.oleDbSelectCommand2.Connection = this.sqlConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE Users SET UserName = ?, UserPassword = ?, GroupID = ?, IsRemoved = ? WHERE" +
				" (UserID = ?) AND (IsRemoved = ?) AND (UserName = ? OR ? IS NULL AND UserName IS" +
				" NULL) AND (UserPassword = ? OR ? IS NULL AND UserPassword IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.sqlConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarWChar, 50, "UserName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserPassword", System.Data.OleDb.OleDbType.VarWChar, 50, "UserPassword"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("GroupID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "GroupID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "IsRemoved"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsRemoved", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserPassword", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserPassword1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPassword", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM Users WHERE (UserID = @Original_UserID) AND (GroupID = @Original_Grou" +
				"pID) AND (IsRemoved = @Original_IsRemoved) AND (UserName = @Original_UserName) A" +
				"ND (UserPassword = @Original_UserPassword)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO Users (UserName, UserPassword, GroupID, IsRemoved) VALUES (@UserName," +
				" @UserPassword, @GroupID, @IsRemoved); SELECT UserID, UserName, UserPassword, Gr" +
				"oupID, IsRemoved FROM Users WHERE (UserID = SCOPE_IDENTITY())";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT UserID, UserName, UserPassword, GroupID, IsRemoved FROM Users";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE Users SET UserName = @UserName, UserPassword = @UserPassword, GroupID = @GroupID, IsRemoved = @IsRemoved WHERE (UserID = @Original_UserID) AND (GroupID = @Original_GroupID) AND (IsRemoved = @Original_IsRemoved) AND (UserName = @Original_UserName) AND (UserPassword = @Original_UserPassword); SELECT UserID, UserName, UserPassword, GroupID, IsRemoved FROM Users WHERE (UserID = @UserID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			// 
			// daUserGroups
			// 
			this.daUserGroups.DeleteCommand = this.oleDbDeleteCommand4;
			this.daUserGroups.InsertCommand = this.oleDbInsertCommand4;
			this.daUserGroups.SelectCommand = this.oleDbSelectCommand4;
			this.daUserGroups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "UsersGroups", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("GroupID", "GroupID"),
																																																				  new System.Data.Common.DataColumnMapping("GroupName", "GroupName"),
																																																				  new System.Data.Common.DataColumnMapping("IsRemoved", "IsRemoved")})});
			this.daUserGroups.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM UsersGroups WHERE (GroupID = ?) AND (GroupName = ? OR ? IS NULL AND G" +
				"roupName IS NULL) AND (IsRemoved = ?)";
			this.oleDbDeleteCommand4.Connection = this.sqlConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GroupID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "GroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GroupName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GroupName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GroupName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GroupName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsRemoved", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO UsersGroups(GroupName, IsRemoved) VALUES (?, ?)";
			this.oleDbInsertCommand4.Connection = this.sqlConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("GroupName", System.Data.OleDb.OleDbType.VarWChar, 50, "GroupName"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "IsRemoved"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT GroupID, GroupName, IsRemoved FROM UsersGroups";
			this.oleDbSelectCommand4.Connection = this.sqlConnection1;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE UsersGroups SET GroupName = ?, IsRemoved = ? WHERE (GroupID = ?) AND (Grou" +
				"pName = ? OR ? IS NULL AND GroupName IS NULL) AND (IsRemoved = ?)";
			this.oleDbUpdateCommand4.Connection = this.sqlConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("GroupName", System.Data.OleDb.OleDbType.VarWChar, 50, "GroupName"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, "IsRemoved"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GroupID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "GroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GroupName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GroupName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GroupName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GroupName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsRemoved", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsRemoved", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM UsersGroups WHERE (GroupID = @Original_GroupID) AND (GroupName = @Ori" +
				"ginal_GroupName) AND (IsRemoved = @Original_IsRemoved)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO UsersGroups (GroupName, IsRemoved) VALUES (@GroupName, @IsRemoved); S" +
				"ELECT GroupID, GroupName, IsRemoved FROM UsersGroups WHERE (GroupID = SCOPE_IDEN" +
				"TITY())";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT GroupID, GroupName, IsRemoved FROM UsersGroups";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE UsersGroups SET GroupName = @GroupName, IsRemoved = @IsRemoved WHERE (GroupID = @Original_GroupID) AND (GroupName = @Original_GroupName) AND (IsRemoved = @Original_IsRemoved); SELECT GroupID, GroupName, IsRemoved FROM UsersGroups WHERE (GroupID = @GroupID)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			// 
			// daUsersPermissions
			// 
			this.daUsersPermissions.DeleteCommand = this.oleDbDeleteCommand3;
			this.daUsersPermissions.InsertCommand = this.oleDbInsertCommand3;
			this.daUsersPermissions.SelectCommand = this.oleDbSelectCommand3;
			this.daUsersPermissions.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "UsersPermissions", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("UserPermissionID", "UserPermissionID"),
																																																							 new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																							 new System.Data.Common.DataColumnMapping("PermissionID", "PermissionID"),
																																																							 new System.Data.Common.DataColumnMapping("Allow", "Allow")})});
			this.daUsersPermissions.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM UsersPermissions WHERE (UserPermissionID = ?) AND (Allow = ?)";
			this.oleDbDeleteCommand3.Connection = this.sqlConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserPermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserPermissionID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Allow", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Allow", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO UsersPermissions(UserID, PermissionID, Allow) VALUES (?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.sqlConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Allow", System.Data.OleDb.OleDbType.Boolean, 2, "Allow"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT PermissionsDescriptions.Description, PermissionsDescriptions.ParentPermissionID, UsersPermissions.UserPermissionID, UsersPermissions.UserID, UsersPermissions.PermissionID, UsersPermissions.Allow, PermissionsDescriptions.PermissionID AS Expr1, PermissionsDescriptions.ShowOrder FROM UsersPermissions INNER JOIN PermissionsDescriptions ON UsersPermissions.PermissionID = PermissionsDescriptions.PermissionID";
			this.oleDbSelectCommand3.Connection = this.sqlConnection1;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE UsersPermissions SET UserID = ?, PermissionID = ?, Allow = ? WHERE (UserPe" +
				"rmissionID = ?) AND (Allow = ?)";
			this.oleDbUpdateCommand3.Connection = this.sqlConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Allow", System.Data.OleDb.OleDbType.Boolean, 2, "Allow"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserPermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserPermissionID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Allow", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Allow", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand4
			// 
			this.sqlDeleteCommand4.CommandText = "DELETE FROM UsersPermissions WHERE (UserPermissionID = @Original_UserPermissionID" +
				") AND (Allow = @Original_Allow) AND (PermissionID = @Original_PermissionID) AND " +
				"(UserID = @Original_UserID)";
			this.sqlDeleteCommand4.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand4
			// 
			this.sqlInsertCommand4.CommandText = "INSERT INTO UsersPermissions(UserID, PermissionID, Allow) VALUES (@UserID, @Permi" +
				"ssionID, @Allow); SELECT UserPermissionID, UserID, PermissionID, Allow FROM User" +
				"sPermissions WHERE (UserPermissionID = @@IDENTITY)";
			this.sqlInsertCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT PermissionsDescriptions.Description, PermissionsDescriptions.ParentPermissionID, UsersPermissions.UserPermissionID, UsersPermissions.UserID, UsersPermissions.PermissionID, UsersPermissions.Allow, PermissionsDescriptions.PermissionID AS Expr1 FROM UsersPermissions INNER JOIN PermissionsDescriptions ON UsersPermissions.PermissionID = PermissionsDescriptions.PermissionID";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand4
			// 
			this.sqlUpdateCommand4.CommandText = @"UPDATE UsersPermissions SET UserID = @UserID, PermissionID = @PermissionID, Allow = @Allow WHERE (UserPermissionID = @Original_UserPermissionID) AND (Allow = @Original_Allow) AND (PermissionID = @Original_PermissionID) AND (UserID = @Original_UserID); SELECT UserPermissionID, UserID, PermissionID, Allow FROM UsersPermissions WHERE (UserPermissionID = @UserPermissionID)";
			this.sqlUpdateCommand4.Connection = this.sqlConnection1;
			// 
			// dvUsersPermissions
			// 
			this.dvUsersPermissions.AllowDelete = false;
			this.dvUsersPermissions.AllowNew = false;
			this.dvUsersPermissions.Sort = "ShowOrder";
			this.dvUsersPermissions.Table = this.dsUsersPermissions1.UsersPermissions;
			// 
			// dsUsersPermissions1
			// 
			this.dsUsersPermissions1.DataSetName = "dsUsersPermissions";
			this.dsUsersPermissions1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsUsersPermissions1.Namespace = "http://www.tempuri.org/dsUsersPermissions.xsd";
			// 
			// daGroupsPermissions
			// 
			this.daGroupsPermissions.DeleteCommand = this.oleDbDeleteCommand1;
			this.daGroupsPermissions.InsertCommand = this.oleDbInsertCommand1;
			this.daGroupsPermissions.SelectCommand = this.oleDbSelectCommand1;
			this.daGroupsPermissions.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "UserGroupsPermissions", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("UserGroupPermissionID", "UserGroupPermissionID"),
																																																								   new System.Data.Common.DataColumnMapping("GroupID", "GroupID"),
																																																								   new System.Data.Common.DataColumnMapping("PermissionID", "PermissionID"),
																																																								   new System.Data.Common.DataColumnMapping("Allow", "Allow")})});
			this.daGroupsPermissions.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM UserGroupsPermissions WHERE (UserGroupPermissionID = ?) AND (Allow = " +
				"?)";
			this.oleDbDeleteCommand1.Connection = this.sqlConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupPermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserGroupPermissionID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Allow", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Allow", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO UserGroupsPermissions(GroupID, PermissionID, Allow) VALUES (?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.sqlConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GroupID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "GroupID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Allow", System.Data.OleDb.OleDbType.Boolean, 2, "Allow"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT PermissionsDescriptions.Description, PermissionsDescriptions.ParentPermissionID, UserGroupsPermissions.UserGroupPermissionID, UserGroupsPermissions.GroupID, UserGroupsPermissions.PermissionID, UserGroupsPermissions.Allow, PermissionsDescriptions.PermissionID AS Expr1, PermissionsDescriptions.ShowOrder FROM UserGroupsPermissions INNER JOIN PermissionsDescriptions ON UserGroupsPermissions.PermissionID = PermissionsDescriptions.PermissionID";
			this.oleDbSelectCommand1.Connection = this.sqlConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE UserGroupsPermissions SET GroupID = ?, PermissionID = ?, Allow = ? WHERE (" +
				"UserGroupPermissionID = ?) AND (Allow = ?)";
			this.oleDbUpdateCommand1.Connection = this.sqlConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GroupID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "GroupID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Allow", System.Data.OleDb.OleDbType.Boolean, 2, "Allow"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupPermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "UserGroupPermissionID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Allow", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Allow", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand5
			// 
			this.sqlDeleteCommand5.CommandText = "DELETE FROM UserGroupsPermissions WHERE (UserGroupPermissionID = @Original_UserGr" +
				"oupPermissionID) AND (Allow = @Original_Allow) AND (GroupID = @Original_GroupID)" +
				" AND (PermissionID = @Original_PermissionID)";
			this.sqlDeleteCommand5.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand5
			// 
			this.sqlInsertCommand5.CommandText = "INSERT INTO UserGroupsPermissions(GroupID, PermissionID, Allow) VALUES (@GroupID," +
				" @PermissionID, @Allow); SELECT UserGroupPermissionID, GroupID, PermissionID, Al" +
				"low FROM UserGroupsPermissions WHERE (UserGroupPermissionID = @@IDENTITY)";
			this.sqlInsertCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT PermissionsDescriptions.Description, PermissionsDescriptions.ParentPermissionID, UserGroupsPermissions.UserGroupPermissionID, UserGroupsPermissions.GroupID, UserGroupsPermissions.PermissionID, UserGroupsPermissions.Allow, PermissionsDescriptions.PermissionID AS Expr1 FROM UserGroupsPermissions INNER JOIN PermissionsDescriptions ON UserGroupsPermissions.PermissionID = PermissionsDescriptions.PermissionID";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand5
			// 
			this.sqlUpdateCommand5.CommandText = @"UPDATE UserGroupsPermissions SET GroupID = @GroupID, PermissionID = @PermissionID, Allow = @Allow WHERE (UserGroupPermissionID = @Original_UserGroupPermissionID) AND (Allow = @Original_Allow) AND (GroupID = @Original_GroupID) AND (PermissionID = @Original_PermissionID); SELECT UserGroupPermissionID, GroupID, PermissionID, Allow FROM UserGroupsPermissions WHERE (UserGroupPermissionID = @UserGroupPermissionID)";
			// 
			// dvGroupsPermissions
			// 
			this.dvGroupsPermissions.AllowDelete = false;
			this.dvGroupsPermissions.AllowNew = false;
			this.dvGroupsPermissions.Sort = "ShowOrder";
			this.dvGroupsPermissions.Table = this.dsGroupsPermissions1.UserGroupsPermissions;
			// 
			// dsGroupsPermissions1
			// 
			this.dsGroupsPermissions1.DataSetName = "dsGroupsPermissions";
			this.dsGroupsPermissions1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsGroupsPermissions1.Namespace = "http://www.tempuri.org/dsGroupsPermissions.xsd";
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNewGroup,
																						this.tbbNewUser,
																						this.tbbDel,
																						this.toolBarButton1,
																						this.tbbChangePwd,
																						this.toolBarButton2,
																						this.tbbShowRem,
																						this.tbbRestore});
			this.toolBar1.ButtonSize = new System.Drawing.Size(130, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imglTb;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(614, 69);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.Enter += new System.EventHandler(this.toolBar1_Enter);
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNewGroup
			// 
			this.tbbNewGroup.ImageIndex = 0;
			this.tbbNewGroup.Text = "Новая группа";
			// 
			// tbbNewUser
			// 
			this.tbbNewUser.ImageIndex = 2;
			this.tbbNewUser.Text = "Новый пользователь";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 1;
			this.tbbDel.Text = "Удалить";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbChangePwd
			// 
			this.tbbChangePwd.ImageIndex = 4;
			this.tbbChangePwd.Text = "Сменить пароль";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbShowRem
			// 
			this.tbbShowRem.ImageIndex = 3;
			this.tbbShowRem.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbShowRem.Text = "Показывать удалённых";
			// 
			// tbbRestore
			// 
			this.tbbRestore.ImageIndex = 5;
			this.tbbRestore.Text = "Восстановить";
			// 
			// imglTb
			// 
			this.imglTb.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imglTb.ImageSize = new System.Drawing.Size(16, 16);
			this.imglTb.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTb.ImageStream")));
			this.imglTb.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// daPermissionList
			// 
			this.daPermissionList.SelectCommand = this.oleDbSelectCommand5;
			this.daPermissionList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "PermissionsDescriptions", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("PermissionID", "PermissionID"),
																																																								  new System.Data.Common.DataColumnMapping("Description", "Description"),
																																																								  new System.Data.Common.DataColumnMapping("PermissionTypeID", "PermissionTypeID"),
																																																								  new System.Data.Common.DataColumnMapping("ParentPermissionID", "ParentPermissionID"),
																																																								  new System.Data.Common.DataColumnMapping("InternalName", "InternalName")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT PermissionID, Description, PermissionTypeID, ParentPermissionID, InternalN" +
				"ame FROM PermissionsDescriptions";
			this.oleDbSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT PermissionID, Description, PermissionTypeID, ParentPermissionID, InternalN" +
				"ame FROM PermissionsDescriptions";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// bnClose
			// 
			this.bnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnClose.Location = new System.Drawing.Point(524, 8);
			this.bnClose.Name = "bnClose";
			this.bnClose.Size = new System.Drawing.Size(80, 26);
			this.bnClose.TabIndex = 5;
			this.bnClose.Text = "Закрыть";
			this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(440, 8);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 4;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// dsPermissionsList1
			// 
			this.dsPermissionsList1.DataSetName = "dsPermissionsList";
			this.dsPermissionsList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsPermissionsList1.Namespace = "http://www.tempuri.org/dsPermissionsList.xsd";
			// 
			// dsUserGroups1
			// 
			this.dsUserGroups1.DataSetName = "dsUserGroups";
			this.dsUserGroups1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsUserGroups1.Namespace = "http://www.tempuri.org/dsUserGroups.xsd";
			// 
			// dsUsers1
			// 
			this.dsUsers1.DataSetName = "dsUsers";
			this.dsUsers1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsUsers1.Namespace = "http://www.tempuri.org/dsUsers.xsd";
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.bnCancel,
																				 this.bnClose,
																				 this.bnSave});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 471);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(614, 40);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataGridV1,
																				 this.splitter1,
																				 this.treeView1});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 69);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(614, 402);
			this.panel2.TabIndex = 7;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(220, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 402);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// Users
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnClose;
			this.ClientSize = new System.Drawing.Size(614, 511);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel2,
																		  this.panel1,
																		  this.toolBar1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Users";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Пользователи";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Users_Closing);
			this.Load += new System.EventHandler(this.Users_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUsersPermissions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersPermissions1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvGroupsPermissions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsGroupsPermissions1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPermissionsList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUserGroups1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUsers1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void fillTree()
		{
			ArrayList ar = new ArrayList();
			if(this.treeView1.Nodes.Count>0)
				this.memTreeExpand(ar);
			this.treeView1.Nodes.Clear();
			int iNodeCount = -1;
			for(int i=0; i < this.dsUserGroups1.UsersGroups.Count; i++)
			{
				if(this.dsUserGroups1.UsersGroups[i].IsRemoved && !this.bIsShowRem)
					continue;
				TreeNode tr = new TreeNode(this.dsUserGroups1.UsersGroups[i].GroupName);
				tr.Tag = this.dsUserGroups1.UsersGroups[i].GroupID;
				if(this.dsUserGroups1.UsersGroups[i].IsRemoved)
				{
					tr.ImageIndex = 3;
					tr.SelectedImageIndex = 3;
				}
				else
				{
					tr.ImageIndex = 0;
					tr.SelectedImageIndex = 0;
				}
				this.treeView1.Nodes.Add(tr);
				iNodeCount++;
				DataRow [] dr = this.dsUsers1.Users.Select("GroupID=" + this.dsUserGroups1.UsersGroups[i].GroupID.ToString());
				for(int j=0; j<dr.Length; j++)
				{
					XSD.dsUsers.UsersRow rw = (XSD.dsUsers.UsersRow) dr[j];
					if(rw.IsRemoved && !this.bIsShowRem)
						continue;
					TreeNode tru = new TreeNode(rw.UserName);
					tru.Tag = rw.UserID;
					if(rw.IsRemoved)
					{
						tru.ImageIndex = 2;
						tru.SelectedImageIndex = 2;
					}
					else
					{
						tru.ImageIndex = 1;
						tru.SelectedImageIndex = 1;
					}
					this.treeView1.Nodes[iNodeCount].Nodes.Add(tru);
				}
				if((int)ar.IndexOf(this.treeView1.Nodes[iNodeCount].Tag)>-1)
					this.treeView1.Nodes[iNodeCount].Expand();
			}
			if(this.treeView1.Nodes.Count > 0)
				this.treeView1.SelectedNode = this.treeView1.Nodes[0];
			if(this.treeView1.Nodes.Count == 1)
			{
				this.dataGridV1.DataSource = this.dvGroupsPermissions;
				this.dvGroupsPermissions.RowFilter = "GroupID=" + this.treeView1.SelectedNode.Tag.ToString();
				this.dataGridV1.CaptionText = "Разрешения для группы пользователей " + this.treeView1.SelectedNode.Text.ToUpper();
			}
		}
		private void memTreeExpand(ArrayList ar)
		{
			for(int i = 0; i<this.treeView1.Nodes.Count; i++)
			{
				if(this.treeView1.Nodes[i].IsExpanded)
					ar.Add(this.treeView1.Nodes[i].Tag);
			}
		}
		private void fillDs()
		{
			try
			{
				this.fillCustomDs(this.daPermissionList, (DataTable) this.dsPermissionsList1.PermissionsDescriptions);
				this.fillCustomDs(this.daUserGroups, (DataTable) this.dsUserGroups1.UsersGroups);
				this.fillCustomDs(this.daUsers, (DataTable) this.dsUsers1.Users);
				this.fillCustomDs(this.daGroupsPermissions, (DataTable) this.dsGroupsPermissions1.UserGroupsPermissions);
				this.fillCustomDs(this.daUsersPermissions, (DataTable) this.dsUsersPermissions1.UsersPermissions);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void fillCustomDs(OleDbDataAdapter da, DataTable dt)
		{
			try
			{
				dt.Clear();
				da.Fill(dt);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void updateCustomDs(OleDbDataAdapter da, DataTable ds)
		{
			try
			{
				da.Update(ds);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(!this.bIsTreeLeave)
				return;
			this.saveChange();
			if(this.treeView1.SelectedNode.Parent == null)
			{
				this.dataGridV1.DataSource = this.dvGroupsPermissions;
				this.dvGroupsPermissions.RowFilter = "GroupID=" + this.treeView1.SelectedNode.Tag.ToString();
				this.dataGridV1.CaptionText = "Разрешения для группы пользователей " + this.treeView1.SelectedNode.Text.ToUpper();
			}
			else
			{
				this.dataGridV1.DataSource = this.dvUsersPermissions;
				this.dvUsersPermissions.RowFilter = "UserID=" + this.treeView1.SelectedNode.Tag.ToString();
				this.dataGridV1.CaptionText = "Разрешения для пользователя " + this.treeView1.SelectedNode.Text.ToUpper();// + " групы " + this.treeView1.SelectedNode.Parent.Text.ToUpper();
			}
		}
		private void saveChange()
		{
			if(this.dsGroupsPermissions1.UserGroupsPermissions.Select("","",DataViewRowState.ModifiedOriginal).Length > 0)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения в разрешениях для группы '" + this.treeView1.Nodes[PrevNode.PrevNodeThis].Text + "'?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
					this.updatePermissions();
				else
					this.dsGroupsPermissions1.RejectChanges();
			}
			if(this.dsUsersPermissions1.UsersPermissions.Select("","",DataViewRowState.ModifiedOriginal).Length > 0)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения в разрешениях для пользователя '" + this.treeView1.Nodes[PrevNode.PrevNodeParent].Nodes[PrevNode.PrevNodeThis].Text + "'?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
					this.updatePermissions();
				else
					this.dsUsersPermissions1.RejectChanges();
			}	
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			this.toolBar1.Focus();
			if (e.Button == this.tbbNewGroup)
			{
				this.addGroup();
			}
			else if (e.Button == this.tbbNewUser)
			{
				this.addUser();
			}
			else if(e.Button == this.tbbDel)
			{
				this.stateUserOrGroup(true);
			}
			else if(e.Button == this.tbbShowRem)
			{
				this.bIsShowRem = this.tbbShowRem.Pushed;
				this.fillTree();
			}
			else if(e.Button == this.tbbChangePwd)
				this.changePwd();
			else if(e.Button == this.tbbRestore)
				this.stateUserOrGroup(false);
		}
		private void changePwd()
		{
			if((this.treeView1.SelectedNode == null) || (this.treeView1.SelectedNode.Parent == null))
			{
				AM_Controls.MsgBoxX.Show("Невозможно сменить пароль. Не выбран пользователь.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			DataRow [] dr = this.dsUsers1.Users.Select("UserID=" + this.treeView1.SelectedNode.Tag.ToString());
			if(dr.Length != 1)
				return;
			XSD.dsUsers.UsersRow rw = (XSD.dsUsers.UsersRow) dr[0];
			string szGroupName = this.treeView1.SelectedNode.Parent.Text;
			AddUser cp = new AddUser(true);
			cp.Text = "Смена пароля";
			cp.GroupName = szGroupName;
			cp.UserName = rw.UserName;
			cp.ShowDialog();
			if(cp.DialogResult == DialogResult.OK)
			{
				rw.UserPassword = this.getMD5Pwd(cp.UserPwd);
				this.updateCustomDs(this.daUsers, this.dsUsers1.Users);
			}
		}
		private void stateUserOrGroup(bool isRemoved)
		{
			if(this.treeView1.SelectedNode == null)
				return;
			if(this.treeView1.SelectedNode.Parent == null)
			{
				this.stateGroup(isRemoved);
			}
			else
			{
				this.stateUser(isRemoved);
			}
			this.fillTree();
		}
		private void stateUser(bool isRemoved)
		{
			DataRow [] dr = this.dsUsers1.Users.Select("UserID=" + this.treeView1.SelectedNode.Tag.ToString());
			if(dr.Length == 1)
			{
				XSD.dsUsers.UsersRow rw = (XSD.dsUsers.UsersRow) dr[0];
				rw.IsRemoved = isRemoved;
				this.updateCustomDs(this.daUsers, this.dsUsers1.Users);
			}
		}
		private void stateGroup(bool isRemoved)
		{
			DataRow [] dr = this.dsUserGroups1.UsersGroups.Select("GroupID=" + this.treeView1.SelectedNode.Tag.ToString());
			if(dr.Length == 1)
			{
				XSD.dsUserGroups.UsersGroupsRow rw = (XSD.dsUserGroups.UsersGroupsRow) dr[0];
				if(rw.IsRemoved == isRemoved)
				{
					this.treeView1.SelectedNode = this.treeView1.Nodes[0];
					return;
				}
				rw.IsRemoved = isRemoved;
				DataRow [] dru = this.dsUsers1.Users.Select("GroupID=" + this.treeView1.SelectedNode.Tag.ToString());
				for(int i=0; i<dru.Length; i++)
				{
					XSD.dsUsers.UsersRow urw = (XSD.dsUsers.UsersRow) dru[i];
					urw.IsRemoved = isRemoved;
				}
				this.updateCustomDs(this.daUserGroups, this.dsUserGroups1.UsersGroups);
				this.updateCustomDs(this.daUsers, this.dsUsers1.Users);
			}
		}
		private void addGroup()
		{
			AddUserGroup aug = new AddUserGroup();
			aug.ShowDialog();
			if(aug.DialogResult == DialogResult.OK)
			{
				XSD.dsUserGroups.UsersGroupsRow rw = this.dsUserGroups1.UsersGroups.NewUsersGroupsRow();
				rw.GroupName = aug.tbName.Text;
				rw.IsRemoved = false;
				this.dsUserGroups1.UsersGroups.AddUsersGroupsRow(rw);
				//----------------------Транзакция
				OleDbCommand cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", this.sqlConnection1);
				OleDbCommand cmdInsGroup = new OleDbCommand("INSERT INTO UserGroupsPermissions (GroupID, PermissionID)" +
															" SELECT ? AS GroupID, PermissionsDescriptions.PermissionID FROM PermissionsDescriptions", this.sqlConnection1);
				cmdInsGroup.Parameters.Add(new OleDbParameter("@GroupID", OleDbType.Integer));
				this.sqlConnection1.Open();
				OleDbTransaction tr = this.sqlConnection1.BeginTransaction();
				this.daUserGroups.InsertCommand.Transaction = cmdInsGroup.Transaction = cmdGetIdentity.Transaction = tr;
				try
				{
					this.daUserGroups.Update(this.dsUserGroups1.UsersGroups);
					object o = cmdGetIdentity.ExecuteScalar();
					if(o == Convert.DBNull)
					{
						tr.Rollback();
						return;
					}
					rw.GroupID = Convert.ToInt32(o);
					this.dsUserGroups1.UsersGroups.AcceptChanges();
					cmdInsGroup.Parameters["@GroupID"].Value = Convert.ToInt32(o);
					cmdInsGroup.ExecuteNonQuery();
					tr.Commit();
					//this.updateCustomDs(this.daUserGroups, this.dsUserGroups1.UsersGroups);
					this.fillCustomDs(this.daGroupsPermissions, (DataTable) this.dsGroupsPermissions1.UserGroupsPermissions);
					this.fillTree();
				}
				catch(Exception ex)
				{
					tr.Rollback();
					this.dsUserGroups1.UsersGroups.RejectChanges();
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				finally
				{
					this.sqlConnection1.Close();
				}
				//this.updateCustomDs(this.daUserGroups, this.dsUserGroups1.UsersGroups);
				
			}
		}
		private void addUser()
		{
			if(this.treeView1.SelectedNode == null)
			{
				AM_Controls.MsgBoxX.Show("Невозможно создать пользователя. Сначала создайте группу пользователей.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			int iGroupID = 0;
			string szGroupName = "";
			if(this.treeView1.SelectedNode.Parent != null)
			{
				iGroupID = (int)this.treeView1.SelectedNode.Parent.Tag;
				szGroupName = this.treeView1.SelectedNode.Parent.Text;
			}
			else
			{
				iGroupID = (int) this.treeView1.SelectedNode.Tag;
				szGroupName = this.treeView1.SelectedNode.Text;
			}
			AddUser au = new AddUser(false);
			au.GroupName = szGroupName;
			au.ShowDialog();
			if(au.DialogResult == DialogResult.OK)
			{
				AuthControl.XSD.dsUsers.UsersRow rw = this.dsUsers1.Users.NewUsersRow();
				rw.GroupID = iGroupID;
				rw.UserName = au.UserName;
				rw.UserPassword = this.getMD5Pwd(au.UserPwd);
				rw.IsRemoved = false;
				DataRow [] dr = this.dsUsers1.Users.Select("UserName='" + rw.UserName + "'");
				if(dr.Length>0)
				{
					AM_Controls.MsgBoxX.Show("Невозможно создать пользователя " + rw.UserName.ToUpper() + "! Пользователь с таким именем уже существует.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				this.dsUsers1.Users.AddUsersRow(rw);
				//----------Транзакция
				OleDbCommand cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", this.sqlConnection1);
				OleDbCommand cmdInsUserPermissions = new OleDbCommand("INSERT INTO UsersPermissions (UserID, PermissionID, Allow)" +
																	  " SELECT ? AS UserID, UserGroupsPermissions.PermissionID, UserGroupsPermissions.Allow FROM" +
																	  " UserGroupsPermissions WHERE UserGroupsPermissions.GroupID = ?", this.sqlConnection1);
				cmdInsUserPermissions.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer));
				cmdInsUserPermissions.Parameters.Add(new OleDbParameter("@GroupID", OleDbType.Integer));
				this.sqlConnection1.Open();
				OleDbTransaction tr = this.sqlConnection1.BeginTransaction();
				
				this.daUsers.InsertCommand.Transaction = cmdInsUserPermissions.Transaction = cmdGetIdentity.Transaction = tr;
				try
				{
					
					this.daUsers.Update(this.dsUsers1.Users);
					object o = cmdGetIdentity.ExecuteScalar();
					if(o == Convert.DBNull)
					{
						tr.Rollback();
						return;
					}
					rw.UserID = Convert.ToInt32(o);
					this.dsUsers1.Users.AcceptChanges();
					cmdInsUserPermissions.Parameters["@UserID"].Value = Convert.ToInt32(o);
					cmdInsUserPermissions.Parameters["@GroupID"].Value = rw.GroupID;
					cmdInsUserPermissions.ExecuteNonQuery();
					tr.Commit();
					//this.updateCustomDs(this.daUsers, this.dsUsers1.Users);
					this.fillCustomDs(this.daUsersPermissions, (DataTable) this.dsUsersPermissions1.UsersPermissions);
					this.fillTree();
				}
				catch(Exception ex)
				{
					tr.Rollback();
					this.dsUsers1.Users.RejectChanges();
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				finally
				{
					this.sqlConnection1.Close();
				}
				//this.updateCustomDs(this.daUsers, this.dsUsers1.Users);
				
			}
		}
		private void updatePermissions()
		{
			this.updateCustomDs(this.daUsersPermissions, this.dsUsersPermissions1.UsersPermissions);
			this.updateCustomDs(this.daGroupsPermissions, this.dsGroupsPermissions1.UserGroupsPermissions);
		}
		private string getMD5Pwd(string szUncryptPwd)
		{
			UnicodeEncoding ue = new UnicodeEncoding();
			byte [] bPwd = ue.GetBytes(szUncryptPwd);
			MD5 md5 = new MD5CryptoServiceProvider();
			byte [] resPwd = md5.ComputeHash(bPwd);
			return BitConverter.ToString(resPwd);
		}
		private void bnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bnSave_Click(object sender, System.EventArgs e)
		{
			this.updatePermissions();
		}

		private void treeView1_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			this.memPrevNode();
		}

		private void dataGridV1_Leave(object sender, System.EventArgs e)
		{
			//this.dgEndEdit();
			//this.saveChange();
		}
		private void dgEndEdit()
		{
			if(this.treeView1.SelectedNode == null)
				return;
			if(this.treeView1.SelectedNode.Parent == null)
			{
				bm = (BindingManagerBase) this.BindingContext[this.dsGroupsPermissions1.UserGroupsPermissions];
			}
			else
			{
				bm = (BindingManagerBase) this.BindingContext[this.dsUsersPermissions1.UsersPermissions];
			}
			bm.CancelCurrentEdit();
			bm.EndCurrentEdit();
		}
		private void treeView1_Enter(object sender, System.EventArgs e)
		{
			if((PrevNode.PrevNodeParent == -1) && (PrevNode.PrevNodeThis != -1))
				this.treeView1.SelectedNode = this.treeView1.Nodes[PrevNode.PrevNodeThis];
			else if(PrevNode.PrevNodeParent != -1)
				this.treeView1.SelectedNode = this.treeView1.Nodes[PrevNode.PrevNodeParent].Nodes[PrevNode.PrevNodeThis];
			//this.saveChange();
			this.bIsTreeLeave = true;
		}
		private void memPrevNode()
		{
			if(this.treeView1.SelectedNode != null)
			{
				PrevNode.PrevNodeThis = treeView1.SelectedNode.Index;
				if(treeView1.SelectedNode.Parent == null)
					PrevNode.PrevNodeParent = -1;
				else
					PrevNode.PrevNodeParent = treeView1.SelectedNode.Parent.Index;
			}
		}
		private void treeView1_Leave(object sender, System.EventArgs e)
		{
			this.bIsTreeLeave = false;
			this.memPrevNode();	
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.dsUsersPermissions1.RejectChanges();
			this.dsGroupsPermissions1.RejectChanges();
		}

		private void toolBar1_Enter(object sender, System.EventArgs e)
		{
			this.saveChange();
		}

		private void dataGridV1_Click(object sender, System.EventArgs e)
		{
			DataView dv = (DataView) this.dataGridV1.DataSource;
			if(dv.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase) this.BindingContext[this.dataGridV1.DataSource];
			DataRow dr = ((DataRowView) bm.Current).Row;
			if(this.dataGridV1.CurrentCell.ColumnNumber == 1)
			{
				dr.BeginEdit();
				/*if((bool)dr["Allow"])
					dr["Allow"] = false;
				else
					dr["Allow"] = true;*/
				dr.EndEdit();
			}
		}

		private void Users_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.saveChange();
		}

		private void Users_Load(object sender, System.EventArgs e)
		{
			this.treeView1.Focus();
			this.memPrevNode();
		}
	}
	internal class PrevNode
	{
		public static int PrevNodeThis = -1;
		public static  int PrevNodeParent = -1;
		static PrevNode()
		{
		}
	}
}
