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

namespace Foodyz.Application.Features.Command.Categories
{
    public record UpdateCategoryCommand(int Id , CategoryDto categoryDto) : IRequest<HttpResponse<Category>>;
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, HttpResponse<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)=>
         _categoryRepository = categoryRepository;
        
        public async Task<HttpResponse<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(c=> c.Id == request.Id);
            if (category == null)
                return new HttpResponse<Category>(HttpStatusCode.NotFound,$"Not Found With ID: {request.Id}");

            category.Name = request.categoryDto.Name;
            await _categoryRepository.UpdateAsync(category);

            return new HttpResponse<Category>(HttpStatusCode.OK,"Seccuss Update Opration",category);
        }
    }
}
