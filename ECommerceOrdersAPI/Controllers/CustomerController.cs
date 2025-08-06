using ECommerceOrdersAPI.DTOs;
using ECommerceOrdersAPI.Models;
using ECommerceOrdersAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrdersAPI.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class CustomerController : Controller
        {
            private readonly ICustomerService _svc;
            public CustomerController(ICustomerService svc) => _svc = svc;

            [HttpGet]
            public IActionResult GetAll() => Ok(_svc.GetAll());

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var c = _svc.GetById(id);
                return c == null ? NotFound() : Ok(c);
            }

            [HttpPost]
            public IActionResult Create([FromBody] CustomerDto dto)
            {
                var cust = new Customer { Name = dto.Name, Email = dto.Email };
                var created = _svc.Create(cust);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
        }
    }

