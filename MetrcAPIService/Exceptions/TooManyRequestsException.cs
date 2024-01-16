using System.Net;

namespace MetrcAPIService;

public class TooManyRequestsException : MetrcApiException
{
    public TooManyRequestsException() : base() { }

    public TooManyRequestsException(HttpStatusCode statusCode, string response) : base("The limit of API calls allowed has been exceeded. Please pace the usage rate of the API more apart.", statusCode, response) { }
}