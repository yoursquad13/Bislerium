using System.Net;

namespace Application.DTOs.Base
{
    public class ResponseDto<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }

        public int? TotalCount { get; set; }

        public T Data { get; set; }
    }
}
