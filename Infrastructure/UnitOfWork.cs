using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ITodoGroupRepository TodoGroupRepository { get; }
        public ITodoListRepository TodoListRepository { get; }
        public ITodoRepository TodoRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            TodoGroupRepository = new TodoGroupRepository(_context);
            TodoListRepository = new TodoListRepository(_context);
            TodoRepository = new TodoRepository(_context);

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
