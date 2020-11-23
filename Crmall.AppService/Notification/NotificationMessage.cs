using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.AppService.Notification
{
    public class NotificationMessage
    {
        public NotificationMessage(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; set; }
        public string Message { get; set; }

    }
}
