using MediatR;

namespace BikeShop.App.BuildingBlocks.Queries;

public record GetAllQuery<TDto> : IRequest<IEnumerable<TDto>>;