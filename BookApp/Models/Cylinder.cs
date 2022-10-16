using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Cylinder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Cylinder Id")]
        public string CylinderId { get; set; }
        [Required]  
        public string Components { get; set; }
        [Required]
        public int Concentration { get; set; }
        [Required]
        public string Unit { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
