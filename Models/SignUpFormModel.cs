using System.ComponentModel.DataAnnotations;

namespace EC_ASP.NET.Models
{
    public class SignUpFormModel
    {
        [Required(ErrorMessage = "You need to enter your full name.")]
        [Display(Name = "Enter your full name")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "You need to enter an email address.")]
        [Display(Name = "Enter your email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You need to enter a password.")]
        [Display(Name = "Enter a password")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "You need to confirm your password.")]
        [Display(Name = "Confirm your password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "You need to accept the terms.")]
        [Display(Name = "Accept Terms and Conditions")]
        public bool Terms { get; set; }

        public string Client { get; set; } = null!;


        public bool IsValid => Terms && Password == ConfirmPassword;
    }
}
