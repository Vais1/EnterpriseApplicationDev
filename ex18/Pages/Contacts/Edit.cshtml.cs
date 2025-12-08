using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ex18.Data;
using ex18.Models;
using System.Security.Claims;

namespace ex18.Pages.Contacts;

[Authorize]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        Contact = contact;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == Contact.Id && c.UserId == userId);

        if (existingContact == null)
        {
            return NotFound();
        }

        existingContact.FirstName = Contact.FirstName;
        existingContact.LastName = Contact.LastName;
        existingContact.Email = Contact.Email;
        existingContact.PhoneNumber = Contact.PhoneNumber;
        existingContact.Address = Contact.Address;
        existingContact.City = Contact.City;
        existingContact.State = Contact.State;
        existingContact.ZipCode = Contact.ZipCode;
        existingContact.Notes = Contact.Notes;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContactExists(Contact.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ContactExists(int id)
    {
        return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}

