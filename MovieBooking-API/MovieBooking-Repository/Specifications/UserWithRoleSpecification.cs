using MovieBooking_DomainModels;

namespace MovieBooking_Repository.Specifications
{
    public class UserWithRoleSpecification : BaseSpecification<User>
    {
        public UserWithRoleSpecification()
        {
            AddIncludes(x => x.Role);
        }

        public UserWithRoleSpecification(int ID) : base(x => x.Id == ID)
        {
            AddIncludes(x => x.Role);
        }
    }
}