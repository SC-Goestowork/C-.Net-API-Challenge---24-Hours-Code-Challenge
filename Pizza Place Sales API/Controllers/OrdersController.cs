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
    public class OrdersController : ControllerBase
    {
        //initialize context
        private readonly OrdersApiContext _ordersContext;

        public OrdersController(OrdersApiContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        //Add new Order
        [HttpPost]
        public JsonResult AddOrder(Orders orders)
        {
            var orderSearch = _ordersContext.Orders.Find(orders.OrderID);

            //check if order already exist
            if (orderSearch != null)
                return new JsonResult("There is an existing order of this ID");
            else
                _ordersContext.Orders.Add(orders);

            _ordersContext.SaveChanges();

            return new JsonResult(Ok(orders));
        }

        //Edit existing Order
        [HttpPut]
        public JsonResult EditOrder(Orders orders)
        {
            var orderSearch = _ordersContext.Orders.Find(orders.OrderID);

            //check if order data is non-existent
            if (orderSearch == null)
                return new JsonResult(NotFound());
            else
                _ordersContext.Entry(orderSearch).CurrentValues.SetValues(orders);

            _ordersContext.SaveChanges();

            return new JsonResult(Ok(orders));
        }

        //Delete specific Order Data
        [HttpDelete]
        public JsonResult DeleteOrder(int orderID)
        {
            var result = _ordersContext.Orders.Find(orderID);

            //checks if order data was not even in database
            if (result == null)
                return new JsonResult(NotFound());

            _ordersContext.Orders.Remove(result);
            _ordersContext.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get specific Order
        [HttpGet]
        public JsonResult GetOrders(int orderID)
        {
            var result = _ordersContext.Orders.Find(orderID);

            //check if order exist
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Get all Orders that are currently in the database
        [HttpGet]
        public JsonResult GetAllOrders()
        {
            var result = _ordersContext.Orders.ToList();

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
    }
}
