using AutoMapper;
using BikeShop.App.Models;
using BikeShop.Core.Entities;

namespace BikeShop.App.Mappers;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Customer, CustomerDto>();
    }
}