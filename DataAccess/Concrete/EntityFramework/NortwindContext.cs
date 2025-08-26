using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // context : db tabloları ile proje classlarını bağlamak için kullanılır ilişkilendirir
    public class NortwindContext : DbContext
    {
        //veri tabanına bağlanma kodu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //server= dedikten sonra normalde ip adresi girilir : 175.45.2.12 gibi
            //biz şimdilik direk db ye bağlanıyoruz
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB ; Database=Northwind ; Trusted_Connection=true");
        }

        //hangi tablo hangi classa karşılık gelecek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Burayı yazınca EfProductDala git Add Delete gibi metotları yapılandırmaya başla


    }
}
