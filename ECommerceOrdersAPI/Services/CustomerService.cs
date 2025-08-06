using ECommerceOrdersAPI.Data;
using ECommerceOrdersAPI.Models;

namespace ECommerceOrdersAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;
        public CustomerService(ApplicationDbContext db) => _db = db;

        public IEnumerable<Customer> GetAll() => _db.Customers.ToList();

        public Customer? GetById(int id) => _db.Customers.Find(id);

        public Customer Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return customer;
        }
    }
}
