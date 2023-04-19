#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CodePink.Models;

public class User
{
    [Key]

    public int UserId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "First name needs to be at least 2 characters.")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name needs to be at least 2 characters.")]
    public string LastName { get; set; }


    public string Nickname { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string SchoolIdImage { get; set; }

    [Required]
    public string ParentIdImage { get; set; }

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password needs to be at least 8 characters please!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords don't match, try again!")]
    public string ConfirmPassword { get; set; }


    public List<Product> addedProduct { get; set; } = new List<Product>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext valContext)
    {
        if (value == null)
        { // if email input is empty
            return new ValidationResult("Email is required");
        }
        MyContext _context = (MyContext)valContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email is in use"); // if email is in database
        }
        else
        {
            return ValidationResult.Success; // email not in database good to go
        }
    }
}