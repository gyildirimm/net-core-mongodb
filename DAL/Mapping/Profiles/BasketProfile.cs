using AutoMapper;
using Domain.DTOs.Basket;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping.Profiles
{
    internal class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Money, MoneyDto>().ReverseMap();
        }
    }
}
