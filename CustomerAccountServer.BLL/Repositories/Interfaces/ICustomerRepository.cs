using CustomerAccountServer.BLL.ExtendedModels;
using CustomerAccountServer.Data.Entities;
using System.Collections.Generic;

namespace CustomerAccountServer.BLL.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        CustomerExtended GetCustomerWithDetails(int customerId);
        void CreateCustomer(Customer customer);
    }
}
