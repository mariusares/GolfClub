using GolfClub.dbconnect;
using GolfClub.Models;
namespace GolfClub.Services
{
    public interface IBookingService
    {
        Task AddNewBooking(Bookings bookings);
    }
        public class BookingService : IBookingService
        {
            public async Task AddNewBooking(Bookings bookings)
            {
                using (var context = new AppDb())
                {
                    await context.bookings.AddAsync(bookings);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
