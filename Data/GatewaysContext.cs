using Gateways.Models;
using Microsoft.EntityFrameworkCore;

namespace Gateways.Data
{
    public class GatewaysContext : DbContext
    {
        public GatewaysContext(DbContextOptions<GatewaysContext> opt) : base(opt)
        {
        }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Device>()
                .HasOne(_ => _.Gateway)
                .WithMany(_ => _.Devices)
                .HasForeignKey(_ => _.SerialNumber);                
        }
    }
}
