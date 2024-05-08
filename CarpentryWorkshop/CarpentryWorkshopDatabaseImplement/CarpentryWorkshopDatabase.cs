using Microsoft.EntityFrameworkCore;
using CarpentryWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement
{
    public class CarpentryWorkshopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=CarpentryWorkshopDatabaseLab51;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Wood> Woods { set; get; }
        public virtual DbSet<WoodComponent> WoodComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
        public virtual DbSet<MessageInfo> MessageInfos { set; get; }
    }
}