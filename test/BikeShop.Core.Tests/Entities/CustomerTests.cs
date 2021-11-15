using BikeShop.Core.Entities;
using FluentAssertions;
using Xunit;

namespace BikeShop.Core.Tests.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void Activate_ShouldChangeCustomerStatusToActivated()
        {
            // Arrange
            var customer = new Customer("John", "Smith");

            // Act
            customer.Activate();

            // Assert
            customer.Status.Should().Be(Customer.CustomerStatus.Activated);
        }
    }
}