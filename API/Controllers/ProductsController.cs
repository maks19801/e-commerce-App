using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObject;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly IGenericRepository<Product> _productsRepository;
    private readonly IGenericRepository<ProductBrand> _brandsRepository;
    private readonly IGenericRepository<ProductType> _typesRepository;

    private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> productsRepository, IGenericRepository<ProductBrand> brandsRepository, IGenericRepository<ProductType> typesRepository, IMapper mapper)
    {
      _mapper = mapper;
      _typesRepository = typesRepository;
      _brandsRepository = brandsRepository;
      _productsRepository = productsRepository;

    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductToReturn>>> GetProducts(string sort)
    {
      var specification = new ProductsWithTypesAndBrandsSpecification(sort);
      var products = await _productsRepository.ListAsync(specification);
      return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturn>>(products));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturn>> GetProduct(int id)
    {
      var specification = new ProductsWithTypesAndBrandsSpecification(id);
      var product = await _productsRepository.GetEntityWithSpecification(specification);

      return _mapper.Map<Product, ProductToReturn>(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
      return Ok(await _brandsRepository.GetAllAsync());
    }
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
      var types = await _typesRepository.GetAllAsync();
      return Ok(types);
    }

  }
}