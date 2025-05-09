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

public record GetCategoryQuery : IRequest<HttpResponse<List<Category>>>;
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, HttpResponse<List<Category>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)=>
        _categoryRepository = categoryRepository;
        
        public async Task<HttpResponse<List<Category>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            if (category.Count == 0)
                return new HttpResponse<List<Category>>(HttpStatusCode.NotFound,"Not Found!");

            return new HttpResponse<List<Category>>(HttpStatusCode.OK,"Seccuss Opration",category);
        }
    }

