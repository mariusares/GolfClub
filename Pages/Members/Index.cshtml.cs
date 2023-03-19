using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;
using GolfClub.dbconnect;
using GolfClub.Services;

namespace GolfClub.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly GolfClub.dbconnect.AppDb _context;

        public IndexModel(GolfClub.dbconnect.AppDb context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.members != null)
            {
                Member = await _context.members.ToListAsync();
            }
        }
    }
}
