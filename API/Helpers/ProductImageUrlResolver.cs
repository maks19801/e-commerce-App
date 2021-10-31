using API.DataTransferObject;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
  public class ProductImageUrlResolver : IValueResolver<Product, ProductToReturn, string>
  {
    private readonly IConfiguration _configuration;
    public ProductImageUrlResolver(IConfiguration configuration)
    {
      _configuration = configuration;

    }

    public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
    {
      if(!string.IsNullOrEmpty(source.PictureUrl))
      {
          return _configuration["ApiUrl"] + source.PictureUrl;
      }

      return null;

    }
  }
}