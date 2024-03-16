using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{

    public string StoreName { get; } = "Cherryl Patel's Car Rentals";
    public string StoreAddress { get; } = "547, Belmont Avenue West, Kitchener, CANADA";
    public string StorePhone { get; } = "+1 (519)-760-1111";
    public List<Car> AvailableCars => CarRepository.CarList;


    private readonly ILogger<IndexModel> _logger;
    public List<User?> Users { get; set; } = new List<User?>();
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        Users = ReservationRepository.GetUsers();
    }
}
public class Car
{
    public required int Id { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string CarImage { get; set; }

    public required bool isReserved { get; set; }
}
public class User
{

    public User(int userId, string userName, string userContact, DateTime reservationDateAndTime)
    {
        this.UserId = userId;
        this.UserName = userName;
        this.UserContact = userContact;
        this.ReservationDateAndTime = reservationDateAndTime;

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
