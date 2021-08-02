
using System;

namespace Demo.ASB.CreditCardStore.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICreditCardRepository CreditCardRepository { get; }
        ICardHolderRepository CardHolderRepository { get; }
        int SaveChanges();
    }
}