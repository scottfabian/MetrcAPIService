using System.Net;

namespace MetrcAPIService;

public class MetrcApiException : Exception
{
    public HttpStatusCode StatusCode { get; private set; }
    public string Response {  get; private set; }


    public MetrcApiException() : base() { }

    public MetrcApiException(string message) : base(message) { }

    public MetrcApiException(string message, Exception ex) : base(message, ex) { }


    public MetrcApiException(HttpStatusCode statusCode, string response) : base() { }

    public MetrcApiException(string message, HttpStatusCode statusCode, string response) : base(message) { }

    public MetrcApiException(string message, Exception ex, HttpStatusCode statusCode, string response) : base(message, ex) { }
}
