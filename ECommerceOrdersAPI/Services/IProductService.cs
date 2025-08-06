using ECommerceOrdersAPI.Models;

namespace ECommerceOrdersAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product Create(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}
