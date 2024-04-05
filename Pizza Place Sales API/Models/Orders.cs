using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API
{
    //This is to map the orders csv schema into a class
    public class Orders
    {
        [Key]
        [Name("order_id")]
        public int OrderID { get; set; }

        [Name("date")]
        public string? Date { get; set; }

        [Name("time")]
        public string? Time { get; set; }

    }
}
