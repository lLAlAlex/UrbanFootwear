using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear.Repository;

namespace UrbanFootwear.Handler
{
    public class FootwearHandler
    {
        public static List<Footwear> GetFootwears()
        {
            return FootwearRepository.GetFootwears();
        }
        public static int InsertFootwear(string name, string brand, string description, int price, int stock, HttpPostedFile image)
        {
            return FootwearRepository.InsertFootwear(name, brand, description, price, stock, image);
        }
        public static int UpdateFootwear(int id, string name, string brand, string description, int price, int stock, HttpPostedFile image)
        {
            return FootwearRepository.UpdateFootwear(id, name, brand, description, price, stock, image);
        }
        public static Boolean DeleteFootwear(int id)
        {
            return FootwearRepository.DeleteFootwear(id);
        }
        public static Footwear FindFootwear(int id)
        {
            return FootwearRepository.FindFootwear(id);
        }
    }
}