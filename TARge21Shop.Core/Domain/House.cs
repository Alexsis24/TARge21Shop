
using System.ComponentModel.DataAnnotations;

namespace TARge21Shop.Core.Domain
{
    public class House
    {
        [Key]
        public Guid? Id { get; set; }
        public string BuildingType { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime ListedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
