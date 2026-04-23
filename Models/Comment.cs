using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty; 

        public DateTime CreatedAt { get; set; }

        // Relationship with User

        public int UserId { get; set; } 
        public User? User { get; set; }

        // Relationship with Task

        public int TaskItemId { get; set; }
        public TaskItem ? TaskItem { get; set; }


    }
}
