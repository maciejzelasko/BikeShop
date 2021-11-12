using System.Runtime.CompilerServices;
using BikeShop.Core.Entities;
using BikeShop.Core.Repositories;
using MediatR;

namespace BikeShop.App.Queries;

public static class GetAllBikes
{
    public class Query : IRequest<IEnumerable<Bike>>
    {

    }

    public class QueryHandler : IRequestHandler<Query, IEnumerable<Bike>>
    {
        private readonly IBikeRepository _bikeRepository;

        public QueryHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public Task<IEnumerable<Bike>> Handle(Query request, CancellationToken cancellationToken)
        {
            return _bikeRepository.GetAllAsync();
        }
    }
}