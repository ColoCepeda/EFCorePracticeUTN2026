using GestionProductos.Application.Interfaces;
using GestionProductos.Domain.Entities;
using GestionProductos.Infrastructure.Persistence;

namespace GestionProductos.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public User? GetByUserName(string userName) =>
        context.Users.FirstOrDefault(u => u.UserName == userName);
}
