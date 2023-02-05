using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequstController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public RequstController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost]
        public async Task Index()
        {
            var products = new List<Product>();

            for (int i = 1; i <= 50; i++)
            {
                products.Add(new Product { Id = i, ProductName = $"ProductName {i}", DateTime = DateTime.Now, Amount = 5 });

                await _publishEndpoint.Publish(new Product
                {
                    Id = i,
                    ProductName = $"ProductName {i}",
                    DateTime = DateTime.Now,
                    Amount = 5
                });

                Console.WriteLine($"Send {i} request");
            } 
        }
    }
}
