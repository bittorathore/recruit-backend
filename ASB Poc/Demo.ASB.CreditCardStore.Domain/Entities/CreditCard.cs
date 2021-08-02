
using System;

namespace Demo.ASB.CreditCardStore.Domain.Entities
{
    public class CreditCard
    {
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVC { get; set; }
        public Guid CardHolderId { get; set; }
        public CardHolder CardHolder { get; set; }
    }
}
