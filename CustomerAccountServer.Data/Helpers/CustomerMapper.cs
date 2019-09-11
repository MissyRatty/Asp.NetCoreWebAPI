using CustomerAccountServer.Data.Entities;
using System;

namespace CustomerAccountServer.Data.Helpers
{
    public  static class CustomerMapper
    {
        public static void Map(this Customer dbCustomer, Customer customer)
        {
            dbCustomer.CustomerName = customer.CustomerName;
            dbCustomer.CustomerCreatedDateTime = DateTime.Now;
        }
    }
}
