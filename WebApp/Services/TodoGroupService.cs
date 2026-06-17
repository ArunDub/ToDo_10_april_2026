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

        public Task<ApiResponse> Get(int Id)
        {
            throw new NotImplementedException();
        }
        //public Task<ApiResponse> Create(TodoGroupDto dto)
        //{
        //    throw new NotImplementedException();
        //}     
        //public Task<ApiResponse> Edit(int Id, TodoGroupDto modelDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ApiResponse> Delete(int Id)
        //{
        //    throw new NotImplementedException();
        //}
               
    }
}
