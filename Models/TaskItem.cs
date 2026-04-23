using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;   

        public string Description { get; set; } = string.Empty; 

        public DateTime DueDate { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;

        // Relationship with User
        public int CreatorId { get; set; }  
        public User? Creator { get; set; } 


        // relationship with Project is 1 to many
        public int ProjectId { get; set; }  
        public Project? Project { get; set; } 
        
        //Relationship with TaskAssignment

        public ICollection<TaskAssignment>? Assignments { get; set; }

        public ICollection<Comment>? Comments { get; set; }

    }
}
