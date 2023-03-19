using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;
using GolfClub.dbconnect;

namespace GolfClub.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDb _context;

        public MembersController(AppDb context)
        {
            _context = context;
        }

       
        public IActionResult Index(string sort)
        {

            using (var context = new AppDb())
            {
                List<Member> member = new List<Member>();

                switch (sort)
                {
                    case "name":
                        member = context.members.OrderBy(p => p.Name).ToList();
                        break;
                    case "gender":
                        member = context.members.OrderBy(p => p.Gender).ToList();
                        break;
                    case "handicap":
                        member = context.members.OrderBy(p => p.Handicap).ToList();
                        break;
                }
                return View(member);
            }
        }
    }
}
