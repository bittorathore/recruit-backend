
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> Include(string path);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}