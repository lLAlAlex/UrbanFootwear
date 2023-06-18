using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear.Repository;
using UrbanFootwear;

namespace UrbanFootwear.Handler
{
    public class CartHandler
    {
        public static int getFootwearStock( int FootwearId)
        {
            Footwear Footwear = FootwearRepository.FindFootwear(FootwearId);

            if (Footwear != null)
            {
                return Footwear.FootwearStock;
            }

            return -1;
        }
        public static bool addToCart(int customerId, int FootwearId, int qty)
        {
            if(CartRepository.checkCartItem(customerId, FootwearId) == null)
            {
                if (CartRepository.addItemToCart(customerId, FootwearId, qty) != null)
                {
                    return true;
                }
            } else
            {
                if(CartRepository.updateCartItem(customerId, FootwearId, qty) != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Cart> getUserCart(int userId)
        {
            return CartRepository.getCartByCustomerId(userId);
        }

        public static bool removeItemFromCart(int userId, int FootwearId)
        {
            if (CartRepository.removeItemFromCart(userId, FootwearId) != null)
            {
                return true;
            }

            return false;
        }
    }
}