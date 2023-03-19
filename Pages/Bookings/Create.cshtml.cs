using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClub.Models;
using GolfClub.dbconnect;

namespace GolfClub.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public CreateModel(GolfClub.dbconnect.AppDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TeeMembers TeeMembers { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.tees == null || TeeMembers == null)
            {
                return Page();
            }

            _context.tees.Add(TeeMembers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
