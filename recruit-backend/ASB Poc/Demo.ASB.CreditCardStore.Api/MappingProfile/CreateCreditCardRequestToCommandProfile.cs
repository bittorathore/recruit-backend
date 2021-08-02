
using AutoMapper;
using Demo.ASB.CreditCardStore.Application.Commands;
using Demo.ASB.CreditCardStore.Application.Queries.Filters;
using Demo.ASB.CreditCardStore.Application.Responses;
using Demo.ASB.CreditCardStore.Contracts.V1.Requests;
using Demo.ASB.CreditCardStore.Contracts.V1.Requests.Queries;
using Demo.ASB.CreditCardStore.Contracts.V1.Responses;

namespace Demo.ASB.CreditCardStore.Api.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCreditCard, CreateCreditCardCommand>();
            CreateMap<CreditCardResponse, CreditCardApiResponse>().
                ForMember(des => des.Name, conf => conf.MapFrom(src => src.CardHolder.CardHolderName)).
                ForMember(des => des.CreditCardNumber, conf => conf.MapFrom(src => src.CreditCardNumber)).
                ForMember(des => des.ExpiryDate, conf => conf.MapFrom(src => src.ExpiryDate)).
                ForMember(des => des.CVC, conf => conf.MapFrom(src => src.CVC));

            CreateMap<RequestFilter, RequestFilterQuery>();
            CreateMap<PaginationFilter, PaginationFilterQuery>();
        }
    }
}