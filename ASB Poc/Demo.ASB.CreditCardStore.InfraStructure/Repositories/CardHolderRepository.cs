
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.Domain.Entities;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.InfraStructure.Repositories
{
    public class CardHolderRepository : RepositoryBase<CardHolder>, ICardHolderRepository
    {
        public CardHolderRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<CardHolder> GetByConditionAsync(Expression<Func<CardHolder, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }
    }
}
