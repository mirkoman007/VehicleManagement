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
    public partial class Drivers : System.Web.UI.Page
    {
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
            driverRepeater.DataSource = SqlHandler.GetDrivers();
            driverRepeater.DataBind();
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
            var idDriver = int.Parse(btn.CommandArgument);


            SqlHandler.DeleteDriver(idDriver);
            Response.Redirect("Drivers.aspx");

        }
    }
}