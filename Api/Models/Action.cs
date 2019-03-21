using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Action
    {
        public Action()
        {
            Notification = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Notification> Notification { get; set; }
    }
}
