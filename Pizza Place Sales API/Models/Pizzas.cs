using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the pizza_types database schema into a class
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
