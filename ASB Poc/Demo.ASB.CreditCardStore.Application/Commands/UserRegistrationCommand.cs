
using Demo.ASB.CreditCardStore.Application.Responses;
using MediatR;

namespace Demo.ASB.CreditCardStore.Application.Commands
{
    public class UserRegistrationCommand: IRequest<AuthenticationResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
