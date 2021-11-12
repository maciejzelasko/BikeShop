using AutoMapper;
using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.Core.BuildingBlocks;
using MediatR;

namespace BikeShop.App.BuildingBlocks.QueryHandlers;

internal abstract class GetByIdQueryHandler<TQuery, TEntity, TDto> : IRequestHandler<TQuery, TDto> 
    where TQuery : GetByIdQuery<TDto>
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    protected GetByIdQueryHandler(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<TDto>(entities);
    }
}