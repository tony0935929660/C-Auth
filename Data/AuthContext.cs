using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class AuthContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=Auth;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
