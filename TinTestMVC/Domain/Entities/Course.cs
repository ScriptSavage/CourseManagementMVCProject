using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = default!;

    [MaxLength(100)]
    public string Description { get; set; } = default!;

    public Decimal Price { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int MaxNumberOfStudents { get; set; }

    public ICollection<PersonCourses> PersonCourses { get; set; } = new HashSet<PersonCourses>();
    
    public int TutorId { get; set; }

    [ForeignKey(nameof(TutorId))]
    public Tutor Tutor { get; set; }
}