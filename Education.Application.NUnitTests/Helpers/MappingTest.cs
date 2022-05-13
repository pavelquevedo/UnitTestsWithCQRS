using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.NUnitTests.Helpers
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Course, CourseDTO>();
        }
    }
}
