using Microsoft.EntityFrameworkCore;

namespace stPete2019
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
    }
}