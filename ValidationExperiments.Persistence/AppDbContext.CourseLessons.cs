using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValidationExperiments.Core.Entities;

namespace ValidationExperiments.Persistence
{
    public partial class AppDbContext
    {
        DbSet<CourseLesson> CourseLessons { get; set; }

        public async Task<CourseLesson> CreateCourseLessonAsync(CourseLesson courseLesson)
        {
            EntityEntry<CourseLesson> courseLessonEntry = await this.CourseLessons.AddAsync(courseLesson);
            await this.SaveChangesAsync();
            return courseLessonEntry.Entity;
        }

        public async Task<CourseLesson> SelectCourseLessonByIdAsync(int id) =>
            await this.CourseLessons
                .AsNoTracking()
                .Include(p => p.Authors)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<CourseLesson>> SelectCourseLessonsAsync()
        {
            return await this.CourseLessons
                            .Include(p => p.Authors)
                            .ToListAsync();
        }

        public async Task<CourseLesson> UpdateCourseLessonAsync(CourseLesson courseLesson)
        {
            EntityEntry<CourseLesson> courseLessonEntry = this.CourseLessons.Update(courseLesson);
            await this.SaveChangesAsync();
            return courseLessonEntry.Entity;
        }
        public async Task<CourseLesson> DeleteCourseLessonAsync(CourseLesson courseLesson)
        {
            EntityEntry<CourseLesson> courseLessonEntry = this.CourseLessons.Remove(courseLesson);
            await this.SaveChangesAsync();
            return courseLessonEntry.Entity;
        }
    }
}
