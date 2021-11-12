using MediatR;

namespace BikeShop.App.BuildingBlocks.Queries;

public record GetByIdQuery<TResponse>(Guid Id) : IRequest<TResponse>;
