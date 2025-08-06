using ECommerceOrdersAPI.Models;

namespace ECommerceOrdersAPI.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        Customer Create(Customer customer);

    }
}
