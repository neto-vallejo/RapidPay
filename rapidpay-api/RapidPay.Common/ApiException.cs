using System.Net;

namespace RapidPay.Common
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<String> Errors { get; set; }


        public ApiException() : this(HttpStatusCode.InternalServerError) { }

        public ApiException(HttpStatusCode statusCode)
            : base("API Error")
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, params String[] errors)
            : this(statusCode)
        {
            Errors = errors;
        }
    }
}
