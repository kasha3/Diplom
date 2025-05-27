using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesktop.Models
{
    public enum AbsenceType
    {
        обучение,
        отгул,
        отсутствие,
        отпуск
    }
    public class Absences
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public AbsenceType? Type { get; set; }
        public string? Description { get; set; }
        public bool? Paid { get; set; }
    }
}
