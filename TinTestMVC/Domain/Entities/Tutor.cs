using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Tutor
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = default!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = default!;

    public string Specialisation { get; set; } = default!;

    public string AboutMe { get; set; } = default!;


    public ICollection<Course> Courses { get; set; }
}