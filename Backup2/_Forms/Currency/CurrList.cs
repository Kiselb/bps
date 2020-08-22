using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AM_Controls;

namespace BPS._Forms.Currency
{
	/// <summary>
	/// Summary description for CurrList.
	/// </summary>
	public class CurrList : System.Windows.Forms.Form
	{
		private AM_Controls.DataGridV dataGrid1;
		private BPS.BLL.Currency.DataSets.dsCurr dsCurr1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Data.DataView dataView1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuSetCurrencyRate;
		private System.Windows.Forms.ToolBarButton tbbRate;

		private BPS.BLL.Currency.coCurrency bllCurrency;

		public CurrList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			bllCurrency = App.bllCurrency;
			this.dsCurr1 = bllCurrency.DataSet;
			this.dataView1.Table =  this.dsCurr1.Currencies;
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
				this.menuItem2.Enabled = this.menuItem3.Enabled = this.menuItem4.Enabled = 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CurrList));
			this.dataGrid1 = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.dataView1 = new System.Data.DataView();
			this.dsCurr1 = new BPS.BLL.Currency.DataSets.dsCurr();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.tbbRate = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuSetCurrencyRate = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurr1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1._CanEdit = false;
			this.dataGrid1._InvisibleColumn = 0;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 72);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(340, 175);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dataView1
			// 
			this.dataView1.Table = this.dsCurr1.Currencies;
			// 
			// dsCurr1
			// 
			this.dsCurr1.DataSetName = "dsCurr";
			this.dsCurr1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Currencies";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Код";
			this.dataGridTextBoxColumn1.MappingName = "CurrencyID";
			this.dataGridTextBoxColumn1.NullText = "?";
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Название";
			this.dataGridTextBoxColumn2.MappingName = "CurrencyName";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "#,##0.00";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Курс";
			this.dataGridTextBoxColumn3.MappingName = "CurrencyRate";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 75;
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
																						this.tbbRate});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(340, 72);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 3;
			this.toolBarButton1.Text = "Новый";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 0;
			this.toolBarButton2.Text = "Изменить";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 1;
			this.toolBarButton4.Text = "Удалить";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 2;
			this.toolBarButton5.Text = "Обновить";
			// 
			// tbbRate
			// 
			this.tbbRate.ImageIndex = 4;
			this.tbbRate.Text = "Курс";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
																					this.menuItem1,
																					this.mnuSetCurrencyRate});
			this.mnuEdit.Text = "Редактирование";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem2.Text = "Новая";
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
			// menuItem1
			// 
			this.menuItem1.Index = 5;
			this.menuItem1.Text = "-";
			// 
			// mnuSetCurrencyRate
			// 
			this.mnuSetCurrencyRate.Index = 6;
			this.mnuSetCurrencyRate.Text = "Изменить Курс";
			this.mnuSetCurrencyRate.Click += new System.EventHandler(this.mnuSetCurrencyRate_Click);
			// 
			// CurrList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(340, 247);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "CurrList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Валюты";
			this.Load += new System.EventHandler(this.CurrList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurr1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			editCurr();
		}
		
		
		private void editCurr()
		{
			if(!this.menuItem3.Enabled)
				return;
			if(this.dataView1.Count>0)
			{
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
				BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow rw = (BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow)((DataRowView)bm.Current).Row;
				EditCurr adC = new EditCurr(rw);
				adC.ShowDialog();
				if(adC.DialogResult == DialogResult.OK)
				{
					bllCurrency.Update();
				}
			}
		}


		private void addCurr()
		{
			BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow rw = this.dsCurr1.Currencies.NewCurrenciesRow();
			EditCurr adC = new EditCurr(rw);
			adC.ShowDialog();
			if(adC.DialogResult == DialogResult.OK)
			{
				this.dsCurr1.Currencies.AddCurrenciesRow(rw);
				bllCurrency.Update();
			}
		}



		private void deleteCurr()
		{
			if(this.dataView1.Count>0)
				try
				{
					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
					BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow rw = (BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow)((DataRowView)bm.Current).Row;
					if(MsgBoxX.Show("Вы действительно хотите удалить валюту " + rw.CurrencyName + "?","BPS",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						((DataRowView)bm.Current).Delete();
						bllCurrency.Update();
					}
				}
				catch(Exception ex)
				{
					MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
		}
		
		private void SetCurrencyRate()
		{
			if ( this.dataView1.Count>0)
				try
				{
					string szCurrencyID		="";
					double dCurrencyRate	=0;
					double dCurrencyRateOld	=0;

					BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
					BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow rw = (BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow)((DataRowView)bm.Current).Row;
					
					szCurrencyID		=rw.CurrencyID;
					dCurrencyRateOld	=rw.CurrencyRate;

					SetCurrencyRate dlg = new SetCurrencyRate();
					dlg.Text =dlg.Text +" " +szCurrencyID;
				
					if ( dlg.ShowDialog() == DialogResult.OK) 
					{
						dCurrencyRate	=dlg.tbvNewRate.dValue;
						if ( (Math.Abs( dCurrencyRateOld -dCurrencyRate)/dCurrencyRateOld) >0.05) 
						{
							if (DialogResult.No ==MessageBox.Show("Изменение Курса более чем на 5%. Продолжить?", 
									"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
								return;

						}
						bllCurrency.SetCurrencyMainRate( szCurrencyID, dCurrencyRate);
					}
					this.dataGrid1.CurrentRowIndex =0; 
				}
				catch(Exception ex)
				{
					MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (this.toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					addCurr();
					break;
				case 1:
					editCurr();
					break;
				case 2:
					deleteCurr();
					break;
				case 4:
					bllCurrency.Fill();
					break;
				case 5:
					this.SetCurrencyRate();
					break;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.addCurr();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.editCurr();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.deleteCurr();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			bllCurrency.Fill();
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

		private void CurrList_Load(object sender, System.EventArgs e)
		{
			this.Clone(this.mnuEdit.MenuItems, this.contextMenu1);
		}

		private void mnuSetCurrencyRate_Click(object sender, System.EventArgs e)
		{
			this.SetCurrencyRate();
		}
	}
}
