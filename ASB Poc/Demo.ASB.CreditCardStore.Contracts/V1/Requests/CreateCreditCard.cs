
using System;
using System.Web.Http;

namespace Demo.ASB.CreditCardStore.Contracts.V1.Requests
{
    public class CreateCreditCard
    {
        public string Name { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVC { get; set; }
    }
}