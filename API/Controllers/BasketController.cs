using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BasketController : ControllerBase
  {
    private readonly IBasketRepository _basketRepository;
    public BasketController(IBasketRepository basketRepository)
    {
      _basketRepository = basketRepository;

    }
    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> CreateBasketAsync(CustomerBasket customerBasket)
    {
      
       await _basketRepository.CreateBasketAsync(customerBasket);

      return Ok(customerBasket);
    }
    [HttpPut]
    public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync(CustomerBasket customerBasket)
    {

      await _basketRepository.UpdateBasketAsync(customerBasket);

      return Ok(customerBasket);
    }

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> Get(string id)
    {
        var basket = await _basketRepository.GetBasketAsync(id);

        return Ok(basket);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(string id)
    {
            
        await _basketRepository.DeleteCustomerBasketAsync(id);
        return Ok();
    }
}
}