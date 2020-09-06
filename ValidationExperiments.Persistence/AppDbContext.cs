using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using ValidationExperiments.Core.Entities;
using ValidationExperiments.Core.Interfaces;

namespace ValidationExperiments.Persistence
{
    public partial class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IConfiguration configuration;

        DbSet<AuthorCourseLesson> AuthorCourseLessons { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();      
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<AuthorCourseLesson>()
                .HasKey(p => new { p.AuthorId, p.CourseLessonId });

            modelBuilder.Entity<AuthorCourseLesson>()
                .HasOne(p => p.Author)
                .WithMany(p => p.CourseLessons)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<AuthorCourseLesson>()
                .HasOne(p => p.CourseLesson)
                .WithMany(p => p.Authors)
                .HasForeignKey(p => p.CourseLessonId);         
        }
    }
}
