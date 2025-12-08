using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ex18.Data;
using ex18.Models;
using System.Security.Claims;

namespace ex18.Pages.Contacts;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

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
}

