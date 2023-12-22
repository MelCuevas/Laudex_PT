using Laudex.Models;
using Laudex.Models.Constants;
using Laudex.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
namespace Laudex.UI.Middlewares;

public static class GlobalExceptionHandler
{
    public static async Task HandleExceptionAsync(HttpContext context)
    {
        var ex = context.Features.Get<IExceptionHandlerFeature>();
        var exception = ex.Error;
        var statusCode = HttpStatusCode.OK;

        ErrorMessageResult result = null;

        switch (exception)
        {
            case FailedToAddException:
            case FailedToUpdateException:
            case FailedToGetAllException:
            case FailedToGetByIdException:
            case FailedToRemoveException:
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    result = new ErrorMessageResult(
                        APIEvents.BadRequest,
                        exception.Message,
                        "correlation-id"
                    );

                    break;
                }
            case MissingRequiredFieldException:
                {
                    statusCode = HttpStatusCode.BadRequest;
                    result = new ErrorMessageResult(
                        APIEvents.BadRequest,
                        exception.Message,
                        "correlation-id"
                    );

                    break;
                }
            default:
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    result = new ErrorMessageResult(
                        APIEvents.Unknown,
                        exception.Message != null ? exception.Message : Constants.Error_UnknownException,
                        "correlation-id"
                    );

                    break;
                }
        }

        if (result != null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
        }
    }
}