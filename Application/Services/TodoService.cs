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
    public class TodoService : Service<Todo, TodoDto, TodoVm>, ITodoService
    {
        public TodoService(
        IUnitOfWork unitOfWork, 
        IMapper mapper,
        IRepository<Todo> repository) : base(unitOfWork, mapper, repository)
        {

        }

        public async Task<TodoVm> Getduplicate(TodoDto dto)
        {
            if (dto == null) return null;
            var model = _mapper.Map<Todo>(dto);
            var matchingModel = await _unitOfWork.TodoRepository.GetDuplicate(model);
            if(matchingModel==null)
            {
                return null;
            }
            else
            {
                var vm = _mapper.Map<TodoVm>(matchingModel);
                return vm;
            }
        }
    }
}
