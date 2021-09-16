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
    public partial class Driver_Edit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            var id = Request.QueryString["id"];
            if (id == null) Response.Redirect("~/Drivers.aspx");

            if (!IsPostBack)
                BindData(int.Parse(id));
        }


        private void BindData(int id)
        {
            Driver d = SqlHandler.GetDriver(id);

            driverEditTitle.InnerHtml = $"{d.FirstName} {d.LastName} – driver edit";

            txtFirstName.Text = d.FirstName;
            txtLastName.Text = d.LastName;
            txtMobileNumber.Text = d.MobileNumber;
            txtDriverLicenseNumber.Text = d.DriverLicenseNumber;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Drivers.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Driver d = new Driver();

            d.IDDriver = int.Parse(Request.QueryString["id"]);
            d.FirstName = txtFirstName.Text;
            d.LastName = txtLastName.Text;
            d.MobileNumber = txtMobileNumber.Text;
            d.DriverLicenseNumber = txtDriverLicenseNumber.Text;

            SqlHandler.UpdateDriver(d);
            Response.Redirect("~/Drivers.aspx");


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlHandler.DeleteDriver(int.Parse(Request.QueryString["id"]));
            Response.Redirect("~/Drivers.aspx");
        }
    }
}