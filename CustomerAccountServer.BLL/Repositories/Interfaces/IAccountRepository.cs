using CustomerAccountServer.Data.Entities;
using System.Collections.Generic;

namespace CustomerAccountServer.BLL.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByCustomer(int customerId);
    }
}
