using Microsoft.EntityFrameworkCore;
using Venu.Identity.Domain;

namespace Venu.Identity.DataAccess
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("IdentityContext :: ctor => " + this.GetHashCode());
        }
    }
}