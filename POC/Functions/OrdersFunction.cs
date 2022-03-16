using Amazon.Lambda.APIGatewayEvents;
using POC.Entities;
using POC.Exceptions;
using System;
using System.Net;
using System.Text.Json;

namespace POC.Functions
{
    public class OrdersFunction
    {
        public APIGatewayProxyResponse LambdaGet(APIGatewayProxyRequest newEvent)
        {
            newEvent.PathParameters.TryGetValue("id", out string idString);
            int id = int.Parse(idString);

            try
            {
                Order order = new Order(id);
                return new APIGatewayProxyResponse()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonSerializer.Serialize(order),
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
