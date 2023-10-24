using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Railway.Models
{
    public class Train
    {
        public int TrainID { get; set; }

        [DisplayName("Train Type")]
        public string Type { get; set; }

        [DisplayName("Number Of Carriages")]
        public string NumberofCarriages { get; set; }

        [DisplayName("Max Speed")]
        public string MaxSpeed { get; set; }

        [DisplayName("Max Capacity")]
        public string MaxCapacity { get; set; }

        [DataType(DataType.Date)]
        public string DOA { get; set; }

        public ICollection<Station> Stations { get; set; }
    }
}
