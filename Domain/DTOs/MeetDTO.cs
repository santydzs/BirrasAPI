using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class MeetDTO
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal Temp { get; set; }
        public List<NotificationDTO> Notifications { get; set; }
    }
}
