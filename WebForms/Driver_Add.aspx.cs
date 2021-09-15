using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Dao;
using WebForms.Models;

namespace WebForms
{
    public partial class Driver_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Drivers.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Driver d = new Driver();

            d.FirstName = txtFirstName.Text;
            d.LastName = txtLastName.Text;
            d.MobileNumber = txtMobileNumber.Text;
            d.DriverLicenseNumber = txtDriverLicenseNumber.Text;


            SqlHandler.AddDriver(d);
            Response.Redirect("~/Drivers.aspx");
        }
    }
}