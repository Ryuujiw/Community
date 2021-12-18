using Community.Models.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Community.Data
{
    public class MapContext : DbContext
    {
        private IConfiguration _configuration { get; set; }
        public MapContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MapDatabase"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
