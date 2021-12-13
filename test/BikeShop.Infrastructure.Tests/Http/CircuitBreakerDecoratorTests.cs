using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BikeShop.Infrastructure.Http;
using BikeShop.Infrastructure.Http.Decorators;
using Moq;
using NUnit.Framework;

namespace BikeShop.Infrastructure.Tests.Http;

public class CircuitBreakerDecoratorTests
{
    private Mock<IBikeShopHttpClient> _bikeShopHttpClientMock;
    [SetUp]
    public void Setup()
    {
        _bikeShopHttpClientMock = new Mock<IBikeShopHttpClient>();
    }
    [Test]
    public async Task GetAsync_Should_Be_Called_Allowed_Breaking_Request_Times_When_Api_Calls_Is_More()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var config = new CircuitBreakerDecoratorConfig()
        {
            Enabled = true,
            DurationOfBreakInSeconds = 2,
            ExceptionsAllowedBeforeBreaking = 2
        };
        _bikeShopHttpClientMock.Setup(x => x.GetAsync<object>(It.IsAny<string>(), cancellationTokenSource.Token))
            .ThrowsAsync(new HttpRequestException());
            
        var circuitBreakerDecorator = new CircuitBreakerDecorator(_bikeShopHttpClientMock.Object,config);

        for (var i = 0; i < 3; i++) {
            try {
                await circuitBreakerDecorator.GetAsync<object>("https://test.com", cancellationTokenSource.Token);
            }
            catch (Exception e) {
                // ignored
            }
        }

        try {
            await circuitBreakerDecorator.GetAsync<object>("https://test.com", cancellationTokenSource.Token);
        }
        catch (Exception e) {
            // ignored
        }

        _bikeShopHttpClientMock.Verify(x => x.GetAsync<object>(It.IsAny<string>(), cancellationTokenSource.Token),Times.Exactly(config.ExceptionsAllowedBeforeBreaking));
    }
}