
using Demo.ASB.CreditCardStore.Application.Commands;
using Demo.ASB.CreditCardStore.Application.Interfaces;
using Demo.ASB.CreditCardStore.Application.Responses;
using Demo.ASB.CreditCardStore.Domain.Entities;

using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Application.Handlers.CreditCardHandlers
{
    public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, CreditCardResponse>
    {
        private readonly ICreditCardService _creditCardService;
        private readonly ICardHolderService _cardHolderService;
        private readonly IMapper _mapper;
        public CreateCreditCardCommandHandler(ICreditCardService creditCardService, ICardHolderService cardHolderService, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _cardHolderService = cardHolderService;
            _mapper = mapper;
        }
        public async Task<CreditCardResponse> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var cardHolder = await _cardHolderService.SearchCardHolder(request.Name);
            if (cardHolder == null)
                cardHolder = _cardHolderService.CreateCardHolder(new CardHolder { CardHolderName = request.Name });

            var creditCardDomain = _mapper.Map<CreditCard>(request);
            creditCardDomain.CardHolderId = cardHolder.Id;
            
            var cc = _creditCardService.CreateCreditCard(creditCardDomain);

            var response = _mapper.Map<CreditCardResponse>(cc);
            response.CardHolder = _mapper.Map<CardHolderResponse>(cardHolder);

            return response;
        }
    }
}