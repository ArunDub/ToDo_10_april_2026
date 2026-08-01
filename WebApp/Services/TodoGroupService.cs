using Application.Dtos;
using Application.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class TodoGroupService : ITodoGroupService
    {
        private readonly IHttpClientService _httpClientService;
        public TodoGroupService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<ApiResponse> Get()
        {
            return await _httpClientService.Get("TodoGroups/Get", false);
        }

        public async Task<ApiResponse> Get(int Id)
        {
            return await _httpClientService.Get("TodoGroups/Get", false,Id);
        }  
        public async Task<ApiResponse> Create(TodoGroupDto dto)
        {
            return await _httpClientService.Post("TodoGroups/Create", false, dto);
        }
        public async Task<ApiResponse> Edit(int Id, TodoGroupDto modelDto)
        {
            return await _httpClientService.Put("TodoGroups/Update", false, Id, modelDto);
        }

        public async Task<ApiResponse> Delete(int Id)
        {
            return await _httpClientService.Delete("TodoGroups/Delete", false, Id);
        }

    }
}
