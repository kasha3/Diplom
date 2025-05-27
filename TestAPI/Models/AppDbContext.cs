using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Departament> departaments { get; set; }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<WorkingCalendar> WorkingCalendar { get; set; }
        public DbSet<Absences> absences { get; set; }
    }
}
