using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class NewCourseDTO
{
    [Required]
    [StringLength(100, ErrorMessage = "Tytuł może mieć maksymalnie 100 znaków.")]
    public string Title { get; set; } = default!;

    [Required]
    [StringLength(100, ErrorMessage = "Opis może mieć maksymalnie 250 znaków.")]
    public string Description { get; set; } = default!;

    [Range(0.01, 99999, ErrorMessage = "Cena musi być większa od zera.")]
    public Decimal Price { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Range(0, 9999, ErrorMessage = "Liczba studentów musi być nieujemna.")]
    public int MaxNumberOfStudents { get; set; }
    public int TutorId { get; set; }
}