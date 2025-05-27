namespace TestAPI.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public int PositionId { get; set; } 
        public string? FullName { get; set; } 
        public DateTime BirthDate { get; set; } 
        public string? WorkPhone { get; set; } 
        public string? Office { get; set; } 
        public string? Email { get; set; } 
        public string? MobilePhone { get; set; }
        public int? DirectorId { get; set; } 
        public int? AssistantId { get; set; }
        public DateTime? TerminationDate { get; set; }

        public Position? Position { get; set; } 

    }
}
