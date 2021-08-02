
using MediatR;
using Demo.ASB.CreditCardStore.Application.Responses;
using System;

namespace Demo.ASB.CreditCardStore.Application.Commands
{
    public class CreateCreditCardCommand: IRequest<CreditCardResponse>
    {
        public string Name { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVC { get; set; }
    }
}
