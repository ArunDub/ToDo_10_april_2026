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
    public class TodoGroupService : Service<TodoGroup, TodoGroupDto, TodoGroupVm>, ITodoGroupService
    {
        public TodoGroupService(
        IUnitOfWork unitOfWork, 
        IMapper mapper,
        IRepository<TodoGroup> repository) : base(unitOfWork, mapper, repository)
        {

        }

        public async Task<TodoGroupVm> Getduplicate(TodoGroupDto dto)
        {
            if (dto == null) return null;
            var model = _mapper.Map<TodoGroup>(dto);
            var matchingModel = await _unitOfWork.TodoGroupRepository.GetDuplicate(model);
            if(matchingModel==null)
            {
                return null;
            }
            else
            {
                var vm = _mapper.Map<TodoGroupVm>(matchingModel);
                return vm;
            }
        }
    }
}
