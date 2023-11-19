using Asgmt.Contexts;
using Asgmt.Entities;

namespace Asgmt.Repos;

public class ProductCategoryRepo : Repo<ProductCategoryEntity>
{
    public ProductCategoryRepo(DataContext context) : base(context) { }
}
