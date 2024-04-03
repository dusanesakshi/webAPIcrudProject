using Microsoft.EntityFrameworkCore;
namespace webAPIcrudProject.Data
{
    public class APIDbContext :DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options):base(options) 
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
