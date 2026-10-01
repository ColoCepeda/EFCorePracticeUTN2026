namespace GestionProductos.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;

    // Solo para la práctica: en un sistema real se guarda el HASH de la contraseña, nunca el texto plano
    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = "User";
}
