using BuildingBlocks.Core;
using BuildingBlocks.UseCases.Errors;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.UseCases.CRUD.Commands.Delete;

public abstract class DeleteCommandHandler<TCommand, TEntity, TId> : IRequestHandler<TCommand, Result> 
    where TCommand : DeleteCommand<TId>
    where TEntity : Entity<TId>
    where TId : new()
{
    private readonly IDbContext _context;
    private readonly DbSet<TEntity> _entities;

    protected DeleteCommandHandler(IDbContext context, DbSet<TEntity> entities)
    {
        _context = context;
        _entities = entities;
    }

    public async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = await _entities.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (entity == null)
        {
            return Result.Fail(new NotFoundError(request.Id?.ToString()));
        }

        _entities.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
