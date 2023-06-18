using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear;
using UrbanFootwear.Factory;

namespace UrbanFootwear.Repository
{
    public class CartRepository
    {
        static DBE db = new DBE();

        public static Cart checkCartItem(int customerId, int FootwearId)
        {
            return (from c in db.Carts where c.CustomerID == customerId && c.FootwearID == FootwearId select c).FirstOrDefault();
        }
        public static Cart addItemToCart(int customerId, int FootwearId, int qty)
        {
            Cart c = CartFactory.createItem(customerId, FootwearId, qty);
            db.Carts.Add(c);
            db.SaveChanges();

            return c;
        }
        public static Cart updateCartItem(int customerId, int FootwearId, int qty)
        {
            Cart item = (from c in db.Carts where c.CustomerID == customerId && c.FootwearID == FootwearId select c).FirstOrDefault();
            item.Qty = qty;
            db.SaveChanges();

            return item;
        }
        public static List<Cart> getCartByCustomerId(int userId)
        {
            return (from c in db.Carts where c.CustomerID == userId select c).ToList();
        }

        public static Cart removeItemFromCart(int userId, int FootwearId)
        {
            Cart item =  (from c in db.Carts where c.CustomerID == userId && c.FootwearID == FootwearId select c).FirstOrDefault();
            db.Carts.Remove(item);
            db.SaveChanges();

            return item;
        }
    }
}