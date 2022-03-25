using Amazon.Lambda.APIGatewayEvents;
using POC.Entities;
using POC.Exceptions;
using POC.Models;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace POC.Functions
{
    public class DataFunction
    {
        public APIGatewayProxyResponse LambdaGet(APIGatewayProxyRequest newEvent)
        {
            newEvent.PathParameters.TryGetValue("reference", out string referenceString);
            DateTime reference = DateTime.Parse(referenceString);

            try
            {
                string data = new KeyProcessIndicator().GetDataToFunction(reference);
                var kpi = new KpiDataModel() { Data = data };

                return new APIGatewayProxyResponse()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonSerializer.Serialize(kpi),
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
                    Body = ex.Message
                };
            }
        }
    }
}
