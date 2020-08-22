using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for FileFormatSettingsList.
	/// </summary>
	public class FileFormatSettingsList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.ComponentModel.IContainer components;
		private ConfigLoader cl;

		public FileFormatSettingsList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			cl = new ConfigLoader(App.POFormatSettingsFileName);
			string[] settings = cl.GetSettingsCollection();
			System.Data.DataTable dt = new System.Data.DataTable("SettingsFormats");
			dt.Columns.Add("Number", System.Type.GetType("System.Int32"));
			dt.Columns.Add("Name", System.Type.GetType("System.String"));
			dt.Columns.Add("Comments", System.Type.GetType("System.String"));
			for(int counter = 0; counter < settings.Length; counter ++)
			{
				string comments = cl.GetSpecifiedNodeDescription(settings[counter]);
				dt.Rows.Add(new object[] {counter + 1, settings[counter], comments});
			}
			this.dataView1.Table = dt;
			this.dataGrid1.DataSource = this.dataView1;
			this.dataView1.AllowDelete = 
				this.dataView1.AllowEdit = 
				this.dataView1.AllowNew = false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileFormatSettingsList));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataView1 = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel});
			this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(526, 25);
			this.toolBar1.TabIndex = 5;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "Новая";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Изменить";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 3;
			this.tbbDel.Text = "Удалить";
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 25);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(526, 280);
			this.dataGrid1.TabIndex = 6;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "SettingsFormats";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Номер";
			this.dataGridTextBoxColumn1.MappingName = "Number";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Наименование";
			this.dataGridTextBoxColumn2.MappingName = "Name";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Описание";
			this.dataGridTextBoxColumn3.MappingName = "Comments";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 250;
			// 
			// FileFormatSettingsList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(526, 305);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid1,
																		  this.toolBar1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FileFormatSettingsList";
			this.Text = "Форматы файлов выписок";
			this.Load += new System.EventHandler(this.FileFormatSettingsList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			EditFileFormat();
		}

		private void EditFileFormat()
		{
			BindingManagerBase bm = this.BindingContext[dataView1];
			string settings_name = ((DataRowView)bm.Current).Row[1].ToString();
			FileFormatSettingsEdit FileFormatSettingsEditForm = new FileFormatSettingsEdit(cl, settings_name, true);
			if(FileFormatSettingsEditForm.ShowDialog() == DialogResult.OK)
			{
				RefreshFormatsTable();
			}
			return;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbbNew)
			{
				NewFileFormat();
			}
			else
			{
				if(e.Button == this.tbbEdit)
				{
					EditFileFormat();
				}
				else
				{
					if(e.Button == this.tbbDel)
					{
						DeleteFileFormat();
					}
				}
			}
		}

		private void RefreshFormatsTable()
		{
			string[] settings = cl.GetSettingsCollection();
			this.dataView1.Table.Rows.Clear();
			for(int counter = 0; counter < settings.Length; counter ++)
			{
				string comments = cl.GetSpecifiedNodeDescription(settings[counter]);
				this.dataView1.Table.Rows.Add(new object[] {counter + 1, settings[counter], comments});
			}
		}

		private void NewFileFormat()
		{
			cl.AddNewFormat("новый формат");
			FileFormatSettingsEdit FileFormatSettingsEditForm = new FileFormatSettingsEdit(cl, "новый формат", false);
			if(FileFormatSettingsEditForm.ShowDialog() == DialogResult.OK)
			{
				RefreshFormatsTable();
			}
			else
			{
				cl.DelFormat("новый формат");
			}
		}

		private void FileFormatSettingsList_Load(object sender, System.EventArgs e)
		{
		
		}

		private void DeleteFileFormat()
		{
			BindingManagerBase bm = this.BindingContext[dataView1];
			string settings_name = ((DataRowView)bm.Current).Row[1].ToString();
			if(cl.DelFormat(settings_name))
			{
				this.dataView1.Table.Rows.Remove(((DataRowView)bm.Current).Row);
			}
		}
	}
}
