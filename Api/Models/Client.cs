using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string HostUrl { get; set; }
        public string ClientName { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Password { get; set; }
    }
}
