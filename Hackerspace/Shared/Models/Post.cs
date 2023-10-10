namespace Hackerspace.Shared.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
