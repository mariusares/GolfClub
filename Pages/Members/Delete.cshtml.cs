using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;
using GolfClub.dbconnect;

namespace GolfClub.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public DeleteModel(GolfClub.dbconnect.AppDb context)
        {
            _context = context;
        }

        [BindProperty]
      public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.members == null)
            {
                return NotFound();
            }

            var member = await _context.members.FirstOrDefaultAsync(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.members == null)
            {
                return NotFound();
            }
            var member = await _context.members.FindAsync(id);

            if (member != null)
            {
                Member = member;
                _context.members.Remove(Member);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
