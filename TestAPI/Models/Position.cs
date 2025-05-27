namespace TestAPI.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int DepartamentId { get; set; }
        public string? Name { get; set; }
        public Departament? Departament { get; set; }

    }
}
