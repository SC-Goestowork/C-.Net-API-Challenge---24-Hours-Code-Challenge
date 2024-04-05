using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pizza_Place_Sales_API.Models;

namespace Pizza_Place_Sales_API.Data
{
    //This is to set up the Pizza Types into an API context
    public class PizzaTypesApiContext : DbContext
    {
        public DbSet<PizzaTypes> PizzaTypes { get; set; }

        public PizzaTypesApiContext(DbContextOptions<PizzaTypesApiContext> options)
            : base(options)
        {

        }
    }
}
