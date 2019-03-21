using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers.Dto
{
    public class GamDroidClient
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string HostUrl { get; set; }
        public string ClientName { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public string Password { get; set; }
    }
}
