
using System.Collections.Generic;

namespace Demo.ASB.CreditCardStore.Contracts.V1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
