
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vaishnavi_Dere_assignment_04.Models;
namespace Vaishnavi_Dere_assignment_04.Data
{

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<VisitorRequest> VisitorRequests { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

}