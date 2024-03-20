
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SuccessfulModel : PageModel
{
    public User? user;
    public Car? car;
    private readonly ILogger<SuccessfulModel> _logger;
    public SuccessfulModel(ILogger<SuccessfulModel> logger)
    {
        _logger = logger;

    }
    public void OnGet(User _user)
    {
        user = _user;
        car = CarRepository.CarList.FirstOrDefault(car => car.Id == user!.SelectedCarId);
    }
}

