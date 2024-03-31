using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.Category.Commands.CreateCategory;
using ToDoApp.Application.Features.Category.Commands.UpdateCategory;
using ToDoApp.Application.Features.Category.Queries.GetAllCategories;
using ToDoApp.Application.Features.Category.Queries.GetCategoryById;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.MappingProfiles
{
	public class CategoryMappingProfile : Profile
	{
        public CategoryMappingProfile()
        {
            CreateMap<GetAllCategoriesDto,Category>().ReverseMap();
			CreateMap<Category, GetCategoryByIdDto>();
			CreateMap<CreateCategoryCommand, Category>();
			CreateMap<UpdateCategoryCommand, Category>();
		}
	}
}
