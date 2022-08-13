using Microsoft.EntityFrameworkCore;
using StudentAPICRUD.Models.Models;

namespace StudentAPICRUD.DatabaseContext.DatabaseContext
{
    public class StudentDbContext : DbContext 
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
