using System.ComponentModel.DataAnnotations;

namespace Hackerspace.Shared.Models
{
    public class Post
    {
        
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Title { get; set; } = "";
        [Required]
        [MinLength(20)]
        public string Text { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
