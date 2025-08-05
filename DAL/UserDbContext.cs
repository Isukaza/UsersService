using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Models.Enums;

namespace DAL;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(u => u.Subscription)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SubscriptionId);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("subscriptions");
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Type)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(s => s.StartDate)
                .IsRequired();

            entity.Property(s => s.EndDate)
                .IsRequired();
        });

        modelBuilder.Entity<Subscription>().HasData(
            new Subscription
            {
                Id = 1,
                Type = SubscriptionType.Free,
                StartDate = new DateTime(2022, 05, 17, 15, 28, 19, DateTimeKind.Utc),
                EndDate = new DateTime(2099, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            },
            new Subscription
            {
                Id = 2,
                Type = SubscriptionType.Super,
                StartDate = new DateTime(2022, 05, 18, 15, 28, 19, DateTimeKind.Utc),
                EndDate = new DateTime(2022, 08, 18, 15, 28, 19, DateTimeKind.Utc)
            },
            new Subscription
            {
                Id = 3,
                Type = SubscriptionType.Trial,
                StartDate = new DateTime(2022, 05, 19, 15, 28, 19, DateTimeKind.Utc),
                EndDate = new DateTime(2022, 06, 19, 15, 28, 19, DateTimeKind.Utc)
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Email = "John@example.com", SubscriptionId = 2 },
            new User { Id = 2, Name = "Mark Shimko", Email = "Mark@example.com", SubscriptionId = 1 },
            new User { Id = 3, Name = "Taras Ovruch", Email = "Taras@example.com", SubscriptionId = 3 }
        );
    }
}