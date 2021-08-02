
using MediatR;
using AutoMapper;
using Demo.ASB.CreditCardStore.Application.Responses;
using Demo.ASB.CreditCardStore.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Demo.ASB.CreditCardStore.Application.Queries;
using System.Collections.Generic;

namespace Demo.ASB.CreditCardStore.Application.Handlers.CreditCardHandlers
{
    public class GetAllCreditCardQueryHandler : IRequestHandler<GetAllCreditCardsQuery, PagedCreditCardResponse>
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;
        public GetAllCreditCardQueryHandler(ICreditCardService creditCardService, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }

        public async Task<PagedCreditCardResponse> Handle(GetAllCreditCardsQuery query, CancellationToken cancellationToken)
        {
            var data = await _creditCardService.SearchCreditCardsAsync(query);
            var responseData = _mapper.Map<List<CreditCardResponse>>(data);
            return new PagedCreditCardResponse { Data = responseData, TotalRecords = _creditCardService.GetTotalCount() };
        }
    }
}