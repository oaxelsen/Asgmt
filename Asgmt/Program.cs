using Asgmt.Contexts;
using Asgmt.Menus;
using Asgmt.Repos;
using Asgmt.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asgmt;

public class Program
{
    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\cms23-db\Asgmt\Asgmt\Contexts\asgmt_db.mdf;Integrated Security=True;Connect Timeout=30"));

        // Repos
        serviceCollection.AddScoped<AddressRepo>();
        serviceCollection.AddScoped<CustomerRepo>();
        serviceCollection.AddScoped<PricingUnitRepo>();
        serviceCollection.AddScoped<ProductCategoryRepo>();
        serviceCollection.AddScoped<ProductRepo>();

        // Services
        serviceCollection.AddScoped<CustomerService>();
        serviceCollection.AddScoped<ProductService>();

        // Menus
        serviceCollection.AddScoped<MainMenu>();
        serviceCollection.AddScoped<CustomerMenu>();
        serviceCollection.AddScoped<ProductMenu>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
        await mainMenu.StartAsync();
    }
}