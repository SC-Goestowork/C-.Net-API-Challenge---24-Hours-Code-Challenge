using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the order_details csv schema into a class
    public class OrderDetails
    {
        [Key]
        [Name("order_details_id")]
        public int OrderDetailsID { get; set; }

        [Name("order_id")]
        public int OrderID { get; set; }

        [Name("pizza_id")]
        public string? PizzaID { get; set; }

        [Name("quantity")]
        public int Quantity { get; set; }
    }
}
