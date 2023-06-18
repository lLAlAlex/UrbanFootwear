using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear;

namespace UrbanFootwear.Factory
{
    public class CartFactory
    {
        public static Cart createItem(int customerId, int FootwearId, int qty)
        {
            Cart c = new Cart();
            c.CustomerID = customerId;
            c.FootwearID = FootwearId;
            c.Qty = qty;

            return c;
        }
    }
}