using CustomerAccountServer.Data.Entities;
using System;
using System.Collections.Generic;

namespace CustomerAccountServer.BLL.ExtendedModels
{
    public class CustomerExtended : IEntity
    {
        public CustomerExtended(Customer customer)
        {
            Id = customer.Id;
            CustomerName = customer.CustomerName;
            CustomerCreatedDateTime = customer.CustomerCreatedDateTime;
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CustomerCreatedDateTime { get; set; }
       
        public IEnumerable<Account> Accounts { get; set; }
    }
}
