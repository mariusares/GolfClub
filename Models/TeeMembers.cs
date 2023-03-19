using System.ComponentModel.DataAnnotations;

namespace GolfClub.Models
{
    public class TeeMembers
    {
        [Key]
        public int TeeID { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }

        public string Player1 { get; set; }
       
        public string Player2 { get; set; }
   
        public string Player3 { get; set; }
   
        public string Player4 { get; set; }
      
    }
}
