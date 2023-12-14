using Microsoft.EntityFrameworkCore;

namespace Micro.Async.Grade
{
    public class GradeDBContext : DbContext
    {
        public GradeDBContext(DbContextOptions<GradeDBContext> options) : base(options)
        {
        }
        public DbSet<Models.Grade> Grades { get; set; }

    }
}
