using Asgmt.Models;
using Asgmt.Services;

namespace Asgmt.Menus;

public class ProductMenu
{
    private readonly ProductService _productService;

    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }

    public async Task ManageProducts()
    {
        Console.Clear();
        Console.WriteLine("Manage products");
        Console.WriteLine("1. View all products");
        Console.WriteLine("2. Add a product");
        Console.Write("Choose an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;
        }
    }

    public async Task CreateAsync()
    {
        var form = new ProductRegForm();

        Console.Clear();
        Console.WriteLine("Product name: ");
        form.ProductName = Console.ReadLine()!;

        Console.WriteLine("Product description: ");
        form.ProductDescription = Console.ReadLine()!;

        Console.WriteLine("Product category: ");
        form.ProductCategory = Console.ReadLine()!;

        Console.WriteLine("Product price (SEK): ");
        form.ProductPrice = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("Pricing unit (qt/hrs etc...): ");
        form.PricingUnit = Console.ReadLine()!;

        var result = await _productService.CreateProductAsync(form);
        if (result)
        {
            Console.WriteLine("Product was created");
        }
        else
        {
            Console.WriteLine("Unable to create product");
        }
    }

    public async Task ListAllAsync()
    {
        Console.Clear();
        var products = await _productService.GetAllAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductName} ({product.ProductCategory.CategoryName})");
            Console.WriteLine($"{product.ProductPrice} ({product.PricingUnit.Unit})");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }
}
