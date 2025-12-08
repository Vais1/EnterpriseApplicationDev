using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ex18.Data;
using ex18.Models;
using System.Security.Claims;

namespace ex18.Pages.Contacts;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Contact> Contact { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Contact = await _context.Contacts
            .Where(c => c.UserId == userId)
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
    }
}

