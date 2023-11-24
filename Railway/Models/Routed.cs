using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Railway.Models
{
    public class Routed
    {
        public int RoutedID { get; set; }

        [DisplayName("Time Of Arrival")]
        [DataType(DataType.Time)]
        public DateTime Time_Of_Arrival { get; set; }

        [DisplayName("Time Of Departure")]
        [DataType(DataType.Time)]
        public DateTime Time_Of_Departure { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

    }
}