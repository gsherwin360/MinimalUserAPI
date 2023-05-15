using System.ComponentModel.DataAnnotations;

namespace MinimalUserAPI.DTOs;

public class UserReadDto
{
    public string? Username { get; set; }
    public string? Fullname { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
} // End of class