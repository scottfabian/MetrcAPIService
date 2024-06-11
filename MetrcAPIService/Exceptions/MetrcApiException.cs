using System.Net;

namespace MetrcAPIService;

public class MetrcApiException : Exception
{
    public HttpStatusCode StatusCode { get; private set; }
    public string Response {  get; private set; }
    public string RequestURL { get; private set; }


    public MetrcApiException() : base() { }

    public MetrcApiException(string message) : base(message) { }

    public MetrcApiException(string message, Exception ex) : base(message, ex) { }


    public MetrcApiException(HttpStatusCode statusCode, string response) : base() { this.StatusCode = statusCode; this.Response = response; }

    public MetrcApiException(HttpStatusCode statusCode, string response, string requestURL) : base() { this.StatusCode = statusCode; this.Response = response; this.RequestURL = requestURL; }

    public MetrcApiException(string message, HttpStatusCode statusCode, string response) : base(message) { this.StatusCode = statusCode; this.Response = response; }

    public MetrcApiException(string message, HttpStatusCode statusCode, string response, string requestURL) : base(message) { this.StatusCode = statusCode; this.Response = response; this.RequestURL = requestURL }

    public MetrcApiException(string message, Exception ex, HttpStatusCode statusCode, string response) : base(message, ex) { this.StatusCode = statusCode; this.Response = response; }
}
