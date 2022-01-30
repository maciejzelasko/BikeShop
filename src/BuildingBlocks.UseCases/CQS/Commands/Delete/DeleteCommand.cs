using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Commands.Delete;

public record DeleteCommand<TId>(TId Id) : IRequest<Result>;
