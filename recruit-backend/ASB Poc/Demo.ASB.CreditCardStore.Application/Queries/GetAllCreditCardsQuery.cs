
using MediatR;
using Demo.ASB.CreditCardStore.Application.Responses;

using System.Collections.Generic;
using Demo.ASB.CreditCardStore.Application.Queries.Filters;

namespace Demo.ASB.CreditCardStore.Application.Queries
{
    public class GetAllCreditCardsQuery: IRequest<PagedCreditCardResponse>
    {
        public RequestFilterQuery QueryFilters { get; set; }
        public PaginationFilterQuery PaginationFilters { get; set; }
    }
}