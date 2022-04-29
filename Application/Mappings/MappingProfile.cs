using Application.DTOs;
using Application.ViewModel;
using AutoMapper;
using Entities.Entities;

namespace FIinancial_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CashBook, CashBookDTO>().ReverseMap();
             CreateMap<OrderDTO,Order>().ForMember(op=>op.OrderProducts, opt=>opt.Ignore());
           // CreateMap<OrderDTO, Order>();
            CreateMap<Order,OrderViewModel>().ReverseMap();


            CreateMap<Document, DocumentDTO>().ReverseMap(); 
            CreateMap<OrderProductDTO, OrderProducts>()
                .ForMember(op=>op.Total,map=>map.MapFrom(src=>$"{src.Quantity}*{src.Value}")).ReverseMap(); 
        }
    }
}
