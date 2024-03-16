public static class CarRepository
{
    public static List<Car> CarList { get; } = new List<Car>
    {
        new Car { Id = 1, Brand = "Rolls-Royce", Model = "Phantom",CarImage="phantom.jpeg",isReserved=false},
        new Car { Id = 2, Brand = "Lamborghini", Model = "Huracan",CarImage="Huracan.jpg",isReserved=false},
        new Car { Id = 3, Brand = "Ferrari", Model = "Ferrari 812 GTS",CarImage="Ferrari812.jpg",isReserved=false},
        new Car { Id = 4, Brand = "Mercedes-Benz", Model = "Maybach",CarImage="image\\Maybach.jpg",isReserved=false},
        new Car { Id = 5, Brand = "Bugatti", Model = "Chiron",CarImage="image\\Chiron.jpg",isReserved=false},
        new Car { Id = 6, Brand = "Ford", Model = "Mustang",CarImage="https://i.pinimg.com/564x/ab/5f/18/ab5f184aafd8af9aed2a16a4bd8eca39.jpg",isReserved=false},
    };


    public static void BookCar(int carId)
    {
        Car carToBook = CarList.First(car => car.Id == carId);
        if (carToBook != null)
        {
            carToBook.isReserved = true;
        }
    }

    public static List<Car> GetAvailableCars()
    {
        return CarList.Where(car => !car.isReserved).ToList();
    }
}
