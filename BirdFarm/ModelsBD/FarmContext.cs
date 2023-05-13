using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BirdFarm.ModelsBD
{
    public class FarmContext : DbContext
    {

        public FarmContext(DbContextOptions<FarmContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Egg> Eggs { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
