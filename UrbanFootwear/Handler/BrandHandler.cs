using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear.Repository;

namespace UrbanFootwear.Handler
{
    public class BrandHandler
    {
        public static List<Brand> GetBrands()
        {
            return BrandRepository.GetBrands();
        }
        public static Brand FindBrand(int brandID)
        {
            return BrandRepository.FindBrand(brandID);
        }
    }
}