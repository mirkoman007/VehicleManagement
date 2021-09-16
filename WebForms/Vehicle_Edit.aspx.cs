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
    public partial class Vehicle_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var id = Request.QueryString["id"];
            if (id == null) Response.Redirect("~/Vehicles.aspx");

            if (!IsPostBack)
                BindData(int.Parse(id));

        }

        private void BindData(int id)
        {
            Vehicle v = SqlHandler.GetVehicle(id);

            vehicleEditTitle.InnerHtml = $"{v.Make} – vehicle edit";

            txtMake.Text = v.Make;
            txtVehicleType.Text = v.VehicleType;
            txtFirstRegistration.Text = v.FirstRegistration.ToString();
            txtMileage.Text = v.Mileage.ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vehicles.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Vehicle v = new Vehicle();

            v.IDVehicle = int.Parse(Request.QueryString["id"]);
            v.Make = txtMake.Text;
            v.VehicleType = txtVehicleType.Text;
            v.FirstRegistration = int.Parse(txtFirstRegistration.Text);
            v.Mileage = int.Parse(txtMileage.Text);

            SqlHandler.UpdateVehicle(v);
            Response.Redirect("~/Vehicles.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlHandler.DeleteVehicle(int.Parse(Request.QueryString["id"]));
            Response.Redirect("~/Vehicles.aspx");

        }
    }
}