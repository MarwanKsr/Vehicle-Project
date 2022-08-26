using System.ComponentModel.DataAnnotations;

namespace Vehicl_Project.Models
{
    public class Color
    {
        public int Id { get; set; }
        [Display(Name ="Color Name")]
        public string Name { get; set; }
        public virtual ICollection<Car>? Cars { get; set; }
        public virtual ICollection<Bus>? Buses { get; set; }
        public virtual ICollection<Boat>? Boats { get; set; }
    }
}
