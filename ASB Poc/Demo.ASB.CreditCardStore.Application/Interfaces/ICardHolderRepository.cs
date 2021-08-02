
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface ICardHolderRepository: IRepositoryBase<CardHolder>
    {
        Task<CardHolder> GetByConditionAsync(Expression<Func<CardHolder, bool>> expression);
    }
}
