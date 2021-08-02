
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface ICreditCardRepository : IRepositoryBase<CreditCard>
    {
        int GetCount();
        Task<List<CreditCard>> GetAllAsync(GetAllCreditCardsQuery query);
        Task<CreditCard> GetByIdAsync(Expression<Func<CreditCard, bool>> expression);
    }
}