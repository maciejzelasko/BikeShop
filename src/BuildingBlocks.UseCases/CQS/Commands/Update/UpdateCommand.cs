using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Commands.Update;

public record UpdateCommand<TId>(TId Id) : IRequest<Result>;
