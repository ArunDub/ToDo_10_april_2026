using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TodoListRepository : Repository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<TodoList> GetDuplicate(TodoList model)
        {
            return _appDbContext.TodoLists.FirstOrDefaultAsync(x => x.ListName.Equals(model.ListName));

        }
    }
}
