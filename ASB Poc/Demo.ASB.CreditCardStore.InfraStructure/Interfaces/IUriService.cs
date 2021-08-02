
using Demo.ASB.CreditCardStore.Application.Queries.Filters;
using System;

namespace Demo.ASB.CreditCardStore.InfraStructure.Interfaces
{
    public interface IUriService
    {

        Uri GetPageUri(string route, int pageNumber, int pageSize);
    }
}
