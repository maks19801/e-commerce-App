using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
         Task<CustomerBasket> GetBasketAsync(string basketId);

         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
         Task DeleteCustomerBasketAsync(string basketId);

         Task<CustomerBasket> CreateBasketAsync(CustomerBasket customerBasket);
    }
}