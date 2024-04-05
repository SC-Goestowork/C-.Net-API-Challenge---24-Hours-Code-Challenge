using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pizza_Place_Sales_API.Models;

namespace Pizza_Place_Sales_API.Data
{
    //This is to set up the Pizzas into an API context
    public class PizzasApiContext : DbContext
    {
        public DbSet<Pizzas> Pizzas { get; set; }

        public PizzasApiContext(DbContextOptions<PizzasApiContext> options)
            : base(options)
        {
            
        }
    }
}
