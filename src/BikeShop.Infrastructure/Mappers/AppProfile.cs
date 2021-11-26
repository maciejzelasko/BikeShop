using AutoMapper;
using BikeShop.App.Features.Customer;
using BikeShop.App.Features.Product;
using BikeShop.Core.Features.Customer;
using BikeShop.Core.Features.Product;

namespace BikeShop.Infrastructure.Mappers;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Customer, CustomerDto>();
    }
}