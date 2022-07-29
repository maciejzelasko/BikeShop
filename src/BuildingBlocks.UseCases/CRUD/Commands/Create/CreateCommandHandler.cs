using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.UseCases.CRUD.Commands.Create;

public abstract class CreateCommandHandler<TCommand, TEntity, TDto> : IRequestHandler<TCommand, Result<TDto>> 
    where TCommand : CreateCommand<TDto> 
    where TEntity : class
{
    private readonly IDbContext _context;
    private readonly DbSet<TEntity> _entities;

    protected CreateCommandHandler(IDbContext dbContext, DbSet<TEntity> entities)
    {
        _context = dbContext;
        _entities = entities;
    }

    public async Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = CreateEntity(request);
        entity = (await _entities.AddAsync(entity, cancellationToken)).Entity;
        await _context.SaveChangesAsync(cancellationToken);
        var productDto = MapDto(entity);
        return Result.Ok(productDto);
    }
    
    protected abstract TEntity CreateEntity(TCommand request);

    protected abstract TDto MapDto(TEntity entity);
}