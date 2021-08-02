
using MediatR;
using AutoMapper;
using Demo.ASB.CreditCardStore.Application.Responses;
using Demo.ASB.CreditCardStore.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Demo.ASB.CreditCardStore.Application.Queries;

namespace Demo.ASB.CreditCardStore.Application.Handlers.CreditCardHandlers
{
    public class GetCreditCardQueryHandler : IRequestHandler<GetCreditCardQuery, CreditCardResponse>
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;
        public GetCreditCardQueryHandler(ICreditCardService creditCardService, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }

        public async Task<CreditCardResponse> Handle(GetCreditCardQuery request, CancellationToken cancellationToken)
        {
            var cc = await _creditCardService.SearchCreditCardAsync(request.Id);

            if (cc == null)
                return null;

            var response = _mapper.Map<CreditCardResponse>(cc);
            return response;
        }
    }
}