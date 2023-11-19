using Asgmt.Contexts;
using Asgmt.Entities;

namespace Asgmt.Repos;

public class AddressRepo : Repo<AddressEntity>
{
    public AddressRepo(DataContext context) : base(context)
    {
    }
}
