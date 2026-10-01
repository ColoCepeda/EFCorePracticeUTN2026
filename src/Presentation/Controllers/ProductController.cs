using GestionProductos.Application.Dtos;
using GestionProductos.Application.Interfaces;
using GestionProductos.Domain.Entities;
using GestionProductos.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GestionProductos.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(productRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = productRepository.GetById(id)
            ?? throw new NotFoundException($"No existe el producto con id {id}");

        return Ok(product);
    }

    // [CLASE JWT] Paso 7: proteger con [Authorize]
    [HttpPost]
    public ActionResult<Product> Create([FromBody] ProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock
        };

        productRepository.Add(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // [CLASE JWT] Paso 7: proteger con [Authorize] y permitir solo el rol Admin
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = productRepository.GetById(id)
            ?? throw new NotFoundException($"No existe el producto con id {id}");

        productRepository.Delete(product);

        return NoContent();
    }
}
