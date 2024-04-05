using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pizza_Place_Sales_API
{
    //This is to map the orders database schema into a class
    public class Orders
    {
        [Key]
        [Index(0)]
        public int OrderID { get; set; }

        [Index(1)]
        public string? Date { get; set; }

        [Index(2)]
        public string? Time { get; set; }

    }
}
