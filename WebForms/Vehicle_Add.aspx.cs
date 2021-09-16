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
    public partial class Vehicle_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vehicles.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Vehicle v = new Vehicle();

            v.Make = txtMake.Text;
            v.VehicleType = txtVehicleType.Text;
            v.FirstRegistration = int.Parse(txtFirstRegistration.Text);
            v.Mileage = int.Parse(txtMileage.Text);

            SqlHandler.AddVehicle(v);

            Response.Redirect("~/Vehicles.aspx");
        }
    }
}