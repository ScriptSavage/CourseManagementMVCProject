using Application.Mapping;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions;

public static class ApplicationExtentionClass
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(PersonMapper));
        service.AddAutoMapper(typeof(CourseMapper));
        service.AddAutoMapper(typeof(TutorMapper));
        service.AddScoped<IPersonService, PersonService>();
        service.AddScoped<ICourseService, CourseService>();
        service.AddScoped<ITutorService, TutorService>();
        service.AddScoped<IPersonCourseService, PersonCourseService>();
    }
}