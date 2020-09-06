using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationExperiments.Core.Entities
{
    public class CourseLesson
    {
        public CourseLesson()
        {
            this.Authors = new HashSet<AuthorCourseLesson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<AuthorCourseLesson> Authors { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
