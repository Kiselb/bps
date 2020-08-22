using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Controls;
using AM_Lib;

namespace BPS
{
	/// <summary>
	/// Summary description for App.
	/// </summary>
	public class App
	{
		public static string ReportsDirectory;
		public static string DBSource;

		public static BPS.BLL.Bank.coBanks bllBank;
		public static BPS.BLL.City.coCities bllCity;
		public static BPS.BLL.Currency.coCurrency bllCurrency;
		public static BPS.BLL.Orgs.coOrgs bllOrgs;
		public static BPS.BLL.ClientsRequests.coRequest bllRequests;
		public static BPS.BLL.Clients.coClientEx bllClients;
		public static BPS.BLL.Clients.coClientEx BPSClients;
		private static BPS.dsOrgsAccount dsOrgsAccount1;
		public static AM_Lib.Lock DBLock;

		public static AM_Lib.sqlData sqlData;

	#region		----------------Разрешения пользователей-----------------------------
		public static bool AllowClientsDirRead = false;
		public static bool AllowClientsDirChange = false;
		public static bool AllowOrgDirRead = false;
		public static bool AllowUserInfo = false;
	//	public static bool AllowUserInfoEdit = false;
	//	public static bool AllowPermissionListEdit = false;
		public static bool AllowEditConfirmedAccountStatement = false;
		public static bool AllowClientsRequests = false;
		public static bool AllowClientsRequestsEdit = false;
		public static bool AllowClientsRequestsExecute = false;
		public static bool AllowTransactions = false;
		public static bool AllowTransactionsEdit = false;
		public static bool AllowTransactionsExecute = false;
		public static bool AllowOrgDirChange = false;
		public static bool AllowAccountsStatements = false;
		public static bool AllowAccountsStatementsEdit = false;
		public static bool AllowAccountsStatementsConfirmed = false;
		public static bool AllowPaymsOrdersRecognition = false;
		public static bool AllowPaymentsOrders = false;
		public static bool AllowPaymentsOrdersEdit = false;
		public static bool AllowPaymentsOrdersSending = false;
		public static bool AllowAccounts = false;
		public static bool AllowBanks = false;
		public static bool AllowBanksEdit = false;
		public static bool AllowCurrencies = false;
		public static bool AllowCurrenciesEdit = false;
		public static bool AllowCurrenciesRate = false;
		public static bool AllowCurrenciesRateEdit = false;
		#endregion

		
		public static string OleDbConnectionString;
		public static string ConnectionString;
		public static int UserLogonID = 1;
		public static int UserLogonHistoryID = -1;
		public static System.Data.SqlClient.SqlConnection  Connection;

	#region DataGrid Table Style Properties
		public static Color		GridBkColor =Color.LightGray;
		public static Color		GridAltBkColor= Color.Gainsboro;
		public static Color		GridLineColor= Color.LightGray;
		public static Color		SelectionBackColor= Color.Cornsilk;
		public static Color		SelectionForeColor= Color.Black;
		public static Color		HeaderBackColor= SystemColors.Control;
		public static Color		HeaderForeColor= Color.Black;
		public static DataGridLineStyle GridLineStyle= DataGridLineStyle.Solid;
	#endregion


		public static string POFormatSettingsFileName;

		private static string m_szMainCurrencyID;

		public class CreditsTypes 
		{
			public const string ShortTerm			="Краткосрочный";						// Credits.IsShortterm ==1
			public const string LongTerm			="Долгосрочный";						// Credits.IsShortterm ==0 && Credits.IsExtended ==0
			public const string LongTermExtended	="Долгосрочный с планом погашения";		// Credits.IsShortterm ==0 && Credits.IsExtended ==1
		}
		
		public class CreditsSettings 
		{

			public const string CreditPercentageRoundModeByDay		="за день";				// Credits.PercentageRoundMode ==0
			public const string CreditPercentageRoundModeByPeriod	="за период";			// Credits.PercentageRoundMode ==1
			public const string CreditPercentageSinkModeByPeriod	="за отчётный период";	// Credits.PercentageSinkMode ==0	
			public const string CreditPercentageSinkModeByOperation	="при погашении тела";	// Credits.PercentageSinkMode ==1
		}
		static App()
		{
			AM_Controls.Settings  AMSet= new AM_Controls.Settings(new System.Configuration.AppSettingsReader());

			ReportsDirectory = LoadDirectoryString( "ReportsDirectory","..\\..\\_Reports\\");
			AM_Controls.MsgBoxX.Header = "BPS";
			Connection = new System.Data.SqlClient.SqlConnection();
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			Connection.ConnectionString = 
			ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			OleDbConnectionString = ((string)(configurationAppSettings.GetValue("OleDbConnectionString", typeof(string))));
			POFormatSettingsFileName = ((string)(configurationAppSettings.GetValue("POFormatSettingsFile", typeof(string))));

			
			sqlData = new AM_Lib.sqlData(ConnectionString);			

			AppSettingsGet();

			
			bllBank = new BPS.BLL.Bank.coBanks(Connection);
			bllBank.Fill();

			bllCity = new BPS.BLL.City.coCities(Connection);
			bllCity.Fill();

			bllCurrency = new BPS.BLL.Currency.coCurrency(Connection);
			bllCurrency.Fill();
			bllCurrency.FillHistory();

			bllOrgs = new BPS.BLL.Orgs.coOrgs(Connection);
			bllOrgs.Fill();

			bllRequests = new BPS.BLL.ClientsRequests.coRequest (Connection);
			bllRequests.FillDirectories();
			
			BPSClients=
				bllClients = new BPS.BLL.Clients.coClientEx(Connection);
			bllClients.DataGridStyle += new BPS.BLL.Clients.coClientEx.DataGridStyleEventHandler(OnSetStyle);
			bllClients.AddClient += new BPS.BLL.Clients.coClientEx.AddClientEventHandler(OnAddingClient);
			
			DBLock = new AM_Lib.Lock(Connection);

			dsOrgsAccount1 = new BPS.dsOrgsAccount();
		}

		public static string MainCurrencyID
		{
			get 
			{
				return m_szMainCurrencyID;
			}
		}

		private static void AppSettingsGet()
		{
			System.Data.SqlClient.SqlCommand sqlCmdAppSettingsGet = new System.Data.SqlClient.SqlCommand();

			sqlCmdAppSettingsGet.CommandText ="[AppSettingsGet]";
			sqlCmdAppSettingsGet.CommandType =System.Data.CommandType.StoredProcedure;
			sqlCmdAppSettingsGet.Connection	 =Connection;
			sqlCmdAppSettingsGet.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlCmdAppSettingsGet.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainCurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			if (AM_Lib.sqlData.ExecuteNonQuery(sqlCmdAppSettingsGet))
				m_szMainCurrencyID =(string)sqlCmdAppSettingsGet.Parameters["@MainCurrencyID"].Value;
			else

				MessageBox.Show("Ошибка чтения настроек приложения." , "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static int UserID
		{
			get
			{
				return 1;
			}
		}
		public static void RefreshBook()
		{
			bllBank.Fill();
			bllCity.Fill();
			bllClients.FillClients();
			bllClients.FillGroups();
			bllOrgs.Fill();
			FillOrgsAccount();
		}

		
		public static void FillOrgsAccount()
		{
			try
			{
				SqlDataAdapter daOrgsAccount = new SqlDataAdapter("",Connection);
				
				daOrgsAccount.SelectCommand.CommandText = "SELECT OrgsAccounts.*, Accounts.CurrencyID AS CurrencyID FROM Accounts INNER JOIN " +
                                                          "OrgsAccounts ON Accounts.AccountID = OrgsAccounts.AccountID";
				dsOrgsAccount1.Clear();
				daOrgsAccount.Fill(dsOrgsAccount1.OrgsAccounts);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}



		public static BPS.dsOrgsAccount DsOrgsAccount
		{
			get
			{
				return dsOrgsAccount1;
			}
		}

		public static BPS.BLL.Orgs.DataSets.dsOrgs DsOrgs
		{
			get
			{
				return bllOrgs.DataSet;
			}
		}

  		public static BLL.Bank.DataSets.dsBanks DsBanks
		{
			get
			{
				return bllBank.DataSet;
			}
		}

		public static BPS.BLL.Currency.DataSets.dsCurr DsCurr
		{
			get
			{
				return bllCurrency.DataSet;
			}
		}
		public static BPS.BLL.Clients.DataSets.dsClients DsClients
		{
			get
			{
				return bllClients.DsClients;
			}
		}
		private static void OnSetStyle(DataGridTableStyle GridStyle)
		{
			SetDataGridTableStyle(GridStyle);
		}

		private static void OnAddingClient(int iClientID)
		{
			// CreateAccount(iClientID);
		}

	public static void ShowClientList(System.Windows.Forms.Form parent)
		{
			if(!App.AllowClientsDirRead)
				return;
			bllClients.ShowList(parent);
		}
		
		public static System.Windows.Forms.Form m_MainFrame;
		public static bool FindWindow(Type FormType )
		{
			if (m_MainFrame!=null)
				return FindWindow(m_MainFrame, FormType);
			else 
				return false;
		}

		public static bool FindWindow(System.Windows.Forms.Form parent, Type FormType )
		{

			foreach( Form f in parent.MdiChildren) 
			{
				if (f.GetType()==FormType)
				{
					f.Show();
					f.Activate();
					return true;
				}
			}
			return false;
		}

		public static void SetDataGridTableStyle(DataGridTableStyle dataGridTableStyle1)
		{
			dataGridTableStyle1.AlternatingBackColor= GridBkColor;
			dataGridTableStyle1.BackColor			= GridAltBkColor;
			dataGridTableStyle1.GridLineColor		= GridLineColor;
			dataGridTableStyle1.SelectionBackColor	= SelectionBackColor;
			dataGridTableStyle1.SelectionForeColor	= SelectionForeColor;
			dataGridTableStyle1.HeaderBackColor		= HeaderBackColor;
			dataGridTableStyle1.HeaderForeColor		= HeaderForeColor;
			dataGridTableStyle1.GridLineStyle		= GridLineStyle;
		}
		public static void Clone(System.Windows.Forms.Menu.MenuItemCollection pattern, MenuItem clone)
		{
			while (clone.MenuItems.Count>0)
				clone.MenuItems.RemoveAt(0);
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
		}

		public static void Clone(System.Windows.Forms.Menu.MenuItemCollection pattern, ContextMenu clone)
		{
			while (clone.MenuItems.Count>0)
				clone.MenuItems.RemoveAt(0);
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
		}
		
		public static bool ExecProc(string StoredProcName)
		{
			SqlCommand sqlCmd = new SqlCommand();
			sqlCmd.Connection = Connection;
			sqlCmd.CommandText = "[" + StoredProcName + "]";
			sqlCmd.CommandType = CommandType.StoredProcedure;

			return ExecSql(sqlCmd);
		}

		public static bool ExecSql( System.Data.SqlClient.SqlCommand sqlCmd )
		{
			bool bCloseConnection = false;
			try 
			{
				Cursor.Current = Cursors.WaitCursor;
				if ( sqlCmd.Connection.State == ConnectionState.Closed ) 
				{
					sqlCmd.Connection.Open();
					bCloseConnection = true;
				}
				sqlCmd.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				Cursor.Current = Cursors.Default;
				MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return false;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				if (bCloseConnection)
					sqlCmd.Connection.Close();

			}

		}

		public static bool LockStatusChange( int nEntityTypeID, int nEntityID, bool bLock) 
		{
			return Lock.StatusChange(UserLogonID,nEntityTypeID, nEntityID, bLock);
		}

		public static void clearLocks()
		{
			Lock.СlearAll(UserLogonID);
		}

		public static string LoadDirectoryString(string szKey, string szDefault)
		{
			string szDir=szDefault;
			System.Configuration.AppSettingsReader 
				configurationAppSettings = new System.Configuration.AppSettingsReader();
			try 
			{
				szDir =((string)(configurationAppSettings.GetValue(szKey, typeof(string))));
			}
			catch
			{

			}
			if (szDir.Length>0 && szDir[szDir.Length-1]!='\\')
				szDir+='\\';

			return szDir;
		}

		public static bool CheckKAccountCheckSum_ForCreditOrg(string CodeBIK, string AccountNumber)
		{
			char[] AccountArray = new char[20];
			int[] Weights = new int[23] {7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1};
			int Sum = 0;
			AccountArray[0] = CodeBIK[6];
			AccountArray[0] = CodeBIK[7];
			AccountArray[0] = CodeBIK[8];
			AccountNumber.ToCharArray().CopyTo(AccountArray, 3);
			for(int counter = 0; counter < 23; counter ++)
			{
				AccountArray[counter] -= '0';
				Sum += (AccountArray[counter] * Weights[counter]) % 10;
			}
			if(Sum % 10 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
