using Microsoft.EntityFrameworkCore;
using ProjetJardin.Models;

namespace ProjetJardin
{
    public class ContexteApplication:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PETU-STI-52\\MSSQLSERVER2;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=Yes;");
        }
        public DbSet<Jardin>Jardins { get; set; }
        public DbSet<Fruit> FruitJardins { get; set; }
        public DbSet<Legume> LegumeJardins { get;set; }
    }
}
