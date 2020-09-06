using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationExperiments.Core.Entities
{
    public class Course
    {
        public Course()
        {
            this.CourseLessons = new HashSet<CourseLesson>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string VideoId { get; set; }

        public ICollection<CourseLesson> CourseLessons { get; set; }
    }
}
