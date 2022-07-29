using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CRUD.Commands.Delete;

public record DeleteCommand<TId>(TId Id) : IRequest<Result>;
