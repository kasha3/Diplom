using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesktop.Models
{
    public class HRContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Absences> Absences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=fadeev4e.beget.tech;port=3306;database=fadeev4e_diplom;user=fadeev4e_diplom;pwd=vN8Ur1Rc;AllowPublicKeyRetrieval=True;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
