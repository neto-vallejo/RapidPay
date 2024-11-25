using AutoMapper;
using RapidPay.API.Data.Entities;
using RapidPay.API.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDTO>();
            CreateMap<CardDTO, Card>();

            CreateMap<CardCreateDTO, Card>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.InitialBalance));

            CreateMap<Card, CardCreateDTO>()
                .ForMember(dest => dest.InitialBalance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<PaymentDTO, Transaction>().ReverseMap();

            CreateMap<TransactionDTO, Transaction>()
                .ForPath(dest => dest.Card.Number, opt => opt.MapFrom(src => src.CardNumber)).ReverseMap();


        }
    }
}
