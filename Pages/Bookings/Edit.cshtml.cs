using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;
using GolfClub.dbconnect;

namespace GolfClub.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public EditModel(GolfClub.dbconnect.AppDb context)
        {
            _context = context;
        }

        [BindProperty]
        public TeeMembers TeeMembers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tees == null)
            {
                return NotFound();
            }

            var teemembers =  await _context.tees.FirstOrDefaultAsync(m => m.TeeID == id);
            if (teemembers == null)
            {
                return NotFound();
            }
            TeeMembers = teemembers;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TeeMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeeMembersExists(TeeMembers.TeeID))
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

        private bool TeeMembersExists(int id)
        {
          return (_context.tees?.Any(e => e.TeeID == id)).GetValueOrDefault();
        }
    }
}
