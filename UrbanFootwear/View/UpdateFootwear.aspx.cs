using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbanFootwear.Controller;

namespace UrbanFootwear.View
{
    public partial class UpdateFootwear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FootwearId"] != null)
                {
                    List<Brand> brands = BrandController.GetBrands();

                    foreach (Brand br in brands)
                    {
                        footwearBrand.Items.Add(new ListItem(br.BrandName, br.BrandName));
                    }

                    int id = Convert.ToInt32(Request.QueryString["FootwearId"]);

                    Footwear footwear = FootwearController.FindFootwear(id);
                    Brand brand = BrandController.FindBrand(footwear.BrandID);

                    footwearName.Value = footwear.FootwearName;
                    footwearBrand.SelectedValue = brand.BrandName;
                    footwearDescription.Value = footwear.FootwearDescription;
                    footwearPrice.Value = footwear.FootwearPrice.ToString();
                    footwearStock.Value = footwear.FootwearStock.ToString();
                    fileNameLabel.Text = footwear.FootwearImage;
                }
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int price;
            int stock;
            int id = Convert.ToInt32(Request.QueryString["FootwearId"]);

            if (!int.TryParse(footwearPrice.Value, out price))
            {
                price = 0;
            }
            if (!int.TryParse(footwearStock.Value, out stock))
            {
                stock = 0;
            }

            int check = FootwearController.UpdateAlbum(id, footwearName.Value, footwearBrand.SelectedValue, footwearDescription.Value, price, stock, footwearImage.PostedFile);

            if (check == 1)
            {
                updateError.Text = "Name must be filled and less than 50 characters";
            }
            else if (check == 2)
            {
                updateError.Text = "Brand must be chosen";
            }
            else if (check == 3)
            {
                updateError.Text = "Description must be filled and less than 255 characters";
            }
            else if (check == 4)
            {
                updateError.Text = "Price must be more than 100000";
            }
            else if (check == 5)
            {
                updateError.Text = "Stock must be filled and more than 0";
            }
            else if (check == 6)
            {
                updateError.Text = "Image file must be chosen, have the correct extension (.png, .jpg, .jpeg, .jfif) and must be lower than 2 MB";
            }
            else
            {
                Response.Redirect("Home.aspx");
                return;
            }
        }
    }
}