using Asgmt.Entities;
using Asgmt.Models;
using Asgmt.Repos;
using Microsoft.IdentityModel.Tokens;

namespace Asgmt.Services;

public class CustomerService
{
    private readonly AddressRepo _addressRepo;
    private readonly CustomerRepo _customerRepo;

    public CustomerService(AddressRepo addressRepo, CustomerRepo customerRepo)
    {
        _addressRepo = addressRepo;
        _customerRepo = customerRepo;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegForm form)
    {
        // Check customer
        if (!await _customerRepo.ExistsAsync(x => x.Email == form.Email))
        {
            // Check address
            AddressEntity addressEntity = await _addressRepo.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);
            if (addressEntity == null)
            {
                addressEntity = await _addressRepo.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });
            }

            // Create customer
            CustomerEntity customerEntity = await _customerRepo.CreateAsync(new CustomerEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id });
            if (customerEntity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var customers = await _customerRepo.GetAllAsync();
        return customers;
    }
}
