using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class User
{

    public User(int userId, string userName, string userContact, DateTime reservationDateAndTime, int selectedCarId)
    {
        this.UserId = userId;
        this.UserName = userName;
        this.UserContact = userContact;
        this.ReservationDateAndTime = reservationDateAndTime;
        this.SelectedCarId = 1;

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
    public required DateTime? ReservationDateAndTime { get; set; }

    [Required(ErrorMessage = "Please select the car")]
    public required int? SelectedCarId { get; set; }
}
