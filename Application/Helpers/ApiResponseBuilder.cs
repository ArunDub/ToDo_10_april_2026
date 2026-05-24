using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class ApiResponseBuilder
    {
        public static ApiResponse GenerateOK(object data, int statusCode, string message, string discription)
        {
            return new ApiResponse(data, (int)HttpStatusCode.OK, "OK", message, discription);
        }
        public static ApiResponse GenerateInternalServerError(object data, int statusCode, string message, string discription)
        {
            return new ApiResponse(data, (int)HttpStatusCode.InternalServerError, "InternalServerError", message, discription);
        }
        public static ApiResponse GenerateBadRequest(string message, string discription)
        {
            return new ApiResponse(null, (int)HttpStatusCode.BadRequest, "Bad Request", message, discription);
        }
        public static ApiResponse GenerateUnAuthorized(string message, string discription)
        {
            return new ApiResponse(null, (int)HttpStatusCode.Unauthorized, "Un authorized", message, discription);
        }
        public static ApiResponse GenerateForbidden(string message, string discription)
        {
            return new ApiResponse(null, (int)HttpStatusCode.Forbidden, "Forbidden", message, discription);
        }
        public static ApiResponse GenerateNotfound(string message, string discription)
        {
            return new ApiResponse(null, (int)HttpStatusCode.NotFound, "NotFound", message, discription);
        }

    }
}
