using Microsoft.AspNetCore.Mvc;

namespace ex5_routing1.Controllers
{
    [Route("shop/[controller]")]
    public class ProductsController : Controller
    {
        [Route("")]
        [Route("list")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("item/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
}