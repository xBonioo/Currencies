﻿using Currencies.Contracts.Helpers.Exceptions;
using Currencies.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Currencies.Api.Middleware;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException validationException)
        {
            var response = new BaseResponse<IEnumerable<ValidationFailure>>
            {
                ResponseCode = StatusCodes.Status422UnprocessableEntity,
                Message = $"One or more validation errors has occurred.",
                BaseResponseError = validationException.Errors
                    .Select(x => new BaseResponseError(x.PropertyName, x.ErrorCode, x.ErrorMessage)).ToList()
            };
            logger.LogError("One or more validation errors has occurred.");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (BadRequestException badRequestException)
        {
            var response = new BaseResponse<IEnumerable<string>>
            {
                ResponseCode = StatusCodes.Status400BadRequest,
                Message = $"Some server error has occurred. {badRequestException.Message}"
            };
            logger.LogError($"Some server error has occurred. {badRequestException.Message}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (NotFoundException notFoundException)
        {
            var response = new BaseResponse<IEnumerable<string>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"The item you were looking for was not found. {notFoundException.Message}"
            };
            logger.LogError($"The item you were looking for was not found. {notFoundException.Message}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (DbUpdateException dbException)
        {
            var response = new BaseResponse<IEnumerable<string>>
            {
                ResponseCode = StatusCodes.Status500InternalServerError,
                Message = $"{dbException.Message}"
            };
            logger.LogError($"{dbException.Message}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception)
        {
            var response = new BaseResponse<string>
            {
                ResponseCode = StatusCodes.Status500InternalServerError,
                Message = "Some server error has occured."
            };
            logger.LogCritical("Some server error has occured.");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}