using System.ComponentModel.DataAnnotations;

namespace EliteDining.DAL.Models;

public class RegistrationModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }
    [Phone]
    [Required(ErrorMessage = "Phone is required")]
    public string? Phone { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}

