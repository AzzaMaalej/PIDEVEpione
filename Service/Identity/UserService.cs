using Data;
using Service.Identity;


namespace Volunteering.Service.Identity
{

    // TODO Refactor UserService Class 

    public class UserService
    {
        public ApplicationUserManager UserManager { get; set; }

        public UserService()
        {
            ApplicationUserStore store = new ApplicationUserStore(new PiContext());
            UserManager = new ApplicationUserManager(store);
        }



    }
}
