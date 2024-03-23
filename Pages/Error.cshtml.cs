using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace DotNetAssignment3.Pages;

public class ErrorModel : PageModel
{
    public List<String> errors { get; set; } = new List<String>();
    public User? user;

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }


    public void OnGet(User _user)

    {
        user = _user;

        if (user.UserName != null && user.UserName.Length < 3)
        {
            errors.Add("User name has to be minimum 3 letters to maximum 20 letters");
        }

        if (user.UserContact != null && !Regex.IsMatch(user.UserContact, @"^\d{3}-\d{3}-\d{4}$"))
        {
            errors.Add("Please provide a valid phone number in the format XXX-XXX-XXXX");
        }

        if (user.ReservationDateAndTime <= DateTime.Now)
        {
            errors.Add("Reservation date & time should be greater than the current date & time.");
        }
    }
}

