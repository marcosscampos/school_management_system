using System.Net;

namespace SMS.Submissions.Api.Common.Responses;

public class NonSuccessResponse
{
    public NonSuccessResponse()
    {
        
    }

    public NonSuccessResponse(IDictionary<string, string> errors, HttpStatusCode statusCode)
    {
        Errors = errors;
        Status = statusCode;
    }
    
    public HttpStatusCode Status { get; set; } = HttpStatusCode.BadRequest;
    public string Message { get; set; } = "Not Processed";
    public IDictionary<string, string>? Errors { get; } = null;
}