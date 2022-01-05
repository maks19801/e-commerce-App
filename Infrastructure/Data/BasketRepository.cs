using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class BasketRepository : IBasketRepository
  {
    private StoreContext _storeContext { get; set; }

    public BasketRepository(StoreContext storeContext)
    {
      _storeContext = storeContext;
    }

    public async Task DeleteCustomerBasketAsync(string basketId)
    {
      var customerBasket =  _storeContext.CustomerBaskets
                .Include(p => p.Items)
                .FirstOrDefault(c => c.Id == basketId);

            _storeContext.BasketItems.RemoveRange(customerBasket.Items);
            _storeContext.CustomerBaskets.Remove(customerBasket);
      await _storeContext.SaveChangesAsync();

    }
    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
         return await _storeContext.CustomerBaskets
         .Include(p => p.Items)
         .FirstOrDefaultAsync(c => c.Id == basketId);

    }

    public  async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
    {
           await DeleteCustomerBasketAsync(customerBasket.Id);
           return await CreateBasketAsync(customerBasket);
        /*var updateBasket = _storeContext.CustomerBaskets
                .Include(p => p.Items)
                .FirstOrDefault(c => c.Id == customerBasket.Id);
        
        updateBasket.Items.AddRange(customerBasket.Items);
        await _storeContext.SaveChangesAsync();
        return updateBasket;*/
    }

    public async Task<CustomerBasket> CreateBasketAsync(CustomerBasket customerBasket)
    {
      await _storeContext.CustomerBaskets.AddAsync(customerBasket);
      await _storeContext.SaveChangesAsync();
      return customerBasket;
    }
  }
}