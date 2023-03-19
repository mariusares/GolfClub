using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;
using GolfClub.dbconnect;

namespace GolfClub.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public DeleteModel(GolfClub.dbconnect.AppDb context)
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

            var teemembers = await _context.tees.FirstOrDefaultAsync(m => m.TeeID == id);

            if (teemembers == null)
            {
                return NotFound();
            }
            else 
            {
                TeeMembers = teemembers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tees == null)
            {
                return NotFound();
            }
            var teemembers = await _context.tees.FindAsync(id);

            if (teemembers != null)
            {
                TeeMembers = teemembers;
                _context.tees.Remove(TeeMembers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
