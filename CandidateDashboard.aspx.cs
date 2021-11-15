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
	public partial class CandidateDashboard : System.Web.UI.Page
	{
		readonly string connection = System.Configuration.ConfigurationManager.ConnectionStrings["CandidateDB"].ConnectionString;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.Cookies["UserName"].Value != null)
				{
					lblUser.Text = "Welcome " + Request.Cookies["UserName"].Value + " to Deloitte Dashboard";
				}
				else
				{
					Response.Redirect("CandidateLogin.aspx");
				}
				GetToDoList();
			}

			

		}

		protected void AddTask()
		{
			try
			{
				if (txtList.Text != "")
				{
					SqlConnection con = new SqlConnection(connection);
					con.Open();
					SqlCommand cmd = new SqlCommand("SP_CandidateTask");
					cmd.CommandType = CommandType.StoredProcedure;

					SqlParameter pTask = new SqlParameter("@Task", txtList.Text);
					SqlParameter pDescription = new SqlParameter("@Description", txtDescription.Text);
					SqlParameter pLastUpdated = new SqlParameter("@LastUpdated", DateTime.Now.ToString());
					SqlParameter pUserName = new SqlParameter("@UserName", Request.Cookies["UserName"].Value.ToString());
					SqlParameter pCreatedDate = new SqlParameter("@CreatedDate", DateTime.Now.ToString());

					cmd.Parameters.Add(pTask);
					cmd.Parameters.Add(pDescription);
					cmd.Parameters.Add(pLastUpdated);
					cmd.Parameters.Add(pUserName);
					cmd.Parameters.Add(pCreatedDate);
					cmd.Connection = con;
					cmd.ExecuteNonQuery();
					MessageBox.Show("Task Successfully Added");
					con.Close();
				}
				else
				{
					MessageBox.Show("Please Enter task to add");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				// to close connections and pools
			}
		}

		protected void GetToDoList()
		{
			try
			{
				SqlConnection con = new SqlConnection(connection);
				con.Open();
				SqlCommand cmd = new SqlCommand("SP_GetTaskItems");
				cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pUserName = new SqlParameter("@UserName", Request.Cookies["UserName"].Value);
				cmd.Parameters.Add(pUserName);
				cmd.Connection = con;
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					grvTaskList.DataSource = reader;
					grvTaskList.DataBind();
					btnDelete.Visible = true;
				}
				else
				{
					btnDelete.Visible = false;
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
		}

		protected void btnAddTask_Click(object sender, EventArgs e)
		{
			AddTask();
			GetToDoList();
			txtList.Text = "";
			txtDescription.Text = "";
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow row in grvTaskList.Rows)
			{

				CheckBox chk = (CheckBox)row.FindControl("chkList");
				if (chk != null & chk.Checked)
				{
					
					try
					{
						int id;
						id = int.Parse(row.Cells[1].Text);
						SqlConnection con = new SqlConnection(connection);
						con.Open();
						SqlCommand cmd = new SqlCommand("SP_DeleteTask");
						cmd.CommandType = CommandType.StoredProcedure;
						SqlParameter pTaskId = new SqlParameter("@TaskId", id);
						cmd.Parameters.Add(pTaskId);
						cmd.Connection = con;
						grvTaskList.DataSource = cmd.ExecuteReader();
						grvTaskList.DataBind();
						GetToDoList();
						txtList.Text = "";
						txtDescription.Text = "";
						MessageBox.Show("Task Deleted");
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
				}
				
				
			}
		}

		protected void btnLogOut_Click(object sender, EventArgs e)
		{
			//Session.Clear();
			//Session.Abandon();
			Response.Redirect("CandidateLogin.aspx");
		}
	}
}