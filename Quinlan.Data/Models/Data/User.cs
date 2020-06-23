using System;
using System.Collections.Generic;
using System.Text;

namespace Quinlan.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } // doubt this is needed
        public Person Person { get; set; }
    }
}
