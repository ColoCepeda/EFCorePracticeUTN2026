using GestionProductos.Application.Dtos;
using GestionProductos.Application.Interfaces;
using GestionProductos.Domain.Entities;
using GestionProductos.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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

    [HttpPost]
    [Authorize]
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

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var product = productRepository.GetById(id)
            ?? throw new NotFoundException($"No existe el producto con id {id}");

        productRepository.Delete(product);

        return NoContent();
    }
}
