using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OKTECH.Models;

namespace RJTECH_Authentication_.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; } = default!;
    }
}
