using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BPS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class RepPreview : System.Windows.Forms.Form
	{
		public CrystalDecisions.Windows.Forms.CrystalReportViewer crv;

		private int ZoomLevel=100;
		private RepDoc rpt;

		public RepDoc Report {get { return rpt;} }
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
		private System.Windows.Forms.PrintDialog printDialog1;
		private string ReportSourceFileName;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RepPreview(string ReportSource, string SelectionFormula)
		{
			ReportSourceFileName = ReportSource;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			rpt = new RepDoc(ReportSource,SelectionFormula);
		}
		public RepPreview()
		{
			InitializeComponent();
		}
		new public DialogResult ShowDialog()
		{
			if(!rpt.IsLoaded)
				if (!rpt.Load())
					return DialogResult.Cancel;
			this.Text+= " - " + rpt.SummaryInfo.ReportTitle;
			this.crv.ReportSource = rpt;
			return base.ShowDialog();
		}

		public DialogResult ShowDialog(RepDoc repDoc)
		{
			rpt=repDoc;
			this.Text+= " - " + rpt.SummaryInfo.ReportTitle;
			this.crv.ReportSource = rpt;
			return base.ShowDialog();
		}
		new public void Show()
		{
			if(!rpt.IsLoaded)
				if (!rpt.Load())
					return;
			this.Text+= " - " + rpt.SummaryInfo.ReportTitle;
			this.crv.ReportSource = rpt;
			base.Show();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RepPreview));
			this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.button1 = new System.Windows.Forms.Button();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.SuspendLayout();
			// 
			// crv
			// 
			this.crv.ActiveViewIndex = -1;
			this.crv.DisplayBackgroundEdge = false;
			this.crv.DisplayGroupTree = false;
			this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.crv.Name = "crv";
			this.crv.ReportSource = "";
			this.crv.ShowExportButton = false;
			this.crv.Size = new System.Drawing.Size(416, 281);
			this.crv.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(314, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Выбор принтера";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// RepPreview
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(416, 281);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.crv});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "RepPreview";
			this.ShowInTaskbar = true;
			this.Text = "Предварительный просмотр документа";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RepPreview_KeyDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{

			PageSettings pgd = new PageSettings();
			PrinterSettings prs = new PrinterSettings ();
			

			this.pageSetupDialog1.PageSettings = pgd;
			this.pageSetupDialog1.PrinterSettings = prs;
			
			printDialog1.PrinterSettings = prs;
			printDialog1.AllowSelection =  false;
			printDialog1.AllowSomePages =  false;
			printDialog1.ShowHelp = false;
			
			prs.PrinterName = prs.PrinterName;
			if (printDialog1.ShowDialog()== DialogResult.OK) 
			{
				rpt.PrintOptions.PrinterName = prs.PrinterName;
				//				rpt.SaveAs(ReportSourceFileName+"2" ,ReportFileFormat.VSNetFileFormat);
			}


			//			if ( this.pageSetupDialog1.ShowDialog() == DialogResult.OK) 
		{

				
		}

			//	printDialog1.PrinterSettings = new 

		}
		
		private void RepPreview_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.PageDown)
				crv.ShowNextPage();
			else if (e.KeyData == Keys.PageUp)
				crv.ShowPreviousPage();
			else if (e.KeyData == Keys.Multiply)
				crv.Zoom(2);
			else if (e.KeyData == Keys.Add)
				crv.Zoom(ZoomLevel+=25);
			else if (e.KeyData == Keys.Subtract)
				crv.Zoom(ZoomLevel-=25);
			else if (e.KeyData == Keys.Escape)
				this.Close();
			else if (e.KeyData == Keys.Enter)
				rpt.Print();
		}
	}

	public class RepPrint : object
	{
		private ReportDocument rpt;
		public RepPrint(string ReportSource, string SelectionFormula)
		{
			rpt = new ReportDocument();
			rpt.Load(ReportSource);
			rpt.DataDefinition.RecordSelectionFormula = SelectionFormula;
			rpt.PrintToPrinter(1,false,0,0);
		}
	}
	

	public class RepDoc : CrystalDecisions.CrystalReports.Engine.ReportDocument
	{
		private string szReportFileName, szSelectionFormula;
		private static string szReportsDirectory;
		public static string ReportsDirectory 
		{ 
			set 
			{
				szReportsDirectory = value;
				if (szReportsDirectory.Length>0 && szReportsDirectory[szReportsDirectory.Length-1]!='\\')
					szReportsDirectory+='\\';
			}
			get {return szReportsDirectory;}
		}


		public RepDoc ()
		{
			szReportsDirectory = "";
			szReportFileName = "";
			szSelectionFormula="";
		}

		public RepDoc (string ReportFileName, string SelectionFormula)
		{
			szReportFileName = ReportFileName;
			szSelectionFormula=SelectionFormula;
		}
		
		new public bool Load(string ReportFileName)
		{
			szReportFileName = ReportFileName;
			szSelectionFormula="";
			return this.Load();
		}

		public bool Load(string ReportFileName, string SelectionFormula)
		{
			szReportFileName = ReportFileName;
			szSelectionFormula=SelectionFormula;
			return this.Load();
		}
		//
		public bool LoadForDataSet(string ReportFileName)
		{
			szReportFileName = ReportFileName;
			try
			{
				base.Load(App.ReportsDirectory+szReportFileName);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке отчета:\n" +ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			
		}
		//
		public bool Load()
		{
			Cursor.Current = Cursors.WaitCursor;
			try 
			{
				base.Load(App.ReportsDirectory+szReportFileName);
				foreach ( CrystalDecisions.CrystalReports.Engine.Table tb in this.Database.Tables) 
				{
					tb.Location= App.DBSource;
				}
				foreach ( CrystalDecisions.CrystalReports.Engine.TableLink tbl in this.Database.Links) 
				{
					tbl.SourceTable.Location= App.DBSource;
				}
				this.DataDefinition.RecordSelectionFormula = szSelectionFormula;
				return true;
			}
		
			catch (Exception ex)
			{
				Cursor.Current = Cursors.Default;
				MessageBox.Show("Ошибка при загрузке отчета:\n" +ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
		
		public bool Print(int nCopies)
		{
			if (!this.Load()) 
				return false;
			PrintToPrinter(nCopies,false,0,0);
			return true;
		}

		public bool Print()
		{
			return this.Print(1);
		}
	}

}