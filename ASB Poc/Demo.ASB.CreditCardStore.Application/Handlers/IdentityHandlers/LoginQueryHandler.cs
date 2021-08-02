
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Handlers.IdentityHandlers
{
    public class LoginQueryHandler : IRequestHandler<LoginRequestQuery, AuthenticationResponse>
    {
        private UserManager<IdentityUser> _userManager;
        public LoginQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthenticationResponse> Handle(LoginRequestQuery request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.UserName);
            if (existingUser == null)
                return new AuthenticationResponse { ErrorMessages = new string[] { "User doesn't exist." }, Success = false };

            var result = await _userManager.CheckPasswordAsync(existingUser, request.Password);
            if (!result)
                return new AuthenticationResponse { ErrorMessages = new string[] { "Invalid Credentials." }, Success = false };

            return new AuthenticationResponse { Success = true, User = existingUser };
        }
    }
}
