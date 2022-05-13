using Education.Application.Courses;
using Education.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EducationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

//It's not necessary to add all the CQRS classes, since MediatR will look for every class extending from IRequest
builder.Services.AddMediatR(typeof(GetCoursesQuery.GetCourseQueryHandler).Assembly);

//It's not necessary to add the reference of all the classes using fluent validation, when you register one, it will read all of the rest
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateCourseCommand>());

//Same here
builder.Services.AddAutoMapper(typeof(GetCoursesQuery.GetCourseQueryHandler));

//Configuring CORS
builder.Services.AddCors(conf => conf.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsApp");
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
