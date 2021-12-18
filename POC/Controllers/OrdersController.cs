using Microsoft.AspNetCore.Mvc;
using POC.Controllers.Models;
using POC.Entities;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            Order order = new Order(id);
            return order;
        }
    }
}
