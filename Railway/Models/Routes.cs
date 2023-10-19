using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;

namespace Railway.Models
{
    public class Routes
    {      
        public int RoutesID { get; set; }
        public int Price { get; set; }

        [DisplayName("Train Line")]
        public string TrainLine { get; set; }

        [DisplayName("Line Status")]
        public string LineStatus { get; set; }
    }
}
   