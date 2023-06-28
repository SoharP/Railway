 namespace Railway.Models
{
    public class Train
    {
        public int TrainID { get; set; }
        public string Type { get; set; }
        public string NumberofCarriages { get; set; }
        public string MaxSpeed { get; set; }
        public string MaxCapacity { get; set; }

        public ICollection<Station> Stations { get; set; }
}
}
