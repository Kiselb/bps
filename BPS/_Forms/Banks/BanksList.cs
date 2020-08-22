using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AM_Controls;

namespace BPS.Forms.Bank
{
	/// <summary>
	/// Summary description for BanksList.
	/// </summary>
	public class BanksList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		//private System.Windows.Forms.DataGrid dataGrid1;
		private AM_Controls.DataGridV dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbCity;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ImageList imlToolBar;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.ComponentModel.IContainer components;
		private System.Data.DataView dvBanks;
		private BPS.BLL.Bank.DataSets.dsBanks dsBanks1;
		
		private BPS.BLL.Bank.coBanks bllBank;
		private System.Data.DataView dvCities;
		private BPS.BLL.City.coCities bllCity;

		public BanksList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

 			App.SetDataGridTableStyle(this.dataGridTableStyle1);

//			this.bllBank = new BPS.BLL.Bank.coBanks();
//			this.bllCity = new BPS.BLL.City.coCities();
//			this.bllBank.Fill();
//			this.bllCity.Fill();
			this.bllBank = App.bllBank;
			this.bllCity = App.bllCity;
			this.dvCities.Table = this.bllCity.DataSet.Cities;

			this.dsBanks1 = this.bllBank.DataSet;
			this.dvBanks.Table = this.dsBanks1.Banks;
//			this.dataGrid1.DataSource = this.dvBanks;

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
		public bool AllowEdit
		{
			set
			{
				this.menuItem1.Enabled = this.menuItem2.Enabled = this.menuItem3.Enabled = 
					this.toolBarButton1.Enabled = this.toolBarButton2.Enabled = this.toolBarButton4.Enabled = value;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BanksList));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
			this.imlToolBar = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCity = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.dvBanks = new System.Data.DataView();
			this.dsBanks1 = new BPS.BLL.Bank.DataSets.dsBanks();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.dvCities = new System.Data.DataView();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvBanks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsBanks1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCities)).BeginInit();
			this.SuspendLayout();
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
																						this.toolBarButton8,
																						this.toolBarButton6,
																						this.toolBarButton7,
																						this.toolBarButton9});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imlToolBar;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(598, 28);
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
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 6;
			this.toolBarButton5.Text = "Обновить";
			// 
			// toolBarButton8
			// 
			this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.ImageIndex = 4;
			this.toolBarButton6.Text = "Выбрать";
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.ImageIndex = 5;
			this.toolBarButton7.Text = "Сбросить";
			// 
			// toolBarButton9
			// 
			this.toolBarButton9.ImageIndex = 9;
			this.toolBarButton9.Text = "Очистить";
			// 
			// imlToolBar
			// 
			this.imlToolBar.ImageSize = new System.Drawing.Size(16, 16);
			this.imlToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolBar.ImageStream")));
			this.imlToolBar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.toolBar1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(598, 70);
			this.panel1.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbCity);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(598, 42);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(230, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Город:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "Название:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbCity
			// 
			this.tbCity.Location = new System.Drawing.Point(276, 16);
			this.tbCity.Name = "tbCity";
			this.tbCity.Size = new System.Drawing.Size(136, 21);
			this.tbCity.TabIndex = 1;
			this.tbCity.Text = "";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(80, 16);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(118, 21);
			this.tbName.TabIndex = 0;
			this.tbName.Text = "";
			// 
			// dataGrid1
			// 
			this.dataGrid1._CanEdit = false;
			this.dataGrid1._InvisibleColumn = 0;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvBanks;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 70);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(598, 335);
			this.dataGrid1.TabIndex = 2;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dvBanks
			// 
			this.dvBanks.Table = this.dsBanks1.Banks;
			// 
			// dsBanks1
			// 
			this.dsBanks1.DataSetName = "dsBanks";
			this.dsBanks1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Banks";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.MappingName = "BankID";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Название";
			this.dataGridTextBoxColumn2.MappingName = "BankName";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Город";
			this.dataGridTextBoxColumn3.MappingName = "CityName";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 110;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "БИК";
			this.dataGridTextBoxColumn4.MappingName = "CodeBIK";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.Width = 101;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Кор. счёт";
			this.dataGridTextBoxColumn5.MappingName = "KAccount";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.Width = 150;
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
																					this.menuItem1,
																					this.menuItem2,
																					this.menuItem3,
																					this.menuItem4,
																					this.menuItem5,
																					this.menuItem6,
																					this.menuItem7,
																					this.menuItem8,
																					this.menuItem9});
			this.mnuEdit.Text = "Редактирование";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem1.Text = "Новый";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.menuItem2.Text = "Изменить";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.menuItem3.Text = "Удалить";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem5.Text = "Обновить";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 5;
			this.menuItem6.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 6;
			this.menuItem7.Text = "Выбрать";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 7;
			this.menuItem8.Text = "Сбросить";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.Text = "Очистить";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// BanksList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(598, 405);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "BanksList";
			this.Text = "Банки";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.BanksList_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvBanks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsBanks1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCities)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (this.toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					addBank();
					break;
				case 1:
					editBank();
					break;
				case 2:
					deleteBank();
					break;
				case 4:
					this.bllBank.Fill();
					break;
				case 6:
					this.applyFilter();
					break;
				case 7:
					this.dvBanks.RowFilter = "";
					break;
				case 8:
					this.resetFilter();
					break;
			}
		}
		
		private void addBank()
		{
/*
  			BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw = this.dsBanks1.Banks.NewBanksRow();
			EditBank eb = new EditBank(rw, this.bllCity);
			eb.ShowDialog();
			if(eb.DialogResult == DialogResult.OK)
			{
				this.dsBanks1.Banks.AddBanksRow(rw);
				bllBank.Update();
			}
*/
			EditBank.AddBankDialog(bllBank,bllCity, "", "");
		}

		public static bool AddBankDialog(BPS.BLL.Bank.coBanks bll, BPS.BLL.City.coCities bllC )
		{
			BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw = bll.DataSet.Banks.NewBanksRow();
			EditBank eb = new EditBank(rw, bllC);
			eb.ShowDialog();
			if(eb.DialogResult == DialogResult.OK)
			{
				bll.DataSet.Banks.AddBanksRow(rw);
				bll.Update();
				return true;
			}
			return false;
		}

		private void editBank()
		{
			if(!this.toolBarButton2.Enabled)
				return;
			if(this.dvBanks.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvBanks];
				BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw = (BPS.BLL.Bank.DataSets.dsBanks.BanksRow)((DataRowView)bm.Current).Row;
				EditBank eb = new EditBank(rw,this.bllCity);
				eb.ShowDialog();
				if(eb.DialogResult == DialogResult.OK)
				{
					bllBank.Update();
				}
			}
		}

		private void deleteBank()
		{
			if(this.dvBanks.Count>0)
			{
					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dvBanks];
					BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw = (BPS.BLL.Bank.DataSets.dsBanks.BanksRow)((DataRowView)bm.Current).Row;
					if(MsgBoxX.Show("Вы действительно хотите удалить банк " + rw.BankName + "?","BPS",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						((DataRowView)bm.Current).Delete();
						bllBank.Update();
					}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnFilterSet_Click(object sender, System.EventArgs e)
		{
			applyFilter();
		}

		private void btnFilterReset_Click(object sender, System.EventArgs e)
		{
			resetFilter();
		}
		private void applyFilter()
		{
			string szFilter = "";
			if(this.tbName.Text.Length>0)
			{
				szFilter = "BankName LIKE'" + this.tbName.Text + "*'";
			}
			if(this.tbCity.Text.Length>0)
			{
				if(szFilter.Length>0)
					szFilter += " and ";
				szFilter += "CityName LIKE'" + this.tbCity.Text + "*'";
			}
			this.dvBanks.RowFilter = szFilter;
		}
		private void resetFilter()
		{
			this.dvBanks.RowFilter = "";
			this.tbCity.Text = "";
			this.tbName.Text = "";
		}


		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.editBank();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.addBank();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.editBank();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.deleteBank();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.bllBank.Fill();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			this.applyFilter();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.dvBanks.RowFilter = "";
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.resetFilter();
		}

		private void BanksList_Load(object sender, System.EventArgs e)
		{
			this.Clone(this.mnuEdit.MenuItems, this.contextMenu1);
		}
		public void Clone(System.Windows.Forms.Menu.MenuItemCollection pattern, ContextMenu clone)
		{
			while (clone.MenuItems.Count>0)
				clone.MenuItems.RemoveAt(0);
			foreach( MenuItem mn in pattern) 
			{
				clone.MenuItems.Add(mn.CloneMenu());
			}
		}
	}
}
