using ECommerceOrdersAPI.DTOs;
using ECommerceOrdersAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
      
        private readonly IOrderService _svc;
            public OrderController(IOrderService svc) => _svc = svc;

            [HttpGet]
            public IActionResult GetAll() => Ok(_svc.GetAll());

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var o = _svc.GetById(id);
                return o == null ? NotFound() : Ok(o);
            }

            [HttpPost]
            public IActionResult PlaceOrder([FromBody] OrderDto dto)
            {
                var order = _svc.PlaceOrder(dto);
                return order == null ? BadRequest("Order failed—check customer or stock") : CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
            }
        }

    }
