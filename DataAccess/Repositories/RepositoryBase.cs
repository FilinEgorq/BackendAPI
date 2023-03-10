using Domain.Interfaces;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected InternetShopContext RepositoryContext { get; set; }

        public RepositoryBase(InternetShopContext internetShopContext) => RepositoryContext = internetShopContext;

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}