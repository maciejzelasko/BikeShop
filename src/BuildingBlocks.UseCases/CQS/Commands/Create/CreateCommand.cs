using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Commands.Create;

public record CreateCommand<TDto> : IRequest<Result<TDto>>;
