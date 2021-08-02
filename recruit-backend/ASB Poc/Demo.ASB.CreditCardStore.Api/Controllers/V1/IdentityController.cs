
using Demo.ASB.CreditCardStore.Api.Helper;
using Demo.ASB.CreditCardStore.Api.Settings;
using Demo.ASB.CreditCardStore.Application.Commands;
using Demo.ASB.CreditCardStore.Application.Queries;
using Demo.ASB.CreditCardStore.Contracts.V1;
using Demo.ASB.CreditCardStore.Contracts.V1.Requests;
using Demo.ASB.CreditCardStore.Contracts.V1.Requests.Queries;
using Demo.ASB.CreditCardStore.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Api.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtSettings _settings;
        public IdentityController(IMediator mediator, JwtSettings settings)
        {
            _mediator = mediator;
            _settings = settings;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthFailedResponse { ErrorMessages = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)) });

            var authResponse = await _mediator.Send(new UserRegistrationCommand { UserName = request.Email, Password = request.Password });

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse { ErrorMessages = authResponse.ErrorMessages });

            return Ok(new AuthSuccessResponse { Token = GenerateTokenHelper.GenerateToken(authResponse.User, _settings) });
        }

        [HttpGet(ApiRoutes.Identity.Login)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginAsync([FromQuery] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthFailedResponse { ErrorMessages = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)) });

            var authResponse = await _mediator.Send(new LoginRequestQuery { UserName = request.Email, Password = request.Password });

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse { ErrorMessages = authResponse.ErrorMessages });

            return Ok(new AuthSuccessResponse { Token = GenerateTokenHelper.GenerateToken(authResponse.User, _settings) });
        }
    }
}
