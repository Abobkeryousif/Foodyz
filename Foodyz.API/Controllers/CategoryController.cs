using Foodyz.Application.DTOs;
using Foodyz.Application.Features.Command.Categories;
using Foodyz.Application.Features.Query.Categories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodyz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISender _sender;
        public CategoryController(ISender sender)=>
            _sender = sender;

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CategoryDto categoryDto) =>
            Ok(await _sender.Send(new CreateCategoryCommand(categoryDto)));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _sender.Send(new GetCategoryQuery()));

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int Id) =>
            Ok(await _sender.Send(new GetByIdCategoryQuery(Id)));

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int Id, CategoryDto categoryDto) =>
            Ok(await _sender.Send(new UpdateCategoryCommand(Id,categoryDto)));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int Id) =>
            Ok(await _sender.Send(new DeleteCategoryCommand(Id)));
    }
}
