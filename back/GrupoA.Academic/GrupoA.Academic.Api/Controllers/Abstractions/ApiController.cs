using GrupoA.Academic.Application.Abstractions.Models;
using GrupoA.Academic.Commom.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GrupoA.Academic.Api.Controllers.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly INotificationContext notificationContext;
    protected readonly IMediator mediator;

    public const int PageSize = 25;
    public const int Page = 1;

    protected ApiController(IMediator mediator, INotificationContext notificationContext)
    {
        this.mediator = mediator;
        this.notificationContext = notificationContext;
    }
    protected ActionResult<T> AcademicResponse<T>(T result, bool noContent = false)
    {
        return noContent ? NoContent() : Ok(result);
    }

    protected IActionResult AcademicResponse()
    {
        return NoContent();
    }

    protected ActionResult<T> AcademicResponse<T>(CommandResult<T> result, bool update = true, string actionName = "", Guid? id = null)
    {

        var route = new
        {
            id = id,
            version = HttpContext.GetRequestedApiVersion()?.ToString()
        };

        return update ? Ok(result.Result) : CreatedAtAction(actionName, route, result.Result);
    }
}