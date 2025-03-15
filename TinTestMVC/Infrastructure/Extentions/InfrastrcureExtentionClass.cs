using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions;

public static class InfrastrcureExtentionClass
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ICoursesRepository, CoursesRepository>();
        services.AddScoped<ITutorRepository, TutorRepository>();
        services.AddScoped<IPersonCoursesRepository, PersonCoursesRepository>();
    }
}