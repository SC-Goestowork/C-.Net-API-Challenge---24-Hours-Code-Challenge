using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the pizza_types database schema into a class
    public class Pizzas
    {
        [Key]
        [Index(0)]
        public string? PizzaID { get; set; }

        [Index(1)]
        public string? PizzaTypeID { get; set; }

        [Index(2)]
        public string? Size { get; set; }

        [Index(3)]
        public float Price { get; set; }
    }
}
