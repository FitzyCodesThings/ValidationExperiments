using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ValidationExperiments.Business.Validators;
using ValidationExperiments.Core.Entities;

namespace ValidationExperiments.Business.Services
{
    public partial class CourseService
    {
        private void ValidateCourseOnCreate(Course course)
        {
            ModelValidator.ValidateModel(course);
            ValidateCourseHasAtLeastOneLesson(course);
        }

        private void ValidateCourseHasAtLeastOneLesson(Course course)
        {
            if (course.CourseLessons == null || course.CourseLessons.Count() == 0)
                throw new ValidationException("Courses must contain at least one lesson.");
        }
    }
}
