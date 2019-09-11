using System.Collections.Generic;
using System.Linq;
using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;
using CustomerAccountServer.Data.Entities;

namespace CustomerAccountServer.BLL.Classes
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Account> AccountsByCustomer(int customerId)
        {
            return FindAllByCondition(account => account.CustomerId.Equals(customerId)).ToList();
        }
    }
}
