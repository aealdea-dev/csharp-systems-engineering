using System.ComponentModel.DataAnnotations;
namespace UserManagementAPI.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "First name cannot be blank")]
    public required string FirstName { get; set; }
    [Required(ErrorMessage = "Last name cannot be blank.")]
    public required string LastName { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "You must provide a valid email format (e.g., name@domain.com).")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format. Must contain an '@' and no spaces.")]
    public required string Email { get; set; }
    [Required(ErrorMessage = "Department cannot be blank.")]
    public required string Department { get; set; }
}