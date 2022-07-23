using Microsoft.EntityFrameworkCore;
using UserAuthExample.Models;

namespace UserAuthExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Contructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Creates table using the model
        public DbSet<User> User { get; set; }
    }
}
