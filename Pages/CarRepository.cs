public class CarRepository
{
    public static List<Car> CarList { get; } = new List<Car>
    {
        new Car { Id = 1, Brand = "Rolls-Royce", Model = "Phantom",Description="The Rolls-Royce Phantom epitomizes luxury with its timeless design and exquisite craftsmanship, setting the standard for automotive excellence worldwide.",CarImage="image\\phantom.jpeg",isReserved=false},
        new Car { Id = 2, Brand = "Lamborghini", Model = "Huracan",Description="A sleek and powerful supercar, epitomizing speed and style on the road. With its striking design and exhilarating performance, it captivates enthusiasts worldwide.",CarImage="image\\Huracan.jpg",isReserved=false},
        new Car { Id = 3, Brand = "Ferrari", Model = "Ferrari 812 GTS",Description="A marvel of engineering and design, embodying raw power and exhilarating performance. With its iconic Ferrari lineage and open-top driving experience, it delivers thrills like no other.",CarImage="image\\Ferrari.jpg",isReserved=false},
        new Car { Id = 4, Brand = "Mercedes-Benz", Model = "Maybach",Description=" A pinnacle of automotive luxury, blending sophistication with cutting-edge technology. With its opulent interior and refined engineering, it offers unparalleled comfort and prestige on the road.",CarImage="image\\Maybach.jpg",isReserved=false},
        new Car { Id = 5, Brand = "Bugatti", Model = "Chiron",Description="A masterpiece of automotive engineering, pushing the boundaries of speed and luxury. With its breathtaking design and unmatched performance, it reigns supreme as the epitome of automotive excellence.",CarImage="image\\Chiron.jpg",isReserved=false},
        new Car { Id = 6, Brand = "Ford", Model = "Mustang",Description=" An iconic American muscle car, symbolizing power, performance, and freedom on the open road. With its legendary design and exhilarating driving experience, it continues to inspire enthusiasts around the world.",CarImage="image\\Mustang.jpg",isReserved=false},
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

public class Car
{
    public required int Id { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string Description { get; set; }
    public required string CarImage { get; set; }
    public required bool isReserved { get; set; }
}