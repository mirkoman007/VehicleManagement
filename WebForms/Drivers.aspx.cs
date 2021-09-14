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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RepeaterDataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            RepeaterDataBind();

        }

        private void RepeaterDataBind()
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


    }
}