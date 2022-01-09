using Microsoft.AspNetCore.Mvc;
using POC.Controllers.Models;
using POC.Entities;
using POC.Exceptions;
using System;
using System.Net;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            try
            {
                Order order = new Order(id);
                return order;
            }
            catch (BoaEntregaException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            };
        }

    }
}
