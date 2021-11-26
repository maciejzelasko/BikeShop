using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.Core.BuildingBlocks;
using MediatR;

namespace BikeShop.App.BuildingBlocks.QueryHandlers;

internal abstract class GetAllQueryHandler<TQuery, TEntity, TDto> : IRequestHandler<TQuery, IEnumerable<TDto>> 
    where TQuery : GetAllQuery<TDto>
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper<TEntity, TDto> _mapper;

    protected GetAllQueryHandler(IRepository<TEntity> repository, IMapper<TEntity, TDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.MapCollection(entities);
    }
}