using MediatR;

namespace BikeShop.App.BuildingBlocks.CQS.Queries;

public record GetByIdQuery<TResponse>(Guid Id) : IRequest<TResponse>;
