using AutoFixture;
using AutoMapper;
using Education.Application.Courses;
using Education.Application.NUnitTests.Helpers;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.NUnitTests.Courses
{
    [TestFixture]
    public class CreateCourseQueryNUnitTests
    {
        private CreateCourseCommand.CreateCourseCommandHandler handlerCreateCourse;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(tr => tr.CourseId, Guid.Empty)
                .Create());

            //Creating temporary in-memory database
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                .Options;

            //Creating fake dbcontext
            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Courses.AddRange(courseRecords);
            educationDbContextFake.SaveChanges();

            handlerCreateCourse = new CreateCourseCommand.CreateCourseCommandHandler(educationDbContextFake);
        }

        [Test]
        public async Task CreateCourseCommand_InputCourse_ReturnsNumber()
        {
            //Arrange           
            CreateCourseCommand.CreateCourseCommandRequest request = new()
            {
                Name = "Course test",
                Description = "Description test",
                PublishDate = DateTime.Now.AddYears(2),
                Price = 100
            };
            //and pass it the objects context and mapping as parameters

            //Act
            var result = await handlerCreateCourse.Handle(request, new CancellationToken());

            //Assert
            Assert.That(result, Is.EqualTo(Unit.Value));
        }
    }
}
