using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using BPS._Forms;
using AuthControl;
using AM_Controls;

namespace BPS
{
	/// <summary>
	/// Summary description for MainMDIForm.
	/// </summary>
	public class MainMDIForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuRepare;
		private System.Windows.Forms.MenuItem mnuArch;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem mnuLockAccess;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuProgClose;
		private System.Windows.Forms.MenuItem mnuDirectories;
		private System.Windows.Forms.MenuItem mnuClients;
		private System.Windows.Forms.MenuItem mnuOrgs;
		private System.Windows.Forms.MenuItem mnuBanks;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuUsers;
		private System.Windows.Forms.MenuItem mnuPayments;
		private System.Windows.Forms.MenuItem mnuPaymIn;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.StatusBar stsBar;
		private System.Windows.Forms.StatusBarPanel stsBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.ToolBar tbMainMDI;
		private System.Windows.Forms.ToolBarButton tbFile;
		private System.Windows.Forms.ToolBarButton tbSep1;
		private System.Windows.Forms.ToolBarButton tbbDir;
		private System.Windows.Forms.ToolBarButton tbSep2;
		private System.Windows.Forms.ToolBarButton tbDoc;
		private System.Windows.Forms.ToolBarButton tbSep3;
		private System.Windows.Forms.ToolBarButton tbPaym;
		private System.Windows.Forms.ToolBarButton tbSep5;
		private System.Windows.Forms.ToolBarButton tbReps;
		private System.Windows.Forms.ToolBarButton tbSep6;
		private System.Windows.Forms.ToolBarButton tbHelp;
		private System.Windows.Forms.ToolBarButton tbSep9;
		private System.Windows.Forms.MenuItem mnuCurrency;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Windows.Forms.MenuItem mnuTrans;
		private System.Windows.Forms.MenuItem mnuRequestsList;
		private System.Windows.Forms.MenuItem mnuAccSt;
		private System.Windows.Forms.MenuItem mnuClientsBalances;
		private System.Windows.Forms.MenuItem mnuBankAccountsStates;
		private System.Windows.Forms.MenuItem mnuPaymsOrdersRecognition;
		private System.Windows.Forms.MenuItem mnuOurAccountstates;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuAccounts;
		private System.Windows.Forms.MenuItem mnuReports;
		private System.Windows.Forms.ToolBarButton tbSep;
		private System.Windows.Forms.ToolBarButton tbReq;
		private System.Windows.Forms.MenuItem mnuBalance;
		private System.Windows.Forms.ToolBarButton tbAcc;
		private System.Windows.Forms.ToolBarButton tbSep10;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.ToolBarButton tbAccStat;
		private System.Windows.Forms.ToolBarButton tbSep11;
		private System.Windows.Forms.ContextMenu cmnuDir;
		private System.Windows.Forms.ContextMenu cmnuAccounts;
		private System.Windows.Forms.ContextMenu cmnuReports;
		private System.Windows.Forms.ContextMenu cmnuHelp;
		private System.Windows.Forms.ContextMenu cmnuFile;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton tbLinked;
		private System.Windows.Forms.ToolBarButton tbSep22;
		private static bool bIsInit = false;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.MenuItem mnuRefrBook;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mnuLocksList;
		private System.Data.SqlClient.SqlCommand sqlCmdBackup;
		private System.Windows.Forms.MenuItem mnuFileFormats;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem mnuCredits;
		private System.Windows.Forms.MenuItem mnuAccountsStatements;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem mnuUsersList;
		private System.Windows.Forms.MenuItem mnuUsersOrgsAccounts;
		private System.Windows.Forms.MenuItem mnuCities;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		private System.Windows.Forms.StatusBarPanel spnlUserName;
//		private static bool bIsLogon = true;
		public MainMDIForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
//			App.CheckClientAccount();// перенесено в триггер
//			App.CheckCurrAccount();			// перенесено в триггер
			this.MakeMenu();
			this.menuItem6.Visible = bIsInit;
			App.m_MainFrame = this;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainMDIForm));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuLocksList = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuRepare = new System.Windows.Forms.MenuItem();
			this.mnuArch = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.mnuLockAccess = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuProgClose = new System.Windows.Forms.MenuItem();
			this.mnuDirectories = new System.Windows.Forms.MenuItem();
			this.mnuClients = new System.Windows.Forms.MenuItem();
			this.mnuOrgs = new System.Windows.Forms.MenuItem();
			this.mnuBanks = new System.Windows.Forms.MenuItem();
			this.mnuCities = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuUsers = new System.Windows.Forms.MenuItem();
			this.mnuUsersList = new System.Windows.Forms.MenuItem();
			this.mnuUsersOrgsAccounts = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.mnuCurrency = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuFileFormats = new System.Windows.Forms.MenuItem();
			this.mnuRefrBook = new System.Windows.Forms.MenuItem();
			this.mnuAccounts = new System.Windows.Forms.MenuItem();
			this.mnuBankAccountsStates = new System.Windows.Forms.MenuItem();
			this.mnuOurAccountstates = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuClientsBalances = new System.Windows.Forms.MenuItem();
			this.mnuBalance = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.mnuPayments = new System.Windows.Forms.MenuItem();
			this.mnuRequestsList = new System.Windows.Forms.MenuItem();
			this.mnuTrans = new System.Windows.Forms.MenuItem();
			this.mnuPaymIn = new System.Windows.Forms.MenuItem();
			this.mnuAccSt = new System.Windows.Forms.MenuItem();
			this.mnuPaymsOrdersRecognition = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.mnuCredits = new System.Windows.Forms.MenuItem();
			this.mnuAccountsStatements = new System.Windows.Forms.MenuItem();
			this.mnuReports = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.stsBar = new System.Windows.Forms.StatusBar();
			this.stsBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.spnlUserName = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.tbMainMDI = new System.Windows.Forms.ToolBar();
			this.tbFile = new System.Windows.Forms.ToolBarButton();
			this.tbSep1 = new System.Windows.Forms.ToolBarButton();
			this.tbbDir = new System.Windows.Forms.ToolBarButton();
			this.cmnuDir = new System.Windows.Forms.ContextMenu();
			this.tbSep2 = new System.Windows.Forms.ToolBarButton();
			this.tbAcc = new System.Windows.Forms.ToolBarButton();
			this.cmnuAccounts = new System.Windows.Forms.ContextMenu();
			this.tbSep10 = new System.Windows.Forms.ToolBarButton();
			this.tbReq = new System.Windows.Forms.ToolBarButton();
			this.tbSep3 = new System.Windows.Forms.ToolBarButton();
			this.tbDoc = new System.Windows.Forms.ToolBarButton();
			this.tbSep9 = new System.Windows.Forms.ToolBarButton();
			this.tbPaym = new System.Windows.Forms.ToolBarButton();
			this.tbSep5 = new System.Windows.Forms.ToolBarButton();
			this.tbAccStat = new System.Windows.Forms.ToolBarButton();
			this.tbSep11 = new System.Windows.Forms.ToolBarButton();
			this.tbLinked = new System.Windows.Forms.ToolBarButton();
			this.tbSep22 = new System.Windows.Forms.ToolBarButton();
			this.tbReps = new System.Windows.Forms.ToolBarButton();
			this.cmnuReports = new System.Windows.Forms.ContextMenu();
			this.tbSep6 = new System.Windows.Forms.ToolBarButton();
			this.tbHelp = new System.Windows.Forms.ToolBarButton();
			this.cmnuHelp = new System.Windows.Forms.ContextMenu();
			this.tbSep = new System.Windows.Forms.ToolBarButton();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.cmnuFile = new System.Windows.Forms.ContextMenu();
			this.sqlCmdBackup = new System.Data.SqlClient.SqlCommand();
			this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnlUserName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuFile,
																					  this.mnuDirectories,
																					  this.mnuAccounts,
																					  this.mnuPayments,
																					  this.mnuReports,
																					  this.menuItem29,
																					  this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuFile, null);
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuLocksList,
																					this.menuItem2,
																					this.mnuRepare,
																					this.mnuArch,
																					this.menuItem38,
																					this.menuItem6,
																					this.mnuLockAccess,
																					this.menuItem3,
																					this.mnuProgClose});
			this.mnuFile.OwnerDraw = true;
			this.mnuFile.Text = "Файл";
			// 
			// mnuLocksList
			// 
			this.mnuLocksList.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuLocksList, ((System.Drawing.Icon)(resources.GetObject("mnuLocksList.MenuItemImage"))));
			this.mnuLocksList.OwnerDraw = true;
			this.mnuLocksList.Text = "Блокировки";
			this.mnuLocksList.Click += new System.EventHandler(this.mnuLocksList_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem2, null);
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "-";
			// 
			// mnuRepare
			// 
			this.mnuRepare.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuRepare, null);
			this.mnuRepare.OwnerDraw = true;
			this.mnuRepare.Text = "Ремонт базы данных";
			// 
			// mnuArch
			// 
			this.mnuArch.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuArch, null);
			this.mnuArch.OwnerDraw = true;
			this.mnuArch.Text = "Архивирование базы данных";
			this.mnuArch.Click += new System.EventHandler(this.mnuArch_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem38, null);
			this.menuItem38.OwnerDraw = true;
			this.menuItem38.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem6, null);
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem7,
																					  this.menuItem9,
																					  this.menuItem10});
			this.menuItem6.OwnerDraw = true;
			this.menuItem6.Text = "Ввод остатков";
			this.menuItem6.Visible = false;
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem7, null);
			this.menuItem7.OwnerDraw = true;
			this.menuItem7.Text = "Наши р. счета";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem9, null);
			this.menuItem9.OwnerDraw = true;
			this.menuItem9.Text = "Наши уч. счета";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem10, null);
			this.menuItem10.OwnerDraw = true;
			this.menuItem10.Text = "Счета клиентов";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// mnuLockAccess
			// 
			this.mnuLockAccess.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuLockAccess, null);
			this.mnuLockAccess.OwnerDraw = true;
			this.mnuLockAccess.Shortcut = System.Windows.Forms.Shortcut.ShiftF4;
			this.mnuLockAccess.Text = "Блокировка доступа к программе";
			this.mnuLockAccess.Click += new System.EventHandler(this.mnuLockAccess_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem3, null);
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "-";
			// 
			// mnuProgClose
			// 
			this.mnuProgClose.Index = 8;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuProgClose, ((System.Drawing.Icon)(resources.GetObject("mnuProgClose.MenuItemImage"))));
			this.mnuProgClose.OwnerDraw = true;
			this.mnuProgClose.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.mnuProgClose.Text = "Выход из программы";
			this.mnuProgClose.Click += new System.EventHandler(this.mnuProgClose_Click);
			// 
			// mnuDirectories
			// 
			this.mnuDirectories.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuDirectories, null);
			this.mnuDirectories.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.mnuClients,
																						   this.mnuOrgs,
																						   this.mnuBanks,
																						   this.mnuCities,
																						   this.menuItem1,
																						   this.mnuUsers,
																						   this.menuItem11,
																						   this.menuItem15,
																						   this.mnuCurrency,
																						   this.menuItem4,
																						   this.mnuFileFormats,
																						   this.mnuRefrBook});
			this.mnuDirectories.MergeOrder = 1;
			this.mnuDirectories.OwnerDraw = true;
			this.mnuDirectories.Text = "Справочники";
			// 
			// mnuClients
			// 
			this.mnuClients.DefaultItem = true;
			this.mnuClients.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuClients, ((System.Drawing.Icon)(resources.GetObject("mnuClients.MenuItemImage"))));
			this.mnuClients.OwnerDraw = true;
			this.mnuClients.Text = "Клиенты";
			this.mnuClients.Click += new System.EventHandler(this.mnuClients_Click);
			// 
			// mnuOrgs
			// 
			this.mnuOrgs.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuOrgs, null);
			this.mnuOrgs.OwnerDraw = true;
			this.mnuOrgs.Text = "Организации";
			this.mnuOrgs.Click += new System.EventHandler(this.mnuOrgs_Click);
			// 
			// mnuBanks
			// 
			this.mnuBanks.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuBanks, ((System.Drawing.Icon)(resources.GetObject("mnuBanks.MenuItemImage"))));
			this.mnuBanks.OwnerDraw = true;
			this.mnuBanks.Text = "Банки";
			this.mnuBanks.Click += new System.EventHandler(this.mnuBanks_Click);
			// 
			// mnuCities
			// 
			this.mnuCities.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCities, null);
			this.mnuCities.OwnerDraw = true;
			this.mnuCities.Text = "Города";
			this.mnuCities.Click += new System.EventHandler(this.mnuCities_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem1, null);
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "-";
			// 
			// mnuUsers
			// 
			this.mnuUsers.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuUsers, null);
			this.mnuUsers.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuUsersList,
																					 this.mnuUsersOrgsAccounts});
			this.mnuUsers.OwnerDraw = true;
			this.mnuUsers.Text = "Пользователи";
			// 
			// mnuUsersList
			// 
			this.mnuUsersList.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuUsersList, null);
			this.mnuUsersList.OwnerDraw = true;
			this.mnuUsersList.Text = "Список";
			this.mnuUsersList.Click += new System.EventHandler(this.mnuUsersList_Click);
			// 
			// mnuUsersOrgsAccounts
			// 
			this.mnuUsersOrgsAccounts.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuUsersOrgsAccounts, null);
			this.mnuUsersOrgsAccounts.OwnerDraw = true;
			this.mnuUsersOrgsAccounts.Text = "Доступ к р.счетам";
			this.mnuUsersOrgsAccounts.Click += new System.EventHandler(this.mnuUsersOrgsAccounts_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem11, null);
			this.menuItem11.OwnerDraw = true;
			this.menuItem11.Text = "Разрешения";
			this.menuItem11.Visible = false;
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem15, null);
			this.menuItem15.OwnerDraw = true;
			this.menuItem15.Text = "-";
			// 
			// mnuCurrency
			// 
			this.mnuCurrency.Index = 8;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCurrency, null);
			this.mnuCurrency.OwnerDraw = true;
			this.mnuCurrency.Text = "Валюты";
			this.mnuCurrency.Click += new System.EventHandler(this.mnuCurrency_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 9;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem4, null);
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Text = "Курсы валют";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// mnuFileFormats
			// 
			this.mnuFileFormats.Index = 10;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuFileFormats, null);
			this.mnuFileFormats.OwnerDraw = true;
			this.mnuFileFormats.Text = "Форматы файлов выписок";
			this.mnuFileFormats.Click += new System.EventHandler(this.mnuFileFormats_Click);
			// 
			// mnuRefrBook
			// 
			this.mnuRefrBook.Index = 11;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuRefrBook, null);
			this.mnuRefrBook.OwnerDraw = true;
			this.mnuRefrBook.Text = "Обновить справочники";
			this.mnuRefrBook.Click += new System.EventHandler(this.mnuRefrBook_Click);
			// 
			// mnuAccounts
			// 
			this.mnuAccounts.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuAccounts, null);
			this.mnuAccounts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuBankAccountsStates,
																						this.mnuOurAccountstates,
																						this.menuItem5,
																						this.mnuClientsBalances,
																						this.mnuBalance,
																						this.menuItem12,
																						this.menuItem13});
			this.mnuAccounts.MergeOrder = 2;
			this.mnuAccounts.OwnerDraw = true;
			this.mnuAccounts.Text = "Счета";
			// 
			// mnuBankAccountsStates
			// 
			this.mnuBankAccountsStates.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuBankAccountsStates, null);
			this.mnuBankAccountsStates.OwnerDraw = true;
			this.mnuBankAccountsStates.Shortcut = System.Windows.Forms.Shortcut.Alt1;
			this.mnuBankAccountsStates.Text = "Наши р.счета";
			this.mnuBankAccountsStates.Click += new System.EventHandler(this.mnuBankAccountsStates_Click);
			// 
			// mnuOurAccountstates
			// 
			this.mnuOurAccountstates.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuOurAccountstates, null);
			this.mnuOurAccountstates.OwnerDraw = true;
			this.mnuOurAccountstates.Shortcut = System.Windows.Forms.Shortcut.Alt2;
			this.mnuOurAccountstates.Text = "Наши уч.счета";
			this.mnuOurAccountstates.Click += new System.EventHandler(this.mnuOurAccountstates_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem5, null);
			this.menuItem5.OwnerDraw = true;
			this.menuItem5.Text = "-";
			// 
			// mnuClientsBalances
			// 
			this.mnuClientsBalances.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuClientsBalances, null);
			this.mnuClientsBalances.OwnerDraw = true;
			this.mnuClientsBalances.Shortcut = System.Windows.Forms.Shortcut.Alt3;
			this.mnuClientsBalances.Text = "Счета клиентов";
			this.mnuClientsBalances.Click += new System.EventHandler(this.mnuClientsBalances_Click);
			// 
			// mnuBalance
			// 
			this.mnuBalance.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuBalance, null);
			this.mnuBalance.OwnerDraw = true;
			this.mnuBalance.Shortcut = System.Windows.Forms.Shortcut.Alt0;
			this.mnuBalance.Text = "Баланс";
			this.mnuBalance.Click += new System.EventHandler(this.mnuBalance_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem12, null);
			this.menuItem12.OwnerDraw = true;
			this.menuItem12.Text = "-";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem13, ((System.Drawing.Icon)(resources.GetObject("menuItem13.MenuItemImage"))));
			this.menuItem13.OwnerDraw = true;
			this.menuItem13.Text = "Все счета";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// mnuPayments
			// 
			this.mnuPayments.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuPayments, null);
			this.mnuPayments.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuRequestsList,
																						this.mnuTrans,
																						this.mnuPaymIn,
																						this.mnuAccSt,
																						this.mnuPaymsOrdersRecognition,
																						this.menuItem14,
																						this.mnuCredits,
																						this.mnuAccountsStatements});
			this.mnuPayments.MergeOrder = 3;
			this.mnuPayments.OwnerDraw = true;
			this.mnuPayments.Text = "Транзакции";
			// 
			// mnuRequestsList
			// 
			this.mnuRequestsList.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuRequestsList, ((System.Drawing.Icon)(resources.GetObject("mnuRequestsList.MenuItemImage"))));
			this.mnuRequestsList.OwnerDraw = true;
			this.mnuRequestsList.Shortcut = System.Windows.Forms.Shortcut.AltF5;
			this.mnuRequestsList.Text = "Заявки клиентов";
			this.mnuRequestsList.Click += new System.EventHandler(this.mnuPaymOut_Click);
			// 
			// mnuTrans
			// 
			this.mnuTrans.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuTrans, ((System.Drawing.Icon)(resources.GetObject("mnuTrans.MenuItemImage"))));
			this.mnuTrans.OwnerDraw = true;
			this.mnuTrans.Shortcut = System.Windows.Forms.Shortcut.AltF6;
			this.mnuTrans.Text = "Транзакции";
			this.mnuTrans.Click += new System.EventHandler(this.mnuTrans_Click);
			// 
			// mnuPaymIn
			// 
			this.mnuPaymIn.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuPaymIn, ((System.Drawing.Icon)(resources.GetObject("mnuPaymIn.MenuItemImage"))));
			this.mnuPaymIn.OwnerDraw = true;
			this.mnuPaymIn.Shortcut = System.Windows.Forms.Shortcut.AltF7;
			this.mnuPaymIn.Text = "Исходящие платежи";
			this.mnuPaymIn.Click += new System.EventHandler(this.mnuPaymIn_Click);
			// 
			// mnuAccSt
			// 
			this.mnuAccSt.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuAccSt, ((System.Drawing.Icon)(resources.GetObject("mnuAccSt.MenuItemImage"))));
			this.mnuAccSt.OwnerDraw = true;
			this.mnuAccSt.Shortcut = System.Windows.Forms.Shortcut.AltF8;
			this.mnuAccSt.Text = "Выписки";
			this.mnuAccSt.Click += new System.EventHandler(this.mnuAccSt_Click);
			// 
			// mnuPaymsOrdersRecognition
			// 
			this.mnuPaymsOrdersRecognition.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuPaymsOrdersRecognition, ((System.Drawing.Icon)(resources.GetObject("mnuPaymsOrdersRecognition.MenuItemImage"))));
			this.mnuPaymsOrdersRecognition.OwnerDraw = true;
			this.mnuPaymsOrdersRecognition.Shortcut = System.Windows.Forms.Shortcut.AltF9;
			this.mnuPaymsOrdersRecognition.Text = "Распознавание Платежей";
			this.mnuPaymsOrdersRecognition.Click += new System.EventHandler(this.mnuPaymsOrdersRecognition_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem14, null);
			this.menuItem14.OwnerDraw = true;
			this.menuItem14.Text = "-";
			// 
			// mnuCredits
			// 
			this.mnuCredits.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuCredits, ((System.Drawing.Icon)(resources.GetObject("mnuCredits.MenuItemImage"))));
			this.mnuCredits.OwnerDraw = true;
			this.mnuCredits.Text = "Кредиты";
			this.mnuCredits.Click += new System.EventHandler(this.mnuCredits_Click);
			// 
			// mnuAccountsStatements
			// 
			this.mnuAccountsStatements.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuAccountsStatements, null);
			this.mnuAccountsStatements.OwnerDraw = true;
			this.mnuAccountsStatements.Text = "Выписки2";
			this.mnuAccountsStatements.Click += new System.EventHandler(this.mnuAccountsStatements_Click);
			// 
			// mnuReports
			// 
			this.mnuReports.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuReports, null);
			this.mnuReports.MergeOrder = 4;
			this.mnuReports.OwnerDraw = true;
			this.mnuReports.Text = "Отчеты";
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 5;
			this.menuItem29.MdiList = true;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem29, null);
			this.menuItem29.MergeOrder = 20;
			this.menuItem29.OwnerDraw = true;
			this.menuItem29.Text = "Окна";
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuHelp, null);
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuAbout});
			this.mnuHelp.MergeOrder = 21;
			this.mnuHelp.OwnerDraw = true;
			this.mnuHelp.Text = "Помощь";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuAbout, ((System.Drawing.Icon)(resources.GetObject("mnuAbout.MenuItemImage"))));
			this.mnuAbout.OwnerDraw = true;
			this.mnuAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.mnuAbout.Text = "О программе и родителях ...";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// stsBar
			// 
			this.stsBar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.stsBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.stsBar.Location = new System.Drawing.Point(0, 327);
			this.stsBar.Name = "stsBar";
			this.stsBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					  this.stsBarPanel1,
																					  this.spnlUserName,
																					  this.statusBarPanel1,
																					  this.statusBarPanel2});
			this.stsBar.ShowPanels = true;
			this.stsBar.Size = new System.Drawing.Size(964, 22);
			this.stsBar.TabIndex = 2;
			this.stsBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.stsBar_PanelClick);
			this.stsBar.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.stsBar_DrawItem);
			this.stsBar.DoubleClick += new System.EventHandler(this.stsBar_DoubleClick);
			// 
			// stsBarPanel1
			// 
			this.stsBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.stsBarPanel1.Icon = ((System.Drawing.Icon)(resources.GetObject("stsBarPanel1.Icon")));
			this.stsBarPanel1.MinWidth = 30;
			this.stsBarPanel1.Width = 31;
			// 
			// spnlUserName
			// 
			this.spnlUserName.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.spnlUserName.Icon = ((System.Drawing.Icon)(resources.GetObject("spnlUserName.Icon")));
			this.spnlUserName.Width = 31;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Width = 771;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.statusBarPanel2.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
			this.statusBarPanel2.Text = "AM Software  ";
			this.statusBarPanel2.Width = 115;
			// 
			// tbMainMDI
			// 
			this.tbMainMDI.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbMainMDI.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						 this.tbFile,
																						 this.tbSep1,
																						 this.tbbDir,
																						 this.tbSep2,
																						 this.tbAcc,
																						 this.tbSep10,
																						 this.tbReq,
																						 this.tbSep3,
																						 this.tbDoc,
																						 this.tbSep9,
																						 this.tbPaym,
																						 this.tbSep5,
																						 this.tbAccStat,
																						 this.tbSep11,
																						 this.tbLinked,
																						 this.tbSep22,
																						 this.tbReps,
																						 this.tbSep6,
																						 this.tbHelp,
																						 this.tbSep});
			this.tbMainMDI.ButtonSize = new System.Drawing.Size(100, 20);
			this.tbMainMDI.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tbMainMDI.DropDownArrows = true;
			this.tbMainMDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.tbMainMDI.ImageList = this.imageList1;
			this.tbMainMDI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tbMainMDI.Location = new System.Drawing.Point(0, 0);
			this.tbMainMDI.Name = "tbMainMDI";
			this.tbMainMDI.ShowToolTips = true;
			this.tbMainMDI.Size = new System.Drawing.Size(964, 42);
			this.tbMainMDI.TabIndex = 4;
			this.tbMainMDI.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMainMDI_ButtonClick);
			// 
			// tbFile
			// 
			this.tbFile.ImageIndex = 3;
			this.tbFile.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbFile.Text = "База данных";
			// 
			// tbSep1
			// 
			this.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbDir
			// 
			this.tbbDir.DropDownMenu = this.cmnuDir;
			this.tbbDir.ImageIndex = 0;
			this.tbbDir.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbbDir.Text = "Справочники";
			// 
			// tbSep2
			// 
			this.tbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbAcc
			// 
			this.tbAcc.DropDownMenu = this.cmnuAccounts;
			this.tbAcc.ImageIndex = 9;
			this.tbAcc.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbAcc.Text = "Счета";
			// 
			// tbSep10
			// 
			this.tbSep10.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbReq
			// 
			this.tbReq.ImageIndex = 5;
			this.tbReq.Text = "Заявки";
			// 
			// tbSep3
			// 
			this.tbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbDoc
			// 
			this.tbDoc.ImageIndex = 7;
			this.tbDoc.Text = "Транзакции";
			// 
			// tbSep9
			// 
			this.tbSep9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbPaym
			// 
			this.tbPaym.ImageIndex = 1;
			this.tbPaym.Text = "Пл.поручения";
			// 
			// tbSep5
			// 
			this.tbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbAccStat
			// 
			this.tbAccStat.ImageIndex = 10;
			this.tbAccStat.Text = "Выписки";
			// 
			// tbSep11
			// 
			this.tbSep11.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbLinked
			// 
			this.tbLinked.ImageIndex = 11;
			this.tbLinked.Text = "Связывание";
			// 
			// tbSep22
			// 
			this.tbSep22.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbReps
			// 
			this.tbReps.DropDownMenu = this.cmnuReports;
			this.tbReps.ImageIndex = 6;
			this.tbReps.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbReps.Text = "Отчеты";
			this.tbReps.Visible = false;
			// 
			// tbSep6
			// 
			this.tbSep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.tbSep6.Visible = false;
			// 
			// tbHelp
			// 
			this.tbHelp.DropDownMenu = this.cmnuHelp;
			this.tbHelp.ImageIndex = 8;
			this.tbHelp.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbHelp.Text = "HELP!";
			// 
			// tbSep
			// 
			this.tbSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT DISTINCT Accounts.CurrencyID, Currencies.CurrencyID AS CCurrencyID FROM Ac" +
				"counts FULL OUTER JOIN Currencies ON Accounts.CurrencyID = Currencies.CurrencyID" +
				" WHERE (Accounts.CurrencyID IS NULL)";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlCmdBackup
			// 
			this.sqlCmdBackup.CommandText = "[BackupToFile]";
			this.sqlCmdBackup.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdBackup.Connection = this.sqlConnection1;
			this.sqlCmdBackup.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// MenuItemImageProvider1
			// 
			this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
			// 
			// MainMDIForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(964, 349);
			this.Controls.Add(this.tbMainMDI);
			this.Controls.Add(this.stsBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainMDIForm";
			this.Text = "BPS";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainMDIForm_Closing);
			this.MdiChildActivate += new System.EventHandler(this.MainMDIForm_MdiChildActivate);
			this.Load += new System.EventHandler(this.MainMDIForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.stsBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnlUserName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string [] args) 
		{
			if(args.Length > 0)
			{
				if(args[0] == "init")
					bIsInit = true;
			}
			/*if(args.Length > 1)
			{
				if(args[1] == "logon")
					bIsLogon = true;
			}*/
			Application.Run(new MainMDIForm());
			
		}
		private void MakeMenu()
		{
			App.Clone(this.mnuDirectories.MenuItems, this.cmnuDir);
			App.Clone(this.mnuAccounts.MenuItems, this.cmnuAccounts);
			App.Clone(this.mnuReports.MenuItems,this.cmnuReports);
			App.Clone(this.mnuHelp.MenuItems, this.cmnuHelp);
		}

		private bool DoLogon()
		{
			this.spnlUserName.Text = "Anonymous";
//			return true;
			this.Hide();
			DataTable dtUserInfo = new DataTable();
			string szConn = App.OleDbConnectionString;
			AuthControl.AuthComp ac = new AuthControl.AuthComp(szConn);
			ac.DoLogon(dtUserInfo, ref App.UserLogonID, ref App.UserLogonHistoryID);
			if(App.UserLogonID != -1)
			{ 
				this.Show();
				App.AllowClientsDirRead = this.mnuClients.Enabled = (bool) dtUserInfo.Rows[0]["ClientsDirRead"];
				App.AllowOrgDirRead = this.mnuOrgs.Enabled = (bool) dtUserInfo.Rows[0]["OrgDirRead"];
				App.AllowUserInfo = 
				this.mnuUsers.Enabled = 
				this.mnuUsersOrgsAccounts.Enabled = (bool) dtUserInfo.Rows[0]["UserInfo"];
				//App.AllowPermissionListEdit = this.menuItem11.Enabled = (bool) dtUserInfo.Rows[0]["PermissionListEdit"];
				App.AllowClientsRequests = this.mnuRequestsList.Enabled = this.tbReq.Enabled = (bool) dtUserInfo.Rows[0]["ClientsRequests"];
				App.AllowTransactions = this.mnuTrans.Enabled = this.tbDoc.Enabled = (bool) dtUserInfo.Rows[0]["Transactions"];
				App.AllowAccountsStatements = this.mnuAccSt.Enabled = this.tbAccStat.Enabled = (bool) dtUserInfo.Rows[0]["AccountsStatements"];
				App.AllowEditConfirmedAccountStatement = (bool) dtUserInfo.Rows[0]["EditConfirmedAccountStatement"];
				App.AllowAccountsStatementsConfirmed = (bool) dtUserInfo.Rows[0]["AccountsStatementsConfirmed"];
				App.AllowAccountsStatementsEdit = (bool) dtUserInfo.Rows[0]["AccountsStatementsEdit"];
				App.AllowClientsDirChange = (bool) dtUserInfo.Rows[0]["ClientsDirChange"];
				App.AllowClientsRequestsEdit = (bool) dtUserInfo.Rows[0]["ClientsRequestsEdit"];
				App.AllowClientsRequestsExecute = (bool) dtUserInfo.Rows[0]["ClientsRequestsExecute"];
				App.AllowOrgDirChange = (bool) dtUserInfo.Rows[0]["OrgDirChange"];
				App.AllowTransactionsEdit = (bool) dtUserInfo.Rows[0]["TransactionsEdit"];
				App.AllowTransactionsExecute = (bool) dtUserInfo.Rows[0]["TransactionsExecute"];
				//App.AllowUserInfoEdit = (bool) dtUserInfo.Rows[0]["UserInfoEdit"];
				App.AllowPaymsOrdersRecognition = this.mnuPaymsOrdersRecognition.Enabled = this.tbLinked.Enabled = (bool) dtUserInfo.Rows[0]["PaymsOrdersRecognition"];
				App.AllowPaymentsOrders = this.mnuPaymIn.Enabled = this.tbPaym.Enabled = (bool) dtUserInfo.Rows[0]["PaymentsOrders"];
				App.AllowPaymentsOrdersEdit = (bool) dtUserInfo.Rows[0]["PaymentsOrdersEdit"];
				App.AllowPaymentsOrdersSending = (bool) dtUserInfo.Rows[0]["PaymentsOrdersSending"];
				App.AllowAccounts = this.mnuAccounts.Enabled = this.tbAcc.Enabled = (bool) dtUserInfo.Rows[0]["Accounts"];
				App.AllowBanks = this.mnuBanks.Enabled = (bool) dtUserInfo.Rows[0]["Banks"];
				App.AllowBanksEdit = (bool) dtUserInfo.Rows[0]["BanksEdit"];
				App.AllowCurrencies = this.mnuCurrency.Enabled = (bool) dtUserInfo.Rows[0]["Currencies"];
				App.AllowCurrenciesEdit = (bool) dtUserInfo.Rows[0]["CurrenciesEdit"];
				App.AllowCurrenciesRate = this.menuItem4.Enabled = (bool) dtUserInfo.Rows[0]["CurrenciesRate"];
				App.AllowCurrenciesRateEdit = (bool) dtUserInfo.Rows[0]["CurrenciesRateEdit"];
				this.MakeMenu();
				this.spnlUserName.Text = ac.UserName;
				return true;
			}
			else
			{
				Application.Exit();
				return false;
			}
		}
		private Form FindOpenedForm(Type FormType)
		{
			MenuItem mi = Menu.MdiListItem;
			foreach( Form f in MdiChildren) 
			{
				if (f.GetType()==FormType)
				{
					f.Show();
					f.Activate();
					return f;
				}
			}
			Type[] tp = new Type[0];
			ConstructorInfo ci = FormType.GetConstructor(tp);
			object[] ob = new object[0];
			Form frm = (Form)ci.Invoke(ob);
			frm.MdiParent = this;
			frm.Show();
			return frm;			
		}
		private bool isOpenForm(Type FormType)
		{
			foreach( Form f in MdiChildren) 
			{
				if (f.GetType()==FormType)
				{
					f.Show();
					f.Activate();
					return false;
				}
			}
			return true;
		}
		private void mnuClients_Click(object sender, System.EventArgs e)
		{
			//Comps.coClientEx cc = new Comps.coClientEx(App.Connection);
			//cc.ShowDlg(this);
			App.ShowClientList(this);
		}

		private void mnuCurrency_Click(object sender, System.EventArgs e)
		{
			//BPS.BLL.Currency.coCurrency cc = new BPS.BLL.Currency.coCurrency(App.Connection);
			//cc.ShowList(this);
			this.FindOpenedForm(typeof(BPS._Forms.Currency.CurrList));
		}
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.FindOpenedForm(typeof(BPS._Forms.Currency.CurrHistory));
		}

		private void mnuOrgs_Click(object sender, System.EventArgs e)
		{
			this.FindOpenedForm(typeof(BPS._Forms.Orgs.OrgsList));
		}

		private void mnuBanks_Click(object sender, System.EventArgs e)
		{
			//Banks.coBanks cb = new Banks.coBanks(App.Connection);
			//cb.ShowList(this);
//			App.ShowBankList(this);
			if(!App.AllowBanks)
				return;
			this.FindOpenedForm(typeof(BPS.Forms.Bank.BanksList));

		}

		private void mnuPaymIn_Click(object sender, System.EventArgs e)
		{
			//Платежи
			if(!App.AllowPaymentsOrders)
				return;
			this.FindOpenedForm(typeof(PaymentsOrdersList));
/*
			BPS._Forms.PaymentsOrdersList pl = new BPS._Forms.PaymentsOrdersList();
			pl.MdiParent = this;
			pl.Show();
*/		}

		private void mnuTrans_Click(object sender, System.EventArgs e)
		{
			//Транзакции
			if(!App.AllowTransactions)
				return;
			this.FindOpenedForm(typeof(TransactionsList));
/*
			TransactionsList trl = new TransactionsList();
			trl.MdiParent = this;
			trl.Show();
*/		}


		private void MainMDIForm_Load(object sender, System.EventArgs e)
		{
//			if(bIsLogon)
				this.DoLogon();
			App.clearLocks();
			this.stsBarPanel1.Text = App.Connection.DataSource+"."+App.Connection.Database;
		}
		
		private void MainMDIForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ( DialogResult.No ==MessageBox.Show("Завершить работу, Вы, уверены?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				// Cancel the Closing event from closing the form.
				e.Cancel = true;
				return;
			}
			string szConn = App.OleDbConnectionString;
			AuthControl.AuthComp ac = new AuthControl.AuthComp(szConn);
			ac.UpdateUserHistory(App.UserLogonHistoryID);
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			//Б/Н платежи конторы
		}

		private void mnuPaymOut_Click(object sender, System.EventArgs e)
		{
			//Заявки клиентов
			if(!App.AllowClientsRequests)
				return;
			this.FindOpenedForm(typeof(ClientRequestsList));
/*
 * 			BPS._Forms.ClientRequest cr = new BPS._Forms.ClientRequest();
			cr.MdiParent = this;
			cr.Show();
*/		}

		private void mnuAccSt_Click(object sender, System.EventArgs e)
		{
			//Выписки
			if(!App.AllowAccountsStatements)
				return;
			BPS._Forms.AccountsStatementsList asl = new BPS._Forms.AccountsStatementsList();
			asl.MdiParent = this;
			asl.Show();
		}

		private void mnuProgClose_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}


		private void mnuClientsBalances_Click(object sender, System.EventArgs e)
		{
			//Балансы Счетов Клиентов
			FindOpenedForm(typeof(AccountStates_Clients));
/*
 * 			BPS._Forms.ClientsBalances  frm = new BPS._Forms.ClientsBalances();
			frm.MdiParent = this;
			frm.Show();		
*/		}

		private void mnuBankAccountsStates_Click(object sender, System.EventArgs e)
		{
			//Состояние Расчётных Счетов Конторы
			FindOpenedForm(typeof(AccountStates_Banks));
/*
			BPS._Forms.BankAccountStates frm = new BPS._Forms.BankAccountStates();
			frm.MdiParent = this;
			frm.Show();				
*/
		}

		private void mnuPaymsOrdersRecognition_Click(object sender, System.EventArgs e)
		{
			if(!App.AllowPaymsOrdersRecognition)
				return;
			FindOpenedForm(typeof(PaymentsOrdersRecognition));
//			BPS._Forms.PaymentsOrdersRecognition frm =new BPS._Forms.PaymentsOrdersRecognition();
//			frm.MdiParent = this;
//			frm.Show();				
		}

		private void mnuOurAccountstates_Click(object sender, System.EventArgs e)
		{
			FindOpenedForm(typeof(AcountStates_Our));		
		}

		private void tbMainMDI_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			
			if (e.Button == this.tbHelp)
				ShowAbout();
			else if (e.Button == this.tbAcc)
				this.FindOpenedForm(typeof(BPS._Forms.Accounts.AllAccounts));
			else if (e.Button == this.tbbDir)
			{
				App.ShowClientList(this);
			}
			else if (e.Button == this.tbDoc)
			{
				if(!App.AllowTransactions)
					return;
				this.FindOpenedForm(typeof(TransactionsList));
			}
			else if (e.Button == this.tbPaym)
			{
				if(!App.AllowPaymentsOrders)
					return;
				this.FindOpenedForm(typeof(PaymentsOrdersList));
			}
			else if (e.Button == this.tbReq)
			{
				if(!App.AllowClientsRequests)
					return;
				this.FindOpenedForm(typeof(ClientRequestsList));
			}
			else if (e.Button == this.tbAccStat)
			{
				if(!App.AllowAccountsStatements)
					return;
				this.FindOpenedForm(typeof(AccountsStatementsList));
			}
			else if (e.Button == this.tbLinked)
			{
				if(!App.AllowPaymsOrdersRecognition)
					return;
				FindOpenedForm(typeof(PaymentsOrdersRecognition));
			}
			else if (e.Button == this.tbFile) 
			{
				if ( AM_Controls.MsgBoxX.Show("Создать резервную копию БД?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					BackupDataBase();
			}

		}
		private void mnuBalance_Click(object sender, System.EventArgs e)
		{
			FindOpenedForm(typeof(Balance));
		
		}

		private void ShowAbout()
		{
			About dlg = new About();
			dlg.ShowDialog();
		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			ShowAbout();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			//Состояние Расчётных Счетов Конторы Начальные значения
			//FindOpenedForm(typeof(AccountStates_Banks));
			AccountStates_Banks asb = new AccountStates_Banks(true);
			asb.MdiParent = this;
			asb.Show();
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			//Учётные счета Начальные значенияAcountStates_Our
			AcountStates_Our asu = new AcountStates_Our(true);
			asu.MdiParent = this;
			asu.Show();
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			//Счета клиентов Начальные значения
			AccountStates_Clients asc = new AccountStates_Clients(true);
			asc.MdiParent = this;
			asc.Show();
		}

		private void mnuUsersList_Click(object sender, System.EventArgs e)
		{
			if(!this.isOpenForm(typeof(AuthControl.Users)))
				return;
			AuthControl.Users us = new AuthControl.Users(App.OleDbConnectionString);
			App.SetDataGridTableStyle(us.StyleDgUsers);
			App.SetDataGridTableStyle(us.StyleDgGroups);
			us.MdiParent = this;
			us.Show();
		}

		private void mnuUsersOrgsAccounts_Click(object sender, System.EventArgs e)
		{
			OrgAccountAccess OrgAccountAccessForm = new OrgAccountAccess();
			OrgAccountAccessForm.ShowDialog();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			AuthControl.PermissionsList pl = new AuthControl.PermissionsList(App.OleDbConnectionString);
			App.SetDataGridTableStyle(pl.GridStyle);
			pl.MdiParent = this;
			pl.Show();
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			this.FindOpenedForm(typeof(BPS._Forms.Accounts.AllAccounts));
		}

		private void stsBar_DrawItem(object sender, System.Windows.Forms.StatusBarDrawItemEventArgs sbdevent)
		{
/*			if (sbdevent.Index==0) 
			{
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
				sbdevent.Graphics.DrawIcon(((System.Drawing.Icon)(resources.GetObject("$this.Icon"))),-4,-4);
				Font drawFont = new Font("Tahoma",8);
				SolidBrush drawBrush = new SolidBrush(Color.Black);
				sbdevent.Graphics.DrawString(this.stsBarPanel1.Text, drawFont,drawBrush,25.0F,4.0F);
			}
			else 
*/
			if (sbdevent.Panel == this.statusBarPanel2) 
			{
				Font drawFont = new Font("Arial",11, FontStyle.Italic|FontStyle.Bold);
				SolidBrush drawBrush = new SolidBrush(Color.RoyalBlue);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Far;
				sf.LineAlignment = StringAlignment.Center;
				sf.FormatFlags = StringFormatFlags.NoWrap;
				Rectangle r = sbdevent.Bounds;
				
				r.Width -= 5;
				r.Y -= 1;
//				SolidBrush drawBrush2 = new SolidBrush(Color.Cornsilk);
//				sbdevent.Graphics.FillRectangle(drawBrush2,sbdevent.Bounds);
				sbdevent.Graphics.DrawString(this.statusBarPanel2.Text, drawFont,drawBrush,r,sf);
			}

		}

		bool bAboutClicked;
		private void stsBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			bAboutClicked = (e.StatusBarPanel == this.statusBarPanel2);
/*			if (bAboutClicked) 
			{
				About dlg = new About();
				dlg.ShowDialog();
			}
*/		
		}

		private void stsBar_DoubleClick(object sender, System.EventArgs e)
		{
			if (bAboutClicked) 
			{
				About dlg = new About();
				dlg.ShowDialog();
			}
		
		}

		private void mnuLockAccess_Click(object sender, System.EventArgs e)
		{
			LockAccess();
		}
		
		private void LockAccess()
		{
			foreach( Form f in MdiChildren) 
				f.Close();
			this.DoLogon();
		}

		private void mnuRefrBook_Click(object sender, System.EventArgs e)
		{
			App.RefreshBook();
		}

		private void mnuLocksList_Click(object sender, System.EventArgs e)
		{
			foreach( Form f in MdiChildren) 
			{
				if (f.GetType()==typeof(LocksView))
				{
					f.Show();
					f.Activate();
					return;
				}
			}
			Type[] tp = new Type[0];
			ConstructorInfo ci = typeof(LocksView).GetConstructor(tp);
			object[] ob = new object[0];
			Form frm = (Form)ci.Invoke(ob);
			//frm.MdiParent = this;
			frm.Show();
			//FindOpenedForm(typeof(LocksView));
		}

		private void mnuArch_Click(object sender, System.EventArgs e)
		{
			BackupDataBase();
		}
		private void BackupDataBase()
		{
			App.ExecSql(this.sqlCmdBackup);
		}

		private void mnuFileFormats_Click(object sender, System.EventArgs e)
		{
			this.FindOpenedForm(typeof(FileFormatSettingsList));
		}

		private void mnuCredits_Click(object sender, System.EventArgs e)
		{
			FindOpenedForm(typeof(BPS._Forms.Credits.Credits));
		}

		private void mnuAccountsStatements_Click(object sender, System.EventArgs e)
		{
		}

		private void mnuCities_Click(object sender, System.EventArgs e)
		{
			FindOpenedForm(typeof(BPS.Forms.City.Cities));
		}

		private void MainMDIForm_MdiChildActivate(object sender, System.EventArgs e)
		{
			reDrawMainMenu(false);
			reDrawMainMenu(true);
		}
		private void reDrawMainMenu(bool isVisible)
		{
			for(int i = 0; i<mainMenu1.MenuItems.Count;i++)
			{
				reDrawMenu(mainMenu1.MenuItems[i], isVisible);
			}
		}
		private void reDrawMenu(MenuItem mnu, bool isVisible)
		{
			mnu.Visible= isVisible;
			if(mnu.MenuItems.Count == 0)
				return;
			else
			{
				for(int i = 0; i < mnu.MenuItems.Count; i++)
				{
					reDrawMenu(mnu.MenuItems[i], isVisible);
				}
			}
		}

	}
}
