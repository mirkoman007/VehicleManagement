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
    public partial class Drivers : System.Web.UI.Page
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const string SELECT_DRIVERS = "use VehicleManagement select * from Driver";
        private const string DELETE_DRIVER = "use VehicleManagement delete from Driver where IDDriver=";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            BindData();

        }

        private void BindData()
        {
            driverRepeater.DataSource = GetDrivers();
            driverRepeater.DataBind();
        }

        private IEnumerable<Driver> GetDrivers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SELECT_DRIVERS, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            yield return new Driver
                            {
                                IDDriver=(int)dr[0],
                                FirstName=dr[1].ToString(),
                                LastName = dr[2].ToString(),
                                MobileNumber = dr[3].ToString(),
                                DriverLicenseNumber = dr[4].ToString()
                            };
                        }
                    }

                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var driverId= int.Parse(btn.CommandArgument);

            Response.Redirect($"~/Driver_Edit.aspx?id={driverId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var driverId = int.Parse(btn.CommandArgument);


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(DELETE_DRIVER + driverId.ToString(), con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Drivers.aspx");

        }
    }
}