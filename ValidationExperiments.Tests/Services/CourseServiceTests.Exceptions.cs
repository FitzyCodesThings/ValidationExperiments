using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using ValidationExperiments.Core.Entities;
using Xunit;

namespace ValidationExperiments.Tests.Services
{
    public partial class CourseServiceTests
    {
        [Fact]
        public async Task GetCourseAsync_ShouldThrowApplicationExceptionWhenIdIsInvalid()
        {
            // given (arrange)
            int invalidId = 100;
            Course invalidCourse = null;

            this.appDbContextMock.Setup(db =>
                db.SelectCourseByIdAsync(invalidId))
                    .ReturnsAsync(invalidCourse);

            // when (act)
            var subjectTask = subject.GetCourseAsync(invalidId);

            // then (assert)
            await Assert.ThrowsAsync<ApplicationException>(() => subjectTask);
            appDbContextMock.Verify(db => db.SelectCourseByIdAsync(invalidId), Times.Once);
            appDbContextMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddCourseAsync_ShouldThrowExceptionForInvalidDataAnnotationRequirement()
        {
            // given (arrange)
            Filler<Course> courseFiller = new Filler<Course>();

            courseFiller.Setup()
                .OnProperty(p => p.Id).IgnoreIt();

            Course invalidCourseToAdd = courseFiller.Create();

            invalidCourseToAdd.Name = null;

            Course databaseCourse = this.mapper.Map<Course>(invalidCourseToAdd);

            databaseCourse.Id = 1;

            this.appDbContextMock.Setup(db =>
                db.CreateCourseAsync(invalidCourseToAdd))
                    .ReturnsAsync(databaseCourse);

            // when (act)
            var actualCourseTask = subject.AddCourseAsync(invalidCourseToAdd);

            // then (assert)
            await Assert.ThrowsAsync<ValidationException>(() => actualCourseTask);
            appDbContextMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddCourseAsync_ShouldThrowExceptionForInvalidBusinessLogicRequirement()
        {
            // given (arrange)
            Filler<Course> courseFiller = new Filler<Course>();

            courseFiller.Setup()
                .OnProperty(p => p.Id).IgnoreIt();

            Course invalidCourseToAdd = courseFiller.Create();

            invalidCourseToAdd.CourseLessons = new List<CourseLesson>();

            Course databaseCourse = this.mapper.Map<Course>(invalidCourseToAdd);

            databaseCourse.Id = 1;

            this.appDbContextMock.Setup(db =>
                db.CreateCourseAsync(invalidCourseToAdd))
                    .ReturnsAsync(databaseCourse);

            // when (act)
            var actualCourseTask = subject.AddCourseAsync(invalidCourseToAdd);

            // then (assert)
            await Assert.ThrowsAsync<ValidationException>(() => actualCourseTask);
            appDbContextMock.VerifyNoOtherCalls();
        }
    }
}
