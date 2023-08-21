using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeatMaps
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Private readonly IUserResolver
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // keys of identity tables are mapped in OnModelCreating method of IdentityDbContext Class.
            base.OnModelCreating(modelBuilder);
            //creating intial seed data
            //modelBuilder.seed();
            //modelBuilder.seed1();
            ////solve issue with composite primary key on DisposableEmployeeData.
            //modelBuilder.Entity<DisposableEmployeeData>().HasKey(c =>new
            //{c.ReferenceId,c.EmployeeId });
        }
        public void AddCascadingObject(object RootEntity)
        {
            ChangeTracker.TrackGraph(
                RootEntity,
                node => node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged
                );
        }

        ///dbsets
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
