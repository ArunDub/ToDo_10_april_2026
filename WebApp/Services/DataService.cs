using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class DataService : IDataService
    {
        private readonly IHttpClientService _httpClientService;
        public ITodoGroupService TodoGroup { get; }
        public DataService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            TodoGroup = new TodoGroupService(_httpClientService);
        }        
    }
}
