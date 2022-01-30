using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Queries.GetById;

public record GetByIdQuery<TId, TDto>(TId Id) : IRequest<Result<TDto>> 
    where TId : new();
