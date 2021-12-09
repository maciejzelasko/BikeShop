using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BikeShop.Infrastructure.Http;
using BikeShop.Infrastructure.Http.Decorators;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BikeShop.Infrastructure.Tests.Http;

public class WaitAndRetryDecoratorTests
{
    private Mock<IBikeShopHttpClient> _bikeShopHttpClientMock;

    [SetUp]
    public void Setup()
    {
        _bikeShopHttpClientMock = new Mock<IBikeShopHttpClient>();
    }
    [Test]
    public async Task GetAsync_Should_Be_Called_Once_When_Response_Is_Successful()
    {
        _bikeShopHttpClientMock.Setup(x => x.GetAsync<object>(It.IsAny<string>(), default))
            .ReturnsAsync(new object());
        var bikeShopHttpClient = new WaitAndRetryDecorator(_bikeShopHttpClientMock.Object);

        var response =
            await bikeShopHttpClient.GetAsync<object>("https://jsonplaceholder.typicode.com/todos",default);

        response.Should().NotBeNull();
        _bikeShopHttpClientMock.Verify(x => x.GetAsync<It.IsAnyType>(It.IsAny<string>(), default),Times.Once);

    }
    [Test]
    public async Task GetAsync_Should_Be_Called_Four_Times_When_Response_Is_Failed()
    {
        _bikeShopHttpClientMock.Setup(x => x.GetAsync<IEnumerable<ToDo>>(It.IsAny<string>(), default))
            .ThrowsAsync(new HttpRequestException());
        var timeoutDecorator = new WaitAndRetryDecorator(_bikeShopHttpClientMock.Object);
        try {
            await timeoutDecorator.GetAsync<IEnumerable<ToDo>>("https://jsonplaceholder.typicode.com/todos",default);
        }
        catch (Exception) {
            
        }
        _bikeShopHttpClientMock.Verify(x => x.GetAsync<IEnumerable<ToDo>>(It.IsAny<string>(),default),Times.Exactly(4));

    }
    [Test]
    public async Task GetAsync_Should_Be_Called_Three_Times_When_Third_Call_Gives_Successful_Response()
    {
        _bikeShopHttpClientMock.SetupSequence(x => x.GetAsync<IEnumerable<ToDo>>(It.IsAny<string>(), default))
            .ThrowsAsync(new HttpRequestException())
            .ThrowsAsync(new HttpRequestException())
            .ReturnsAsync(new List<ToDo>());
        var timeoutDecorator = new WaitAndRetryDecorator(_bikeShopHttpClientMock.Object);
        try {
            await timeoutDecorator.GetAsync<IEnumerable<ToDo>>("https://jsonplaceholder.typicode.com/todos",default);
        }
        catch (Exception) {
            
        }
        _bikeShopHttpClientMock.Verify(x => x.GetAsync<IEnumerable<ToDo>>(It.IsAny<string>(),default),Times.Exactly(3));

    }
}

public class ToDo
{
    public int UserId { get; init; }
    public int Id { get; init; }
    public string Title { get; init; }
    public bool Completed { get; init; }
    
}