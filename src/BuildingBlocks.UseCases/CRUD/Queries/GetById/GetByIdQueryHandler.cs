using BuildingBlocks.Core;
using BuildingBlocks.UseCases.Errors;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace BuildingBlocks.UseCases.CRUD.Queries.GetById;

public abstract class GetByIdQueryHandler<TQuery, TEntity, TId, TDto> : IRequestHandler<TQuery, Result<TDto>> 
    where TQuery : GetByIdQuery<TId, TDto> 
    where TEntity : Entity<TId>
    where TId : new()
{
    private readonly IReadRepository<TEntity, TId> _repository;
    private readonly IMapper _mapper;

    protected GetByIdQueryHandler(IReadRepository<TEntity, TId> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<Result<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) 
        {
            return Result.Fail(new NotFoundError(request.Id?.ToString()));
        }
        return Result.Ok(_mapper.Map<TDto>(entity));
    }
}