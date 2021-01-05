using MovieBooking_DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking_Repository.Specifications
{
   public class UserWithRoleSpecification :BaseSpecification<User>
    {
        public UserWithRoleSpecification()
        {
            AddIncludes(x => x.Role);
        }
        public UserWithRoleSpecification(int ID):base(x=>x.Id==ID)
        {
            AddIncludes(x => x.Role);
        }
    }
}
