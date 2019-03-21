using Api.Models;
using Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public interface IGamDroidDbService
    {
       
        Client AddNewClient(Client client);

        DeviceConfigurationResponse GetDeviceConfiguration(LoginModel user);
    }
}
