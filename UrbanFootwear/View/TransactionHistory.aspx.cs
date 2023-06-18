
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbanFootwear.Controller;

namespace UrbanFootwear.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        Customer customer;
        public List<TransactionHeader> trans;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = ((Customer)Session["customer"]);
            if (customer == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            if (!customer.CustomerRole.Equals("user"))
            {
                Response.Redirect("~/View/Home.aspx");
            }

            trans = TransactionController.getUserTransaction(customer.CustomerID);
        }
    }
}