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

        public void CreateCustomer(Customer customer)
        {
            //if the customerId column was not Identity(1,1) or autocremented by sql but rather set by us, then we'd have done something like below:
            //customer.Id = OurNewCustomerId
            Create(customer);
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
