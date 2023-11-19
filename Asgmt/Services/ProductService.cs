using Asgmt.Entities;
using Asgmt.Models;
using Asgmt.Repos;

namespace Asgmt.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly PricingUnitRepo _pricingUnitRepo;
    private readonly ProductCategoryRepo _productCategoryRepo;

    public ProductService(ProductRepo productRepo, PricingUnitRepo pricingUnitRepo, ProductCategoryRepo productCategoryRepo)
    {
        _productRepo = productRepo;
        _pricingUnitRepo = pricingUnitRepo;
        _productCategoryRepo = productCategoryRepo;
    }

    public async Task<bool> CreateProductAsync(ProductRegForm form)
    {
        if (!await _productRepo.ExistsAsync(x => x.ProductName == form.ProductName))
        {
            // Check if pricing unit exists otherwise create
            var pricingUnitEntity = await _pricingUnitRepo.GetAsync(x => x.Unit == form.PricingUnit);
            if (pricingUnitEntity == null)
            {
                pricingUnitEntity = await _pricingUnitRepo.CreateAsync(new PricingUnitEntity { Unit = form.PricingUnit });
            }

            // Check if category exists otherwise create
            var productCategoryEntity = await _productCategoryRepo.GetAsync(x => x.CategoryName == form.ProductCategory);
            if (productCategoryEntity == null)
            {
                productCategoryEntity = await _productCategoryRepo.CreateAsync(new ProductCategoryEntity { CategoryName = form.ProductCategory });
            }

            // Create product
            var productEntity = new ProductEntity
            {
                ProductName = form.ProductName,
                ProductDescription = form.ProductDescription,
                ProductPrice = form.ProductPrice,
                PricingUnitId = pricingUnitEntity.Id,
                ProductCategoryId = productCategoryEntity.Id
            };

            await _productRepo.CreateAsync(productEntity);

            if (productEntity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var products = await _productRepo.GetAllAsync();
        return products;
    }
} 
