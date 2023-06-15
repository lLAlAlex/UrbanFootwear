using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using UrbanFootwear.Handler;

namespace UrbanFootwear.Controller
{
    public class FootwearController
    {
        public static List<Footwear> GetFootwears()
        {
            return FootwearHandler.GetFootwears();
        }
        public static int InsertAlbum(string name, string brand, string description, int price, int stock, HttpPostedFile image)
        {
            string fileExtension = Path.GetExtension(image.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxFileSize = 2 * 1024 * 1024;

            if (name.Length <= 0 || name.Length >= 50)
            {
                return 1;
            }
            else if(brand.Length <= 0)
            {
                return 2;
            }
            else if (description.Length <= 0 || name.Length >= 255)
            {
                return 3;
            }
            else if (price < 100000)
            {
                return 4;
            }
            else if (stock <= 0)
            {
                return 5;
            }
            else if (!(allowedExtensions.Contains(fileExtension) && image.ContentLength <= maxFileSize))
            {
                return 6;
            }
            return FootwearHandler.InsertFootwear(name, brand, description, price, stock, image);
        }
        public static int UpdateAlbum(int id, string name, string brand, string description, int price, int stock, HttpPostedFile image)
        {
            string fileExtension = Path.GetExtension(image.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxFileSize = 2 * 1024 * 1024;

            if (name.Length <= 0 || name.Length >= 50)
            {
                return 1;
            }
            else if (brand.Length <= 0)
            {
                return 2;
            }
            else if (description.Length <= 0 || name.Length >= 255)
            {
                return 3;
            }
            else if (price < 100000)
            {
                return 4;
            }
            else if (stock <= 0)
            {
                return 5;
            }
            else if (!(allowedExtensions.Contains(fileExtension) && image.ContentLength <= maxFileSize))
            {
                return 6;
            }
            return FootwearHandler.UpdateFootwear(id, name, brand, description, price, stock, image);
        }
        public static Boolean DeleteFootwear(int id)
        {
            return FootwearHandler.DeleteFootwear(id);
        }
        public static Footwear FindFootwear(int id)
        {
            return FootwearHandler.FindFootwear(id);
        }
    }
}