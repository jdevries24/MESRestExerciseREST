using Microsoft.EntityFrameworkCore;
namespace MesExerciseREST
{
    public class AplicationDBContext : DbContext
    {
        public DbSet<ExampleItem> ItemTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase("ApplicationDB.db");
    }
}
