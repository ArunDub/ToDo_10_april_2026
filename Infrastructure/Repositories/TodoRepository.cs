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
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<Todo> GetDuplicate(Todo model)
        {
            return _appDbContext.Todos.FirstOrDefaultAsync(x => x.TodoItem.Equals(model.TodoItem));

        }
    }
}
