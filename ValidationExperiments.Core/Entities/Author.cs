using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationExperiments.Core.Entities
{
    public class Author
    {
        public Author()
        {
            this.CourseLessons = new HashSet<AuthorCourseLesson>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string ContactEmail { get; set; }

        public ICollection<AuthorCourseLesson> CourseLessons { get; set; }
    }
}
