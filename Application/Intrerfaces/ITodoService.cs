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
    public interface ITodoService:IService<Todo,TodoDto,TodoVm>
    {
        Task<TodoVm> Getduplicate(TodoDto dto);
    }
}
