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

        public Task<ApiResponse> Delete(string Path, bool AddAuthHeader, int id)
        {
            throw new NotImplementedException();
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

        public async Task<ApiResponse> Get(string Path, bool addAuthHeader, int Id) 
        {
            if (addAuthHeader == false)
                return await GetResponse(Path,Id);


            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await GetResponse(Path,Id) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");

        }

        public Task<ApiResponse> Post(string Path, bool AddAuthHeader, object model)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Put(string Path, bool AddAuthHeader, int id, object model)
        {
            throw new NotImplementedException();
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
        //private async Task<ApiResponse> GetResponse(string Path, int Id)
        //{
        //    var httpResponseMessasge = await _httpclient.GetAsync($"{Path}/{Id}");
        //    return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        //}
        private async Task<ApiResponse> GetResponse(string Path,int Id,bool AddAuthHeader)
        {
            if(AddAuthHeader==false)
            {
                return await GetResponse(Path);
            }
            var httpResponseMessasge = await _httpclient.GetAsync($"{ Path}/{ Id}");
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
        private async Task<ApiResponse> PostResponse(string Path, object model)
        {
            var httpResponseMessasge = await _httpclient.PostAsJsonAsync(Path,model);
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
        private async Task<ApiResponse> PutResponse(string Path,int Id, object model)
        {
            var httpResponseMessasge = await _httpclient.PutAsJsonAsync($"{Path}/{Id}", model);
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
        private async Task<ApiResponse> DeleteResponse(string Path, int Id )
        {
            var httpResponseMessasge = await _httpclient.DeleteAsync($"{Path}/{Id}");
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }
}
