using System.Net;

namespace MetrcAPIService;

public class ForbiddenRequestException : MetrcApiException
{
    public ForbiddenRequestException() : base() { }

    public ForbiddenRequestException(HttpStatusCode statusCode, string response) : base("The authenticated user does not have access to the requested resource.", statusCode, response) { }
}