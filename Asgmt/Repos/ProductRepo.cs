using Asgmt.Contexts;
using Asgmt.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Asgmt.Repos;

public class ProductRepo : Repo<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepo(DataContext context) : base(context) {
        _context = context;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.PricingUnit)
            .Include(x => x.ProductCategory)
            .ToListAsync();
    }
}
