using Microsoft.EntityFrameworkCore;
namespace Chef_And_Dishes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        // "users" table is represented by this DbSet "Users"
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Dish> Dishs { get; set; }
    }
}
