using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace AuthControl
{
	/// <summary>
	/// Summary description for PermissionsList.
	/// </summary>
	public class PermissionsList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbAdd;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbbUpdt;
		private System.Windows.Forms.ImageList imageList1;
		private AM_Controls.DataGridV dataGridV1;
		private AuthControl.XSD.dsPermissionsList dsPermissionsList1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.ComponentModel.IContainer components;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private string szConnectionString;
		public PermissionsList(string szConnectionString)
		{
			//
			// Required for Windows Form Designer support
			this.szConnectionString = szConnectionString;
			InitializeComponent();
			this.oleDbConnection1.ConnectionString = szConnectionString;
			this.fillDs();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public DataGridTableStyle GridStyle
		{
			get
			{
				return this.dataGridTableStyle1;
			}
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PermissionsList));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbAdd = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbUpdt = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.dataView1 = new System.Data.DataView();
			this.dsPermissionsList1 = new AuthControl.XSD.dsPermissionsList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPermissionsList1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbAdd,
																						this.tbbEdit,
																						this.toolBarButton1,
																						this.tbbUpdt});
			this.toolBar1.ButtonSize = new System.Drawing.Size(120, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(566, 25);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbAdd
			// 
			this.tbbAdd.ImageIndex = 0;
			this.tbbAdd.Text = "Новое";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Изменить";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbUpdt
			// 
			this.tbbUpdt.ImageIndex = 3;
			this.tbbUpdt.Text = "Обновить";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1.CaptionVisible = false;
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dataView1;
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 25);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.ReadOnly = true;
			this.dataGridV1.Size = new System.Drawing.Size(566, 370);
			this.dataGridV1.TabIndex = 1;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			this.dataGridV1.DoubleClick += new System.EventHandler(this.dataGridV1_DoubleClick);
			// 
			// dataView1
			// 
			this.dataView1.Table = this.dsPermissionsList1.PermissionsDescriptions;
			// 
			// dsPermissionsList1
			// 
			this.dsPermissionsList1.DataSetName = "dsPermissionsList";
			this.dsPermissionsList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsPermissionsList1.Namespace = "http://www.tempuri.org/dsPermissionsList.xsd";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridV1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "PermissionsDescriptions";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "ID";
			this.dataGridTextBoxColumn1.MappingName = "PermissionID";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Описание";
			this.dataGridTextBoxColumn2.MappingName = "Description";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 250;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Внутреннее имя";
			this.dataGridTextBoxColumn3.MappingName = "InternalName";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 200;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "PermissionsDescriptions", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("PermissionID", "PermissionID"),
																																																								   new System.Data.Common.DataColumnMapping("InternalName", "InternalName"),
																																																								   new System.Data.Common.DataColumnMapping("Description", "Description"),
																																																								   new System.Data.Common.DataColumnMapping("PermissionTypeID", "PermissionTypeID"),
																																																								   new System.Data.Common.DataColumnMapping("ParentPermissionID", "ParentPermissionID")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT PermissionID, InternalName, Description, PermissionTypeID, ParentPermissio" +
				"nID FROM PermissionsDescriptions";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO PermissionsDescriptions(InternalName, Description, PermissionTypeID, " +
				"ParentPermissionID) VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InternalName", System.Data.OleDb.OleDbType.VarWChar, 50, "InternalName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 50, "Description"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermissionTypeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionTypeID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ParentPermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ParentPermissionID", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE PermissionsDescriptions SET InternalName = ?, Description = ?, PermissionTypeID = ?, ParentPermissionID = ? WHERE (PermissionID = ?) AND (Description = ? OR ? IS NULL AND Description IS NULL) AND (InternalName = ? OR ? IS NULL AND InternalName IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InternalName", System.Data.OleDb.OleDbType.VarWChar, 50, "InternalName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 50, "Description"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PermissionTypeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionTypeID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ParentPermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ParentPermissionID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InternalName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InternalName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InternalName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InternalName", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM PermissionsDescriptions WHERE (PermissionID = ?) AND (Description = ?" +
				" OR ? IS NULL AND Description IS NULL) AND (InternalName = ? OR ? IS NULL AND In" +
				"ternalName IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PermissionID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PermissionID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Description1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InternalName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InternalName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InternalName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InternalName", System.Data.DataRowVersion.Original, null));
			// 
			// PermissionsList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(566, 395);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGridV1,
																		  this.toolBar1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PermissionsList";
			this.Text = "Разрешения";
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPermissionsList1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private void fillDs()
		{
			try
			{
				this.oleDbDataAdapter1.Fill(this.dsPermissionsList1);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbbUpdt)
				this.fillDs();
			else if(e.Button == this.tbbAdd)
				this.addPermission();
			else if(e.Button == this.tbbEdit)
				this.editPermission();
		}
		private void addPermission()
		{
			XSD.dsPermissionsList.PermissionsDescriptionsRow rw = (XSD.dsPermissionsList.PermissionsDescriptionsRow) this.dataView1.Table.NewRow();
			PermissionsEdit pe = new PermissionsEdit(rw, this.dataView1, false);
			pe.Text += " [Новое]";
			pe.ShowDialog();
			if(pe.DialogResult == DialogResult.OK)
			{
				this.dataView1.Table.Rows.Add((DataRow) rw);
				OleDbCommand cmdGetIdentity = new OleDbCommand("SELECT @@IDENTITY", this.oleDbConnection1);
				OleDbCommand cmdInsInUserPerm = new OleDbCommand("INSERT INTO UsersPermissions (UserID, PermissionID)" +
																 " SELECT UserID, ? AS PermissionID FROM Users", this.oleDbConnection1);
				cmdInsInUserPerm.Parameters.Add(new OleDbParameter("@PermissionID", OleDbType.Integer));
				OleDbCommand cmdInsInGroupPerm = new OleDbCommand("INSERT INTO UserGroupsPermissions (GroupID, PermissionID)" +
																  " SELECT GroupID, ? AS PermissionID FROM UsersGroups", this.oleDbConnection1);
				cmdInsInGroupPerm.Parameters.Add(new OleDbParameter("@PermissionID", OleDbType.Integer));
				this.oleDbConnection1.Open();
				OleDbTransaction tr = this.oleDbConnection1.BeginTransaction();
				cmdGetIdentity.Transaction = this.oleDbDataAdapter1.InsertCommand.Transaction = cmdInsInUserPerm.Transaction = cmdInsInGroupPerm.Transaction = tr;
				try
				{
					this.oleDbDataAdapter1.Update(this.dsPermissionsList1.PermissionsDescriptions);
					object o = cmdGetIdentity.ExecuteScalar();
					if(o == Convert.DBNull)
					{
						tr.Rollback();
						return;
					}
					rw.PermissionID = Convert.ToInt32(o);
					this.dsPermissionsList1.PermissionsDescriptions.AcceptChanges();
					cmdInsInUserPerm.Parameters["@PermissionID"].Value = rw.PermissionID;
					cmdInsInUserPerm.ExecuteNonQuery();
					cmdInsInGroupPerm.Parameters["@PermissionID"].Value = rw.PermissionID;
					cmdInsInGroupPerm.ExecuteNonQuery();
					tr.Commit();
				}
				catch(Exception ex)
				{
					tr.Rollback();
					this.dsPermissionsList1.PermissionsDescriptions.RejectChanges();
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				finally
				{
					this.oleDbConnection1.Close();
				}
			}
		}
		private void editPermission()
		{
			if(this.dataView1.Count == 0)
				return;
			BindingManagerBase bm = (BindingManagerBase)  this.BindingContext[this.dataView1];
			XSD.dsPermissionsList.PermissionsDescriptionsRow rw = (XSD.dsPermissionsList.PermissionsDescriptionsRow) ((DataRowView) bm.Current).Row;
			PermissionsEdit pe = new PermissionsEdit(rw, this.dataView1, true);
			pe.Text += " [Редактирование]";
			pe.ShowDialog();
			if(pe.DialogResult == DialogResult.OK)
			{
				try
				{
					this.oleDbDataAdapter1.Update(this.dsPermissionsList1.PermissionsDescriptions);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void dataGridV1_DoubleClick(object sender, System.EventArgs e)
		{
			this.editPermission();
		}
	}
}
