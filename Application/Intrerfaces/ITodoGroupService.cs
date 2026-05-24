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
    public interface ITodoGroupService:IService<TodoGroup,TodoGroupDto,TodoGroupVm>
    {
        Task<TodoGroupVm> Getduplicate(TodoGroupDto dto);
    }
}
