using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanFootwear.Repository;

namespace UrbanFootwear.Handler
{
    public class CustomerHandler
    {
        public static List<Customer> GetCustomers()
        {
            return CustomerRepository.GetCustomers();
        }

        public static int AddCustomer(String name, String email, String gender, String address, String password)
        {
            return CustomerRepository.AddCustomer(name, email, gender, address, password);
        }

        public static Boolean Login(String email, String password)
        {
            return CustomerRepository.Login(email, password);
        }
    }
}