using System.ComponentModel.DataAnnotations;

namespace Railway.Models
{
    public class Weekdays
    {
        public int WeekdaysID { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
