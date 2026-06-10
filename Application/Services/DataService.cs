using Application.Intrerfaces;
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
    public class DataService : IDataService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
        public ITodoGroupService TodoGroupService { get; }
        public ITodoListService TodoListService { get; } 
        public ITodoService TodoService { get; }
        public DataService(
         IUnitOfWork unitOfWork,
         IMapper mapper,
         IRepository<TodoGroup>todoGroupsRepo,
         IRepository<TodoList>todoListsRepo,
         IRepository<Todo>todosRepo            
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            TodoGroupService = new TodoGroupService(_unitOfWork, _mapper, todoGroupsRepo);
            TodoListService = new TodoListService(_unitOfWork, _mapper, todoListsRepo);
            TodoService = new TodoService(_unitOfWork, _mapper, todosRepo);

        }
    }
}
