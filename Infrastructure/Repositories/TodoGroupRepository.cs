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
    public class TodoGroupRepository : Repository<TodoGroup>, ITodoGroupRepository
    {
        public TodoGroupRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<TodoGroup> GetDuplicate(TodoGroup model)
        {
            return _appDbContext.TodoGroups.FirstOrDefaultAsync(x => x.GroupName.Equals(model.GroupName));

        }
    }
}
