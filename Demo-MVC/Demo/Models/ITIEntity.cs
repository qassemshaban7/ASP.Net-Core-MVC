using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ITIEntity:IdentityDbContext<ApplicationUser>
    {
        public ITIEntity():base()
        {

        }

        public ITIEntity(DbContextOptions options):base(options)
        {

        }
       
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Intake42Q3Assiut;Integrated Security=True");
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
