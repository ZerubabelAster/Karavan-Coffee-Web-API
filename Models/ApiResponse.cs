using System.Net;

namespace KaravanCoffeeWebAPI.Models
{

    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public ApiResponse(HttpStatusCode statusCode, string message, object result = null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
    }
}
