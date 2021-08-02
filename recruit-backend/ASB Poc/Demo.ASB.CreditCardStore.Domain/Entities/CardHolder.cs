
using System;
using System.Collections.Generic;

namespace Demo.ASB.CreditCardStore.Domain.Entities
{
    public class CardHolder
    {
        public Guid Id { get; set; }
        public string CardHolderName { get; set; }
        public IList<CreditCard> CreditCards { get;set;}
    }
}
