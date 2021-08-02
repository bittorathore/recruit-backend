
using System.Collections.Generic;

namespace Demo.ASB.CreditCardStore.Application.Responses
{
    public class PagedCreditCardResponse
    {
        public List<CreditCardResponse> Data { get; set; }
        public int TotalRecords { get; set; }
    }
}