using Application.Helpers;
using System.Runtime.CompilerServices;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpclient;
        public HttpClientService(IHttpClientFactory httpclient)
        {
            _httpclient = httpclient.CreateClient("WebApiClient");
        }
        public void Dispose()
        {
            _httpclient?.Dispose();
        }

        public async Task<ApiResponse> Get(string Path, bool addAuthHeader)
        {
            if(addAuthHeader==false)            
             return await GetResponse(Path);
            

            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await GetResponse(Path) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");
           
        }
        private Task<bool> AddAuthHeader() 
        {
            throw new NotImplementedException();
        }
        private async Task<ApiResponse>GetResponse(string Path)
        {
            var httpResponseMessasge = await _httpclient.GetAsync(Path);
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }
}
