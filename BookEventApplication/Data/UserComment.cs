using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApplication.Data
{
    public class UserComment
    {
        [Key]
        public int CommentId { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Events { get; set; }
        public string Comment { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
