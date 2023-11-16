using Microsoft.EntityFrameworkCore;

namespace Micro.Sinhro.REST.Student.Persistance
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }   
        public DbSet<Models.Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Models.Student>().HasData(
                 new List<Models.Student>()
                 {
                     new Models.Student() {Id = 1, FirstName = "Dzejlana", LastName = "Halilovic"},
                     new Models.Student() {Id = 2, FirstName = "Edina", LastName = "Kucevic"},
                     new Models.Student() {Id = 3, FirstName = "Elma", LastName = "Mujovic"},
                 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
