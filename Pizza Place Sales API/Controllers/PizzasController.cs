using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Place_Sales_API.Models;
using Pizza_Place_Sales_API.Data;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;
using CsvHelper;
using System.Linq;

namespace Pizza_Place_Sales_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        //initialize context
        private readonly PizzasApiContext _pizzaContext;

        public PizzasController(PizzasApiContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        //Add new Pizza
        [HttpPost]
        public JsonResult AddPizza(Pizzas pizzas)
        {
            var pizzaSearch = _pizzaContext.Pizzas.Find(pizzas.PizzaID);

            //check if pizza already exist
            if (pizzaSearch != null)
                return new JsonResult("There is an existing pizza of this ID");
            else
                _pizzaContext.Pizzas.Add(pizzas);

            _pizzaContext.SaveChanges();

            return new JsonResult(Ok(pizzas));
        }

        //Edit existing Pizza
        [HttpPut]
        public JsonResult EditPizza(Pizzas pizzas)
        {
            var pizzaSearch = _pizzaContext.Pizzas.Find(pizzas.PizzaID);

            //check if pizza data is non-existent
            if (pizzaSearch == null)
                return new JsonResult(NotFound());
            else
                _pizzaContext.Entry(pizzaSearch).CurrentValues.SetValues(pizzas);

            _pizzaContext.SaveChanges();

            return new JsonResult(Ok(pizzas));
        }

        //Delete specific Pizza Data
        [HttpDelete]
        public JsonResult DeletePizza(string pizzaID) 
        {
            var result = _pizzaContext.Pizzas.Find(pizzaID);

            //checks if pizza data was not even in database
            if (result == null)
                return new JsonResult(NotFound());

            _pizzaContext.Pizzas.Remove(result);
            _pizzaContext.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get specific Pizza
        [HttpGet]
        public JsonResult GetPizza(string pizzaID)
        {
            var result = _pizzaContext.Pizzas.Find(pizzaID);

            //checks if pizza exist
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Get all Pizzas that are currently in the database
        [HttpGet]
        public JsonResult GetAllPizzas()
        {
            var result = _pizzaContext.Pizzas.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
