using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesktop.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string? Name { get; set; }
        public Organization? Organization { get; set; }
    }
}
