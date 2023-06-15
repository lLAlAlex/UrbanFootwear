using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbanFootwear.Controller;

namespace UrbanFootwear.View
{
    public partial class InsertFootwear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Brand> brands = BrandController.GetBrands();

                foreach(Brand brand in brands)
                {
                    footwearBrand.Items.Add(new ListItem(brand.BrandName, brand.BrandName));
                }
            }
        }

        protected void insertButton_Click(object sender, EventArgs e)
        {
            int price;
            int stock;

            if (!int.TryParse(footwearPrice.Value, out price))
            {
                price = 0;
            }
            if (!int.TryParse(footwearStock.Value, out stock))
            {
                stock = 0;
            }

            int check = FootwearController.InsertAlbum(footwearName.Value, footwearBrand.SelectedValue, footwearDescription.Value, price, stock, footwearImage.PostedFile);

            if (check == 1)
            {
                insertError.Text = "Name must be filled and less than 50 characters";
            }
            else if(check == 2)
            {
                insertError.Text = "Brand must be chosen";
            }
            else if (check == 3)
            {
                insertError.Text = "Description must be filled and less than 255 characters";
            }
            else if (check == 4)
            {
                insertError.Text = "Price must be more than 100000";
            }
            else if (check == 5)
            {
                insertError.Text = "Stock must be filled and more than 0";
            }
            else if (check == 6)
            {
                insertError.Text = "Image file must be chosen, have the correct extension (.png, .jpg, .jpeg, .jfif) and must be lower than 2 MB";
            }
            else
            {
                Response.Redirect("Home.aspx");
                return;
            }
        }
    }
}