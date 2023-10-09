namespace Railway.Models
{
    public class Station
    {
        public string StationName { get; set; }
        public int PlatformNo { get; set; }
        public string TimeOfArrival { get; set; }
        public string TimeOfDeparture{ get; set; }
        public int TrainID { get; set; }

        public TrainID TrainID { get; set; }
    }
}
