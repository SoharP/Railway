using System.ComponentModel;

namespace Railway.Models
{
    public class Updates
    {
        public string UpdatesID { get; set; }

        [DisplayName("Time Of Arrival")]
        public int Time_Of_Arrival { get; set; }
        public string Delay { get; set; }

        [DisplayName("Time Of Departure")]
        public string Time_Of_Departutre { get; set; }

        [DisplayName("Platform Number")]
        public int Platform_No { get; set; }

        [DisplayName("LoginID")]
        public string Login_ID { get; set; }

        [DisplayName("Station Name")]
        public string Station_Name { get; set; }
        
    }
}

