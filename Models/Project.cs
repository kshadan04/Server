using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProjectName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string ProjectDescription { get; set; } = string.Empty;

        //Tasks
        public ICollection<TaskItem>? TaskItems { get; set; }

        //ProjectMembers Relation
        public ICollection<ProjectMember>? ProjectMembers { get; set; }


        // Relationship with User
        public int CreatorId { get; set; }
        public User? Creator { get; set; }
    }
}
