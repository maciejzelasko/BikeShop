using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CRUD.Commands.Update;

public record UpdateCommand<TId>(TId Id) : IRequest<Result>;
