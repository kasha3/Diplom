using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestDesktop.Models
{
    public class CanvasDepartment
    {
        public string? Name { get; set; }
        public CanvasDepartment? Parent { get; set; }
        public Grid? BockScene { get; set; }
    }

}
