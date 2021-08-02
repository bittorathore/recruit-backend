
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Demo.ASB.CreditCardStore.Application.Responses
{
    public class AuthenticationResponse
    {
        public IdentityUser User { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
