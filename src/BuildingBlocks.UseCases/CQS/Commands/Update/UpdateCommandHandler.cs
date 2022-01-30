﻿using FluentResults;
using MediatR;

namespace BuildingBlocks.UseCases.CQS.Commands.Update;

public abstract class UpdateCommandHandler<TCommand, TId> : IRequestHandler<TCommand, Result> 
    where TCommand : UpdateCommand<TId>
{
    public abstract Task<Result> Handle(TCommand request, CancellationToken cancellationToken);
}