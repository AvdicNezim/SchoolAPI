using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    public class AppDbContext : DbContext
    {
        // Konstruktor klase koji prima opcije baze podataka
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Definiranje tabela u bazi podataka
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Final> Finals { get; set; }

        // Metoda koja se poziva prilikom konfiguriranja modela baze podataka
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodavanje podataka o odjelima
            modelBuilder.Entity<Department>().HasData(new Department { id = 1, name = "Microsoft Web Development" });
            modelBuilder.Entity<Department>().HasData(new Department { id = 2, name = "Microsoft Desktop Development" });

            // Dodavanje podataka o kursevima
            modelBuilder.Entity<Course>().HasData(new Course { id = 1, name = "Microsoft Web Services", numberOfClasses = 32 });
            modelBuilder.Entity<Course>().HasData(new Course { id = 2, name = "ASP.NET Core MVC", numberOfClasses = 44 });
            modelBuilder.Entity<Course>().HasData(new Course { id = 3, name = "Introduction To Web Development", numberOfClasses = 32 });

            // Dodavanje podataka o studentima
            modelBuilder.Entity<Student>().HasData(new Student { id = 1, firstName = "John", lastName = "Doe", departmentId = 1});
            modelBuilder.Entity<Student>().HasData(new Student { id = 2, firstName = "Mark", lastName = "Stone", departmentId = 1 });

            // Dodavanje podataka o ispitima
            modelBuilder.Entity<Final>().HasData(new Final { id = 1, name = "Primjer polaganja", courseId = 1, date = DateTime.Today, mark = 10, studentId = 1 });
            modelBuilder.Entity<Final>().HasData(new Final { id = 2, name = "Primjer polaganja", courseId = 1, date = DateTime.Today, mark = 10, studentId = 2 });
            modelBuilder.Entity<Final>().HasData(new Final { id = 3, name = "Primjer polaganja", courseId = 2, date = DateTime.Today, mark = 10, studentId = 1 });
        }
    }
}
