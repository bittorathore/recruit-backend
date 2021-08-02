
using System;

namespace Demo.ASB.CreditCardStore.Contracts.V1.Responses
{
    public class CreditCardApiResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVC { get; set; }
    }
}
