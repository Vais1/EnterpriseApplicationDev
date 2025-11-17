using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ex12.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["PageTitle"] = "Home - ViewData and ViewBag Demo";
        ViewData["WelcomeMessage"] = "Welcome to the ViewData and ViewBag Exercise";
        ViewData["ApplicationName"] = "ex12 - View Engine Demo";
        ViewData["Version"] = "1.0";
    }
}
