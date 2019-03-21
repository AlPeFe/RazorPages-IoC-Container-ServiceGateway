using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ServiceGateway
{
    internal class ServiceClient : HttpClient
    {
        private readonly static ServiceClient _instance = new ServiceClient();

        private ServiceClient()
        {
            MaxResponseContentBufferSize = int.MaxValue;
            BaseAddress = new Uri("https://localhost:44321");
        }

        public static ServiceClient Instance
        {

            get
            {
                return _instance;
            }
        }
    }
}
