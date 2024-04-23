using System.ComponentModel.DataAnnotations;
namespace WebApp.ViewModels;

public class SubscribeViewModel
{
    [Required(ErrorMessage = "Enter a valid Email address")]
    [EmailAddress]
    [Display(Name = "E-mail address", Prompt = "Your Email")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your email address is invalid")]


    public string Email { get; set; } = null!;

    public bool DailyNewsletter { get; set; }

    public bool AdvertisingUpdates { get; set; }

    public bool WeekinReview { get; set; }

    public bool EventUpdates { get; set; }

    public bool StartupsWeekly { get; set; }

    public bool Podcasts { get; set; }
}
