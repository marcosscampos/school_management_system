﻿using System.Net;
using SMS.Submissions.Api.Common.Responses;
using SMS.Submissions.CrossCutting.Exceptions;

namespace SMS.Submissions.Api.Common.Handlers;

public static class ErrorHandler
{
    public static NonSuccessResponse Create(Exception ex) => ex switch
    {
        BadRequestException e => new NonSuccessResponse(e.Errors, HttpStatusCode.BadRequest),
        NotFoundException e => new NonSuccessResponse
        {
            Message = e.Message,
            Status = HttpStatusCode.NotFound
        },
        _ => new NonSuccessResponse(new Dictionary<string, string>
        {
            { ex.GetType().Name, ex.Message }
        }, HttpStatusCode.BadRequest)
    };
}