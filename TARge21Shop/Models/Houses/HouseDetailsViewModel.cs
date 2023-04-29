namespace TARge21Shop.Models.Houses
{
    public class HouseDetailsViewModel
    {
        public Guid? Id { get; set; } //Guid allows larger numbers:  instead of a base-10 value (0-9) it allows for (0-z)
        public string BuildingType { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //only in database to know when entry was made and when it was last modified
        public DateTime ListedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
