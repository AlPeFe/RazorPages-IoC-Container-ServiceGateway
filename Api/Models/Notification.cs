using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdAction { get; set; }
        public int IdType { get; set; }
        public int IdState { get; set; }
        public int Vhi { get; set; }
        public string GamId { get; set; }

        public Action IdActionNavigation { get; set; }
        public State IdStateNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
        public Vhi VhiNavigation { get; set; }
    }
}
