using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear.Handler;

namespace UrbanFootwear.Controller
{
    public class BrandController
    {
        public static List<Brand> GetBrands()
        {
            return BrandHandler.GetBrands();
        }
        public static Brand FindBrand(int brandID)
        {
            return BrandHandler.FindBrand(brandID);
        }
    }
}