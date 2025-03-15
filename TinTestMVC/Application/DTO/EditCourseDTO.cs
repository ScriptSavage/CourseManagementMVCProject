using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class EditCourseDTO
{
    [Required]
    [StringLength(100, ErrorMessage = "Opis może mieć maksymalnie 100 znaków.")]
    public string Description { get; set; } = default!;

    [Range(0.01, 99999, ErrorMessage = "Cena musi być większa od zera.")]
    public Decimal Price { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}