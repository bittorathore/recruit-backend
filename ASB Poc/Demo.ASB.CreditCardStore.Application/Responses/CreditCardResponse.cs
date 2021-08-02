
using System;

namespace Demo.ASB.CreditCardStore.Application.Responses
{
    public class CreditCardResponse
    {
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVC { get; set; }
        public CardHolderResponse CardHolder { get; set; }
    }
}