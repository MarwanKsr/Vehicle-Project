using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vehicl_Project.Models
{
    public class Boat : Vehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Boat Name must be at much 25 character")]
        [MinLength(2, ErrorMessage = "Boat Name must be at least 2 character")]
        public string Name { get; set; }
        public string? Brand { get; set; }
        public virtual Color Color { get; set; }
        public int ColorId { get; set; }
    }
}
