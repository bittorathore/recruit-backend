
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Domain.Entities;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.InfraStructure.Repositories
{
    public class CreditCardRepository : RepositoryBase<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<List<CreditCard>> GetAllAsync(GetAllCreditCardsQuery query)
        {
            var dataSet = FindAll().Include("CardHolder");

            if (!string.IsNullOrWhiteSpace(query.QueryFilters.Name))
                dataSet = dataSet.Where(x => x.CardHolder.CardHolderName.Contains(query.QueryFilters.Name));

            if (query.PaginationFilters.PageNumber.HasValue && query.PaginationFilters.PageSize.HasValue)
            {
                var pageNumber = query.PaginationFilters.PageNumber.Value;
                pageNumber = (pageNumber >= 1) ? pageNumber - 1 : pageNumber;
                var pageSize = query.PaginationFilters.PageSize.Value;

                dataSet = dataSet.Skip(pageNumber * pageSize).Take(pageSize);
            }
            return await dataSet.ToListAsync();
        }

        public async Task<CreditCard> GetByIdAsync(Expression<Func<CreditCard, bool>> expression) 
            => await FindByCondition(expression).Include("CardHolder").SingleOrDefaultAsync();

        public int GetCount()
        {
            return FindAll().Count();
        }
    }
}
