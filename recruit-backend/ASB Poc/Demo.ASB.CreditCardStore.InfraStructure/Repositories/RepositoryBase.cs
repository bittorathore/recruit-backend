
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.ASB.CreditCardStore.InfraStructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataBaseContext RepositoryContext { get; set; }
        public RepositoryBase(DataBaseContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
            => this.RepositoryContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        public IQueryable<T> Include(string path)
        {
            return RepositoryContext.Set<T>().Include(path);
        }

        public T Create(T entity)
        {
            var created = RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
            return created.Entity;
        }

        public T Update(T entity)
        {
            var updated = RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
            return updated.Entity;
        }

        public bool Delete(T entity)
        {
            var deleted = RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
            return deleted.Entity != null;
        }
    }
}
