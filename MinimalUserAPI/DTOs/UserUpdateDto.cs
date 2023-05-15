using System.ComponentModel.DataAnnotations;

namespace MinimalUserAPI.DTOs;

public class UserUpdateDto
{
    [Required]
    [MaxLength(15)]
    public string? Username { get; set; }

    [Required]
    [MaxLength(15)]
    public string? Password { get; set; }

    [Required]
    [MaxLength(30)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(30)]
    public string? LastName { get; set; }
} // End of class