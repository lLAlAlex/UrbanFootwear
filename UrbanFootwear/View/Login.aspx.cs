using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbanFootwear.Controller;

namespace UrbanFootwear.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the RememberMe cookie exists
                if (Request.Cookies["RememberMe"] != null)
                {
                    HttpCookie cookie = Request.Cookies["RememberMe"];

                    string email = cookie.Values["Email"];
                    string password = cookie.Values["Password"];

                    tbEmail.Text = email;
                    tbPassword.Text = password;
                    cbRemember.Checked = true;
                }
            }
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;

            if (!CustomerController.Login(email, password))
            {
                lblError.Text = "Incorrect Credentials!";
                return;
            }
            DBE db = new DBE();

            Customer user = (from u in db.Customers where u.CustomerEmail.Equals(email) && u.CustomerPassword.Equals(password) select u).FirstOrDefault();

            if (user != null)
            {
                if (cbRemember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("RememberMe");
                    cookie.Values["Email"] = email;
                    cookie.Values["Password"] = password;
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    if (Request.Cookies["RememberMe"] != null)
                    {
                        HttpCookie cookie = new HttpCookie("RememberMe");
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                }
                Session["customer"] = user;
            }
            Response.Redirect("~/View/Home.aspx");
            return;
        }
    }
}