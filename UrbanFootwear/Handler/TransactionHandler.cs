﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear;
using UrbanFootwear.Repository;

namespace UrbanFootwear.Handler
{
    public class TransactionHandler
    {
        public static bool checkout(int userId)
        {
            if(TransactionRepository.checkout(userId) != null)
            {
                return true;
            }

            return false;
        }

        public static List<TransactionHeader> getUserTransaction(int userId)
        {
            return TransactionRepository.getUserTransaction(userId);
        }

        public static List<TransactionHeader> getTransactions()
        {
            return TransactionRepository.getTransactions();
        }
    }
}