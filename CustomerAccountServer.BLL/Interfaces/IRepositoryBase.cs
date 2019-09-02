using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerAccountServer.BLL.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
