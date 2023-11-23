namespace Railway.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public int TainID { get; set; }

        public Train Train { get; set; }

        public int RouteID { get; set; }

        public Route Route { get; set; }
        public int WeekdaysID { get; set; }

        public Weekdays Weekdays { get; set; }
    }
}
