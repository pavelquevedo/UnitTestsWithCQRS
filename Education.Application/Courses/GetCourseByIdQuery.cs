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
    public class GetCourseByIdQuery
    {
        public class GetCourseByIdQueryRequest : IRequest<CourseDTO> {
            public Guid id;
        }

        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, CourseDTO>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;

            public GetCourseByIdQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CourseDTO> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses
                    .FirstOrDefaultAsync(x => x.CourseId == request.id);

                var courseDTO = _mapper.Map<Course, CourseDTO>(course);
                return courseDTO;
            }
        }
    }
}
