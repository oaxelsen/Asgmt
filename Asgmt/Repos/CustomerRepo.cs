using Asgmt.Contexts;
using Asgmt.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asgmt.Repos;

public class CustomerRepo : Repo<CustomerEntity>
{
    private readonly DataContext _context;
    public CustomerRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.Include(x => x.Address).ToListAsync();
    }
}
