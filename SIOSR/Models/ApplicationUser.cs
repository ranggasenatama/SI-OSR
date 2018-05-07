using Microsoft.AspNetCore.Identity;

namespace SIOSR.Models {

    public enum UserType {
        User,
        Staff,
        Admin
    }
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser {

        public UserType? UserType { get; set; }
    }
}
