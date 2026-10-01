using GestionProductos.Domain.Entities;

namespace GestionProductos.Application.Interfaces;

public interface IUserRepository
{
    User? GetByUserName(string userName);
}
