using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Railway.Models
{
    public class Station
    {
        public int StationID { get; set; }

        [DisplayName("Sation Name")]
        public string Name { get; set; }

        [DisplayName("Station Address")]
        public string Address { get; set; }

        [DisplayName("Sation Suburb")]
        public string Suburb { get; set; }

        public int CityID { get; set; }

        public City City { get; set; }

        public ICollection<Schedule> Schedules { get; set; } 
    }
}
