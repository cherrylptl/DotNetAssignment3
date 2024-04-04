
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SuccessfulModel : PageModel
{
    public User? user;
    public Car? car;
    public int userID { get; set; }
    public int carID { get; set; }
    private readonly ILogger<SuccessfulModel> _logger;
    public SuccessfulModel(ILogger<SuccessfulModel> logger)
    {
        _logger = logger;

    }
    public void OnGet(int carId, int userId)
    {
        userID = userId;
        carID = carId;
        car = CarRepository.CarList.FirstOrDefault(car => car.Id == carID);
        user = ReservationRepository.USERS.FirstOrDefault(u => u.UserId == userID);
    }
}

