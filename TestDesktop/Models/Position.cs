using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesktop.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int DepartamentId { get; set; }
        public string? Name { get; set; }
        public Departament? Departament { get; set; }
    }
}
