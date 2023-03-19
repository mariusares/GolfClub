
using GolfClub.dbconnect;
using GolfClub.Models;

namespace GolfClub.Services
{
    public interface ITeeServices
    {
        Task AddNewTee(TeeMembers tees);
    }
    public class TeeService : ITeeServices
    {
        public async Task AddNewTee(TeeMembers tees)
        {
            using (var context = new AppDb())
            {
                await context.tees.AddAsync(tees);
                await context.SaveChangesAsync();
            }
        }
    }
}
