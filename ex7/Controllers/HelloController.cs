using Microsoft.AspNetCore.Mvc;

namespace ex7.Controllers
{
    public class HelloController : Controller
    {
        // GET /Hello or /
        public IActionResult Index()
        {
            return Content("Hello from HelloController.Index");
        }

        // GET /Hello/Greet?name=Bob
        public IActionResult Greet(string? name)
        {
            if (string.IsNullOrEmpty(name))
                name = "Guest";
            return Content($"Hello, {name}!");
        }
    }
}
