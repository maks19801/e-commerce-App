using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    private readonly StoreContext _context;
    public GenericRepository(StoreContext context)
    {
      _context = context;

    }

    public async Task<int> CountAsync(ISpecification<T> specification)
    {
      return await ApplySpecification(specification).CountAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
    {
      return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
    {
      return await ApplySpecification(specification).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
      return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
  }
}