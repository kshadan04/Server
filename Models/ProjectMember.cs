using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class ProjectMember
    {
        public int UserId { get; set; } 

        public User? User { get; set; }

        public int ProjectId { get; set; }  
        
        public Project? Project { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty; 
        
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }

}
