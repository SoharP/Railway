using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Railway.Models
{
    public class Station
    {
        public string StationID { get; set; }

        [DisplayName("Platform Number")]
        public int PlatformNo { get; set; }

        [DisplayName("Time Of Arrival")]
        [DataType(DataType.Time)]
        public string TimeOfArrival { get; set; }

        [DisplayName("Time Of Departure")]
        [DataType(DataType.Time)]
        public string TimeOfDeparture{ get; set; }

        public int TrainID { get; set; }

        public Train Train { get; set; }
    }
}
