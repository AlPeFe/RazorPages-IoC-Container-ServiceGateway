using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Mappers.Dto;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class GamDroidDeviceConfiguration : Controller
    {
        IGamDroidDbService _gamDroidDbService;

        public GamDroidDeviceConfiguration(IGamDroidDbService gamDroidDbService)
        {
            _gamDroidDbService = gamDroidDbService;
        }

        // POST api/<controller>
        [HttpPost, Route("configuration")]
        [HttpPost]
        public DeviceConfigurationResponse Post([FromBody]LoginModel user)
        {
            return _gamDroidDbService.GetDeviceConfiguration(user);
        }
    }
}
