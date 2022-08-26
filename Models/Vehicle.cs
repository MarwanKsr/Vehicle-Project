namespace Vehicl_Project.Models
{
    public interface Vehicle
    {
        public int Id { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
    }
}
