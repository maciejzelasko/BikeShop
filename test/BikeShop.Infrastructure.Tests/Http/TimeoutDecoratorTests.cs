using System;
using System.Threading;
using System.Threading.Tasks;
using BikeShop.Infrastructure.Http;
using BikeShop.Infrastructure.Http.Decorators;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Polly.Timeout;

namespace BikeShop.Infrastructure.Tests.Http;

public class TimeoutDecoratorTests
{
    private Mock<IBikeShopHttpClient> _bikeShopHttpClientMock;
    [SetUp]
    public void Setup()
    {
        _bikeShopHttpClientMock = new Mock<IBikeShopHttpClient>();
    }

    [Test]
    public async Task GetAsync_Should_Throw_TimeoutRejectedException_When_Response_Takes_Longer_Than_Expected()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        _bikeShopHttpClientMock.Setup(x => x.GetAsync<object>(It.IsAny<string>(), cancellationTokenSource.Token))
            .ReturnsAsync(new object(), TimeSpan.FromSeconds(6));
            
        var timeoutDecorator = new TimeoutDecorator(_bikeShopHttpClientMock.Object);
        Exception? result = null;
        try {
            await timeoutDecorator.GetAsync<object>("https://test.com", cancellationTokenSource.Token);
        }
        catch (Exception e) {
            result = e;
        }

        result.Should().NotBeNull();
        result.Should().BeOfType<TimeoutRejectedException>();

    }
}