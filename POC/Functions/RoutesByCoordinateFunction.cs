using Amazon.Lambda.APIGatewayEvents;
using POC.Controllers.Models;
using POC.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace POC.Functions
{
    public class RoutesByCoordinateFunction
    {
        public APIGatewayProxyResponse LambdaGet(APIGatewayProxyRequest newEvent)
        {
            try
            {
                decimal startingX = GetParameter(newEvent, "startingX");
                decimal startingY = GetParameter(newEvent, "startingY");
                decimal destinationX = GetParameter(newEvent, "destinationX");
                decimal destinationY = GetParameter(newEvent, "destinationY");

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

        private static decimal GetParameter(APIGatewayProxyRequest newEvent, string parameter)
        {
            newEvent.QueryStringParameters.TryGetValue(parameter, out string parameterString);
            return Math.Round(decimal.Parse(parameterString), 2);
        }
    }
}
