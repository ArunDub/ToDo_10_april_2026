using Application.Dtos;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Intrerfaces
{
    public interface ITodoListService:IService<TodoList,TodoListDto,TodoListVm>
    {
        Task<TodoListVm> Getduplicate(TodoListDto dto);
    }
}
