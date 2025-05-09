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

namespace Foodyz.Application.Features.Query.Categories
{
    public record GetByIdCategoryQuery(int Id): IRequest<HttpResponse<Category>>;
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, HttpResponse<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository)=>
        _categoryRepository = categoryRepository;
       public async Task<HttpResponse<Category>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.FirstOrDefaultAsync(c=> c.Id == request.Id);
            if (existCategory is null)
                return new HttpResponse<Category>(HttpStatusCode.NotFound,$"Not Found With ID: {request.Id}");

            return new HttpResponse<Category>(HttpStatusCode.OK, "Seccuss Opration", existCategory);
        }
    }
}
