using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Laudex.Models;

[ExcludeFromCodeCoverage]
public class ErrorMessageResult
{
    public ErrorMessageResult(string code = APIEvents.General, string message = null, string correlationId = null)
    {
        Error = new Error
        {
            Code = code,
            CorrelationId = correlationId,
            Message = message
        };
    }

    [JsonProperty("error")] public Error Error { get; set; }
}

[ExcludeFromCodeCoverage]
public class Error
{
    [JsonProperty("code")] public string Code { get; set; }
    [JsonProperty("message")] public string Message { get; set; }
    [JsonProperty("correlationId")] public string CorrelationId { get; set; }
}

[ExcludeFromCodeCoverage]
public class APIEvents
{
    public const string General = "General";
    public const string Unauthorized = "Unauthorized";
    public const string NotFound = "NotFound";
    public const string InvalidArgument = "InvalidArgument";
    public const string BadRequest = "BadRequest";
    public const string Infra = "Infa";
    public const string Unknown = "Unknown";
    public const string Cache = "Cache";
    public const string Data = "Data";
    public const string PreConditionFailure = "PreConditionFailure";
}