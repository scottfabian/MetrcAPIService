using System.Net;

namespace MetrcAPIService;

public class BadRequestException : MetrcApiException
{
    public BadRequestException() : base() { }

    public BadRequestException(HttpStatusCode statusCode, string response) : base("Bad Request", statusCode, response) { }

    public BadRequestException(HttpStatusCode statusCode, string response, string requestURL) : base("Bad Request", statusCode, response, requestURL) { }
}