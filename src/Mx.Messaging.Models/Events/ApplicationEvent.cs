
using System;

namespace Mx.Messaging.Models.Events
{
    public class ApplicationEvent
    {
        public string EventType { get; set; }

        public string Body { get; set;  }

        //public DateTime Sent { get; set; }
    }
}
