using API.DataTransferObject;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturn>()
        .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
        .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
        .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductImageUrlResolver>());
        CreateMap<Address, AddressDto>().ReverseMap();
        
     }
  }
}