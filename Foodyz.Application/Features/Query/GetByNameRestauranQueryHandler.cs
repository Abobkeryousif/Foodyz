

using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Application.DTOs;
using Foodyz.Core.Commen;
using Foodyz.Core.Entities;
using MediatR;
using System.Net;

namespace Foodyz.Application.Features.Query
{
    public record GetByNameRestauranQuery(GetByNameRestauranDto GetByNameRestauranDto) : IRequest<HttpResponse<Restaurant>>;
    public class GetByNameRestauranQueryHandler : IRequestHandler<GetByNameRestauranQuery, HttpResponse<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public GetByNameRestauranQueryHandler(IRestaurantRepository restaurantRepository)=>
        _restaurantRepository = restaurantRepository;
        

        public async Task<HttpResponse<Restaurant>> Handle(GetByNameRestauranQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.FirstOrDefaultAsync(n=> n.Name.ToLower() == request.GetByNameRestauranDto.Name.ToLower());
            if (restaurant == null)
                return new HttpResponse<Restaurant>(HttpStatusCode.NotFound,$"Not Found Restaurant With Name: {request.GetByNameRestauranDto.Name}");

            return new HttpResponse<Restaurant>(HttpStatusCode.OK,"Seccuss Opration",restaurant);
        }
    }
}
