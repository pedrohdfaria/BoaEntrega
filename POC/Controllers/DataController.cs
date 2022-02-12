using Microsoft.AspNetCore.Mvc;
using POC.Controllers.Models;
using POC.Entities;
using POC.Exceptions;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet("companyManagement")]
        public async Task<ActionResult<string>> GetOrder(DateTime reference)
        {
            try
            {
                string data = await new KeyProcessIndicator().GetData(reference);
                return data;
            }
            catch (BoaEntregaException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Um erro inesperado aconteceu");
            };

        }
    }
}
