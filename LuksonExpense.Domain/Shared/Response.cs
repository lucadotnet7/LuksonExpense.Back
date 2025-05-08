using System.Net;
using System.Text.Json.Serialization;

namespace LuksonExpense.Domain.Shared
{
    public class Response<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Content { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ErrorResponse? Error { get; set; }

        public Response()
        {
        }

        public Response(HttpStatusCode statusCode, T content)
        {
            StatusCode = statusCode;
            Content = content;
        }
    }

    public class ErrorResponse
    {
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
