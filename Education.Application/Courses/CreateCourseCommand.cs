using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    public class CreateCourseCommand
    {
        public class CreateCourseCommandRequest : IRequest
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime PublishDate { get; set; }
            public decimal Price { get; set; }
        }

        public class CreateCourseCommandRequestValidation : AbstractValidator<CreateCourseCommandRequest>
        {
            public CreateCourseCommandRequestValidation()
            {
                RuleFor(x => x.Description);
                RuleFor(x => x.Name);
            }
        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest>
        {
            private readonly EducationDbContext _context;

            public CreateCourseCommandHandler(EducationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    CourseId = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    CreationDate = DateTime.UtcNow,
                    PublishDate = request.PublishDate,
                    Price = request.Price
                };

                _context.Add(course);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Course cannot be inserted");
            }
        }
    }

}
