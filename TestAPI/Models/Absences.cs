using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
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
