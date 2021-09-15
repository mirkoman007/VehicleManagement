using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class Driver_Edit : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const string SELECT_DRIVER = "use VehicleManagement select * from Driver where IDDriver=";
        private const string DELETE_DRIVER = "use VehicleManagement delete from Driver where IDDriver=";

        protected void Page_Load(object sender, EventArgs e)
        {

            var id = Request.QueryString["id"];
            if (id == null) Response.Redirect("Drivers.aspx");

            if (!IsPostBack)
                BindData(int.Parse(id));
        }


        private void BindData(int id)
        {
            Driver d = new Driver();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SELECT_DRIVER+id.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            d.IDDriver = (int)dr[0];
                            d.FirstName = dr[1].ToString();
                            d.LastName = dr[2].ToString();
                            d.MobileNumber = dr[3].ToString();
                            d.DriverLicenseNumber = dr[4].ToString();
                        }
                    }

                }
            }
            driverEditTitle.InnerHtml = $"{d.FirstName} {d.LastName} – driver edit";

            txtFirstName.Text = d.FirstName;
            txtLastName.Text = d.LastName;
            txtMobileNumber.Text = d.MobileNumber;
            txtDriverLicenseNumber.Text = d.DriverLicenseNumber;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drivers.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Driver d = new Driver();

            d.IDDriver = int.Parse(Request.QueryString["id"]);
            d.FirstName = txtFirstName.Text;
            d.LastName = txtLastName.Text;
            d.MobileNumber = txtMobileNumber.Text;
            d.DriverLicenseNumber = txtDriverLicenseNumber.Text;


            //===== Unfinished ==========

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(DELETE_DRIVER + Request.QueryString["id"], con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Drivers.aspx");
        }
    }
}