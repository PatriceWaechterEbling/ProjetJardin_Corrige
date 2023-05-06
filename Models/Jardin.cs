namespace ProjetJardin.Models
{
    public class Jardin
    {
        public int Id { get; set; }
        public string Emplacement { get; set; }
        public int Surface { get; set; }  
        public ICollection<Aliment> Aliment { get; set; }    
    }
}
