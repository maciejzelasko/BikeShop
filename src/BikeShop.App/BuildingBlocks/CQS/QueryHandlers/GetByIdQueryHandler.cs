using BikeShop.App.BuildingBlocks.CQS.Queries;
using BikeShop.Core.BuildingBlocks;
using MediatR;

namespace BikeShop.App.BuildingBlocks.CQS.QueryHandlers;

internal abstract class GetByIdQueryHandler<TQuery, TEntity, TDto> : IRequestHandler<TQuery, TDto> 
    where TQuery : GetByIdQuery<TDto>
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper<TEntity, TDto> _mapper;

    protected GetByIdQueryHandler(IRepository<TEntity> repository, IMapper<TEntity, TDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map(entities);
    }
}