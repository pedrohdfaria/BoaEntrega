using Microsoft.AspNetCore.Mvc;
using POC.Controllers.Models;
using POC.Entities;
using System;
using System.Threading.Tasks;

namespace POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet("companyManagement")]
        public async Task<ActionResult<FileResult>> GetOrder(DateTime reference)
        {
            string fileName = "kpi.csv";
            byte[] fileBytes = await new KeyProcessIndicator().GetData(reference);

            return File(fileBytes, "text/csv", fileName); 
        }
    }
}
