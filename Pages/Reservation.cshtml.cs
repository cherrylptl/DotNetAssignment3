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

        if (user.ReservationDateAndTime <= DateTime.Now)
        {
            ModelState.AddModelError("user.ReservationDateAndTime", "Reservation date & time should be greater than the current date & time.");
            return Page();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        user.UserId = ReservationRepository.GetUsers().Count + 1;
        ReservationRepository.AddUser(user);
        CarRepository.BookCar(user.SelectedCarId ?? 0);

        return RedirectToPage("Successful", user);
    }
}

