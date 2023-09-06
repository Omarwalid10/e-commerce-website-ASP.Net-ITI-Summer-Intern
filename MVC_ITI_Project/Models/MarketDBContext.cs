using Microsoft.EntityFrameworkCore;

namespace MVC_ITI_Project.Models
{
    public class MarketDBContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JTPRIP3\\MSSQLSERVER01; Database=Market_Place; Trusted_Connection = true; TrustServerCertificate = true");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product>  products { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<User> users { get; set; }
    }
}
