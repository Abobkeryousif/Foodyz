using AutoMapper;
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

namespace Foodyz.Application.Features.Command.Restaurants
{
    public record UpdateRestaurantCommand(int Id,RestaurantDto restaurantDto) : IRequest<HttpResponse<Restaurant>>;
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, HttpResponse<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        
            public UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)=>
            _restaurantRepository = restaurantRepository;
        
        public async Task<HttpResponse<Restaurant>> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.FirstOrDefaultAsync(r=> r.Id == request.Id);
            if (restaurant == null)
                return new HttpResponse<Restaurant>(HttpStatusCode.NotFound, $"Not Found With ID: {request.Id}");
            restaurant.Name = request.restaurantDto.Name;
            restaurant.City = request.restaurantDto.City;
            restaurant.Address = request.restaurantDto.Address;
            restaurant.Phone = request.restaurantDto.Phone;

            await _restaurantRepository.UpdateAsync(restaurant);
            return new HttpResponse<Restaurant>(HttpStatusCode.OK,"Seccuss Opration",restaurant);
        }
    }
}
