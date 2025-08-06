using ECommerceOrdersAPI.DTOs;
using ECommerceOrdersAPI.Models;

namespace ECommerceOrdersAPI.Services
{
    public interface IOrderService
    {
        Order? PlaceOrder(OrderDto dto);
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
    }
}

