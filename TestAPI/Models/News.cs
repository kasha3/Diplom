namespace TestAPI.Models
{
    public class News
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
