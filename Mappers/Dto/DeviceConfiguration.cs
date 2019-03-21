using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers.Dto
{
    public class DeviceConfiguration
    {
        public string RestUrl { get; set; }

        public string ClientCode { get; set; }

        public string PushNotificationServiceUrl { get; set; }

    }

    public class StatusSettings
    {
        public bool MultiStatus { get; set; }

        public bool Activation { get; set; }

        public bool Origin { get; set; }

        public bool Evacuation { get; set; }

        public bool Destination { get; set; }

        public bool Transfer { get; set; }

        public bool Free { get; set; }

    }


    public class DeviceConfigurationResponse
    {
        public bool Response { get; set; }

        public DeviceConfiguration DeviceConfiguration { get; set; }
    }
}
