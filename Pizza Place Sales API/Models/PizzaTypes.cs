﻿using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_Place_Sales_API.Models
{
    //This is to map the pizza_types database schema into a class
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
