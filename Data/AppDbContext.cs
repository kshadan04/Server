using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }  
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        // ****************** Fluent API ******************
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
            });

            // Project
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.ProjectId);

                // Relationship(user => project)
                entity.HasOne(p => p.Creator)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict); // parent will not be deleted if it has children
            });

            //TaskItem
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(p => p.TaskItemId);

                //Relationship(project => task)
                entity.HasOne(t => t.Project)
                .WithMany(p => p.TaskItems)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

                //Relationship(user => task)
                entity.HasOne(t => t.Creator)
                .WithMany(u => u.TaskItems)
                .HasForeignKey(t => t.CreatorId);
            });

            //Comment
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);

                //Relationship(comment => taskItem)
                entity.HasOne(c => c.TaskItem)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskItemId)
                .OnDelete(DeleteBehavior.Restrict);

                //Relationship(comment => user)
                entity.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            //ProjectMember
            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasKey(pm => new { pm.UserId, pm.ProjectId});

                //Relationship(projectMember => User)
                entity.HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                //Relationship(projectMember => Project)
                entity.HasOne(pm =>pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //TaskAssignment
            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(ta => new { ta.UserId, ta.TaskItemId });

                //Relationship(taskAssignment => User)  
                entity.HasOne(ta => ta.User)
                .WithMany(u => u.Assignments)
                .HasForeignKey(ta =>ta.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                //Relationship(taskAssignment => TaskItem)
                entity.HasOne(ta => ta.TaskItem)
                .WithMany(t => t.Assignments)
                .HasForeignKey(ta => ta.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);
  
            });

            //UserRole
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                //Relationship(userRole => User)
                entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                //Relationship(userRole => Role)
                entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
