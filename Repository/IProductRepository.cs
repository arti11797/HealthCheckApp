using HealthCheckApp.Models;

namespace HealthCheckApp.Repository
{
    public interface  IProductRepository
    {
        public List<Product> GetProducts();
    }
}
