using Hangfire.Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult Get() 
        {
            var products = _productService.GetAllProducts();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var result = _productService.AddRangeProduct();

            if(result > 0)
                return Ok("Kayıt Eklendi");
            else
                return BadRequest();
        }

    }
}
