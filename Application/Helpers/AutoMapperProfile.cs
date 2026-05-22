using Application.Dtos;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoGroupDto, TodoGroup>();
            CreateMap<TodoGroup, TodoGroupDto>();
            CreateMap<TodoGroup, TodoGroupVm>();
        }
    }
}
