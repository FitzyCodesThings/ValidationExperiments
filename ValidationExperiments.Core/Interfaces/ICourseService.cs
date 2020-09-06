using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ValidationExperiments.Core.Entities;

namespace ValidationExperiments.Core.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync();

        Task<Course> GetCourseAsync(int id);

        Task<Course> AddCourseAsync(Course course);

        Task<Course> UpdateCourseAsync(Course course);

        Task<Course> DeleteCourseAsync(Course course);
    }
}
