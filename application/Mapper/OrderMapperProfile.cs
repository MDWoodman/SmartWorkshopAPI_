namespace SmartWorkshopAPI.application.Mapper
{
    public class OrderMapperProfile : AutoMapper.Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<domain.entities.Order, application.Dto.CreateOrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<domain.entities.Order , application.Dto.CreateOrderDto>();


            CreateMap<domain.entities.OrderItem, application.Dto.CreateOrderItemDto>();

            CreateMap<application.Dto.ReadOrderDto, domain.entities.Order>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<application.Dto.ReadOrderItemDto , domain.entities.OrderItem>();

        }
    }
}
