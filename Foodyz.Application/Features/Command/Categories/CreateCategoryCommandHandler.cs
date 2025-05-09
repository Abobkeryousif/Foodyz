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

namespace Foodyz.Application.Features.Command.Categories
{
    public record CreateCategoryCommand(CategoryDto categoryDto) : IRequest<HttpResponse<CategoryDto>>;
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, HttpResponse<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<HttpResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var IsExist = await _categoryRepository.IsExist(n=> n.Name.ToLower() == request.categoryDto.Name.ToLower());
            if (IsExist)
                return new HttpResponse<CategoryDto>(HttpStatusCode.BadRequest,"This Category Already Added!");
            var category = _mapper.Map<Category>(request.categoryDto);
            await _categoryRepository.CreateAsync(category);

            return new HttpResponse<CategoryDto>(HttpStatusCode.OK, "Seccuss Opration",request.categoryDto);
            
        }
    }
}
