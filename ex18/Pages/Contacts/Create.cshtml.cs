using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ex18.Data;
using ex18.Models;
using System.Security.Claims;

namespace ex18.Pages.Contacts;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Contact Contact { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.Contacts == null || Contact == null)
        {
            return Page();
        }

        Contact.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Contact.CreatedDate = DateTime.Now;

        _context.Contacts.Add(Contact);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

