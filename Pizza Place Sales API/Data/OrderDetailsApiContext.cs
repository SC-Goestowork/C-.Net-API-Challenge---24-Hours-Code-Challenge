using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pizza_Place_Sales_API.Models;
using System.Globalization;

namespace Pizza_Place_Sales_API.Data
{
    //This is to set up the Order Details CSV into an API context
    public class OrderDetailsApiContext : DbContext
    {
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public OrderDetailsApiContext(DbContextOptions<OrderDetailsApiContext> options)
            : base(options)
        {

        }
    }
}
