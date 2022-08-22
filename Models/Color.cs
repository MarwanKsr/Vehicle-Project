namespace Vehicl_Project.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car>? Cars { get; set; }
        public ICollection<Bus>? Buses { get; set; }
        public ICollection<Boat>? Boats { get; set; }
    }
}
