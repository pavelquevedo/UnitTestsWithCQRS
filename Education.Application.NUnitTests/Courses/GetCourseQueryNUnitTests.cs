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
    public class GetCourseQueryNUnitTests
    {
        private GetCoursesQuery.GetCourseQueryHandler handlerAllCourses;

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

            //Configuring fake mapper
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            handlerAllCourses = new GetCoursesQuery.GetCourseQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCourseQueryHandler_CoursesQuery_ReturnsTrue()
        {
            //Arrange
            //1. Emulate context which represents the instance of EntityFramework

            //2. Emulate the Mapping Profile

            //3. Instanciate an object of the class GetCourseQuery.GetCourseQueryHandler
            GetCoursesQuery.GetCourseQueryRequest request = new();
            //and pass it the objects context and mapping as parameters

            //Act
            var result = await handlerAllCourses.Handle(request, new CancellationToken());

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
