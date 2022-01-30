using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Queries.GetAll;

public record GetAllQuery<TDto> : IRequest<Result<IEnumerable<TDto>>>;