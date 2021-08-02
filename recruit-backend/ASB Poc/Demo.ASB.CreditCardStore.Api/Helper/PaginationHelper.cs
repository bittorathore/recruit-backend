
using Demo.ASB.CreditCardStore.Contracts.V1.Requests.Queries;
using Demo.ASB.CreditCardStore.Contracts.V1.Responses;
using Demo.ASB.CreditCardStore.InfraStructure.Interfaces;
using System.Collections.Generic;

namespace Demo.ASB.CreditCardStore.Api.Helper
{
    public static class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedReponse<T>(IUriService uriService, string route, List<T> pagedData, PaginationFilter pagination, int total)
        {
            var totalPages = total / pagination.PageSize.Value;
            var response = new PagedResponse<List<T>>(pagedData, pagination.PageNumber.Value, pagination.PageSize.Value, total)
            {
                NextPage = (pagination.PageNumber >= 1 && pagination.PageNumber.Value < totalPages) ? uriService.GetPageUri(route, pagination.PageNumber.Value + 1, pagination.PageSize.Value) : null,
                PreviousPage = (pagination.PageNumber - 1 >= 1 && pagination.PageNumber.Value <= totalPages) ? uriService.GetPageUri(route, pagination.PageNumber.Value - 1, pagination.PageSize.Value) : null
            };
            return response;
        }
    }
}