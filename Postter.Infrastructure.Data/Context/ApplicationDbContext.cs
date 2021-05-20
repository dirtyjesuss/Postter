using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Postter.Domain.Models;

namespace Postter.Infrastructure.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private string _connectionString =
            "Host=ec2-54-228-99-58.eu-west-1.compute.amazonaws.com;Port=5432;Database=dfv616l4cmmlaf;Username=godyxmvqnyzxzs;Password=b70dfbe0bc41157d513746e4b114ee59a2863e327ffbc2a2ab3096a60aa35182;SslMode=Require;Trust Server Certificate=true";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follower> Followers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .IsRequired();
            modelBuilder.Entity<Follower>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<User>()
                .HasMany<Follower>(u => u.Followers)
                .WithOne(f => f.Follows)
                .HasForeignKey(f => f.FollowsId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany<Follower>(u => u.Following)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(_connectionString);
    }
}