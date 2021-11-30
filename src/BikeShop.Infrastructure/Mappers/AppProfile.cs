using AutoMapper;
using BikeShop.App.Features.Customers;
using BikeShop.App.Features.Products;
using BikeShop.Core.Features.Customers;
using BikeShop.Core.Features.Products;

namespace BikeShop.Infrastructure.Mappers;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Customer, CustomerDto>();
    }
}