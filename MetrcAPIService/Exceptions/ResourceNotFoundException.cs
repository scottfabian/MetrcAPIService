using System.Net;

namespace MetrcAPIService;

public class ResourceNotFoundException : MetrcApiException
{
    public ResourceNotFoundException() : base() { }

    public ResourceNotFoundException(HttpStatusCode statusCode, string response) : base("The requested resource could not be found (incorrect or invalid URI)", statusCode, response) { }

    public ResourceNotFoundException(HttpStatusCode statusCode, string response, string requestURL) : base("The requested resource could not be found (incorrect or invalid URI)", statusCode, response, requestURL) { }
}