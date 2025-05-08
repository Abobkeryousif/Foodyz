using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Core.Commen;
using Foodyz.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Application.Features.Command.Restaurants
{
    public record DeleteRestaurantCommand(int Id) : IRequest<HttpResponse<string>> ;
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, HttpResponse<string>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository)=>
        _restaurantRepository = restaurantRepository;
        public async Task<HttpResponse<string>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.FirstOrDefaultAsync(r=> r.Id == request.Id);
            if (restaurant is null)
                return new HttpResponse<string>(HttpStatusCode.NotFound,$"Not Found With ID: {request.Id}");

            await _restaurantRepository.DeleteAsync(restaurant);
            return new HttpResponse<string>(HttpStatusCode.OK,"Seccuss Opration",restaurant.Name);
        }
    }
}
