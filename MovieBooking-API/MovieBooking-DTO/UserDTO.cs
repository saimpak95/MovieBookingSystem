using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking_DTO
{
   public class UserDTO
    {
       
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Mobile { get; set; }
            public string  Role { get; set; }
        
    }
}
