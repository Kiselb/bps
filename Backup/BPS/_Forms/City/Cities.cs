using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS.Forms.City
{
	/// <summary>
	/// Summary description for Cities.
	/// </summary>
	public class Cities : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.DataView dvCities;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn CityID;
		private System.Windows.Forms.DataGridTextBoxColumn CityName;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.ToolBarButton tbbRefresh;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuDel;
		private System.ComponentModel.IContainer components;
		private BPS.BLL.City.coCities BPSCity;

		public Cities()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			BPSCity = new BPS.BLL.City.coCities();
			FillCities();
			this.dvCities.Table = this.BPSCity.DataSet.Cities;
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Cities));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuDel = new System.Windows.Forms.MenuItem();
			this.dvCities = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.CityID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CityName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbbRefresh = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCities)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvCities;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 28);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(526, 245);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuNew,
																						 this.mnuEdit,
																						 this.mnuDel});
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.mnuNew.Text = "Новый";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 1;
			this.mnuEdit.Text = "Изменить";
			this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
			// 
			// mnuDel
			// 
			this.mnuDel.Index = 2;
			this.mnuDel.Text = "Удалить";
			this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
			// 
			// dvCities
			// 
			this.dvCities.AllowDelete = false;
			this.dvCities.AllowEdit = false;
			this.dvCities.AllowNew = false;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.CityID,
																												  this.CityName});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Cities";
			// 
			// CityID
			// 
			this.CityID.Format = "";
			this.CityID.FormatInfo = null;
			this.CityID.HeaderText = "ID";
			this.CityID.MappingName = "CityID";
			this.CityID.NullText = "-";
			this.CityID.ReadOnly = true;
			this.CityID.Width = 50;
			// 
			// CityName
			// 
			this.CityName.Format = "";
			this.CityName.FormatInfo = null;
			this.CityName.HeaderText = "Название";
			this.CityName.MappingName = "CityName";
			this.CityName.NullText = "-";
			this.CityName.Width = 200;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel,
																						this.toolBarButton3,
																						this.tbbRefresh});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(526, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 3;
			this.tbbNew.Text = "Новый";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 0;
			this.tbbEdit.Text = "Изменить";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 1;
			this.tbbDel.Text = "Удалить";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.ImageIndex = 2;
			this.tbbRefresh.Text = "Обновить";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Cities
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(526, 273);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Cities";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Города";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Cities_Closing);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCities)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void FillCities()
		{
			BPSCity.Fill();
		}

		private bool UpdateCities()
		{
			return BPSCity.Update();
		}

		private void Cities_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			UpdateCities();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbbNew)
			{
				AddNewCity();
			}
			else if(e.Button == this.tbbEdit)
			{
				EditCity();
			}
			else if(e.Button == this.tbbDel)
			{
				DeleteCity();
			}
			else if(e.Button == this.tbbRefresh)
			{
				FillCities();
			}
			
		}

		private void AddNewCity()
		{
			CityEdit CityEditForm = new CityEdit(BPSCity, null);
			CityEditForm.Text += " [НОВЫЙ]";
			if(CityEditForm.ShowDialog() == DialogResult.OK)
			{
				if(CityEditForm.NewCityID != -1)
				{
					for(int counter = 0; counter < this.dvCities.Count; counter ++)
					{
						if((int)this.dataGrid1[counter, 0] == CityEditForm.NewCityID)
						{
							this.dataGrid1.CurrentRowIndex = counter;
							this.dataGrid1.Select(counter);
							break;
						}
					}
				}			
			}
		}

		private void EditCity()
		{
			BindingManagerBase bm = this.BindingContext[dvCities];
			if(bm.Position != -1)
			{
				BPS.BLL.City.DataSets.dsCities.CitiesRow rw = (BPS.BLL.City.DataSets.dsCities.CitiesRow)((DataRowView)bm.Current).Row;
				CityEdit CityEditForm = new CityEdit(BPSCity, rw.CityName);
				CityEditForm.Text += " [РЕДАКТИРОВАНИЕ]";
				if(CityEditForm.ShowDialog() == DialogResult.OK)
				{
					rw.BeginEdit();
					rw.CityName = CityEditForm.strCityName;
					rw.EndEdit();
					UpdateCities();
				}
			}
		}

		private void DeleteCity()
		{
			if(MessageBox.Show("Вы действительно хотите удалить выбранный город?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				BindingManagerBase bm = this.BindingContext[dvCities];
				if(bm.Position != -1)
				{
					((DataRowView)bm.Current).Row.Delete();
				}
				if(!UpdateCities())
				{
					BPSCity.RejectChanges();
				}
			}
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			EditCity();
		}

		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			AddNewCity();
		}

		private void mnuEdit_Click(object sender, System.EventArgs e)
		{
			EditCity();
		}

		private void mnuDel_Click(object sender, System.EventArgs e)
		{
			DeleteCity();
		}

	}
}
