namespace TARge21Shop.Models.Car
{
    public class CarIndexViewModel
    {
        public Guid? Id { get; set; } //Guid allows larger numbers:  instead of a base-10 value (0-9) it allows for (0-z)

        public string Brand { get; set; }
        public string Model { get; set; }
        public int PassengerCount { get; set; }
        public int FullTripsCount { get; set; }
        public int EnginePower { get; set; }
    }
}
