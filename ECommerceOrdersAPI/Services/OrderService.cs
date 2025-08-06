using ECommerceOrdersAPI.Data;
using ECommerceOrdersAPI.DTOs;
using ECommerceOrdersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrdersAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db) => _db = db;

        public IEnumerable<Order> GetAll() => _db.Orders.Include(o => o.Items).ToList();

        public Order? GetById(int id) => _db.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.Id == id);

        public Order? PlaceOrder(OrderDto dto)
        {
            var customer = _db.Customers.Find(dto.CustomerId);
            if (customer == null) return null;

            // Validate stock availability
            var products = _db.Products.Where(p => dto.Items.Any(i => i.ProductId == p.Id)).ToList();
            foreach (var item in dto.Items)
            {
                var prod = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (prod == null || prod.QuantityInStock < item.Quantity)
                    return null;
            }

            var order = new Order { CustomerId = dto.CustomerId, OrderDate = DateTime.UtcNow };
            _db.Orders.Add(order);
            _db.SaveChanges();

            foreach (var item in dto.Items)
            {
                var prod = products.First(p => p.Id == item.ProductId);
                prod.QuantityInStock -= item.Quantity;

                var line = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = prod.Id,
                    Quantity = item.Quantity,
                    UnitPrice = prod.Price
                };
                _db.OrderItems.Add(line);
            }

            _db.SaveChanges();
            return order;
        }
    }
}

