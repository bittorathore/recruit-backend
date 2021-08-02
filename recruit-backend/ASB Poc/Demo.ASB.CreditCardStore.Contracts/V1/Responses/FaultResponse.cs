
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Contracts.V1.Responses
{
    public class FaultResponse
    {
        public IEnumerable<string> ErrorMessage { get; set; }
    }
}
