using HeatMaps.Utilities.Products;
using Microsoft.AspNetCore.Mvc;

namespace HeatMaps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        //public readonly ILogger<Product> _logger;
        private readonly IProductService _ProductsService;

        public ProductsController(IProductService productsService)
        {
            //_logger = logger;
            _ProductsService = productsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _ProductsService.GetAll();
            return Json(products.Result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> GetAProduct(int id)
        {
            var product = _ProductsService.Get(id);
            return Json(product.Result);
        }

        [HttpGet("ByProductId/{productId}")]
        public ActionResult<Product> GetPdusingProductId(string ProductId)
        {
            var product = _ProductsService.Get(ProductId);
            return Json(product.Result);
        }
    }
}
