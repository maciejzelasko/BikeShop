using BuildingBlocks.Core;
using BuildingBlocks.UseCases.Errors;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.UseCases.CQS.Commands.Delete;

public abstract class DeleteCommandHandler<TCommand, TEntity, TId> : IRequestHandler<TCommand, Result> 
    where TCommand : DeleteCommand<TId>
    where TEntity : Entity<TId>
    where TId : new()
{
    protected readonly IDbContext Context;

    protected DeleteCommandHandler(IDbContext context)
    {
        Context = context;
    }

    public async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = await Entities.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (entity == null)
        {
            return Result.Fail(new NotFoundError(request.Id?.ToString()));
        }

        Entities.Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    protected abstract DbSet<TEntity> Entities { get; }
}
