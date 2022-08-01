using System.Diagnostics;
using Library.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[AllowAnonymous]
public class ErrorController:ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            BookNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Ad unexpected error occured")
        };
        
        return Problem(statusCode:statusCode, detail:message);
    }
}