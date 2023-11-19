using Asgmt.Contexts;
using Asgmt.Entities;

namespace Asgmt.Repos;

public class PricingUnitRepo : Repo<PricingUnitEntity>
{
    public PricingUnitRepo(DataContext context) : base(context) { }
}
