using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Application.DTOs;
using Foodyz.Core.Commen;
using Foodyz.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Application.Features.Query
{
    public record GetByIdRestaurantQuery(int Id) : IRequest<HttpResponse<Restaurant>>;
    public class GetByIdRestaurantQueryHandler : IRequestHandler<GetByIdRestaurantQuery, HttpResponse<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        
        public GetByIdRestaurantQueryHandler(IRestaurantRepository restaurantRepository)=>
        
            _restaurantRepository = restaurantRepository;
     
        public async Task<HttpResponse<Restaurant>> Handle(GetByIdRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.FirstOrDefaultAsync(i=> i.Id == request.Id);
            if (restaurant is null)
                return new HttpResponse<Restaurant>(HttpStatusCode.NotFound,$"Not Found With ID: {request.Id}");

            return new HttpResponse<Restaurant>(HttpStatusCode.OK,"Seccuss Opration" , restaurant);
            
        }
    }
}
