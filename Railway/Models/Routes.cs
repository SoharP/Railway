using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Railway.Models
{
    public class Routes
    {      
        public int RoutesID { get; set; }
        public int Price { get; set; }
        public string TrainLine { get; set; }
        public string LineStatus { get; set; }
    }
}
   