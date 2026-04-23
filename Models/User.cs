using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class User
    {
        public int UserId { get;set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get;set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string UserEmail { get;set; } =string.Empty;

        
        //project member relations
        public ICollection<ProjectMember>? ProjectMembers { get; set; }


        // user can create multiple TaskItems
        public ICollection<TaskItem>? TaskItems { get; set; }

        //TaskAssignment relations
        public ICollection<TaskAssignment>? Assignments { get; set; }


        // a user can multiple comments
        public ICollection<Comment>? Comments { get; set; }

        public ICollection<UserRole>? UserRoles { get; set; } 


        // user can create multiple Projects
        public ICollection<Project>? Projects { get; set; }
    }
}
