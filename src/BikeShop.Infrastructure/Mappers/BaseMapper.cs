using AutoMapper;
using BikeShop.App.BuildingBlocks;

namespace BikeShop.Infrastructure.Mappers;

internal abstract class BaseMapper<TFrom, TTo> : IMapper<TFrom, TTo>
{
    private readonly IMapper _mapper;

    protected BaseMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TTo Map(TFrom from) =>
        _mapper.Map<TTo>(from);

    public IEnumerable<TTo> MapCollection(IEnumerable<TFrom> from) =>
        _mapper.Map<IEnumerable<TTo>>(from);
}