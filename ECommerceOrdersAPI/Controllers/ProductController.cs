using ECommerceOrdersAPI.DTOs;
using ECommerceOrdersAPI.Models;
using ECommerceOrdersAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _svc;
        public ProductController(IProductService svc) => _svc = svc;

        [HttpGet]
        public IActionResult GetAll() => Ok(_svc.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _svc.GetById(id);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                QuantityInStock = dto.QuantityInStock
            };
            var created = _svc.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto dto)
        {
            var existing = _svc.GetById(id);
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.QuantityInStock = dto.QuantityInStock;
            _svc.Update(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _svc.Delete(id);
            return NoContent();
        }
    }

}
