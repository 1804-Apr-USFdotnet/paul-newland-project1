using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Reviews)
                .WithRequired(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Reviews)
                .WithRequired(r => r.Restaurant)
                .HasForeignKey(r => r.RestaurantId);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}