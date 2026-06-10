using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public ITodoGroupRepository TodoGroupRepository { get; }
        public ITodoListRepository TodoListRepository { get; }
        public ITodoRepository TodoRepository { get; } 

        Task<int> SaveChanges();
    }
}
