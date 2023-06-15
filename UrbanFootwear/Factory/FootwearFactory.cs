using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrbanFootwear.Factory
{
    public class FootwearFactory
    {
        public static Footwear createFootwear(String name, int brand, String description, int price, int stock, String image)
        {
            Footwear f = new Footwear();

            f.FootwearName = name;
            f.BrandID = brand;
            f.FootwearDescription = description;
            f.FootwearPrice = price;
            f.FootwearStock = stock;
            f.FootwearImage = image;

            return f;
        }
    }
}