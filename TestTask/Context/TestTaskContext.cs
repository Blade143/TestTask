using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities;

namespace TestTask.Context
{
    public class TestTaskContext : DbContext
    {
        public DbSet<Activity> ACtivity { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Employer> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectUserRole> ProjectUserRole { get; set; }
        public DbSet<Role> Roles { get; set; }

        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUserRole>()
                .HasKey(o => new { o.UserId, o.RoleId, o.ProjectId});
        }
    }
}
