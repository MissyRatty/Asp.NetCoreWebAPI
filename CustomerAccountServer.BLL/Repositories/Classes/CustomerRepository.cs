using System.Collections.Generic;
using System.Linq;
using CustomerAccountServer.BLL.ExtendedModels;
using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;
using CustomerAccountServer.Data.Entities;

namespace CustomerAccountServer.BLL.Classes
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return FindAll()
                .OrderBy(customer => customer.CustomerName)
                .ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return FindAllByCondition(customer => customer.Id.Equals(customerId))
                //return new empty customer object if that customer id doesn't exist instead of returning null.
                .DefaultIfEmpty(new Customer())
                .FirstOrDefault();
        }

        public CustomerExtended GetCustomerWithDetails(int customerId)
        {
            return new CustomerExtended(GetCustomerById(customerId))
            {
                //Get all accounts info belonging to this customer
                Accounts = RepositoryContext.Accounts
                .Where(account => account.CustomerId.Equals(customerId))
            };
        }
    }
}
