using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear;
using UrbanFootwear.Handler;
using UrbanFootwear.View;

namespace UrbanFootwear.Controller
{
    public class CartController
    {
        public static bool validateFootwear(FootwearDetails view, int customerId, string FootwearId, string quantity)
        {
            var isFootwearNumeric = int.TryParse(FootwearId, out int Footwear);
            if (!isFootwearNumeric)
            {
                HttpContext.Current.Response.Redirect("~/View/Home.aspx");
                return false;
            }

            var isQtyNumeric = int.TryParse(quantity, out int qty);
            if (!isQtyNumeric)
            {
                view.ErrorMessage = "Quantity must be filled and numeric";
                return false;
            }

            if (qty < 1)
            {
                view.ErrorMessage = "Quantity must more than 0";
                return false;
            }

            if (qty > CartHandler.getFootwearStock(Footwear))
            {
                view.ErrorMessage = "Quantity can’t be more than the stock Footwear";
                return false;
            }

            return CartHandler.addToCart(customerId, Footwear, qty);
        }

        public static List<Cart> getUserCart(int userId)
        {
            return CartHandler.getUserCart(userId);
        }

        public static bool removeItem(int userId, int FootwearId)
        {
            return CartHandler.removeItemFromCart(userId, FootwearId);
        }
    }
}