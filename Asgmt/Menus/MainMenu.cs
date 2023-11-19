namespace Asgmt.Menus;

public class MainMenu
{
    private readonly CustomerMenu _customerMenu;
    private readonly ProductMenu _productMenu;

    public MainMenu(CustomerMenu customerMenu, ProductMenu productMenu)
    {
        _customerMenu = customerMenu;
        _productMenu = productMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Main menu");
            Console.WriteLine("1. Manage customers");
            Console.WriteLine("1. Manage products");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _customerMenu.ManageCustomers();
                    break;

                case "2":
                    await _productMenu.ManageProducts();
                    break;
            }
        }
        while (true);
    }
}