using GestionProductos.Application.Dtos;
using GestionProductos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace GestionProductos.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController(ICustomAuthenticationService authenticationService) :
ControllerBase
{
    [HttpPost("authenticate")]
    public ActionResult<string> Autenticar([FromBody] CredentialsDto credentials)
    {
        string token = authenticationService.Autenticar(credentials);
        return Ok(token);
    }
}
