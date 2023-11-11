using Microsoft.EntityFrameworkCore;
using Models;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace LightTracker.Data
{
    public class LightTrackerContext : DbContext
    {
        public DbSet<MQTTMessage> MQTTMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=LILLEBRG-LAP\\TECH2DB;Initial Catalog=LightTrackerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
