using Microsoft.EntityFrameworkCore;
using webapi.Data.DataConfigs;
using webapi.models;

namespace webapi.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<User> Users { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Lot> Lots { get; set; }

        public DbSet<LotDescription> LotDescriptions { get; set; }

        public DbSet<UserBank > UserBanks { get; set; }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserBankConfug());
            modelBuilder.ApplyConfiguration(new LotDescriptionConfig());


        }

    } 

   
}
