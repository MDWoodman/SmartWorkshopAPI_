using System;
using System.Linq;
using System.Collections.Generic;

namespace SmartWorkshopAPI.application.Mapper
{
    public class OrderMapperProfile : AutoMapper.Profile
    {
        public OrderMapperProfile()
        {
            // Map incoming CreateOrderDto -> domain Order (used when creating an order)
            CreateMap<application.Dto.CreateOrderDto, domain.entities.Order>()
                .ConstructUsing((src, ctx) =>
                    new domain.entities.Order(
                        0, // orderid
                        src.CustomerName ?? string.Empty, // customerName
                        DateTime.UtcNow, // orderDate
                        src.TotalAmount, // totalAmount
                        0m, // totalFee
                        src.Items?.Select(i => ctx.Mapper.Map<domain.entities.OrderItem>(i)).ToList() ?? new List<domain.entities.OrderItem>() // items
                    )
                );

            // Map CreateOrderItemDto -> domain OrderItem (used when creating items)
            CreateMap<application.Dto.CreateOrderItemDto, domain.entities.OrderItem>()
                .ConstructUsing(src =>
                    new domain.entities.OrderItem(
                        Guid.NewGuid(), // orderItemid
                        0, // orderId (default or placeholder, since not provided in DTO)
                        src.Description ?? string.Empty, // description
                        0m, // price
                        src.Quantity // quantity
                    )
                );

            // Read mappings (Order -> ReadOrderDto, OrderItem -> ReadOrderItemDto)
            CreateMap<domain.entities.Order, application.Dto.ReadOrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<domain.entities.OrderItem, application.Dto.ReadOrderItemDto>();

            // Keep/adjust additional mappings as needed (e.g., UpdateOrderDto -> Order)
        }
    }
}
