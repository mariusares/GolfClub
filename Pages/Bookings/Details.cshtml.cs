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
    public class DetailsModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public DetailsModel(GolfClub.dbconnect.AppDb context)
        {
            _context = context;
        }

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
    }
}
