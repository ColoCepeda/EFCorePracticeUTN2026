using GestionProductos.Application.Dtos;
namespace GestionProductos.Application.Interfaces;

public interface ICustomAuthenticationService
{
    string Autenticar(CredentialsDto credentials);
}
