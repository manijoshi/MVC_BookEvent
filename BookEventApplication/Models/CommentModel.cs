using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApplication.Models
{
    public class CommentModel
    {
        public int EventId { get; set; }
        public string Comment { get; set; }

        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
