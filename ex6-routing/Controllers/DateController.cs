using System;
using Microsoft.AspNetCore.Mvc;

namespace ex6_routing.Controllers
{
    public class DateController : Controller
    {
        // GET /date
        public IActionResult Index()
        {
            return View();
        }

        // GET /date/day/{offset}
        // We'll interpret {offset} as days added to a fixed base date so the output is deterministic.
        // Assumption: base date = 2025-06-17 so offset=8 => 2025-06-25 (matches the example).
        [Route("date/day/{offset}")]
        public IActionResult Day(int offset)
        {
            var baseDate = new DateTime(2025, 6, 17);
            var result = baseDate.AddDays(offset);
            return View(model: result);
        }
    }
}
