using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using POC.Controllers.Models;
using POC.Exceptions;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Route> Get(int id)
        {
            
            var starting = new Coordinate(0, -id);
            var destination = new Coordinate(0, id);
            return new Route(starting, destination); ;
        }

        [HttpGet("{startingX}-{startingY}&{destinationX}-{destinationY}")]
        public ActionResult<Route> GetRoute(float startingX, float startingY, float destinationX, float destinationY)
        {
            try
            {
                var coordinates = new Coordinate[]
                {
                    new Coordinate(startingX, startingY),
                    new Coordinate(destinationX, destinationY)
                };

                if (coordinates.Length < 2)
                {
                    throw new BoaEntregaException("A rota deve ter ao menos um ponto de partida e um ponto de chegada");
                } 
                var route = new Route(coordinates.First(), coordinates.Last());
                return StatusCode((int)HttpStatusCode.OK, route);

            }
            catch(BoaEntregaException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            };

        }

    }
}
