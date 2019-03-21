using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class OsoftConfigurationController : Controller
    {
        IGamDroidDbService _gamDroidDbService;
        public OsoftConfigurationController(IGamDroidDbService gamDroidDbService)
        {
            _gamDroidDbService = gamDroidDbService;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]Client client)
        {
            if (ModelState.IsValid)
            {
                return Ok ( new { GamDroidClient = _gamDroidDbService.AddNewClient(client) });
            }

            return Unauthorized();
        }

        // PUT api/<controller>/5
        [Authorize] 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
