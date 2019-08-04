using System;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreRESTTemplate.Controllers
{
    [Route("api/[controller]")] // starts header for it
    [ApiController]
    public class NewController : Controller
    {
        // GET

        [HttpGet("{name}")]
        public string GetName(string name)
        {
            return name;
        }

        [HttpPost]
        public ActionResult<string> Post( string random)
        {
            return random;
        }

        [HttpPut]
        public ActionResult<string> Put(string random)
        {
            return random;
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
    
}