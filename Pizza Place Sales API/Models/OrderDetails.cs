using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the order_details database schema into a class
    public class OrderDetails
    {
        [Key]
        [Index(0)]
        public int OrderDetailsID { get; set; }

        [Index(1)]
        public int OrderID { get; set; }

        [Index(2)]
        public string? PizzaID { get; set; }

        [Index(3)]
        public int Quantity { get; set; }
    }
}
