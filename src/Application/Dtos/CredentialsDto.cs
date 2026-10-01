namespace GestionProductos.Application.Dtos;

// Credenciales que llegan en el body del endpoint de login
public record CredentialsDto(string UserName, string Password);
