
using Foundation.Models;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
