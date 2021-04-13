using Postter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Postter.Infrastructure.Data.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(){}
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=ec2-52-50-171-4.eu-west-1.compute.amazonaws.com;Port=5432;Database=d8bpenst2veosd;Username=cbattjwtpawoar;Password=c0849f04ff550534bc1997583f654c5c9d7cf9f67a488cf0be96f08989539083;SslMode=Require;Trust Server Certificate=true");
        }

        public DbSet<User> Users { get; set; }
    }
}