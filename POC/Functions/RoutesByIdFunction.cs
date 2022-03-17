using Amazon.Lambda.APIGatewayEvents;
using POC.Controllers.Models;
using POC.Exceptions;
using System;
using System.Net;
using System.Text.Json;

namespace POC.Functions
{
    public class RoutesByIdFunction
    {
        public APIGatewayProxyResponse LambdaGet(APIGatewayProxyRequest newEvent)
        {
            newEvent.PathParameters.TryGetValue("id", out string idString);
            int id = int.Parse(idString);

            try
            {
                if (id > 180) id = id % 180;
                var starting = new Coordinate(0, -id);
                var destination = new Coordinate(0, id);
                var route = new Route(starting, destination);

                return new APIGatewayProxyResponse()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonSerializer.Serialize(route),
                };

            }
            catch (BoaEntregaException ex)
            {
                return new APIGatewayProxyResponse()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Body = ex.Message
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new APIGatewayProxyResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Body = "Sorry, contact an admin"
                };
            }
        }
    }
}
