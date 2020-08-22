using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace AuthControl
{
	/// <summary>
	/// Summary description for Logon.
	/// </summary>
	internal class Logon :  System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.TextBox tbUserLogonName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		public string UserName {get {return tbUserLogonName.Text; } }
		private int iUserID;
		private int iUserLogonID;
		private string ProgName;
		public Logon(string szConnectionString, string szProgName)
		{
			InitializeComponent();
			ProgName = szProgName;
			this.Text = this.Text + "  \""+ szProgName +"\"";
			this.oleDbConnection1.ConnectionString = szConnectionString;
			/*
			//Получение логина последнего захода с этого компьютера
			string szCmdTxt = "SELECT Users.UserName FROM  Users INNER JOIN " + 
				" UsersLogonHistory ON Users.UserID = UsersLogonHistory.UserID " + 
				" WHERE (UsersLogonHistory.ID IN (SELECT MAX(ID) AS ID1" +
				" FROM UsersLogonHistory WHERE   ComputerName = ?))";
			OleDbCommand cmdGetLogon = new OleDbCommand(szCmdTxt, this.oleDbConnection1);
			cmdGetLogon.Parameters.Add(new OleDbParameter("@CompName", OleDbType.VarWChar, 50));
			cmdGetLogon.Parameters["@CompName"].Value = SystemInformation.ComputerName;
			try
			{
				this.oleDbConnection1.Open();
				object o = cmdGetLogon.ExecuteScalar();
				if(o != Convert.DBNull)
					this.tbUserLogonName.Text = o.ToString();
			}
			catch//(Exception ex)
			{
				//AM_Controls.MsgBoxX.Show(ex.Message,"BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				this.oleDbConnection1.Close();
			}
*/
		}
		public int UserID
		{
			get
			{
				return iUserID;
			}
		}
		public int UserLogonHistoryID
		{
			get
			{
				return iUserLogonID;
			}
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Logon));
			this.tbUserLogonName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.SuspendLayout();
			// 
			// tbUserLogonName
			// 
			this.tbUserLogonName.Location = new System.Drawing.Point(84, 10);
			this.tbUserLogonName.Name = "tbUserLogonName";
			this.tbUserLogonName.Size = new System.Drawing.Size(234, 26);
			this.tbUserLogonName.TabIndex = 1;
			this.tbUserLogonName.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Имя:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Пароль:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(84, 38);
			this.tbPassword.MaxLength = 14;
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(234, 26);
			this.tbPassword.TabIndex = 2;
			this.tbPassword.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnOK.BackColor = System.Drawing.SystemColors.Control;
			this.btnOK.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOK.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOK.Image")));
			this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOK.Location = new System.Drawing.Point(108, 76);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(104, 28);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "Войти";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancel.Image")));
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new System.Drawing.Point(214, 76);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 28);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Выйти";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Logon
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(322, 107);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOK,
																		  this.label2,
																		  this.tbPassword,
																		  this.label1,
																		  this.tbUserLogonName});
			this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Logon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Регистрация в системе";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Logon_KeyPress);
			this.Load += new System.EventHandler(this.Logon_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void Logon_Load(object sender, System.EventArgs e)
		{
			this.tbUserLogonName.Focus();
			if (this.tbUserLogonName.Text.Length>0)
			{
				this.tbPassword.TabIndex = 0;
				this.tbUserLogonName.TabIndex = 1;
			}
			else
			{
				this.tbPassword.TabIndex = 1;
				this.tbUserLogonName.TabIndex = 0;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			VerifyUser();
		}
		
		private void VerifyUser()
		{
			string szThisComputer = SystemInformation.ComputerName;
			string psw = "";
			if ((this.tbUserLogonName.Text.Length >0) 
				&& (this.tbPassword.Text.Length >0)) 
			{
				//Верификация
				string strCommandText ="SELECT Users.UserID, Users.UserName, Users.UserPassword, Users.GroupID"
				+ " FROM Users WHERE Users.UserName = ? AND IsRemoved=?";
				OleDbCommand cmdUserLoad = new OleDbCommand (strCommandText, this.oleDbConnection1);
				cmdUserLoad.Parameters.Add(new OleDbParameter("@UserName", OleDbType.VarWChar, 50));
				cmdUserLoad.Parameters["@UserName"].Direction = ParameterDirection.Input;
				cmdUserLoad.Parameters["@UserName"].Value = this.tbUserLogonName.Text;
				cmdUserLoad.Parameters.Add(new OleDbParameter("@IsRemoved", OleDbType.Boolean));
				cmdUserLoad.Parameters["@IsRemoved"].Value = false;
				cmdUserLoad.Connection.Open();
				OleDbDataReader rdrUserLoad=null;
				try 
				{
					rdrUserLoad= cmdUserLoad.ExecuteReader();
					bool bReadOk =rdrUserLoad.Read();
					if ( bReadOk)
					{
						iUserID =  rdrUserLoad.GetInt32 (0); 
						psw			 =  rdrUserLoad.GetString(2);
						if (psw == this.getMD5Pwd(tbPassword.Text))
						{
							this.DialogResult =DialogResult.OK;
							this.Close();
						}
						else 
						{
							AM_Controls.MsgBoxX.Show("Неправильное имя пользователя или пароль",ProgName, 
								MessageBoxButtons.OK, MessageBoxIcon.Stop); 
							this.tbPassword.Text="";
							this.tbPassword.Focus();
							return;
						}
					}
					else 
					{
						AM_Controls.MsgBoxX.Show("Неправильное имя пользователя или пароль.",ProgName, 
							MessageBoxButtons.OK, MessageBoxIcon.Stop);
						this.tbUserLogonName.Focus();
						this.tbPassword.Text="";
						return;
					}
				}
				catch(Exception xc)
				{
					AM_Controls.MsgBoxX.Show("В регистрации отказано. При Регистрации в системе возникла ошибка:\n " + xc.Message.ToString(),ProgName, 
						MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}
				finally
				{
					cmdUserLoad.Connection.Close();
					rdrUserLoad.Close();
				}
				//Запись времени входа
	/*			string strUserHist= "INSERT INTO UsersLogonHistory  (UserID, ComputerName, LogonTime) VALUES ("
					+ iUserID.ToString() +","
					+ "'" + szThisComputer+ "','" + this.getDBDateTimeNow()
					+"')";
		*/		string strUserHist= "INSERT INTO UsersLogonHistory  (UserID, ComputerName, LogonTime) VALUES ("
					+ iUserID.ToString() +","
					+ "'" + szThisComputer+ "',?)";
				OleDbCommand cmdUserHist = new OleDbCommand(strUserHist, this.oleDbConnection1);
				cmdUserHist.Parameters.Add(new OleDbParameter("LogonTime", OleDbType.Date));
				cmdUserHist.Parameters["LogonTime"].Value = DateTime.Now;
				OleDbCommand cmdUserHistID = new OleDbCommand("SELECT @@IDENTITY", this.oleDbConnection1);
				try 
				{
					cmdUserHist.Connection.Open();
					cmdUserHist.ExecuteNonQuery();
					object o = cmdUserHistID.ExecuteScalar();
					if(o != Convert.DBNull)
						iUserLogonID = Convert.ToInt32(o);
				}
				catch(Exception e)
				{
					AM_Controls.MsgBoxX.Show("Ошибка при сохранение протокола:\n " + e.Message.ToString(),"BPS", 
						MessageBoxButtons.OK, MessageBoxIcon.Error ); 
				}
				finally
				{
					cmdUserHist.Connection.Close();
				}

			}
		}
		private string getDBDateTimeNow()
		{
			DateTime dt = DateTime.Now;
			string szDateTime = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString() + " " + dt.TimeOfDay.Hours.ToString() + ":" + dt.TimeOfDay.Minutes.ToString() + ":" + dt.TimeOfDay.Seconds.ToString();
			return szDateTime;
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =DialogResult.Cancel;		
			this.Close();
		}
		private string getMD5Pwd(string szUncryptPwd)
		{
			UnicodeEncoding ue = new UnicodeEncoding();
			byte [] bPwd = ue.GetBytes(szUncryptPwd);
			MD5 md5 = new MD5CryptoServiceProvider();
			byte [] resPwd = md5.ComputeHash(bPwd);
			return BitConverter.ToString(resPwd);
		}
		private void Logon_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==27) 
			{
				this.DialogResult =DialogResult.Cancel;		
				this.Close();
			}
			else
				if (e.KeyChar == '\r') 
			{
				if ( (this.tbUserLogonName.Focused && this.tbUserLogonName.Text!=""))
					this.tbPassword.Focus();
				else
					VerifyUser();
			}
		}

	}
}

