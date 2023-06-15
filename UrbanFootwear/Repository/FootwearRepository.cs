using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using UrbanFootwear.Factory;

namespace UrbanFootwear.Repository
{
    public class FootwearRepository
    {
        public static List<Footwear> GetFootwears()
        {
            DBE db = new DBE();
            List<Footwear> footwears = (from f in db.Footwears select f).ToList();
            return footwears;
        }
        public static int InsertFootwear(string name, string brand, string description, int price, int stock, HttpPostedFile image)
        {
            DBE db = new DBE();

            string imageName = image.FileName;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
            string filePath = GetServerRelativePath("~/Assets/Footwears/" + fileName);
            image.SaveAs(filePath);

            Brand brandObject = db.Brands.FirstOrDefault(b => b.BrandName == brand);

            Footwear f = FootwearFactory.createFootwear(name, brandObject.BrandID, description, price, stock, fileName);

            db.Footwears.Add(f);
            db.SaveChanges();

            return 0;
        }
        public static int UpdateFootwear(int id, string name, string brand, string description, int price, int stock, HttpPostedFile image)
        {
            string updatedImage = null;
            string updatedFileName = null;

            using (DBE db = new DBE())
            {
                Footwear footwear = db.Footwears.FirstOrDefault(f => f.FootwearID == id);
                Brand brandObject = db.Brands.FirstOrDefault(b => b.BrandName == brand);

                if (footwear != null)
                {
                    footwear.FootwearName = name;
                    footwear.BrandID = brandObject.BrandID;
                    footwear.FootwearDescription = description;
                    footwear.FootwearPrice = price;
                    footwear.FootwearStock = stock;

                    if (image != null && image.ContentLength > 0)
                    {
                        updatedFileName = Path.GetFileName(image.FileName);
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedFileName);
                        string filePath = GetServerRelativePath("~/Assets/Footwears/" + fileName);
                        image.SaveAs(filePath);
                        updatedImage = fileName;
                    }
                    else
                    {
                        updatedFileName = Path.GetFileName(image.FileName);
                        updatedImage = updatedFileName;
                    }

                    if (!string.IsNullOrEmpty(updatedImage))
                    {
                        footwear.FootwearImage = updatedImage;
                    }
                    db.SaveChanges();
                }
            }
            return 0;
        }
        private static string GetServerRelativePath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
        public static Boolean DeleteFootwear(int id)
        {
            using (DBE db = new DBE())
            {
                var footwear = db.Footwears.FirstOrDefault(f => f.FootwearID == id);

                if (footwear != null)
                {
                    db.Footwears.Remove(footwear);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static Footwear FindFootwear(int id)
        {
            DBE db = new DBE();
            Footwear footwear = db.Footwears.FirstOrDefault(f => f.FootwearID == id);
            return footwear;
        }
    }
}