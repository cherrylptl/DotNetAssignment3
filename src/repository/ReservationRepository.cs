public class ReservationRepository
{

    public static List<User> USERS = new List<User>();

    public static void AddUser(User user)
    {
        USERS.Add(user);
    }

    public static List<User> GetUsers()
    {
        return USERS;
    }

    //   public static List<User> GetUserWithId==()
    // {
    //     return USERS;
    // }

}