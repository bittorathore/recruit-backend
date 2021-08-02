
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using System;

namespace Demo.ASB.CreditCardStore.InfraStructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataBaseContext _context;
        private ICreditCardRepository _creditCardRepository;
        private ICardHolderRepository _cardHolderRepository;
        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            _creditCardRepository = new CreditCardRepository(context);
            _cardHolderRepository = new CardHolderRepository(context);
        }

        public ICreditCardRepository CreditCardRepository { get { return _creditCardRepository; } }
        public ICardHolderRepository CardHolderRepository { get { return _cardHolderRepository; } }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
           return  _context.SaveChanges();
        }
    }
}
