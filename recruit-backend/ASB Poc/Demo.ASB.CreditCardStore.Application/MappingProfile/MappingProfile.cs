
using AutoMapper;
using Demo.ASB.CreditCardStore.Application.Commands;
using Demo.ASB.CreditCardStore.Application.Responses;
using Demo.ASB.CreditCardStore.Domain.Entities;
using System;
using System.Globalization;

namespace Demo.ASB.CreditCardStore.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCreditCardCommand, CreditCard>()
                .ForMember(des => des.CVC, conf => conf.MapFrom(src => src.CVC))
                .ForMember(des => des.CreditCardNumber, conf => conf.MapFrom(src => src.CreditCardNumber))
                .ForMember(des => des.ExpiryDate, conf => conf.MapFrom(src => DateTime.ParseExact(src.ExpiryDate.ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<CardHolder, CardHolderResponse>();
            CreateMap<CreditCard, CreditCardResponse>()
                .ForMember(des => des.CVC, conf => conf.MapFrom(src => src.CVC))
                .ForMember(des => des.CreditCardNumber, conf => conf.MapFrom(src => src.CreditCardNumber))
                .ForMember(des => des.ExpiryDate, conf => conf.MapFrom(src => src.ExpiryDate.ToString()));
        }
    }
}