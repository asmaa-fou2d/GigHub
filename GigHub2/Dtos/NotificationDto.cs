using GigHub2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub2.Dtos
{
    public class NotificationDto
    {

        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        public GigDto Gig { get; set; }


    }
}