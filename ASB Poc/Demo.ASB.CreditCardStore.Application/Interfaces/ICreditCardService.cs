
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface ICreditCardService
    {
        int GetTotalCount();
        CreditCard CreateCreditCard(CreditCard creditCard);
        Task<CreditCard> SearchCreditCardAsync(Guid id);
        Task<List<CreditCard>> SearchCreditCardsAsync(GetAllCreditCardsQuery query);
    }
}