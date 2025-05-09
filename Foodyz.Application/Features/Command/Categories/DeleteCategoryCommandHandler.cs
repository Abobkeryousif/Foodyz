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

namespace Foodyz.Application.Features.Command.Categories
{
    public record DeleteCategoryCommand(int Id) : IRequest<HttpResponse<string>>;
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, HttpResponse<string>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)=>
            _categoryRepository = categoryRepository;
        public async Task<HttpResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deletedCategory = await _categoryRepository.FirstOrDefaultAsync(c=> c.Id == request.Id);
            if (deletedCategory is null)
                return new HttpResponse<string>(HttpStatusCode.NotFound, $"Not Found With ID: {request.Id}");

            await _categoryRepository.DeleteAsync(deletedCategory);
            return new HttpResponse<string>(HttpStatusCode.OK,"Seccuss Delete Opration");
            
                
            
        }
    }
}
