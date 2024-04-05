using Microsoft.EntityFrameworkCore;
using Pizza_Place_Sales_API.Models;

namespace Pizza_Place_Sales_API.Data
{
    //This is to set up the Order into an API context
    public class OrdersApiContext : DbContext
    {
        //DbSet will be used to store data InMemory
        public DbSet<Orders> Orders { get; set; }

        public OrdersApiContext(DbContextOptions<OrdersApiContext> options)
            : base(options)
        {
            
        }
    }
}
