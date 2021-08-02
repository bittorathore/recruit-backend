
using System;
using Microsoft.AspNetCore.WebUtilities;
using Demo.ASB.CreditCardStore.InfraStructure.Interfaces;

namespace Demo.ASB.CreditCardStore.InfraStructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(string route, int pageNumber, int pageSize)
        {
            var endpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "pageNumber", pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri.ToString(), "pageSize", pageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}