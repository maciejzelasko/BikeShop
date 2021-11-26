using MediatR;

namespace BikeShop.App.BuildingBlocks.CQS.Queries;

public record GetAllQuery<TDto> : IRequest<IEnumerable<TDto>>;