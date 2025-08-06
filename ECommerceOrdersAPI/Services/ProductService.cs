using ECommerceOrdersAPI.Data;
using ECommerceOrdersAPI.Models;

namespace ECommerceOrdersAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db) => _db = db;

        public IEnumerable<Product> GetAll() => _db.Products.ToList();

        public Product? GetById(int id) => _db.Products.Find(id);

        public Product Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _db.Products.Find(id);
            if (p != null)
            {
                _db.Products.Remove(p);
                _db.SaveChanges();
            }
        }
    }
}
