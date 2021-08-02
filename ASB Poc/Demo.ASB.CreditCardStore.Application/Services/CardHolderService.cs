
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Services
{
    public class CardHolderService : ICardHolderService
    {
        private readonly ICardHolderRepository _repository;
        public CardHolderService(ICardHolderRepository repository)
        {
            _repository = repository;
        }
        public CardHolder CreateCardHolder(CardHolder creditHolder)
        {
            return _repository.Create(creditHolder);

        }
        public async Task<CardHolder> SearchCardHolder(string name)
        {
            Expression<Func<CardHolder, bool>> predicate = (c => c.CardHolderName == name);
            return await _repository.GetByConditionAsync(predicate);
        }
    }
}