using GestionProductos.Application.Interfaces;
using GestionProductos.Domain.Entities;
using GestionProductos.Infrastructure.Persistence;

namespace GestionProductos.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public IEnumerable<Product> GetAll() => context.Products.ToList();

    public Product? GetById(int id) => context.Products.Find(id);

    public void Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Delete(Product product)
    {
        context.Products.Remove(product);
        context.SaveChanges();
    }
}
