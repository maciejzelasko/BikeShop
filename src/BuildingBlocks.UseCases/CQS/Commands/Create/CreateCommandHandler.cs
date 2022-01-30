using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Commands.Create;

public abstract class CreateCommandHandler<TCommand, TDto> : IRequestHandler<TCommand, Result<TDto>> 
    where TCommand : CreateCommand<TDto>
{
    public abstract Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken);
}