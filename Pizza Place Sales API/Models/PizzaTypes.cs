using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the pizza_types csv schema into a class
    public class PizzaTypes
    {
        [Key]
        [Name("pizza_type_id")]
        public string? PizzaTypeID { get; set; }

        [Name("name")]
        public string? Name { get; set; }

        [Name("category")]
        public string? Category { get; set; }

        [Name("ingredients")]
        public string? Ingredients { get; set; }
    }
}
