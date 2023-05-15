using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalUserAPI.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(15)]
    [Column("username")]
    public string Username { get; set; } = null!;

    [StringLength(15)]
    [Column("password")]
    public string Password { get; set; } = null!;

    [StringLength(30)]
    [Column("first_name")]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    [Column("last_name")]
    public string LastName { get; set; } = null!;

    [Column("date_created")]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    [Column("date_updated")]
    public DateTime? DateUpdated { get; set; } = null;
} // End of class