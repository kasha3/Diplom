namespace TestAPI.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? Category { get; set; }
        public bool HasComments { get; set; }
    }
}
