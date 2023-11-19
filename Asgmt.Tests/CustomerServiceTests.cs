using Asgmt.Entities;
using Asgmt.Models;
using Asgmt.Repos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Asgmt.Services.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCustomers()
        {
            // Arrange
            var expectedCustomers = new List<CustomerEntity>
            {
                new CustomerEntity
                {
                    FirstName = "Ossian",
                    LastName = "Axelsen"
                }
            };

            var mockAddressRepo = new Mock<AddressRepo>();
            var mockCustomerRepo = new Mock<CustomerRepo>();

            mockCustomerRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedCustomers);

            var customerService = new CustomerService(mockAddressRepo.Object, mockCustomerRepo.Object);

            // Act
            var result = await customerService.GetAllAsync();

            // Assert
            Assert.Equal(expectedCustomers.Count, result.Count());
        }
    }
}
