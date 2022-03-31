using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApplication.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public TimeSpan StartTime { get; set; }

        public string EventType { get; set; }

        public string Organiser { get; set; }
        public int Duration { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InviteEmails { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
