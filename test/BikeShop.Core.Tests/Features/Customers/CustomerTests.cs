using System;
using BikeShop.Core.Features.Customers;
using FluentAssertions;
using Xunit;

namespace BikeShop.Core.Tests.Features.Customers
{
    public class CustomerTests
    {
        [Fact]
        public void Activate_ShouldChangeCustomerStatusToActivated()
        {
            // Arrange
            var customer = new Customer("John", "Smith", new DateTime(1900, 12, 1));

            // Act
            customer.Activate();

            // Assert
            customer.Status.Should().Be(Customer.CustomerStatus.Activated);
        }
    }
}