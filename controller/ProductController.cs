using HealthCheckApp.Models;
using HealthCheckApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheckApp.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productRepository.GetProducts();
        }
    }
}
