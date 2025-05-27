namespace TestAPI.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string? Name { get; set; }

        public Organization? Organization { get; set; }
    }
}
