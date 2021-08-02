
using Demo.ASB.CreditCardStore.Application.Commands;
using Demo.ASB.CreditCardStore.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Handlers.IdentityHandlers
{
    public class UserRegistrationHandler : IRequestHandler<UserRegistrationCommand, AuthenticationResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRegistrationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthenticationResponse> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.UserName);
            if (existingUser != null)
                return new AuthenticationResponse { ErrorMessages = new string[] { "User with same email id exists." }, Success = false };

            var newUser = new IdentityUser { Email = request.UserName, UserName = request.UserName };
            var userCreated = await _userManager.CreateAsync(newUser, request.Password);

            if (!userCreated.Succeeded)
                return new AuthenticationResponse { ErrorMessages = userCreated.Errors.Select(x => x.Description), Success = false };

            return new AuthenticationResponse { Success = true, User = newUser };
        }
    }
}
