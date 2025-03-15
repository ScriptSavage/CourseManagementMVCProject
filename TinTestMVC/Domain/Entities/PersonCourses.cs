using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;


[PrimaryKey(nameof(PersonId),nameof(CourseId))]
public class PersonCourses
{

    public int PersonId { get; set; }
    [ForeignKey(nameof(PersonId))]
    public Person Person { get; set; }
    
    public int CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; }
    
    public DateTime RegistrationDate { get; set; }
}