using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CRUD.Queries.GetAll;

public record GetAllQuery<TDto> : IRequest<Result<IEnumerable<TDto>>>;