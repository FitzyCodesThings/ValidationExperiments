using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValidationExperiments.Core.Entities;

namespace ValidationExperiments.Core.Interfaces
{
    public partial interface IAppDbContext
    {
        public Task<CourseLesson> CreateCourseLessonAsync(CourseLesson courseLesson);
        public Task<CourseLesson> SelectCourseLessonByIdAsync(int id);
        public Task<List<CourseLesson>> SelectCourseLessonsAsync();
        public Task<CourseLesson> UpdateCourseLessonAsync(CourseLesson courseLesson);
        public Task<CourseLesson> DeleteCourseLessonAsync(CourseLesson courseLesson);
    }
}
