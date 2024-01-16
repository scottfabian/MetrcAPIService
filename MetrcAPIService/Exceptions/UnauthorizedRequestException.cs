using System.Net;

namespace MetrcAPIService;

public class UnauthorizedRequestException : MetrcApiException
{
    public UnauthorizedRequestException() : base() { }

    public UnauthorizedRequestException(HttpStatusCode statusCode, string response) : base("Invalid or no authentication provided.", statusCode, response) { }
}
