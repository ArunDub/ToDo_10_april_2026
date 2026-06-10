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
            //TodoGroup
            CreateMap<TodoGroupDto, TodoGroup>();
            CreateMap<TodoGroup, TodoGroupDto>();
            CreateMap<TodoGroup, TodoGroupVm>();
            //TodoList
            CreateMap<TodoListDto, TodoList>();
            CreateMap<TodoList, TodoListDto>();
            CreateMap<TodoList, TodoListVm>();
            //Todo
            CreateMap<TodoDto, Todo>();
            CreateMap<Todo, TodoDto>();
            CreateMap<Todo, TodoVm>();
        }
    }
}
