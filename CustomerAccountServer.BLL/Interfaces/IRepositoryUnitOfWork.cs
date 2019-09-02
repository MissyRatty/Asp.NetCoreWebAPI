namespace CustomerAccountServer.BLL.Interfaces
{
    public interface IRepositoryUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
