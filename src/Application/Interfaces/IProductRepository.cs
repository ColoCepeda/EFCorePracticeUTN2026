using GestionProductos.Domain.Entities;

namespace GestionProductos.Application.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    void Add(Product product);
    void Delete(Product product);
}
