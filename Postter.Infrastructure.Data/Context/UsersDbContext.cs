using Postter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Postter.Infrastructure.Data.Context
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options):base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("Host=ec2-54-155-87-214.eu-west-1.compute.amazonaws.com;" +
                                         "Port=5432;Database=d4gnsnnlifl664;" +
                                         "Username=jobocqezlhcciu;" +
                                         "Password=dfc1ed31cf7d6f844d535e9dad2973f792991603661ae177ec0516139a95ca14;" +
                                         "SslMode=Require;" +
                                         "Trust Server Certificate=true");
        }

    }
}