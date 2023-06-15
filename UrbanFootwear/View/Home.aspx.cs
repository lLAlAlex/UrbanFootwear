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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Footwear> footwears = FootwearController.GetFootwears();

                footwearRepeater.DataSource = footwears;
                footwearRepeater.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertFootwear.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int footwearId = Convert.ToInt32(btnDelete.CommandArgument);

            if (FootwearController.DeleteFootwear(footwearId))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}