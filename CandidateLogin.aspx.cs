using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DeloitteCandidateStatus
{
	public partial class CandidateLogin : System.Web.UI.Page
	{
		readonly string connection = System.Configuration.ConfigurationManager.ConnectionStrings["CandidateDB"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		private void  ValidateUser()
		{
			bool Login = false ;
			try
			{
				SqlConnection con = new SqlConnection(connection);
				con.Open();
				SqlCommand cmd = new SqlCommand("Select * from [dbo].[CandidateLogin] where UserName ='" + txtUserName.Text + "'and Password ='" + txtPassword.Text + "'");
				cmd.Connection = con;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					if (chkRememberMe.Checked)
					{
						Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
						Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
					}
					
					
					Response.Cookies["UserName"].Value = txtUserName.Text;
					Response.Cookies["Password"].Value = txtPassword.Text;
					Login = true;
					
				}
				else
				{
					MessageBox.Show("Invalid Login please check username and password");
					txtUserName.Text = "";
					txtPassword.Text = "";
					Login = false;
				}
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				// to close connections and pools
			}
			if (Login)
			{
				Response.Redirect("CandidateDashboard.aspx");
			}
		}

		protected void Submit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				ValidateUser();
			}
		}
	}
}