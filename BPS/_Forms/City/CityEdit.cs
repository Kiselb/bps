using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS.Forms.City
{
	/// <summary>
	/// Summary description for CityEdit.
	/// </summary>
	public class CityEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCityName;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private BPS.BLL.City.coCities BPSCity;
		private int NewID = 0;
		private bool AddNewCity = true;

		public string strCityName
		{
			get
			{
				return tbCityName.Text;
			}
		}

		public int NewCityID
		{
			get
			{
				return NewID;
			}
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public CityEdit(BPS.BLL.City.coCities Cities, string CityName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			if(CityName != null)
			{
				this.tbCityName.Text = CityName;
				AddNewCity = false;

			}
			this.BPSCity = Cities;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CityEdit));
			this.label1 = new System.Windows.Forms.Label();
			this.tbCityName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Название:";
			// 
			// tbCityName
			// 
			this.tbCityName.Location = new System.Drawing.Point(78, 10);
			this.tbCityName.Name = "tbCityName";
			this.tbCityName.Size = new System.Drawing.Size(188, 21);
			this.tbCityName.TabIndex = 1;
			this.tbCityName.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnSave.Location = new System.Drawing.Point(102, 54);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnClose.Location = new System.Drawing.Point(188, 54);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(80, 26);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Отменить";
			// 
			// CityEdit
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(276, 87);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tbCityName);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CityEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Город ";
			this.ResumeLayout(false);

		}
		#endregion

		private void trimCity()
		{
			this.tbCityName.Text = this.tbCityName.Text.Trim(new char[]{'"',' ','<','>','\''});
			this.tbCityName.Text = this.tbCityName.Text.TrimStart(new char[]{'"',' ','<','>','\'','.',',','[',']','{','}','(',')',':',';','?','/','!','@','#','$','%','^','&','*'});
			if(this.tbCityName.Text.StartsWith("г.") || this.tbCityName.Text.StartsWith("Г."))
			{
				this.tbCityName.Text = this.tbCityName.Text.Remove(0, 2);
			}
			if(this.tbCityName.Text.StartsWith("город") || this.tbCityName.Text.StartsWith("ГОРОД") || this.tbCityName.Text.StartsWith("Город"))
			{
				this.tbCityName.Text = this.tbCityName.Text.Remove(0, 5);
			}
			this.tbCityName.Text = this.tbCityName.Text.Trim(new char[]{'"',' ','<','>','\''});
			this.tbCityName.Text = this.tbCityName.Text.TrimStart(new char[]{'"',' ','<','>','\'','.',',','[',']','{','}','(',')',':',';','?','/','!','@','#','$','%','^','&','*'});
		}

		private bool validateCity()
		{
			this.trimCity();
			if(this.tbCityName.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Заполните поле НАЗВАНИЕ", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.tbCityName.Focus();
				return false;
			}
			return true;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(!validateCity())
				return;
			if(AddNewCity)
			{
				NewID = BPSCity.AddCity(this.tbCityName.Text);
			}
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
