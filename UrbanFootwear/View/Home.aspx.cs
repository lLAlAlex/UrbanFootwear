using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbanFootwear.Controller;

namespace UrbanFootwear.View
{
    public partial class Home : System.Web.UI.Page
    {
        public Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                customer = ((Customer)Session["customer"]);


                List<Footwear> footwears = FootwearController.GetFootwears();

                footwearRepeater.DataSource = footwears;
                footwearRepeater.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            LinkButton btnDelete = (LinkButton)sender;
            int footwearId = Convert.ToInt32(btnDelete.CommandArgument);

            if (FootwearController.DeleteFootwear(footwearId))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void footwearRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "detail")
            {
                Response.Redirect("~/View/FootwearDetails.aspx?footwearId=" + id);
            }

            if (e.CommandName == "update")
            {
                Response.Redirect("~/View/UpdateFootwear.aspx?footwearId=" + id);
            }

            if (e.CommandName == "delete")
            {

                if (FootwearController.DeleteFootwear(id))
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
        }


        protected void btnInsertFootwear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertFootwear.aspx");
        }
    }
}