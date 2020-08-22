using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using ExportToExel;

namespace BPS._Forms.Currency
{
	/// <summary>
	/// Summary description for CurrHistory.
	/// </summary>
	public class CurrHistory : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private AM_Controls.DataGridV dataGridV1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private DataTable dtCurr;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Data.DataView dvHistory;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		
		private BPS.BLL.Currency.coCurrency bllCurrency;


		public CurrHistory()
		{
			bllCurrency = App.bllCurrency;
			BPS.BLL.Currency.DataSets.dsCurrHistory dsH = bllCurrency.DataSetHistory;
			BPS.BLL.Currency.DataSets.dsCurr dsC = bllCurrency.DataSet;

			InitializeComponent();

			this.dtCurr = new DataTable("CurrHistory");
			DataColumn currID = new DataColumn("Currency");
			this.dtCurr.Columns.Add(currID);
			for(int i=0;i<dsC.Currencies.Rows.Count;i++)
			{
				DataColumn dc = new DataColumn(dsC.Currencies.Rows[i]["CurrencyID"].ToString());
				dc.DataType = System.Type.GetType("System.Double");
				this.dtCurr.Columns.Add(dc);
			}
			dataGridTableStyle1 = new DataGridTableStyle();
			this.dataGridTableStyle1.MappingName = "CurrHistory";
			this.dataView1.Table = this.dtCurr;//dsH.CurrenciesHistory;
			this.dataGridV1.DataSource = this.dataView1;//this.dtCurr;
			this.setDgStyle();
			this.dataGridV1.TableStyles.Add(this.dataGridTableStyle1);
			this.dvHistory.Table = dsH.CurrenciesHistory;
			this.checkBox1.Checked = true;
		
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
		public bool AllowEdit
		{
			set
			{
				this.checkBox1.Enabled = this.toolBarButton2.Enabled = value;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CurrHistory));
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.dataView1 = new System.Data.DataView();
			this.dvHistory = new System.Data.DataView();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvHistory)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.groupBox1,
																				 this.toolBar1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(458, 64);
			this.panel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.checkBox1,
																					this.label1,
																					this.dateTimePicker1});
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(458, 39);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(162, 14);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(118, 16);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Только просмотр";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Дата:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(58, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(86, 21);
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton2,
																						this.toolBarButton5});
			this.toolBar1.ButtonSize = new System.Drawing.Size(100, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(458, 25);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 1;
			this.toolBarButton2.Text = "Записать";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 0;
			this.toolBarButton5.Text = "Обновить";
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
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 64);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.Size = new System.Drawing.Size(458, 261);
			this.dataGridV1.TabIndex = 0;
			// 
			// dataView1
			// 
			this.dataView1.AllowDelete = false;
			this.dataView1.AllowNew = false;
			// 
			// dvHistory
			// 
			this.dvHistory.AllowDelete = false;
			this.dvHistory.AllowNew = false;
			// 
			// CurrHistory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(458, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGridV1,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CurrHistory";
			this.Text = "История валют";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvHistory)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void fillTableHistory()
		{
			this.dtCurr.Clear();
			//if(this.dateTimePicker1.Value.Date <= DateTime.Today)
			{
				this.dvHistory.RowFilter = "CurrDate <" + this.getDate(this.dateTimePicker1.Value.AddDays(1)) + " and CurrDate>=" + this.getDate(this.dateTimePicker1.Value);// + "*";
				if(this.dvHistory.Count == 0)
				{
					for(int i=1;i<this.dtCurr.Columns.Count;i++)
					{
						for(int j=1;j<this.dtCurr.Columns.Count;j++)
						{
							BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow rw = (BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow) this.dvHistory.Table.NewRow();
							rw.CurrencyID = this.dtCurr.Columns[i].ColumnName;
							rw.BaseCurrencyID = this.dtCurr.Columns[j].ColumnName;
							rw.CurrDate = this.dateTimePicker1.Value;
							if(i==j)
								rw.CurrRate = 1;
							else
								rw.CurrRate = 0;
							rw.CurrencyName = "";
							this.dvHistory.Table.Rows.Add((DataRow) rw);
						}
					}
					bllCurrency.UpdateHistory();
				}
				
				for(int i=1;i<this.dtCurr.Columns.Count;i++)
				{
					DataRow dr = this.dtCurr.NewRow();
					dr[0] = this.dtCurr.Columns[i].ColumnName;
					/*for(int j=1;j<this.dtCurr.Columns.Count;j++)
					{
							if(Convert.ToDouble(this.dvHistory[iCount]["CurrRate"])>0)
								//dr[j] = Convert.DBNull;
								dr[j] = this.dvHistory[iCount]["CurrRate"].ToString();
							iCount++;
					}*/
					this.dtCurr.Rows.Add(dr);
				}
				//int iCount = 0;
				for(int j=0;j<this.dvHistory.Count;j++)
				{
					if(Convert.ToDouble(this.dvHistory[j]["CurrRate"])>0)
						this.dtCurr.Rows[this.dtCurr.Columns[this.dvHistory[j]["CurrencyID"].ToString()].Ordinal-1][this.dvHistory[j]["BaseCurrencyID"].ToString()] = this.dvHistory[j]["CurrRate"].ToString(); 
				}
			}
		}
		private void saveChange()
		{
			//int iCount = 0;
			this.dvHistory.RowStateFilter = DataViewRowState.CurrentRows;
			for(int i=1;i<this.dtCurr.Columns.Count;i++)
			{
				for(int j=1;j<this.dtCurr.Columns.Count;j++)
				{
					this.dvHistory.RowFilter = "CurrencyID='" + this.dtCurr.Rows[i-1][0].ToString() + "' and BaseCurrencyID='" + this.dtCurr.Columns[j].ColumnName + "' and " + "CurrDate <" + this.getDate(this.dateTimePicker1.Value.AddDays(1)) + " and CurrDate>=" + this.getDate(this.dateTimePicker1.Value);
					if(this.dvHistory.Count == 1)//(this.dvHistory.Find(new object[] {this.dtCurr.Rows[i-1][0].ToString(), this.dtCurr.Columns[j].ColumnName}) == 1)
					{
						BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow rw = (BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow) this.dvHistory[0].Row;//.FindRows(new object[] {this.dtCurr.Rows[i-1][0].ToString(), this.dtCurr.Columns[j].ColumnName})[0].Row;
						rw.CurrencyID = this.dtCurr.Columns[i].ColumnName;
						rw.BaseCurrencyID = this.dtCurr.Columns[j].ColumnName;
						rw.CurrDate = this.dateTimePicker1.Value;
						if(i==j)
						{
							//rw.CurrRate = 1;
							this.dtCurr.Rows[i-1][j] = 1;
						}
						else if(this.dtCurr.Rows[i-1][j]!=Convert.DBNull)
							rw.CurrRate = Convert.ToDouble(this.dtCurr.Rows[i-1][j]);
						rw.CurrencyName = "";
					}
					else if(this.dvHistory.Count == 0)//(this.dvHistory.Find(new object[] {this.dtCurr.Rows[i-1][0].ToString(), this.dtCurr.Columns[j].ColumnName}) == 1)
					{
						BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow rw = (BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow) this.dvHistory.Table.NewRow();
						rw.CurrencyID = this.dtCurr.Columns[i].ColumnName;
						rw.BaseCurrencyID = this.dtCurr.Columns[j].ColumnName;
						rw.CurrDate = this.dateTimePicker1.Value;
						if(i==j)
						{
							rw.CurrRate = 1;
							this.dtCurr.Rows[i-1][j] = 1;
						}
						else if(this.dtCurr.Rows[i-1][j]!=Convert.DBNull)
							rw.CurrRate = Convert.ToDouble(this.dtCurr.Rows[i-1][j]);
						else if(this.dtCurr.Rows[i-1][j]==Convert.DBNull)
							rw.CurrRate = 0;
						rw.CurrencyName = "";
						this.dvHistory.Table.Rows.Add((DataRow) rw);
					}
				}
					//iCount++;
					//
			}
			bllCurrency.UpdateHistory();
		}
		private string getDate(DateTime dt)
		{
			return "#" + dt.Month + "/" + dt.Day + "/" +  dt.Year + "#";
		}
		private void setDgStyle()
		{
			DataGridTextBoxColumn tbCol = new DataGridTextBoxColumn();
			tbCol.MappingName = this.dtCurr.Columns[0].ColumnName;
			tbCol.HeaderText = "Валюта";
			tbCol.ReadOnly = true;
			tbCol.Width = 50;
			this.dataGridTableStyle1.GridColumnStyles.Add(tbCol);
			for(int i=1;i<this.dtCurr.Columns.Count;i++)
			{
				tbCol = new DataGridTextBoxColumn();
				tbCol.Format = "#,##0.0000";
				tbCol.FormatInfo = null;
				tbCol.MappingName = tbCol.HeaderText = this.dtCurr.Columns[i].ColumnName;
				tbCol.ReadOnly = false;
				tbCol.Alignment = HorizontalAlignment.Right;
				tbCol.Width = 50;	
				tbCol.NullText = "-";
				tbCol.TextBox.Leave += new System.EventHandler(this.Col_Leave);
				tbCol.TextBox.Enter += new System.EventHandler(this.Col_Enter);
				this.dataGridTableStyle1.GridColumnStyles.Add(tbCol);
			}
		}
		private void Col_Leave(object sender, System.EventArgs e)
		{
			
		}
		private void Col_Enter(object sender, System.EventArgs e)
		{
			if((this.dataGridV1.CurrentCell.ColumnNumber-1) == this.dataGridV1.CurrentCell.RowNumber)
			{
				((DataGridTextBox)sender).ReadOnly = true;
			}
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (this.toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					this.saveChange();
					//addCurr();
					break;
				case 1:
					this.fillTableHistory();
					//editCurr();
					break;
				case 2:
					//ExelComp ec = new ExelComp();
					//ec.ExportFromDV(this.dataView1, this.dataGridTableStyle1.GridColumnStyles);
					break;
				case 4:
					
					break;
			}
		}
		private void addCurr()
		{
			/*AddRate ar = new AddRate();
			ar.ShowDialog();
			if(ar.DialogResult == DialogResult.OK)*/
			{
				/*BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow rw = (BPS.BLL.Currency.DataSets.dsCurrHistory.CurrenciesHistoryRow) this.dataView1.Table.NewRow();
				rw.BaseCurrencyID = ar.cmbBaseCurr.Text;
				rw.CurrDate = ar.dtpDate.Value;
				rw.CurrencyName = "111";
				rw.CurrencyID = ar.cmbCurr.Text;
				rw.CurrRate = ar.tbRate.dValue;
				this.dataView1.Table.Rows.Add((DataRow) rw);
				this.UpdateRate(true);*/
			}
		}

		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
		{
			this.fillTableHistory();
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.checkBox1.Checked)
				this.dataGridV1.ReadOnly = true;
			else
				this.dataGridV1.ReadOnly = false;
		}
	}
}
