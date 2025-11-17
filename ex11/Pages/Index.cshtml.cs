using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ex11.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    // Model properties
    public string Title { get; set; } = "Home.Index";
    public DateTime CurrentDate { get; set; }
    public List<string> Items { get; set; } = new();
    public List<int> Numbers { get; set; } = new();
    public string Message { get; set; } = "";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        CurrentDate = DateTime.Now;
        Items = new List<string> { "Wednesday, 5 Aug 2020", "Wednesday, 5 Aug 2020" };
        Numbers = new List<int> { 1, 2, 3, 4, 5 };
        Message = "Welcome to Razor Model Access Demo";
    }
}
