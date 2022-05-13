using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Education.Application
{
    public class GetCoursesQuery
    {
        public class GetCourseQueryRequest : IRequest<List<Course>> {}

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<Course>>
        {
            private readonly EducationDbContext _context;
            public GetCourseQueryHandler(EducationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Course>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.ToListAsync();

                return courses;
            }
        }
    }
}
