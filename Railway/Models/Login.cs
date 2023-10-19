using System.ComponentModel;

namespace Railway.Models
{
    public class Login
    {
        public string LoginID { get; set; }
        public int Username { get; set; }
        public string Password { get; set; }

        [DisplayName("Phone Number")]
        public string Phone_Number { get; set; }

        public int Email { get; set; }

        
    }
}

 
