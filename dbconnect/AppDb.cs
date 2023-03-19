using GolfClub.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GolfClub.dbconnect
{
    public class AppDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=Database\Database.db");
        public DbSet<Member> members { get; set; }
        public DbSet<Bookings> bookings { get; set; }

        public DbSet<TeeMembers> tees { get; set; }
        
    }
}