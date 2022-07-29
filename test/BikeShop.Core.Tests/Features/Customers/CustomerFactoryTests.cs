using System;
using BikeShop.Core.SharedKernel;
using BikeShop.Core.UseCases.Customers;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BikeShop.Core.Tests.Features.Customers;

public class CustomerFactoryTests
{
    private readonly CustomerFactory _sut;

    public CustomerFactoryTests()
    {
        var dateTimeProvider = Substitute.For<IDateTimeProvider>();
        dateTimeProvider.Now.Returns(new DateTime(2020, 1, 1));

        _sut = new CustomerFactory(dateTimeProvider);
    }

    [Fact]
    public void Create_ShouldNotAllowToCreateUnderAgedCustomer()
    {
        // Arrange && Act
        var result = _sut.Create("John", "Smith", new DateTime(2019, 12, 1));

        // Assert
        result.IsFailed.Should().BeTrue();
    }
}