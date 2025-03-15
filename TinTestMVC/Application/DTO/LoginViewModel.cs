using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class LoginViewModel
{
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}

public class RegisterViewModel
{
    [Required(ErrorMessage = "Imię jest wymagane.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Nazwisko jest wymagane.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email jest wymagany.")]
    [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Hasło jest wymagane.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Hasła muszą się zgadzać.")]
    public string ConfirmPassword { get; set; }
}
