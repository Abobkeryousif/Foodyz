using Foodyz.Application.DTOs;
using Foodyz.Application.Features.Command.Restaurants;
using Foodyz.Application.Features.Query;
using Foodyz.Application.Features.Query.Restaurants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodyz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ISender _sender;

        public RestaurantController(ISender sender) =>
            _sender = sender;
        

        [HttpPost("Create")]
         public async Task<IActionResult> CreateAsync(RestaurantDto restaurantDto) =>
            Ok(await _sender.Send(new CreateRestaurantCommand(restaurantDto)));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _sender.Send(new GetRestaurantsQuery()));

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByNameAsync(GetByNameRestauranDto getByNameRestauranDto) =>
            Ok(await _sender.Send(new GetByNameRestauranQuery(getByNameRestauranDto)));

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int Id) =>
            Ok(await _sender.Send(new GetByIdRestaurantQuery(Id)));

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int Id, RestaurantDto restaurantDto) =>
            Ok(await _sender.Send(new UpdateRestaurantCommand(Id,restaurantDto)));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int Id) =>
            Ok(await _sender.Send(new DeleteRestaurantCommand(Id)));


    }
}
