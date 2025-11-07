using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ex10.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    // Properties for Razor variables demonstration
    public string WelcomeMessage { get; } = "Welcome to ex10 - Razor Variables Exercise";
    public int NumberValue { get; } = 42;
    public List<string> Fruits { get; } = new() { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
    public List<int> Numbers { get; } = new() { 10, 20, 30, 40, 50 };

    public void OnGet()
    {

    }
}
