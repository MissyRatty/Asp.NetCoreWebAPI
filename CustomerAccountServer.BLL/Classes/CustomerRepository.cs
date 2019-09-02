using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;
using CustomerAccountServer.Data.Models;

namespace CustomerAccountServer.BLL.Classes
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
