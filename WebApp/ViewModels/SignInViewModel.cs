using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class SignInViewModel
    {
      
        [Display(Name = "E-mail address", Prompt = "Enter your Email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter a valid Email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your email address is invalid")]
        public string Email { get; set; } = null!;

      
        [Display(Name = "Password", Prompt = "Enter your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid password")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Your password is invalid")]
        public string Password { get; set; } = null!;


        [Display(Name = "Remember me", Prompt = "Remember me")]
        public bool IsPresistent { get; set; }    
    }
}
