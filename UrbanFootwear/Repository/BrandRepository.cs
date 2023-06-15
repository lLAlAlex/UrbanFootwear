using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrbanFootwear.Repository
{
    public class BrandRepository
    {
        public static List<Brand> GetBrands()
        {
            DBE db = new DBE();
            List<Brand> brands = (from b in db.Brands select b).ToList();
            return brands;
        }
        public static Brand FindBrand(int brandID)
        {
            DBE db = new DBE();
            Brand brand = db.Brands.FirstOrDefault(b => b.BrandID == brandID); ;
            return brand;
        }
    }
}