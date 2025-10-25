using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudApp
{
    public partial class MainPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }
        void BindGridView()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UserDetails", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GrdView1.DataSource = dt;
            GrdView1.DataBind();
        }
        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtroll.Text != "")
            {
                //string querry= "INSERT INTO UserDetails (Name, RollNumber) VALUES ("+ "'" + txtname.Text + "'," + "'" + txtroll.Text + "')";
                //SqlCommand cmd = new SqlCommand(querry, conn);
                SqlCommand cmd = new SqlCommand("INSERT INTO UserDetails (username, rollno,marks) VALUES (@Name, @RollNumber,@marks)", conn);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtroll.Text);
                cmd.Parameters.AddWithValue("@marks", txtmark.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                txtname.Text = "";
                txtroll.Text = "";
                txtmark.Text = "";
                BindGridView();
            }
        }

        protected void GrdView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GrdView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int roll = Convert.ToInt32(GrdView1.Rows[e.RowIndex].Cells[0].Text);
            string name = ((TextBox)GrdView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int mark = Convert.ToInt32(((TextBox)GrdView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text);//controls[0] because textbox is the first control in the cell-- also
            //to make sure it is integer we are converting it to int32
            SqlCommand cmd = new SqlCommand("UPDATE UserDetails SET username=@Name,marks=@marks WHERE rollno=@RollNumber", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@marks", mark);
            cmd.Parameters.AddWithValue("@RollNumber", roll);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            GrdView1.EditIndex = -1;
            BindGridView();

        }

        protected void GrdView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int roll = Convert.ToInt32(GrdView1.Rows[e.RowIndex].Cells[0].Text);
            SqlCommand cmd = new SqlCommand("DELETE FROM UserDetails WHERE rollno=@RollNumber", conn);  
            cmd.Parameters.AddWithValue("@RollNumber", roll);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            BindGridView();
        }

        protected void GrdView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdView1.EditIndex = -1;
            BindGridView();
        }
    }
}