
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface ICardHolderService
    {
        CardHolder CreateCardHolder(CardHolder creditHolder);
        Task<CardHolder> SearchCardHolder(string name);
    }
}
