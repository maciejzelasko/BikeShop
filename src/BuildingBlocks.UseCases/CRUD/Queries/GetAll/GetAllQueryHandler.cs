using BuildingBlocks.Core;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace BuildingBlocks.UseCases.CRUD.Queries.GetAll;

public abstract class GetAllQueryHandler<TQuery, TEntity, TId, TDto> : IRequestHandler<TQuery, Result<IEnumerable<TDto>>> 
    where TQuery : GetAllQuery<TDto>
    where TEntity : Entity<TId>
    where TId : new()
{
    private readonly IReadRepository<TEntity, TId> _repository;
    private readonly IMapper _mapper;

    protected GetAllQueryHandler(IReadRepository<TEntity, TId> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<Result<IEnumerable<TDto>>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        var dtos = entities.Select(s => _mapper.Map<TDto>(s));
        return Result.Ok(dtos);
    }
}