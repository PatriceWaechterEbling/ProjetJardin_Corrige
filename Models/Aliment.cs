namespace ProjetJardin.Models
{
    public class Aliment
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Jardin> Jardins { get; set; }
    }
}
