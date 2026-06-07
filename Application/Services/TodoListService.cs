using Application.Dtos;
using Application.Intrerfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TodoListService : Service<TodoList, TodoListDto, TodoListVm>, ITodoListService
    {
        public TodoListService(
        IUnitOfWork unitOfWork, 
        IMapper mapper,
        IRepository<TodoList> repository) : base(unitOfWork, mapper, repository)
        {

        }

        public async Task<TodoListVm> Getduplicate(TodoListDto dto)
        {
            if (dto == null) return null;
            var model = _mapper.Map<TodoList>(dto);
            var matchingModel = await _unitOfWork.TodoListRepository.GetDuplicate(model);
            if(matchingModel==null)
            {
                return null;
            }
            else
            {
                var vm = _mapper.Map<TodoListVm>(matchingModel);
                return vm;
            }
        }
    }
}
