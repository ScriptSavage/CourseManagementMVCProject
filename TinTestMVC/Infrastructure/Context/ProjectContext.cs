using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ProjectContext : IdentityDbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }
    
    protected ProjectContext()
    {
    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Course> Courses { get; set; }
    
    public DbSet<PersonCourses> PersonCourses { get; set; }

    public DbSet<Tutor> Tutors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Person>()
            .HasData(
                new Person()
                {
                    Id = 1 , 
                    FirstName = "Maksymilian" , 
                    LastName = "Galeziowski",
                    Email = "max@example.com"
                }, 
                new Person()
                    {
                        Id = 2 ,
                        FirstName = "Krzys" ,
                        LastName = "Fajny",
                        Email = "krzys@test.com"}
                );
        
        
        modelBuilder.Entity<Tutor>().HasData(
            new Tutor
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Specialisation = "Java",
                AboutMe = "Programista z 10-letnim doświadczeniem w Javie"
            },
            new Tutor
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                Specialisation = "Networking",
                AboutMe = " Ekspertka w tworzeniu aplikacji backendowych."
            }
        );
        
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Title = "Podwstawy z Javy",
                Description = "Podstawy programowania z Javy",
                Price = 499.99m,
                StartDate = new DateTime(2025, 01, 10),
                EndDate = new DateTime(2025, 03, 10),
                MaxNumberOfStudents = 0,
                TutorId = 1
            },
            new Course
            {
                Id = 2,
                Title = "Podstawy sieci",
                Description = "Podstawowe zagadnienia zwiazane z sieciami",
                Price = 749.99m,
                StartDate = new DateTime(2025, 02, 01),
                EndDate = new DateTime(2025, 06, 01),
                MaxNumberOfStudents = 0,
                TutorId = 2
            }
        );
        
        modelBuilder.Entity<PersonCourses>().HasData(
            new PersonCourses
            {
                PersonId = 1,
                CourseId = 1,
                RegistrationDate = new DateTime(2025, 01, 11)
            },
            new PersonCourses
            {
                PersonId = 1,
                CourseId = 2,
                RegistrationDate = new DateTime(2025, 01, 15)
            },
            new PersonCourses
            {
                PersonId = 2,
                CourseId = 2,
                RegistrationDate = new DateTime(2025, 02, 02)
            }
        );
        
    }
}