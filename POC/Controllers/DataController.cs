using Microsoft.AspNetCore.Mvc;
using POC.Controllers.Models;
using POC.Entities;
using POC.Exceptions;
using POC.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet("companyManagement/{reference}")]
        public async Task<ActionResult<KpiDataModel>> GetData(DateTime reference)
        {
            try
            {
                string data = await new KeyProcessIndicator().GetData(reference);
                return new KpiDataModel() { Data = data };
            }
            catch (BoaEntregaException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Um erro inesperado aconteceu");
            }
        }
    }
}
