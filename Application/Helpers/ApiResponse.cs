using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Helpers
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Discription { get; set; }
        public ApiResponse(object data, int statusCode, string title, string message, string discription) 
        {
            Data = data;
            StatusCode = statusCode;
            Title = title;
            Message = message;
            Discription = discription;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
