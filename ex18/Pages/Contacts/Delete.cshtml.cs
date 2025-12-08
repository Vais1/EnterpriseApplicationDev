using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ex18.Data;
using ex18.Models;
using System.Security.Claims;

namespace ex18.Pages.Contacts;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Contact Contact { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Contacts == null)
        {
            return NotFound();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

        if (contact == null)
        {
            return NotFound();
        }
        else
        {
            Contact = contact;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Contacts == null)
        {
            return NotFound();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

        if (contact != null)
        {
            Contact = contact;
            _context.Contacts.Remove(Contact);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}

