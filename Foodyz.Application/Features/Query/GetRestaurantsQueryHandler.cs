using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Core.Commen;
using Foodyz.Core.Entities;
using MediatR;
using System.Net;

namespace Foodyz.Application.Features.Query
{
    public record GetRestaurantsQuery : IRequest<HttpResponse<List<Restaurant>>>;
    public class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, HttpResponse<List<Restaurant>>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        

        public GetRestaurantsQueryHandler(IRestaurantRepository restaurantRepository)=>
            _restaurantRepository = restaurantRepository;
          
        

        public async Task<HttpResponse<List<Restaurant>>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _restaurantRepository.GetAllAsync();
            if (result.Count == 0)
                return new HttpResponse<List<Restaurant>>(HttpStatusCode.NotFound,"Not Found Any Restaurant!");

            return new HttpResponse<List<Restaurant>>(HttpStatusCode.OK,"Seccuss Opration" , result);

        }
    }
}
