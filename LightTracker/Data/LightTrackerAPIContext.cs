using Microsoft.EntityFrameworkCore;
using Models;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace LightTrackerAPI.Data
{
    public class LightTrackerAPIContext : DbContext
    {
        public DbSet<LightLog> LightLogs { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=192.168.148.128\\MSSQL;Initial Catalog=LightTrackerDB;User ID=philip;Password=123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
