using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
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

    public ProductsController(IGenericRepository<Product> productsRepository, IGenericRepository<ProductBrand> brandsRepository, IGenericRepository<ProductType> typesRepository)
    {
      _typesRepository = typesRepository;
      _brandsRepository = brandsRepository;
      _productsRepository = productsRepository;

    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
      var products = await _productsRepository.GetAllAsync();
      return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _productsRepository.GetByIdAsync(id);
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