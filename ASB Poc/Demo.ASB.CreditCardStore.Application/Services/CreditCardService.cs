
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;
        public CreditCardService(ICreditCardRepository repository)
        {
            _repository = repository;
        }

        public int GetTotalCount() => _repository.GetCount();
        public CreditCard CreateCreditCard(CreditCard creditCard)
        {
            return _repository.Create(creditCard);
        }

        public async Task<CreditCard> SearchCreditCardAsync(Guid id)
        {
            Expression<Func<CreditCard, bool>> predicate = (c => c.Id == id);
            var result = await _repository.GetByIdAsync(predicate);

            return result;
        }

        public async Task<List<CreditCard>> SearchCreditCardsAsync(GetAllCreditCardsQuery query)
        {
            return await _repository.GetAllAsync(query);
        }
    }
}
