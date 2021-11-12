using AutoMapper;
using BikeShop.App.Models;
using BikeShop.Core.Entities;

namespace BikeShop.App.Mappers;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Bike, BikeDto>();
        CreateMap<Customer, CustomerDto>();
    }
}