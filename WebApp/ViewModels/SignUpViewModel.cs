using System.ComponentModel.DataAnnotations;
using WebApp.Filters;

namespace WebApp.ViewModels
{
    public class SignUpViewModel
    {

       
        [DataType(DataType.Text)]
        [Display(Name = "First Name", Prompt = "Enter your first Name")]
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2, ErrorMessage = "Enter your first name")]
        public string FirstName { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Last Name", Prompt = "Enter your last name")]
        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2, ErrorMessage = "Enter your last name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email address", Prompt = "Enter your Email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter a valid Email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your email address is invalid")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password", Prompt = "Enter your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Your password is invalid")]
        public string Password { get; set; } = null!;

        [Display(Name = "ConfirmPassword", Prompt = "Re write your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password don't match")]
        [Compare(nameof(Password), ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "I agree to the Terms & Conditions.")]
        [CheckboxRequired(ErrorMessage = "You must accept the terms and conditions to proceed.")]
        public bool TermsAndConditions { get; set; }
    }
}
