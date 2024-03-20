using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string StoreName { get; } = "Cherryl Patel's Car Rentals";
    public string StoreAddress { get; } = "547, Belmont Avenue West, Kitchener, CANADA";
    public string StorePhone { get; } = "+1 (519)-760-1111";
    public List<Car> AllCarsList => CarRepository.CarList;

    private readonly ILogger<IndexModel> _logger;
    public List<User> Users { get; set; } = new List<User>();
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Users = ReservationRepository.GetUsers();
    }
}
