using Microsoft.AspNetCore.Identity;

namespace Vaishnavi_Dere_assignment_04.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
