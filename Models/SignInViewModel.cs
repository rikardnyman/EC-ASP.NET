using System.ComponentModel.DataAnnotations;

namespace EC_ASP.NET.Models
{
    public class SignInViewModel
    {

        [Required(ErrorMessage = "You need to enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Enter your email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You need to enter a password.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number.")]
        [Display(Name = "Enter a password")]
        public string Password { get; set; } = null!;

        [Range(typeof(bool), "true", "true")]
        [Display(Name = "Accept Terms and Conditions")]
        public bool IsPersistent { get; set; }
    }
}
