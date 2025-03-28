using IT04_1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT04_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // ตั้งค่า Default Schema เป็น dbo
            builder.HasDefaultSchema("dbo");
            base.OnModelCreating(builder);
        }
    }
}
