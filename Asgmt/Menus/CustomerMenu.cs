using Asgmt.Models;
using Asgmt.Services;

namespace Asgmt.Menus;

public class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("Manage customers");
        Console.WriteLine("1. View all customers");
        Console.WriteLine("2. Add a customer");
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
        var form = new CustomerRegForm();

        Console.Clear();
        Console.WriteLine("First name: ");
        form.FirstName = Console.ReadLine()!;

        Console.WriteLine("Last name: ");
        form.LastName = Console.ReadLine()!;

        Console.WriteLine("Email: ");
        form.Email = Console.ReadLine()!;

        Console.WriteLine("Street name: ");
        form.StreetName = Console.ReadLine()!;

        Console.WriteLine("Postal code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.WriteLine("City: ");
        form.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
        {
            Console.WriteLine("Customer was created");
        }
        else
        {
            Console.WriteLine("Unable to create customer");
        }
    }

    public async Task ListAllAsync()
    {
        Console.Clear();
        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode} {customer.Address.City}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }
}