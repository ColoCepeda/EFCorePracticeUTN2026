using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestionProductos.Application.Dtos;
using GestionProductos.Application.Interfaces;
using GestionProductos.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace GestionProductos.Infrastructure.Services;

public class AuthenticationService(IUserRepository userRepository, IConfiguration config) :
ICustomAuthenticationService
{
    public string Autenticar(CredentialsDto credentials)
    {
        // 1. ¿Existe el usuario y la contraseña es correcta?
        var user = userRepository.GetByUserName(credentials.UserName);
        if (user is null || user.Password != credentials.Password)
            throw new InvalidCredentialsException();
        // 2. Clave secreta + algoritmo de firma
        var securityKey = new SymmetricSecurityKey(
        Encoding.ASCII.GetBytes(config["Authentication:SecretForKey"]!));
        var signature = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        // 3. Claims que viajan en el payload
        var claimsForToken = new List<Claim>
{
new("sub", user.Id.ToString()),
new("given_name", user.UserName),
new("role", user.Role)
};
        // 4. El token: issuer, audience, claims, desde, hasta y firma
        var jwtSecurityToken = new JwtSecurityToken(
        config["Authentication:Issuer"],
        config["Authentication:Audience"],
        claimsForToken,
        DateTime.UtcNow,
        DateTime.UtcNow.AddHours(1),
        signature);
        // 5. Serializarlo a header.payload.signature
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
