namespace GestionProductos.Application.Dtos;

public record ProductRequest(string Name, string Description, decimal Price, int Stock);
