using CarpentryWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
namespace CarpentryWorkshopDatabaseImplement
{
    public class CarpentryWorkshopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=KOMPUTER\SQLEXPRESS;Initial Catalog=CarpentryWorkshopDatabase;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Wood> Woods { set; get; }
        public virtual DbSet<WoodComponent> WoodComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}