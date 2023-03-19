using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfClub.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }

        [ForeignKey("TeeID")]
        public TeeMembers tees { get; set; }
    }
}