using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Education.Application.DTO;

namespace Education.Application.Courses
{
    public class GetCoursesQuery
    {
        public class GetCourseQueryRequest : IRequest<List<CourseDTO>> {}

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<CourseDTO>>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;

            public GetCourseQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<CourseDTO>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses
                    .ToListAsync();

                var coursesDTO = _mapper.Map<List<Course>, List<CourseDTO>>(courses);
                return coursesDTO;
            }
        }
    }
}
