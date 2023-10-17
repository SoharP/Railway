namespace Railway.Models
{
    public class Station
    {
        public string StationID { get; set; }
        public int PlatformNo { get; set; }
        public string TimeOfArrival { get; set; }
        public string TimeOfDeparture{ get; set; }
        public int TrainID { get; set; }

        public Train Train { get; set; }
    }
}
