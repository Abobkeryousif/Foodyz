

using AutoMapper;
using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Application.DTOs;
using Foodyz.Core.Commen;
using Foodyz.Core.Entities;
using MediatR;
using System.Net;

namespace Foodyz.Application.Features.Command.Restaurants
{
    public record CreateRestaurantCommand(RestaurantDto restaurantDto) : IRequest<HttpResponse<Restaurant>>;
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, HttpResponse<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<HttpResponse<Restaurant>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var IsExist = await _restaurantRepository.IsExist(r=> r.Name.ToLower() == request.restaurantDto.Name.ToLower());
            if (IsExist)
                return new HttpResponse<Restaurant>(HttpStatusCode.BadRequest,"This Restaurant Already Add!");

            var restaurant = _mapper.Map<Restaurant>(request.restaurantDto);
            await _restaurantRepository.CreateAsync(restaurant);
            return new HttpResponse<Restaurant>(HttpStatusCode.OK,"Seccuss Opration",restaurant);

        }
    }
}
