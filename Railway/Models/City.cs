using System.ComponentModel;

namespace Railway.Models
{
    public class City
    {
        public int CityID { get; set; }

        [DisplayName("City Name")]
        public string Name { get; set; }
        [DisplayName("Suburb Name")]
        public string SubName { get; set; }

        public ICollection<Station> Station { get; set; }
    }
}
