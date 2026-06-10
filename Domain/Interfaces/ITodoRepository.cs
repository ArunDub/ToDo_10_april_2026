using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITodoRepository:IRepository<Todo> 
    {
        Task<Todo> GetDuplicate(Todo model);
    }
}
