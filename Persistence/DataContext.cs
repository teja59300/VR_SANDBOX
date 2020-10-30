using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext:IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Financial> Financials { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
                base.OnModelCreating(builder);
                builder.Entity<Value>()
                .HasData(
                    new Value {Id=1,Name="surya"},
                    new Value {Id=2,Name="teja"},
                    new Value {Id=3,Name="surya teja"}
                );


                builder.Entity<Financial>(x => x.HasKey(fa =>
                    new {fa.ActivityId}));
                builder.Entity<Financial>()
                .HasOne(a => a.Activity)
                .WithMany(fa => fa.Financials)
                .HasForeignKey(a => a.ActivityId);


                builder.Entity<UserActivity>(x => x.HasKey(ua => 
                new {ua.AppUserId,ua.ActivityId}));

                builder.Entity<UserActivity>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.UserActivities)
                .HasForeignKey(u => u.AppUserId);

                builder.Entity<UserActivity>()
                .HasOne(a => a.Activity)
                .WithMany(u => u.UserActivities)
                .HasForeignKey(a => a.ActivityId);
        }
    }
}
