using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Person
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = default!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = default!;
    
    [MaxLength(250)]
    public string Email { get; set; } = default!;

    public ICollection<PersonCourses> PersonCourses { get; set; } = new HashSet<PersonCourses>();


}