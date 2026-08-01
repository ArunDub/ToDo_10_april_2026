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
        private async Task<bool> AddAuthHeader()
        {
            throw new NotImplementedException();
        }
        #region Httpverbs
        public async Task<ApiResponse> Get(string Path, bool addAuthHeader)
        {
            if (addAuthHeader == false)
                return await GetResponse(Path);
            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await GetResponse(Path) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");

        }
        public async Task<ApiResponse> Get(string Path, bool addAuthHeader, int Id)
        {
            if (addAuthHeader == false)
                return await GetResponse(Path, Id);
            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await GetResponse(Path, Id) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");

        }

        public async  Task<ApiResponse> Post(string Path, bool addAuthHeader, object model)
        {
            if (addAuthHeader == false)
                return await PostResponse(Path,model);
            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await PostResponse(Path,model) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");


        }

        public async Task<ApiResponse> Put(string Path, bool addAuthHeader, int id, object model)
        {
            if (addAuthHeader == false)
                return await PutResponse(Path,id, model);
            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await PutResponse(Path,id, model) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");

        }

        public async Task<ApiResponse> Delete(string Path, bool addAuthHeader, int id)
        {
            if (addAuthHeader == false)
                return await DeleteResponse(Path, id);
            bool AuthHeaderAdded = await AddAuthHeader();
            return AuthHeaderAdded == true ? await DeleteResponse(Path, id) : ApiResponseBuilder.GenerateUnAuthorized("UnAuthorized", "Pls Login");

        }
        #endregion
        #region Response Getter
        private async Task<ApiResponse> GetResponse(string Path)
        {
            var httpResponseMessasge = await _httpclient.GetAsync(Path);
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }

        private async Task<ApiResponse> GetResponse(string Path, int Id)
        {
            var httpResponseMessasge = await _httpclient.GetAsync($"{Path}/{Id}");
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }

        private async Task<ApiResponse> PostResponse(string Path, object model)
        {
            var httpResponseMessasge = await _httpclient.PostAsJsonAsync(Path, model);
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }

        private async Task<ApiResponse> PutResponse(string Path, int Id, object model)
        {
            var httpResponseMessasge = await _httpclient.PutAsJsonAsync($"{Path}/{Id}", model);
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
        private async Task<ApiResponse> DeleteResponse(string Path, int Id)
        {
            var httpResponseMessasge = await _httpclient.DeleteAsync($"{Path}/{Id}");
            return await httpResponseMessasge.Content.ReadFromJsonAsync<ApiResponse>();
        }
        #endregion     

        public void Dispose()
        {
            _httpclient?.Dispose();
        }
    }
}
