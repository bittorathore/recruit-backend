
using Demo.ASB.CreditCardStore.Application.Responses;
using MediatR;

namespace Demo.ASB.CreditCardStore.Application.Queries
{
    public class LoginRequestQuery : IRequest<AuthenticationResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
