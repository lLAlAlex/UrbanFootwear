using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear;
using UrbanFootwear.Handler;

namespace UrbanFootwear.Controller
{
    public class TransactionController
    {
        public static bool checkout(int userId)
        {
            return TransactionHandler.checkout(userId);
        }

        public static List<TransactionHeader> getUserTransaction(int userId)
        {
            return TransactionHandler.getUserTransaction(userId);
        }
    }
}