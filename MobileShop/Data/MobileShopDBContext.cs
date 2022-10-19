using Microsoft.EntityFrameworkCore;
using MobileShop.Models;

namespace MobileShop.Data
{
    public class MobileShopDBContext : DbContext
    {
        public MobileShopDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Mobiles>? Mobiles { get; set; }
        public DbSet<Laptops>? Laptops { get; set; }
    }

}

