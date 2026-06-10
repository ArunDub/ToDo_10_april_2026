using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Intrerfaces
{
    public interface IDataService
    {
        ITodoGroupService TodoGroupService { get; }
        ITodoListService TodoListService { get; }
        ITodoService TodoService { get; } 

    }
}
