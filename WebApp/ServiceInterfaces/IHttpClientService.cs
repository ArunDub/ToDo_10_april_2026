using Application.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface IHttpClientService:IDisposable
    {
        Task<ApiResponse> Get(string Path, bool addAuthHeader);
        //Task<ApiResponse> Get(string Path, bool AddAuthHeader, int id);
        //Task<ApiResponse> Post(string Path, bool AddAuthHeader, object model);
        //Task<ApiResponse> Put(string Path, bool AddAuthHeader, int id, object model);
        //Task<ApiResponse> Delete(string Path, bool AddAuthHeader, int id);

    }
}
