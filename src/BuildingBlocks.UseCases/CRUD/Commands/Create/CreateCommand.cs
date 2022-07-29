using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CRUD.Commands.Create;

public record CreateCommand<TDto> : IRequest<Result<TDto>>;
