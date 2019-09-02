using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;
using CustomerAccountServer.Data.Models;

namespace CustomerAccountServer.BLL.Classes
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
