namespace TARge21Shop.Models.Spaceship
{
    public class SpaceshipIndexViewModel
    {
        public Guid? Id { get; set; } //Guid allows larger numbers:  instead of a base-10 value (0-9) it allows for (0-z)

        public string Name { get; set; }
        public string Type { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int CargoWeight { get; set; }
        public int FullTripsCount { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int EnginePower { get; set; }
        public DateTime MaidenLaunch { get; set; }
        public DateTime BuiltDate { get; set; }


        //only in database to know when entry was made and when it was last modified
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
