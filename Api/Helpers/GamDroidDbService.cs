using Api.Models;
using Api.Utils;
using Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class GamDroidDbService : IGamDroidDbService
    {
        private readonly gamdroidContext _context;
        IUserAuthService _userAuthService;

        public GamDroidDbService(gamdroidContext context, IUserAuthService userAuthService)
        {
            _context = context;
            _userAuthService = userAuthService;
        }
       
        public Client AddNewClient(Client client)
        {
            _context.Client.Add(client);

            _context.SaveChanges();

            return client;
        }

        public DeviceConfigurationResponse GetDeviceConfiguration(LoginModel user)
        {
            if (_userAuthService.GetUserAuthorization(user))
            {
               return _context.Client
                    .Where(c => c.ClientCode == user.ClientCode)
                    .Select(v => new DeviceConfigurationResponse
                    {
                        DeviceConfiguration = new DeviceConfiguration
                        {
                            ClientCode = v.ClientCode,
                            RestUrl = v.HostUrl,
                            PushNotificationServiceUrl = ""
                        },
                        Response = true
                    }).First();        
            }

            return new DeviceConfigurationResponse { Response = false };
        }
    }
}
