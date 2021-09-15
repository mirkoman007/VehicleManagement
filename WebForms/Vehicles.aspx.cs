using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Dao;

namespace WebForms
{
    public partial class Vehicles : System.Web.UI.Page
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
            vehicleRepeater.DataSource = SqlHandler.GetVehicles();
            vehicleRepeater.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            var btn = sender as Button;
            var vehicleId = int.Parse(btn.CommandArgument);

            Response.Redirect($"~/Vehicle_Edit.aspx?id={vehicleId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Vehicle_Add.aspx");
        }
    }
}