using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Place_Sales_API.Models;
using Pizza_Place_Sales_API.Data;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;

namespace Pizza_Place_Sales_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        //initialize context
        private readonly OrderDetailsApiContext _orderDetailsContext;

        public OrderDetailsController(OrderDetailsApiContext orderDetailsContext)
        {
            _orderDetailsContext = orderDetailsContext;
        }

        //Add new Order Detail
        [HttpPost]
        public JsonResult AddOrderDetails(OrderDetails orderDetails)
        {
            var orderDetailSearch = _orderDetailsContext.OrderDetails.Find(orderDetails.OrderDetailsID);

            //check if order detail already exist
            if (orderDetailSearch != null)
                return new JsonResult("There is an existing order detail of this ID");
            else
                _orderDetailsContext.OrderDetails.Add(orderDetails);

            _orderDetailsContext.SaveChanges();

            return new JsonResult(Ok(orderDetails));
        }

        //Edit existing Order Detail
        [HttpPost]
        public JsonResult EditOrderDetails(OrderDetails orderDetails)
        {
            var orderDetailSearch = _orderDetailsContext.OrderDetails.Find(orderDetails.OrderDetailsID);

            //check if order detail data is non-existent
            if (orderDetailSearch == null)
                return new JsonResult(NotFound());
            else
                _orderDetailsContext.Entry(orderDetailSearch).CurrentValues.SetValues(orderDetails);

            _orderDetailsContext.SaveChanges();

            return new JsonResult(Ok(orderDetails));
        }

        //Delete specific Order Detail Data
        [HttpDelete]
        public JsonResult DeleteOrderDetails(int orderDetailID)
        {
            var result = _orderDetailsContext.OrderDetails.Find(orderDetailID);

            //checks if order detail data was not even in database
            if (result == null)
                return new JsonResult(NotFound());

            _orderDetailsContext.OrderDetails.Remove(result);
            _orderDetailsContext.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get specific Order Detail
        [HttpGet]
        public JsonResult GetOrderDetails(int orderDetailID)
        {
            var result = _orderDetailsContext.OrderDetails.Find(orderDetailID);

            //check if order detail exist
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Get all Orders that are currently in the database
        [HttpGet]
        public JsonResult GetAllOrderDetails()
        {
            var result = _orderDetailsContext.OrderDetails.ToList();

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
    }
}
