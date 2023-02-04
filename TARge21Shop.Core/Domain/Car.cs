using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Domain
{
    public class Car
    {
        [Key]
       public Guid? Id { get; set; } //Guid allows larger numbers:  instead of a base-10 value (0-9) it allows for (0-z)

        public string Brand { get; set; }
        public string Model { get; set; }
        public int PassengerCount { get; set; }
        public int FullTripsCount { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int EnginePower { get; set; }
        public DateTime BuiltDate { get; set; }

        //only in database to know when entry was made and when it was last modified
        public DateTime ListedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
