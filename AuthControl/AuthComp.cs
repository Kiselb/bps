using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Reflection;

namespace AuthControl
{
	/// <summary>
	/// Summary description for AuthComp.
	/// </summary>
	public class AuthComp : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbDataAdapter daUserPermissions;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private AuthControl.dsUserInfo dsUserInfo1;
		private string szConnectionString = "";
		private string szUsername = "";
		//private int iUserID;
		//private int iUserLogonHistoryID;
		public AuthComp(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public AuthComp(string szConnectionString)
		{
			InitializeComponent();
			this.szConnectionString = szConnectionString;
			this.oleDbConnection1.ConnectionString = szConnectionString;
		}
		public string UserName
		{
			get
			{
				return this.szUsername;
			}
		}
		/*public int UserID
		{
			get
			{
				return this.iUserID;
			}
		}
		public int UserLogonHistoryID
		{
			get
			{
				return this.iUserLogonHistoryID;
			}
		}*/
		public void DoLogon(DataTable dt, ref int iUserID, ref int iUserLogonHistoryID)
		{
			Assembly asm =Assembly.GetCallingAssembly();
			string[] szName  = asm.FullName.Split(',');
			Logon frmLogon =new Logon(this.szConnectionString, szName[0]);
			frmLogon.ShowDialog();
			if (frmLogon.DialogResult == DialogResult.OK) 
			{
				if(this.fillUserPermissions(dt, frmLogon.UserID))
				{
					szUsername = frmLogon.UserName;
					iUserID = frmLogon.UserID;
					iUserLogonHistoryID = frmLogon.UserLogonHistoryID;
				}
				else
				{
					iUserID = -1;
					iUserLogonHistoryID = -1;
				}
			}
			else
			{
				iUserID = -1;
				iUserLogonHistoryID = -1;
			}
		}
		private bool fillUserPermissions(DataTable dt, int thisUserID)
		{
			try
			{
				this.daUserPermissions.SelectCommand.CommandText += " WHERE UsersPermissions.UserID=" + thisUserID.ToString();
				this.daUserPermissions.Fill(this.dsUserInfo1);
				for(int i=0; i< this.dsUserInfo1._Table.Count; i++)
				{
					DataColumn dc = new DataColumn(dsUserInfo1._Table[i].InternalName);
					dc.DataType = typeof(bool);
					dt.Columns.Add(dc);
				}
				DataRow dr = dt.NewRow();
				for(int i=0; i< this.dsUserInfo1._Table.Count; i++)
				{
					dr[dsUserInfo1._Table[i].InternalName] = dsUserInfo1._Table[i].Allow;
				}
				dt.Rows.Add(dr);
				return true;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return false;
		}
		public void UpdateUserHistory(int iUserLogonHistoryID)
		{
			//Запись времени выхода
		//	OleDbCommand cmdUpdUsrHist = new OleDbCommand("UPDATE UsersLogonHistory SET LogoutTime='" + DateTime.Now + "' WHERE ID=" + iUserLogonHistoryID.ToString(), this.oleDbConnection1);
			OleDbCommand cmdUpdUsrHist = new OleDbCommand("UPDATE UsersLogonHistory SET LogoutTime=?" + " WHERE ID=" + iUserLogonHistoryID.ToString(), this.oleDbConnection1);
			cmdUpdUsrHist.Parameters.Add(new OleDbParameter("LogoutTime", OleDbType.Date));
			cmdUpdUsrHist.Parameters["LogoutTime"].Value = DateTime.Now;
			try
			{
				cmdUpdUsrHist.Connection.Open();
				cmdUpdUsrHist.ExecuteNonQuery();
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
			finally
			{
				cmdUpdUsrHist.Connection.Close();
			}
		}
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.daUserPermissions = new System.Data.OleDb.OleDbDataAdapter();
			this.dsUserInfo1 = new AuthControl.dsUserInfo();
			((System.ComponentModel.ISupportInitialize)(this.dsUserInfo1)).BeginInit();
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT UsersPermissions.Allow, UsersPermissions.UserPermissionID, PermissionsDescriptions.InternalName, PermissionsDescriptions.Description, PermissionsDescriptions.PermissionTypeID, PermissionsDescriptions.ParentPermissionID, UsersPermissions.PermissionID FROM UsersPermissions INNER JOIN PermissionsDescriptions ON UsersPermissions.PermissionID = PermissionsDescriptions.PermissionID";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// daUserPermissions
			// 
			this.daUserPermissions.DeleteCommand = this.oleDbDeleteCommand1;
			this.daUserPermissions.InsertCommand = this.oleDbInsertCommand1;
			this.daUserPermissions.SelectCommand = this.oleDbSelectCommand1;
			this.daUserPermissions.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// dsUserInfo1
			// 
			this.dsUserInfo1.DataSetName = "dsUserInfo";
			this.dsUserInfo1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsUserInfo1.Namespace = "http://www.tempuri.org/dsUserInfo.xsd";
			((System.ComponentModel.ISupportInitialize)(this.dsUserInfo1)).EndInit();

		}
		#endregion
	}
}
