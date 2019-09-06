using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;

namespace CustomerAccountServer.BLL.Classes
{
    //This is a good practice because now we can, 
    //for example, add two customers, modify two accounts and delete one customer, all in one method, 
    //and then just call the Save method once. 
    //All the changes will be applied or if something fails, all the changes will be reverted

    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;

        //creating properties that will expose the concrete repositories
        private ICustomerRepository _customerRepository;
        private IAccountRepository _accountRepository;

        public RepositoryUnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_repositoryContext);
                }

                return _customerRepository;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_repositoryContext);
                }

                return _accountRepository;
            }
        }

        // used after all the modifications are finished on a certain object
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
