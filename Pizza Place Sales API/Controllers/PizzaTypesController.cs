using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Place_Sales_API.Models;
using Pizza_Place_Sales_API.Data;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pizza_Place_Sales_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaTypesController : ControllerBase
    {
        //initialize context
        private readonly PizzaTypesApiContext _pizzaTypeContext;

        public PizzaTypesController(PizzaTypesApiContext pizzaTypeContext)
        {
            _pizzaTypeContext = pizzaTypeContext;
        }

        //Add new Pizza Type
        [HttpPost]
        public JsonResult AddPizzaType(PizzaTypes pizzaTypes)
        {
            var pizzaTypeSearch = _pizzaTypeContext.PizzaTypes.Find(pizzaTypes.PizzaTypeID);

            //check if pizza type already exist
            if (pizzaTypeSearch != null)
                return new JsonResult("There is an existing pizza type of this ID");
            else
                _pizzaTypeContext.PizzaTypes.Add(pizzaTypes);

            _pizzaTypeContext.SaveChanges();

            return new JsonResult(Ok(pizzaTypes));
        }

        //Edit existing Pizza Type
        [HttpPut]
        public JsonResult EditPizzaType(PizzaTypes pizzaTypes)
        {
            var pizzaTypeSearch = _pizzaTypeContext.PizzaTypes.Find(pizzaTypes.PizzaTypeID);

            //check if pizza type data is non-existent
            if (pizzaTypeSearch == null)
                return new JsonResult(NotFound());
            else
                _pizzaTypeContext.Entry(pizzaTypeSearch).CurrentValues.SetValues(pizzaTypes);

            _pizzaTypeContext.SaveChanges();

            return new JsonResult(Ok(pizzaTypes));
        }

        //Delete specific Pizza Type Data
        [HttpDelete]
        public JsonResult DeletePizzaType(string pizzaTypeID)
        {
            var result = _pizzaTypeContext.PizzaTypes.Find(pizzaTypeID);

            //checks if pizza type data was not even in database
            if (result == null)
                return new JsonResult(NotFound());

            _pizzaTypeContext.PizzaTypes.Remove(result);
            _pizzaTypeContext.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get specific Pizza Type
        [HttpGet]
        public JsonResult GetPizzaType(string pizzaTypeID)
        {
            var result = _pizzaTypeContext.PizzaTypes.Find(pizzaTypeID);

            //checks if pizza type exist
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Get all Pizzas that are currently in the database
        [HttpGet]
        public JsonResult GetAllPizzaTypes()
        {
            var result = _pizzaTypeContext.PizzaTypes.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
