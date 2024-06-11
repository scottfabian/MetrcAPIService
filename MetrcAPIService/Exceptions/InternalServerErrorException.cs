using System.Net;

namespace MetrcAPIService;

public class InternalServerErrorException : MetrcApiException
{
    public InternalServerErrorException() : base() { }

    public InternalServerErrorException(HttpStatusCode statusCode, string response) : base("An error has occurred while executing your request. The error message is typically included in the body of the response.", statusCode, response) { }

    public InternalServerErrorException(HttpStatusCode statusCode, string response, string requestURL) : base("An error has occurred while executing your request. The error message is typically included in the body of the response.", statusCode, response, requestURL) { }
}