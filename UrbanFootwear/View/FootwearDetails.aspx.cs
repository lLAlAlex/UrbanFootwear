using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbanFootwear.Controller;

namespace UrbanFootwear.View
{
    public partial class FootwearDetails : System.Web.UI.Page
    {
        public Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);
            if (customer == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }

            if (!IsPostBack)
            {
                // manual artistID and albumID
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
                int id = Convert.ToInt32(Request.QueryString["id"]);

                Footwear currShoe = FootwearController.FindFootwear(id);
                AlbName.Text = currShoe.FootwearName;
                AlbImage.ImageUrl = ResolveUrl("~/Assets/Footwears/" + currShoe.FootwearImage);
                AlbDesc.Text = currShoe.FootwearDescription;
                AlbPrice.Text = Convert.ToString(currShoe.FootwearPrice);
                AlbStock.Text = Convert.ToString(currShoe.FootwearStock);
            }
        }

        public string ErrorMessage
        {
            get { return lblError.Text; }
            set
            {
                lblError.Text = value;

                // Show Error Alert
                if (!string.IsNullOrEmpty(lblError.Text))
                {
                    alert.Style.Remove("display");
                }
                else
                {
                    alert.Style.Add("display", "none");
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (CartController.validateFootwear(this, customer.CustomerID, Request.QueryString["id"], tbQuantity.Text))
            {
                Response.Redirect("~/View/MyCart.aspx");
            }
        }
    }

}