using AutoMapper;
using EDWebshop.Contracts.DTOs;
using EDWebshop.Contracts.Entities;

namespace EDWebshop.Api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FlowerProduct, FlowerProductDto>().ReverseMap();
            CreateMap<FlowerProduct, FlowerProductsDto>();
            CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
        }
    }
}