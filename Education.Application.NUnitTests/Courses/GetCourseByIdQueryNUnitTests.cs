using AutoFixture;
using AutoMapper;
using Education.Application.Courses;
using Education.Application.NUnitTests.Helpers;
using Education.Domain;
using Education.Persistence;
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
    public class GetCourseByIdQueryNUnitTests
    {
        private GetCourseByIdQuery.GetCourseByIdQueryHandler handlerByIdCourse;
        private Guid courseIdTest;

        [SetUp]
        public void SetUp()
        {
            courseIdTest = new Guid("3de6334b-9aaf-46dc-9231-561267dd8289");

            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(tr => tr.CourseId, courseIdTest)
                .Create());

            //Creating temporary in-memory database
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                .Options;

            //Creating fake dbcontext
            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Courses.AddRange(courseRecords);
            educationDbContextFake.SaveChanges();

            //Configuring fake mapper
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            handlerByIdCourse = new GetCourseByIdQuery.GetCourseByIdQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCourseByIdQueryHandler_InputCourseId_ReturnsNotNull()
        {
            //Arrange
            GetCourseByIdQuery.GetCourseByIdQueryRequest request = new()
            {
                id = courseIdTest
            };
            //and pass it the objects context and mapping as parameters

            //Act
            var result = await handlerByIdCourse.Handle(request, new CancellationToken());

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
