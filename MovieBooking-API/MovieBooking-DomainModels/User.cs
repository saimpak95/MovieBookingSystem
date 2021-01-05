using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking_DomainModels
{
   public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
