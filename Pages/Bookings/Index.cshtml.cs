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
    public class IndexModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public IndexModel(GolfClub.dbconnect.AppDb context)
        {
            _context = context;
        }

        public IList<TeeMembers> TeeMembers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.tees != null)
            {
                TeeMembers = await _context.tees.ToListAsync();
            }
        }
    }
}
