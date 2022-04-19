﻿using Application.DTOs;
using AutoMapper;
using Entities.Entities;

namespace FIinancial_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CashBook, CashBookDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();   
            CreateMap<Document, DocumentDTO>().ReverseMap(); 
            CreateMap<OrderProductDTO, OrderProducts>()
                .ForMember(op=>op.Total,map=>map.MapFrom(src=>$"{src.Quantity}*{src.Value}")).ReverseMap(); 
        }
    }
}