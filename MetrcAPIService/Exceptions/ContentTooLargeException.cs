using System.Net;

namespace MetrcAPIService;

public class ContentTooLargeException : MetrcApiException
{
    public ContentTooLargeException() : base() { }

    public ContentTooLargeException(HttpStatusCode statusCode, string response) : base("The request exceeds the maximum number of objects allowed. See the Object Limiting section for details", statusCode, response) { }
}