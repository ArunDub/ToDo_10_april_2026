using Application.Dtos;
using Application.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface ITodoGroupService
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(int Id);
        Task<ApiResponse> Create(TodoGroupDto dto);
        Task<ApiResponse> Edit(int Id, TodoGroupDto modelDto);
        Task<ApiResponse> Delete(int Id);
    }
}
