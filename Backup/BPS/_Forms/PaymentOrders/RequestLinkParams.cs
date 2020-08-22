using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for RequestLinkParams.
	/// </summary>
	public class RequestLinkParams : System.Windows.Forms.Form
	{
		private AM_Controls.TextBoxV tbvPercent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RequestLinkParams(_Forms.dsRequestsNotLinked.GetRequestsNotLinkedRow rwRequest)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.getServiceCharge(rwRequest);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RequestLinkParams));
			this.tbvPercent = new AM_Controls.TextBoxV();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbvPercent
			// 
			this.tbvPercent.dValue = 0;
			this.tbvPercent.IsPcnt = true;
			this.tbvPercent.Location = new System.Drawing.Point(146, 14);
			this.tbvPercent.MaxDecPos = 2;
			this.tbvPercent.MaxPos = 4;
			this.tbvPercent.Name = "tbvPercent";
			this.tbvPercent.nValue = ((long)(0));
			this.tbvPercent.Size = new System.Drawing.Size(72, 20);
			this.tbvPercent.TabIndex = 0;
			this.tbvPercent.Text = "0";
			this.tbvPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Процент обслуживания:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(42, 96);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(70, 20);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "ОК";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(114, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(70, 20);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// RequestLinkParams
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(228, 119);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnOK,
																		  this.label1,
																		  this.tbvPercent,
																		  this.btnCancel});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RequestLinkParams";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Параметры Связывания";
			this.ResumeLayout(false);

		}
		#endregion
		private void getServiceCharge(_Forms.dsRequestsNotLinked.GetRequestsNotLinkedRow rwRequest)
		{
			SqlCommand cmdGetServiceCharge = new SqlCommand("[GetServiceChargeForLinked]", App.Connection);
			cmdGetServiceCharge.CommandType = CommandType.StoredProcedure;
		//	cmdGetServiceCharge.Parameters.Add(new SqlParameter("@RequestID", SqlDbType.Int));
		//	cmdGetServiceCharge.Parameters.Add(new SqlParameter("@RequestTypeID", SqlDbType.Int));
			cmdGetServiceCharge.Parameters.Add(new SqlParameter("@ClientID",SqlDbType.Int));
			//cmdGetServiceCharge.Parameters.Add(new SqlParameter("@Account", SqlDbType.NVarChar));
			cmdGetServiceCharge.Parameters.Add(new SqlParameter("@OrgINN", SqlDbType.NVarChar));
			cmdGetServiceCharge.Parameters.Add(new SqlParameter("@ServiceCharge", SqlDbType.Float));
			cmdGetServiceCharge.Parameters["@ServiceCharge"].Direction = ParameterDirection.Output;
			if(rwRequest.RequestTypeID != 1)
				return;
			cmdGetServiceCharge.Parameters["@ClientID"].Value = rwRequest.ClientID;
			//cmdGetServiceCharge.Parameters["@Account"].Value = rwRequest.AccountTo;
			cmdGetServiceCharge.Parameters["@OrgINN"].Value = rwRequest.OrgToINN;
			App.Connection.Open();
			try
			{
				cmdGetServiceCharge.ExecuteNonQuery();
				object o = cmdGetServiceCharge.Parameters["@ServiceCharge"].Value;
				if((o != Convert.DBNull) && (Convert.ToDouble(o)!=-1d))
					this.tbvPercent.dValue = Convert.ToDouble(o);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				App.Connection.Close();
			}

	}
	private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();		
		}

		public double PercentValue
		{
			set 
			{
				this.tbvPercent.dValue =value;
			}
			get 
			{
				return this.tbvPercent.dValue;
			}
		}
	
	
	}
}
