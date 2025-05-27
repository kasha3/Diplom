namespace TestAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string? Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorPosition { get; set; }
    }
}
