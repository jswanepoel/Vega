using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Features)
                .WithOne(v => v.Vehicle)
                .HasPrincipalKey(v => v.Id);

            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.VehicleId, vf.FeatureId });



            //        modelBuilder
            //.Entity<PRAT>()
            //.HasOne(e => e.VW_PRATICHE_CONTIPO)
            //.WithOne()
            //.HasForeignKey<VW_PRATICHE_CONTIPO>();
        }
    }
}