using Microsoft.EntityFrameworkCore;
using Models;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace LightTracker.Data
{
    public class LightTrackerContext : DbContext
    {
        public DbSet<LightLog> LightLogs { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=DEM0N;Initial Catalog=LightTrackerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
