using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class TutorDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = default!;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = default!;

    [StringLength(100)]
    public string Specialisation { get; set; } = default!;

    [Required]
    public string AboutMe { get; set; } = default!;
}