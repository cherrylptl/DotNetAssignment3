using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReservationModel : PageModel
{
    private readonly ILogger<ReservationModel> _logger;

    public User? user;

    public List<Car> AvailableCars => CarRepository.GetAvailableCars();
    public ReservationModel(ILogger<ReservationModel> logger)
    {
        _logger = logger;

    }
    public void OnGet()
    {
    }

    public IActionResult OnPost(User user)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        user.UserId = ReservationRepository.GetUsers().Count + 1;
        ReservationRepository.AddUser(user);
        CarRepository.BookCar(user.SelectedCarId);

        return RedirectToPage("Successful", user);
    }


}

public class User
{

    public User(int userId, string userName, string userContact, DateTime reservationDateAndTime, int selectedCarId)
    {
        this.UserId = userId;
        this.UserName = userName;
        this.UserContact = userContact;
        this.ReservationDateAndTime = reservationDateAndTime;
        this.SelectedCarId = selectedCarId;

    }
    public User()
    {
    }

    public required int UserId { get; set; }

    [Required(ErrorMessage = "User name is required"), StringLength(50, MinimumLength = 3, ErrorMessage = "User name has to be minimum 3 letters to maximum 20 letters")]

    public required string UserName { get; set; }

    [Required(ErrorMessage = "Phone number is required"), RegularExpression("([0-9]+(-[0-9]+)+)", ErrorMessage = "Please provide a valid phone number eg: XXX-XXX-XXXX")]

    public required string UserContact { get; set; }

    [Required(ErrorMessage = "Reservation Date & Time is required")]
    public required DateTime ReservationDateAndTime { get; set; }

    [Required(ErrorMessage = "Please select the car")]
    public int SelectedCarId { get; set; }
}
