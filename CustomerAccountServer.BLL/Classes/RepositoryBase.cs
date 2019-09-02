using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerAccountServer.BLL.Classes
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        //Todo: maybe this RepositoryContext Class should have been behind an interface, so its contract will be injected into this RepositoryBase Class instead of this concrete implementation.
        protected RepositoryContext RepositoryContext { get; set; }

        //Todo: should be injecting a RepositoryBase contract into this RepositoryBase Class instead of this concrete implementation.
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

       
    }
}
