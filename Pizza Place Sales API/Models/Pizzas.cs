using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the pizza_types csv schema into a class
    public class Pizzas
    {
        [Key]
        [Name("pizza_id")]
        public string? PizzaID { get; set; }

        [Name("pizza_type_id")]
        public string? PizzaTypeID { get; set; }


        [Name("size")]
        public string? Size { get; set; }

        [Name("price")]
        public float Price { get; set; }
    }
}
