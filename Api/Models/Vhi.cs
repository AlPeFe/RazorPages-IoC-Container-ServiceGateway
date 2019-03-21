using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Vhi
    {
        public Vhi()
        {
            Notification = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string ContextId { get; set; }
        public string CodigoVhi { get; set; }

        public ICollection<Notification> Notification { get; set; }
    }
}
