
using Demo.ASB.CreditCardStore.Application.Responses;
using MediatR;
using System;

namespace Demo.ASB.CreditCardStore.Application.Queries
{
    public class GetCreditCardQuery: IRequest<CreditCardResponse>
    {
        public Guid Id { get; set; } 
    }
}
