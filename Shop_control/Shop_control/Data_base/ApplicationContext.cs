using Microsoft.EntityFrameworkCore;
using Shop_control.Data_base;

namespace Shop_control.Data_base
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Classifications> classifications { get; set; } = null!;
        public DbSet<Countryes> countryes { get; set; } = null!;
        public DbSet<Cities> cities { get; set; } = null!;
        public DbSet<Street> streets { get; set; } = null!;
        public DbSet<Adresses> adresses { get; set; } = null!;
        public DbSet<Suppliers> suppliers { get; set; } = null!;
        public DbSet<Positions> positions { get; set; } = null!;
        public DbSet<Persons> persons { get; set; } = null!;
        public DbSet<Adresses_type> adresses_types { get; set; } = null!;
        public DbSet<Persons_adress> persons_adress { get; set; } = null!;
        public DbSet<Shops> shops { get; set; } = null!;
        public DbSet<Regular_customers> regular_customers { get; set; } = null!;
        public DbSet<Employees> employees { get; set; } = null!;
        public DbSet<Furnitures> furnitures { get; set; } = null!;
        public DbSet<Operations> operations { get; set; } = null!;
        public DbSet<Transactions> transactions { get; set; } = null!;
        public DbSet<Turnovers> turnovers { get; set; } = null!;



        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Furnitures_shop;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }
}
