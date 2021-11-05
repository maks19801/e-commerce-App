using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
  public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
  {
    public ProductsWithTypesAndBrandsSpecification(ProductSpesificationParameters productParameters) : base(x => 
      (!productParameters.BrandId.HasValue || x.ProductBrandId == productParameters.BrandId) &&
      (!productParameters.TypeId.HasValue || x.ProductTypeId == productParameters.TypeId)
    )
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        AddOrderBy(x => x.Name);
        AddPagination(productParameters.PageSize * (productParameters.PageIndex -1), productParameters.PageSize);

        if(!string.IsNullOrEmpty(productParameters.Sort))
        {
          switch(productParameters.Sort)
          {
            case "priceAsc":
              AddOrderBy(p => p.Price);
              break;
            case "priceDesc":
              AddOrderByDescending(p => p.Price);
              break;
            default:
              AddOrderBy(n => n.Name);
              break;
          }
        }
    }

    public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.ProductType);
      AddInclude(x => x.ProductBrand);
    }
  }
}