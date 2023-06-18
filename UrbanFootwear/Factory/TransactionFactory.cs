using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear;

namespace UrbanFootwear.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader createTransactionHeader(int customerId)
        {
            TransactionHeader th = new TransactionHeader();
            th.CustomerID = customerId;
            th.TransactionDate = DateTime.Now;

            return th;
        }

        public static TransactionDetail createTransactionDetail(int transactionId, int FootwearId, int qty)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = transactionId;
            td.FootwearID = FootwearId;
            td.Qty = qty;

            return td;
        }
    }
}